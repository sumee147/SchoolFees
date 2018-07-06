using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentInfo.Data
{
    public partial class StartupScreen : Form
    {
         public StartupScreen()
        {
            InitializeComponent();
        }
        DataLogs dLog = new DataLogs();
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();

                Main mm = new Main();
                mm.StartPosition = FormStartPosition.CenterScreen;
                mm.Show();
                this.Hide();
            }
            catch(Exception ex)
            {
                dLog.SaveLogs("StartupScreen timer1_Tick " + ex.Message);
            }
           
        }
    }
}
