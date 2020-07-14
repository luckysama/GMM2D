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
            this.rESETMEMORYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupbox_canvas = new System.Windows.Forms.GroupBox();
            this.ViewedLayerNumber = new System.Windows.Forms.NumericUpDown();
            this.ViewedLayer = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.ViewedLayerNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PointNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayerNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SampleNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FitNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(6, 563);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(35, 13);
            this.label_status.TabIndex = 0;
            this.label_status.Text = "label1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1033, 24);
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
            this.rESETMEMORYToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.dataToolStripMenuItem.Text = "Data Points";
            this.dataToolStripMenuItem.Click += new System.EventHandler(this.dataToolStripMenuItem_Click);
            // 
            // regenerateRandomDataToolStripMenuItem
            // 
            this.regenerateRandomDataToolStripMenuItem.Name = "regenerateRandomDataToolStripMenuItem";
            this.regenerateRandomDataToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.regenerateRandomDataToolStripMenuItem.Text = "Generate Random Data";
            this.regenerateRandomDataToolStripMenuItem.Click += new System.EventHandler(this.regenerateRandomDataToolStripMenuItem_Click);
            // 
            // generateDummyGaussianDataToolStripMenuItem
            // 
            this.generateDummyGaussianDataToolStripMenuItem.Name = "generateDummyGaussianDataToolStripMenuItem";
            this.generateDummyGaussianDataToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.generateDummyGaussianDataToolStripMenuItem.Text = "Generate Gaussian Data";
            this.generateDummyGaussianDataToolStripMenuItem.Click += new System.EventHandler(this.generateDummyGaussianDataToolStripMenuItem_Click_1);
            // 
            // drawDummyGaussianToolStripMenuItem
            // 
            this.drawDummyGaussianToolStripMenuItem.Name = "drawDummyGaussianToolStripMenuItem";
            this.drawDummyGaussianToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.drawDummyGaussianToolStripMenuItem.Text = "Draw Gaussian Ground Truth";
            this.drawDummyGaussianToolStripMenuItem.Click += new System.EventHandler(this.drawDummyGaussianToolStripMenuItem_Click);
            // 
            // fitGMMsToolStripMenuItem
            // 
            this.fitGMMsToolStripMenuItem.Name = "fitGMMsToolStripMenuItem";
            this.fitGMMsToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.fitGMMsToolStripMenuItem.Text = "Fit GMMs";
            this.fitGMMsToolStripMenuItem.Click += new System.EventHandler(this.fitGMMsToolStripMenuItem_Click);
            // 
            // rESETMEMORYToolStripMenuItem
            // 
            this.rESETMEMORYToolStripMenuItem.Name = "rESETMEMORYToolStripMenuItem";
            this.rESETMEMORYToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.rESETMEMORYToolStripMenuItem.Text = "RESET MEMORY";
            this.rESETMEMORYToolStripMenuItem.Click += new System.EventHandler(this.rESETMEMORYToolStripMenuItem_Click);
            // 
            // groupbox_canvas
            // 
            this.groupbox_canvas.Controls.Add(this.ViewedLayerNumber);
            this.groupbox_canvas.Controls.Add(this.label_status);
            this.groupbox_canvas.Controls.Add(this.ViewedLayer);
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
            this.groupbox_canvas.Name = "groupbox_canvas";
            this.groupbox_canvas.Size = new System.Drawing.Size(1033, 576);
            this.groupbox_canvas.TabIndex = 2;
            this.groupbox_canvas.TabStop = false;
            this.groupbox_canvas.Text = "Data Plot";
            this.groupbox_canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.groupbox_canvans_Paint);
            this.groupbox_canvas.Enter += new System.EventHandler(this.groupbox_canvas_Enter_1);
            // 
            // ViewedLayerNumber
            // 
            this.ViewedLayerNumber.Location = new System.Drawing.Point(952, 556);
            this.ViewedLayerNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ViewedLayerNumber.Name = "ViewedLayerNumber";
            this.ViewedLayerNumber.Size = new System.Drawing.Size(81, 20);
            this.ViewedLayerNumber.TabIndex = 11;
            this.ViewedLayerNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ViewedLayerNumber.ValueChanged += new System.EventHandler(this.viewedLevelHandler);
            this.ViewedLayerNumber.Enter += new System.EventHandler(this.viewedLevelHandler);
            // 
            // ViewedLayer
            // 
            this.ViewedLayer.AutoSize = true;
            this.ViewedLayer.Location = new System.Drawing.Point(876, 558);
            this.ViewedLayer.Name = "ViewedLayer";
            this.ViewedLayer.Size = new System.Drawing.Size(70, 13);
            this.ViewedLayer.TabIndex = 10;
            this.ViewedLayer.Text = "Current Layer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(949, 424);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Configuration";
            // 
            // PointNumber
            // 
            this.PointNumber.Location = new System.Drawing.Point(952, 452);
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
            this.PointNumber.Size = new System.Drawing.Size(81, 20);
            this.PointNumber.TabIndex = 8;
            this.PointNumber.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.PointNumber.ValueChanged += new System.EventHandler(this.UpdateConfigurationHandler);
            this.PointNumber.Enter += new System.EventHandler(this.UpdateConfigurationHandler);
            // 
            // LayerNumber
            // 
            this.LayerNumber.Location = new System.Drawing.Point(952, 530);
            this.LayerNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LayerNumber.Name = "LayerNumber";
            this.LayerNumber.Size = new System.Drawing.Size(81, 20);
            this.LayerNumber.TabIndex = 7;
            this.LayerNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LayerNumber.ValueChanged += new System.EventHandler(this.UpdateConfigurationHandler);
            this.LayerNumber.Enter += new System.EventHandler(this.UpdateConfigurationHandler);
            // 
            // SampleNumber
            // 
            this.SampleNumber.Location = new System.Drawing.Point(952, 478);
            this.SampleNumber.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.SampleNumber.Name = "SampleNumber";
            this.SampleNumber.Size = new System.Drawing.Size(81, 20);
            this.SampleNumber.TabIndex = 6;
            this.SampleNumber.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.SampleNumber.ValueChanged += new System.EventHandler(this.UpdateConfigurationHandler);
            this.SampleNumber.Enter += new System.EventHandler(this.UpdateConfigurationHandler);
            // 
            // FitNumber
            // 
            this.FitNumber.Location = new System.Drawing.Point(952, 504);
            this.FitNumber.Name = "FitNumber";
            this.FitNumber.Size = new System.Drawing.Size(81, 20);
            this.FitNumber.TabIndex = 5;
            this.FitNumber.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.FitNumber.ValueChanged += new System.EventHandler(this.UpdateConfigurationHandler);
            this.FitNumber.Enter += new System.EventHandler(this.UpdateConfigurationHandler);
            // 
            // HierarchicalLayers
            // 
            this.HierarchicalLayers.AutoSize = true;
            this.HierarchicalLayers.Location = new System.Drawing.Point(858, 533);
            this.HierarchicalLayers.Name = "HierarchicalLayers";
            this.HierarchicalLayers.Size = new System.Drawing.Size(88, 13);
            this.HierarchicalLayers.TabIndex = 3;
            this.HierarchicalLayers.Text = "Hierchical Layers";
            // 
            // GaussiansPerLevel
            // 
            this.GaussiansPerLevel.AutoSize = true;
            this.GaussiansPerLevel.Location = new System.Drawing.Point(842, 506);
            this.GaussiansPerLevel.Name = "GaussiansPerLevel";
            this.GaussiansPerLevel.Size = new System.Drawing.Size(104, 13);
            this.GaussiansPerLevel.TabIndex = 2;
            this.GaussiansPerLevel.Text = "Gaussians Per Level";
            // 
            // GaussianSamples
            // 
            this.GaussianSamples.AutoSize = true;
            this.GaussianSamples.Location = new System.Drawing.Point(852, 480);
            this.GaussianSamples.Name = "GaussianSamples";
            this.GaussianSamples.Size = new System.Drawing.Size(94, 13);
            this.GaussianSamples.TabIndex = 1;
            this.GaussianSamples.Text = "Gaussian Samples";
            // 
            // generatedPoints
            // 
            this.generatedPoints.AutoSize = true;
            this.generatedPoints.Location = new System.Drawing.Point(854, 459);
            this.generatedPoints.Name = "generatedPoints";
            this.generatedPoints.Size = new System.Drawing.Size(92, 13);
            this.generatedPoints.TabIndex = 0;
            this.generatedPoints.Text = "Generated  Points";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // GMMDemoWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 576);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupbox_canvas);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GMMDemoWnd";
            this.Text = "GMMDemo";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupbox_canvas.ResumeLayout(false);
            this.groupbox_canvas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ViewedLayerNumber)).EndInit();
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
        private System.Windows.Forms.NumericUpDown ViewedLayerNumber;
        private System.Windows.Forms.Label ViewedLayer;
    }
}

