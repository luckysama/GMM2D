using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace GMMDemo
{
    public static class KMeans
    {
        private static List<Vector2> pts;
        private static int num_clusters;
        private static List<Vector2> init_centroid = new List<Vector2>();
        private static Random rand = new Random();

        private static List<int> ClosestCentroid(List<Vector2> init_means)
        {
            List<int> closest_centroid = new List<int>();
            foreach (Vector2 pt in pts)
            {
                List<double> dist_list = new List<double>();
                foreach (Vector2 centroid in init_means)
                {
                    dist_list.Add((double)pt.distancesquare(centroid));
                }
                closest_centroid.Add(dist_list.IndexOf(dist_list.Min()));
            }
            return closest_centroid;
        }

        private static List<Vector2> ShiftCentroid(List<int> closest_centroid)
        {
            List<Vector2> centroid = new List<Vector2>(num_clusters);
            List<int> point_per_cluster = new List<int>(num_clusters);
            for (int i = 0; i < num_clusters; i++)
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

        private static bool CloseCentroid(List<Vector2> old_centroid, List<Vector2> centroid)
        {
            double centroid_diff_thresh = 0.01;
            double centroid_diff = 0;

            for (int i = 0; i < num_clusters; i++)
            {
                centroid_diff += old_centroid[i].distancesquare(centroid[i]);
            }

            if (centroid_diff < centroid_diff_thresh)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Gaussian_2D> fit(List<Vector2> pts_init, int num_clusters_init)
        {
            pts = pts_init;
            num_clusters = num_clusters_init;
            int num_points = pts.Count();
            List<Gaussian_2D> gau_list = new List<Gaussian_2D>();

            int iter_counter = 0;
            init_centroid = random_state.choice(pts, num_clusters);
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

            foreach (Vector2 miu in centroid)
            {
                Gaussian_2D gau = new Gaussian_2D(rand, miu);
                gau_list.Add(gau);
            }
            return gau_list;
        }

    }

    public static class FuzzyCMeans
    {
        private static List<Vector2> pts;
        private static int num_clusters;
        private static Random rand = new Random();
        private static int fuz_coef = 2;

        private static List<List<double>> InitializeMemberships()
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

        private static List<Vector2> UpdateCenter(List<List<double>> membership)
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

        private static List<List<double>> GetDistance(List<Vector2> centers)
        {
            List<List<double>> dist_list = new List<List<double>>();
            foreach (Vector2 pt in pts)
            {
                List<double> dist_list_i = new List<double>();
                foreach (Vector2 centroid in centers)
                {
                    dist_list_i.Add((double)pt.distancesquare(centroid));
                }
                dist_list.Add(dist_list_i);
            }
            return dist_list;
        }

        private static List<List<double>> UpdateMemberships(List<Vector2> centers)
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

        private static bool CloseCentroid(List<Vector2> old_centroid, List<Vector2> centroid)
        {
            double centroid_diff_thresh = 0.01;
            double centroid_diff = 0;

            for (int i = 0; i < num_clusters; i++)
            {
                centroid_diff += old_centroid[i].distancesquare(centroid[i]);
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

        public static List<Gaussian_2D> fit(List<Vector2> pts_init, int num_clusters_init)
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
}