﻿using System;
using System.IO;
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
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            gmm = new GMM();
            label_status.Text = "Welcome to GMM demo!"; // use this control to display a line of text.
        }

        List<Vector2> drawingPts = new List<Vector2>();
        List<Vector2> drawingLargeCircles = new List<Vector2>();
        List<Gaussian_2D> drawingGaussians = new List<Gaussian_2D>();
        List<Gaussian_2D> groundTruthGaussians = new List<Gaussian_2D>();
        List<Polygon> drawingPolygons = new List<Polygon>();

        Color pt_drawing_color = Color.Red;
        Color ground_truth_color = Color.Blue;
        Color polygon_color = Color.LightBlue;
        Color circle_color = Color.Purple;
        Color unselected_gaussian = Color.Black;
        Color selected_gaussian = Color.Orange;


        int drawing_size_x = 2;
        int drawing_size_y = 2;

        int num_of_points;
        int num_of_samples;
        int num_of_fits;
        int num_of_levels;
        int viewed_level;
        int init_method = 0;

        float line_res;
        float circle_res;

        bool show_points;
        bool show_fits;
        bool fit_ran = false;
        bool use_random_colors;
        int selected_gaussian_idx;

        bool manual_mode = false;
        bool manual_gmm_initialized = false;
        int manual_level = 0;
        Vector2 mouse_position = new Vector2(0, 0);

        GMM gmm;

        private void UpdateConfigurationUnputs()
        {
            num_of_points = (int)PointNumber.Value;
            num_of_samples = (int)SampleNumber.Value;
            num_of_fits = (int)FitNumber.Value;
            num_of_levels = (int)LayerNumber.Value;
            viewed_level = (int)ViewedLayerNumber.Value;
            circle_res = (float)CircleResolution.Value;
            line_res = (float)LineResolution.Value;
            use_random_colors = (bool)useRandomColors.Checked;
            show_points = (bool)showPoints.Checked;
            show_fits = (bool)showFits.Checked;
            init_method = (int)InitializationSelectionBox.SelectedIndex;
            fit_ran = false;
        }

        private void UpdateConfigurationHandler(object sender, EventArgs e)
        {
            UpdateConfigurationUnputs();
        }

        private void ResetSimulationMemory()
        {
            
            UpdateConfigurationUnputs();

            gmm = new GMM();
            //gmm.ClearPoints();
            drawingGaussians.Clear();
            drawingPolygons.Clear();
            drawingPts.Clear();
            drawingLargeCircles.Clear();
            groundTruthGaussians.Clear();

            manual_mode = false;
            manual_gmm_initialized = false;
            manual_level = 0;
            fitMode.Text = "Auto";
            label_status.Text = "Memory cleared at " + DateTime.Now;
        }

        private void regenerateRandomDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateConfigurationUnputs();

            List<Vector2> pts;

            pts = RandomPoints.Generate(num_of_points, drawingCanvas.Width, drawingCanvas.Height);
            gmm.AddPoints(pts);
            drawingPts.AddRange(pts);

            label_status.Text = "Generated " + num_of_points + " new random points at " + DateTime.Now;
            this.Refresh();
        }

        private void generateDummyGaussianDataToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UpdateConfigurationUnputs();

            List<Vector2> pts;
            List<Gaussian_2D> gaussians;

            (pts, gaussians) = GaussianPoints.Generate(num_of_points, num_of_samples);
            gmm.AddPoints(pts);
            drawingPts.AddRange(pts);
            groundTruthGaussians.AddRange(gaussians);

            label_status.Text = "Generated " + num_of_points + " new gaussian points at " + DateTime.Now;
            this.Refresh();
        }

        private void generateLiDARDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateConfigurationUnputs();

            List<Vector2> pts;
            Vector2 Scanner_Position;

            pts = LidarPoints.Generate(drawing_size_x, drawing_size_y, out drawingPolygons, out Scanner_Position);
            gmm.AddPoints(pts);
            drawingPts.AddRange(pts);
            drawingLargeCircles = new List<Vector2>();
            drawingLargeCircles.Add(Scanner_Position);

            label_status.Text = "Generated simulated 2D lidar data";
            this.Refresh();
        }

        private void drawDummyGaussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateConfigurationUnputs();
            drawingGaussians.AddRange(groundTruthGaussians);
            label_status.Text = "Displaying ground truth at " + DateTime.Now;
            this.Refresh();
        }

        private void CompleteColoring(Graphics g)
        {
            ColorSelector ellipse_colors = new ColorSelector();
            Color ellipse_color = ellipse_colors.NextColor();
           
            ColorPoints(g, viewed_level);

            foreach (BaseModel model in gmm.baseModels)
            {
                if (model == null)
                    continue;
                switch (model.GetType().ToString())
                {
                    case "GMMDemo.LineModel":
                        ColorLines(g, model);
                        break;
                    case "GMMDemo.CircleModel":
                        ColorCircles(g, model);
                        break;
                }
            }

            if (drawingGaussians.Count > 0 && show_fits)
            {
                if (!fit_ran)
                {
                    Pen ground_truth_pen = new Pen(ground_truth_color, 2);
                    foreach (Gaussian_2D gaussian in drawingGaussians)
                    {
                        if (!gaussian.dropped)
                        {
                            Draw3SigmaEllipse(g, gaussian, ground_truth_pen);
                        }
                    }
                }
                else
                {
                    Pen ellipse_pen = new Pen(ellipse_color, 2);
                    int gaussian_count = 0;
                    int layer_count = 1;
                    int cumulative_limit = num_of_fits;


                    List<int> level_gaussians = gmm.GetLevel(viewed_level - 1);

                    foreach (int i in level_gaussians)
                    {
                        if (gaussian_count >= cumulative_limit)
                        {
                            layer_count++;
                            ellipse_color = ellipse_colors.NextColor();
                            ellipse_pen = new Pen(ellipse_color, 2);
                            cumulative_limit += (int)Math.Pow(num_of_fits, layer_count);
                        }

                        if (!drawingGaussians[i].dropped)
                        {
                            Draw3SigmaEllipse(g, drawingGaussians[i], ellipse_pen);
                        }
                        gaussian_count++;
                    }
                }
            }
        }

        private void manualModeColoring(Graphics g)
        {
            ColorPoints(g, manual_level);

            foreach (BaseModel model in gmm.baseModels)
            {
                //if (model == null)
                //    continue;
                switch (model.GetType().ToString())
                {
                    case "GMMDemo.LineModel":
                        ColorLines(g, model);
                        break;
                    case "GMMDemo.CircleModel":
                        ColorCircles(g, model);
                        break;
                }
            }

            if (drawingGaussians.Count > 0)
            {
                Pen unselected = new Pen(unselected_gaussian, 2);
                Pen selected = new Pen(selected_gaussian, 2);

                List<int> level_gaussians = gmm.GetLevel(manual_level - 1);

                foreach (int i in level_gaussians)
                {
                    if (!drawingGaussians[i].dropped)
                    {
                        if (drawingGaussians[i].selected)
                        {
                            Draw3SigmaEllipse(g, drawingGaussians[i], selected);
                        }
                        else
                        {
                            Draw3SigmaEllipse(g, drawingGaussians[i], unselected);
                        }

                    }

                }
            }
        }

        private void ColorLines(Graphics g, BaseModel model)
        {
            Pen redPen = new Pen(Color.Red, 2);

            Point p1 = new Point((int)(model.Start.x), (int)(model.Start.y));
            Point p2 = new Point((int)(model.End.x), (int)(model.End.y));
            g.DrawLine(redPen, p1, p2);
        }

        private void ColorCircles(Graphics g, BaseModel model)
        {
            Pen bluePen = new Pen(Color.Blue, 2);
            float top_left_x = model.Center.x - model.R;
            float top_left_y = model.Center.y - model.R;
            float width = model.R * 2;

            g.DrawEllipse(bluePen, top_left_x, top_left_y, width, width);
        }

        private void ColorPoints(Graphics g, int currentLevel)
        {
            int point_color_index;
            Random random_color = new Random();
            ColorSelector point_color = new ColorSelector();
            List<Color> point_colors = new List<Color>();
            SolidBrush defaultPointBrush = new SolidBrush(pt_drawing_color);

            if (drawingPts.Count > 0 && drawingPts.Count > 0 && show_points)
            {
                if (viewed_level <= drawingPts[0].gaussian_idx.Count && fit_ran)
                {
                    // Creating a list of colors based on the number of gaussians present in a level. Each gaussian holds a cluster of points with a different color.
                    for (int parent_count = 0; parent_count < (int)Math.Pow(num_of_fits, currentLevel); parent_count++)
                    {
                        if (use_random_colors)
                        {
                            point_colors.Add(Color.FromArgb(random_color.Next(256), random_color.Next(256), random_color.Next(256)));
                        }
                        else
                        {
                            point_colors.Add(point_color.NextColor());
                        }
                    }

                    // cumulative stores a value used in indexing the gaussian_idx list in order to determine what color a point should be
                    int cumulative = 0;
                    if (currentLevel > 1)
                    {
                        for (int layer = 1; layer < currentLevel; layer++)
                        {
                            cumulative += (int)Math.Pow(num_of_fits, layer);
                        }
                    }
                    else cumulative = 0;

                    foreach (Vector2 pt in drawingPts)
                    {
                        if (pt.gaussian_idx[currentLevel - 1] == -1) // A point will have this value if the parent gaussian at the viewed level is dropped
                        {
                            SolidBrush brush = new SolidBrush(Color.Black);
                            g.FillRectangle(brush, pt.x - 1, pt.y - 1, 3, 3); //a 9 pixel dot
                        }
                        else
                        {
                            if (currentLevel == 1)
                            {
                                point_color_index = pt.gaussian_idx[0];
                            }
                            else
                            {
                                int check = pt.gaussian_idx[0];
                                point_color_index = pt.gaussian_idx[currentLevel - 1] - cumulative;
                            }
                            SolidBrush brush = new SolidBrush(point_colors[point_color_index]);
                            g.FillRectangle(brush, pt.x - 1, pt.y - 1, 3, 3); //a 9 pixel dot
                        }
                    }
                }
                else
                {
                    foreach (Vector2 pt in drawingPts)
                    {
                        g.FillRectangle(defaultPointBrush, pt.x - 1, pt.y - 1, 3, 3); //a 9 pixel dot
                    }
                }
            }
        }

        private void drawDummyLidarAssets(Graphics g)
        {
            //draw the polygon first, which will be the background of everything else
            if (drawingPolygons.Count > 0)
            {
                SolidBrush polygonbrush = new SolidBrush(polygon_color);
                foreach (Polygon poly in drawingPolygons)
                {
                    g.FillPolygon(polygonbrush, poly.pts);
                }
            }
            //draw the large circles
            if (drawingLargeCircles.Count > 0)
            {
                SolidBrush circleBrush = new SolidBrush(circle_color);
                foreach (Vector2 vec in drawingLargeCircles)
                {
                    g.FillEllipse(circleBrush, new Rectangle((int)(vec.x - 10), (int)(vec.y - 10), 20, 20));
                }
            }
        }

        private void Draw3SigmaEllipse(Graphics g, Gaussian_2D gaussian, Pen pen)
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

        private void drawingCanvasPaint(object sender, PaintEventArgs e)
        {
            drawing_size_x = e.ClipRectangle.Width;
            drawing_size_y = e.ClipRectangle.Height;
            Graphics g = drawingCanvas.CreateGraphics();

            drawDummyLidarAssets(g);

            if (!manual_mode)
            {
                CompleteColoring(g);
            }
            else if(manual_mode){
                manualModeColoring(g);
            }
         
            
        }
        /// How to draw the 3-sigma error ellipse of a given 2D Gaussian?
        /// https://math.stackexchange.com/questions/395698/fast-way-to-calculate-eigen-of-2x2-matrix-using-a-formula
        /// https://www.visiondummy.com/2014/04/draw-error-ellipse-representing-covariance-matrix/
        /// http://people.math.harvard.edu/~knill/teaching/math21b2004/exhibits/2dmatrices/index.html
        
        private void rESETMEMORYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetSimulationMemory();
            this.Refresh();
        }

        private void dataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewedLevelHandler(object sender, EventArgs e)
        {
            viewed_level = (int)ViewedLayerNumber.Value;
            this.Refresh();
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            use_random_colors = (bool)useRandomColors.Checked;
            this.Refresh();
        }

        private void load2DLIDARScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetSimulationMemory();
            label_status.Text = "Loading 2D scan.";
            this.Refresh();
            // This method of getting to the scans directory might break in 
            string cwd = Directory.GetCurrentDirectory();
            string parentPath = Path.GetFullPath(Path.Combine(cwd, @"..\..\..\"));
            string defaultImportPath = Path.Combine(parentPath, "2d_slices");
            sliceImporter2D.InitialDirectory = defaultImportPath;
            sliceImporter2D.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            List<Vector2> pts = new List<Vector2>();

            if (sliceImporter2D.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                var pointsFile = sliceImporter2D.FileName;
                
                List<String> lines = File.ReadAllLines(pointsFile).ToList();

                pts = Scan2D.Import(num_of_points, lines, drawingCanvas.Width, drawingCanvas.Height);
                gmm.AddPoints(pts);
                drawingPts.AddRange(pts);
            }
            if(pts.Count < num_of_points)
            {
                label_status.Text = "Loaded original 2D Scan with " + drawingPts.Count + " available points after rescaling at" + DateTime.Now;
            }
            else
            {
                label_status.Text = "Loaded subsampled 2D Scan with " + num_of_points + " points after rescaling at " + DateTime.Now;
            }
            this.Refresh();
        }
        
        private void showPoints_CheckedChanged(object sender, EventArgs e)
        {
            show_points = (bool)showPoints.Checked;
            this.Refresh();
        }

        private void showFits_CheckedChanged(object sender, EventArgs e)
        {
            show_fits = (bool)showFits.Checked;
            this.Refresh();
        }

        private void fitGMMsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateConfigurationUnputs();
            label_status.Text = "Calculating... ";
            drawingGaussians.Clear();
            this.Refresh();
            DateTime time_start = DateTime.Now;
            (drawingGaussians, drawingPts) = gmm.FitGaussians(num_of_fits, num_of_levels, init_method);
            DateTime time_end = DateTime.Now;

            fit_ran = true;
            label_status.Text = "Done in " + time_end.Subtract(time_start).TotalSeconds.ToString() + " seconds at " + DateTime.Now;
            this.Refresh();
        }

        private void manualFitButton_Click(object sender, EventArgs e)
        {
            label_status.Text = "Fitting level " + (manual_level+1) + "...";
            this.Refresh(); // This refresh has to come before manual_level is incremented or else the point coloring function will break.

            if (!manual_gmm_initialized)
            {
                manual_mode = true;
                manual_level = 1;
                fitMode.Text = "Manual";

                drawingGaussians.Clear();

                gmm.Init();
                manual_gmm_initialized = true;
                fit_ran = false;
            }
            else
            {
                // Since gaussians are initialized to partition=true at creation, we must check the 
                // selected state of each gaussian and set partition accordingly after level 1.
                bool anySelected = false; // Checking if the user selected at least one gaussian to partition
                List<int> level_gaussians = gmm.GetLevel(manual_level - 1);

                foreach (int i in level_gaussians)
                {
                    if (gmm.gaussian_list[i].selected)
                    {
                        gmm.gaussian_list[i].partition = true;
                        anySelected = true;
                    }
                    else
                    {
                        gmm.gaussian_list[i].partition = false;
                    }
                }
                if (!anySelected)
                {
                    label_status.Text = "No gaussians selected at level " + manual_level + ". Finalizing GMM.";

                    finalizGMM(); 
                    
                    return;
                }
                manual_level++;
            }

            DateTime time_start = DateTime.Now;

            (drawingGaussians, drawingPts) = gmm.FitGaussiansManual(num_of_fits, manual_level-1, init_method);

            // TODO: deep copy of gmm.gaussian_list
            //List<Gaussian_2D> drawingGaussians_temp;
            //List<Vector2> drawingPts_temp;
            //drawingGaussians = new List<Gaussian_2D>(drawingGaussians_temp.Count);
            //drawingGaussians_temp.CopyTo(drawingGaussians);
            //drawingPts = drawingPts_temp.ToList();

            fit_ran = true;
            DateTime time_end = DateTime.Now;

            label_status.Text = "Level " + manual_level + " done in " + time_end.Subtract(time_start).TotalSeconds.ToString() + " seconds at " + DateTime.Now;
            this.Refresh();
        }

        private void formClickDetect(object sender, MouseEventArgs e)
        {
            

            if (manual_mode && gmm.gaussian_list.Count > 0)
            {
                //Get mouse position
                mouse_position.x = e.Location.X;
                mouse_position.y = e.Location.Y;

                List<int> level_gaussians = gmm.GetLevel(manual_level - 1);

                //Find non-placeholder gaussian with shortest mean distance to mouse.
                float minDistance = 1000000000000000; // Large number so that mouse is always closer to at least one gaussian
                foreach (int i in level_gaussians)
                {
                    if (!gmm.gaussian_list[i].dropped)
                    {
                        
                        float distance = (float)Math.Sqrt(gmm.gaussian_list[i].miu.distancesquare(mouse_position));
                        if(distance < minDistance)
                        {
                            minDistance = distance;
                            selected_gaussian_idx = i;
                        }
                    }
                }

                switch (e.Button)
                {
                    case MouseButtons.Left:
                        if (gmm.gaussian_list[selected_gaussian_idx].selected)
                        {
                            gmm.gaussian_list[selected_gaussian_idx].selected = false;
                        }
                        else
                        {
                            gmm.gaussian_list[selected_gaussian_idx].selected = true;
                        }
                        drawingGaussians = gmm.gaussian_list;

                        this.Refresh();

                        break;

                    case MouseButtons.Right:
                        Point pt = new Point(e.Location.X, e.Location.Y);
                        contextMenuStrip1.Show(drawingCanvas, pt);
                        break;
                }
            }
        }

        private void finalizGMM()
        {
            manual_mode = false;
            fitMode.Text = "Auto";
            manual_gmm_initialized = false;
            fit_ran = true;

            gmm.DetectLastLevel(manual_level);
            manual_level = 0;

            this.Refresh();
        }

        private void finalizeManualGMM_Click(object sender, EventArgs e)
        {
            finalizGMM();
        }

        private void SelectAllGaussiansButton_Click(object sender, EventArgs e)
        {
            List<int> level_gaussians = gmm.GetLevel(manual_level - 1);

            foreach (int i in level_gaussians)
            {
                if (!gmm.gaussian_list[i].dropped)
                {
                    gmm.gaussian_list[i].selected = true;
                }
            }
            this.Refresh();
        }

        private void InitializationSelectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_method = (int)InitializationSelectionBox.SelectedIndex;
            this.Refresh();
        }

        private void fitLineToolStripMenuItem_Click(object sender, EventArgs e)
        {

            List<Vector2> gaussian_i_pts = new List<Vector2>();

            foreach (Vector2 pt in gmm.pts)
            {
                if (pt.gaussian_idx[manual_level - 1] == selected_gaussian_idx)
                    gaussian_i_pts.Add(pt);
            }

            if (gaussian_i_pts.Count < 2)
                return;

            BaseModel lineModel = new LineModel();
            lineModel = RANSAC.Fit(gaussian_i_pts, lineModel, 2, line_res);
            gmm.baseModels.Add(lineModel);

            drawingGaussians[selected_gaussian_idx].dropped = true;
            drawingGaussians[selected_gaussian_idx].selected = false;
            gmm.gaussian_list[selected_gaussian_idx].dropped = true;
            gmm.gaussian_list[selected_gaussian_idx].selected = false;

            this.Refresh();
            // TODO: deep copy of gmm.gaussian_list
            //gmm.gaussian_list[selected_gaussian_idx].dropped = false;
        }

        private void fitCircleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            List<Vector2> gaussian_i_pts = new List<Vector2>();

            foreach (Vector2 pt in gmm.pts)
            {
                if (pt.gaussian_idx[manual_level - 1] == selected_gaussian_idx)
                    gaussian_i_pts.Add(pt);
            }

            if (gaussian_i_pts.Count < 3)
                return;
            
            BaseModel circleModel = new CircleModel();
            circleModel = RANSAC.Fit(gaussian_i_pts, circleModel, 3, circle_res);
            gmm.baseModels.Add(circleModel);

            drawingGaussians[selected_gaussian_idx].dropped = true;
            drawingGaussians[selected_gaussian_idx].selected = false;
            gmm.gaussian_list[selected_gaussian_idx].dropped = true;
            gmm.gaussian_list[selected_gaussian_idx].selected = false;

            this.Refresh();
            // TODO: deep copy of gmm.gaussian_list
            //gmm.gaussian_list[selected_gaussian_idx].dropped = false;
        }

        private void ignoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawingGaussians[selected_gaussian_idx].dropped = true;
            drawingGaussians[selected_gaussian_idx].selected = false;
            gmm.gaussian_list[selected_gaussian_idx].dropped = true;
            gmm.gaussian_list[selected_gaussian_idx].selected = false;
            this.Refresh();
            // TODO: deep copy of gmm.gaussian_list
            //gmm.gaussian_list[selected_gaussian_idx].dropped = false;
        }
    }
}