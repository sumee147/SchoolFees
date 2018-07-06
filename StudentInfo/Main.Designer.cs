namespace StudentInfo
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mastersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expensiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sajakaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feesDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sajakaDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expensiveDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(188)))), ((int)(((byte)(244)))));
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mastersToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1259, 39);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mastersToolStripMenuItem
            // 
            this.mastersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.standardToolStripMenuItem,
            this.sectionToolStripMenuItem,
            this.studentInfoToolStripMenuItem,
            this.feesToolStripMenuItem,
            this.expensiveToolStripMenuItem,
            this.sajakaToolStripMenuItem,
            this.importExcelToolStripMenuItem});
            this.mastersToolStripMenuItem.Name = "mastersToolStripMenuItem";
            this.mastersToolStripMenuItem.Size = new System.Drawing.Size(130, 35);
            this.mastersToolStripMenuItem.Text = "Masters";
            // 
            // standardToolStripMenuItem
            // 
            this.standardToolStripMenuItem.Name = "standardToolStripMenuItem";
            this.standardToolStripMenuItem.Size = new System.Drawing.Size(250, 36);
            this.standardToolStripMenuItem.Text = "Standard";
            this.standardToolStripMenuItem.Click += new System.EventHandler(this.standardToolStripMenuItem_Click);
            // 
            // sectionToolStripMenuItem
            // 
            this.sectionToolStripMenuItem.Name = "sectionToolStripMenuItem";
            this.sectionToolStripMenuItem.Size = new System.Drawing.Size(250, 36);
            this.sectionToolStripMenuItem.Text = "Section";
            this.sectionToolStripMenuItem.Click += new System.EventHandler(this.sectionToolStripMenuItem_Click);
            // 
            // studentInfoToolStripMenuItem
            // 
            this.studentInfoToolStripMenuItem.Name = "studentInfoToolStripMenuItem";
            this.studentInfoToolStripMenuItem.Size = new System.Drawing.Size(250, 36);
            this.studentInfoToolStripMenuItem.Text = "Student Info";
            this.studentInfoToolStripMenuItem.Click += new System.EventHandler(this.studentInfoToolStripMenuItem_Click);
            // 
            // feesToolStripMenuItem
            // 
            this.feesToolStripMenuItem.Name = "feesToolStripMenuItem";
            this.feesToolStripMenuItem.Size = new System.Drawing.Size(250, 36);
            this.feesToolStripMenuItem.Text = "Fees";
            this.feesToolStripMenuItem.Click += new System.EventHandler(this.feesToolStripMenuItem_Click);
            // 
            // expensiveToolStripMenuItem
            // 
            this.expensiveToolStripMenuItem.Name = "expensiveToolStripMenuItem";
            this.expensiveToolStripMenuItem.Size = new System.Drawing.Size(250, 36);
            this.expensiveToolStripMenuItem.Text = "Expensive";
            this.expensiveToolStripMenuItem.Click += new System.EventHandler(this.expensiveToolStripMenuItem_Click);
            // 
            // sajakaToolStripMenuItem
            // 
            this.sajakaToolStripMenuItem.Name = "sajakaToolStripMenuItem";
            this.sajakaToolStripMenuItem.Size = new System.Drawing.Size(250, 36);
            this.sajakaToolStripMenuItem.Text = "Sajaka";
            this.sajakaToolStripMenuItem.Click += new System.EventHandler(this.sajakaToolStripMenuItem_Click);
            // 
            // importExcelToolStripMenuItem
            // 
            this.importExcelToolStripMenuItem.Name = "importExcelToolStripMenuItem";
            this.importExcelToolStripMenuItem.Size = new System.Drawing.Size(250, 36);
            this.importExcelToolStripMenuItem.Text = "Import Excel";
            this.importExcelToolStripMenuItem.Click += new System.EventHandler(this.importExcelToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.feesDetailsToolStripMenuItem,
            this.sajakaDetailsToolStripMenuItem,
            this.expensiveDetailsToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(129, 35);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // feesDetailsToolStripMenuItem
            // 
            this.feesDetailsToolStripMenuItem.Name = "feesDetailsToolStripMenuItem";
            this.feesDetailsToolStripMenuItem.Size = new System.Drawing.Size(321, 36);
            this.feesDetailsToolStripMenuItem.Text = "Fees Details";
            this.feesDetailsToolStripMenuItem.Click += new System.EventHandler(this.feesDetailsToolStripMenuItem_Click);
            // 
            // sajakaDetailsToolStripMenuItem
            // 
            this.sajakaDetailsToolStripMenuItem.Name = "sajakaDetailsToolStripMenuItem";
            this.sajakaDetailsToolStripMenuItem.Size = new System.Drawing.Size(321, 36);
            this.sajakaDetailsToolStripMenuItem.Text = "Sajaka Details";
            this.sajakaDetailsToolStripMenuItem.Click += new System.EventHandler(this.sajakaDetailsToolStripMenuItem_Click);
            // 
            // expensiveDetailsToolStripMenuItem
            // 
            this.expensiveDetailsToolStripMenuItem.Name = "expensiveDetailsToolStripMenuItem";
            this.expensiveDetailsToolStripMenuItem.Size = new System.Drawing.Size(321, 36);
            this.expensiveDetailsToolStripMenuItem.Text = "Expensive Details";
            this.expensiveDetailsToolStripMenuItem.Click += new System.EventHandler(this.expensiveDetailsToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(226)))), ((int)(((byte)(234)))));
            this.BackgroundImage = global::StudentInfo.Properties.Resources.fees;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1259, 597);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Main";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mastersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem standardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem feesDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sajakaDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expensiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sajakaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem feesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expensiveDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importExcelToolStripMenuItem;
    }
}

