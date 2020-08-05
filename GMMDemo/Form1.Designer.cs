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
            this.fitGMMsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawDummyGaussianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateLiDARDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.load2DLIDARScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupbox_canvas = new System.Windows.Forms.GroupBox();
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
            this.label_status.Location = new System.Drawing.Point(11, 909);
            this.label_status.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(76, 21);
            this.label_status.TabIndex = 0;
            this.label_status.Text = "label1";
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
            this.fitGMMsToolStripMenuItem,
            this.drawDummyGaussianToolStripMenuItem,
            this.generateLiDARDataToolStripMenuItem,
            this.load2DLIDARScanToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(89, 32);
            this.dataToolStripMenuItem.Text = "Menu";
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
            // fitGMMsToolStripMenuItem
            // 
            this.fitGMMsToolStripMenuItem.Name = "fitGMMsToolStripMenuItem";
            this.fitGMMsToolStripMenuItem.Size = new System.Drawing.Size(422, 40);
            this.fitGMMsToolStripMenuItem.Text = "Fit HGMM";
            this.fitGMMsToolStripMenuItem.Click += new System.EventHandler(this.fitGMMsToolStripMenuItem_Click);
            // 
            // drawDummyGaussianToolStripMenuItem
            // 
            this.drawDummyGaussianToolStripMenuItem.Name = "drawDummyGaussianToolStripMenuItem";
            this.drawDummyGaussianToolStripMenuItem.Size = new System.Drawing.Size(422, 40);
            this.drawDummyGaussianToolStripMenuItem.Text = "Draw Gaussian Ground Truth";
            this.drawDummyGaussianToolStripMenuItem.Click += new System.EventHandler(this.drawDummyGaussianToolStripMenuItem_Click);
            // 
            // generateLiDARDataToolStripMenuItem
            // 
            this.generateLiDARDataToolStripMenuItem.Name = "generateLiDARDataToolStripMenuItem";
            this.generateLiDARDataToolStripMenuItem.Size = new System.Drawing.Size(422, 40);
            this.generateLiDARDataToolStripMenuItem.Text = "Generate Fake LiDAR Data";
            this.generateLiDARDataToolStripMenuItem.Click += new System.EventHandler(this.generateLiDARDataToolStripMenuItem_Click);
            // 
            // load2DLIDARScanToolStripMenuItem
            // 
            this.load2DLIDARScanToolStripMenuItem.Name = "load2DLIDARScanToolStripMenuItem";
            this.load2DLIDARScanToolStripMenuItem.Size = new System.Drawing.Size(422, 40);
            this.load2DLIDARScanToolStripMenuItem.Text = "Load 2D LIDAR Scan";
            this.load2DLIDARScanToolStripMenuItem.Click += new System.EventHandler(this.load2DLIDARScanToolStripMenuItem_Click);
            // 
            // groupbox_canvas
            // 
            this.groupbox_canvas.Controls.Add(this.KmeansInit);
            this.groupbox_canvas.Controls.Add(this.dropGaussians);
            this.groupbox_canvas.Controls.Add(this.button2);
            this.groupbox_canvas.Controls.Add(this.useRandomColors);
            this.groupbox_canvas.Controls.Add(this.button1);
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
            this.groupbox_canvas.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.groupbox_canvas.Name = "groupbox_canvas";
            this.groupbox_canvas.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.groupbox_canvas.Size = new System.Drawing.Size(1894, 934);
            this.groupbox_canvas.TabIndex = 2;
            this.groupbox_canvas.TabStop = false;
            this.groupbox_canvas.Text = "Data Plot";
            this.groupbox_canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.groupbox_canvans_Paint);
            this.groupbox_canvas.Enter += new System.EventHandler(this.groupbox_canvas_Enter_1);
            // 
            // KmeansInit
            // 
            this.KmeansInit.AutoSize = true;
            this.KmeansInit.Location = new System.Drawing.Point(915, 884);
            this.KmeansInit.Margin = new System.Windows.Forms.Padding(11, 8, 11, 8);
            this.KmeansInit.Name = "KmeansInit";
            this.KmeansInit.Size = new System.Drawing.Size(168, 25);
            this.KmeansInit.TabIndex = 16;
            this.KmeansInit.Text = "K-means Init";
            this.KmeansInit.UseVisualStyleBackColor = true;
            this.KmeansInit.CheckedChanged += new System.EventHandler(this.kmeansInit_CheckedChanged);
            // 
            // dropGaussians
            // 
            this.dropGaussians.AutoSize = true;
            this.dropGaussians.Location = new System.Drawing.Point(1368, 859);
            this.dropGaussians.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dropGaussians.Name = "dropGaussians";
            this.dropGaussians.Size = new System.Drawing.Size(190, 25);
            this.dropGaussians.TabIndex = 15;
            this.dropGaussians.Text = "Drop Gaussians";
            this.dropGaussians.UseVisualStyleBackColor = true;
            this.dropGaussians.CheckedChanged += new System.EventHandler(this.dropGaussians_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1087, 884);
            this.button2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(270, 44);
            this.button2.TabIndex = 14;
            this.button2.Text = "RESET MEMORY";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.rESETMEMORYToolStripMenuItem_Click);
            // 
            // useRandomColors
            // 
            this.useRandomColors.AutoSize = true;
            this.useRandomColors.Location = new System.Drawing.Point(1368, 900);
            this.useRandomColors.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.useRandomColors.Name = "useRandomColors";
            this.useRandomColors.Size = new System.Drawing.Size(179, 25);
            this.useRandomColors.TabIndex = 13;
            this.useRandomColors.Text = "Random Colors";
            this.useRandomColors.UseVisualStyleBackColor = true;
            this.useRandomColors.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1579, 685);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 37);
            this.button1.TabIndex = 12;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ViewedLayerNumber
            // 
            this.ViewedLayerNumber.Location = new System.Drawing.Point(1745, 898);
            this.ViewedLayerNumber.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ViewedLayerNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ViewedLayerNumber.Name = "ViewedLayerNumber";
            this.ViewedLayerNumber.Size = new System.Drawing.Size(149, 31);
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
            this.ViewedLayer.Location = new System.Drawing.Point(1606, 901);
            this.ViewedLayer.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.ViewedLayer.Name = "ViewedLayer";
            this.ViewedLayer.Size = new System.Drawing.Size(153, 21);
            this.ViewedLayer.TabIndex = 10;
            this.ViewedLayer.Text = "Current Level";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1756, 685);
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
            this.PointNumber.ValueChanged += new System.EventHandler(this.UpdateConfigurationHandler);
            this.PointNumber.Enter += new System.EventHandler(this.UpdateConfigurationHandler);
            // 
            // LayerNumber
            // 
            this.LayerNumber.Location = new System.Drawing.Point(1745, 856);
            this.LayerNumber.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.LayerNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LayerNumber.Name = "LayerNumber";
            this.LayerNumber.Size = new System.Drawing.Size(149, 31);
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
            this.SampleNumber.Location = new System.Drawing.Point(1745, 772);
            this.SampleNumber.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.SampleNumber.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.SampleNumber.Name = "SampleNumber";
            this.SampleNumber.Size = new System.Drawing.Size(149, 31);
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
            this.FitNumber.ValueChanged += new System.EventHandler(this.UpdateConfigurationHandler);
            this.FitNumber.Enter += new System.EventHandler(this.UpdateConfigurationHandler);
            // 
            // HierarchicalLayers
            // 
            this.HierarchicalLayers.AutoSize = true;
            this.HierarchicalLayers.Location = new System.Drawing.Point(1557, 861);
            this.HierarchicalLayers.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.HierarchicalLayers.Name = "HierarchicalLayers";
            this.HierarchicalLayers.Size = new System.Drawing.Size(219, 21);
            this.HierarchicalLayers.TabIndex = 3;
            this.HierarchicalLayers.Text = "Hierarchical Levels";
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
            this.GaussianSamples.Location = new System.Drawing.Point(1557, 775);
            this.GaussianSamples.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.GaussianSamples.Name = "GaussianSamples";
            this.GaussianSamples.Size = new System.Drawing.Size(197, 21);
            this.GaussianSamples.TabIndex = 1;
            this.GaussianSamples.Text = "Sample Gaussians ";
            // 
            // generatedPoints
            // 
            this.generatedPoints.AutoSize = true;
            this.generatedPoints.Location = new System.Drawing.Point(1566, 741);
            this.generatedPoints.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.generatedPoints.Name = "generatedPoints";
            this.generatedPoints.Size = new System.Drawing.Size(186, 21);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1894, 934);
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
        private System.Windows.Forms.NumericUpDown ViewedLayerNumber;
        private System.Windows.Forms.Label ViewedLayer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox useRandomColors;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox dropGaussians;
        private System.Windows.Forms.ToolStripMenuItem generateLiDARDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem load2DLIDARScanToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog sliceImporter2D;
        private System.Windows.Forms.CheckBox KmeansInit;
    }
}

