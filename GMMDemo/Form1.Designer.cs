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
            this.label_status = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regenerateRandomDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateDummyGaussianDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mixtureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mixtureToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fitGMMsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fit4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fit8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitHGMsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupbox_canvas = new System.Windows.Forms.GroupBox();
            this.drawDummyGaussianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(12, 530);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(35, 13);
            this.label_status.TabIndex = 0;
            this.label_status.Text = "label1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(529, 24);
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
            this.fitHGMsToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.dataToolStripMenuItem.Text = "Data Points";
            this.dataToolStripMenuItem.Click += new System.EventHandler(this.dataToolStripMenuItem_Click);
            // 
            // regenerateRandomDataToolStripMenuItem
            // 
            this.regenerateRandomDataToolStripMenuItem.Name = "regenerateRandomDataToolStripMenuItem";
            this.regenerateRandomDataToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.regenerateRandomDataToolStripMenuItem.Text = "Regenerate Random Data";
            this.regenerateRandomDataToolStripMenuItem.Click += new System.EventHandler(this.regenerateRandomDataToolStripMenuItem_Click);
            // 
            // generateDummyGaussianDataToolStripMenuItem
            // 
            this.generateDummyGaussianDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mixtureToolStripMenuItem,
            this.mixtureToolStripMenuItem1});
            this.generateDummyGaussianDataToolStripMenuItem.Name = "generateDummyGaussianDataToolStripMenuItem";
            this.generateDummyGaussianDataToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.generateDummyGaussianDataToolStripMenuItem.Text = "Generate Dummy Gaussian Data";
            this.generateDummyGaussianDataToolStripMenuItem.Click += new System.EventHandler(this.generateDummyGaussianDataToolStripMenuItem_Click_1);
            // 
            // mixtureToolStripMenuItem
            // 
            this.mixtureToolStripMenuItem.Name = "mixtureToolStripMenuItem";
            this.mixtureToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.mixtureToolStripMenuItem.Text = "4-Mixture";
            this.mixtureToolStripMenuItem.Click += new System.EventHandler(this.mixtureToolStripMenuItem_Click);
            // 
            // mixtureToolStripMenuItem1
            // 
            this.mixtureToolStripMenuItem1.Name = "mixtureToolStripMenuItem1";
            this.mixtureToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.mixtureToolStripMenuItem1.Text = "8-Mixture";
            this.mixtureToolStripMenuItem1.Click += new System.EventHandler(this.mixtureToolStripMenuItem1_Click);
            // 
            // fitGMMsToolStripMenuItem
            // 
            this.fitGMMsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fit4ToolStripMenuItem,
            this.fit8ToolStripMenuItem});
            this.fitGMMsToolStripMenuItem.Name = "fitGMMsToolStripMenuItem";
            this.fitGMMsToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.fitGMMsToolStripMenuItem.Text = "Fit Flat GMMs ";
            this.fitGMMsToolStripMenuItem.Click += new System.EventHandler(this.fitGMMsToolStripMenuItem_Click);
            // 
            // fit4ToolStripMenuItem
            // 
            this.fit4ToolStripMenuItem.Name = "fit4ToolStripMenuItem";
            this.fit4ToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.fit4ToolStripMenuItem.Text = "Fit 4";
            this.fit4ToolStripMenuItem.Click += new System.EventHandler(this.fit4ToolStripMenuItem_Click);
            // 
            // fit8ToolStripMenuItem
            // 
            this.fit8ToolStripMenuItem.Name = "fit8ToolStripMenuItem";
            this.fit8ToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.fit8ToolStripMenuItem.Text = "Fit 8";
            this.fit8ToolStripMenuItem.Click += new System.EventHandler(this.fit8ToolStripMenuItem_Click);
            // 
            // fitHGMsToolStripMenuItem
            // 
            this.fitHGMsToolStripMenuItem.Name = "fitHGMsToolStripMenuItem";
            this.fitHGMsToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.fitHGMsToolStripMenuItem.Text = "Fit HGMs";
            this.fitHGMsToolStripMenuItem.Click += new System.EventHandler(this.fitHGMsToolStripMenuItem_Click);
            // 
            // groupbox_canvas
            // 
            this.groupbox_canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupbox_canvas.Location = new System.Drawing.Point(0, 0);
            this.groupbox_canvas.Name = "groupbox_canvas";
            this.groupbox_canvas.Size = new System.Drawing.Size(529, 549);
            this.groupbox_canvas.TabIndex = 2;
            this.groupbox_canvas.TabStop = false;
            this.groupbox_canvas.Text = "Data Plot";
            this.groupbox_canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.groupbox_canvans_Paint);
            // 
            // drawDummyGaussianToolStripMenuItem
            // 
            this.drawDummyGaussianToolStripMenuItem.Name = "drawDummyGaussianToolStripMenuItem";
            this.drawDummyGaussianToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.drawDummyGaussianToolStripMenuItem.Text = "Draw Dummy Gaussian";
            this.drawDummyGaussianToolStripMenuItem.Click += new System.EventHandler(this.drawDummyGaussianToolStripMenuItem_Click);
            // 
            // GMMDemoWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 549);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupbox_canvas);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GMMDemoWnd";
            this.Text = "GMMDemo";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regenerateRandomDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitGMMsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fit4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fit8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fitHGMsToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupbox_canvas;
        private System.Windows.Forms.ToolStripMenuItem generateDummyGaussianDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mixtureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mixtureToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem drawDummyGaussianToolStripMenuItem;
    }
}

