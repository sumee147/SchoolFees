using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentInfo.Reports
{
    public partial class SajakaReport : Form
    {
        public SajakaReport()
        {
            InitializeComponent();
        }
        DataLogs dLog = new DataLogs();
        private void SajakaReport_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'studentDatabase.StandardMaster' table. You can move, or remove it, as needed.
                this.standardMasterTableAdapter.Fill(this.studentDatabase.StandardMaster);
                BindSectionDDL();
                this.sajakaReportTableAdapter1.Fill(this.studentDatabase.SajakaReport);
                this.reportViewer1.RefreshReport();
            }
            catch(Exception ex)
            {
                dLog.SaveLogs("SajakaReport SajakaReport_Load " + ex.Message);
            }
        }
        private void BindSectionDDL()
        {
            this.sectionMasterTableAdapter.Fill(this.studentDatabase.SectionMaster, Convert.ToInt16(ddlStandard.SelectedValue));
        }

        private void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSectionDDL();
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            try
            {
                this.sajakaReportTableAdapter1.FillBy(this.studentDatabase.SajakaReport, Convert.ToInt16(ddlSection.SelectedValue), Convert.ToInt16(ddlStandard.SelectedValue), Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text));
                this.reportViewer1.RefreshReport();
            }
            catch(Exception ex)
            {
                dLog.SaveLogs("SajakaReport btnshow_Click " + ex.Message);
            }
        }
    }
}
