using System;
using System.Collections.Generic;
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

        public float Dot(Vector2 rhs)
        {
            return this.x * rhs.x + this.y * rhs.y;
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

        public float Det()
        {
            return m00 * m11 - m10 * m01;
        }

        public Matrix22 Inverse()
        {
            Matrix22 inv_M = new Matrix22();

            inv_M.m00 = m11 / Det();
            inv_M.m01 = -m01 / Det();
            inv_M.m10 = -m10 / Det();
            inv_M.m11 = m00 / Det();

            return inv_M;
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
