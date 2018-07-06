using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo
{
    internal class PrinterData
    {
        internal int ReceiptID { get; set; }
        internal string RName { get; set; }
        internal string RStandard { get; set; }
        internal string RSection { get; set; }
        internal string RParticular { get; set; }
        internal decimal Amount { get; set; }

    }
    
    internal class DataLogs
    {
        string Log { get; set; }
        BackgroundWorker bw=new BackgroundWorker();
        internal DataLogs()
        {
            bw.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
        }
        internal void SaveLogs(string Data)
        {
            Log = Data;
            if (!bw.IsBusy)
            {
                bw.RunWorkerAsync();
            }
        }
        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if(!Directory.Exists("C:\\SFCLogs\\"))
                {
                    Directory.CreateDirectory("C:\\SFCLogs\\");
                }
                StreamWriter sw = new StreamWriter("C:\\SFCLogs\\" + DateTime.Now.ToString("ddMMyy") + ".log", true);              
                sw.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " :" + Log);
                sw.Flush();
                sw.Dispose();
            }
            catch(Exception ex)
            {

            }
        }
    }
}
