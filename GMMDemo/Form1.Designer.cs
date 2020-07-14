namespace GMMDemo
{
    partial class GMMDemoWnd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label_status = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regenerateRandomDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateDummyGaussianDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawDummyGaussianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitGMMsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitHGMsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rESETMEMORYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupbox_canvas = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PointNumber = new System.Windows.Forms.NumericUpDown();
            this.LayerNumber = new System.Windows.Forms.NumericUpDown();
            this.SampleNumber = new System.Windows.Forms.NumericUpDown();
            this.FitNumber = new System.Windows.Forms.NumericUpDown();
            this.HierarchicalLayers = new System.Windows.Forms.Label();
            this.GaussiansPerLevel = new System.Windows.Forms.Label();
            this.GaussianSamples = new System.Windows.Forms.Label();
            this.generatedPoints = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupbox_canvas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PointNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayerNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SampleNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FitNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(22, 856);
            this.label_status.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(76, 21);
            this.label_status.TabIndex = 0;
            this.label_status.Text = "label1";
            this.label_status.Click += new System.EventHandler(this.label_status_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(11, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1894, 38);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.regenerateRandomDataToolStripMenuItem,
            this.generateDummyGaussianDataToolStripMenuItem,
            this.drawDummyGaussianToolStripMenuItem,
            this.fitGMMsToolStripMenuItem,
            this.fitHGMsToolStripMenuItem,
            this.rESETMEMORYToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(147, 32);
            this.dataToolStripMenuItem.Text = "Data Points";
            this.dataToolStripMenuItem.Click += new System.EventHandler(this.dataToolStripMenuItem_Click);
            // 
            // regenerateRandomDataToolStripMenuItem
            // 
            this.regenerateRandomDataToolStripMenuItem.Name = "regenerateRandomDataToolStripMenuItem";
            this.regenerateRandomDataToolStripMenuItem.Size = new System.Drawing.Size(422, 40);
            this.regenerateRandomDataToolStripMenuItem.Text = "Generate Random Data";
            this.regenerateRandomDataToolStripMenuItem.Click += new System.EventHandler(this.regenerateRandomDataToolStripMenuItem_Click);
            // 
            // generateDummyGaussianDataToolStripMenuItem
            // 
            this.generateDummyGaussianDataToolStripMenuItem.Name = "generateDummyGaussianDataToolStripMenuItem";
            this.generateDummyGaussianDataToolStripMenuItem.Size = new System.Drawing.Size(422, 40);
            this.generateDummyGaussianDataToolStripMenuItem.Text = "Generate Gaussian Data";
            this.generateDummyGaussianDataToolStripMenuItem.Click += new System.EventHandler(this.generateDummyGaussianDataToolStripMenuItem_Click_1);
            // 
            // drawDummyGaussianToolStripMenuItem
            // 
            this.drawDummyGaussianToolStripMenuItem.Name = "drawDummyGaussianToolStripMenuItem";
            this.drawDummyGaussianToolStripMenuItem.Size = new System.Drawing.Size(422, 40);
            this.drawDummyGaussianToolStripMenuItem.Text = "Draw Gaussian Ground Truth";
            this.drawDummyGaussianToolStripMenuItem.Click += new System.EventHandler(this.drawDummyGaussianToolStripMenuItem_Click);
            // 
            // fitGMMsToolStripMenuItem
            // 
            this.fitGMMsToolStripMenuItem.Name = "fitGMMsToolStripMenuItem";
            this.fitGMMsToolStripMenuItem.Size = new System.Drawing.Size(422, 40);
            this.fitGMMsToolStripMenuItem.Text = "Fit Flat GMMs ";
            this.fitGMMsToolStripMenuItem.Click += new System.EventHandler(this.fitGMMsToolStripMenuItem_Click);
            // 
            // fitHGMsToolStripMenuItem
            // 
            this.fitHGMsToolStripMenuItem.Name = "fitHGMsToolStripMenuItem";
            this.fitHGMsToolStripMenuItem.Size = new System.Drawing.Size(422, 40);
            this.fitHGMsToolStripMenuItem.Text = "Fit HGMMs";
            this.fitHGMsToolStripMenuItem.Click += new System.EventHandler(this.fitHGMsToolStripMenuItem_Click);
            // 
            // rESETMEMORYToolStripMenuItem
            // 
            this.rESETMEMORYToolStripMenuItem.Name = "rESETMEMORYToolStripMenuItem";
            this.rESETMEMORYToolStripMenuItem.Size = new System.Drawing.Size(422, 40);
            this.rESETMEMORYToolStripMenuItem.Text = "RESET MEMORY";
            this.rESETMEMORYToolStripMenuItem.Click += new System.EventHandler(this.rESETMEMORYToolStripMenuItem_Click);
            // 
            // groupbox_canvas
            // 
            this.groupbox_canvas.Controls.Add(this.label5);
            this.groupbox_canvas.Controls.Add(this.PointNumber);
            this.groupbox_canvas.Controls.Add(this.LayerNumber);
            this.groupbox_canvas.Controls.Add(this.SampleNumber);
            this.groupbox_canvas.Controls.Add(this.FitNumber);
            this.groupbox_canvas.Controls.Add(this.HierarchicalLayers);
            this.groupbox_canvas.Controls.Add(this.GaussiansPerLevel);
            this.groupbox_canvas.Controls.Add(this.GaussianSamples);
            this.groupbox_canvas.Controls.Add(this.generatedPoints);
            this.groupbox_canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupbox_canvas.Location = new System.Drawing.Point(0, 0);
            this.groupbox_canvas.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.groupbox_canvas.Name = "groupbox_canvas";
            this.groupbox_canvas.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.groupbox_canvas.Size = new System.Drawing.Size(1894, 887);
            this.groupbox_canvas.TabIndex = 2;
            this.groupbox_canvas.TabStop = false;
            this.groupbox_canvas.Text = "Data Plot";
            this.groupbox_canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.groupbox_canvans_Paint);
            this.groupbox_canvas.Enter += new System.EventHandler(this.groupbox_canvas_Enter_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1740, 685);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "Configuration";
            // 
            // PointNumber
            // 
            this.PointNumber.Location = new System.Drawing.Point(1745, 730);
            this.PointNumber.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.PointNumber.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.PointNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PointNumber.Name = "PointNumber";
            this.PointNumber.Size = new System.Drawing.Size(149, 31);
            this.PointNumber.TabIndex = 8;
            this.PointNumber.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.PointNumber.ValueChanged += new System.EventHandler(this.PointNumber_ValueChanged);
            this.PointNumber.Enter += new System.EventHandler(this.PointNumber_ValueChanged);
            // 
            // LayerNumber
            // 
            this.LayerNumber.Location = new System.Drawing.Point(1745, 856);
            this.LayerNumber.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.LayerNumber.Name = "LayerNumber";
            this.LayerNumber.Size = new System.Drawing.Size(149, 31);
            this.LayerNumber.TabIndex = 7;
            this.LayerNumber.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.LayerNumber.ValueChanged += new System.EventHandler(this.LayerNumber_ValueChanged);
            this.LayerNumber.Enter += new System.EventHandler(this.LayerNumber_ValueChanged);
            // 
            // SampleNumber
            // 
            this.SampleNumber.Location = new System.Drawing.Point(1745, 772);
            this.SampleNumber.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.SampleNumber.Name = "SampleNumber";
            this.SampleNumber.Size = new System.Drawing.Size(149, 31);
            this.SampleNumber.TabIndex = 6;
            this.SampleNumber.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.SampleNumber.ValueChanged += new System.EventHandler(this.SampleNumber_ValueChanged);
            this.SampleNumber.Enter += new System.EventHandler(this.SampleNumber_ValueChanged);
            // 
            // FitNumber
            // 
            this.FitNumber.Location = new System.Drawing.Point(1745, 814);
            this.FitNumber.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.FitNumber.Name = "FitNumber";
            this.FitNumber.Size = new System.Drawing.Size(149, 31);
            this.FitNumber.TabIndex = 5;
            this.FitNumber.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.FitNumber.ValueChanged += new System.EventHandler(this.FitNumber_ValueChanged);
            this.FitNumber.Enter += new System.EventHandler(this.FitNumber_ValueChanged);
            // 
            // HierarchicalLayers
            // 
            this.HierarchicalLayers.AutoSize = true;
            this.HierarchicalLayers.Location = new System.Drawing.Point(1573, 861);
            this.HierarchicalLayers.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.HierarchicalLayers.Name = "HierarchicalLayers";
            this.HierarchicalLayers.Size = new System.Drawing.Size(197, 21);
            this.HierarchicalLayers.TabIndex = 3;
            this.HierarchicalLayers.Text = "Hierchical Layers";
            this.HierarchicalLayers.Click += new System.EventHandler(this.label4_Click);
            // 
            // GaussiansPerLevel
            // 
            this.GaussiansPerLevel.AutoSize = true;
            this.GaussiansPerLevel.Location = new System.Drawing.Point(1544, 817);
            this.GaussiansPerLevel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.GaussiansPerLevel.Name = "GaussiansPerLevel";
            this.GaussiansPerLevel.Size = new System.Drawing.Size(219, 21);
            this.GaussiansPerLevel.TabIndex = 2;
            this.GaussiansPerLevel.Text = "Gaussians Per Level";
            // 
            // GaussianSamples
            // 
            this.GaussianSamples.AutoSize = true;
            this.GaussianSamples.Location = new System.Drawing.Point(1562, 775);
            this.GaussianSamples.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.GaussianSamples.Name = "GaussianSamples";
            this.GaussianSamples.Size = new System.Drawing.Size(186, 21);
            this.GaussianSamples.TabIndex = 1;
            this.GaussianSamples.Text = "Gaussian Samples";
            // 
            // generatedPoints
            // 
            this.generatedPoints.AutoSize = true;
            this.generatedPoints.Location = new System.Drawing.Point(1566, 741);
            this.generatedPoints.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.generatedPoints.Name = "generatedPoints";
            this.generatedPoints.Size = new System.Drawing.Size(197, 21);
            this.generatedPoints.TabIndex = 0;
            this.generatedPoints.Text = "Generated  Points";
            this.generatedPoints.Click += new System.EventHandler(this.label1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // GMMDemoWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1894, 887);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupbox_canvas);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "GMMDemoWnd";
            this.Text = "GMMDemo";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupbox_canvas.ResumeLayout(false);
            this.groupbox_canvas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PointNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayerNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SampleNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FitNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regenerateRandomDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitGMMsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitHGMsToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupbox_canvas;
        private System.Windows.Forms.ToolStripMenuItem generateDummyGaussianDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawDummyGaussianToolStripMenuItem;
        private System.Windows.Forms.Label generatedPoints;
        private System.Windows.Forms.Label HierarchicalLayers;
        private System.Windows.Forms.Label GaussiansPerLevel;
        private System.Windows.Forms.Label GaussianSamples;
        private System.Windows.Forms.NumericUpDown LayerNumber;
        private System.Windows.Forms.NumericUpDown SampleNumber;
        private System.Windows.Forms.NumericUpDown FitNumber;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown PointNumber;
        private System.Windows.Forms.ToolStripMenuItem rESETMEMORYToolStripMenuItem;
    }
}

