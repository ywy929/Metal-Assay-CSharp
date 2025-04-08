using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metal_Assay
{
    public partial class EditForm : Form
    {
        private Main MainForm;
        public EditForm(Main form1)
        {
            InitializeComponent();
            this.MainForm = form1;
        }
        public string result_id { get; set; }
        public string customer { get; set; }
        public string date { get; set; }
        public string formcode { get; set; }
        public string itemcode { get; set; }
        public string sample_weight { get; set; }
        string connection_string = GlobalConfig.ConnectionString;
        string sql = "";
        private void Form3_Load(object sender, EventArgs e)
        {
            EditCustomerLabel.Text = customer;
            EditDateLabel.Text = date;
            EditFormCodeLabel.Text = formcode;
            EditItemcodeTextbox.Text = itemcode;
            EditSampleWeightTextbox.Text = sample_weight;
            WriteToLogFile($"Edit Form Opened. Customer:{customer}, FC:{formcode}, IC:{itemcode}, sw:{sample_weight}");
        }
        private void WriteToLogFile(string content)
        {
            using (StreamWriter sw = File.AppendText($".\\log\\{DateTime.Today.ToString("yyyyMdd")}.txt"))
            {
                sw.WriteLine($"[{DateTime.Now}]:{content}");
            }
        }
        private void EditSaveButton_Click(object sender, EventArgs e)
        {
            if (EditItemcodeTextbox.Text == "" || EditSampleWeightTextbox.Text == "")
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var con = new MySqlConnection(connection_string);
                sql = $"UPDATE assayresult SET itemcode=@itemcode,sampleweight=@sampleweight WHERE id={result_id}";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                cmd.Parameters.AddWithValue("@itemcode", EditItemcodeTextbox.Text);
                cmd.Parameters.AddWithValue("@sampleweight", EditSampleWeightTextbox.Text);
                cmd.ExecuteReader();
                con.Close();
                WriteToLogFile($"Edited. Customer:{customer}, FC:{formcode}, IC:{EditItemcodeTextbox.Text}, SW:{EditSampleWeightTextbox.Text}");
            }
            catch (Exception ex)
            {
                WriteToLogFile($"Exception: {ex.ToString()}");
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();
            MainForm.MainItemcodeLabel.Text = EditItemcodeTextbox.Text;
            MainForm.MainSampleWeightLabel.Text = EditSampleWeightTextbox.Text;

            //Update Main Right, FW, LW, SR
            //MainForm.UpdateEdited(EditItemcodeTextbox.Text,EditSampleWeightTextbox.Text,result_id);
            MainForm.LoadMainPageTable();
            MainForm.LoadFirstWeightTable();
            MainForm.LoadLastWeightTable();
            MainForm.LoadSampleReturnTable();
        }

        private void CancelSaveButton_Click(object sender, EventArgs e)
        {
            Close();
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

        private void TabToNext(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
            }
        }

    }
}
