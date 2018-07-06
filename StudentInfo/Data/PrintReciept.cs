using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentInfo.Data
{
    public partial class PrintReciept : Form
    {
        PrinterData print = new PrinterData();
        DataLogs dLog = new DataLogs();
        public PrintReciept()
        {
            InitializeComponent();
        }
        public PrintReciept(object PrinterData)
        {
            print = (PrinterData)PrinterData;
            InitializeComponent();
        }
        private void PrintReciept_Load(object sender, EventArgs e)
        {
            try
            {
                this.printReportTableAdapter.Fill(this.studentDatabase.PrintReport, print.ReceiptID);
                this.reportViewer1.RefreshReport();
                           }
            catch(Exception ex)
            {
                dLog.SaveLogs("PrintReciept gvDtls_CellDoubleClick" + ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
        }

        private void reportViewer1_PrintingBegin(object sender, Microsoft.Reporting.WinForms.ReportPrintEventArgs e)
        {
            e.PrinterSettings.DefaultPageSettings.Landscape = false;

        }
    }
}
