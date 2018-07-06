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
    public partial class ExpensiveReport : Form
    {
        public ExpensiveReport()
        {
            InitializeComponent();
        }
        DataLogs dLog = new DataLogs();
        private void ExpensiveReport_Load(object sender, EventArgs e)
        {
            try
            { 
            // TODO: This line of code loads data into the 'studentDatabase.Expensive' table. You can move, or remove it, as needed.
            this.expensiveTableAdapter.Fill(this.studentDatabase.Expensive);
                
            this.reportViewer1.RefreshReport();
            }
            catch(Exception ex)
            {
                dLog.SaveLogs("ExpensiveReport btnshow_Click "+ex.Message);
            }

}

        private void btnshow_Click(object sender, EventArgs e)
        {
            try
            {
                this.expensiveTableAdapter.FillBy(this.studentDatabase.Expensive, Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text));
                this.reportViewer1.RefreshReport();
            }
            catch(Exception ex)
            {
                dLog.SaveLogs("ExpensiveReport btnshow_Click "+ex.Message);
            }
        }
    }
}
