using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentInfo.Data
{
    public partial class ExcelImport : Form
    {
        DataLogs dLog = new DataLogs();
        DateTime systemdatetime=new DateTime();
        delegate void SetControlText(Control ct,string text);
        private void SetText(Control ct,string text)
        {
            if (ct.InvokeRequired)
            {
                SetControlText d = new SetControlText(SetText);
                this.Invoke(d,new object[] { text });
            }
            else
            {
                ct.Text = text;
            }
        }
        delegate void SetProgressBar(ProgressBar pb, int value);
        private void SetValue(ProgressBar pb,int value)
        {
            if (pb.InvokeRequired)
            {
                SetProgressBar d = new SetProgressBar(SetValue);
                this.Invoke(d, new int[] { value });
            }
            else
            {
                pb.Value = value;
            }
        }

        DataTable dt = new DataTable();
        DataRow dr;
        DAL dal = new DAL();
        public ExcelImport()
        {
            InitializeComponent();
            InitializeDatatable();
        }

        private void InitializeDatatable()
        {
            try
            {
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("StandardID", typeof(int));
                dt.Columns.Add("SectionID", typeof(int));
                dt.Columns.Add("DOB", typeof(DateTime));
                dt.Columns.Add("FatherName", typeof(string));
                dt.Columns.Add("Address", typeof(string));
                dt.Columns.Add("MobNo", typeof(string));
            }
            catch(Exception ex)
            {
                dLog.SaveLogs("ExcelImport InitializeDatatable " + ex.Message);
            }     
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Start();

                openFileDialog1.ShowDialog();
            }
            catch(Exception ex)
            {
                dLog.SaveLogs("ExcelImport btnUpload_Click " + ex.Message);
            }

        }

        private void DoWork()
        {
            try
            {
               
                    string path = openFileDialog1.FileName;
                    string data = File.ReadAllText(path);
                    string[] Lines = data.Split('\n');
                    string[] sdata;
                    int StandardID = 0;
                    int SectionID = 0;
                    dt.Rows.Clear();
                    for (int i = 1; i < Lines.Length; i++)
                    {
                        sdata = Lines[i].Split(',');
                        if (sdata.Length > 4)
                        {
                            StandardID = 0;
                            SectionID = 0;
                            dr = dt.NewRow();
                            dr["Name"] = sdata[0].Trim();
                            StandardID = GetStandardID(sdata[1]);
                            if(StandardID==0)
                            {
                                MessageBox.Show("Please Check Standard entry Present in Master \nTry Again with correct format", "Warning", MessageBoxButtons.OK);
                                timer1.Stop();
                                return;
                            }
                            dr["StandardID"] = StandardID;
                            SectionID = GetSectionID(sdata[2], StandardID);
                            if (StandardID == 0)
                            {
                                MessageBox.Show("Please Check Section entry Present in Master \nTry Again with correct format", "Warning", MessageBoxButtons.OK);

                                timer1.Stop();
                                return;
                            }
                            dr["SectionID"] = SectionID;
                            if (DateTime.TryParse(sdata[3], out systemdatetime))
                            {
                                dr["DOB"] = Convert.ToDateTime(sdata[3]);
                            }
                            else
                            {
                                MessageBox.Show("Please Check Date Format(dd/MM/yy) \nTry Again with correct format", "Warning", MessageBoxButtons.OK);
                                timer1.Stop();
                                return;
                            }
                            dr["FatherName"] = sdata[4].Trim();
                            dr["Address"] = sdata[5].Trim();
                            if(dr["MobNo"].ToString().Length>10)
                            {
                                MessageBox.Show("Please Check Mobile No Column(Lenght=10) \nTry Again with correct format", "Warning", MessageBoxButtons.OK);
                                return;
                            }
                            dr["MobNo"] = sdata[6].Trim();

                            dt.Rows.Add(dr);
                        }

                    }

                    SQLBulkCopyInsert(dt);
                    MessageBox.Show("Data Imported Successfully", "Import", MessageBoxButtons.OK);
                
                    timer1.Stop();
                  // SetValue(progressBar1, 0);

            }
            catch (Exception ex)
            {
                dLog.SaveLogs("ExcelImport DoWork " + ex.Message);
                MessageBox.Show("Something Went Wrong \nTry Again with correct format", "Warning", MessageBoxButtons.OK);
                timer1.Stop();
            }
        }
        private int GetStandardID(string Standard)
        {
            int returnval = 0;
            try
            {
                if (dal.con.State != ConnectionState.Open)
                {
                    dal.con.Open();
                }

                using (SqlCommand cmd=new SqlCommand("select standardid from standardmaster where standardname=@StandardName",dal.con))
                {
                    cmd.Parameters.AddWithValue("@StandardName", Standard.Trim());
                    if (Convert.ToString(cmd.ExecuteScalar()) != string.Empty)
                    {
                        returnval = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch(Exception ex)
            {
                dLog.SaveLogs("ExcelImport GetStandardID " + ex.Message);
            }
            finally
            {
                if(dal.con.State!=ConnectionState.Closed)
                {
                    dal.con.Close();
                }
            }
            return returnval;
        }

        private int GetSectionID(string Section,int StandardID)
        {
            int returnval = 0;
            try
            {
                if (dal.con.State != ConnectionState.Open)
                {
                    dal.con.Open();
                }

                using (SqlCommand cmd = new SqlCommand("select sectionid from sectionmaster where SectionName=@SectionName and StandardID=@StandardID", dal.con))
                {
                    cmd.Parameters.AddWithValue("@SectionName", Section.Trim());
                    cmd.Parameters.AddWithValue("@StandardID", StandardID);
                    if (Convert.ToString(cmd.ExecuteScalar()) != string.Empty)
                    {
                        returnval = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                dLog.SaveLogs("ExcelImport GetSectionID " + ex.Message);
            }
            finally

            {
                if (dal.con.State != ConnectionState.Closed)
                {
                    dal.con.Close();
                }
            }
            return returnval;
        }
        private void SQLBulkCopyInsert(DataTable dt)
        {
            try
            {
                if(dal.con.State!=ConnectionState.Open)
                {
                    dal.con.Open();
                }
                using (SqlBulkCopy objbulk = new SqlBulkCopy(dal.con))
                {
                    objbulk.DestinationTableName = "StudentDtls";
                    objbulk.ColumnMappings.Add("Name", "Name");
                    objbulk.ColumnMappings.Add("StandardID", "StandardID");
                    objbulk.ColumnMappings.Add("SectionID", "SectionID");
                    objbulk.ColumnMappings.Add("DOB", "DOB");
                    objbulk.ColumnMappings.Add("FatherName", "FatherName");
                    objbulk.ColumnMappings.Add("Address", "Address");
                    objbulk.ColumnMappings.Add("MobNo", "MobNo");
                    objbulk.WriteToServer(dt);
                }
            }
            catch(Exception ex)
            {
                dLog.SaveLogs("ExcelImport SQLBulkCopyInsert " + ex.Message);
                MessageBox.Show("Something Went Wrong \nTry Again with correct format", "Warning", MessageBoxButtons.OK);
                timer1.Stop();
                return;
            }
            finally
            {
                if (dal.con.State != ConnectionState.Closed)
                {
                    dal.con.Close();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (progressBar1.Value == 100)
                {
                    SetValue(progressBar1, 0);
                }
                else
                {
                    SetValue(progressBar1, progressBar1.Value + 10);
                }
            }
            catch(Exception ex)
            {
                dLog.SaveLogs("ExcelImport timer1_Tick " + ex.Message);
            }
        }
        
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                System.Threading.Thread td = new System.Threading.Thread(DoWork);
                td.Start();
            }
            catch(Exception ex)
            {
                dLog.SaveLogs("ExcelImport openFileDialog1_FileOk " + ex.Message);
            }
        }

        private void ExcelImport_Load(object sender, EventArgs e)
        {

            
        }
    }
}
