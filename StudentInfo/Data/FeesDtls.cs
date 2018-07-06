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
    public partial class FeesDtls : Form
    {
        DataLogs dLog = new DataLogs();
        DataTable dt = new DataTable();
        bool isUpdate = false;
        int RecID = 0;
        DAL dal = new DAL();
        PrinterData print = new PrinterData();
        public FeesDtls()
        {
            InitializeComponent();
        }

        private void FeesDtls_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentDatabase.StandardMaster' table. You can move, or remove it, as needed.
            this.standardMasterTableAdapter.Fill(this.studentDatabase.StandardMaster);
            BindSectionDDL();
            BindGrid();
        }
        private void BindSectionDDL()
        {
            this.sectionMasterTableAdapter.Fill(this.studentDatabase.SectionMaster, Convert.ToInt16(ddlStandard.SelectedValue));
            BindStudentDDL();
        }

        private void ddlStandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSectionDDL();
           
        }
        private void ClearData()
        {
            txtAmount.Text = string.Empty;
            txtParticular.Text = string.Empty;           
            RecID = 0;
            isUpdate = false;
        }
        private void BindStudentDDL()
        {
            this.studentDtlsTableAdapter.Fill(this.studentDatabase.StudentDtls, Convert.ToInt16(ddlStandard.SelectedValue),Convert.ToInt16(ddlSection.SelectedValue));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
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
        private void SaveData()
        {
            if (dal.con.State != ConnectionState.Open)
            {
                dal.con.Open();
            }
            if (txtAmount.Text == string.Empty)
            {
                errorProvider1.SetError(txtAmount, "*");
               
            }
            if (txtParticular.Text == string.Empty)
            {
                errorProvider1.SetError(txtParticular, "*");
               
            }
            if (txtAmount.Text == string.Empty || txtParticular.Text == string.Empty )
            {
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (Convert.ToString(ddlStandard.SelectedValue) == string.Empty || Convert.ToString(ddlSection.SelectedValue) == string.Empty || Convert.ToString(ddlStudent.SelectedValue)==string.Empty)
            {
                MessageBox.Show("Select Standard,Section & Student \n Add Master Entry if Not Present", "Mandatory", MessageBoxButtons.OK);
                return;
            }

            //try
            //{
            //    using (SqlCommand cmd1 = new SqlCommand("Select count(1) from FeesDtls where StudentID=@StudentID and SectionID=@SectionID and StandardID=@StandardID and RecID <> @RecID ", dal.con))
            //    {
            //        cmd1.Parameters.AddWithValue("@SectionID", ddlSection.SelectedValue.ToString());
            //        cmd1.Parameters.AddWithValue("@StandardID", ddlStandard.SelectedValue.ToString());
            //        cmd1.Parameters.AddWithValue("@StudentID", ddlStudent.SelectedValue.ToString());
            //        cmd1.Parameters.AddWithValue("@RecID", RecID);
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
                    using (SqlCommand cmd = new SqlCommand("update FeesDtls set StudentID=@StudentID,Particular=@Particular,Amount=@Amount where RecID=@RecID ", dal.con))

                    {
                        //cmd.Parameters.AddWithValue("@StandardID", ddlStandard.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@StudentID", ddlStudent.SelectedValue.ToString());
                        //cmd.Parameters.AddWithValue("@SectionID", ddlSection.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@Particular", txtParticular.Text);
                        cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
                        cmd.Parameters.AddWithValue("@RecID", RecID);
                        if (RecID != 0)
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

                    using (SqlCommand cmd = new SqlCommand("insert into FeesDtls(StudentID,Particular,Amount,Date) values(@StudentID,@Particular,@Amount,GETDATE()) ; select @@IDENTITY ", dal.con))

                    {
                        //cmd.Parameters.AddWithValue("@StandardID", ddlStandard.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@StudentID", ddlStudent.SelectedValue.ToString());
                        //cmd.Parameters.AddWithValue("@SectionID", ddlSection.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@Particular", txtParticular.Text);
                        cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
                        int retunval =Convert.ToInt32( cmd.ExecuteScalar());
                        if (retunval > 0)
                        {
                            print.ReceiptID = retunval;
                            print.RName = ddlStudent.Text;
                            print.RStandard = ddlStandard.Text;
                            print.RSection = ddlSection.Text;
                            print.RParticular = txtParticular.Text;
                            PrintReciept frm = new PrintReciept(print);
                            frm.StartPosition = FormStartPosition.CenterParent;
                            frm.ShowDialog(this);
                            //MessageBox.Show("Data Saved Successfully", "Save", MessageBoxButtons.OK);
                            ClearData();
                            BindGrid();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                dLog.SaveLogs("FeesDtls SaveData"+ex.Message);
            }
            finally
            {
                if (dal.con.State != ConnectionState.Closed)
                {
                    dal.con.Close();
                }
            }
        }

        private void BindGrid()
        {
            dt.Rows.Clear();
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Select fd.StudentID,fd.RecID,sd.StandardName,sc.SectionName,sdl.Name,fd.Amount,fd.Particular,sdl.SectionID,sdl.StandardID,'Print' as PrintData from FeesDtls fd inner join StudentDtls sdl on sdl.StudentID=fd.StudentID inner join StandardMaster sd on sdl.StandardID=sd.StandardID inner join SectionMaster sc on sc.SectionID=sdl.SectionID", dal.con))
                {
                    da.Fill(dt);
                    gvDtls.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                dLog.SaveLogs("FeesDtls BindGrid" + ex.Message);
            }

        }
       
        private void gvDtls_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtAmount.Text = gvDtls.Rows[e.RowIndex].Cells["Amount"].Value.ToString();
                txtParticular.Text = gvDtls.Rows[e.RowIndex].Cells["Particular"].Value.ToString();
                ddlStandard.SelectedValue = gvDtls.Rows[e.RowIndex].Cells["StandardID"].Value;
                ddlSection.SelectedValue = gvDtls.Rows[e.RowIndex].Cells["SectionID"].Value;
                ddlStudent.SelectedValue = gvDtls.Rows[e.RowIndex].Cells["StudentID"].Value;
                RecID = Convert.ToInt16(gvDtls.Rows[e.RowIndex].Cells["RecordID"].Value);
                isUpdate = true;
            }
            catch(Exception ex)
            {
                dLog.SaveLogs("FeesDtls gvDtls_CellDoubleClick" + ex.Message);
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void gvDtls_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {


                print.ReceiptID = Convert.ToInt16(gvDtls.Rows[e.RowIndex].Cells["RecordID"].Value);

                PrintReciept frm = new PrintReciept(print);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
        }
    }
}
