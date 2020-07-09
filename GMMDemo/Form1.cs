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

        List<Point> drawingPts;
        List<Gaussian_2D> drawingGaussians;

        Color pt_drawing_color = Color.Red; //ToDo: use color to express GMM group memebership of points
        Color ellipse_drawing_color = Color.Blue;
        Color miu_color = Color.Green;

        int num_of_points = 20000;//todo: have an interface to adjust how many points we place?

        GMM gmm;

        private void regenerateRandomDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Vector2> geometry_pts = gmm.GenerateRandomPoints(num_of_points, groupbox_canvas.Width, groupbox_canvas.Height);
            drawingPts = new List<Point>();
            for (int i = 0; i < geometry_pts.Count; ++ i)
            {
                drawingPts.Add(new Point((int)geometry_pts[i].x, (int)geometry_pts[i].y));
            }
            label_status.Text = "Generated " + num_of_points + " new points at " + DateTime.Now;
            this.Refresh();
        }


        private void fit4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawingGaussians = gmm.Fit4Gaussians();
            label_status.Text = "Fit 4 Gaussians (flat). " + DateTime.Now;
            this.Refresh();
        }

        private void fit8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawingGaussians = gmm.Fit8Gaussians();
            label_status.Text = "Fit 8 Gaussians (flat). " + DateTime.Now;
            this.Refresh();
        }

        private void fitHGMsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawingGaussians = gmm.FitHierarchyGaussians();
            label_status.Text = "Fit HGM . " + DateTime.Now;
            this.Refresh();
        }

        private void groupbox_canvans_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (drawingPts != null)
            {
                SolidBrush brush = new SolidBrush(pt_drawing_color);
                foreach (Point pt in drawingPts)
                {
                    g.FillRectangle(brush, pt.X-1, pt.Y-1, 3, 3); //a 9 pixel dot
                }
            }
            if (drawingGaussians != null)
            {
                Pen ellipse_pen = new Pen(ellipse_drawing_color, 2);
                foreach (Gaussian_2D gaussian in drawingGaussians)
                {
                    Draw3SigmaEllipse(g, gaussian, ellipse_pen);
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
            float axis_x = 0;
            float axis_y = 0;
            if (gaussian.Sigma.m00 > gaussian.Sigma.m11)
            {
                if (gaussian.Sigma.eigenvalue_0 >= 0)
                {
                    axis_x = (float)(2 * Math.Sqrt(5.991f * gaussian.Sigma.eigenvalue_0));
                }
                if (gaussian.Sigma.eigenvalue_1 >= 0)
                {
                    axis_y = (float)(2 * Math.Sqrt(5.991f * gaussian.Sigma.eigenvalue_1));
                }
            }
            else
            {
                if (gaussian.Sigma.eigenvalue_0 >= 0)
                {
                    axis_y = (float)(2 * Math.Sqrt(5.991f * gaussian.Sigma.eigenvalue_0));
                }
                if (gaussian.Sigma.eigenvalue_1 >= 0)
                {
                    axis_x = (float)(2 * Math.Sqrt(5.991f * gaussian.Sigma.eigenvalue_1));
                }
            }
            
            double angle;
            if (gaussian.Sigma.eigenvalue_0 > gaussian.Sigma.eigenvalue_1) 
            {
                angle = Math.Atan2(gaussian.Sigma.eigenvector_0.y, gaussian.Sigma.eigenvector_0.x);
            }
            else
            {
                angle = Math.Atan2(gaussian.Sigma.eigenvector_1.y, gaussian.Sigma.eigenvector_1.x);
            }
            Console.WriteLine("Ellipse angle");
            Console.WriteLine(angle * 180 / Math.PI);
            //angle = 0;

            g.TranslateTransform(gaussian.miu.x, gaussian.miu.y);
            g.RotateTransform((float)(angle * 180 / Math.PI)); //Rad to Deg
            g.DrawEllipse(pen, new RectangleF(-(int)Math.Round(axis_x / 2),
                                            -(int)Math.Round(axis_y / 2),
                                            axis_x,
                                            axis_y));
            g.ResetTransform();
        }
        
        private void fitGMMsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void generateDummyGaussianDataToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void mixtureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Vector2> geometry_pts = gmm.GenerateDummyGaussianPoints(num_of_points, groupbox_canvas.Width, groupbox_canvas.Height);
            drawingPts = new List<Point>();
            for (int i = 0; i < geometry_pts.Count; ++i)
            {
                if (geometry_pts[i].x >= 0 && geometry_pts[i].x <= groupbox_canvas.Width && geometry_pts[i].y >= 0 && geometry_pts[i].y <= groupbox_canvas.Height)
                {
                    drawingPts.Add(new Point((int)geometry_pts[i].x, (int)geometry_pts[i].y));
                }
          
            }
            label_status.Text = "Generated " + num_of_points + " new points at " + DateTime.Now;
            this.Refresh();
        }

        private void mixtureToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void groupbox_canvas_Enter(object sender, EventArgs e)
        {

        }

        private void drawDummyGaussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawingGaussians = gmm.DrawDummyGaussian();
            label_status.Text = "Fit Dummy Gaussian (flat). " + DateTime.Now;
            this.Refresh();
        }
    }
}
