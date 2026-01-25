using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Windows.Forms;

namespace Metal_Assay
{
    public partial class NewCustomer : Form
    {
        private Main MainForm;
        public string clicksource { get; set; }
        public string customer { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string fax { get; set; }
        public string area { get; set; }
        public string billing { get; set; }
        public string coupon { get; set; }
        public NewCustomer(Main mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
        }
        string connection_string = GlobalConfig.ConnectionString;
        string sql = "";
        private void NewCustomer_Load(object sender, EventArgs e)
        {
            if (clicksource == "EDIT")
            {
                CustomerNameTextBox.Text = customer;
                PhoneTextBox.Text = phone;
                EmailTextBox.Text = email;
                FaxTextBox.Text = fax;
                OrientationComboBox.Text = area;
                BillingComboBox.Text = billing;
                CouponComboBox.Text = coupon;
                AddCustomerButton.Text = "EDIT";
            }
            else
            {
                CustomerNameTextBox.Enabled = true;
            }
            WriteToLogFile("New/Edit Customer Form Opened.");
        }
        private void WriteToLogFile(string content)
        {
            using (StreamWriter sw = File.AppendText($".\\log\\{DateTime.Today.ToString("yyyyMdd")}.txt"))
            {
                sw.WriteLine($"[{DateTime.Now}]:{content}");
            }
        }
        private void AddCustomerButton_Click(object sender, EventArgs e)
        {
            if (clicksource == "NEW")
            {
                try
                {
                    var con = new MySqlConnection(connection_string);
                    con.Open();
                    string cmdText = "INSERT INTO user (created, modified, name, phone, email, fax, area, billing, coupon,role) VALUES (@created, @modified, @name, @phone, @email, @fax, @area, @billing, @coupon,@role)";
                    MySqlCommand cmd = new MySqlCommand(cmdText, con);
                    cmd.Parameters.AddWithValue("@created", DateTime.Now);
                    cmd.Parameters.AddWithValue("@modified", DateTime.Now);
                    cmd.Parameters.AddWithValue("@name", CustomerNameTextBox.Text);
                    cmd.Parameters.AddWithValue("@phone", PhoneTextBox.Text);
                    cmd.Parameters.AddWithValue("@email", EmailTextBox.Text);
                    cmd.Parameters.AddWithValue("@fax", FaxTextBox.Text);
                    cmd.Parameters.AddWithValue("@area", OrientationComboBox.Text);
                    cmd.Parameters.AddWithValue("@role", "customer");
                    if (BillingComboBox.Text == "YES")
                    {
                        cmd.Parameters.AddWithValue("@billing", true);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@billing", false);
                    }
                    if (CouponComboBox.Text == "YES")
                    {
                        cmd.Parameters.AddWithValue("@coupon", true);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@coupon", false);
                    }
                    cmd.ExecuteNonQuery();
                    con.Close();
                    WriteToLogFile($"New Customer. Name:{CustomerNameTextBox.Text}, Phone:{PhoneTextBox.Text}, Email:{EmailTextBox.Text}, Area:{OrientationComboBox.Text}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    var con = new MySqlConnection(connection_string);
                    sql = $"UPDATE user SET modified=@modified,name=@name,phone=@phone,email=@email,fax=@fax,area=@area,billing=@billing,coupon=@coupon WHERE name='{CustomerNameTextBox.Text}'";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@modified", DateTime.Now);
                    cmd.Parameters.AddWithValue("@name", CustomerNameTextBox.Text);
                    cmd.Parameters.AddWithValue("@phone", PhoneTextBox.Text);
                    cmd.Parameters.AddWithValue("@email", EmailTextBox.Text);
                    cmd.Parameters.AddWithValue("@fax", FaxTextBox.Text);
                    cmd.Parameters.AddWithValue("@area", OrientationComboBox.Text);

                    if (BillingComboBox.Text == "YES")
                    {
                        cmd.Parameters.AddWithValue("@billing", true);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@billing", false);
                    }
                    if (CouponComboBox.Text == "YES")
                    {
                        cmd.Parameters.AddWithValue("@coupon", true);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@coupon", false);
                    }
                    cmd.ExecuteReader();
                    con.Close();
                    WriteToLogFile($"Updated Customer. Name:{CustomerNameTextBox.Text}, Phone:{PhoneTextBox.Text}, Email:{EmailTextBox.Text}, Area:{OrientationComboBox.Text}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            MainForm.LoadCustomerTable();
            MainForm.LoadCustomerCustomerList();
            MainForm.LoadHistoryCustomerList();
            //MainForm.LoadMainPageTable();
            //MainForm.LoadFirstWeightTable();
            //MainForm.LoadLastWeightTable();
            //MainForm.LoadSampleReturnTable();

            //MainForm.MainBackgroundWorker.RunWorkerAsync();
            //MainForm.FWBackgroundWorker.RunWorkerAsync();
            //MainForm.LWBackgroundWorker.RunWorkerAsync();
            //MainForm.SRBackgroundWorker.RunWorkerAsync();
            Close();
        }

        private void AddCustomerButton_MouseEnter(object sender, EventArgs e)
        {
            AddCustomerButton.BackColor = System.Drawing.Color.FromArgb(184, 134, 11); // Darker gold
        }

        private void AddCustomerButton_MouseLeave(object sender, EventArgs e)
        {
            AddCustomerButton.BackColor = System.Drawing.Color.FromArgb(218, 165, 32); // Original gold
        }
    }
}
