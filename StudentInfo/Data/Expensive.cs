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
    public partial class Expensive : Form
    {

        DataLogs dLog = new DataLogs();
        DateTime systemdatetime = new DateTime();
        DataTable dt = new DataTable();
        bool isUpdate = false;
        int  ExpensiveID = 0;
        DAL dal = new DAL();
        public Expensive()
        {
            InitializeComponent();
        }
        private void BindGrid()
        {
            dt.Rows.Clear();
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Select * from Expensive", dal.con))
                {
                    da.Fill(dt);
                    gvDtls.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                dLog.SaveLogs("Expensive BindGrid " + ex.Message);
            }

        }
        private void ClearData()
        {
            txtAmount.Text = string.Empty;
            txtDate.Text = string.Empty;
            txtParticular.Text = string.Empty;
            ExpensiveID = 0;
            isUpdate = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (dal.con.State != ConnectionState.Open)
            {
                dal.con.Open();
            }
            if (txtParticular.Text == string.Empty)
            {
                errorProvider1.SetError(txtParticular, "*");
              
            }
            if (txtAmount.Text == string.Empty)
            {
                errorProvider1.SetError(txtAmount, "*");
               
            }
            if(txtParticular.Text==string.Empty || txtAmount.Text==string.Empty)
            {
                return;
            }
            else
            {
                errorProvider1.Clear();
            }

            try
            {
                using (SqlCommand cmd1 = new SqlCommand("Select count(1) from Expensive where Date=@Date and Amount=@Amount and Particular=@Particular and ExpensiveID <> @ExpensiveID ", dal.con))
                {
                    cmd1.Parameters.AddWithValue("@ExpensiveID", ExpensiveID);
                    if (DateTime.TryParse(txtDate.Text, out systemdatetime))
                    {
                        cmd1.Parameters.AddWithValue("@Date", txtDate.Text);
                    }
                    else
                    {
                        MessageBox.Show("Check System Date Format (dd-MMM-yy)", "Warning", MessageBoxButtons.OK);
                        return;
                    }
                    cmd1.Parameters.AddWithValue("@Amount", txtAmount.Text);
                    cmd1.Parameters.AddWithValue("@Particular", txtParticular.Text);
                    if (Convert.ToInt16(cmd1.ExecuteScalar()) > 0)
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
                    using (SqlCommand cmd = new SqlCommand("update Expensive set Amount=@Amount,Particular=@Particular,Date=@Date where ExpensiveID=@ExpensiveID ", dal.con))

                    {
                        cmd.Parameters.AddWithValue("@ExpensiveID", ExpensiveID);
                        cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
                        cmd.Parameters.AddWithValue("@Particular", txtParticular.Text);
                        if (DateTime.TryParse(txtDate.Text, out systemdatetime))
                        {
                            cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(txtDate.Text));
                        }
                        else
                        {
                            MessageBox.Show("Check System Date Format (dd-MMM-yy)", "Warning", MessageBoxButtons.OK);
                            return;
                        }
                        if (ExpensiveID != 0)
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

                    using (SqlCommand cmd = new SqlCommand("insert into Expensive(Amount,Particular,Date) values(@Amount,@Particular,@Date) ", dal.con))

                    {
                        cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
                        cmd.Parameters.AddWithValue("@Particular", txtParticular.Text);
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
                dLog.SaveLogs("Expensive btnSave_Click " + ex.Message);
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
                txtAmount.Text = gvDtls.Rows[e.RowIndex].Cells["Amount"].Value.ToString();
                txtParticular.Text = gvDtls.Rows[e.RowIndex].Cells["Particular"].Value.ToString();
                txtDate.Text = gvDtls.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                ExpensiveID = Convert.ToInt32(gvDtls.Rows[e.RowIndex].Cells["ExpensiveID1"].Value);
                isUpdate = true;
            }
            catch(Exception ex)
            {
                dLog.SaveLogs("Expensive gvDtls_CellDoubleClick " + ex.Message);
            }

        }

        private void Expensive_Load(object sender, EventArgs e)
        {
            BindGrid();
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
