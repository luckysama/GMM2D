using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GMMDemo
{
    /// <summary>
    /// way to simulate a simple lidar using GDI+'s region class
    /// 1. create a few rectangles (do not create rectangles that contain the lidar)
    /// 2. shoot rays from the lidar (maxX/2, maxY/2) to 360 all around it
    /// 3. for each rectangle
    /// 3.1 intersect the ray with each edge of the region
    /// 3.2 compute a list of intersection points for each edge (need to be within the segment)
    /// 3.3 sort the distance of the intersections ( from all regions) towards the lidar, and pick the closest one as the scanned point
    /// 3.4 add some noise 
    /// 3.5 return the scanned point list to GMM class and the drawing form class
    /// </summary>
    public class Polygon
    {
        public List<PointF> vertices;
        public Polygon()
        {
            vertices = new List<PointF>();
        }
        public void AddPointFArray(PointF[] ptF)
        {
            for (int i = 0; i < ptF.Length; ++ i)
            {
                vertices.Add(ptF[i]);
            }
        }
        public PointF[] pts
        {
            get
            {
                return vertices.ToArray();
            }
        }
    }
    public class simplelidar
    {

        public float lidar_error = 0.5f;
        public List<Polygon> polygons_list;
        public int scan_density = 360;//send out 360 scans
        public List<Vector2> ScanFrom(Vector2 lidar_pos)
        {
            double rad_step = 2 * Math.PI / (double)(scan_density);
            double current_rad = 0;
            Random rand = new Random();
            List<Vector2> scan_result = new List<Vector2>();

            for (int i = 0; i < scan_density; ++ i)
            {
                Vector2 ray_direction = new Vector2((float)Math.Cos(current_rad), (float)Math.Sin(current_rad));
                List<Vector2> intersections = new List<Vector2>();
                bool has_intersection = false;
                foreach (Polygon poly in polygons_list)
                {
                    Vector2 segment_start, segment_end, intersect_pt;
                    for (int j = 0; j < poly.vertices.Count - 1; ++ j)
                    {
                        segment_start = new Vector2(poly.vertices[j]);
                        segment_end = new Vector2(poly.vertices[j + 1]);
                        intersect_pt = ComputeRaySegmentIntersection(lidar_pos, ray_direction, 
                            segment_start, segment_end, out has_intersection);
                        if (has_intersection)
                        {
                            intersections.Add(intersect_pt);
                        }
                    }

                    //last segment
                    segment_start = new Vector2(poly.vertices[poly.vertices.Count - 1]);
                    segment_end = new Vector2(poly.vertices[0]);
                    intersect_pt = ComputeRaySegmentIntersection(lidar_pos, ray_direction,
                           segment_start, segment_end, out has_intersection);
                    if (has_intersection)
                    {
                        intersections.Add(intersect_pt);
                    }
                }

                //pick the closest intersection point
                if (intersections.Count > 0)
                {
                    float min_distance = lidar_pos.distancesquare(intersections[0]);
                    int min_index = 0;
                    for (int j = 1; j < intersections.Count; ++j)
                    {
                        float distance = lidar_pos.distancesquare(intersections[j]);
                        if (distance < min_distance)
                        {
                            min_distance = distance;
                            min_index = j;
                        }
                    }
                    Vector2 closest_intersection = intersections[min_index];
                    closest_intersection.x += (float)(rand.NextDouble() * lidar_error);
                    closest_intersection.y += (float)(rand.NextDouble() * lidar_error);
                    scan_result.Add(new Vector2(closest_intersection));
                }
                current_rad += rad_step;
            }
            return scan_result;
        }
        ///https://stackoverflow.com/questions/563198/how-do-you-detect-where-two-line-segments-intersect
        private Vector2 ComputeRaySegmentIntersection(Vector2 origin, Vector2 direction, 
            Vector2 segment_start, Vector2 segment_end, out bool has_intersection)
        {
            has_intersection = true;
            //align the notations with the stackoverflow blog
            Vector2 p = origin;
            Vector2 r = direction;
            Vector2 q = segment_start;
            Vector2 s = segment_end.Minus(segment_start);

            float r_cross_s = r.Cross2d(s);
            if (r_cross_s == 0)
            {
                has_intersection = false;//parallel
                return new Vector2();
            }
            Vector2 q_minues_p = q.Minus(p);
            float qp_cross_r = q_minues_p.Cross2d(r);
            float u = qp_cross_r / r_cross_s;
            Vector2 intersection_point = q.Add(new Vector2(u * s.x, u * s.y));
            if (u < 0) has_intersection = false;
            if (u > 1) has_intersection = false;
            return intersection_point;

        }

    }
}
