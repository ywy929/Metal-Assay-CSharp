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
    public partial class ResultForm : Form
    {
        private Main MainForm;
        public ResultForm(Main mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
        }
        public string average_result { get; set; }
        public string customer { get; set; }
        public string item_code { get; set; }
        public string id { get; set; }
        string connection_string = @"server=localhost;uid=root;pwd=Assay123!;database=assay";
        string sql = "";

        private void ResultForm_Load(object sender, EventArgs e)
        {
            ResultPreresultTextbox.Text = average_result;
            ResultCustomerContentLabel.Text = customer;
            ResultItemcodeContentLabel.Text = item_code;
            GetLossValue();
        }

        private void GetLossValue()
        {
            try
            {
                var con = new MySqlConnection(connection_string);
                con.Open();

                sql = "SELECT low, high, pct FROM loss ORDER BY low DESC";
                var cmd = new MySqlCommand(sql, con);

                MySqlDataReader data_reader = cmd.ExecuteReader();

                if (data_reader.HasRows)
                {
                    while (data_reader.Read())
                    {
                        if (float.Parse(average_result) >= float.Parse(data_reader.GetString("low")) && float.Parse(average_result) <= float.Parse(data_reader.GetString("high")))
                        {
                            ResultLossTextbox.Text = data_reader.GetString("pct");
                            ResultFinalResultTextbox.Text = Math.Round(float.Parse(average_result) - float.Parse(data_reader.GetString("pct")), 2).ToString("0.0");
                            ResultBigResultContentLabel.Text = ResultFinalResultTextbox.Text;
                            break;
                        }
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
        }
        private void WriteToLogFile(string content)
        {
            using (StreamWriter sw = File.AppendText($".\\log\\{DateTime.Today.ToString("yyyyMdd")}.txt"))
            {
                sw.WriteLine($"[{DateTime.Now}]:{content}");
            }
        }
        private void ResultLossTextbox_TextChanged(object sender, EventArgs e)
        {
            ResultFinalResultTextbox.Text = (float.Parse(ResultPreresultTextbox.Text) - float.Parse(ResultLossTextbox.Text)).ToString("0.0");
            ResultBigResultContentLabel.Text = ResultFinalResultTextbox.Text;
        }

        private void ResultLossTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -2))
            {
                e.Handled = true;
            }
        }
        private void ResultOKButton_Click(object sender, EventArgs e)
        {
            MainForm.LWFinalResultTextBox.Text = ResultBigResultContentLabel.Text;
            MainForm.LWLossContent.Text = ResultLossTextbox.Text;
            MainForm.SaveLastWeight();
            Close();
        }
        private void ResultForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.LWLastWeightATextBox.Focus();
        }
    }
}
