using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metal_Assay
{
    public partial class ChooseItemForm : Form
    {
        private Main MainForm;

        public ChooseItemForm(Main mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
        }
        public string date { get; set; }
        public string source { get; set; }
        public string customer { get; set; }
        public string formcode { get; set; }
        public string action { get; set; }
        public bool split { get; set; }
        string connection_string = @"server=192.168.0.36;uid=view1;pwd=Assay123!;database=assay";
        //string connection_string = @"server=localhost;uid=root;pwd=Assay123!;database=assay";
        string sql = "";
        private void ChooseItemForm_Load(object sender, EventArgs e)
        {
            try
            {
                ChooseItemFormcodeContentLabel.Text = formcode;
                ChooseItemCustomerContentLabel.Text = customer;

                //get itemcode list and insert into checkedlist 
                var con = new MySqlConnection(connection_string);
                con.Open();
                sql = $"SELECT itemcode FROM assayresult WHERE formcode = '{formcode}'";
                var cmd = new MySqlCommand(sql, con);
                MySqlDataReader data_reader = cmd.ExecuteReader();
                checkedListBox1.Items.Clear();
                if (data_reader.HasRows)
                {
                    while (data_reader.Read())
                    {
                        checkedListBox1.Items.Insert(checkedListBox1.Items.Count, data_reader.GetString("itemcode"));
                    }
                }
                data_reader.Close();
                con.Close();

                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
                WriteToLogFile($"ChooseItemForm Opened. FC:{formcode}");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }
        private void WriteToLogFile(string content)
        {
            using (StreamWriter sw = File.AppendText($".\\log\\{DateTime.Today.ToString("yyyyMdd")}.txt"))
            {
                sw.WriteLine($"[{DateTime.Now}]:{content}");
            }
        }
        private void ChooseItemButton_Click(object sender, EventArgs e)
        {
            try
            {

                PreviewForm previewForm = new PreviewForm(MainForm);
                MainForm.ItemcodeList.Clear();
                //SQL query, add result to list
                string itemcodes = "";
                for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                {
                    itemcodes += $"'{checkedListBox1.CheckedItems[i]}',";
                }
                itemcodes = itemcodes.Remove(itemcodes.Length - 1);
                string query = $"SELECT assayresult.itemcode AS itemcode, assayresult.finalresult AS finalresult, assayresult.sampleweight AS sampleweight, assayresult.samplereturn AS samplereturn, user.fax AS fax FROM assayresult INNER JOIN user ON assayresult.customer = user.id WHERE assayresult.formcode = '{formcode}' And assayresult.itemcode IN ({itemcodes})";
                //Update List
                MainForm.UpdateFormcodeItemList(query);
                if (split == true)
                {
                    //run loop and generate pdf
                    for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                    {
                        MainForm.GeneratePDFSplit(source, customer, date, i.ToString());
                    }
                    //open preview page, enable buttons           
                    previewForm.PreviewActionButton.Text = "SAVE ALL";
                    previewForm.pdf_count = checkedListBox1.CheckedItems.Count;
                }
                else
                {
                    MainForm.GeneratePDF(source, customer, date);
                    //open preview page, enable buttons           
                    previewForm.PreviewActionButton.Text = "SAVE";
                    previewForm.pdf_count = 1;
                }

                string customeremail = "";
                string customerfax = "";
                //Check if email/fax available
                if (action.Contains("SAVE"))
                {
                    previewForm.button_enable = true;
                    previewForm.other_button_enable = false;
                }
                else if (action.Contains("PRINT"))
                {
                    previewForm.button_enable = true;
                    previewForm.other_button_enable = false;
                }
                else if (action.Contains("EMAIL"))
                {

                    var con = new MySqlConnection(connection_string);
                    con.Open();

                    sql = $"SELECT email FROM user WHERE name='{customer}'";
                    var cmd = new MySqlCommand(sql, con);
                    MySqlDataReader data_reader = cmd.ExecuteReader();

                    if (data_reader.HasRows)
                    {
                        while (data_reader.Read())
                        {
                            customeremail = data_reader.GetString("email");
                        }
                    }
                    data_reader.Close();
                    con.Close();


                    if (customeremail == "")
                    {
                        previewForm.button_enable = false;
                        previewForm.customeremail = "";
                    }
                    else
                    {
                        previewForm.button_enable = true;
                        previewForm.customeremail = customeremail;
                    }
                    previewForm.other_button_enable = true;
                    previewForm.action = "EMAIL";
                }
                else if (action.Contains("FAX"))
                {

                    var con = new MySqlConnection(connection_string);
                    con.Open();

                    sql = $"SELECT fax FROM user WHERE name='{customer}'";
                    var cmd = new MySqlCommand(sql, con);
                    MySqlDataReader data_reader = cmd.ExecuteReader();

                    if (data_reader.HasRows)
                    {
                        while (data_reader.Read())
                        {
                            customerfax = data_reader.GetString("fax");
                        }
                    }
                    data_reader.Close();
                    con.Close();



                    if (customerfax == "")
                    {
                        previewForm.button_enable = false;
                        previewForm.customerfax = "";
                    }
                    else
                    {
                        previewForm.button_enable = true;
                        previewForm.customerfax = customerfax;
                    }
                    previewForm.other_button_enable = true;
                    previewForm.action = "FAX";

                }

                previewForm.customer = customer;
                previewForm.ItemcodeList = MainForm.ItemcodeList;
                previewForm.PreviewActionButton.Text = action;
                previewForm.ShowDialog();
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }
    }
}
