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
        public List<Vector2> pts = null;
        public List<Gaussian_2D> sample_gaussian_list = null;

        public List<Vector2> GenerateRandomPoints(int num_of_points, int xmax, int ymax) //x and y range from 0
        {
            if (pts == null)
            {
                pts = new List<Vector2>();
            }

            Random rand = new Random();
            for (int i = 0; i < num_of_points; ++i)
            {
                pts.Add(new Vector2(rand.Next(0, xmax), rand.Next(0, ymax)));
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

            Random rand = new Random();
            for(int loop = 0; loop < num_gaussians; loop++)
            {
                Gaussian_2D sample_gaussian = new Gaussian_2D(rand);
                sample_gaussian_list.Add(sample_gaussian);

                sample_gaussian.Sigma.UpdateEigens();
                double angle;

                if (sample_gaussian.Sigma.eigenvalue_0 > sample_gaussian.Sigma.eigenvalue_1)
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

        public List<List<double>> EStep(List<Gaussian_2D> gaussian_list, List<double> class_prior)
        {
            int num_gaussians = gaussian_list.Count;

            //pdfs: probability density function. 
            //shape (row, column): (num_gaussian, num_point)
            List<List<double>> pdfs = new List<List<double>>();

            //calculate numerator: P(point=i | gaussian=j) * P(gaussian=j)
            for (int j = 0; j < num_gaussians; ++j)
            {
                List<double> pdf = new List<double>();//init pdfs of gaussian j
                double pdf_elm = new double();
                for (int i = 0; i < pts.Count; ++i)
                {
                    pdf_elm = class_prior[j] * MatrixMath.MultivariateNormalPDF(pts[i],
                                                                            gaussian_list[j].miu,
                                                                            gaussian_list[j].Sigma);

                    //if (pdf_elm == 0) pdf_elm = 1E-323;
                    pdf.Add(pdf_elm);
                }
                pdfs.Add(pdf);
            }

            //TODO List.Sum()
            for (int i = 0; i < pts.Count; ++i)
            {
                //calculate denominator: sum(pdfs, axis = 1)
                double sum = 0;
                for (int j = 0; j < num_gaussians; ++j)
                {
                    sum += pdfs[j][i];
                }
                //calculate W (inplace)
                for (int j = 0; j < num_gaussians; ++j)
                {
                    pdfs[j][i] /= sum;
                }
            }

            return pdfs;
        }

        public (List<Gaussian_2D> gaussian_list, List<double> class_prior) MStep(List<List<double>> W)
        {
            List<Gaussian_2D> gaussian_list = new List<Gaussian_2D>();
            List<double> class_prior = new List<double>();

            for (int j = 0; j < W.Count; j++)
            {
                double sum = 0;
                Gaussian_2D gau = new Gaussian_2D();
                //double gau.miu.x = Convert.ToDouble(gau.miu.x);
                //calculate class prior and mean
                for (int i = 0; i < W[0].Count; i++)
                {
                    sum += W[j][i];//sum(W, axis=0)
                    gau.miu.x += (float)W[j][i] * (pts[i].x);//sum(Wi, xi)
                    gau.miu.y += (float)W[j][i] * pts[i].y;//sum(Wi, yi)
                }
                gau.miu.x /= (float)sum;
                gau.miu.y /= (float)sum;
                class_prior.Add(sum / W[0].Count);

                //calculate covariance
                for (int i = 0; i < W[0].Count; i++)
                {
                    gau.Sigma.m00 += (float)(W[j][i] * Math.Pow(pts[i].x - gau.miu.x, 2));
                    gau.Sigma.m10 = gau.Sigma.m01 += (float)W[j][i] * (pts[i].x - gau.miu.x) * (pts[i].y - gau.miu.y);
                    gau.Sigma.m11 += (float)(W[j][i] * Math.Pow(pts[i].y - gau.miu.y, 2));
                }
                gau.Sigma.m00 /= (float)sum;
                gau.Sigma.m10 = gau.Sigma.m01 /= (float)sum;
                gau.Sigma.m11 /= (float)sum;

                gaussian_list.Add(gau);
            }

            return (gaussian_list, class_prior);
        }

        public List<Gaussian_2D> FitGaussians(int num_gaussians)
        {
            int max_iter = 20;
            Random rand = new Random();

            //init gaussians and class prior (weight)
            List<Gaussian_2D> gaussian_list = new List<Gaussian_2D>();

            if (pts != null)
            {
                List<double> class_prior = new List<double>();
                for (int i = 0; i < num_gaussians; i++)
                {
                    gaussian_list.Add(new Gaussian_2D(rand, true));
                    class_prior.Add(1 / (double)(num_gaussians));
                }
                //init P(gaussian=j | point=i)
                List<List<double>> W = new List<List<double>>();

                //EM algo
                int iter = 0;
                do
                {
                    W = EStep(gaussian_list, class_prior);
                    (gaussian_list, class_prior) = MStep(W);
                    iter++;
                    //TODO: loglikelihood
                } while (iter < max_iter);
            }
            return gaussian_list;
        }

        public List<Gaussian_2D> DrawDummyGaussian()
        {
            return sample_gaussian_list;
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
