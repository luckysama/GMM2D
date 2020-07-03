using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMMDemo
{
   public class Vector2
    {
        public float x, y;
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
        public Gaussian_2D()
        {
            miu = new Vector2();
            Sigma = new Matrix22();
        }
    }
}
