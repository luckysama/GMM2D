using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Runtime.InteropServices;

namespace GMMDemo
{
    public interface BaseModel
    {
        // Line model parameters
        Vector2 Start { get; set; }
        Vector2 End { get; set; }

        // Circle model parameters
        Vector2 Center { get; set; }
        float R { get; set; }

        void Estimate(List<Vector2> pts);
        List<float> Residual(List<Vector2> pts);
        void UpdateLineEnds(List<Vector2> pts);
    }
    
    public class LineModel : BaseModel
    {
        // Line model parameters
        public Vector2 Start { get; set; }
        public Vector2 End { get; set; }
        private Vector2 origin = null;
        private Vector2 direction = null;

        // Circle model parameters
        public Vector2 Center { get; set; }
        public float R { get; set; }

        public void Estimate(List<Vector2> pts)
        {
            origin = Matrix.Mean(pts);
            List<Vector2> centered_pts = Matrix.Minus(pts, origin);

            if(centered_pts.Count == 2)
            {
                Start = centered_pts[0];
                End = centered_pts[1];
                direction = centered_pts[1].Minus(centered_pts[0]);
                float norm = (float)Math.Sqrt(centered_pts[1].distancesquare(centered_pts[0]));
                direction.x /= norm;
                direction.y /= norm;
            } 
            else if (centered_pts.Count > 2)
            {
                direction = Matrix.SVD_V(centered_pts);
            }
            else
            {
                throw new ArgumentException("At least 2 input points needed.", "original");
            }
        }

        public List<float> Residual(List<Vector2> pts)
        {
            if (origin == null || direction == null)
            {
                throw new ArgumentException("Parameters cannot be None.", "original");
            }

            List<float> residuals = new List<float>();
            float residual;

            Vector2 origin_to_pt;
            foreach (Vector2 pt in pts)
            {
                origin_to_pt = pt.Minus(origin);
                residual = Math.Abs(origin_to_pt.Cross2d(direction));
                residuals.Add(residual);
            }

            return residuals;
        }

        public void UpdateLineEnds(List<Vector2> pts)
        {
            float residual;
            Vector2 origin_to_pt;
            float projection_x;
            float projection_y;
            float max_projection_x = 0;
            float min_projection_x = 0;
            foreach (Vector2 pt in pts)
            {
                origin_to_pt = pt.Minus(origin);
                //residual = Math.Abs(origin_to_pt.Cross2d(direction));
                residual = origin_to_pt.Cross2d(direction);
                projection_x = origin_to_pt.x - residual * direction.y;
                if (projection_x > max_projection_x)
                {
                    max_projection_x = projection_x;
                    projection_y = projection_x * direction.y / direction.x;
                    End = new Vector2(origin.x + projection_x, origin.y + projection_y);
                }
                else if (projection_x < min_projection_x)
                {
                    min_projection_x = projection_x;
                    projection_y = projection_x * direction.y / direction.x;
                    Start = new Vector2(origin.x + projection_x, origin.y + projection_y);
                }
            }

        }

    }
    
    public class CircleModel : BaseModel
    {
        // Line model parameters
        public Vector2 Start { get; set; }
        public Vector2 End { get; set; }

        // Circle model parameters
        public Vector2 Center { get; set; } = null;
        public float R { get; set; } = 0;

        public void Estimate(List<Vector2> pts)
        {
            // http://www.dtcenter.org/sites/default/files/community-code/met/docs/write-ups/circle_fit.pdf
            float a;
            float b;
            float x2;
            float y2;
            float uc;
            float vc;

            Matrix22 m1;
            Matrix22 m2;
            Matrix22 m3;

            float sum_x2 = 0;
            float sum_y2 = 0;
            float sum_xy = 0;
            float sum_x3 = 0;
            float sum_y3 = 0;
            float sum_xy2 = 0;
            float sum_yx2 = 0;

            Vector2 origin = Matrix.Mean(pts);
            List<Vector2> centered_pts = Matrix.Minus(pts, origin);

            foreach (Vector2 pt in centered_pts)
            {
                x2 = pt.x * pt.x;
                y2 = pt.y * pt.y;
                sum_x2 += x2;
                sum_y2 += y2;
                sum_xy += pt.x * pt.y;
                sum_x3 += x2 * pt.x;
                sum_y3 += y2 * pt.y;
                sum_xy2 += pt.x * y2;
                sum_yx2 += pt.y * x2;
            }

            a = (sum_x3 + sum_xy2) / 2;
            b = (sum_y3 + sum_yx2) / 2;

            // Solve 2-dimensional linear equation using Cramer’s rule:
            // https://www.geeksforgeeks.org/system-linear-equations-three-variables-using-cramers-rule/
            m1 = new Matrix22(sum_x2, sum_xy, sum_xy, sum_y2);
            m2 = new Matrix22(a, sum_xy, b, sum_y2);
            m3 = new Matrix22(sum_x2, a, sum_xy, b);

            uc = m2.Det() / m1.Det();
            vc = m3.Det() / m1.Det();

            Center = new Vector2(uc, vc).Add(origin);
            R = (float)Math.Sqrt(uc * uc + vc * vc + (sum_x2 + sum_y2) / centered_pts.Count);
        }

        public List<float> Residual(List<Vector2> pts)
        {
            if (Center == null || R == 0)
            {
                throw new ArgumentException("Parameters cannot be None.", "original");
            }

            float x2;
            float y2;
            float residual;
            Vector2 centered_pt;

            List<float> residuals = new List<float>();
            foreach (Vector2 pt in pts)
            {
                centered_pt = pt.Minus(Center);
                x2 = centered_pt.x * centered_pt.x;
                y2 = centered_pt.y * centered_pt.y;

                residual = Math.Abs(R - (float)Math.Sqrt(x2 + y2));
                residuals.Add(residual);
            }

            return residuals;
        }

        public void UpdateLineEnds(List<Vector2> pts)
        {
            // Place holder
        }

    }

    public static class RANSAC
    {
        private static List<Vector2> GetInliers(List<float> residuals, float residual_threshold, List<Vector2> pts)
        {
            List<Vector2> inliers = new List<Vector2>();
            for(int i = 0; i < pts.Count; i++)
            {
                if (residuals[i] <= residual_threshold)
                {
                    inliers.Add(pts[i]);
                }
            }
            return inliers;
        }

        public static BaseModel Fit(List<Vector2> pts, BaseModel model_class, int min_samples, float residual_threshold)
        {
            int max_trials = 200;
            int num_trials = 0;
            int stop_sample_num = 10000000;
            float stop_residuals_sum = 0;
            //float stop_probability = 1;

            BaseModel sample_model;
            int sample_inlier_num;
            float sample_model_residuals_sum;
            List<Vector2> samples;
            List<float> sample_model_residuals;
            List<Vector2> sample_model_inliers;

            BaseModel best_model = null;
            int best_inlier_num = 0;
            List<float> best_model_residuals;
            float best_inlier_residuals_sum = 10000000;
            List<Vector2> best_inliers = null;

            while (num_trials < max_trials)
            {
                //sample selection
                samples = random_state.choice(pts, min_samples);

                //estimate model for current random sample set
                sample_model = model_class;
                sample_model.Estimate(samples);

                //consensus set / inliers
                sample_model_residuals = sample_model.Residual(pts);
                sample_model_residuals_sum = sample_model_residuals.Sum();
                sample_model_inliers = GetInliers(sample_model_residuals, residual_threshold, pts);

                //choose as new best model if number of inliers is maximal
                sample_inlier_num = sample_model_inliers.Count;

                if (//more inliers
                    sample_inlier_num > best_inlier_num
                    //same number of inliers but less "error" in terms of residuals
                    || (sample_inlier_num == best_inlier_num
                    && sample_model_residuals_sum < best_inlier_residuals_sum)
                    )
                {
                    best_model = sample_model;
                    best_inlier_num = sample_inlier_num;
                    best_inlier_residuals_sum = sample_model_residuals_sum;
                    best_inliers = sample_model_inliers;
                    //TODO: dynamic max trials
                    if (best_inlier_num >= stop_sample_num
                        || best_inlier_residuals_sum <= stop_residuals_sum
                        )  //|| num_trials >= dynamic_max_trials
                    {
                        break;
                    }
                }
                    
                num_trials++;
            }
            Console.WriteLine("Inum_trials : {0}", num_trials);

            //estimate final model using all inliers
            if (best_inliers != null)
            {
                best_model.Estimate(best_inliers);
                best_model_residuals = best_model.Residual(pts);
                best_inliers = GetInliers(best_model_residuals, residual_threshold, pts);
                best_model.UpdateLineEnds(best_inliers);
                float accuracy = (float)best_inliers.Count / (float)pts.Count;
                Console.WriteLine("### Inliers / all points : {0}", accuracy);
            }
        
            return best_model;
        }
    }
    
}
