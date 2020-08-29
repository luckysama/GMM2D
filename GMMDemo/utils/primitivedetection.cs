using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Runtime.InteropServices;

namespace GMMDemo
{
    public interface BaseModel
    {
        Vector2 start { get; set; }
        Vector2 end { get; set; }

        void Estimate(List<Vector2> pts);
        List<float> Residual(List<Vector2> pts);
        void UpdateLineEnds(List<Vector2> pts);
        BaseModel ShallowCopy();
    }
    
    public class LineModel : BaseModel
    {
        public Vector2 start { get; set; }
        public Vector2 end { get; set; }
        private Vector2 origin;
        private Vector2 direction;

        public void Estimate(List<Vector2> pts)
        {
            origin = Matrix.Mean(pts);
            List<Vector2> centered_pts = Matrix.Minus(pts, origin);

            if(centered_pts.Count == 2)
            {
                start = centered_pts[0];
                end = centered_pts[1];
                direction = centered_pts[1].Minus(centered_pts[0]);
                float norm = (float)Math.Sqrt(centered_pts[1].distancesquare(centered_pts[0]));
                direction.x /= norm;
                direction.y /= norm;
            } 
            else if (centered_pts.Count > 2)
            {
                direction = Matrix.SVD_V(origin, centered_pts);
            }
            else
            {
                throw new System.ArgumentException("At least 2 input points needed.", "original");
            }
        }

        public List<float> Residual(List<Vector2> pts)
        {
            if (origin == null || direction == null)
            {
                throw new System.ArgumentException("Parameters cannot be None.", "original");
            }

            List<float> residuals = new List<float>();
            float residual;
            float sum = 0;

            Vector2 origin_to_pt;
            foreach (Vector2 pt in pts)
            {
                origin_to_pt = pt.Minus(origin);
                residual = Math.Abs(origin_to_pt.Cross2d(direction));
                residuals.Add(residual);
                //sum += residual * residual;
            }
            /*
            sum = (float)Math.Sqrt(sum);

            for( int i = 0; i < residuals.Count; i++)
            {
                residuals[i] /= sum;
            }*/

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
                    end = new Vector2(origin.x + projection_x, origin.y + projection_y);
                }
                else if (projection_x < min_projection_x)
                {
                    min_projection_x = projection_x;
                    projection_y = projection_x * direction.y / direction.x;
                    start = new Vector2(origin.x + projection_x, origin.y + projection_y);
                }
            }

        }

        public BaseModel ShallowCopy()
        {
            return (BaseModel)this.MemberwiseClone();
        }
    }
    /*
    public class CircleModel : BaseModel
    {
        public Vector2 origin { get; set; }
        public Vector2 direction { get; set; }

        public void Estimate(List<Vector2> pts)
        {
        }

        public List<float> Residual(List<Vector2> pts)
        {
            return null;
        }

        public BaseModel ShallowCopy()
        {
            return (BaseModel)this.MemberwiseClone();
        }
    }*/

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

        public static BaseModel Fit(List<Vector2> pts, BaseModel model_class, int min_samples=2)
        {
            int max_trials = 200;
            int num_trials = 0;
            int stop_sample_num = 10000000;
            float stop_residuals_sum = 0;
            //float stop_probability = 1;
            float residual_threshold = 2.00F;

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
                    float accuracy = (float)best_inliers.Count / (float)pts.Count;
                    Console.WriteLine("Inliers / all points : {0}", accuracy);
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
