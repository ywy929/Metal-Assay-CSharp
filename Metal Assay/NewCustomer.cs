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
                textBox1.Text = customer;
                textBox2.Text = phone;
                textBox3.Text = email;
                textBox4.Text = fax;
                comboBox1.Text = area;
                comboBox2.Text = billing;
                comboBox3.Text = coupon;
                button1.Text = "EDIT";
            }
            else
            {
                textBox1.Enabled = true;
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
        private void button1_Click(object sender, EventArgs e)
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
                    cmd.Parameters.AddWithValue("@name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@phone", textBox2.Text);
                    cmd.Parameters.AddWithValue("@email", textBox3.Text);
                    cmd.Parameters.AddWithValue("@fax", textBox4.Text);
                    cmd.Parameters.AddWithValue("@area", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@role", "customer");
                    if (comboBox2.Text == "YES")
                    {
                        cmd.Parameters.AddWithValue("@billing", true);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@billing", false);
                    }
                    if (comboBox3.Text == "YES")
                    {
                        cmd.Parameters.AddWithValue("@coupon", true);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@coupon", false);
                    }
                    cmd.ExecuteNonQuery();
                    con.Close();
                    WriteToLogFile($"New Customer. Name:{textBox1.Text}, Phone:{textBox2.Text}, Email:{textBox3.Text}, Area:{comboBox1.Text}");
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
                    sql = $"UPDATE user SET modified=@modified,name=@name,phone=@phone,email=@email,fax=@fax,area=@area,billing=@billing,coupon=@coupon WHERE name='{textBox1.Text}'";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@modified", DateTime.Now);
                    cmd.Parameters.AddWithValue("@name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@phone", textBox2.Text);
                    cmd.Parameters.AddWithValue("@email", textBox3.Text);
                    cmd.Parameters.AddWithValue("@fax", textBox4.Text);
                    cmd.Parameters.AddWithValue("@area", comboBox1.Text);

                    if (comboBox2.Text == "YES")
                    {
                        cmd.Parameters.AddWithValue("@billing", true);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@billing", false);
                    }
                    if (comboBox3.Text == "YES")
                    {
                        cmd.Parameters.AddWithValue("@coupon", true);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@coupon", false);
                    }
                    cmd.ExecuteReader();
                    con.Close();
                    WriteToLogFile($"Updated Customer. Name:{textBox1.Text}, Phone:{textBox2.Text}, Email:{textBox3.Text}, Area:{comboBox1.Text}");
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


    }
}
