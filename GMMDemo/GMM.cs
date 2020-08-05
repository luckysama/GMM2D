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
        public Random rand = new Random();

        public List<Vector2> pts = null;
        public List<Gaussian_2D> sample_gaussian_list = null;
        public List<Gaussian_2D> gaussian_list = null;//HGMM tree structure. Can be quaried via GetChild(parent_idx)
        public int num_gaussian = 0;
        public List<double> class_prior = null;
        public List<List<double>> T = null;
        public List<int> current_idx = null;
        public List<int> parent_idx = null;
        public int num_levels = 1;

        /// <summary>
        /// Initialize point - gaussian list of parent and child level
        /// </summary>
        public void InitTree()
        {
            current_idx = new List<int>();
            parent_idx = new List<int>();
            for (int i = 0; i < pts.Count; i++)
            {
                current_idx.Add(-1);
                parent_idx.Add(-1);
            }
        }

        /// <summary>
        /// Initialize and add new gaussians at the beginning of each level
        /// </summary>
        /// <param name="level">
        /// Level index
        /// </param>
        public void InitLevel(int level, bool kmeans_init)
        {
            InitGMM init_GMM = new InitGMM();
            IEnumerable<int> current_level_gaussians = GetLevel(level);

            //TODO: initialize gaussians at smaller scale for deeper levels, only within the parent domain
            //gau.Sigma.m00 /= level + 1;
            //gau.Sigma.m11 /= level + 1;
            if (kmeans_init)
            {
                List<Vector2> mius = new List<Vector2>();
                if (level != 0)
                {
                    IEnumerable<int> parent_level_gaussians = GetLevel(level - 1);
                    foreach (int i in parent_level_gaussians)
                    {
                        List<Vector2> parent_pts = new List<Vector2>();
                        foreach (Vector2 pt in pts)
                        {
                            if (pt.gaussian_idx[level - 1] == i)
                            {
                                parent_pts.Add(pt);
                            }
                        }
                        List<Vector2> mius_i = init_GMM.KMeans(parent_pts, num_gaussian);
                        mius = mius.Concat(mius_i).ToList();
                    }
                }
                else
                {
                    mius = init_GMM.KMeans(pts, num_gaussian);
                }

                foreach ( Vector2 miu in mius)
                {
                    Gaussian_2D gau = new Gaussian_2D(rand, miu);
                    gaussian_list.Add(gau);
                    //All gaussians at each level are initialized with equal class prior
                    class_prior.Add(1 / (double)(num_gaussian));
                    //A list of constitute sufficient statistics for updating gaussian parameters in parallel.
                    //See paper section 3.5
                    T.Add(new List<double>(new double[] { 0, 0, 0, 0, 0, 0, 0 }));
                }
            }
            else
            {
                foreach (int i in current_level_gaussians)
                {
                    //Each gaussian is randomly initialized at four corners
                    Gaussian_2D gau = new Gaussian_2D(rand, (i % 8) + 1, true);

                    gaussian_list.Add(gau);
                    //All gaussians at each level are initialized with equal class prior
                    class_prior.Add(1 / (double)(num_gaussian));
                    //A list of constitute sufficient statistics for updating gaussian parameters in parallen.
                    //See paper section 3.5
                    T.Add(new List<double>(new double[] { 0, 0, 0, 0, 0, 0, 0 }));
                }
            }
        }

        public List<Vector2> GenerateRandomPoints(int num_of_points, int xmax, int ymax) //x and y range from 0
        {
            if (pts == null)
            {
                pts = new List<Vector2>();
            }

            for (int i = 0; i < num_of_points; ++i)
            {
                pts.Add(new Vector2(rand.Next(0, xmax), rand.Next(0, ymax)));
            }

            return pts;
        }

        public List<Vector2> GenerateLidarPoints(int xmax, int ymax, out List<Polygon> drawing_polygons, out Vector2 scan_position)
        {
            simplelidar lidar = new simplelidar();
            List<Polygon> shapes = new List<Polygon>();
            //Shape 0 - the room...
            Polygon outer_bound = new Polygon();
            outer_bound.vertices.Add(new PointF(5, 5));
            outer_bound.vertices.Add(new PointF(xmax - 5, 5));
            outer_bound.vertices.Add(new PointF(xmax - 5, ymax - 5));
            outer_bound.vertices.Add(new PointF(5, ymax - 5));
            shapes.Add(outer_bound);
            //TODO: We need a better way to create shapes.....
            Polygon square = new Polygon();
            square.vertices.Add(new PointF(100, 100));
            square.vertices.Add(new PointF(200, 100));
            square.vertices.Add(new PointF(200, 200));
            square.vertices.Add(new PointF(100, 200));
            shapes.Add(square);

            Rectangle star_bound = new Rectangle(300, 300, 200, 200);
            int star_vertex_count = 6;
            PointF[] star_vertices = StarPoints(star_vertex_count, star_bound);
            Polygon star = new Polygon();
            star.AddPointFArray(star_vertices);
            shapes.Add(star);

            Polygon triangle = new Polygon();
            triangle.vertices.Add(new PointF(500, 100));
            triangle.vertices.Add(new PointF(650, 100));
            triangle.vertices.Add(new PointF(550, 200));
            shapes.Add(triangle);
            scan_position = new Vector2(xmax / 2, ymax / 2);
            lidar.polygons_list = shapes;
            pts = lidar.ScanFrom(scan_position);

            //draw everything but not the room, e.g. the outer_bound
            drawing_polygons = new List<Polygon>();            
            drawing_polygons.Add(square);
            drawing_polygons.Add(star);
            drawing_polygons.Add(triangle);
            return pts;
        }

        private PointF[] StarPoints(int num_points, Rectangle bounds)
        {
            // Make room for the points.
            PointF[] pts = new PointF[num_points];

            double rx = bounds.Width / 2;
            double ry = bounds.Height / 2;
            double cx = bounds.X + rx;
            double cy = bounds.Y + ry;

            // Start at the top.
            double theta = -Math.PI / 2;
            double dtheta = 2 * Math.PI / num_points;
            for (int i = 0; i < num_points; i++)
            {
                pts[i] = new PointF(
                    (float)(cx + rx * Math.Cos(theta)),
                    (float)(cy + ry * Math.Sin(theta)));
                theta += dtheta;
            }

            return pts;
        }

        public List<Vector2> GenerateGaussianPoints(int num_of_points, int num_gaussians)
        {
            if (pts == null)
            {
                pts = new List<Vector2>();
            }
            if (sample_gaussian_list == null)
            {
                sample_gaussian_list = new List<Gaussian_2D>();
            }

            int ptsPerGaussian = (int)Math.Round((double)num_of_points / num_gaussians);

            for (int loop = 0; loop < num_gaussians; loop++)
            {
                Gaussian_2D sample_gaussian = new Gaussian_2D(rand);
                sample_gaussian_list.Add(sample_gaussian);

                sample_gaussian.Sigma.UpdateEigens();
                double angle;
                if (sample_gaussian.Sigma.m00 > sample_gaussian.Sigma.m11)
                {
                    angle = Math.Atan2(sample_gaussian.Sigma.eigenvector_0.y, sample_gaussian.Sigma.eigenvector_0.x);
                }
                else
                {
                    angle = Math.Atan2(sample_gaussian.Sigma.eigenvector_1.y, sample_gaussian.Sigma.eigenvector_1.x);
                }

                double u1, u2;
                int x_old, y_old;
                int x, y;

                for (int i = 0; i < ptsPerGaussian; i++)
                {
                    do
                    {
                        u1 = rand.NextDouble();
                        u2 = rand.NextDouble();
                    } while (u1 == 0 && u2 == 0);
                    x_old = (int)Math.Round(Math.Sqrt(sample_gaussian.Sigma.m00) * Math.Sqrt(-2 * Math.Log(u2)) * Math.Cos(2 * Math.PI * u1));
                    y_old = (int)Math.Round(Math.Sqrt(sample_gaussian.Sigma.m11) * Math.Sqrt(-2 * Math.Log(u2)) * Math.Sin(2 * Math.PI * u1));
                    x = (int)Math.Round(x_old * Math.Cos(angle) - y_old * Math.Sin(angle) + sample_gaussian.miu.x);
                    y = (int)Math.Round(x_old * Math.Sin(angle) + y_old * Math.Cos(angle) + sample_gaussian.miu.y);
                    pts.Add(new Vector2(x, y));
                }
            }

            return pts;
        }

        /// <summary>
        /// Get point[parent]'s corresponding gaussian's children
        /// </summary>
        /// <param name="parent">
        /// Parent gaussian index
        /// </param>
        /// <returns></returns>


        public List<Vector2> get2DScan(int num_of_points, List<String> lines, float canvasWidth, float CanvasHeight)
        {
            List<Vector2> scanned_pts = new List<Vector2>();
            pts = new List<Vector2>();
            // Highest values in list of x y coordinates of imported text file
            float xMax = 0;
            float yMax = 0;
            foreach (string line in lines)
            {
                if (line == "")
                {
                    continue;
                }
                string[] coordinates = line.Split(' ');
                float x = float.Parse(coordinates[0]);
                if (x > xMax)
                {
                    xMax = x;
                }

                float y = float.Parse(coordinates[1]);
                if (y > yMax)
                {
                    yMax = y;
                }
                scanned_pts.Add(new Vector2(x, y));
            }

            float xScale = canvasWidth / xMax;
            float yScale = CanvasHeight / yMax;
            foreach (Vector2 point in scanned_pts)
            {

                point.x = (int)Math.Round(point.x * xScale);
                point.y = (int)Math.Round(point.y * yScale);

            }

            for (int raw=0; raw < scanned_pts.Count; raw++)
            {
                bool duplicate = false;
                for(int compare=0; compare<raw; compare++)
                {
                    if((scanned_pts[raw].x == scanned_pts[compare].x) && (scanned_pts[raw].y == scanned_pts[compare].y))
                    {
                        duplicate = true;
                        break;
                    }
                }
                if (!duplicate)
                {
                    pts.Add(new Vector2(scanned_pts[raw].x, scanned_pts[raw].y));
                }
            }
            
            if (pts.Count > num_of_points)
            {
                Random deletePoint = new Random();
                int index = 0;
                int overflow = pts.Count - num_of_points;
                for (int loop = 0; loop < overflow; loop++)
                {
                    index = deletePoint.Next(pts.Count);
                    pts.RemoveAt(index);
                }
            }
            return pts;
        }

        public List<int> GetChild(int parent)
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
        public void PointRegistration(int l)
        {
            List<List<double>> pdfs = new List<List<double>>();

            //calculate numerator: P(point=i | gaussian=j) * P(gaussian=j)
            for (int i = 0; i < pts.Count; ++i)
            {
                List<double> pdf = new List<double>();
                List<int> children = GetChild(parent_idx[i]);

                foreach (int j in children)
                {
                    pdf.Add(class_prior[j] * MatrixMath.MultivariateNormalPDF(pts[i],
                                                                            gaussian_list[j].miu,
                                                                            gaussian_list[j].Sigma));
                }
                pdfs.Add(pdf);

                //calculate denominator: sum(pdfs, axis = 1)
                double sum = pdfs[i].Sum();

                for (int e = 0; e < pdf.Count; e++)
                {
                    pdfs[i][e] /= sum;
                }

                pts[i].gaussian_idx.Add(children[pdfs[i].IndexOf(pdfs[i].Max())]);
            }

        }

        /// <summary>
        /// Drop gaussians with insufficient support
        /// </summary>
        /// <param name="class_prior_thresh">
        /// Threshold for minimal class prior
        /// </param>
        public void ClusterDrop(double class_prior_thresh)
        {
            for (int i = class_prior.Count - 1; i >= 0; i--)
            {
                if (class_prior[i] < class_prior_thresh)
                {
                    Console.WriteLine("Dropping gaussian {0} with class_prior {1}", i, class_prior[i]);
                    gaussian_list[i].dropped = true;
                }
            }
        }

        /// <summary>
        /// Hierarchical EM: E step
        /// </summary>
        /// <param name="level">
        /// Level index
        /// </param>
        /// <returns></returns>
        public double HEStep(int l)
        {
            //pdfs: probability density function. 
            //shape (row, column): (num_point, num_gaussian)
            List<List<double>> pdfs = new List<List<double>>();

            //loglikelihood: EM stopping condition
            List<double> logs = new List<double>();

            for (int i = 0; i < pts.Count; ++i)
            {
                List<double> pdf = new List<double>();//init pdfs of point i
                List<int> children = GetChild(parent_idx[i]);

                //numerator: P(point=i | gaussian=j) * P(gaussian=j)
                foreach (int j in children)
                {
                    pdf.Add(class_prior[j] * MatrixMath.MultivariateNormalPDF(pts[i],
                                                                            gaussian_list[j].miu,
                                                                            gaussian_list[j].Sigma));
                }
                pdfs.Add(pdf);

                //denominator: sum(pdfs, axis = 1)
                double sum = pdfs[i].Sum();

                for ( int e = 0; e < pdf.Count; e++)
                {
                    pdfs[i][e] /= sum;
                }

                //calculate T in parallel. See paper equation 5-7
                foreach (int j in children)
                {
                    T[j][0] += pdfs[i][j - children[0]];
                    T[j][1] += pdfs[i][j - children[0]] * pts[i].x;
                    T[j][2] += pdfs[i][j - children[0]] * pts[i].y;
                }

                //loglikelihood
                logs.Add(Math.Log(sum));

                //update the gaussian index that point i belong to at current level
                current_idx[i] = children[pdfs[i].IndexOf(pdfs[i].Max())];
            }

            List<int> level_gaussians = GetLevel(l);
            
            //Mean
            foreach (int j in level_gaussians)
            {
                T[j][1] /= T[j][0];
                T[j][2] /= T[j][0];
            }

            //covariance
            for (int i = 0; i < pts.Count; ++i)
            {
                List<int> children = GetChild(parent_idx[i]);

                foreach (int j in children)
                {
                    T[j][3] += pdfs[i][j - children[0]] * Math.Pow(pts[i].x - T[j][1], 2);
                    T[j][4] = T[j][5] += pdfs[i][j - children[0]] * (pts[i].x - T[j][1]) * (pts[i].y - T[j][2]);
                    T[j][6] += pdfs[i][j - children[0]] * Math.Pow(pts[i].y - T[j][2], 2);
                }
            }

            return logs.Average();
        }

        /// <summary>
        /// Hierarchical EM: M step
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public void HMStep(int l)
        {
            List<int> level_gaussians = GetLevel(l);
            //Tikhonov regularization parameter
            float lambda = 1;

            foreach (int j in level_gaussians)
            {
                int point_count = 0;

                //count points in gaussian j
                for ( int i = 0; i < pts.Count(); i++)
                {
                    List<int> children = GetChild(parent_idx[i]);
                    foreach (int child in children)
                    {
                        if (current_idx[i] == child) point_count++;
                    }
                }

                //Ensure at least one point
                point_count++;
                //class prior
                class_prior[j] = T[j][0] / point_count;
                //mean
                gaussian_list[j].miu.x = (float)T[j][1];
                gaussian_list[j].miu.y = (float)T[j][2];

                //covariance
                gaussian_list[j].Sigma.m00 = (float)(T[j][3] / T[j][0]);
                gaussian_list[j].Sigma.m10 = gaussian_list[j].Sigma.m01 = (float)(T[j][4] / T[j][0]);
                gaussian_list[j].Sigma.m11 = (float)(T[j][6] / T[j][0]);

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
        public (List<Gaussian_2D>, List<Vector2>) FitGaussians(int num_gaussians, int levels, bool kmeans_init)
        {
            num_levels = levels;
            num_gaussian = num_gaussians;
            int iter = 0;
            int max_iter = 80;//maximum iterations
            double log_diff_thresh = 1E-9;//loglikelihood difference threshold
            double class_prior_thresh = 0.01;//class prior threshold
            double log_diff = 0;
            double loglikelihook_new = 0;
            double loglikelihook_old = 0;

            gaussian_list = new List<Gaussian_2D>();
            class_prior = new List<double>();
            T = new List<List<double>>();

            if(pts != null)
            {   
                if(pts[0].gaussian_idx.Count > 0)
                {
                    foreach (Vector2 pt in pts)
                    {
                        pt.gaussian_idx.Clear();
                    }
                }
                
            }

            Console.WriteLine("Calculating...");
            if (pts != null)
            {
                InitTree();

                //EM algo
                for (int l = 0; l < num_levels; l++)
                {
                    InitLevel(l, kmeans_init);
                    do
                    {
                        //E-Step
                        loglikelihook_new = HEStep(l);
                        //Log difference
                        log_diff = Math.Abs(loglikelihook_old - loglikelihook_new);
                        loglikelihook_old = loglikelihook_new;
                        //M-Step
                        HMStep(l);
                        iter++;
                    } while (log_diff >= log_diff_thresh && iter <= max_iter);

                    PointRegistration(l);

                    iter = 0;//restart EM loop
                    max_iter *= 5;//increase max interation for next level
                    log_diff_thresh *= 100;//increase loglikelihood hold for next level

                    //Update parent list with current list => next level
                    for ( int i = 0; i < pts.Count; i++)
                    {
                        parent_idx[i] = current_idx[i];
                    }
                }
                ClusterDrop(class_prior_thresh);
            }
            Console.WriteLine("Done!");
            return (gaussian_list, pts);
        }

        public List<Gaussian_2D> DrawDummyGaussian()
        {
            return sample_gaussian_list;
        }

        public List<Gaussian_2D> FitHierarchyGaussians()
        {
            return null;
        }

    }
}
