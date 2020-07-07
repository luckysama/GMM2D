using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GMMDemo
{

    public class GMM
    {
        public List<Vector2> pts;

        public List<Vector2> GenerateRandomPoints(int num_of_points, int xmax, int ymax) //x and y range from 0
        {
            pts = new List<Vector2>();
            Random rand = new Random();
            for (int i = 0; i < num_of_points; ++i)
            {
                pts.Add(new Vector2(rand.Next(0, xmax), rand.Next(0, ymax)));
            }
            return pts;
        }

        public List<Gaussian_2D> Fit4Gaussians()
        {
            List<Gaussian_2D> gaussian_list = new List<Gaussian_2D>();
            Gaussian_2D dummy_gaussian = new Gaussian_2D();

            dummy_gaussian.miu = new Vector2(100, 100);
            ///used the example matrix in https://en.wikipedia.org/wiki/Multivariate_normal_distribution
            dummy_gaussian.Sigma.m00 = 50;
            dummy_gaussian.Sigma.m01 = 30;
            dummy_gaussian.Sigma.m10 = 30;
            dummy_gaussian.Sigma.m11 = 100;
            gaussian_list.Add(dummy_gaussian);
            //change
            return gaussian_list;
        }

        public List<Gaussian_2D> Fit8Gaussians()
        {
            return null;
        }


        public List<Gaussian_2D> FitHierarchyGaussians()
        {
            return null;
        }

    }
}
