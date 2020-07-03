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
            this.fitGMMsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fit4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fit8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fitHGMsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupbox_canvans = new System.Windows.Forms.GroupBox();
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
            this.fitGMMsToolStripMenuItem,
            this.fitHGMsToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.dataToolStripMenuItem.Text = "Data Points";
            // 
            // regenerateRandomDataToolStripMenuItem
            // 
            this.regenerateRandomDataToolStripMenuItem.Name = "regenerateRandomDataToolStripMenuItem";
            this.regenerateRandomDataToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.regenerateRandomDataToolStripMenuItem.Text = "Regenerate Random Data";
            this.regenerateRandomDataToolStripMenuItem.Click += new System.EventHandler(this.regenerateRandomDataToolStripMenuItem_Click);
            // 
            // fitGMMsToolStripMenuItem
            // 
            this.fitGMMsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fit4ToolStripMenuItem,
            this.fit8ToolStripMenuItem});
            this.fitGMMsToolStripMenuItem.Name = "fitGMMsToolStripMenuItem";
            this.fitGMMsToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.fitGMMsToolStripMenuItem.Text = "Fit Flat GMMs ";
            this.fitGMMsToolStripMenuItem.Click += new System.EventHandler(this.fitGMMsToolStripMenuItem_Click);
            // 
            // fit4ToolStripMenuItem
            // 
            this.fit4ToolStripMenuItem.Name = "fit4ToolStripMenuItem";
            this.fit4ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fit4ToolStripMenuItem.Text = "Fit 4";
            this.fit4ToolStripMenuItem.Click += new System.EventHandler(this.fit4ToolStripMenuItem_Click);
            // 
            // fit8ToolStripMenuItem
            // 
            this.fit8ToolStripMenuItem.Name = "fit8ToolStripMenuItem";
            this.fit8ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fit8ToolStripMenuItem.Text = "Fit 8";
            this.fit8ToolStripMenuItem.Click += new System.EventHandler(this.fit8ToolStripMenuItem_Click);
            // 
            // fitHGMsToolStripMenuItem
            // 
            this.fitHGMsToolStripMenuItem.Name = "fitHGMsToolStripMenuItem";
            this.fitHGMsToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.fitHGMsToolStripMenuItem.Text = "Fit HGMs";
            this.fitHGMsToolStripMenuItem.Click += new System.EventHandler(this.fitHGMsToolStripMenuItem_Click);
            // 
            // groupbox_canvans
            // 
            this.groupbox_canvans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupbox_canvans.Location = new System.Drawing.Point(0, 0);
            this.groupbox_canvans.Name = "groupbox_canvans";
            this.groupbox_canvans.Size = new System.Drawing.Size(529, 549);
            this.groupbox_canvans.TabIndex = 2;
            this.groupbox_canvans.TabStop = false;
            this.groupbox_canvans.Text = "Data Plot";
            this.groupbox_canvans.Paint += new System.Windows.Forms.PaintEventHandler(this.groupbox_canvans_Paint);
            // 
            // GMMDemoWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 549);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupbox_canvans);
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
        private System.Windows.Forms.GroupBox groupbox_canvans;
    }
}

