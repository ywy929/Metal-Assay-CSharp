using iTextSharp.text;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metal_Assay
{
    public partial class AddForm : Form
    {
        private Main MainForm;
        public AddForm(Main form1)
        {
            InitializeComponent();
            MainForm = form1;
        }
        public string customer { get; set; }
        public string date { get; set; }
        public string formcode { get; set; }
        public int item_count { get; set; }
        string connection_string = @"server=192.168.0.36;uid=view1;pwd=Assay123!;database=assay";
        //string connection_string = @"server=localhost;uid=root;pwd=Assay123!;database=assay";
        string sql = "";
        public bool round_color { get; set; }
        List<string> itemcode_check = new List<string>();
        private void AddForm_Load(object sender, EventArgs e)
        {
            AddCustomerContent.Text = customer;
            AddDateLabel.Text = date;
            AddFormCodeContent.Text = formcode;

            //Load itemcodes in formcode
            try
            {
                var con = new MySqlConnection(connection_string);
                con.Open();

                sql = $"SELECT itemcode FROM assayresult WHERE formcode='{AddFormCodeContent.Text}'";
                var cmd = new MySqlCommand(sql, con);

                MySqlDataReader data_reader = cmd.ExecuteReader();

                if (data_reader.HasRows)
                {
                    while (data_reader.Read())
                    {
                        itemcode_check.Add(data_reader.GetString("itemcode"));
                    }
                }
                data_reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                WriteToLogFile($"Exception: {ex.ToString()}");
                MessageBox.Show(ex.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            WriteToLogFile("Add Form Opened.");
        }

        private void AddCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TabToNext(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
            }
        }

        private void DecimalValidation(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }
        int assayrecord_id;
        bool color;
        string sw_to_send;
        DateTime created;
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (AddItemcodeTextbox.Text == "" || AddSampleWeightTextbox.Text == "")
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (item_count >= 14)
            {
                MessageBox.Show("Formcode already has 14 record. Unable to add any more.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int customer_id = 0;
            //Get Customer ID
            try
            {
                var con = new MySqlConnection(connection_string);
                con.Open();

                sql = $"SELECT id FROM user WHERE name='{AddCustomerContent.Text}'";
                var cmd = new MySqlCommand(sql, con);

                MySqlDataReader data_reader = cmd.ExecuteReader();

                if (data_reader.HasRows)
                {
                    while (data_reader.Read())
                    {
                        customer_id = data_reader.GetInt32("id");
                    }
                }
                data_reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                WriteToLogFile($"Exception: {ex.ToString()}");
                MessageBox.Show(ex.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            //Do some validations           

            if (itemcode_check.Contains(AddItemcodeTextbox.Text))
            {
                MessageBox.Show("This formcode already has this itemcode.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                itemcode_check.Add(AddItemcodeTextbox.Text);
            }

            try
            {
                
                var con = new MySqlConnection(connection_string);
                con.Open();
                string cmdText = "INSERT INTO assayresult (created, modified, itemcode, sampleweight, color, customer, formcode) VALUES (@created, @modified, @itemcode, @sampleweight, @color, @customer, @formcode)";
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                cmd.Parameters.AddWithValue("@created", DateTime.Now);
                cmd.Parameters.AddWithValue("@modified", DateTime.Now);
                cmd.Parameters.AddWithValue("@itemcode", AddItemcodeTextbox.Text);
                cmd.Parameters.AddWithValue("@sampleweight", AddSampleWeightTextbox.Text);
                cmd.Parameters.AddWithValue("@color", round_color);
                cmd.Parameters.AddWithValue("@customer", customer_id);
                cmd.Parameters.AddWithValue("@formcode", AddFormCodeContent.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                WriteToLogFile($"Added Item: Customer:{AddCustomerContent.Text}, FC:{AddFormCodeContent.Text}, IC:{AddItemcodeTextbox.Text}, SW:{AddSampleWeightTextbox.Text}");
            }
            catch (Exception ex)
            {
                WriteToLogFile($"Exception: {ex.ToString()}");
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            //Get added record ID
            try
            {
                var con = new MySqlConnection(connection_string);
                con.Open();

                sql = $"SELECT id, sampleweight,created FROM assayresult WHERE formcode='{AddFormCodeContent.Text}' AND itemcode='{AddItemcodeTextbox.Text}'";
                var cmd = new MySqlCommand(sql, con);

                MySqlDataReader data_reader = cmd.ExecuteReader();

                if (data_reader.HasRows)
                {
                    while (data_reader.Read())
                    {
                        assayrecord_id = data_reader.GetInt32("id");
                        //color = data_reader.GetBoolean("color");
                        sw_to_send = data_reader.GetString("sampleweight");
                        created = data_reader.GetDateTime("created");
                    }
                }
                data_reader.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                WriteToLogFile($"Exception: {ex.ToString()}");
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Update Main Left, Main Right, FW, LW, SR
            MainForm.UpdateAdded(customer, AddFormCodeContent.Text, AddItemcodeTextbox.Text, sw_to_send,assayrecord_id.ToString(),created, round_color);
            AddItemcodeTextbox.Text = "";
            AddSampleWeightTextbox.Text = "";
            AddItemcodeTextbox.Focus();
            item_count += 1;
            //MainForm.MainBackgroundWorker.RunWorkerAsync();
            //MainForm.FWBackgroundWorker.RunWorkerAsync();
            //MainForm.LWBackgroundWorker.RunWorkerAsync();
            //MainForm.SRBackgroundWorker.RunWorkerAsync();
        }
        private void WriteToLogFile(string content)
        {
            using (StreamWriter sw = File.AppendText($".\\log\\{DateTime.Today.ToString("yyyyMdd")}.txt"))
            {
                sw.WriteLine($"[{DateTime.Now}]:{content}");
            }
        }
    }
}
