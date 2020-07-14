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
        List<Gaussian_2D> drawingGaussians = null;

        Color pt_drawing_color = Color.Black; //ToDo: use color to express GMM group memebership of points
        
        int num_of_points;
        int num_of_samples;
        int num_of_fits;
        int num_of_levels;
        int viewed_layer;
        bool fit_ran = false;
   
        GMM gmm;

        private void UpdateConfigurationUnputs()
        {
            num_of_points = (int)PointNumber.Value;
            num_of_samples = (int)SampleNumber.Value;
            num_of_fits = (int)FitNumber.Value;
            num_of_levels = (int)LayerNumber.Value;
            viewed_layer = (int)ViewedLayerNumber.Value;
            
        }

        private void UpdateConfigurationHandler(object sender, EventArgs e)
        {
            UpdateConfigurationUnputs();
        }

        private void ResetSimulationMemory()
        {
            gmm.pts = null;
            gmm.sample_gaussian_list = null;
            drawingGaussians = null;
            drawingPts = null;
            label_status.Text = "Memory cleared at " + DateTime.Now;
        }

        private void regenerateRandomDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawingPts = gmm.GenerateRandomPoints(num_of_points, groupbox_canvas.Width, groupbox_canvas.Height);
            fit_ran = false;
            label_status.Text = "Generated " + num_of_points + " new points at " + DateTime.Now;
            this.Refresh();
        }

        private void fitGMMsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (drawingGaussians, drawingPts) = gmm.FitGaussians(num_of_fits, num_of_levels);
            fit_ran = true;
            label_status.Text = "Fit " + num_of_fits + " Gaussians (flat). " + DateTime.Now;
            this.Refresh();
        }

        private void generateDummyGaussianDataToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            drawingPts = gmm.GenerateGaussianPoints(num_of_points, num_of_samples);
            fit_ran = false;
            label_status.Text = "Generated " + num_of_points + " new points at " + DateTime.Now;
            this.Refresh();
        }

        private void drawDummyGaussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawingGaussians = gmm.DrawDummyGaussian();
            label_status.Text = "Fit Dummy Gaussian (flat). " + DateTime.Now;
            this.Refresh();
        }

        private void groupbox_canvans_Paint(object sender, PaintEventArgs e)
        {
            Random random_color = new Random();
            ColorList ellipse_colors = new ColorList();
            Color ellipse_color = ellipse_colors.NextColor();
            List<Color> point_colors = new List<Color>();
            int point_color_index;

            Graphics g = e.Graphics;

            if (drawingPts != null)
            {
                SolidBrush defaultBrush = new SolidBrush(pt_drawing_color);
                
                if (viewed_layer <= drawingPts[0].gaussian_idx.Count && fit_ran)
                {
                    for(int parent_count = 0; parent_count < (int)Math.Pow(num_of_fits, viewed_layer); parent_count++)
                    {
                        point_colors.Add(Color.FromArgb(random_color.Next(200, 256), random_color.Next(190), random_color.Next(190)));
                    }

                    int cumulative = 0;
                    if (viewed_layer > 1)
                    {
                        for (int layer = 1; layer < viewed_layer; layer++)
                        {
                            cumulative += (int)Math.Pow(num_of_fits, layer);
                        }
                    }
                    else cumulative = 1;

                    foreach (Vector2 pt in drawingPts)
                    {
                        if (viewed_layer == 1)
                        {
                            point_color_index = pt.gaussian_idx[0];
                        }
                        else
                        {
                            point_color_index = pt.gaussian_idx[viewed_layer-1] - cumulative;
                        }
                        //if (viewed_layer == 2 && pt.gaussian_idx[viewed_layer - 1] < num_of_fits)
                        //{
                        //    Vector2 point = pt;
                        //}
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
                    Draw3SigmaEllipse(g, gaussian, ellipse_pen);
                    gaussian_count++;
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
            UpdateConfigurationUnputs();
            this.Refresh();
        }
    }
}

