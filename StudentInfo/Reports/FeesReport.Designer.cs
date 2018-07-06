namespace StudentInfo.Reports
{
    partial class FeesReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeesReport));
            this.FeesReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studentDatabase = new StudentInfo.Data.StudentDatabase();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlSection = new System.Windows.Forms.ComboBox();
            this.sectionMasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ddlStandard = new System.Windows.Forms.ComboBox();
            this.standardMasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnshow = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtToDate = new System.Windows.Forms.DateTimePicker();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.standardMasterTableAdapter = new StudentInfo.Data.StudentDatabaseTableAdapters.StandardMasterTableAdapter();
            this.sectionMasterTableAdapter = new StudentInfo.Data.StudentDatabaseTableAdapters.SectionMasterTableAdapter();
            this.feesReportTableAdapter1 = new StudentInfo.Data.StudentDatabaseTableAdapters.FeesReportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.FeesReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionMasterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.standardMasterBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // FeesReportBindingSource
            // 
            this.FeesReportBindingSource.DataMember = "FeesReport";
            this.FeesReportBindingSource.DataSource = this.studentDatabase;
            // 
            // studentDatabase
            // 
            this.studentDatabase.DataSetName = "StudentDatabase";
            this.studentDatabase.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(188)))), ((int)(((byte)(244)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-1, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(648, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fees Details";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(422, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "Section";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(331, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "Standard";
            // 
            // ddlSection
            // 
            this.ddlSection.DataSource = this.sectionMasterBindingSource;
            this.ddlSection.DisplayMember = "SectionName";
            this.ddlSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlSection.FormattingEnabled = true;
            this.ddlSection.Location = new System.Drawing.Point(426, 72);
            this.ddlSection.Name = "ddlSection";
            this.ddlSection.Size = new System.Drawing.Size(71, 28);
            this.ddlSection.TabIndex = 28;
            this.ddlSection.ValueMember = "SectionID";
            // 
            // sectionMasterBindingSource
            // 
            this.sectionMasterBindingSource.DataMember = "SectionMaster";
            this.sectionMasterBindingSource.DataSource = this.studentDatabase;
            // 
            // ddlStandard
            // 
            this.ddlStandard.DataSource = this.standardMasterBindingSource;
            this.ddlStandard.DisplayMember = "StandardName";
            this.ddlStandard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlStandard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlStandard.FormattingEnabled = true;
            this.ddlStandard.Location = new System.Drawing.Point(335, 72);
            this.ddlStandard.Name = "ddlStandard";
            this.ddlStandard.Size = new System.Drawing.Size(71, 28);
            this.ddlStandard.TabIndex = 27;
            this.ddlStandard.ValueMember = "StandardID";
            this.ddlStandard.SelectedIndexChanged += new System.EventHandler(this.ddlStandard_SelectedIndexChanged);
            // 
            // standardMasterBindingSource
            // 
            this.standardMasterBindingSource.DataMember = "StandardMaster";
            this.standardMasterBindingSource.DataSource = this.studentDatabase;
            // 
            // btnshow
            // 
            this.btnshow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnshow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnshow.FlatAppearance.BorderSize = 0;
            this.btnshow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnshow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnshow.Location = new System.Drawing.Point(538, 70);
            this.btnshow.Name = "btnshow";
            this.btnshow.Size = new System.Drawing.Size(78, 30);
            this.btnshow.TabIndex = 31;
            this.btnshow.Text = "Show";
            this.btnshow.UseVisualStyleBackColor = false;
            this.btnshow.Click += new System.EventHandler(this.btnshow_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 20);
            this.label7.TabIndex = 33;
            this.label7.Text = "From";
            // 
            // txtFromDate
            // 
            this.txtFromDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromDate.Location = new System.Drawing.Point(28, 74);
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Size = new System.Drawing.Size(135, 26);
            this.txtFromDate.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(179, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 20);
            this.label2.TabIndex = 35;
            this.label2.Text = "To";
            // 
            // txtToDate
            // 
            this.txtToDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToDate.Location = new System.Drawing.Point(183, 74);
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.Size = new System.Drawing.Size(135, 26);
            this.txtToDate.TabIndex = 34;
            // 
            // reportViewer1
            // 
            this.reportViewer1.BackColor = System.Drawing.Color.OldLace;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.FeesReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "StudentInfo.Reports.RptFees.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(28, 134);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(588, 246);
            this.reportViewer1.TabIndex = 36;
            // 
            // standardMasterTableAdapter
            // 
            this.standardMasterTableAdapter.ClearBeforeFill = true;
            // 
            // sectionMasterTableAdapter
            // 
            this.sectionMasterTableAdapter.ClearBeforeFill = true;
            // 
            // feesReportTableAdapter1
            // 
            this.feesReportTableAdapter1.ClearBeforeFill = true;
            // 
            // FeesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(206)))), ((int)(((byte)(254)))));
            this.BackgroundImage = global::StudentInfo.Properties.Resources.BackIMG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(646, 409);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtToDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtFromDate);
            this.Controls.Add(this.btnshow);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ddlSection);
            this.Controls.Add(this.ddlStandard);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FeesReport";
            this.Text = "FeesReport";
            this.Load += new System.EventHandler(this.FeesReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FeesReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionMasterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.standardMasterBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddlSection;
        private System.Windows.Forms.ComboBox ddlStandard;
        private System.Windows.Forms.Button btnshow;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker txtFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtToDate;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Data.StudentDatabase studentDatabase;
        private System.Windows.Forms.BindingSource standardMasterBindingSource;
        private Data.StudentDatabaseTableAdapters.StandardMasterTableAdapter standardMasterTableAdapter;
        private System.Windows.Forms.BindingSource sectionMasterBindingSource;
        private Data.StudentDatabaseTableAdapters.SectionMasterTableAdapter sectionMasterTableAdapter;
        private System.Windows.Forms.BindingSource FeesReportBindingSource;
        private Data.StudentDatabaseTableAdapters.FeesReportTableAdapter feesReportTableAdapter1;
    }
}