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
            this.manualFitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManualFitButton = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectAllGaussiansButton = new System.Windows.Forms.ToolStripMenuItem();
            this.finalizeManualGMM = new System.Windows.Forms.ToolStripMenuItem();
            this.groupbox_canvas = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CircleResolution = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.LineResolution = new System.Windows.Forms.NumericUpDown();
            this.InitializationSelectionBox = new System.Windows.Forms.ComboBox();
            this.LayerNumber = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.GaussianSamples = new System.Windows.Forms.Label();
            this.ViewedLayer = new System.Windows.Forms.Label();
            this.FitNumber = new System.Windows.Forms.NumericUpDown();
            this.ViewedLayerNumber = new System.Windows.Forms.NumericUpDown();
            this.showFits = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.showPoints = new System.Windows.Forms.CheckBox();
            this.SampleNumber = new System.Windows.Forms.NumericUpDown();
            this.useRandomColors = new System.Windows.Forms.CheckBox();
            this.PointNumber = new System.Windows.Forms.NumericUpDown();
            this.GaussiansPerLevel = new System.Windows.Forms.Label();
            this.HierarchicalLayers = new System.Windows.Forms.Label();
            this.generatedPoints = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.drawingCanvas = new System.Windows.Forms.Panel();
            this.fitLabel = new System.Windows.Forms.Label();
            this.fitMode = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fitLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitCircleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sliceImporter2D = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ignoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupbox_canvas.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CircleResolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineResolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayerNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FitNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewedLayerNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SampleNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PointNumber)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(12, 1648);
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
            this.dataToolStripMenuItem,
            this.manualFitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(11, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(2834, 38);
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
            // manualFitToolStripMenuItem
            // 
            this.manualFitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ManualFitButton,
            this.SelectAllGaussiansButton,
            this.finalizeManualGMM});
            this.manualFitToolStripMenuItem.Name = "manualFitToolStripMenuItem";
            this.manualFitToolStripMenuItem.Size = new System.Drawing.Size(138, 32);
            this.manualFitToolStripMenuItem.Text = "Manual Fit";
            // 
            // ManualFitButton
            // 
            this.ManualFitButton.Name = "ManualFitButton";
            this.ManualFitButton.Size = new System.Drawing.Size(331, 40);
            this.ManualFitButton.Text = "Manually Fit Level";
            this.ManualFitButton.Click += new System.EventHandler(this.manualFitButton_Click);
            // 
            // SelectAllGaussiansButton
            // 
            this.SelectAllGaussiansButton.Name = "SelectAllGaussiansButton";
            this.SelectAllGaussiansButton.Size = new System.Drawing.Size(331, 40);
            this.SelectAllGaussiansButton.Text = "Select All Gaussians";
            this.SelectAllGaussiansButton.Click += new System.EventHandler(this.SelectAllGaussiansButton_Click);
            // 
            // finalizeManualGMM
            // 
            this.finalizeManualGMM.Name = "finalizeManualGMM";
            this.finalizeManualGMM.Size = new System.Drawing.Size(331, 40);
            this.finalizeManualGMM.Text = "Finalize GMM";
            this.finalizeManualGMM.Click += new System.EventHandler(this.finalizeManualGMM_Click);
            // 
            // groupbox_canvas
            // 
            this.groupbox_canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupbox_canvas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupbox_canvas.Controls.Add(this.panel1);
            this.groupbox_canvas.Controls.Add(this.drawingCanvas);
            this.groupbox_canvas.Controls.Add(this.fitLabel);
            this.groupbox_canvas.Controls.Add(this.fitMode);
            this.groupbox_canvas.Controls.Add(this.label_status);
            this.groupbox_canvas.Location = new System.Drawing.Point(0, 3);
            this.groupbox_canvas.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.groupbox_canvas.Name = "groupbox_canvas";
            this.groupbox_canvas.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.groupbox_canvas.Size = new System.Drawing.Size(2810, 1678);
            this.groupbox_canvas.TabIndex = 2;
            this.groupbox_canvas.TabStop = false;
            this.groupbox_canvas.Text = "Data Plot";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CircleResolution);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.LineResolution);
            this.panel1.Controls.Add(this.InitializationSelectionBox);
            this.panel1.Controls.Add(this.LayerNumber);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.GaussianSamples);
            this.panel1.Controls.Add(this.ViewedLayer);
            this.panel1.Controls.Add(this.FitNumber);
            this.panel1.Controls.Add(this.ViewedLayerNumber);
            this.panel1.Controls.Add(this.showFits);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.showPoints);
            this.panel1.Controls.Add(this.SampleNumber);
            this.panel1.Controls.Add(this.useRandomColors);
            this.panel1.Controls.Add(this.PointNumber);
            this.panel1.Controls.Add(this.GaussiansPerLevel);
            this.panel1.Controls.Add(this.HierarchicalLayers);
            this.panel1.Controls.Add(this.generatedPoints);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1838, 1350);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(993, 329);
            this.panel1.TabIndex = 22;
            // 
            // CircleResolution
            // 
            this.CircleResolution.DecimalPlaces = 2;
            this.CircleResolution.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.CircleResolution.Location = new System.Drawing.Point(815, 29);
            this.CircleResolution.Name = "CircleResolution";
            this.CircleResolution.Size = new System.Drawing.Size(149, 31);
            this.CircleResolution.TabIndex = 23;
            this.CircleResolution.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(606, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 21);
            this.label3.TabIndex = 22;
            this.label3.Text = "Circle resolution";
            // 
            // LineResolution
            // 
            this.LineResolution.DecimalPlaces = 2;
            this.LineResolution.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.LineResolution.Location = new System.Drawing.Point(815, 74);
            this.LineResolution.Name = "LineResolution";
            this.LineResolution.Size = new System.Drawing.Size(149, 31);
            this.LineResolution.TabIndex = 21;
            this.LineResolution.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.LineResolution.ValueChanged += new System.EventHandler(this.UpdateConfigurationHandler);
            this.LineResolution.Enter += new System.EventHandler(this.UpdateConfigurationHandler);
            // 
            // InitializationSelectionBox
            // 
            this.InitializationSelectionBox.FormattingEnabled = true;
            this.InitializationSelectionBox.Items.AddRange(new object[] {
            "K-Means",
            "FCM",
            "Random"});
            this.InitializationSelectionBox.Location = new System.Drawing.Point(431, 239);
            this.InitializationSelectionBox.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.InitializationSelectionBox.Name = "InitializationSelectionBox";
            this.InitializationSelectionBox.Size = new System.Drawing.Size(131, 29);
            this.InitializationSelectionBox.TabIndex = 1;
            this.InitializationSelectionBox.Text = "K-Means";
            this.InitializationSelectionBox.SelectedIndexChanged += new System.EventHandler(this.InitializationSelectionBox_SelectedIndexChanged);
            // 
            // LayerNumber
            // 
            this.LayerNumber.Location = new System.Drawing.Point(815, 243);
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(-7, 272);
            this.button2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(270, 44);
            this.button2.TabIndex = 14;
            this.button2.Text = "RESET MEMORY";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.rESETMEMORYToolStripMenuItem_Click);
            // 
            // GaussianSamples
            // 
            this.GaussianSamples.AutoSize = true;
            this.GaussianSamples.Location = new System.Drawing.Point(617, 163);
            this.GaussianSamples.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.GaussianSamples.Name = "GaussianSamples";
            this.GaussianSamples.Size = new System.Drawing.Size(186, 21);
            this.GaussianSamples.TabIndex = 1;
            this.GaussianSamples.Text = "Sample Gaussians";
            // 
            // ViewedLayer
            // 
            this.ViewedLayer.AutoSize = true;
            this.ViewedLayer.Location = new System.Drawing.Point(650, 287);
            this.ViewedLayer.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.ViewedLayer.Name = "ViewedLayer";
            this.ViewedLayer.Size = new System.Drawing.Size(153, 21);
            this.ViewedLayer.TabIndex = 10;
            this.ViewedLayer.Text = "Current Level";
            // 
            // FitNumber
            // 
            this.FitNumber.Location = new System.Drawing.Point(815, 201);
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
            // ViewedLayerNumber
            // 
            this.ViewedLayerNumber.Location = new System.Drawing.Point(815, 285);
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
            // showFits
            // 
            this.showFits.AutoSize = true;
            this.showFits.Checked = true;
            this.showFits.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showFits.Location = new System.Drawing.Point(360, 159);
            this.showFits.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.showFits.Name = "showFits";
            this.showFits.Size = new System.Drawing.Size(135, 25);
            this.showFits.TabIndex = 17;
            this.showFits.Text = "Show Fits";
            this.showFits.UseVisualStyleBackColor = true;
            this.showFits.CheckedChanged += new System.EventHandler(this.showFits_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(628, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 21);
            this.label2.TabIndex = 20;
            this.label2.Text = "Line resolution";
            // 
            // showPoints
            // 
            this.showPoints.AutoSize = true;
            this.showPoints.Checked = true;
            this.showPoints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showPoints.Location = new System.Drawing.Point(360, 117);
            this.showPoints.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.showPoints.Name = "showPoints";
            this.showPoints.Size = new System.Drawing.Size(157, 25);
            this.showPoints.TabIndex = 18;
            this.showPoints.Text = "Show Points";
            this.showPoints.UseVisualStyleBackColor = true;
            this.showPoints.CheckedChanged += new System.EventHandler(this.showPoints_CheckedChanged);
            // 
            // SampleNumber
            // 
            this.SampleNumber.Location = new System.Drawing.Point(815, 159);
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
            // useRandomColors
            // 
            this.useRandomColors.AutoSize = true;
            this.useRandomColors.Location = new System.Drawing.Point(360, 204);
            this.useRandomColors.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.useRandomColors.Name = "useRandomColors";
            this.useRandomColors.Size = new System.Drawing.Size(179, 25);
            this.useRandomColors.TabIndex = 13;
            this.useRandomColors.Text = "Random Colors";
            this.useRandomColors.UseVisualStyleBackColor = true;
            this.useRandomColors.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // PointNumber
            // 
            this.PointNumber.Location = new System.Drawing.Point(815, 117);
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
            // GaussiansPerLevel
            // 
            this.GaussiansPerLevel.AutoSize = true;
            this.GaussiansPerLevel.Location = new System.Drawing.Point(584, 208);
            this.GaussiansPerLevel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.GaussiansPerLevel.Name = "GaussiansPerLevel";
            this.GaussiansPerLevel.Size = new System.Drawing.Size(219, 21);
            this.GaussiansPerLevel.TabIndex = 2;
            this.GaussiansPerLevel.Text = "Gaussians Per Level";
            // 
            // HierarchicalLayers
            // 
            this.HierarchicalLayers.AutoSize = true;
            this.HierarchicalLayers.Location = new System.Drawing.Point(584, 247);
            this.HierarchicalLayers.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.HierarchicalLayers.Name = "HierarchicalLayers";
            this.HierarchicalLayers.Size = new System.Drawing.Size(219, 21);
            this.HierarchicalLayers.TabIndex = 3;
            this.HierarchicalLayers.Text = "Hierarchical Levels";
            // 
            // generatedPoints
            // 
            this.generatedPoints.AutoSize = true;
            this.generatedPoints.Location = new System.Drawing.Point(617, 121);
            this.generatedPoints.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.generatedPoints.Name = "generatedPoints";
            this.generatedPoints.Size = new System.Drawing.Size(186, 21);
            this.generatedPoints.TabIndex = 0;
            this.generatedPoints.Text = "Generated Points";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(277, 243);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 21);
            this.label1.TabIndex = 19;
            this.label1.Text = "Init. Method";
            // 
            // drawingCanvas
            // 
            this.drawingCanvas.Location = new System.Drawing.Point(0, 40);
            this.drawingCanvas.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.drawingCanvas.Name = "drawingCanvas";
            this.drawingCanvas.Size = new System.Drawing.Size(2834, 1568);
            this.drawingCanvas.TabIndex = 20;
            this.drawingCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.drawingCanvasPaint);
            this.drawingCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.formClickDetect);
            // 
            // fitLabel
            // 
            this.fitLabel.AutoSize = true;
            this.fitLabel.Location = new System.Drawing.Point(12, 1617);
            this.fitLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.fitLabel.Name = "fitLabel";
            this.fitLabel.Size = new System.Drawing.Size(98, 21);
            this.fitLabel.TabIndex = 18;
            this.fitLabel.Text = "Fit Mode";
            // 
            // fitMode
            // 
            this.fitMode.AutoSize = true;
            this.fitMode.Location = new System.Drawing.Point(122, 1617);
            this.fitMode.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.fitMode.Name = "fitMode";
            this.fitMode.Size = new System.Drawing.Size(54, 21);
            this.fitMode.TabIndex = 19;
            this.fitMode.Text = "Auto";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fitLineToolStripMenuItem,
            this.fitCircleToolStripMenuItem,
            this.ignoreToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(170, 106);
            // 
            // fitLineToolStripMenuItem
            // 
            this.fitLineToolStripMenuItem.Name = "fitLineToolStripMenuItem";
            this.fitLineToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.fitLineToolStripMenuItem.Text = "Fit line";
            this.fitLineToolStripMenuItem.Click += new System.EventHandler(this.fitLineToolStripMenuItem_Click);
            // 
            // fitCircleToolStripMenuItem
            // 
            this.fitCircleToolStripMenuItem.Name = "fitCircleToolStripMenuItem";
            this.fitCircleToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.fitCircleToolStripMenuItem.Text = "Fit circle";
            this.fitCircleToolStripMenuItem.Click += new System.EventHandler(this.fitCircleToolStripMenuItem_Click);
            // 
            // ignoreToolStripMenuItem
            // 
            this.ignoreToolStripMenuItem.Name = "ignoreToolStripMenuItem";
            this.ignoreToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.ignoreToolStripMenuItem.Text = "Ignore";
            this.ignoreToolStripMenuItem.Click += new System.EventHandler(this.ignoreToolStripMenuItem_Click);
            // 
            // GMMDemoWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2834, 1682);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupbox_canvas);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximumSize = new System.Drawing.Size(2858, 1746);
            this.MinimumSize = new System.Drawing.Size(2858, 1746);
            this.Name = "GMMDemoWnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GMMDemo";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupbox_canvas.ResumeLayout(false);
            this.groupbox_canvas.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CircleResolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineResolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayerNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FitNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewedLayerNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SampleNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PointNumber)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem manualFitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManualFitButton;
        private System.Windows.Forms.ToolStripMenuItem finalizeManualGMM;
        private System.Windows.Forms.Label fitMode;
        private System.Windows.Forms.Label fitLabel;
        private System.Windows.Forms.Panel drawingCanvas;
        private System.Windows.Forms.ToolStripMenuItem SelectAllGaussiansButton;
        private System.Windows.Forms.ToolStripMenuItem fitLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitCircleToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown ViewedLayerNumber;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label ViewedLayer;
        private System.Windows.Forms.ComboBox InitializationSelectionBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown PointNumber;
        private System.Windows.Forms.CheckBox showPoints;
        private System.Windows.Forms.NumericUpDown LayerNumber;
        private System.Windows.Forms.CheckBox showFits;
        private System.Windows.Forms.NumericUpDown SampleNumber;
        private System.Windows.Forms.CheckBox useRandomColors;
        private System.Windows.Forms.NumericUpDown FitNumber;
        private System.Windows.Forms.Label GaussianSamples;
        private System.Windows.Forms.Label HierarchicalLayers;
        private System.Windows.Forms.Label generatedPoints;
        private System.Windows.Forms.Label GaussiansPerLevel;
        private System.Windows.Forms.NumericUpDown LineResolution;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown CircleResolution;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem ignoreToolStripMenuItem;
    }
}

