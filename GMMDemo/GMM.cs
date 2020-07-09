﻿using System;
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
        public List<Vector2> pts;

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
                for (int i = 0; i < pts.Count; ++i)
                {
                    pdf.Add(class_prior[j] * MatrixMath.MultivariateNormalPDF(pts[i], 
                                                                            gaussian_list[j].miu, 
                                                                            gaussian_list[j].Sigma));
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

            //calculate class prior
            for (int j = 0; j < W.Count; j++)
            {
                double sum = 0;
                Vector2 sum_prior = new Vector2();
                Matrix22 sum_sigma = new Matrix22();
                for (int i = 0; i < W[0].Count; i++)
                {
                    sum += W[j][i];
                    sum_prior.x += (float)W[j][i] * pts[i].x;
                    sum_prior.y += (float)W[j][i] * pts[i].y;
                    sum_sigma.m00 += 1;
                }
                class_prior.Add(sum / W[0].Count);
            }

            //calculate mean
            for (int j = 0; j < W.Count; j++)
            {
                double sum = 0;
                for (int i = 0; i < W[0].Count; i++)
                {
                    sum += W[j][i];
                }
                gaussian_list[j].miu.x = 0;
                gaussian_list[j].miu.y = 0;
            }

            return (gaussian_list, class_prior);
        }

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

        public List<Vector2> GenerateDummyGaussianPoints(int num_of_points, int xmax, int ymax) //x and y range from 0
        {
            pts = new List<Vector2>();
            Random rand = new Random();
            Gaussian_2D dummy_gaussian = CreateDummyGaussian();

            dummy_gaussian.Sigma.UpdateEigens();
            double angle;
            Console.WriteLine("Eigenvalues");
            Console.WriteLine(dummy_gaussian.Sigma.eigenvalue_0);
            Console.WriteLine(dummy_gaussian.Sigma.eigenvalue_1);
            if (dummy_gaussian.Sigma.eigenvalue_0 > dummy_gaussian.Sigma.eigenvalue_1)
            {
                angle = Math.PI + Math.Atan2(dummy_gaussian.Sigma.eigenvector_0.y, dummy_gaussian.Sigma.eigenvector_0.x);
            }
            else
            {
                angle = Math.PI + Math.Atan2(dummy_gaussian.Sigma.eigenvector_1.y, dummy_gaussian.Sigma.eigenvector_1.x);
            }
          
            Console.WriteLine("Sample angle");
            Console.WriteLine(angle * 180 / Math.PI);
            double u1, u2;
            int x_old, y_old;
            int x, y;

            for (int i = 0; i < num_of_points; i++)
            {
                do
                {
                    u1 = rand.NextDouble();
                    u2 = rand.NextDouble();
                } while (u1 == 0 && u2 == 0);
                x_old = (int)Math.Round(Math.Sqrt(dummy_gaussian.Sigma.m00) * Math.Sqrt(-2 * Math.Log(u2)) * Math.Cos(2 * Math.PI * u1));
                y_old = (int)Math.Round(Math.Sqrt(dummy_gaussian.Sigma.m11) * Math.Sqrt(-2 * Math.Log(u2)) * Math.Sin(2 * Math.PI * u1));
                x = (int)Math.Round(x_old * Math.Cos(angle) - y_old * Math.Sin(angle) + dummy_gaussian.miu.x);
                y = (int)Math.Round(x_old * Math.Sin(angle) + y_old * Math.Cos(angle) + dummy_gaussian.miu.y);
                pts.Add(new Vector2(x, y));
            }
            return pts;
        }

        public List<Gaussian_2D> Fit4Gaussians()
        {
            int num_gaussians = 4;
            int max_iter = 1;
            Random rand = new Random();

            //init gaussians and class prior (weight)
            List<Gaussian_2D> gaussian_list = new List<Gaussian_2D>();
            List<double> class_prior = new List<double>();
            for (int i = 0; i < num_gaussians; i++)
            {
                gaussian_list.Add(new Gaussian_2D(rand));
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
            } while (iter < max_iter);

            return gaussian_list;
        }

        public List<Gaussian_2D> DrawDummyGaussian(){
            List<Gaussian_2D> gaussian_list = new List<Gaussian_2D>();
            gaussian_list.Add(CreateDummyGaussian());
            return gaussian_list;
        }
        public Gaussian_2D CreateDummyGaussian()
        {
            Gaussian_2D dummy_gaussian = new Gaussian_2D();
            
            dummy_gaussian.miu = new Vector2(200, 200);
            ///used the example matrix in https://en.wikipedia.org/wiki/Multivariate_normal_distribution
            dummy_gaussian.Sigma.m00 = 50;
            dummy_gaussian.Sigma.m01 = 30;
            dummy_gaussian.Sigma.m10 = 30;
            dummy_gaussian.Sigma.m11 = 100;
            return dummy_gaussian;
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
