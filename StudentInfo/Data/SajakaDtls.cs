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
    public partial class SajakaDtls : Form
    {
        DataLogs dLog = new DataLogs();
        DataTable dt = new DataTable();
        DateTime systemdatetime = new DateTime();
        bool isUpdate = false;
        int SajakaID1 = 0;
        DAL dal = new DAL();
        public SajakaDtls()
        {
            InitializeComponent();
        }

        private void SajakaDtls_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentDatabase.StandardMaster' table. You can move, or remove it, as needed.
            this.standardMasterTableAdapter.Fill(this.studentDatabase.StandardMaster);
            BindSectionDDL();
            BindGrid();
        }
        private void BindSectionDDL()
        {
            this.sectionMasterTableAdapter.Fill(this.studentDatabase.SectionMaster, Convert.ToInt16(ddlStandard.SelectedValue));
            
        }
        private void BindGrid()
        {
            dt.Rows.Clear();
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Select sj.*,sd.StandardName,sc.SectionName from SajakaDtls sj inner join StandardMaster sd on sj.StandardID=sd.StandardID inner join SectionMaster sc on sc.SectionID=sj.SectionID", dal.con))
                {
                    da.Fill(dt);
                    gvDtls.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                dLog.SaveLogs("SajakaDtls BindGrid " + ex.Message);
            }

        }
        private void ClearData()
        {
            txtAmount.Text = string.Empty;
            txtName.Text = string.Empty;         
            SajakaID1 = 0;
            isUpdate = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {
            if (dal.con.State != ConnectionState.Open)
            {
                dal.con.Open();
            }
            if (txtName.Text == string.Empty)
            {
                errorProvider1.SetError(txtName, "*");
            }
            if (txtAmount.Text == string.Empty)
            {
                errorProvider1.SetError(txtAmount, "*");


            }
            if (txtName.Text==string.Empty || txtAmount.Text==string.Empty)
            {
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (Convert.ToString(ddlStandard.SelectedValue) == string.Empty || Convert.ToString(ddlSection.SelectedValue) == string.Empty)
            {
                MessageBox.Show("Select Standard & Section \nAdd Master Entry if Not Present", "Mandatory", MessageBoxButtons.OK);
                return;
            }
            //try
            //{
            //    using (SqlCommand cmd1 = new SqlCommand("Select count(1) from SajakaDtls where SectionID=@SectionID and StandardID=@StandardID and SajakaID <> @SajakaID ", dal.con))
            //    {
            //        cmd1.Parameters.AddWithValue("@SectionID", ddlSection.SelectedValue.ToString());
            //        cmd1.Parameters.AddWithValue("@StandardID", ddlStandard.SelectedValue.ToString());            //        
            //        cmd1.Parameters.AddWithValue("@SajakaID", SajakaID1);
            //        if (Convert.ToInt16(cmd1.ExecuteScalar()) > 0)
            //        {

            //            MessageBox.Show("Duplicate Entry Exists", "Duplicate", MessageBoxButtons.OK);
            //            return;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{


            //}


            try
            {
                if (isUpdate == true)
                {
                    using (SqlCommand cmd = new SqlCommand("update SajakaDtls set Name=@Name,Date=@Date,SectionID=@SectionID,StandardID=@StandardID,Amount=@Amount where SajakaID=@SajakaID ", dal.con))

                    {
                        cmd.Parameters.AddWithValue("@StandardID", ddlStandard.SelectedValue.ToString());                      
                        cmd.Parameters.AddWithValue("@SectionID", ddlSection.SelectedValue.ToString());                       
                        cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@SajakaID", SajakaID1);
                        if (DateTime.TryParse(txtDate.Text, out systemdatetime))
                        {
                            cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(txtDate.Text));
                        }
                        else
                        {
                            MessageBox.Show("Check System Date Format (dd-MMM-yy)", "Warning", MessageBoxButtons.OK);
                            return;
                        }
                        if (SajakaID1 != 0)
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

                    using (SqlCommand cmd = new SqlCommand("insert into SajakaDtls(Name,SectionID,StandardID,Amount,Date) values(@Name,@SectionID,@StandardID,@Amount,@Date) ", dal.con))

                    {
                        cmd.Parameters.AddWithValue("@StandardID", ddlStandard.SelectedValue.ToString());                       
                        cmd.Parameters.AddWithValue("@SectionID", ddlSection.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
                        if (DateTime.TryParse(txtDate.Text, out systemdatetime))
                        {
                            cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(txtDate.Text));
                        }
                        else
                        {
                            MessageBox.Show("Check System Date Format (dd-MMM-yy)", "Warning", MessageBoxButtons.OK);
                            return;
                        }
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
                dLog.SaveLogs("SajakaDtls SaveData " + ex.Message);
            }
            finally
            {
                if (dal.con.State != ConnectionState.Closed)
                {
                    dal.con.Close();
                }
            }
        }

        private void ddlStandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSectionDDL();
        }

        private void gvDtls_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtAmount.Text = gvDtls.Rows[e.RowIndex].Cells["Amount"].Value.ToString();
                txtName.Text = gvDtls.Rows[e.RowIndex].Cells["SName"].Value.ToString();
                txtDate.Text = gvDtls.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                ddlSection.SelectedValue = gvDtls.Rows[e.RowIndex].Cells["SectionID"].Value;
                ddlStandard.SelectedValue = gvDtls.Rows[e.RowIndex].Cells["StandardID"].Value;
                SajakaID1 = Convert.ToInt16(gvDtls.Rows[e.RowIndex].Cells["SajakaID"].Value);
                isUpdate = true;
            }
            catch(Exception ex)
            {
                dLog.SaveLogs("SajakaDtls gvDtls_CellDoubleClick " + ex.Message);
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }
        public void onlynumwithsinglepoint(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }
    }
}
