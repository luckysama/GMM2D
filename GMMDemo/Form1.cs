using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GMMDemo
{
    public partial class GMMDemoWnd : Form
    {
        public GMMDemoWnd()
        {
            InitializeComponent();
            drawingPts = null;
            gmm = new GMM();
            label_status.Text = "Welcome to GMM demo!"; // use this control to display a line of text.
        }

        List<Vector2> drawingPts = null;
        List<Vector2> drawingLargeCircles = null;
        List<Gaussian_2D> drawingGaussians = null;
        List<Polygon> drawingPolygons = null;

        Color pt_drawing_color = Color.Red;
        Color ground_truth_color = Color.Blue;
        Color polygon_color = Color.LightBlue;
        Color circle_color = Color.Purple;


        int drawing_size_x = 2;
        int drawing_size_y = 2;

        int num_of_points;
        int num_of_samples;
        int num_of_fits;
        int num_of_levels;
        int viewed_level;
        bool fit_ran = false;
        bool use_random_colors;
        bool drop_gaussians;
        bool kmeans_init;

        GMM gmm;

        private void UpdateConfigurationUnputs()
        {
            num_of_points = (int)PointNumber.Value;
            num_of_samples = (int)SampleNumber.Value;
            num_of_fits = (int)FitNumber.Value;
            num_of_levels = (int)LayerNumber.Value;
            viewed_level = (int)ViewedLayerNumber.Value;
            use_random_colors = (bool)useRandomColors.Checked;
            drop_gaussians = (bool)dropGaussians.Checked;
            kmeans_init = (bool)KmeansInit.Checked;
            fit_ran = false;
        }

        private void UpdateConfigurationHandler(object sender, EventArgs e)
        {
            UpdateConfigurationUnputs();
        }

        private void ClearDrawingData()
        {
            drawingGaussians = null;
            drawingPolygons = null;
            drawingPts = null;
            drawingLargeCircles = null;
        }
        private void ResetSimulationMemory()
        {
            gmm.pts = null;
            gmm.sample_gaussian_list = null;
            ClearDrawingData();
            label_status.Text = "Memory cleared at " + DateTime.Now;
        }

        private void regenerateRandomDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearDrawingData();
            drawingPts = gmm.GenerateRandomPoints(num_of_points, groupbox_canvas.Width, groupbox_canvas.Height);
            fit_ran = false;
            label_status.Text = "Generated " + num_of_points + " new random points at " + DateTime.Now;
            this.Refresh();
        }

        private void fitGMMsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label_status.Text = "Calculating... ";
            drawingGaussians = null;
            this.Refresh();
            DateTime time_start = DateTime.Now;
            (drawingGaussians, drawingPts) = gmm.FitGaussians(num_of_fits, num_of_levels, kmeans_init);
            DateTime time_end = DateTime.Now;

            fit_ran = true;
            label_status.Text = "Done in " + time_end.Subtract(time_start).TotalSeconds.ToString() + " seconds at " + DateTime.Now;
            this.Refresh();
        }

        private void generateDummyGaussianDataToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ClearDrawingData();
            drawingPts = gmm.GenerateGaussianPoints(num_of_points, num_of_samples);
            fit_ran = false;
            label_status.Text = "Generated " + num_of_points + " new gaussian points at " + DateTime.Now;
            this.Refresh();
        }

        private void generateLiDARDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearDrawingData();
            Vector2 Scanner_Position;
            drawingPts = gmm.GenerateLidarPoints(drawing_size_x, drawing_size_y, out drawingPolygons, out Scanner_Position);
            drawingLargeCircles = new List<Vector2>();
            drawingLargeCircles.Add(Scanner_Position);
            fit_ran = false;
            label_status.Text = "Generated simulated 2D lidar data";
            this.Refresh();
        }

        private void drawDummyGaussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawingGaussians = gmm.DrawDummyGaussian();
            label_status.Text = "Displaying ground truth at " + DateTime.Now;
            this.Refresh();
        }

        private void groupbox_canvans_Paint(object sender, PaintEventArgs e)
        {
            Random random_color = new Random();
            ColorList ellipse_colors = new ColorList();
            ColorList fixed_ellipse_colors = new ColorList();
            Color ellipse_color = ellipse_colors.NextColor();
            List<Color> point_colors = new List<Color>();
            int point_color_index;

            drawing_size_x = e.ClipRectangle.Width;
            drawing_size_y = e.ClipRectangle.Height;

            Graphics g = e.Graphics;

            //draw the polygon first, which will be the background of everything else
            if (drawingPolygons != null)
            {                
                SolidBrush polygonbrush = new SolidBrush(polygon_color);
                foreach (Polygon poly in drawingPolygons)
                {
                    g.FillPolygon(polygonbrush, poly.pts);
                }
            }
            //draw the large circles
            if (drawingLargeCircles != null)
            {
                SolidBrush circleBrush = new SolidBrush(circle_color);
                foreach (Vector2 vec in drawingLargeCircles)
                {
                    g.FillEllipse(circleBrush, new Rectangle((int)(vec.x - 10), (int)(vec.y - 10), 20, 20));
                }
            }    

            if (drawingPts != null && drawingPts.Count > 0)
            {
                SolidBrush defaultBrush = new SolidBrush(pt_drawing_color);
                
                if (viewed_level <= drawingPts[0].gaussian_idx.Count && fit_ran)
                {
                    for(int parent_count = 0; parent_count < (int)Math.Pow(num_of_fits, viewed_level); parent_count++)
                    {
                        if (use_random_colors)
                        {
                            point_colors.Add(Color.FromArgb(random_color.Next(256), random_color.Next(256), random_color.Next(256)));
                        }
                        else
                        {
                            point_colors.Add(fixed_ellipse_colors.NextColor());
                        }
                    }

                    int cumulative = 0;
                    if (viewed_level > 1)
                    {
                        for (int layer = 1; layer < viewed_level; layer++)
                        {
                            cumulative += (int)Math.Pow(num_of_fits, layer);
                        }
                    }
                    else cumulative = 0;

                    foreach (Vector2 pt in drawingPts)
                    {
                        if (viewed_level == 1)
                        {
                            point_color_index = pt.gaussian_idx[0];
                        }
                        else
                        {
                            int check = pt.gaussian_idx[0];
                            point_color_index = pt.gaussian_idx[viewed_level-1] - cumulative;
                        }
                        SolidBrush brush = new SolidBrush(point_colors[point_color_index]);
                        g.FillRectangle(brush, pt.x - 1, pt.y - 1, 3, 3); //a 9 pixel dot
                    }
                }
                else
                {
                    foreach (Vector2 pt in drawingPts)
                    {
                        g.FillRectangle(defaultBrush, pt.x - 1, pt.y - 1, 3, 3); //a 9 pixel dot
                    }
                }
                
            }
            if (drawingGaussians != null)
            {
                if (!fit_ran)
                {
                    Pen ground_truth_pen = new Pen(ground_truth_color, 2);
                    foreach (Gaussian_2D gaussian in drawingGaussians)
                    {
                            Draw3SigmaEllipse(g, gaussian, ground_truth_pen);
                    }
                }
                else
                {
                    Pen ellipse_pen = new Pen(ellipse_color, 2);
                    int gaussian_count = 0;
                    int layer_count = 1;
                    int cumulative_limit = num_of_fits;
                    foreach (Gaussian_2D gaussian in drawingGaussians)
                    {
                        if (gaussian_count >= cumulative_limit)
                        {
                            layer_count++;
                            ellipse_color = ellipse_colors.NextColor();
                            ellipse_pen = new Pen(ellipse_color, 2);
                            cumulative_limit += (int)Math.Pow(num_of_fits, layer_count);
                        }
                       
                        if (gaussian.dropped && drop_gaussians)
                        {
                            gaussian_count++;
                            continue;
                        }
                        Draw3SigmaEllipse(g, gaussian, ellipse_pen);
                        gaussian_count++;
                    }
                }
                
            }
        }

        /// How to draw the 3-sigma error ellipse of a given 2D Gaussian?
        /// https://math.stackexchange.com/questions/395698/fast-way-to-calculate-eigen-of-2x2-matrix-using-a-formula
        /// https://www.visiondummy.com/2014/04/draw-error-ellipse-representing-covariance-matrix/
        /// http://people.math.harvard.edu/~knill/teaching/math21b2004/exhibits/2dmatrices/index.html
        void Draw3SigmaEllipse(Graphics g, Gaussian_2D gaussian, Pen pen)
        {
            gaussian.Sigma.UpdateEigens();
            float major_axis, minor_axis;

            if (gaussian.Sigma.eigenvalue_0 > gaussian.Sigma.eigenvalue_1)
            {
                major_axis = (float)(2 * Math.Sqrt(5.991f * gaussian.Sigma.eigenvalue_0));
                minor_axis = (float)(2 * Math.Sqrt(5.991f * gaussian.Sigma.eigenvalue_1));
            }
            else
            {
                major_axis = (float)(2 * Math.Sqrt(5.991f * gaussian.Sigma.eigenvalue_1));
                minor_axis = (float)(2 * Math.Sqrt(5.991f * gaussian.Sigma.eigenvalue_0));
            }

            float x_axis, y_axis;
            double angle;
            if (gaussian.Sigma.m00 > gaussian.Sigma.m11)
            {
                x_axis = major_axis;
                y_axis = minor_axis;
                angle = Math.Atan2(gaussian.Sigma.eigenvector_0.y, gaussian.Sigma.eigenvector_0.x);
            }
            else
            {
                x_axis = minor_axis;
                y_axis = major_axis;
                angle = Math.Atan2(gaussian.Sigma.eigenvector_1.y, gaussian.Sigma.eigenvector_1.x);
            }
            if (Double.IsNaN(angle))
            {
                label_status.Text = "One or more gaussians failed to fit. Modify your input parameters.";
                return;
            }
            g.TranslateTransform(gaussian.miu.x, gaussian.miu.y);
            g.RotateTransform((float)(angle * 180 / Math.PI)); //Rad to Deg
            g.DrawEllipse(pen, new RectangleF(-(int)Math.Round(x_axis / 2),
                                            -(int)Math.Round(y_axis / 2),
                                            x_axis,
                                            y_axis));
            g.ResetTransform();
        }

        private void rESETMEMORYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetSimulationMemory();
            this.Refresh();
        }

        private void dataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void groupbox_canvas_Enter_1(object sender, EventArgs e)
        {

        }

        private void viewedLevelHandler(object sender, EventArgs e)
        {
            viewed_level = (int)ViewedLayerNumber.Value;
            this.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            use_random_colors = (bool)useRandomColors.Checked;
            this.Refresh();
        }

        private void dropGaussians_CheckedChanged(object sender, EventArgs e)
        {
            drop_gaussians = (bool)dropGaussians.Checked;
            this.Refresh();
        }

        private void kmeansInit_CheckedChanged(object sender, EventArgs e)
        {
            kmeans_init = (bool)KmeansInit.Checked;
            this.Refresh();
        }
    }
}

