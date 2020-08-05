﻿namespace GMMDemo
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
            this.fitGMMsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawDummyGaussianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateLiDARDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.load2DLIDARScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupbox_canvas = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.showPoints = new System.Windows.Forms.CheckBox();
            this.showFits = new System.Windows.Forms.CheckBox();
            this.KmeansInit = new System.Windows.Forms.CheckBox();
            this.dropGaussians = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.useRandomColors = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
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
            this.sliceImporter2D = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.menuStrip1.SuspendLayout();
            this.groupbox_canvas.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.label_status.Location = new System.Drawing.Point(6, 1021);
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
            this.menuStrip1.Size = new System.Drawing.Size(1904, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.regenerateRandomDataToolStripMenuItem,
            this.generateDummyGaussianDataToolStripMenuItem,
            this.fitGMMsToolStripMenuItem,
            this.drawDummyGaussianToolStripMenuItem,
            this.generateLiDARDataToolStripMenuItem,
            this.load2DLIDARScanToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.dataToolStripMenuItem.Text = "Menu";
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
            // fitGMMsToolStripMenuItem
            // 
            this.fitGMMsToolStripMenuItem.Name = "fitGMMsToolStripMenuItem";
            this.fitGMMsToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.fitGMMsToolStripMenuItem.Text = "Fit HGMM";
            this.fitGMMsToolStripMenuItem.Click += new System.EventHandler(this.fitGMMsToolStripMenuItem_Click);
            // 
            // drawDummyGaussianToolStripMenuItem
            // 
            this.drawDummyGaussianToolStripMenuItem.Name = "drawDummyGaussianToolStripMenuItem";
            this.drawDummyGaussianToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.drawDummyGaussianToolStripMenuItem.Text = "Draw Gaussian Ground Truth";
            this.drawDummyGaussianToolStripMenuItem.Click += new System.EventHandler(this.drawDummyGaussianToolStripMenuItem_Click);
            // 
            // generateLiDARDataToolStripMenuItem
            // 
            this.generateLiDARDataToolStripMenuItem.Name = "generateLiDARDataToolStripMenuItem";
            this.generateLiDARDataToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.generateLiDARDataToolStripMenuItem.Text = "Generate Fake LiDAR Data";
            this.generateLiDARDataToolStripMenuItem.Click += new System.EventHandler(this.generateLiDARDataToolStripMenuItem_Click);
            // 
            // load2DLIDARScanToolStripMenuItem
            // 
            this.load2DLIDARScanToolStripMenuItem.Name = "load2DLIDARScanToolStripMenuItem";
            this.load2DLIDARScanToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.load2DLIDARScanToolStripMenuItem.Text = "Load 2D LIDAR Scan";
            this.load2DLIDARScanToolStripMenuItem.Click += new System.EventHandler(this.load2DLIDARScanToolStripMenuItem_Click);
            // 
            // groupbox_canvas
            // 
            this.groupbox_canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupbox_canvas.Controls.Add(this.label_status);
            this.groupbox_canvas.Controls.Add(this.panel1);
            this.groupbox_canvas.Location = new System.Drawing.Point(0, 0);
            this.groupbox_canvas.Name = "groupbox_canvas";
            this.groupbox_canvas.Size = new System.Drawing.Size(1920, 1080);
            this.groupbox_canvas.TabIndex = 2;
            this.groupbox_canvas.TabStop = false;
            this.groupbox_canvas.Text = "Data Plot";
            this.groupbox_canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.groupbox_canvans_Paint);
            this.groupbox_canvas.Enter += new System.EventHandler(this.groupbox_canvas_Enter_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.showPoints);
            this.panel1.Controls.Add(this.showFits);
            this.panel1.Controls.Add(this.KmeansInit);
            this.panel1.Controls.Add(this.dropGaussians);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.useRandomColors);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.ViewedLayerNumber);
            this.panel1.Controls.Add(this.ViewedLayer);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.PointNumber);
            this.panel1.Controls.Add(this.LayerNumber);
            this.panel1.Controls.Add(this.SampleNumber);
            this.panel1.Controls.Add(this.FitNumber);
            this.panel1.Controls.Add(this.HierarchicalLayers);
            this.panel1.Controls.Add(this.GaussiansPerLevel);
            this.panel1.Controls.Add(this.GaussianSamples);
            this.panel1.Controls.Add(this.generatedPoints);
            this.panel1.Location = new System.Drawing.Point(1341, 861);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(551, 173);
            this.panel1.TabIndex = 17;
            // 
            // showPoints
            // 
            this.showPoints.AutoSize = true;
            this.showPoints.Checked = true;
            this.showPoints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showPoints.Location = new System.Drawing.Point(262, 52);
            this.showPoints.Name = "showPoints";
            this.showPoints.Size = new System.Drawing.Size(85, 17);
            this.showPoints.TabIndex = 18;
            this.showPoints.Text = "Show Points";
            this.showPoints.UseVisualStyleBackColor = true;
            this.showPoints.CheckedChanged += new System.EventHandler(this.showPoints_CheckedChanged);
            // 
            // showFits
            // 
            this.showFits.AutoSize = true;
            this.showFits.Checked = true;
            this.showFits.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showFits.Location = new System.Drawing.Point(262, 75);
            this.showFits.Name = "showFits";
            this.showFits.Size = new System.Drawing.Size(72, 17);
            this.showFits.TabIndex = 17;
            this.showFits.Text = "Show Fits";
            this.showFits.UseVisualStyleBackColor = true;
            this.showFits.CheckedChanged += new System.EventHandler(this.showFits_CheckedChanged);
            // 
            // KmeansInit
            // 
            this.KmeansInit.AutoSize = true;
            this.KmeansInit.Checked = true;
            this.KmeansInit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.KmeansInit.Location = new System.Drawing.Point(262, 100);
            this.KmeansInit.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.KmeansInit.Name = "KmeansInit";
            this.KmeansInit.Size = new System.Drawing.Size(84, 17);
            this.KmeansInit.TabIndex = 16;
            this.KmeansInit.Text = "K-means Init";
            this.KmeansInit.UseVisualStyleBackColor = true;
            this.KmeansInit.CheckedChanged += new System.EventHandler(this.kmeansInit_CheckedChanged);
            // 
            // dropGaussians
            // 
            this.dropGaussians.AutoSize = true;
            this.dropGaussians.Location = new System.Drawing.Point(262, 125);
            this.dropGaussians.Name = "dropGaussians";
            this.dropGaussians.Size = new System.Drawing.Size(101, 17);
            this.dropGaussians.TabIndex = 15;
            this.dropGaussians.Text = "Drop Gaussians";
            this.dropGaussians.UseVisualStyleBackColor = true;
            this.dropGaussians.CheckedChanged += new System.EventHandler(this.dropGaussians_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(109, 140);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 27);
            this.button2.TabIndex = 14;
            this.button2.Text = "RESET MEMORY";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.rESETMEMORYToolStripMenuItem_Click);
            // 
            // useRandomColors
            // 
            this.useRandomColors.AutoSize = true;
            this.useRandomColors.Location = new System.Drawing.Point(262, 150);
            this.useRandomColors.Name = "useRandomColors";
            this.useRandomColors.Size = new System.Drawing.Size(98, 17);
            this.useRandomColors.TabIndex = 13;
            this.useRandomColors.Text = "Random Colors";
            this.useRandomColors.UseVisualStyleBackColor = true;
            this.useRandomColors.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(377, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ViewedLayerNumber
            // 
            this.ViewedLayerNumber.Location = new System.Drawing.Point(468, 149);
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
            this.ViewedLayer.Location = new System.Drawing.Point(392, 151);
            this.ViewedLayer.Name = "ViewedLayer";
            this.ViewedLayer.Size = new System.Drawing.Size(70, 13);
            this.ViewedLayer.TabIndex = 10;
            this.ViewedLayer.Text = "Current Level";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(474, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Configuration";
            // 
            // PointNumber
            // 
            this.PointNumber.Location = new System.Drawing.Point(468, 45);
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
            this.LayerNumber.Location = new System.Drawing.Point(468, 123);
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
            this.SampleNumber.Location = new System.Drawing.Point(468, 71);
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
            this.FitNumber.Location = new System.Drawing.Point(468, 97);
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
            this.HierarchicalLayers.Location = new System.Drawing.Point(365, 126);
            this.HierarchicalLayers.Name = "HierarchicalLayers";
            this.HierarchicalLayers.Size = new System.Drawing.Size(97, 13);
            this.HierarchicalLayers.TabIndex = 3;
            this.HierarchicalLayers.Text = "Hierarchical Levels";
            // 
            // GaussiansPerLevel
            // 
            this.GaussiansPerLevel.AutoSize = true;
            this.GaussiansPerLevel.Location = new System.Drawing.Point(358, 99);
            this.GaussiansPerLevel.Name = "GaussiansPerLevel";
            this.GaussiansPerLevel.Size = new System.Drawing.Size(104, 13);
            this.GaussiansPerLevel.TabIndex = 2;
            this.GaussiansPerLevel.Text = "Gaussians Per Level";
            // 
            // GaussianSamples
            // 
            this.GaussianSamples.AutoSize = true;
            this.GaussianSamples.Location = new System.Drawing.Point(365, 73);
            this.GaussianSamples.Name = "GaussianSamples";
            this.GaussianSamples.Size = new System.Drawing.Size(97, 13);
            this.GaussianSamples.TabIndex = 1;
            this.GaussianSamples.Text = "Sample Gaussians ";
            // 
            // generatedPoints
            // 
            this.generatedPoints.AutoSize = true;
            this.generatedPoints.Location = new System.Drawing.Point(370, 52);
            this.generatedPoints.Name = "generatedPoints";
            this.generatedPoints.Size = new System.Drawing.Size(89, 13);
            this.generatedPoints.TabIndex = 0;
            this.generatedPoints.Text = "Generated Points";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // sliceImporter2D
            // 
            this.sliceImporter2D.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // GMMDemoWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupbox_canvas);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GMMDemoWnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GMMDemo";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupbox_canvas.ResumeLayout(false);
            this.groupbox_canvas.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem generateLiDARDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem load2DLIDARScanToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog sliceImporter2D;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox showPoints;
        private System.Windows.Forms.CheckBox showFits;
        private System.Windows.Forms.CheckBox KmeansInit;
        private System.Windows.Forms.CheckBox dropGaussians;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox useRandomColors;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown ViewedLayerNumber;
        private System.Windows.Forms.Label ViewedLayer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown PointNumber;
        private System.Windows.Forms.NumericUpDown LayerNumber;
        private System.Windows.Forms.NumericUpDown SampleNumber;
        private System.Windows.Forms.NumericUpDown FitNumber;
        private System.Windows.Forms.Label HierarchicalLayers;
        private System.Windows.Forms.Label GaussiansPerLevel;
        private System.Windows.Forms.Label GaussianSamples;
        private System.Windows.Forms.Label generatedPoints;
    }
}

