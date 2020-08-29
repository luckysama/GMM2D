using System;
using System.Collections.Generic;
using System.Linq;

namespace GMMDemo
{ 
    public class random_state
    {
        public static List<Vector2> choice(List<Vector2> pts, int pts_count)
        {
            IOrderedEnumerable<Vector2> ordered_pts = pts.OrderBy(arg => Guid.NewGuid());
            List<Vector2> sample_pts = ordered_pts.Take(pts_count).ToList();
            return sample_pts;
        }
    }
        
}