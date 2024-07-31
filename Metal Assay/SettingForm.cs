using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metal_Assay
{
    public partial class SettingForm : Form
    {
        private Main MainForm;
        public SettingForm(Main mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
        }

        string connection_string = @"server=192.168.0.36;uid=view1;pwd=Assay123!;database=assay";
        //string connection_string = @"server=localhost;uid=root;pwd=Assay123!;database=assay";
        string sql = "";
        private void SettingForm_Load(object sender, EventArgs e)
        {
            LoadLossTable();
            SettingLossdataGridView.CurrentCell = SettingLossdataGridView.Rows[0].Cells[0];
            SettingLossEditMinTextbox.Text = SettingLossdataGridView.CurrentRow.Cells[0].Value.ToString();
            SettingLossEditMaxTextbox.Text = SettingLossdataGridView.CurrentRow.Cells[1].Value.ToString();
            SettingEditLossTextbox.Text = SettingLossdataGridView.CurrentRow.Cells[2].Value.ToString();
            LoadCompanyInfo();
        }
        //Loss Tab
        private void LoadLossTable()
        {
            var con = new MySqlConnection(connection_string);
            con.Open();

            sql = "SELECT low, high, pct, id FROM loss ORDER BY low DESC";
            var cmd = new MySqlCommand(sql, con);

            MySqlDataReader data_reader = cmd.ExecuteReader();

            SettingLossdataGridView.Rows.Clear();
            SettingLossdataGridView.Refresh();

            List<DataGridViewRow> FW_rows = new List<DataGridViewRow>();
            if (data_reader.HasRows)
            {
                while (data_reader.Read())
                {
                    DataGridViewRow newLossRow = new DataGridViewRow() { Height = 30 };
                    newLossRow.CreateCells(SettingLossdataGridView);
                    newLossRow.Cells[0].Value = data_reader.GetString("low");
                    newLossRow.Cells[1].Value = data_reader.GetString("high");
                    newLossRow.Cells[2].Value = data_reader.GetString("pct");
                    newLossRow.Cells[3].Value = data_reader.GetString("id");
                    FW_rows.Insert(0, newLossRow);
                }
            }
            data_reader.Close();
            SettingLossdataGridView.Rows.AddRange(FW_rows.ToArray());
            con.Close();

        }

        private void SettingLossdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SettingLossEditMinTextbox.Text = SettingLossdataGridView.CurrentRow.Cells[0].Value.ToString();
            SettingLossEditMaxTextbox.Text = SettingLossdataGridView.CurrentRow.Cells[1].Value.ToString();
            SettingEditLossTextbox.Text = SettingLossdataGridView.CurrentRow.Cells[2].Value.ToString();
        }

        private void SettingLossNewButton_Click(object sender, EventArgs e)
        {
            try
            {
                var con = new MySqlConnection(connection_string);
                con.Open();
                string cmdText = "INSERT INTO loss (low, high, pct, created, modified) VALUES (@low, @high, @pct, @created, @modified)";
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                cmd.Parameters.AddWithValue("@created", DateTime.Now);
                cmd.Parameters.AddWithValue("@modified", DateTime.Now);
                cmd.Parameters.AddWithValue("@low", SettingLossNewMinTextbox.Text);
                cmd.Parameters.AddWithValue("@high", SettingLossNewMaxTextbox.Text);
                cmd.Parameters.AddWithValue("@pct", SettingLossNewLossTextbox.Text);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadLossTable();
        }

        private void SettingLossEditButton_Click(object sender, EventArgs e)
        {
            if (SettingLossEditButton.Text == "EDIT")
            {
                //Unlock textboxes
                SettingLossEditMinTextbox.Enabled = true;
                SettingLossEditMaxTextbox.Enabled = true;
                SettingEditLossTextbox.Enabled = true;
                SettingLossEditButton.Text = "SAVE";
            }
            else if (SettingLossEditButton.Text == "SAVE")
            {
                //Save value
                try
                {
                    var con = new MySqlConnection(connection_string);
                    sql = $"UPDATE loss SET modified=@modified,low=@low,high=@high,pct=@pct WHERE id={SettingLossdataGridView.CurrentRow.Cells[3].Value.ToString()}";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@modified", DateTime.Now);
                    cmd.Parameters.AddWithValue("@low", SettingLossEditMinTextbox.Text);
                    cmd.Parameters.AddWithValue("@high", SettingLossEditMaxTextbox.Text);
                    cmd.Parameters.AddWithValue("@pct", SettingEditLossTextbox.Text);
                    cmd.ExecuteReader();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //Lock textboxes
                SettingLossEditMinTextbox.Enabled = false;
                SettingLossEditMaxTextbox.Enabled = false;
                SettingEditLossTextbox.Enabled = false;
                SettingLossEditButton.Text = "EDIT";

                LoadLossTable();
            }
        }
        //Company Info Tab
        private void LoadCompanyInfo()
        {
            var con = new MySqlConnection(connection_string);
            con.Open();

            sql = "SELECT name, addressone, addresstwo, phone, phonetwo, companyemail, mailpw FROM user WHERE role = 'worker'";
            var cmd = new MySqlCommand(sql, con);

            MySqlDataReader data_reader = cmd.ExecuteReader();

            if (data_reader.HasRows)
            {
                while (data_reader.Read())
                {
                    SettingCompanyInfoNameTextbox.Text = data_reader.GetString("name");
                    SettingCompanyInfoAddressOneTextbox.Text = data_reader.GetString("addressone");
                    SettingCompanyInfoAddressTwoTextbox.Text = data_reader.GetString("addresstwo");
                    SettingCompanyInfoPhoneOneTextbox.Text = data_reader.GetString("phone");
                    SettingCompanyInfoPhoneTwoTextbox.Text = data_reader.GetString("phonetwo");
                    SettingCompanyInfoEmailTextbox.Text = data_reader.GetString("companyemail");
                    SettingCompanyInfoEmailPWTextbox.Text = data_reader.GetString("mailpw");
                }
            }
            data_reader.Close();
            con.Close();
        }

        private void SettingCompanyInfoSaveButton_Click(object sender, EventArgs e)
        {
            //Save value
            try
            {
                var con = new MySqlConnection(connection_string);
                sql = $"UPDATE user SET name=@name,addressone=@addressone,addresstwo=@addresstwo,phone=@phone,phonetwo=@phonetwo,companyemail=@companyemail,mailpw=@mailpw WHERE role = 'worker'";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                cmd.Parameters.AddWithValue("@name", SettingCompanyInfoNameTextbox.Text);
                cmd.Parameters.AddWithValue("@addressone", SettingCompanyInfoAddressOneTextbox.Text);
                cmd.Parameters.AddWithValue("@addresstwo", SettingCompanyInfoAddressTwoTextbox.Text);
                cmd.Parameters.AddWithValue("@phone", SettingCompanyInfoPhoneOneTextbox.Text);
                cmd.Parameters.AddWithValue("@phonetwo", SettingCompanyInfoPhoneTwoTextbox.Text);
                cmd.Parameters.AddWithValue("@companyemail", SettingCompanyInfoEmailTextbox.Text);
                cmd.Parameters.AddWithValue("@mailpw", SettingCompanyInfoEmailPWTextbox.Text);
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Company Info Updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                MainForm.LoadCompanyInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        //Printing
        private void SettingPrintingVerticalButton_Click(object sender, EventArgs e)
        {
            try
            {
                var con = new MySqlConnection(connection_string);
                sql = $"UPDATE user SET orientation=@orientation WHERE role = 'worker'";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                cmd.Parameters.AddWithValue("@orientation", "vertical");
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Orientation Changed to Vertical.", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SettingPrintingLandscapeButton_Click(object sender, EventArgs e)
        {
            try
            {
                var con = new MySqlConnection(connection_string);
                sql = $"UPDATE user SET orientation=@orientation WHERE role = 'worker'";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                cmd.Parameters.AddWithValue("@orientation", "landscape");
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Orientation Changed to Landscape.", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
