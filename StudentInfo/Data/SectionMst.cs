using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentInfo.Data
{
    public partial class SectionMst : Form
    {
        DataLogs dLog = new DataLogs();
        DataTable dt = new DataTable();
        bool isUpdate = false;
        Int16 SectionID = 0;
        DAL dal = new DAL();
        public SectionMst()
        {
            InitializeComponent();
        }

        private void SectionMst_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentDatabase.StandardMaster' table. You can move, or remove it, as needed.
            this.standardMasterTableAdapter.Fill(this.studentDatabase.StandardMaster);
            BindGrid();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }
        private void BindGrid()
        {
            dt.Rows.Clear();
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Select sc.*,sm.StandardName from SectionMaster sc inner join  StandardMaster sm on sm.StandardID=sc.StandardID order by StandardName,SectionName", dal.con))
                {
                    da.Fill(dt);
                    gvDtls.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                dLog.SaveLogs("SectionMst BindGrid " + ex.Message);
            }

        }
        private void ClearData()
        {
            txtSectionName.Text = string.Empty;
            SectionID = 0;
            isUpdate = false;
        }      

        private void gvDtls_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtSectionName.Text = gvDtls.Rows[e.RowIndex].Cells["SectionName"].Value.ToString();
                ddlStandard.SelectedValue = gvDtls.Rows[e.RowIndex].Cells["Standard"].Value;
                SectionID = Convert.ToInt16(gvDtls.Rows[e.RowIndex].Cells["SectionID1"].Value);
                isUpdate = true;
            }
            catch(Exception ex)
            {
                dLog.SaveLogs("SectionMst gvDtls_CellDoubleClick " + ex.Message);
            }
        }

        private void SaveData()
        {
            if (dal.con.State != ConnectionState.Open)
            {
                dal.con.Open();
            }
            if (txtSectionName.Text == string.Empty)
            {
                errorProvider1.SetError(txtSectionName, "*");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (Convert.ToString(ddlStandard.SelectedValue) == string.Empty)
            {
                MessageBox.Show("Select Standard & Section \n Add Master Entry if Not Present", "Mandatory", MessageBoxButtons.OK);
                return;
            }
            try
            {
                using (SqlCommand cmd1 = new SqlCommand("Select count(1) from SectionMaster where SectionName=@SectionName and StandardID=@StandardID and SectionID <> @SectionID ", dal.con))
                {
                    cmd1.Parameters.AddWithValue("@SectionID", SectionID);
                    cmd1.Parameters.AddWithValue("@StandardID", ddlStandard.SelectedValue.ToString());
                    cmd1.Parameters.AddWithValue("@SectionName", txtSectionName.Text);
                    if (Convert.ToInt16(cmd1.ExecuteScalar()) > 0)
                    {

                        MessageBox.Show("Duplicate Entry Exists", "Duplicate", MessageBoxButtons.OK);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                dLog.SaveLogs("SectionMst SaveData " + ex.Message);
            }


            try
            {
                if (isUpdate == true)
                {
                    using (SqlCommand cmd = new SqlCommand("update SectionMaster set SectionName=@SectionName,StandardID=@StandardID where SectionID=@SectionID ", dal.con))

                    {
                        cmd.Parameters.AddWithValue("@StandardID", ddlStandard.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@SectionID", SectionID);
                        cmd.Parameters.AddWithValue("@SectionName", txtSectionName.Text);
                        if (SectionID != 0)
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

                    using (SqlCommand cmd = new SqlCommand("insert into SectionMaster(SectionName,StandardID) values(@SectionName,@StandardID) ", dal.con))

                    {
                        cmd.Parameters.AddWithValue("@StandardID", ddlStandard.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@SectionName", txtSectionName.Text);
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
                dLog.SaveLogs("SectionMst SaveData " + ex.Message);
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
