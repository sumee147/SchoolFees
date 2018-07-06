using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
namespace StudentInfo.Data
{
    public partial class StandardMst : Form
    {
        DataLogs dLog = new DataLogs();
        DataTable dt = new DataTable();
        bool isUpdate = false;
        Int16 StandardID = 0;
        public StandardMst()
        {
            InitializeComponent();
        }
        DAL dal = new DAL();
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void BindGrid()
        {
            dt.Rows.Clear();
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Select * from StandardMaster", dal.con))
                {
                    da.Fill(dt);
                    gvDtls.DataSource = dt;

                }
            }
            catch(Exception ex)
            {
                dLog.SaveLogs("StandardMst BindGrid " + ex.Message);
            }

        }
        private void ClearData()
        {
            txtStandard.Text = string.Empty;
            StandardID = 0;
            isUpdate = false;
        }

        private void StandardMst_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void gvDtls_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtStandard.Text = gvDtls.Rows[e.RowIndex].Cells["StandardName"].Value.ToString();
                StandardID = Convert.ToInt16(gvDtls.Rows[e.RowIndex].Cells["Standard"].Value);
                isUpdate = true;
            }
            catch(Exception ex)
            {
                dLog.SaveLogs("StandardMst gvDtls_CellDoubleClick " + ex.Message);
            }     

        }

        private void SaveData()
        {
            if (dal.con.State != ConnectionState.Open)
            {
                dal.con.Open();
            }
            if (txtStandard.Text == string.Empty)
            {
                errorProvider1.SetError(txtStandard, "*");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }

            try
            {
                using (SqlCommand cmd1 = new SqlCommand("Select count(1) from StandardMaster where StandardName=@StandardName and StandardID <> @StandardID ",dal.con))
                {
                    cmd1.Parameters.AddWithValue("@StandardID", StandardID);
                    cmd1.Parameters.AddWithValue("@StandardName", txtStandard.Text);
                    if(Convert.ToInt16(cmd1.ExecuteScalar())>0)
                    {

                        MessageBox.Show("Duplicate Entry Exists", "Duplicate", MessageBoxButtons.OK);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {

                dLog.SaveLogs(ex.Message);
            }


            try
            {
                if (isUpdate == true)
                {
                    using (SqlCommand cmd = new SqlCommand("update StandardMaster set StandardName=@StandardName where StandardID=@StandardID ", dal.con))

                    {
                        cmd.Parameters.AddWithValue("@StandardID", StandardID);
                        cmd.Parameters.AddWithValue("@StandardName", txtStandard.Text);
                        if (StandardID != 0)
                        {
                            int i = cmd.ExecuteNonQuery();
                            if (i > 0)
                            {
                                MessageBox.Show("Data Updated Successfully", "Update", MessageBoxButtons.OK);
                                ClearData();
                                BindGrid();
                            }
                        }

                    }
                }
                else
                {

                    using (SqlCommand cmd = new SqlCommand("insert into StandardMaster(StandardName) values(@StandardName) ", dal.con))

                    {
                        cmd.Parameters.AddWithValue("@StandardName", txtStandard.Text);
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Data Saved Successfully", "Save", MessageBoxButtons.OK);
                            ClearData();
                            BindGrid();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                dLog.SaveLogs("StandardMst SaveData " + ex.Message);
            }
            finally
            {
                if (dal.con.State != ConnectionState.Closed)
                {
                    dal.con.Close();
                }
            }
        }
    }
}
