namespace StudentInfo.Data
{
    partial class SectionMst
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SectionMst));
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtSectionName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gvDtls = new System.Windows.Forms.DataGridView();
            this.Standard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StandardID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SectionID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SectionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlStandard = new System.Windows.Forms.ComboBox();
            this.standardMasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studentDatabase = new StudentInfo.Data.StudentDatabase();
            this.standardMasterTableAdapter = new StudentInfo.Data.StudentDatabaseTableAdapters.StandardMasterTableAdapter();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gvDtls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.standardMasterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(188)))), ((int)(((byte)(244)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-2, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(430, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add Section";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(327, 70);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtSectionName
            // 
            this.txtSectionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSectionName.Location = new System.Drawing.Point(137, 74);
            this.txtSectionName.MaxLength = 10;
            this.txtSectionName.Name = "txtSectionName";
            this.txtSectionName.Size = new System.Drawing.Size(170, 26);
            this.txtSectionName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(133, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Section Name";
            // 
            // gvDtls
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvDtls.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvDtls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvDtls.BackgroundColor = System.Drawing.Color.OldLace;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvDtls.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvDtls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDtls.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Standard,
            this.StandardID,
            this.SectionID1,
            this.SectionName});
            this.gvDtls.Location = new System.Drawing.Point(24, 132);
            this.gvDtls.Name = "gvDtls";
            this.gvDtls.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvDtls.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvDtls.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gvDtls.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDtls.Size = new System.Drawing.Size(381, 162);
            this.gvDtls.TabIndex = 5;
            this.gvDtls.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDtls_CellDoubleClick);
            // 
            // Standard
            // 
            this.Standard.DataPropertyName = "StandardName";
            this.Standard.HeaderText = "Standard";
            this.Standard.Name = "Standard";
            this.Standard.ReadOnly = true;
            // 
            // StandardID
            // 
            this.StandardID.DataPropertyName = "StandardID";
            this.StandardID.HeaderText = "StandardID";
            this.StandardID.Name = "StandardID";
            this.StandardID.ReadOnly = true;
            this.StandardID.Visible = false;
            // 
            // SectionID1
            // 
            this.SectionID1.DataPropertyName = "SectionID";
            this.SectionID1.HeaderText = "SectionID";
            this.SectionID1.Name = "SectionID1";
            this.SectionID1.ReadOnly = true;
            this.SectionID1.Visible = false;
            // 
            // SectionName
            // 
            this.SectionName.DataPropertyName = "SectionName";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SectionName.DefaultCellStyle = dataGridViewCellStyle3;
            this.SectionName.HeaderText = "Section Name";
            this.SectionName.Name = "SectionName";
            this.SectionName.ReadOnly = true;
            this.SectionName.Width = 230;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(296, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "Double Click To Edit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 31;
            this.label4.Text = "Standard";
            // 
            // ddlStandard
            // 
            this.ddlStandard.DataSource = this.standardMasterBindingSource;
            this.ddlStandard.DisplayMember = "StandardName";
            this.ddlStandard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlStandard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlStandard.FormattingEnabled = true;
            this.ddlStandard.Location = new System.Drawing.Point(24, 74);
            this.ddlStandard.Name = "ddlStandard";
            this.ddlStandard.Size = new System.Drawing.Size(87, 28);
            this.ddlStandard.TabIndex = 30;
            this.ddlStandard.ValueMember = "StandardID";
            // 
            // standardMasterBindingSource
            // 
            this.standardMasterBindingSource.DataMember = "StandardMaster";
            this.standardMasterBindingSource.DataSource = this.studentDatabase;
            // 
            // studentDatabase
            // 
            this.studentDatabase.DataSetName = "StudentDatabase";
            this.studentDatabase.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // standardMasterTableAdapter
            // 
            this.standardMasterTableAdapter.ClearBeforeFill = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // SectionMst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(206)))), ((int)(((byte)(254)))));
            this.BackgroundImage = global::StudentInfo.Properties.Resources.BackIMG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(428, 306);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ddlStandard);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gvDtls);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSectionName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SectionMst";
            this.Text = "SectionMst";
            this.Load += new System.EventHandler(this.SectionMst_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvDtls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.standardMasterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtSectionName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gvDtls;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddlStandard;
        private StudentDatabase studentDatabase;
        private System.Windows.Forms.BindingSource standardMasterBindingSource;
        private StudentDatabaseTableAdapters.StandardMasterTableAdapter standardMasterTableAdapter;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Standard;
        private System.Windows.Forms.DataGridViewTextBoxColumn StandardID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SectionID1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SectionName;
    }
}