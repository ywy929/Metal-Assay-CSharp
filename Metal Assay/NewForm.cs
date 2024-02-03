using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Windows.Forms;

namespace Metal_Assay
{
    public partial class NewForm : Form
    {
        private Main MainForm;
        public NewForm(Main main_form)
        {
            InitializeComponent();
            this.MainForm = main_form;
        }
        public string ClickSource { get; set; }
        string connection_string = @"server=localhost;uid=root;pwd=Assay123!;database=assay";
        string sql = "";
        int item_counter = 0;
        List<string> itemcode_check = new List<string>();
        private void Form2_Load(object sender, EventArgs e)
        {
            LoadLatestFormCode();
            LoadCustomerList();
            if (ClickSource == "New Round")
            {
                round_color = round_color == true ? false : true;
            }
            WriteToLogFile($"Opened New Form");
        }
        private void WriteToLogFile(string content)
        {
            using (StreamWriter sw = File.AppendText($".\\log\\{DateTime.Today.ToString("yyyyMdd")}.txt"))
            {
                sw.WriteLine($"[{DateTime.Now}]:{content}");
            }
        }
        private bool round_color = true;
        private void LoadLatestFormCode()
        {
            try
            {
                var con = new MySqlConnection(connection_string);
                con.Open();

                sql = "SELECT assayresult.formcode AS formcode, assayresult.color AS color FROM assayresult ORDER BY assayresult.formcode DESC LIMIT 1";
                var cmd = new MySqlCommand(sql, con);

                MySqlDataReader data_reader = cmd.ExecuteReader();

                if (data_reader.HasRows)
                {
                    while (data_reader.Read())
                    {
                        NewFormCodeContent.Text = (int.Parse(data_reader.GetString("formcode")) + 1).ToString();
                        round_color = data_reader.GetBoolean("color");
                    }
                }
                data_reader.Close();
                con.Close();
                NewDateContent.Text = DateTime.Now.ToString("dd-MM-yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                WriteToLogFile($"Exception: {ex.ToString()}");
            }

        }

        private void LoadCustomerList()
        {
            try
            {
                var con = new MySqlConnection(connection_string);
                con.Open();

                sql = "SELECT name FROM user WHERE role ='customer'";
                var cmd = new MySqlCommand(sql, con);

                MySqlDataReader data_reader = cmd.ExecuteReader();
                NewCustomerCombobox.Items.Clear();
                if (data_reader.HasRows)
                {
                    while (data_reader.Read())
                    {
                        NewCustomerCombobox.Items.Add(data_reader.GetString("name"));
                    }
                }
                data_reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }

        private void NewCustomerCombobox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                NewItemcodeTextbox.Focus();
            }
        }

        private void NewCustomerCombobox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
            {
                e.KeyChar -= (char)32;
            }
        }

        private void NewItemcodeTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;

            }
        }

        private void Decimal_Validation(object sender, KeyPressEventArgs e)
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

        private void NewSampleWeightTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                SaveNewRecord();
                NewItemcodeTextbox.Text = "";
                NewSampleWeightTextbox.Text = "";
                NewItemcodeTextbox.Focus();
            }
        }
        int assayrecord_id;
        DateTime created;
        bool color;
        string sw_to_send;
        private void SaveNewRecord()
        {
            //Blank Validation
            if (NewCustomerCombobox.Text == "" || NewItemcodeTextbox.Text == "" || NewSampleWeightTextbox.Text == "")
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int customer_id = 0;
            //Get Customer ID
            try
            {
                var con = new MySqlConnection(connection_string);
                con.Open();

                sql = $"SELECT id FROM user WHERE name='{NewCustomerCombobox.Text}'";
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
                MessageBox.Show(ex.Message);
            }
            //Do some validations
            if (itemcode_check.Contains(NewItemcodeTextbox.Text))
            {
                MessageBox.Show("This formcode already has this itemcode.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                itemcode_check.Add(NewItemcodeTextbox.Text);
            }
            item_counter++;
            if (item_counter > 14)
            {
                MessageBox.Show("Formcode has 14 item, this item will be added to new formcode.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NewFormCodeContent.Text = (int.Parse(NewFormCodeContent.Text) + 1).ToString();
                itemcode_check.Clear();
                item_counter = 0;
                round_color = round_color == true ? false : true;
            }
            //Insert into DB
            try
            {
                var con = new MySqlConnection(connection_string);
                con.Open();
                string cmdText = "INSERT INTO assayresult (created, modified, itemcode, sampleweight, color, customer, formcode) VALUES (@created, @modified, @itemcode, @sampleweight, @color, @customer, @formcode)";
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                cmd.Parameters.AddWithValue("@created", DateTime.Now);
                cmd.Parameters.AddWithValue("@modified", DateTime.Now);
                cmd.Parameters.AddWithValue("@itemcode", NewItemcodeTextbox.Text);
                cmd.Parameters.AddWithValue("@sampleweight", NewSampleWeightTextbox.Text);
                cmd.Parameters.AddWithValue("@color", round_color);
                cmd.Parameters.AddWithValue("@customer", customer_id);
                cmd.Parameters.AddWithValue("@formcode", NewFormCodeContent.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                WriteToLogFile($"New Record. Customer:{NewCustomerCombobox.Text}, FC:{NewFormCodeContent.Text}, IC:{NewItemcodeTextbox.Text}, SW:{NewSampleWeightTextbox.Text}");
            }
            catch (Exception ex)
            {
                WriteToLogFile($"Exception: {ex.ToString()}");
                MessageBox.Show(ex.Message);
            }

            //Get assayrecord ID           
            try
            {
                var con = new MySqlConnection(connection_string);
                con.Open();

                sql = $"SELECT id,created, color,sampleweight FROM assayresult WHERE formcode='{NewFormCodeContent.Text}' AND itemcode='{NewItemcodeTextbox.Text}'";
                var cmd = new MySqlCommand(sql, con);

                MySqlDataReader data_reader = cmd.ExecuteReader();

                if (data_reader.HasRows)
                {
                    while (data_reader.Read())
                    {
                        assayrecord_id = data_reader.GetInt32("id");
                        created = data_reader.GetDateTime("created");
                        color = data_reader.GetBoolean("color");
                        sw_to_send = data_reader.GetString("sampleweight");
                    }
                }
                data_reader.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                WriteToLogFile($"Exception: {ex.ToString()}");
                MessageBox.Show(ex.Message);
            }

            MainForm.AddNewToMainLeft(NewFormCodeContent.Text, created, NewCustomerCombobox.Text, color);
            MainForm.AddNewToMainRight(NewFormCodeContent.Text, NewItemcodeTextbox.Text, sw_to_send, assayrecord_id, color);
            MainForm.AddNewToFW(NewCustomerCombobox.Text, NewItemcodeTextbox.Text, assayrecord_id, color);
            MainForm.AddNewToLW(NewCustomerCombobox.Text, NewItemcodeTextbox.Text, assayrecord_id, color, NewFormCodeContent.Text, created);
            MainForm.AddNewToSR(NewCustomerCombobox.Text, NewFormCodeContent.Text, NewItemcodeTextbox.Text, sw_to_send, created, assayrecord_id, color);

        }

        private void NewFormCodeButton_Click(object sender, EventArgs e)
        {
            try
            {
                LoadLatestFormCode();
                NewCustomerCombobox.Text = "";
                NewItemcodeTextbox.Text = "";
                NewSampleWeightTextbox.Text = "";
                NewCustomerCombobox.Focus();
                itemcode_check.Clear();
            }
            catch (Exception ex)
            {
                WriteToLogFile($"Exception: {ex.ToString()}");
                MessageBox.Show(ex.Message);
            }
        }

        private void NewForm_Shown(object sender, EventArgs e)
        {
            NewCustomerCombobox.Focus();
        }
    }
}
