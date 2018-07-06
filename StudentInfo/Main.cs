using StudentInfo.Data;
using StudentInfo.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentInfo
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        DataLogs dLog = new DataLogs();
        private void OpenForm(Form frm,bool isResizable)
        {
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);          
         
        }

        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StandardMst frmStandard = new StandardMst();
            OpenForm(frmStandard,false);
        }

        private void sectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SectionMst frmSection = new SectionMst();
            OpenForm(frmSection, false);
        }

        private void studentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentInfo frmStudent = new frmStudentInfo();
            OpenForm(frmStudent, false);

        }

        private void expensiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Expensive frmExp = new Expensive();
            OpenForm(frmExp, false);
        }

        private void sajakaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SajakaDtls frmSajaka = new SajakaDtls();
            OpenForm(frmSajaka,false);
        }

        private void feesDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FeesReport frmFeeRpt = new FeesReport();
            OpenForm(frmFeeRpt,false);
        }

        private void sajakaDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SajakaReport frmSajakaRpt = new SajakaReport();
            OpenForm(frmSajakaRpt, false);
        }

        private void feesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FeesDtls frmFees = new FeesDtls();
            OpenForm(frmFees, false);
        }

        private void expensiveDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpensiveReport frmExp = new ExpensiveReport();
            OpenForm(frmExp, false);
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            Application.Exit();
        }

        private void importExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelImport frmExp = new ExcelImport();
            OpenForm(frmExp, false);
        }
    }
}
