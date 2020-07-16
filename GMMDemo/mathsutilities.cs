using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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

        public Vector2(float x_init, float y_init)
        {
            x = x_init;
            y = y_init;
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

        public bool dropped = false;
        public Gaussian_2D()
        {
            //init with zeros
            miu = new Vector2(0, 0);
            Sigma = new Matrix22(0, 0, 0, 0);
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
                miu = new Vector2(rand.Next(100, 900), rand.Next(50, 400));
                Sigma = new Matrix22(rand.Next(100, 900), rand.Next(-100, 100),
                                rand.Next(-100, 100), rand.Next(100, 900));
            }
            //init new gaussians at one of the four corners
            else
            {
                switch (corner)
                {
                    case 1:
                        miu = new Vector2(10, 10);
                        break;

                    case 2:
                        miu = new Vector2(1000, 500);
                        break;

                    case 3:
                        miu = new Vector2(10, 500);
                        break;

                    case 4:
                        miu = new Vector2(1000, 10);
                        break;

                }
                //init covariance
                Sigma = new Matrix22(rand.Next(1000, 2000), rand.Next(-100, 100),
                                rand.Next(-100, 100), rand.Next(1000, 2000));
            }
        }
    }

    /// <summary>
    /// Hardcoded matrix computations for multivariate normal PDF.
    /// Input: Vector2 and Matrix22
    /// </summary>
    public class MatrixMath
    {
        public static float Det(Matrix22 m)
        {
            return m.m00 * m.m11 - m.m10 * m.m01;
        }

        public static Vector2 Minus(Vector2 v1, Vector2 v2)
        {
            Vector2 min = new Vector2(v1.x - v2.x, v1.y - v2.y);
            return min;
        }

        public static Matrix22 Inverse(Matrix22 m)
        {
            Matrix22 inv_M = new Matrix22();

            inv_M.m00 = m.m11 / Det(m);
            inv_M.m01 = -m.m01 / Det(m);
            inv_M.m10 = -m.m10 / Det(m);
            inv_M.m11 = m.m00 / Det(m);

            return inv_M;
        }

        public static float Dot(Vector2 v1, Vector2 v2)
        {
            return v1.x * v2.x + v1.y * v2.y;
        }

        public static List<int> LogLikeliHood()
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
        public static double MultivariateNormalPDF(Vector2 pt, Vector2 miu, Matrix22 covariance)
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

    public class ColorList
    {
        private int currentColorIndex;
        public List<Color> colors = new List<Color>();
        public ColorList()
        {
            currentColorIndex = colors.Count - 1;
            colors.Add(Color.Blue);
            colors.Add(Color.Green);
            colors.Add(Color.Red);
            colors.Add(Color.Orange);
            colors.Add(Color.Yellow);

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
