using iTextSharp.text;
using System;
using System.CodeDom.Compiler;
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
    public partial class PreviewForm : Form
    {
        private Main MainForm;
        public PreviewForm(Main mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
        }
        public string customerfax { get; set; }
        public string customeremail { get; set; }
        public bool button_enable { get; set; }
        public bool other_button_enable { get; set; }
        public string action { get; set; }
        public string customer { get; set; }
        public int pdf_count { get; set; }
        public List<string> ItemcodeList = new List<string>();
        private int current_order = 1;
        private void PreviewForm_Load(object sender, EventArgs e)
        {
            try
            {


                //PreviewWebBrowser.Navigate(Environment.CurrentDirectory + $"/temp/{current_order - 1}.pdf");
                //Load Image
                System.Drawing.Image img;
                using (var bmpTemp = new Bitmap(Path.GetFullPath($"temp/{current_order - 1}1.jpg")))
                {
                    img = new Bitmap(bmpTemp);
                }
                pictureBox1.Image = img;
                if (pdf_count > 1)
                {
                    PreviewNextButton.Enabled = true;
                }
                if (button_enable == true)
                {
                    PreviewActionButton.Enabled = true;
                }
                else
                {
                    PreviewActionButton.Enabled = false;
                }
                if (other_button_enable == true)
                {
                    PreviewOtherButton.Enabled = true;
                }
                else
                {
                    PreviewOtherButton.Enabled = false;
                }
                if (action != null)
                {
                    if (action.Contains("FAX"))
                    {
                        PreviewOtherButton.Text = "FAX TO OTHERS";
                    }
                    if (action.Contains("EMAIL"))
                    {
                        PreviewOtherButton.Text = "EMAIL TO OTHERS";
                    }

                }
                WriteToLogFile("Preview Form Opened.");
            }
            catch (Exception ex)
            {
                WriteToLogFile($"Exception: {ex.ToString()}");
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WriteToLogFile(string content)
        {
            using (StreamWriter sw = File.AppendText($".\\log\\{DateTime.Today.ToString("yyyyMdd")}.txt"))
            {
                sw.WriteLine($"[{DateTime.Now}]:{content}");
            }
        }
        private void PreviewActionButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(PreviewActionButton.Text);
            if (PreviewActionButton.Text == "SAVE" || PreviewActionButton.Text == "SAVE ALL")
            {
                for (int i = 0; i < pdf_count; i++)
                {
                    try
                    {
                        File.Copy($"temp/{i}.pdf", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"{customer.Replace("/", " ").Replace(":", " ")} {ItemcodeList[i].Replace("/", " ").Replace(":", " ")} {DateTime.Now.ToString("yyMMdd HHmmss")}.pdf"), true);
                        File.Delete($"temp/{i}.pdf");
                        WriteToLogFile($"Saved PDF: {customer.Replace("/", " ")} {ItemcodeList[i].Replace("/", " ")} {DateTime.Now.ToString("yyMMdd HHmmss")}.pdf");
                    }
                    catch (IOException iox)
                    {
                        WriteToLogFile($"Exception: {iox.ToString()}");
                        MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                Close();

            }
            else if (PreviewActionButton.Text == "FAX" || PreviewActionButton.Text == "FAX ALL")
            {
                for (int i = 0; i < pdf_count; i++)
                {
                    try
                    {
                        MainForm.FaxPDF(Path.GetFullPath($"temp/{i}.pdf"), customerfax, customer);
                        //File.Copy($"temp/{i}.pdf", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"{customer.Replace("/", " ")} {ItemcodeList[i].Replace("/", " ")} {DateTime.Now.ToString("yyMMdd HHmmss")}.pdf"), true);
                        File.Delete(Path.GetFullPath($"temp/{i}.pdf"));
                        WriteToLogFile($"Faxed PDF. Customer:{customer}, Fax:{customerfax}");
                    }
                    catch (Exception ex)
                    {
                        WriteToLogFile($"Exception: {ex.ToString()}");
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                Close();
            }
            else if (PreviewActionButton.Text == "EMAIL" || PreviewActionButton.Text == "EMAIL ALL")
            {
                if (pdf_count == 1)
                {
                    try
                    {
                        string concat_itemcode = String.Join(",", ItemcodeList);
                        MainForm.EmailPDF(Path.GetFullPath($"temp/0.pdf"), customer, concat_itemcode, customeremail);
                        WriteToLogFile($"Emailed PDF. Customer:{customer}, Email:{customeremail}, IC:{concat_itemcode}");
                    }
                    catch (Exception ex)
                    {
                        WriteToLogFile($"Exception: {ex.ToString()}");
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (pdf_count > 1)
                {
                    for (int i = 0; i < pdf_count; i++)
                    {
                        try
                        {
                            MainForm.EmailPDF(Path.GetFullPath($"temp/{i}.pdf"), customer, ItemcodeList[i], customeremail);
                            WriteToLogFile($"Emailed PDF. Customer:{customer}, Email:{customeremail}, IC:{ItemcodeList[i]}");
                        }
                        catch (Exception ex)
                        {
                            WriteToLogFile($"Exception: {ex.ToString()}");
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                Close();
            }
            else if (PreviewActionButton.Text == "PRINT" || PreviewActionButton.Text == "PRINT ALL")
            {
                for (int i = 0; i < pdf_count; i++)
                {
                    try
                    {
                        MainForm.PrintPDF(Path.GetFullPath($"temp/{i}.pdf"));
                        //File.Copy($"temp/{i}.pdf", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"{customer.Replace("/", " ")} {ItemcodeList[i].Replace("/", " ")} {DateTime.Now.ToString("yyMMdd HHmmss")}.pdf"), true);
                        WriteToLogFile($"Printed PDF. Customer:{customer}");
                    }
                    catch (Exception ex)
                    {
                        WriteToLogFile($"Exception: {ex.ToString()}");
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                Close();
            }
        }

        private void PreviewCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PreviewNextButton_Click(object sender, EventArgs e)
        {
            try
            {
                current_order += 1;
                System.Drawing.Image img;
                using (var bmpTemp = new Bitmap($"temp/{current_order - 1}1.jpg"))
                {
                    img = new Bitmap(bmpTemp);
                }
                pictureBox1.Image = img;
                //PreviewWebBrowser.Navigate(Environment.CurrentDirectory + $"/temp/{current_order - 1}.pdf");
                PreviewBackButton.Enabled = true;
                if (current_order == pdf_count)
                {
                    PreviewNextButton.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                WriteToLogFile($"Exception: {ex.ToString()}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreviewBackButton_Click(object sender, EventArgs e)
        {
            try
            {
                current_order -= 1;
                System.Drawing.Image img;
                using (var bmpTemp = new Bitmap($"temp/{current_order - 1}1.jpg"))
                {
                    img = new Bitmap(bmpTemp);
                }
                pictureBox1.Image = img;
                //PreviewWebBrowser.Navigate(Environment.CurrentDirectory + $"/temp/{current_order - 1}.pdf");
                PreviewNextButton.Enabled = true;
                if (current_order == 1)
                {
                    PreviewBackButton.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                WriteToLogFile($"Exception: {ex.ToString()}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreviewCancelButton_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void PreviewOtherButton_Click(object sender, EventArgs e)
        {

            if (PreviewOtherButton.Text == "FAX TO OTHERS")
            {
                SendToOther sendToOther = new SendToOther(MainForm);
                sendToOther.mode = "fax";
                sendToOther.itemcode_list = ItemcodeList;
                sendToOther.pdf_count = pdf_count;
                sendToOther.ShowDialog();
            }
            else if (PreviewOtherButton.Text == "EMAIL TO OTHERS")
            {
                SendToOther sendToOther = new SendToOther(MainForm);
                sendToOther.mode = "email";
                sendToOther.itemcode_list = ItemcodeList;
                sendToOther.pdf_count = pdf_count;
                sendToOther.ShowDialog();
            }
        }
    }
}
