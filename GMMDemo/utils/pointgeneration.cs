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
    public static class RandomPoints
    {
        public static List<Vector2> Generate(int num_of_points, int xmax, int ymax) //x and y range from 0
        {
            List<Vector2> pts = new List<Vector2>();
            Random rand = new Random();
            for (int i = 0; i < num_of_points; ++i)
            {
                pts.Add(new Vector2(rand.Next(0, xmax), rand.Next(0, ymax)));
            }
            return pts;
        }
    }

    public static class LidarPoints
    {
        private static PointF[] StarPoints(int num_points, Rectangle bounds)
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
        public static List<Vector2> Generate(int xmax, int ymax, out List<Polygon> drawing_polygons, out Vector2 scan_position)
        {
            List<Vector2> pts = new List<Vector2>();
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
    }

    public static class GaussianPoints
    {
        public static (List<Vector2>, List<Gaussian_2D>) Generate(int num_of_points, int num_gaussians)
        {
            List<Gaussian_2D> ground_truth_gaussian_list = new List<Gaussian_2D>();
            List<Vector2> pts = new List<Vector2>();
            Random rand = new Random();

            int ptsPerGaussian = (int)Math.Round((double)num_of_points / num_gaussians);

            for (int loop = 0; loop < num_gaussians; loop++)
            {
                Gaussian_2D sample_gaussian = new Gaussian_2D(rand);
                ground_truth_gaussian_list.Add(sample_gaussian);

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
            return (pts, ground_truth_gaussian_list);
        }
    }

    public static class Scan2D
    {
        public static List<Vector2> Import(int num_of_points, List<String> lines, float canvasWidth, float CanvasHeight)
        {
            List<Vector2> scanned_pts = new List<Vector2>();
            List<Vector2> pts = new List<Vector2>();
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
            for (int i = 0; i < scanned_pts.Count; i++)
            {
                scanned_pts[i].x = (int)Math.Round(scanned_pts[i].x * xScale);
                scanned_pts[i].y = (int)Math.Round(scanned_pts[i].y * yScale);

            }

            for (int raw = 0; raw < scanned_pts.Count; raw++)
            {
                bool duplicate = false;
                for (int compare = 0; compare < raw; compare++)
                {
                    if ((scanned_pts[raw].x == scanned_pts[compare].x) && (scanned_pts[raw].y == scanned_pts[compare].y))
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
    }
}
