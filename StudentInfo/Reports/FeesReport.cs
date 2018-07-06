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
    public partial class FeesReport : Form
    {
        public FeesReport()
        {
            InitializeComponent();
        }
        DataLogs dLog = new DataLogs();
        private void FeesReport_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'studentDatabase.StandardMaster' table. You can move, or remove it, as needed.
                this.standardMasterTableAdapter.Fill(this.studentDatabase.StandardMaster);
            BindSectionDDL();
            this.feesReportTableAdapter1.Fill(this.studentDatabase.FeesReport);
            this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                dLog.SaveLogs("At FeesReport_Load " + ex.Message);
            }

        }
        private void BindSectionDDL()
        {
            this.sectionMasterTableAdapter.Fill(this.studentDatabase.SectionMaster, Convert.ToInt16(ddlStandard.SelectedValue));
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            try
            {
                this.feesReportTableAdapter1.FillBy(this.studentDatabase.FeesReport, Convert.ToInt16(ddlStandard.SelectedValue), Convert.ToInt16(ddlSection.SelectedValue), Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text));
                this.reportViewer1.RefreshReport();
            }
            catch(Exception ex)
            {
                dLog.SaveLogs("FeesReport btnshow_Clickn"+ex.Message);
            }
        }

        private void ddlStandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSectionDDL(); 
        }
    }
}
