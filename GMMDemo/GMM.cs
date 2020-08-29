using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace GMMDemo
{
    public class GMM
    {
        private Random rand = new Random();

        public List<Vector2> pts = new List<Vector2>();
        public List<Gaussian_2D> gaussian_list = null;//HGMM tree structure. Can be quaried via GetChild(parent_idx)
        private int num_gaussian = 0;
        private List<double> class_prior = null;
        private List<List<double>> T = null;
        private List<int> current_idx = null;
        private List<int> parent_idx = null;
        private int num_levels = 1;
        public List<BaseModel> baseModels = new List<BaseModel>();

        private int iter = 0;
        private int max_iter = 80;//maximum iterations
        private double log_diff_thresh = 1E-9;//loglikelihood difference threshold

        public void Init()
        {
            gaussian_list = new List<Gaussian_2D>();
            class_prior = new List<double>(); 
            baseModels = new List<BaseModel>();
            T = new List<List<double>>();

            if (pts != null)
            {
                current_idx = new List<int>();
                parent_idx = new List<int>();
                for (int i = 0; i < pts.Count; i++)
                {
                    current_idx.Add(-1);
                    parent_idx.Add(-1);
                }

                //Clear the gaussian property of all points
                if (pts[0].gaussian_idx.Count > 0)
                {
                    for (int i = 0; i < pts.Count; i++)
                    {
                        pts[i].gaussian_idx.Clear();
                    }
                }
            }
        }

        public void DetectLastLevel(int level)
        {
            IEnumerable<int> level_gaussians = GetLevel(level-1);
            foreach (int i in level_gaussians)
            {
                List<Vector2> gaussian_i_pts = new List<Vector2>();

                foreach (Vector2 pt in pts)
                {
                    if (pt.gaussian_idx[level-1] == i)
                        gaussian_i_pts.Add(pt);
                }

                if (gaussian_i_pts.Count < 3)
                    continue;
                
                BaseModel lineModel = new LineModel();
                lineModel = RANSAC.Fit(gaussian_i_pts, lineModel);
                baseModels.Add(lineModel);
            }
        }

        private List<Gaussian_2D> ClusteringInitGMM(int level, int init_type)
        {
            List<Gaussian_2D> cluster_list = new List<Gaussian_2D>();
            if (level != 0)
            {
                IEnumerable<int> parent_level_gaussians = GetLevel(level - 1);
                foreach (int i in parent_level_gaussians)
                {
                    List<Vector2> parent_pts = new List<Vector2>();
                    List<Gaussian_2D> cluster_list_i = new List<Gaussian_2D>();

                    foreach (Vector2 pt in pts)
                    {
                        if (pt.gaussian_idx[level - 1] == i)
                            parent_pts.Add(pt);
                    }

                    //if there are fewer points than num_gaussian * 2 in the parent gaussian, stop partition
                    //if (parent_pts.Count <= num_gaussian * 2 || gaussian_list[i].partition == false)
                    if (parent_pts.Count < num_gaussian || gaussian_list[i].partition == false)
                    {
                        Console.WriteLine("===========Stopping at gaussian {0}==============", i);
                        //gaussian_list[i].partition = false;
                        for (int j = 0; j < num_gaussian; j++)
                        {
                            Gaussian_2D gau = new Gaussian_2D();
                            gau.partition = false;
                            gau.dropped = true;
                            cluster_list_i.Add(gau);
                        }
                        cluster_list = cluster_list.Concat(cluster_list_i).ToList();

                        /*
                        if (parent_pts.Count > 2 && gaussian_list[i].dropped == false)
                        {
                            BaseModel lineModel = new LineModel();
                            lineModel = RANSAC.Fit(parent_pts, lineModel);
                            baseModels.Add(lineModel);
                        }
                        */

                        continue;
                    }

                    if (init_type == 1)
                    {
                        cluster_list_i = FuzzyCMeans.fit(parent_pts, num_gaussian);
                    }
                    else if (init_type == 0)
                    {
                        cluster_list_i = KMeans.fit(parent_pts, num_gaussian);
                    }
                    cluster_list = cluster_list.Concat(cluster_list_i).ToList();

                }
            }
            else
            {
                if (init_type == 1)
                {
                    cluster_list = FuzzyCMeans.fit(pts, num_gaussian);
                }
                else if (init_type == 0)
                {
                    cluster_list = KMeans.fit(pts, num_gaussian);
                }

            }

            return cluster_list;
        }

        /// <summary>
        /// Initialize and add new gaussians at the beginning of each level
        /// </summary>
        /// <param name="level">
        /// Level index
        /// </param>
        private void InitLevel(int level, int init_type)
        {
            Console.WriteLine("level {0} begin ", level);

            List<Gaussian_2D> level_gaussian_list = new List<Gaussian_2D>();

            //TODO: initialize gaussians at smaller scale for deeper levels, only within the parent domain
            //gau.Sigma.m00 /= level + 1;
            //gau.Sigma.m11 /= level + 1;
            if (init_type == 0 || init_type == 1) // kmeans_init (0) || FCM_init (1) 
            {
                level_gaussian_list = ClusteringInitGMM(level, init_type);
            }
            else if(init_type == 2)
            {
                IEnumerable<int> level_gaussian_idx = GetLevel(level);
                foreach (int i in level_gaussian_idx)
                {
                    //Each gaussian is randomly initialized at four corners
                    Gaussian_2D gaussian_rand = new Gaussian_2D(rand, (i % 8) + 1, true);
                    level_gaussian_list.Add(gaussian_rand);
                }
            }

            foreach (Gaussian_2D gaussian in level_gaussian_list)
            {
                gaussian_list.Add(gaussian);
                //All gaussians at each level are initialized with equal class prior
                class_prior.Add(1 / (double)(num_gaussian));
                //A list of constitute sufficient statistics for updating gaussian parameters in parallel.
                //See paper section 3.5
                T.Add(new List<double>(new double[] { 0, 0, 0, 0, 0, 0, 0 }));
            }

        }

        /// <summary>
        /// Get point[parent]'s corresponding gaussian's children
        /// </summary>
        /// <param name="parent">
        /// Parent gaussian index
        /// </param>
        /// <returns></returns>
        private List<int> GetChild(int parent)
        {
           //See paper section 4
            IEnumerable<int> children = Enumerable.Range((parent + 1) * num_gaussian, num_gaussian);
            List<int> child = children.ToList();
            return child;
        }

        /// <summary>
        /// Get the gaussian indexs of each level
        /// </summary>
        /// <param name="level">
        /// Level index
        /// </param>
        /// <returns></returns>
        public List<int> GetLevel(int level)
        {
            //See paper section 4
            IEnumerable<int> level_gaussians = Enumerable.Range(num_gaussian * ((int)Math.Pow(num_gaussian, level) - 1) / (num_gaussian - 1),
                                                                (int)Math.Pow(num_gaussian, level + 1));
            List<int> level_gaussian = level_gaussians.ToList();
            return level_gaussian;
        }

        /// <summary>
        /// Associate each point with a gaussian at each level. Requires computation of pdfs.
        /// </summary>
        /// <param name="l"></param>
        private void PointRegistration(int l)
        {
            //calculate numerator: P(point=i | gaussian=j) * P(gaussian=j)
            for (int i = 0; i < pts.Count; ++i)
            {
                List<double> pdfs = new List<double>();
                List<int> children = GetChild(parent_idx[i]);

                if (l != 0 && !gaussian_list[parent_idx[i]].partition)
                {
                    pts[i].gaussian_idx.Add(-1);
                    pdfs.Add(0);
                    continue;
                }

                foreach (int j in children)
                {
                    pdfs.Add(class_prior[j] * MultiNormalPDF(pts[i], gaussian_list[j]));
                }

                pts[i].gaussian_idx.Add(children[pdfs.IndexOf(pdfs.Max())]);
            }

        }

        /// <summary>
        /// Calculate multivariate normal probablity density function. 
        /// Hardcoded for Vector2 and Matrix22 datatype.
        /// Use double precision to increase robustness.
        /// </summary>
        /// <param name="pt"></param>
        /// <param name="miu"></param>
        /// <param name="covariance"></param>
        /// <returns></returns>
        private static double MultiNormalPDF(Vector2 pt, Gaussian_2D gaussian)
        {
            Vector2 miu = gaussian.miu;
            Matrix22 covariance = gaussian.Sigma;

            Vector2 x_minus_miu = pt.Minus(miu);
            Matrix22 inv_cov = covariance.Inverse();

            //Break Matrix22 into two rows (Vector2) for dot product 
            Vector2 row1 = new Vector2(inv_cov.m00, inv_cov.m01);
            Vector2 row2 = new Vector2(inv_cov.m10, inv_cov.m11);

            float dot_row1 = row1.Dot(x_minus_miu);
            float dot_row2 = row2.Dot(x_minus_miu);

            //Assemble two rows
            Vector2 temp_v = new Vector2(dot_row1, dot_row2);

            double numerator = Math.Exp(-x_minus_miu.Dot(temp_v) / 2);
            double denom = 2 * Math.PI * Math.Sqrt(covariance.Det());

            return numerator / denom;
        }

        /// <summary>
        /// Hierarchical EM: E step
        /// </summary>
        /// <param name="level">
        /// Level index
        /// </param>
        /// <returns></returns>
        private double EStep(int l)
        {

            //loglikelihood: EM stopping condition
            List<double> logs = new List<double>();

            for (int i = 0; i < pts.Count; ++i)
            {
                //pdfs: probability density function of point i. 
                List<double> pdfs = new List<double>();
                List<int> children = GetChild(parent_idx[i]);

                if (l != 0 && !gaussian_list[parent_idx[i]].partition)
                {
                    pdfs.Add(0);
                    continue;
                }

                //numerator: P(point=i | gaussian=j) * P(gaussian=j)
                foreach (int j in children)
                {
                    pdfs.Add(class_prior[j] * MultiNormalPDF(pts[i], gaussian_list[j]));
                }

                //denominator: sum(pdfs, axis = 1)
                double sum = pdfs.Sum();
                
                //accumulate T in parallel. See paper equation 5-7
                foreach (int j in children)
                {
                    pdfs[j - children[0]] /= sum;
                    T[j][0] += pdfs[j - children[0]];
                    T[j][1] += pdfs[j - children[0]] * pts[i].x;
                    T[j][2] += pdfs[j - children[0]] * pts[i].y;
                    T[j][3] += pdfs[j - children[0]] * Math.Pow(pts[i].x, 2);
                    T[j][4] = T[j][5] += pdfs[j - children[0]] * pts[i].x * pts[i].y;
                    T[j][6] += pdfs[j - children[0]] * Math.Pow(pts[i].y, 2);
                }

                //loglikelihood
                logs.Add(Math.Log(sum));
                //update the gaussian index that point i belong to at current level
                current_idx[i] = children[pdfs.IndexOf(pdfs.Max())];
            }
            return logs.Average();
        }

        /// <summary>
        /// Hierarchical EM: M step
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        private void MStep(int l)
        {
            List<int> level_gaussians = GetLevel(l);
            //Tikhonov regularization parameter
            float lambda = .01F;

            foreach (int j in level_gaussians)
            {
                if (!gaussian_list[j].partition)
                {
                    continue;
                }

                //count points in gaussian j
                int point_count = 0;
                foreach (int idx in current_idx)
                {
                    if (idx == j) point_count++;
                }

                //In progress
                if (point_count == 0)
                {
                    point_count += 1;
                    //gaussian_list[j].partition = false;
                    //gaussian_list[j].dropped = true;
                    continue;
                }

                //class prior
                class_prior[j] = T[j][0] / point_count;

                //mean
                T[j][1] /= T[j][0];
                T[j][2] /= T[j][0];
                gaussian_list[j].miu.x = (float)T[j][1];
                gaussian_list[j].miu.y = (float)T[j][2];

                //covariance
                gaussian_list[j].Sigma.m00 = (float)(T[j][3] / T[j][0] - Math.Pow(T[j][1], 2));
                gaussian_list[j].Sigma.m10 = gaussian_list[j].Sigma.m01 = (float)(T[j][4] / T[j][0] - T[j][1]* T[j][2]);
                gaussian_list[j].Sigma.m11 = (float)(T[j][6] / T[j][0] - Math.Pow(T[j][2], 2));

                //Tikhonov regularization
                gaussian_list[j].Sigma.m00 += lambda;
                gaussian_list[j].Sigma.m11 += lambda;

                //clear T list
                for ( int i = 0; i < 7; i++)
                {
                    T[j][i] = 0;
                }
            }
        }

        /// <summary>
        /// Input: number of the predicted gaussians
        /// Output: gaussian_list
        /// </summary>
        /// <param name="num_gaussians"></param>
        /// <returns></returns>
        public (List<Gaussian_2D>, List<Vector2>) FitGaussians(int num_gaussian, int num_levels, int init_type)
        {
            this.num_levels = num_levels;
            this.num_gaussian = num_gaussian;
            double log_diff = 0;
            double loglikelihook_new = 0;
            double loglikelihook_old = 0;

            Init();

            Console.WriteLine("Calculating...");
            if (pts != null)
            {
                for (int l = 0; l < num_levels; l++)
                {
                    InitLevel(l, init_type);
                    //EM algo
                    do
                    {
                        if (iter % 10 == 0)
                        {
                            Console.WriteLine("iter {0}  ", iter);
                        }

                        //E-Step
                        loglikelihook_new = EStep(l);
                        //Log difference
                        log_diff = Math.Abs(loglikelihook_old - loglikelihook_new);
                        if (log_diff <= log_diff_thresh)
                            break;
                        //M-Step
                        MStep(l);

                        loglikelihook_old = loglikelihook_new;
                        iter++;
                    } while (iter <= max_iter);

                    PointRegistration(l);

                    iter = 0;//restart EM loop
                    //max_iter *= 5;//increase max interation for next level

                    //log_diff_thresh *= 100;//increase loglikelihood hold for next level

                    //Update parent list with current list => next level
                    for ( int i = 0; i < pts.Count; i++)
                    {
                        parent_idx[i] = current_idx[i];
                    }

                    //TODO: drop tiny gaussians

                    Console.WriteLine("level {0} done ", l);

                    if (l == num_levels - 1)
                    {
                        DetectLastLevel(l + 1);
                    }
                }
            }


            Console.WriteLine("Done!");

            return (gaussian_list, pts);
        }
        public (List<Gaussian_2D>, List<Vector2>) FitGaussiansManual(int num_gaussian, int level, int init_type)
        {
            iter = 0;
            this.num_gaussian = num_gaussian;
            double log_diff;
            double loglikelihook_new;
            double loglikelihook_old = 0;

            if (pts == null)
            {
                return (null, null);
            }

            //EM algo
            InitLevel(level, init_type);
            do
            {
                if (iter % 10 == 0)
                {
                    Console.WriteLine("iter {0}  ", iter);
                }

                //E-Step
                loglikelihook_new = EStep(level);
                //Log difference
                log_diff = Math.Abs(loglikelihook_old - loglikelihook_new);
                if (log_diff <= log_diff_thresh)
                    break;
                //M-Step
                MStep(level);

                loglikelihook_old = loglikelihook_new;
                iter++;
            } while (iter <= max_iter);

            PointRegistration(level);

            //max_iter *= 5;//increase max interation for next level
            //log_diff_thresh *= 100;//increase loglikelihood hold for next level

            //Update parent list with current list => next level
            for (int i = 0; i < pts.Count; i++)
            {
                parent_idx[i] = current_idx[i];
            }

            //TODO: drop tiny gaussians

            Console.WriteLine("level {0} done ", level);

            return (gaussian_list, pts);
        }

        public void AddPoints(List<Vector2> points)
        {
            pts.AddRange(points);
        }

        public void ClearPoints()
        {
            pts.Clear();
            baseModels.Clear();
        }
    }
}
