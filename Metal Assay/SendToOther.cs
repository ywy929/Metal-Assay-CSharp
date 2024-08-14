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
    public partial class SendToOther : Form
    {
        private Main MainForm;
        public SendToOther(Main mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
        }
        //string connection_string = @"server=192.168.0.8;uid=view1;pwd=Assay123!;database=assay";
        //string connection_string = @"server=localhost;uid=root;pwd=Assay123!;database=assay";
        string connection_string = @"server=192.168.0.36;uid=view1;pwd=Assay123!;database=assay";
        //string connection_string = @"server=localhost;uid=root;pwd=Assay123!;database=assay";
        string sql = "";

        List<SendInfo> info_list = new List<SendInfo>();
        class SendInfo
        {
            public string customer;
            public string fax_no;
            public string email_address;
        }
        public string mode { get; set; }
        public int pdf_count { get; set; }
        public List<string> itemcode_list { get; set; }
        private void LoadFaxCustomerList()
        {
            CustomerCombobox.Items.Clear();
            var con = new MySqlConnection(connection_string);
            con.Open();

            sql = "SELECT name,fax FROM user WHERE role='customer' WHERE NOT fax=''";
            var cmd = new MySqlCommand(sql, con);

            MySqlDataReader data_reader = cmd.ExecuteReader();
            CustomerCombobox.Items.Clear();
            info_list.Clear();
            if (data_reader.HasRows)
            {
                while (data_reader.Read())
                {
                    CustomerCombobox.Items.Add(data_reader.GetString("name"));
                    SendInfo info = new SendInfo();
                    info.customer = data_reader.GetString("name");
                    info.fax_no = data_reader.GetString("fax");
                    info_list.Add(info);
                }
            }
            data_reader.Close();
            con.Close();
        }

        private void LoadEmailCustomerList()
        {
            CustomerCombobox.Items.Clear();
            var con = new MySqlConnection(connection_string);
            con.Open();

            sql = "SELECT name,email FROM user WHERE role='customer' AND NOT email=''";
            var cmd = new MySqlCommand(sql, con);

            MySqlDataReader data_reader = cmd.ExecuteReader();
            CustomerCombobox.Items.Clear();
            info_list.Clear();
            if (data_reader.HasRows)
            {
                while (data_reader.Read())
                {
                    CustomerCombobox.Items.Add(data_reader.GetString("name"));
                    SendInfo info = new SendInfo();
                    info.customer = data_reader.GetString("name");
                    info.fax_no = data_reader.GetString("email");
                    info_list.Add(info);
                }
            }
            data_reader.Close();
            con.Close();
        }

        private void SendToOther_Load(object sender, EventArgs e)
        {
            if (mode == "email")
            {
                LoadEmailCustomerList();
                groupBox1.Text = "Email To Other Customer";
                groupBox2.Text = "Email To Address";
            }
            else if (mode == "fax")
            {
                LoadFaxCustomerList();
                groupBox1.Text = "Fax To Other Customer";
                groupBox2.Text = "Fax To Address";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mode == "email")
            {
                string email = "";
                for (int i = 0; i < info_list.Count; i++)
                {
                    if (info_list[i].customer == CustomerCombobox.Text)
                    {
                        email = info_list[i].email_address;
                    }
                }
                string concat_itemcode = String.Join(",", itemcode_list);
                if (pdf_count == 1)
                {
                    try
                    {
                        
                        MainForm.EmailPDF(Path.GetFullPath($"temp/0.pdf"), CustomerCombobox.Text, concat_itemcode, email);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                else if (pdf_count > 1)
                {
                    for (int i = 0; i < pdf_count; i++)
                    {
                        try
                        {
                            MainForm.EmailPDF(Path.GetFullPath($"temp/{i}.pdf"), CustomerCombobox.Text, itemcode_list[i], email);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                    }
                }
                Close();
            }
            else if (mode == "fax")
            {
                //Search fax using customer
                string fax_no = "";
                for (int i = 0; i < info_list.Count; i++)
                {
                    if (info_list[i].customer == CustomerCombobox.Text)
                    {
                        fax_no = info_list[i].fax_no;
                    }
                }
                for (int i = 0; i < pdf_count; i++)
                {
                    try
                    {
                        MainForm.FaxPDF(Path.GetFullPath($"temp/{i}.pdf"), fax_no, CustomerCombobox.Text);                        
                        File.Delete(Path.GetFullPath($"temp/{i}.pdf"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (mode == "email")
            {
                string concat_itemcode = String.Join(",", itemcode_list);
                if (pdf_count == 1)
                {
                    try
                    {

                        MainForm.EmailPDF(Path.GetFullPath($"temp/0.pdf"), CustomerCombobox.Text, concat_itemcode, OtherTextbox.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                else if (pdf_count > 1)
                {
                    for (int i = 0; i < pdf_count; i++)
                    {
                        try
                        {
                            MainForm.EmailPDF(Path.GetFullPath($"temp/{i}.pdf"), CustomerCombobox.Text, itemcode_list[i], OtherTextbox.Text);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                    }
                }
                Close();
            }
            else if (mode == "fax")
            {
                for (int i = 0; i < pdf_count; i++)
                {
                    try
                    {
                        MainForm.FaxPDF(Path.GetFullPath($"temp/{i}.pdf"), OtherTextbox.Text, CustomerCombobox.Text);
                        File.Delete(Path.GetFullPath($"temp/{i}.pdf"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            Close();
            Close();
        }
    }



}
