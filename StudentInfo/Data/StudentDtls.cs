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
    public partial class frmStudentInfo : Form
    {
        DataLogs dLog = new DataLogs();
        DataTable dt = new DataTable();
        bool isUpdate = false;
        DateTime systemdatetime = new DateTime();
        int StudentID1 = 0;
        DAL dal = new DAL();
        public frmStudentInfo()
        {
            InitializeComponent();
        }

        private void StudentDtls_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'studentDatabase.StandardMaster' table. You can move, or remove it, as needed.
                this.standardMasterTableAdapter.Fill(this.studentDatabase.StandardMaster);
                BindSectionDDL();
                BindGrid();
            }
            catch (Exception ex)
            {
                dLog.SaveLogs("StudentDtls StudentDtls_Load " + ex.Message);

            }
        }

        private void BindSectionDDL()
        {
            this.sectionMasterTableAdapter.Fill(this.studentDatabase.SectionMaster, Convert.ToInt16(ddlStandard.SelectedValue));
        }

        private void ddlStandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSectionDDL();
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
                using (SqlDataAdapter da = new SqlDataAdapter("Select sd.*,sc.SectionName,sm.StandardName from StudentDtls sd inner join SectionMaster sc on sc.SectionID=sd.SectionID inner join  StandardMaster sm on sm.StandardID=sd.StandardID order by Name,StandardName", dal.con))
                {
                    da.Fill(dt);
                    gvDtls.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                dLog.SaveLogs("StudentDtls BindGrid " + ex.Message);
            }

        }
        private void ClearData()
        {
            txtName.Text = string.Empty;
            txtFatherName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtDOB.Text = string.Empty;
            txtMobNo.Text = string.Empty;
            StudentID1 = 0;
            isUpdate = false;
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
            if (txtAddress.Text == string.Empty)
            {
                errorProvider1.SetError(txtAddress, "*");
                
            }
            if (txtFatherName.Text == string.Empty)
            {
                errorProvider1.SetError(txtFatherName, "*");
               
            }
            if (txtMobNo.Text == string.Empty)
            {
                errorProvider1.SetError(txtMobNo, "*");
               
            }
           if(txtName.Text == string.Empty|| txtMobNo.Text == string.Empty|| txtFatherName.Text == string.Empty|| txtAddress.Text == string.Empty)
            {
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (Convert.ToString(ddlStandard.SelectedValue) == string.Empty || Convert.ToString(ddlSection.SelectedValue) == string.Empty)
            {
                MessageBox.Show("Select Standard & Section \n Add Master Entry if Not Present", "Mandatory", MessageBoxButtons.OK);
                return;
            }
            try
            {
                using (SqlCommand cmd1 = new SqlCommand("Select count(1) from StudentDtls where Name=@Name and MobNo=@MobNo and StandardID=@StandardID and StudentID <> @StudentID ", dal.con))
                {
                    cmd1.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd1.Parameters.AddWithValue("@MobNo", txtMobNo.Text);
                    cmd1.Parameters.AddWithValue("@StandardID", ddlStandard.SelectedValue.ToString());
                    cmd1.Parameters.AddWithValue("@StudentID", StudentID1);
                    if (Convert.ToInt16(cmd1.ExecuteScalar()) > 0)
                    {

                        MessageBox.Show("Duplicate Entry Exists", "Duplicate", MessageBoxButtons.OK);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                dLog.SaveLogs("StudentDtls SaveData " + ex.Message);
            }


            try
            {
                if (isUpdate == true)
                {
                    using (SqlCommand cmd = new SqlCommand("update StudentDtls set Name=@Name,StandardID=@StandardID,SectionID=SectionID,DOB=@DOB,FatherName=@FatherName,Address=@Address,MobNo=@MobNo where StudentID=@StudentID ", dal.con))

                    {
                        cmd.Parameters.AddWithValue("@StudentID", StudentID1);
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        if (DateTime.TryParse(txtDOB.Text, out systemdatetime))
                        {
                            cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(txtDOB.Text));
                        }
                        else
                        {
                            MessageBox.Show("Check System Date Format (dd-MMM-yy)", "Warning", MessageBoxButtons.OK);
                            return;
                        }
                        cmd.Parameters.AddWithValue("@FatherName", txtFatherName.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@MobNo", txtMobNo.Text);
                        cmd.Parameters.AddWithValue("@StandardID", ddlStandard.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@SectionID", ddlSection.SelectedValue.ToString());
                        if (StudentID1 != 0)
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

                    using (SqlCommand cmd = new SqlCommand("insert into StudentDtls(Name,StandardID,SectionID,DOB,FatherName,Address,MobNo) values(@Name,@StandardID,@SectionID,@DOB,@FatherName,@Address,@MobNo)",dal.con))

                    {
                        cmd.Parameters.AddWithValue("@Name",txtName.Text);
                        if (DateTime.TryParse(txtDOB.Text, out systemdatetime))
                        {
                            cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(txtDOB.Text));
                        }
                        else
                        {
                            MessageBox.Show("Check System Date Format (dd-MMM-yy)", "Warning", MessageBoxButtons.OK);
                            return;
                        }
                        cmd.Parameters.AddWithValue("@FatherName", txtFatherName.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@MobNo", txtMobNo.Text);
                        cmd.Parameters.AddWithValue("@StandardID", ddlStandard.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@SectionID", ddlSection.SelectedValue.ToString());
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
                dLog.SaveLogs("StudentDtls SaveData " + ex.Message);
            }
            finally
            {
                if (dal.con.State != ConnectionState.Closed)
                {
                    dal.con.Close();
                }
            }
        }

        private void gvDtls_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtName.Text = gvDtls.Rows[e.RowIndex].Cells["SName"].Value.ToString();
                txtFatherName.Text = gvDtls.Rows[e.RowIndex].Cells["FatherName"].Value.ToString();
                txtMobNo.Text = gvDtls.Rows[e.RowIndex].Cells["MobNo"].Value.ToString();
                txtAddress.Text = gvDtls.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                txtDOB.Text = gvDtls.Rows[e.RowIndex].Cells["DOB"].Value.ToString();
                ddlSection.SelectedValue = gvDtls.Rows[e.RowIndex].Cells["SectionID"].Value;
                ddlStandard.SelectedValue = gvDtls.Rows[e.RowIndex].Cells["StandardID"].Value;
                StudentID1 = Convert.ToInt16(gvDtls.Rows[e.RowIndex].Cells["StudentID"].Value);
                isUpdate = true;
            }
            catch(Exception ex)
            {
                dLog.SaveLogs("StudentDtls gvDtls_CellDoubleClick " + ex.Message);
            }
        }

        private void txtMobNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }
    }
}
