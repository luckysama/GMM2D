using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GMMDemo
{
   public class Vector2
    {
        public float x, y;
        public List<int> gaussian_idx = new List<int>();// Associate each point with a gaussian at each level
        public Vector2()
        {
            x = y = 0;
        }

        public Vector2(PointF ptf_pt)
        {
            x = ptf_pt.X;
            y = ptf_pt.Y;
        }

        public Vector2(float x_init, float y_init)
        {
            x = x_init;
            y = y_init;
        }

        public Vector2(Vector2 rhs)
        {
            x = rhs.x;
            y = rhs.y;
        }

        public float distancesquare(Vector2 rhs)
        {
            float dist = 0;
            dist += (rhs.x - this.x) * (rhs.x - this.x);
            dist += (rhs.y - this.y) * (rhs.y - this.y);
            return dist;
        }

        public float Cross2d(Vector2 rhs)
        {
            return this.x * rhs.y - this.y * rhs.x;
        }

        public Vector2 Minus(Vector2 rhs)
        {
            return new Vector2(this.x - rhs.x, this.y - rhs.y);
        }

        public Vector2 Add(Vector2 rhs)
        {
            return new Vector2(this.x + rhs.x, this.y + rhs.y);
        }
    }

    public class Matrix22
    {
        public float m00, m01, m10, m11;
        public Matrix22()
        {
            m00 = m01 = m10 = m11 = 0;
        }

        public Matrix22(float m00_init, float m01_init, float m10_init, float m11_init)
        {
            //matrix with init value
            m00 = m00_init;
            m10 = m01 = m01_init;
            m11 = m11_init;
        }

        public void UpdateEigens()
        {
            degenerate = false;
            trace = m00 + m11;
            det = m00 * m11 - m10 * m01;
            float r = trace * trace * 0.25f - det;
            if (r > 0)
            {
                eigenvalue_0 = trace * 0.5f + (float)Math.Sqrt(r);
                eigenvalue_1 = trace * 0.5f - (float)Math.Sqrt(r);
            }
            else
            {
                eigenvalue_0 = 0;
                eigenvalue_1 = 0;
                degenerate = true;
            }

            if (m10 != 0)
            {
                eigenvector_0 = new Vector2(eigenvalue_0 - m11, m10);
                eigenvector_1 = new Vector2(eigenvalue_1 - m11, m10);
            } else if (m01 != 0)
            {
                eigenvector_0 = new Vector2(m01, eigenvalue_0 - m00);
                eigenvector_1 = new Vector2(m01, eigenvalue_1 - m00);
            } else
            {
                eigenvector_0 = new Vector2(1, 0);
                eigenvector_1 = new Vector2(0, 1);
            }
        }

        public float trace;
        public float det;
        public float eigenvalue_0;
        public float eigenvalue_1;
        public Vector2 eigenvector_0;
        public Vector2 eigenvector_1;
        public bool degenerate;
    }

    public class Gaussian_2D
    {
        public Vector2 miu; //mean
        public Matrix22 Sigma; //variance
        public bool selected = false; //Flag if this gaussian is selected by the user
        public bool partition = true;
        public bool dropped = false;

        public Gaussian_2D()
        {
            //init with zeros
            miu = new Vector2(0, 0);
            Sigma = new Matrix22(0, 0, 0, 0);
        }

        public Gaussian_2D(Random rand, Vector2 miu_init)
        {
            //init with zeros
            miu = miu_init;
            Sigma = new Matrix22(800, rand.Next(-10, 10),
                                rand.Next(-10, 10), 800); ;
        }

        /// <summary>
        /// Generate a random gaussian.
        /// </summary>
        /// <param name="rand">
        /// Random operator
        /// </param> 
        /// <param name="corner">
        /// Which corner to initialize
        /// </param> 
        /// <param name="init">
        /// If true, initialize gaussians for prediction;
        /// If false, for input data
        /// </param>
        public Gaussian_2D(Random rand, int corner = 0, bool init=false)
        {
            //init input datapoints with random value
            if (!init && corner == 0)
            {
                miu = new Vector2(rand.Next(100, 1700), rand.Next(50, 900));
                Sigma = new Matrix22(rand.Next(100, 900), rand.Next(-100, 100),
                                rand.Next(-100, 100), rand.Next(100, 900));
            }
            //init new gaussians at one of the four corners
            else
            {
                switch (corner)
                {
                    case 1:
                        miu = new Vector2(200, 200);
                        break;

                    case 2:
                        miu = new Vector2(1700, 900);
                        break;

                    case 3:
                        miu = new Vector2(200, 900);
                        break;

                    case 4:
                        miu = new Vector2(1700, 200);
                        break;
                    case 5:
                        miu = new Vector2(850, 200);
                        break;

                    case 6:
                        miu = new Vector2(850, 900);
                        break;

                    case 7:
                        miu = new Vector2(200, 1100);
                        break;

                    case 8:
                        miu = new Vector2(1700, 1100);
                        break;

                }
                //init covariance
                Sigma = new Matrix22(2000, rand.Next(-10, 10),
                                rand.Next(-10, 10), 2000);
            }
        }
    }

    /// <summary>
    /// Hardcoded matrix computations for multivariate normal PDF.
    /// Input: Vector2 and Matrix22
    /// </summary>
    public class MatrixMath
    {
        public float Det(Matrix22 m)
        {
            return m.m00 * m.m11 - m.m10 * m.m01;
        }

        public Vector2 Minus(Vector2 v1, Vector2 v2)
        {
            Vector2 min = new Vector2(v1.x - v2.x, v1.y - v2.y);
            return min;
        }

        public Matrix22 Inverse(Matrix22 m)
        {
            Matrix22 inv_M = new Matrix22();

            inv_M.m00 = m.m11 / Det(m);
            inv_M.m01 = -m.m01 / Det(m);
            inv_M.m10 = -m.m10 / Det(m);
            inv_M.m11 = m.m00 / Det(m);

            return inv_M;
        }

        public float Dot(Vector2 v1, Vector2 v2)
        {
            return v1.x * v2.x + v1.y * v2.y;
        }

        public List<int> LogLikeliHood()
        {
            return null;
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
        public double MultivariateNormalPDF(Vector2 pt, Vector2 miu, Matrix22 covariance)
        {
            Vector2 x_minus_miu = Minus(pt, miu);
            Matrix22 inv_cov = Inverse(covariance);

            //Break Matrix22 into two rows (Vector2) for dot product 
            Vector2 row1 = new Vector2(inv_cov.m00, inv_cov.m01);
            Vector2 row2 = new Vector2(inv_cov.m10, inv_cov.m11);

            float dot_row1 = Dot(row1, x_minus_miu);
            float dot_row2 = Dot(row2, x_minus_miu);

            //Assemble two rows
            Vector2 temp_v = new Vector2(dot_row1, dot_row2);

            double numerator = Math.Exp(-Dot(x_minus_miu, temp_v) / 2);
            double denom = 2 * Math.PI * Math.Sqrt(Det(covariance));

            return numerator / denom;
        }
    }

    /// <summary>
    /// Hardcoded matrix computations for multivariate normal PDF.
    /// Input: Vector2 and Matrix22
    /// </summary>
    public class KMeans
    {
        public List<Vector2> pts;
        public int num_clusters;
        public List<Vector2> init_centroid = new List<Vector2>();
        Random rand = new Random();

        public List<Vector2> RandomPoint(int num_clusters)
        {
            return pts.OrderBy(arg => Guid.NewGuid()).Take(num_clusters).ToList();
        }

        public List<int> ClosestCentroid(List<Vector2> init_means)
        {
            List<int> closest_centroid = new List<int>();
            foreach (Vector2 pt in pts)
            {
                List<double> dist_list = new List<double>();
                foreach (Vector2 centroid in init_means)
                {
                    dist_list.Add(Math.Pow(pt.x - centroid.x, 2) + Math.Pow(pt.y - centroid.y, 2));
                }
                closest_centroid.Add(dist_list.IndexOf(dist_list.Min()));
            }
            return closest_centroid;
        }

        public List<Vector2> ShiftCentroid(List<int> closest_centroid)
        {
            List<Vector2> centroid = new List<Vector2>(num_clusters);
            List<int> point_per_cluster = new List<int>(num_clusters);
            for ( int i = 0; i < num_clusters; i++)
            {
                centroid.Add(new Vector2());
                point_per_cluster.Add(0);
            }

            for (int i = 0; i < pts.Count(); i++)
            {
                centroid[closest_centroid[i]].x += pts[i].x;
                centroid[closest_centroid[i]].y += pts[i].y;
                point_per_cluster[closest_centroid[i]] += 1;
            }

            for (int i = 0; i < num_clusters; i++)
            {
                if (point_per_cluster[i] == 0)
                {
                    Console.WriteLine("point_per_cluster cannot be 0, continued");
                    continue;
                    //throw new System.ArgumentException("point_per_cluster cannot be 0", "original");
                }
                centroid[i].x /= point_per_cluster[i];
                centroid[i].y /= point_per_cluster[i];
            }

            return centroid;
        }

        public bool CloseCentroid(List<Vector2> old_centroid, List<Vector2> centroid)
        {
            double centroid_diff_thresh = 0.01;
            double centroid_diff = 0;

            for (int i = 0; i < num_clusters; i++)
            {
                centroid_diff += Math.Pow(old_centroid[i].x - centroid[i].x, 2) + Math.Pow(old_centroid[i].y - centroid[i].y, 2);
            }

            //Console.WriteLine(centroid_diff);

            if (centroid_diff < centroid_diff_thresh)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Gaussian_2D> KM(List<Vector2> pts_init, int num_clusters_init)
        {
            pts = pts_init;
            num_clusters = num_clusters_init;
            int num_points = pts.Count();
            List<Gaussian_2D> gau_list = new List<Gaussian_2D>();

            int iter_counter = 0;
            init_centroid = RandomPoint(num_clusters);
            List<int> closest_centroid = new List<int>();
            List<Vector2> centroid = init_centroid;
            List<Vector2> old_centroid = init_centroid;
            do
            {
                old_centroid = centroid;
                closest_centroid = ClosestCentroid(old_centroid);
                centroid = ShiftCentroid(closest_centroid);
                iter_counter++;
            } while (!CloseCentroid(old_centroid, centroid) && iter_counter <= 50);

            foreach(Vector2 miu in centroid)
            {
                Gaussian_2D gau = new Gaussian_2D(rand, miu);
                gau_list.Add(gau);
            }
            return gau_list;
        }

    }
    public class FuzzyCMeans
    {
        public List<Vector2> pts;
        public int num_clusters;
        public Random rand = new Random();
        public int fuz_coef = 2;

        public List<List<double>> InitializeMemberships()
        {
            List<List<double>> membership = new List<List<double>>(pts.Count);
            for (int i = 0; i < pts.Count - 1; i++)
            {
                List<double> membership_i = new List<double>(num_clusters);
                for (int j = 0; j < num_clusters; j++)
                {
                    membership_i.Add(rand.NextDouble());
                }

                double sum = membership_i.Sum();

                for (int j = 0; j < num_clusters; j++)
                {
                    membership_i[j] /= sum;
                }
                membership.Add(membership_i);
            }
            return membership;
        }

        public List<Vector2> UpdateCenter(List<List<double>> membership)
        {
            List<Vector2> centers = new List<Vector2>(num_clusters);

            for (int j = 0; j < num_clusters; j++)
            {
                double sum = 0;
                Vector2 center = new Vector2();
                for (int i = 0; i < pts.Count - 1; i++)
                {
                    sum += membership[i][j];
                }

                for (int i = 0; i < pts.Count - 1; i++)
                {
                    membership[i][j] /= sum;
                    center.x += (float)membership[i][j] * pts[i].x;
                    center.y += (float)membership[i][j] * pts[i].y;
                }
                centers.Add(center);
            }
            return centers;
        }

        public List<List<double>> GetDistance(List<Vector2> centers)
        {
            List<List<double>> dist_list = new List<List<double>>();
            foreach (Vector2 pt in pts)
            {
                List<double> dist_list_i = new List<double>();
                foreach (Vector2 centroid in centers)
                {
                    dist_list_i.Add(Math.Pow(pt.x - centroid.x, 2) + Math.Pow(pt.y - centroid.y, 2));
                }
                dist_list.Add(dist_list_i);
            }
            return dist_list;
        }

        public List<List<double>> UpdateMemberships(List<Vector2> centers)
        {
            List<List<double>> membership = new List<List<double>>(pts.Count);
            List<List<double>> dist = GetDistance(centers);

            for (int i = 0; i < pts.Count - 1; i++)
            {
                List<double> membership_i = new List<double>(num_clusters);
                for (int j = 0; j < num_clusters; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < num_clusters; k++)
                    {
                        sum += Math.Pow(dist[i][j] / (dist[i][k]), 2 / (fuz_coef - 1));
                    }

                    if (double.IsNaN(sum) || sum == 0.0)
                    {
                        Console.WriteLine("===========Bad Sum=========");
                    }

                    membership_i.Add(1 / sum);
                }
                membership.Add(membership_i);
            }
            return membership;
        }

        public bool CloseCentroid(List<Vector2> old_centroid, List<Vector2> centroid)
        {
            double centroid_diff_thresh = 0.01;
            double centroid_diff = 0;

            for (int i = 0; i < num_clusters; i++)
            {
                centroid_diff += Math.Pow(old_centroid[i].x - centroid[i].x, 2) + Math.Pow(old_centroid[i].y - centroid[i].y, 2);
            }

            //Console.WriteLine(centroid_diff);

            if (centroid_diff < centroid_diff_thresh)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Gaussian_2D> FCM(List<Vector2> pts_init, int num_clusters_init)
        {
            pts = pts_init;
            num_clusters = num_clusters_init;
            int num_points = pts.Count();
            int iter_counter = 0;

            List<Gaussian_2D> gau_list = new List<Gaussian_2D>();
            List<List<double>> membership = InitializeMemberships();
            //List<List<double>> old_membership = new List<List<double>>();
            List<Vector2> centers = UpdateCenter(membership);
            List<Vector2> old_centres = new List<Vector2>();

            do
            {
                iter_counter++;
                //old_membership = membership;
                old_centres = centers;
                membership = UpdateMemberships(centers);
                centers = UpdateCenter(membership);
            } while (!CloseCentroid(old_centres, centers) && iter_counter <= 50);


            foreach (Vector2 miu in centers)
            {
                Gaussian_2D gau = new Gaussian_2D(rand, miu);
                gau_list.Add(gau);
            }

            return gau_list;
        }
    }
    public class ColorSelector
    {
        private int currentColorIndex;
        public List<Color> colors = new List<Color>();
        public ColorSelector()
        {
            currentColorIndex = colors.Count - 1;
            colors.Add(Color.Blue);
            colors.Add(Color.Green);
            colors.Add(Color.Red);
            colors.Add(Color.Orange);

        }

        public Color NextColor()
        {
            currentColorIndex++;
            if (currentColorIndex >= colors.Count)
            {
                currentColorIndex = 0;
            }
            return colors[currentColorIndex];
        }
    }
}
