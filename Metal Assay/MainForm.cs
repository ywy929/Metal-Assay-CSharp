using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using FAXCOMEXLib;
using System.Runtime.InteropServices;
using MySqlX.XDevAPI.Relational;
using System.ComponentModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data;
using System.Drawing;
namespace Metal_Assay
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        //string connection_string = @"server=192.168.0.8;uid=view1;pwd=Assay123!;database=assay";
        //string connection_string = @"server=localhost;uid=root;pwd=Assay123!;database=assay";
        string connection_string = @"server=localhost;uid=root;pwd=Assay123!;database=assay";
        string sql = "";

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                //create log folder (if doesn't exist)
                Directory.CreateDirectory("log");
                //create temp folder (if doesn't exist)
                Directory.CreateDirectory("temp");

                //Delete file in Temp if it is 30 days ago;
                string[] tempfiles = Directory.GetFiles(@".\temp");

                foreach (string file in tempfiles)
                {
                    FileInfo fi = new FileInfo(file);
                    if (fi.CreationTime < DateTime.Now.AddDays(-30))
                        fi.Delete();
                }

                //Exit program if already opened
                String thisprocessname = Process.GetCurrentProcess().ProcessName;

                if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1)
                {
                    MessageBox.Show("Application already running.");
                    Environment.Exit(0);
                    return;
                }

                // hide MainForm
                Hide();

                MainLeftDataGridView.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(MainLeftDataGridView, true, null);
                MainRightDataGridView.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(MainRightDataGridView, true, null);
                FWDataGridView.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(FWDataGridView, true, null);
                LWDataGridView.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(LWDataGridView, true, null);
                SRDataGridView.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(SRDataGridView, true, null);
                MainBackgroundWorker.DoWork += new DoWorkEventHandler(MainBackgroundWorker_DoWork);
                FWBackgroundWorker.DoWork += new DoWorkEventHandler(FWBackgroundWorker_DoWork);
                LWBackgroundWorker.DoWork += new DoWorkEventHandler(LWBackgroundWorker_DoWork);
                SRBackgroundWorker.DoWork += new DoWorkEventHandler(SRBackgroundWorker_DoWork);
                LoadAllTable();
                LoadCompanyInfo();
                LoadHistoryCustomerList();
                LoadCustomerCustomerList();
                WriteToLogFile("Program Opened.");
                Login login = new Login(this);
                // show Login
                login.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }

        //Logging
        private void WriteToLogFile(string content)
        {
            using (StreamWriter sw = File.AppendText($".\\log\\{DateTime.Today.ToString("yyyyMdd")}.txt"))
            {
                sw.WriteLine($"[{DateTime.Now}]:{content}");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == FirstWeightTab)
            {
                FWPointToBlank();
            }
            if (tabControl1.SelectedTab == LastWeightTab)
            {
                LWPointToBlank();
            }
            if (tabControl1.SelectedTab == SampleReturnTab)
            {
                SRPointToBlank();
            }
        }

        private void LoadAllTable()
        {
            LoadMainPageTable();
            LoadFirstWeightTable();
            LoadLastWeightTable();
            LoadSampleReturnTable();
            LoadCustomerTable();
            LoadHistoryCustomerList();
            LoadCustomerCustomerList();

        }

        private void TabToNext(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
            }
        }

        private void CheckInteger(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private string left_selected_formcode = "";
        private int right_selected_id = 0;

        public void LoadMainPageTable()
        {
            try
            {
                var con = new MySqlConnection(connection_string);
                con.Open();

                sql = "SELECT assayresult.formcode AS formcode, assayresult.created AS created, user.name AS customer, assayresult.color AS color, assayresult.itemcode AS itemcode, assayresult.sampleweight AS sampleweight, assayresult.samplereturn AS samplereturn, assayresult.finalresult AS finalresult, assayresult.id AS id FROM assayresult INNER JOIN user ON assayresult.customer = user.id ORDER BY assayresult.formcode DESC, assayresult.created DESC LIMIT 500";
                var cmd = new MySqlCommand(sql, con);

                MySqlDataReader data_reader = cmd.ExecuteReader();
                string current_formcode = "0";
                MainLeftDataGridView.Rows.Clear();
                MainLeftDataGridView.Refresh();
                MainRightDataGridView.Rows.Clear();
                MainRightDataGridView.Refresh();
                List<DataGridViewRow> left_rows = new List<DataGridViewRow>();
                List<DataGridViewRow> right_rows = new List<DataGridViewRow>();
                int item_count = 0;
                if (data_reader.HasRows)
                {
                    while (data_reader.Read())
                    {

                        //Load Left
                        if (current_formcode != data_reader.GetString("formcode"))
                        {
                            item_count = 1;
                            DataGridViewRow newLeftRow = new DataGridViewRow() { Height = 30 };
                            newLeftRow.CreateCells(MainLeftDataGridView);
                            newLeftRow.Cells[0].Value = data_reader.GetString("formcode");
                            newLeftRow.Cells[1].Value = item_count;
                            newLeftRow.Cells[2].Value = data_reader.GetDateTime("created");
                            newLeftRow.Cells[3].Value = data_reader.GetString("customer");
                            if (data_reader.GetBoolean("color"))
                            {
                                newLeftRow.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                            }
                            else
                            {
                                newLeftRow.DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                            }
                            left_rows.Insert(0, newLeftRow);

                            current_formcode = data_reader.GetString("formcode");
                        }
                        else
                        {
                            item_count++;
                            left_rows.First().Cells[1].Value = item_count;
                        }

                        //Load Right
                        DataGridViewRow newRightRow = new DataGridViewRow() { Height = 30 };
                        newRightRow.CreateCells(MainRightDataGridView);
                        newRightRow.Cells[0].Value = data_reader.GetString("formcode");
                        newRightRow.Cells[1].Value = data_reader.GetString("itemcode");
                        if (data_reader.GetString("sampleweight") == null)
                        {
                            newRightRow.Cells[2].Value = "";
                        }
                        else
                        {
                            newRightRow.Cells[2].Value = data_reader.GetString("sampleweight");
                        }
                        if (data_reader.IsDBNull(6))
                        {
                            newRightRow.Cells[3].Value = "";
                        }
                        else
                        {
                            newRightRow.Cells[3].Value = data_reader.GetString("samplereturn");
                        }
                        if (data_reader.IsDBNull(7))
                        {
                            newRightRow.Cells[4].Value = "";
                        }
                        else
                        {
                            if (data_reader.GetString("finalresult") == "-1.0")
                            {
                                newRightRow.Cells[4].Value = "REJECT";
                                newRightRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                            }
                            else if (data_reader.GetString("finalresult") == "-2.0")
                            {
                                newRightRow.Cells[4].Value = "REDO";
                                newRightRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                            }
                            else if (data_reader.GetString("finalresult") == "-3.0")
                            {
                                newRightRow.Cells[4].Value = "LOW";
                                newRightRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                newRightRow.Cells[4].Value = data_reader.GetString("finalresult");
                            }
                        }
                        newRightRow.Cells[5].Value = data_reader.GetString("id");
                        if (data_reader.GetBoolean("color"))
                        {
                            newRightRow.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                        }
                        else
                        {
                            newRightRow.DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                        }
                        right_rows.Insert(0, newRightRow);
                    }
                }
                data_reader.Close();
                MainLeftDataGridView.Rows.AddRange(left_rows.ToArray());
                MainRightDataGridView.Rows.AddRange(right_rows.ToArray());
                con.Close();
                MainLeftDataGridView.ClearSelection();
                MainLeftDataGridView.Rows[MainLeftDataGridView.Rows.Count - 1].Selected = true;
                MainLeftDataGridView.FirstDisplayedScrollingRowIndex = MainLeftDataGridView.Rows.Count - 1;
                MainLeftDataGridView.CurrentCell = MainLeftDataGridView.Rows[MainLeftDataGridView.Rows.Count - 1].Cells[0];
                MainLeftDataGridView_CellClick(this.MainLeftDataGridView, new DataGridViewCellEventArgs(0, 0));
                WriteToLogFile("Main Page tables loaded.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }

        private void MainLeftDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Show formcode at right table
                foreach (DataGridViewRow row in MainRightDataGridView.Rows)
                {
                    if (row.Cells[0].Value.ToString() == MainLeftDataGridView.CurrentRow.Cells[0].Value.ToString())
                    {
                        MainRightDataGridView.ClearSelection();
                        MainRightDataGridView.FirstDisplayedScrollingRowIndex = row.Index;
                        MainRightDataGridView.CurrentCell = MainRightDataGridView.Rows[row.Cells[0].RowIndex].Cells[0];
                        MainRightDataGridView_CellClick(this.MainRightDataGridView, new DataGridViewCellEventArgs(0, 0));
                        row.Selected = true;
                        //Show Info
                        MainFormcodeLabel.Text = "Formcode: " + row.Cells[0].Value.ToString();
                        MainCustomerLabel.Text = "Customer: " + MainLeftDataGridView.CurrentRow.Cells[3].Value.ToString();
                        MainDateLabel.Text = "Date: " + DateTime.Parse(MainLeftDataGridView.CurrentRow.Cells[2].Value.ToString()).ToString("dddd, dd MMMM yyyy");
                        MainItemcodeLabel.Text = "Itemcode: " + row.Cells[1].Value.ToString();
                        MainSampleWeightLabel.Text = "Sample Weight(g): " + row.Cells[2].Value.ToString();
                        //Set Current clicked
                        left_selected_formcode = row.Cells[0].Value.ToString();
                        right_selected_id = 0;
                        break;
                    }
                }
            }
            catch
            (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }

        }

        private void MainRightDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Show Info
                //Show formcode at right table
                foreach (DataGridViewRow row in MainLeftDataGridView.Rows)
                {
                    if (row.Cells[0].Value.ToString() == MainRightDataGridView.CurrentRow.Cells[0].Value.ToString())
                    {
                        //Show Info
                        MainFormcodeLabel.Text = "Formcode: " + row.Cells[0].Value.ToString();
                        MainCustomerLabel.Text = "Customer: " + row.Cells[3].Value.ToString();
                        MainDateLabel.Text = "Date: " + row.Cells[2].Value.ToString().Substring(0, 10);
                        MainItemcodeLabel.Text = "Itemcode: " + MainRightDataGridView.CurrentRow.Cells[1].Value.ToString();
                        MainSampleWeightLabel.Text = "Sample Weight(g): " + MainRightDataGridView.CurrentRow.Cells[2].Value.ToString();
                        //Set Current clicked
                        right_selected_id = int.Parse(MainRightDataGridView.CurrentRow.Cells[5].Value.ToString());
                        left_selected_formcode = "";
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }

        private void MainNewButton_Click(object sender, EventArgs e)
        {
            NewForm new_form = new NewForm(this);
            new_form.ClickSource = "New";
            new_form.ShowDialog();
        }

        private void MainNewRoundButton_Click(object sender, EventArgs e)
        {
            NewForm new_form = new NewForm(this);
            new_form.ClickSource = "New Round";
            new_form.ShowDialog();
        }

        private void MainDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if anything selected
                if (left_selected_formcode == "" && right_selected_id == 0)
                {
                    return;
                }
                //Verify Deletion
                if (left_selected_formcode != "")
                {
                    DialogResult dialogResult;
                    dialogResult = MessageBox.Show($"Delete All Under Formcode {left_selected_formcode}?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    DialogResult dialogResult;
                    dialogResult = MessageBox.Show($"Delete Selected Item?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
                //Proceed to delete
                if (left_selected_formcode != "")
                {
                    //Delete based on left clicked
                    var con = new MySqlConnection(connection_string);
                    con.Open();
                    sql = $"DELETE from assayresult WHERE formcode='{left_selected_formcode}'";

                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.ExecuteReader();
                    con.Close();
                    //get the IDs of deleted assay record and delete from Main Right
                    List<int> delete_id_list = new List<int>();
                    delete_id_list.Clear();
                    List<DataGridViewRow> temp_right_rows = MainRightDataGridView.Rows.Cast<DataGridViewRow>().ToList();
                    foreach (DataGridViewRow row in temp_right_rows)
                    {
                        if (row.Cells[0].Value.ToString() == MainLeftDataGridView.CurrentRow.Cells[0].Value.ToString())
                        {
                            delete_id_list.Add(int.Parse(row.Cells[5].Value.ToString()));
                            MainRightDataGridView.Rows.Remove(row);
                        }
                    }
                    //Delete from Main Left
                    MainLeftDataGridView.Rows.RemoveAt(MainLeftDataGridView.CurrentRow.Index);
                    //Delete from FW
                    List<DataGridViewRow> temp_fw_rows = FWDataGridView.Rows.Cast<DataGridViewRow>().ToList();
                    foreach (DataGridViewRow row in temp_fw_rows)
                    {
                        if (delete_id_list.Contains(int.Parse(row.Cells[5].Value.ToString())))
                        {
                            FWDataGridView.Rows.Remove(row);
                        }
                    }
                    //Delete from LW
                    List<DataGridViewRow> temp_lw_rows = LWDataGridView.Rows.Cast<DataGridViewRow>().ToList();
                    foreach (DataGridViewRow row in temp_lw_rows)
                    {
                        if (delete_id_list.Contains(int.Parse(row.Cells[12].Value.ToString())))
                        {
                            LWDataGridView.Rows.Remove(row);
                        }
                    }
                    //Delete from SR
                    List<DataGridViewRow> temp_sr_rows = SRDataGridView.Rows.Cast<DataGridViewRow>().ToList();
                    foreach (DataGridViewRow row in temp_sr_rows)
                    {
                        if (delete_id_list.Contains(int.Parse(row.Cells[7].Value.ToString())))
                        {
                            SRDataGridView.Rows.Remove(row);
                        }
                    }

                }
                else
                {
                    //Delete based on right clicked
                    var con = new MySqlConnection(connection_string);
                    con.Open();
                    sql = $"DELETE from assayresult WHERE id='{right_selected_id}'";

                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.ExecuteReader();
                    con.Close();
                    //Delete from Main Left
                    foreach (DataGridViewRow row in MainLeftDataGridView.Rows)
                    {
                        if (row.Cells[0].Value.ToString() == MainRightDataGridView.CurrentRow.Cells[0].Value.ToString())
                        {
                            if (row.Cells[0].Value.ToString() == "1")
                            {
                                MainLeftDataGridView.Rows.Remove(row);
                            }
                            else
                            {
                                row.Cells[1].Value = (int.Parse(row.Cells[1].Value.ToString()) - 1).ToString();
                            }
                            break;
                        }
                    }
                    //Delete from Main Right
                    MainRightDataGridView.Rows.RemoveAt(MainRightDataGridView.CurrentRow.Index);
                    //Delete from FW
                    foreach (DataGridViewRow row in FWDataGridView.Rows)
                    {
                        if (int.Parse(row.Cells[5].Value.ToString()) == right_selected_id)
                        {
                            FWDataGridView.Rows.Remove(row);
                            break;
                        }
                    }
                    //Delete from LW
                    foreach (DataGridViewRow row in LWDataGridView.Rows)
                    {
                        if (int.Parse(row.Cells[12].Value.ToString()) == right_selected_id)
                        {
                            LWDataGridView.Rows.Remove(row);
                            break;
                        }
                    }
                    //Delete from SR
                    foreach (DataGridViewRow row in SRDataGridView.Rows)
                    {
                        if (int.Parse(row.Cells[7].Value.ToString()) == right_selected_id)
                        {
                            SRDataGridView.Rows.Remove(row);
                            break;
                        }
                    }
                }
                MainLeftDataGridView.ClearSelection();
                MainRightDataGridView.ClearSelection();
                MainFormcodeLabel.Text = "";
                MainCustomerLabel.Text = "";
                MainDateLabel.Text = "";
                MainItemcodeLabel.Text = "";
                MainSampleWeightLabel.Text = "";
                left_selected_formcode = "";
                right_selected_id = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }

        private void MainEditButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if anything selected
                if (right_selected_id == 0)
                {
                    MessageBox.Show("Please choose a record in right table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                //Open Edit Form
                EditForm edit_form = new EditForm(this);
                edit_form.result_id = MainRightDataGridView.CurrentRow.Cells[5].Value.ToString();
                edit_form.customer = MainCustomerLabel.Text;
                edit_form.date = MainDateLabel.Text;
                edit_form.formcode = MainFormcodeLabel.Text;
                edit_form.itemcode = MainRightDataGridView.CurrentRow.Cells[1].Value.ToString();
                edit_form.sample_weight = MainRightDataGridView.CurrentRow.Cells[2].Value.ToString();
                edit_form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }


        }

        private void MainAddButton_Click(object sender, EventArgs e)
        {
            try
            {

                int item_count = 0;
                //Check if anything selected
                if (left_selected_formcode == "" && right_selected_id == 0)
                {
                    return;
                }
                if (left_selected_formcode != "")
                {
                    if (MainLeftDataGridView.CurrentRow.Cells[1].Value.ToString() == "14")
                    {
                        MessageBox.Show("Unable to add. Formcode already has 14 record.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    item_count = int.Parse(MainLeftDataGridView.CurrentRow.Cells[1].Value.ToString());
                }
                else
                {
                    foreach (DataGridViewRow row in MainLeftDataGridView.Rows)
                    {
                        if (row.Cells[0].Value.ToString() == MainRightDataGridView.CurrentRow.Cells[0].Value.ToString())
                        {
                            if (row.Cells[1].Value.ToString() == "14")
                            {
                                MessageBox.Show("Unable to add. Formcode already has 14 record.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return;
                            }
                            item_count = int.Parse(row.Cells[1].Value.ToString());
                            break;
                        }
                    }
                }
                AddForm add_form = new AddForm(this);
                add_form.customer = MainCustomerLabel.Text.Replace("Customer: ", "");
                add_form.date = MainDateLabel.Text;
                add_form.formcode = MainRightDataGridView.CurrentRow.Cells[0].Value.ToString();
                add_form.item_count = item_count;
                //Debug.WriteLine(MainLeftDataGridView.CurrentRow.DefaultCellStyle.BackColor.ToString()); ;
                if (MainRightDataGridView.CurrentRow.DefaultCellStyle.BackColor == System.Drawing.Color.LightCyan)
                {
                    add_form.round_color = true;
                }
                else
                {
                    add_form.round_color = false;
                }
                add_form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }

        //First Weight
        public void LoadFirstWeightTable()
        {
            try
            {
                var con = new MySqlConnection(connection_string);
                con.Open();

                sql = "SELECT user.name AS customer, assayresult.itemcode AS itemcode, assayresult.fwa AS fwa, assayresult.fwb AS fwb, assayresult.silverpct AS silverpct, assayresult.color AS color, assayresult.finalresult AS finalresult, assayresult.id AS id FROM assayresult INNER JOIN user ON assayresult.customer = user.id ORDER BY assayresult.formcode DESC, assayresult.created DESC LIMIT 500";
                var cmd = new MySqlCommand(sql, con);

                MySqlDataReader data_reader = cmd.ExecuteReader();

                FWDataGridView.Rows.Clear();
                FWDataGridView.Refresh();

                List<DataGridViewRow> FW_rows = new List<DataGridViewRow>();
                if (data_reader.HasRows)
                {
                    while (data_reader.Read())
                    {
                        DataGridViewRow newFWRow = new DataGridViewRow() { Height = 30 };
                        newFWRow.CreateCells(FWDataGridView);
                        newFWRow.Cells[0].Value = data_reader.GetString("customer");
                        newFWRow.Cells[1].Value = data_reader.GetString("itemcode");
                        if (!data_reader.IsDBNull(2))
                        {
                            newFWRow.Cells[2].Value = data_reader.GetString("fwa");
                        }
                        else
                        {
                            newFWRow.Cells[2].Value = "";
                        }
                        if (!data_reader.IsDBNull(3))
                        {
                            newFWRow.Cells[3].Value = data_reader.GetString("fwb");
                        }
                        else
                        {
                            newFWRow.Cells[3].Value = "";
                        }
                        if (!data_reader.IsDBNull(4))
                        {
                            newFWRow.Cells[4].Value = data_reader.GetString("silverpct");
                        }
                        else
                        {
                            newFWRow.Cells[4].Value = "";
                        }
                        newFWRow.Cells[5].Value = data_reader.GetString("id");

                        if (!data_reader.IsDBNull(6))
                        {
                            if (data_reader.GetString("finalresult") == "-1.0")
                            {
                                newFWRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                                newFWRow.Cells[6].Value = "REJECT";
                            }
                            else if (data_reader.GetString("finalresult") == "-2.0")
                            {
                                newFWRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                                newFWRow.Cells[6].Value = "REDO";
                            }
                            else if (data_reader.GetString("finalresult") == "-3.0")
                            {
                                newFWRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                                newFWRow.Cells[6].Value = "LOW";
                            }
                            else
                            {
                                newFWRow.Cells[6].Value = data_reader.GetString("finalresult");
                            }
                        }
                        else
                        {
                            newFWRow.Cells[6].Value = "";
                        }
                        if (data_reader.GetBoolean("color"))
                        {
                            newFWRow.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                        }
                        else
                        {
                            newFWRow.DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                        }
                        FW_rows.Insert(0, newFWRow);
                    }
                }
                data_reader.Close();
                FWDataGridView.Rows.AddRange(FW_rows.ToArray());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }

        private void FWDatagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Show Info
                FWCustomerContent.Text = FWDataGridView.CurrentRow.Cells[0].Value.ToString();
                FWItemcodeContent.Text = FWDataGridView.CurrentRow.Cells[1].Value.ToString();
                FWATextbox.Text = FWDataGridView.CurrentRow.Cells[2].Value.ToString();
                FWBTextbox.Text = FWDataGridView.CurrentRow.Cells[3].Value.ToString();
                FWSilverPctCombobox.Text = FWDataGridView.CurrentRow.Cells[4].Value.ToString();
                if (FWATextbox.Text != "" && FWBTextbox.Text != "")
                {
                    FWATextbox.Enabled = false;
                    FWBTextbox.Enabled = false;
                    FWSilverPctCombobox.Enabled = false;
                    FWSaveButton.Text = "Edit";

                }
                else
                {
                    FWATextbox.Enabled = true;
                    FWBTextbox.Enabled = true;
                    FWSilverPctCombobox.Enabled = true;
                    FWSaveButton.Text = "Save";
                    FWATextbox.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }

        }

        private void FWPointToBlank()
        {
            try
            {

                foreach (DataGridViewRow row in FWDataGridView.Rows)
                {
                    if (row.Cells[2].Value.ToString() == "" || row.Cells[3].Value.ToString() == "")
                    {
                        FWDataGridView.ClearSelection();
                        FWDataGridView.Rows[row.Cells[0].RowIndex].Selected = true;
                        if (row.Cells[0].RowIndex - 1 < 0)
                        {
                            FWDataGridView.FirstDisplayedScrollingRowIndex = row.Cells[0].RowIndex;
                        }
                        else
                        {

                            FWDataGridView.FirstDisplayedScrollingRowIndex = row.Cells[0].RowIndex - 1;
                        }
                        FWDataGridView.CurrentCell = FWDataGridView.Rows[row.Cells[0].RowIndex].Cells[0];
                        FWDatagridview_CellClick(this.FWDataGridView, new DataGridViewCellEventArgs(0, 0));
                        if (row.Cells[4].Value.ToString() == "")
                        {
                            FWSilverPctCombobox.SelectedIndex = 0;
                        }
                        break;
                    }
                    //last
                    if (FWDataGridView.Rows.Count - 1 == row.Index)
                    {
                        FWDataGridView.ClearSelection();
                        FWDataGridView.Rows[row.Cells[0].RowIndex].Selected = true;
                        FWDataGridView.FirstDisplayedScrollingRowIndex = row.Cells[0].RowIndex;
                        FWDataGridView.CurrentCell = FWDataGridView.Rows[row.Cells[0].RowIndex].Cells[0];
                        FWDatagridview_CellClick(this.FWDataGridView, new DataGridViewCellEventArgs(0, 0));
                        if (row.Cells[4].Value.ToString() == "")
                        {
                            FWSilverPctCombobox.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }

        private void FWSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (FWSaveButton.Text == "Edit")
                {
                    FWATextbox.Enabled = true;
                    FWBTextbox.Enabled = true;
                    FWSilverPctCombobox.Enabled = true;
                    FWSaveButton.Text = "Save";
                    FWATextbox.Focus();
                }
                else
                {
                    if (FWATextbox.Text == "" || FWBTextbox.Text == "" || FWSilverPctCombobox.Text == "")
                    {
                        return;
                    }

                    var con = new MySqlConnection(connection_string);
                    sql = $"UPDATE assayresult SET fwa=@fwa,fwb=@fwb,silverpct=@silverpct WHERE id={FWDataGridView.CurrentRow.Cells[5].Value.ToString()}";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@fwa", FWATextbox.Text);
                    cmd.Parameters.AddWithValue("@fwb", FWBTextbox.Text);
                    cmd.Parameters.AddWithValue("@silverpct", FWSilverPctCombobox.Text);
                    cmd.ExecuteReader();
                    con.Close();
                    WriteToLogFile($"Saved FW. Customer:{FWCustomerContent.Text}, IC:{FWItemcodeContent.Text}, FWA:{FWATextbox.Text}, FWB:{FWBTextbox.Text}");

                    //Add data to FW table
                    FWDataGridView.CurrentRow.Cells[2].Value = FWATextbox.Text;
                    FWDataGridView.CurrentRow.Cells[3].Value = FWBTextbox.Text;
                    FWDataGridView.CurrentRow.Cells[4].Value = FWSilverPctCombobox.Text;
                    FWSaveButton.Text = "Save";

                    //Add data to LW table
                    foreach (DataGridViewRow row in LWDataGridView.Rows)
                    {
                        if (row.Cells[12].Value.ToString() == FWDataGridView.CurrentRow.Cells[5].Value.ToString())
                        {
                            row.Cells[2].Value = FWATextbox.Text;
                            row.Cells[3].Value = FWBTextbox.Text;
                            row.Cells[6].Value = FWSilverPctCombobox.Text;
                        }
                    }

                    //Move to next row in FW table
                    FWDataGridView.ClearSelection();
                    if (FWDataGridView.Rows.Count - 1 == FWDataGridView.CurrentRow.Cells[0].RowIndex)
                    {
                        FWDataGridView.Rows[FWDataGridView.CurrentRow.Cells[0].RowIndex].Selected = true;
                        FWDataGridView.CurrentCell = FWDataGridView.Rows[FWDataGridView.CurrentRow.Cells[0].RowIndex].Cells[0];
                    }
                    else
                    {

                        FWDataGridView.Rows[FWDataGridView.CurrentRow.Cells[0].RowIndex + 1].Selected = true;
                        FWDataGridView.CurrentCell = FWDataGridView.Rows[FWDataGridView.CurrentRow.Cells[0].RowIndex + 1].Cells[0];
                    }

                    FWDatagridview_CellClick(this.FWDataGridView, new DataGridViewCellEventArgs(0, 0));
                    //LWBackgroundWorker.RunWorkerAsync();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }

        //Last Weight
        public void LoadLastWeightTable()
        {
            try
            {


                var con = new MySqlConnection(connection_string);
                con.Open();

                sql = "SELECT user.name AS customer, assayresult.itemcode AS itemcode, assayresult.fwa AS fwa, assayresult.fwb AS fwb, assayresult.lwa AS lwa, assayresult.lwb AS lwb, assayresult.silverpct AS silverpct, assayresult.finalresult AS finalresult, assayresult.resulta AS resulta, assayresult.resultb AS resultb, assayresult.preresult AS preresult, assayresult.loss AS loss, assayresult.color AS color, assayresult.id AS id, assayresult.formcode AS formcode, assayresult.created AS date FROM assayresult INNER JOIN user ON assayresult.customer = user.id ORDER BY assayresult.formcode DESC, assayresult.created DESC LIMIT 500";
                var cmd = new MySqlCommand(sql, con);

                MySqlDataReader data_reader = cmd.ExecuteReader();

                LWDataGridView.Rows.Clear();
                LWDataGridView.Refresh();

                List<DataGridViewRow> LW_rows = new List<DataGridViewRow>();
                if (data_reader.HasRows)
                {
                    while (data_reader.Read())
                    {
                        DataGridViewRow LWDatagridViewRow = new DataGridViewRow() { Height = 30 };
                        LWDatagridViewRow.CreateCells(LWDataGridView);
                        LWDatagridViewRow.Cells[0].Value = data_reader.GetString("customer");
                        LWDatagridViewRow.Cells[1].Value = data_reader.GetString("itemcode");
                        if (!data_reader.IsDBNull(2))
                        {
                            LWDatagridViewRow.Cells[2].Value = data_reader.GetString("fwa");
                        }
                        else
                        {
                            LWDatagridViewRow.Cells[2].Value = "";
                        }
                        if (!data_reader.IsDBNull(3))
                        {
                            LWDatagridViewRow.Cells[3].Value = data_reader.GetString("fwb");
                        }
                        else
                        {
                            LWDatagridViewRow.Cells[3].Value = "";
                        }
                        if (!data_reader.IsDBNull(4))
                        {
                            LWDatagridViewRow.Cells[4].Value = data_reader.GetString("lwa");
                        }
                        else
                        {
                            LWDatagridViewRow.Cells[4].Value = "";
                        }
                        if (!data_reader.IsDBNull(5))
                        {
                            LWDatagridViewRow.Cells[5].Value = data_reader.GetString("lwb");
                        }
                        else
                        {
                            LWDatagridViewRow.Cells[5].Value = "";
                        }
                        if (!data_reader.IsDBNull(6))
                        {
                            LWDatagridViewRow.Cells[6].Value = data_reader.GetString("silverpct");
                        }
                        else
                        {
                            LWDatagridViewRow.Cells[6].Value = "";
                        }
                        if (data_reader.IsDBNull(7))
                        {
                            LWDatagridViewRow.Cells[7].Value = "";
                        }
                        else
                        {
                            if (data_reader.GetString("finalresult") == "-1.0")
                            {
                                LWDatagridViewRow.Cells[7].Value = "REJECT";
                                LWDatagridViewRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                            }
                            else if (data_reader.GetString("finalresult") == "-2.0")
                            {
                                LWDatagridViewRow.Cells[7].Value = "REDO";
                                LWDatagridViewRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                            }
                            else if (data_reader.GetString("finalresult") == "-3.0")
                            {
                                LWDatagridViewRow.Cells[7].Value = "LOW";
                                LWDatagridViewRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                LWDatagridViewRow.Cells[7].Value = data_reader.GetString("finalresult");
                            }
                        }
                        if (!data_reader.IsDBNull(8))
                        {
                            LWDatagridViewRow.Cells[8].Value = data_reader.GetString("resulta");
                        }
                        else
                        {
                            LWDatagridViewRow.Cells[8].Value = "";
                        }
                        if (!data_reader.IsDBNull(9))
                        {
                            LWDatagridViewRow.Cells[9].Value = data_reader.GetString("resultb");
                        }
                        else
                        {
                            LWDatagridViewRow.Cells[9].Value = "";
                        }
                        if (!data_reader.IsDBNull(10))
                        {
                            LWDatagridViewRow.Cells[10].Value = data_reader.GetString("preresult");
                        }
                        else
                        {
                            LWDatagridViewRow.Cells[10].Value = "";
                        }
                        if (!data_reader.IsDBNull(11))
                        {
                            LWDatagridViewRow.Cells[11].Value = data_reader.GetString("loss");
                        }
                        else
                        {
                            LWDatagridViewRow.Cells[11].Value = "";
                        }
                        LWDatagridViewRow.Cells[12].Value = data_reader.GetString("id");
                        LWDatagridViewRow.Cells[13].Value = data_reader.GetString("formcode");
                        LWDatagridViewRow.Cells[14].Value = data_reader.GetDateTime("date").ToString("dd/MM/yyyy");
                        if (data_reader.GetBoolean("color"))
                        {
                            LWDatagridViewRow.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                        }
                        else
                        {
                            LWDatagridViewRow.DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                        }

                        LW_rows.Insert(0, LWDatagridViewRow);
                    }
                }
                data_reader.Close();
                LWDataGridView.Rows.AddRange(LW_rows.ToArray());
                con.Close();
                WriteToLogFile("Loaded LW table");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }

        private void LWPointToBlank()
        {
            try
            {
                foreach (DataGridViewRow row in LWDataGridView.Rows)
                {
                    if (row.Cells[4].Value.ToString() == "" || row.Cells[5].Value.ToString() == "")
                    {
                        LWDataGridView.ClearSelection();
                        LWDataGridView.Rows[row.Cells[0].RowIndex].Selected = true;
                        if (row.Cells[0].RowIndex - 1 < 0)
                        {
                            LWDataGridView.FirstDisplayedScrollingRowIndex = row.Cells[0].RowIndex;
                        }
                        else
                        {

                            LWDataGridView.FirstDisplayedScrollingRowIndex = row.Cells[0].RowIndex - 1;
                        }
                        LWDataGridView.CurrentCell = LWDataGridView.Rows[row.Cells[0].RowIndex].Cells[0];
                        LWDataGridView_CellClick(this.LWDataGridView, new DataGridViewCellEventArgs(0, 0));
                        break;
                    }
                    //last
                    if (LWDataGridView.Rows.Count - 1 == row.Index)
                    {
                        LWDataGridView.ClearSelection();
                        LWDataGridView.Rows[row.Cells[0].RowIndex].Selected = true;
                        LWDataGridView.FirstDisplayedScrollingRowIndex = row.Cells[0].RowIndex;
                        LWDataGridView.CurrentCell = LWDataGridView.Rows[row.Cells[0].RowIndex].Cells[0];
                        LWDataGridView_CellClick(this.LWDataGridView, new DataGridViewCellEventArgs(0, 0));
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }

        private void LWDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Show Info
                LWCustomerContent.Text = LWDataGridView.CurrentRow.Cells[0].Value.ToString();
                LWItemcodeContent.Text = LWDataGridView.CurrentRow.Cells[1].Value.ToString();
                LWFirstWeightATextBox.Text = LWDataGridView.CurrentRow.Cells[2].Value.ToString();
                LWFirstWeightBTextBox.Text = LWDataGridView.CurrentRow.Cells[3].Value.ToString();
                LWLastWeightATextBox.Text = LWDataGridView.CurrentRow.Cells[4].Value.ToString();
                LWLastWeightBTextBox.Text = LWDataGridView.CurrentRow.Cells[5].Value.ToString();
                LWPreresultATextBox.Text = LWDataGridView.CurrentRow.Cells[8].Value.ToString();
                LWPreresultBTextBox.Text = LWDataGridView.CurrentRow.Cells[9].Value.ToString();
                LWAverageResultTextBox.Text = LWDataGridView.CurrentRow.Cells[10].Value.ToString();
                LWFinalResultTextBox.Text = LWDataGridView.CurrentRow.Cells[7].Value.ToString();
                LWLossContent.Text = LWDataGridView.CurrentRow.Cells[11].Value.ToString();

                if (LWLastWeightATextBox.Text != "" && LWLastWeightBTextBox.Text != "")
                {
                    LWLastWeightATextBox.Enabled = false;
                    LWLastWeightBTextBox.Enabled = false;
                    LWEditButton.Enabled = true;

                }
                else
                {
                    LWLastWeightATextBox.Enabled = true;
                    LWLastWeightBTextBox.Enabled = true;
                    LWLastWeightATextBox.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }

        private void LWEditButton_Click(object sender, EventArgs e)
        {
            LWLastWeightATextBox.Enabled = true;
            LWLastWeightBTextBox.Enabled = true;
            LWLastWeightATextBox.Focus();
        }

        private void CalculatePreresultAndShowPopup(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    if (LWLastWeightATextBox.Text == "" || LWLastWeightBTextBox.Text == "")
                    {
                        return;
                    }

                    //Assign Calculated Values to textbox
                    decimal preresult_A = Math.Round((Decimal.Divide(Decimal.Parse(LWLastWeightATextBox.Text), Decimal.Parse(LWFirstWeightATextBox.Text)) * 1000), 1, MidpointRounding.AwayFromZero);
                    decimal preresult_B = Math.Round((Decimal.Divide(Decimal.Parse(LWLastWeightBTextBox.Text), Decimal.Parse(LWFirstWeightBTextBox.Text)) * 1000), 1, MidpointRounding.AwayFromZero);

                    LWPreresultATextBox.Text = preresult_A.ToString("0.0");
                    LWPreresultBTextBox.Text = preresult_B.ToString("0.0");

                    decimal average_result = Math.Round((preresult_A + preresult_B) / 2, 1, MidpointRounding.AwayFromZero);
                    LWAverageResultTextBox.Text = average_result.ToString("0.0");
                    //If Diff > 1, Open Result Popup with Result Textbox
                    if (Math.Abs(preresult_A - preresult_B) > 1)
                    {
                        ProblematicResultForm problematicResultForm = new ProblematicResultForm(this);
                        problematicResultForm.ShowDialog();
                    }
                    else
                    {
                        ResultForm resultForm = new ResultForm(this);
                        resultForm.average_result = LWAverageResultTextBox.Text;
                        resultForm.customer = LWCustomerContent.Text;
                        resultForm.item_code = LWItemcodeContent.Text;
                        resultForm.id = LWDataGridView.CurrentRow.Cells[12].Value.ToString();
                        resultForm.ShowDialog();
                        LWLastWeightATextBox.Focus();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }

        public void SaveProblemLastWeight(string mode)
        {
            try
            {
                var loss_con = new MySqlConnection(connection_string);
                loss_con.Open();

                sql = "SELECT low, high, pct FROM loss ORDER BY low DESC";
                var loss_cmd = new MySqlCommand(sql, loss_con);

                MySqlDataReader loss_data_reader = loss_cmd.ExecuteReader();

                if (loss_data_reader.HasRows)
                {
                    while (loss_data_reader.Read())
                    {
                        if (float.Parse(LWAverageResultTextBox.Text) >= float.Parse(loss_data_reader.GetString("low")) && float.Parse(LWAverageResultTextBox.Text) <= float.Parse(loss_data_reader.GetString("high")))
                        {
                            LWLossContent.Text = loss_data_reader.GetString("pct");
                            break;
                        }
                    }
                }
                loss_data_reader.Close();
                loss_con.Close();

                var con = new MySqlConnection(connection_string);
                sql = $"UPDATE assayresult SET lwa=@lwa,lwb=@lwb,finalresult=@finalresult,resulta=@resulta,resultb=@resultb,preresult=@preresult,loss=@loss " +
                    $"WHERE id='{LWDataGridView.CurrentRow.Cells[12].Value.ToString()}'";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                cmd.Parameters.AddWithValue("@lwa", LWLastWeightATextBox.Text);
                cmd.Parameters.AddWithValue("@lwb", LWLastWeightBTextBox.Text);
                if (mode == "REJECT")
                {
                    cmd.Parameters.AddWithValue("@finalresult", -1.0);

                }
                if (mode == "REDO")
                {
                    cmd.Parameters.AddWithValue("@finalresult", -2.0);

                }
                if (mode == "LOW")
                {
                    cmd.Parameters.AddWithValue("@finalresult", -3.0);

                }
                cmd.Parameters.AddWithValue("@resulta", LWPreresultATextBox.Text);
                cmd.Parameters.AddWithValue("@resultb", LWPreresultBTextBox.Text);
                cmd.Parameters.AddWithValue("@preresult", LWAverageResultTextBox.Text);
                cmd.Parameters.AddWithValue("@loss", LWLossContent.Text);
                cmd.ExecuteReader();
                con.Close();
                WriteToLogFile($"Last Weight Saved. Customer:{LWCustomerContent.Text}, IC:{LWItemcodeContent.Text}, LWA:{LWLastWeightATextBox.Text}, LWB:{LWLastWeightBTextBox.Text}, finalresult:{mode}, loss:{LWLossContent.Text}");

                //Log the spoil record
                con.Open();
                string spoilcmdText = $"INSERT INTO spoilrecord (itemcode, created, modified, sampleweight, samplereturn, fwa, fwb, silverpct, lwa, lwb, resulta, resultb, preresult, loss, finalresult, customer, formcode, color, returndate, collector, incharge) SELECT itemcode, created, modified, sampleweight, samplereturn, fwa, fwb, silverpct, lwa, lwb, resulta, resultb, preresult, loss, finalresult, customer, formcode, color, returndate, collector, incharge FROM assayresult WHERE id='{LWDataGridView.CurrentRow.Cells[12].Value.ToString()}'";
                MySqlCommand spoilcmd = new MySqlCommand(spoilcmdText, con);
                spoilcmd.ExecuteNonQuery();
                con.Close();

                //Update LW Value
                LWFinalResultTextBox.Text = mode;
                LWDataGridView.CurrentRow.Cells[4].Value = LWLastWeightATextBox.Text;
                LWDataGridView.CurrentRow.Cells[5].Value = LWLastWeightBTextBox.Text;
                LWDataGridView.CurrentRow.Cells[7].Value = LWFinalResultTextBox.Text;
                LWDataGridView.CurrentRow.Cells[8].Value = LWPreresultATextBox.Text;
                LWDataGridView.CurrentRow.Cells[9].Value = LWPreresultBTextBox.Text;
                LWDataGridView.CurrentRow.Cells[10].Value = LWAverageResultTextBox.Text;
                LWDataGridView.CurrentRow.Cells[11].Value = LWLossContent.Text;
                LWDataGridView.CurrentRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;

                //Update Main Right Value
                foreach (DataGridViewRow row in MainRightDataGridView.Rows)
                {
                    if (row.Cells[5].Value.ToString() == LWDataGridView.CurrentRow.Cells[12].Value.ToString())
                    {
                        row.Cells[4].Value = LWFinalResultTextBox.Text;
                    }
                }
                //Update SR Value
                foreach (DataGridViewRow row in LWDataGridView.Rows)
                {
                    if (row.Cells[7].Value.ToString() == LWDataGridView.CurrentRow.Cells[12].Value.ToString())
                    {
                        row.Cells[3].Value = LWFinalResultTextBox.Text;
                    }
                }
                //Update FW Color
                foreach (DataGridViewRow row in FWDataGridView.Rows)
                {
                    if (row.Cells[5].Value.ToString() == LWDataGridView.CurrentRow.Cells[12].Value.ToString())
                    {
                        row.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                    }
                }
                //Go to next row in LW
                LWDataGridView.ClearSelection();
                if (LWDataGridView.Rows.Count - 1 == LWDataGridView.CurrentRow.Cells[0].RowIndex)
                {
                    LWDataGridView.Rows[LWDataGridView.CurrentRow.Cells[0].RowIndex].Selected = true;
                    LWDataGridView.CurrentCell = LWDataGridView.Rows[LWDataGridView.CurrentRow.Cells[0].RowIndex].Cells[0];
                }
                else
                {
                    LWDataGridView.Rows[LWDataGridView.CurrentRow.Cells[0].RowIndex + 1].Selected = true;
                    LWDataGridView.CurrentCell = LWDataGridView.Rows[LWDataGridView.CurrentRow.Cells[0].RowIndex + 1].Cells[0];
                }
                LWDataGridView_CellClick(this.LWDataGridView, new DataGridViewCellEventArgs(0, 0));

                MainBackgroundWorker.RunWorkerAsync();
                SRBackgroundWorker.RunWorkerAsync();

                //e.SuppressKeyPress = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }
        public void SaveLastWeight()
        {
            try
            {
                var con = new MySqlConnection(connection_string);
                sql = $"UPDATE assayresult SET lwa=@lwa,lwb=@lwb,finalresult=@finalresult,resulta=@resulta,resultb=@resultb,preresult=@preresult,loss=@loss " +
                    $"WHERE id='{LWDataGridView.CurrentRow.Cells[12].Value.ToString()}'";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                cmd.Parameters.AddWithValue("@lwa", LWLastWeightATextBox.Text);
                cmd.Parameters.AddWithValue("@lwb", LWLastWeightBTextBox.Text);
                cmd.Parameters.AddWithValue("@finalresult", LWFinalResultTextBox.Text);
                cmd.Parameters.AddWithValue("@resulta", LWPreresultATextBox.Text);
                cmd.Parameters.AddWithValue("@resultb", LWPreresultBTextBox.Text);
                cmd.Parameters.AddWithValue("@preresult", LWAverageResultTextBox.Text);
                cmd.Parameters.AddWithValue("@loss", LWLossContent.Text);
                cmd.ExecuteReader();
                con.Close();
                WriteToLogFile($"Last Weight Saved. Customer:{LWCustomerContent.Text}, IC:{LWItemcodeContent.Text}, LWA:{LWLastWeightATextBox.Text}, LWB:{LWLastWeightBTextBox.Text}, finalresult:{LWFinalResultTextBox.Text}, loss:{LWLossContent.Text}");
                LWDataGridView.CurrentRow.Cells[4].Value = LWLastWeightATextBox.Text;
                LWDataGridView.CurrentRow.Cells[5].Value = LWLastWeightBTextBox.Text;
                LWDataGridView.CurrentRow.Cells[7].Value = LWFinalResultTextBox.Text;
                LWDataGridView.CurrentRow.Cells[8].Value = LWPreresultATextBox.Text;
                LWDataGridView.CurrentRow.Cells[9].Value = LWPreresultBTextBox.Text;
                LWDataGridView.CurrentRow.Cells[10].Value = LWAverageResultTextBox.Text;
                LWDataGridView.CurrentRow.Cells[11].Value = LWLossContent.Text;
                LWDataGridView.CurrentRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                //Update FW Color
                foreach (DataGridViewRow row in FWDataGridView.Rows)
                {
                    if (row.Cells[5].Value.ToString() == LWDataGridView.CurrentRow.Cells[12].Value.ToString())
                    {
                        row.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    }
                }
                //Update Main Right Value
                foreach (DataGridViewRow row in MainRightDataGridView.Rows)
                {
                    if (row.Cells[5].Value.ToString() == LWDataGridView.CurrentRow.Cells[12].Value.ToString())
                    {
                        row.Cells[4].Value = LWFinalResultTextBox.Text;
                    }
                }
                //Update SR Value
                foreach (DataGridViewRow row in LWDataGridView.Rows)
                {
                    if (row.Cells[7].Value.ToString() == LWDataGridView.CurrentRow.Cells[12].Value.ToString())
                    {
                        row.Cells[3].Value = LWFinalResultTextBox.Text;
                    }
                }
                //Go to next row in LW
                LWDataGridView.ClearSelection();
                if (LWDataGridView.Rows.Count - 1 == LWDataGridView.CurrentRow.Cells[0].RowIndex)
                {
                    LWDataGridView.Rows[LWDataGridView.CurrentRow.Cells[0].RowIndex].Selected = true;
                    LWDataGridView.CurrentCell = LWDataGridView.Rows[LWDataGridView.CurrentRow.Cells[0].RowIndex].Cells[0];
                }
                else
                {
                    LWDataGridView.Rows[LWDataGridView.CurrentRow.Cells[0].RowIndex + 1].Selected = true;
                    LWDataGridView.CurrentCell = LWDataGridView.Rows[LWDataGridView.CurrentRow.Cells[0].RowIndex + 1].Cells[0];
                }

                LWDataGridView_CellClick(this.LWDataGridView, new DataGridViewCellEventArgs(0, 0));

                MainBackgroundWorker.RunWorkerAsync();
                SRBackgroundWorker.RunWorkerAsync();

                //e.SuppressKeyPress = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }

        private void LWDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dataGrid = (DataGridView)sender;
            if (e.Button == MouseButtons.Right && e.RowIndex != -1)
            {
                var row = dataGrid.Rows[e.RowIndex];
                dataGrid.CurrentCell = row.Cells[e.ColumnIndex == -1 ? 1 : e.ColumnIndex];
                row.Selected = true;
                LWDataGridView_CellClick(this.LWDataGridView, new DataGridViewCellEventArgs(0, 0));
                LastWeightContextMenuStrip.Show(this, PointToClient(Cursor.Position));
                right_click_formcode = LWDataGridView.CurrentRow.Cells[13].Value.ToString();
                right_click_id = LWDataGridView.CurrentRow.Cells[12].Value.ToString();
                right_click_date = LWDataGridView.CurrentRow.Cells[14].Value.ToString();
                right_click_source = "LW";
                right_click_customer = LWDataGridView.CurrentRow.Cells[0].Value.ToString();
            }
        }


        //Sample Return
        public void LoadSampleReturnTable()
        {
            try
            {

                var con = new MySqlConnection(connection_string);
                con.Open();

                sql = "SELECT user.name AS customer, assayresult.formcode AS formcode, assayresult.itemcode AS itemcode, assayresult.finalresult AS finalresult, assayresult.sampleweight AS sampleweight, assayresult.samplereturn AS samplereturn, assayresult.color AS color, assayresult.id AS id, assayresult.created AS created, user.fax AS fax FROM assayresult INNER JOIN user ON assayresult.customer = user.id ORDER BY assayresult.formcode DESC, assayresult.created DESC LIMIT 500";
                var cmd = new MySqlCommand(sql, con);

                MySqlDataReader data_reader = cmd.ExecuteReader();

                SRDataGridView.Rows.Clear();

                List<DataGridViewRow> SR_rows = new List<DataGridViewRow>();
                if (data_reader.HasRows)
                {
                    while (data_reader.Read())
                    {
                        DataGridViewRow SRDatagridViewRow = new DataGridViewRow() { Height = 30 };
                        SRDatagridViewRow.CreateCells(SRDataGridView);
                        SRDatagridViewRow.Cells[0].Value = data_reader.GetString("customer");
                        SRDatagridViewRow.Cells[1].Value = data_reader.GetString("formcode");
                        SRDatagridViewRow.Cells[2].Value = data_reader.GetString("itemcode");
                        if (data_reader.IsDBNull(3))
                        {
                            SRDatagridViewRow.Cells[3].Value = "";
                        }
                        else
                        {
                            if (data_reader.GetString("finalresult") == "-1.0")
                            {
                                SRDatagridViewRow.Cells[3].Value = "REJECT";
                                SRDatagridViewRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                            }
                            else if (data_reader.GetString("finalresult") == "-2.0")
                            {
                                SRDatagridViewRow.Cells[3].Value = "REDO";
                                SRDatagridViewRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                            }
                            else if (data_reader.GetString("finalresult") == "-3.0")
                            {
                                SRDatagridViewRow.Cells[3].Value = "LOW";
                                SRDatagridViewRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                SRDatagridViewRow.Cells[3].Value = data_reader.GetString("finalresult");
                            }
                        }
                        if (!data_reader.IsDBNull(4))
                        {
                            SRDatagridViewRow.Cells[4].Value = data_reader.GetString("sampleweight");
                        }
                        else
                        {
                            SRDatagridViewRow.Cells[4].Value = "";
                        }
                        if (!data_reader.IsDBNull(5))
                        {
                            SRDatagridViewRow.Cells[5].Value = data_reader.GetString("samplereturn");
                        }
                        else
                        {
                            SRDatagridViewRow.Cells[5].Value = "";
                        }

                        SRDatagridViewRow.Cells[6].Value = data_reader.GetDateTime("created").ToString("dd/MM/yyyy");
                        SRDatagridViewRow.Cells[7].Value = data_reader.GetString("id");
                        if (data_reader.GetBoolean("color"))
                        {
                            SRDatagridViewRow.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                        }
                        else
                        {
                            SRDatagridViewRow.DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                        }

                        SR_rows.Insert(0, SRDatagridViewRow);
                    }
                }
                data_reader.Close();
                SRDataGridView.Rows.AddRange(SR_rows.ToArray());
                con.Close();
                WriteToLogFile("Sample Return table Loaded");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }

        private void SRPointToBlank()
        {
            try
            {
                foreach (DataGridViewRow row in SRDataGridView.Rows)
                {
                    if (row.Cells[5].Value.ToString() == "")
                    {
                        SRDataGridView.ClearSelection();
                        SRDataGridView.Rows[row.Cells[0].RowIndex].Selected = true;
                        if (row.Cells[0].RowIndex - 1 < 0)
                        {
                            SRDataGridView.FirstDisplayedScrollingRowIndex = row.Cells[0].RowIndex;
                        }
                        else
                        {

                            SRDataGridView.FirstDisplayedScrollingRowIndex = row.Cells[0].RowIndex - 1;
                        }
                        SRDataGridView.CurrentCell = SRDataGridView.Rows[row.Cells[0].RowIndex].Cells[0];
                        SRDataGridView_CellClick(this.SRDataGridView, new DataGridViewCellEventArgs(0, 0));
                        break;
                    }
                    //last
                    if (SRDataGridView.Rows.Count - 1 == row.Index)
                    {
                        SRDataGridView.ClearSelection();
                        SRDataGridView.Rows[row.Cells[0].RowIndex].Selected = true;
                        SRDataGridView.FirstDisplayedScrollingRowIndex = row.Cells[0].RowIndex;
                        SRDataGridView.CurrentCell = SRDataGridView.Rows[row.Cells[0].RowIndex].Cells[0];
                        SRDataGridView_CellClick(this.SRDataGridView, new DataGridViewCellEventArgs(0, 0));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }

        }

        private void SRDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Show Info
                SampleReturnCustomerContentLabel.Text = SRDataGridView.CurrentRow.Cells[0].Value.ToString();
                SampleReturnItemcodeContentLabel.Text = SRDataGridView.CurrentRow.Cells[2].Value.ToString();
                SampleReturnResultContentLabel.Text = SRDataGridView.CurrentRow.Cells[3].Value.ToString();
                SampleReturnSampleWeightContentLabel.Text = SRDataGridView.CurrentRow.Cells[4].Value.ToString();
                SampleReturnSampleReturnTextbox.Text = SRDataGridView.CurrentRow.Cells[5].Value.ToString();


                if (SampleReturnSampleReturnTextbox.Text != "")
                {
                    SampleReturnSampleReturnTextbox.Enabled = false;
                    SampleReturnSaveButton.Text = "EDIT";
                }
                else
                {
                    SampleReturnSampleReturnTextbox.Enabled = true;
                    SampleReturnSaveButton.Text = "SAVE";
                    SampleReturnSampleReturnTextbox.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }
        private void SampleReturnSampleReturnTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    if (SampleReturnSampleReturnTextbox.Text == "")
                    {
                        return;
                    }
                    //Check if SR > than SW
                    if (decimal.Parse(SampleReturnSampleReturnTextbox.Text) > decimal.Parse(SampleReturnSampleWeightContentLabel.Text))
                    {
                        MessageBox.Show("Sample Return cannot be bigger than Sample Weight", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var con = new MySqlConnection(connection_string);
                    sql = $"UPDATE assayresult SET samplereturn=@samplereturn,modified=@modified " +
                        $"WHERE id='{SRDataGridView.CurrentRow.Cells[7].Value}'";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@samplereturn", SampleReturnSampleReturnTextbox.Text);
                    cmd.Parameters.AddWithValue("@modified", DateTime.Now);
                    cmd.ExecuteReader();
                    con.Close();
                    WriteToLogFile($"Sample Return Saved. Customer:{SampleReturnCustomerContentLabel.Text}, IC:{SampleReturnItemcodeContentLabel.Text}, SR:{SampleReturnSampleReturnTextbox.Text}");


                    //Add data to table
                    string srstring = SampleReturnSampleReturnTextbox.Text;

                    if (srstring.StartsWith("."))
                    {
                        srstring = "0" + srstring;
                    }
                    if (srstring.Length < 4)
                    {
                        if (srstring.Contains("."))
                        {
                            srstring = srstring.PadRight(4, '0');
                        }
                        else
                        {
                            srstring = srstring + ".";
                            srstring = srstring.PadRight(4, '0');
                        }
                    }

                    //Update SR Value
                    SRDataGridView.CurrentRow.Cells[5].Value = srstring;
                    //Update Main Right Value
                    foreach (DataGridViewRow row in MainRightDataGridView.Rows)
                    {
                        if (row.Cells[5].Value.ToString() == SRDataGridView.CurrentRow.Cells[7].Value.ToString())
                        {
                            row.Cells[3].Value = SRDataGridView.CurrentRow.Cells[5].Value.ToString();
                        }
                    }
                    SRDataGridView.ClearSelection();
                    if (SRDataGridView.Rows.Count - 1 == SRDataGridView.CurrentRow.Cells[0].RowIndex)
                    {
                        SRDataGridView.Rows[SRDataGridView.CurrentRow.Cells[0].RowIndex].Selected = true;
                        SRDataGridView.CurrentCell = SRDataGridView.Rows[SRDataGridView.CurrentRow.Cells[0].RowIndex].Cells[0];
                    }
                    else
                    {
                        SRDataGridView.Rows[SRDataGridView.CurrentRow.Cells[0].RowIndex + 1].Selected = true;
                        SRDataGridView.CurrentCell = SRDataGridView.Rows[SRDataGridView.CurrentRow.Cells[0].RowIndex + 1].Cells[0];
                    }
                    SRDataGridView_CellClick(this.SRDataGridView, new DataGridViewCellEventArgs(0, 0));
                    //MainBackgroundWorker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }
        private void SampleReturnSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (SampleReturnSaveButton.Text == "SAVE")
                {
                    //Check if SR > than SW
                    if (decimal.Parse(SampleReturnSampleReturnTextbox.Text) > decimal.Parse(SampleReturnSampleWeightContentLabel.Text))
                    {
                        MessageBox.Show("Sample Return cannot be bigger than Sample Weight", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var con = new MySqlConnection(connection_string);
                    sql = $"UPDATE assayresult SET samplereturn=@samplereturn,modified=@modified " +
                        $"WHERE id='{SRDataGridView.CurrentRow.Cells[7].Value}'";
                    Debug.WriteLine(sql);
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@samplereturn", SampleReturnSampleReturnTextbox.Text);
                    cmd.Parameters.AddWithValue("@modified", DateTime.Now);
                    cmd.ExecuteReader();
                    con.Close();

                    WriteToLogFile($"Sample Return Saved. Customer:{SampleReturnCustomerContentLabel.Text}, IC:{SampleReturnItemcodeContentLabel.Text}, SR:{SampleReturnSampleReturnTextbox.Text}");
                    //Add data to table
                    string srstring = SampleReturnSampleReturnTextbox.Text;

                    if (srstring.StartsWith("."))
                    {
                        srstring = "0" + srstring;
                    }
                    if (srstring.Length < 4)
                    {

                        if (srstring.Contains("."))
                        {
                            srstring = srstring.PadRight(4, '0');
                        }
                        else
                        {
                            srstring = srstring + ".";
                            srstring = srstring.PadRight(4, '0');
                        }


                    }
                    //Update SR Value
                    SRDataGridView.CurrentRow.Cells[5].Value = srstring;
                    //Update Main Right Value
                    foreach (DataGridViewRow row in MainRightDataGridView.Rows)
                    {
                        if (row.Cells[5].Value.ToString() == SRDataGridView.CurrentRow.Cells[7].Value.ToString())
                        {
                            row.Cells[3].Value = SRDataGridView.CurrentRow.Cells[5].Value.ToString();
                        }
                    }
                    SRDataGridView.ClearSelection();
                    if (SRDataGridView.Rows.Count - 1 == SRDataGridView.CurrentRow.Cells[0].RowIndex)
                    {
                        SRDataGridView.Rows[SRDataGridView.CurrentRow.Cells[0].RowIndex].Selected = true;
                        SRDataGridView.CurrentCell = SRDataGridView.Rows[SRDataGridView.CurrentRow.Cells[0].RowIndex].Cells[0];
                    }
                    else
                    {
                        SRDataGridView.Rows[SRDataGridView.CurrentRow.Cells[0].RowIndex + 1].Selected = true;
                        SRDataGridView.CurrentCell = SRDataGridView.Rows[SRDataGridView.CurrentRow.Cells[0].RowIndex + 1].Cells[0];
                    }

                    SRDataGridView_CellClick(this.SRDataGridView, new DataGridViewCellEventArgs(0, 0));
                    //MainBackgroundWorker.RunWorkerAsync();


                }
                else if (SampleReturnSaveButton.Text == "EDIT")
                {
                    SampleReturnSampleReturnTextbox.Enabled = true;
                    SampleReturnSaveButton.Text = "SAVE";
                    SampleReturnSampleReturnTextbox.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }

        private void SampleReturnSampleReturnTextbox_KeyPress(object sender, KeyPressEventArgs e)
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
                if ((sender as System.Windows.Forms.TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void SRDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dataGrid = (DataGridView)sender;
            if (e.Button == MouseButtons.Right && e.RowIndex != -1)
            {
                var row = dataGrid.Rows[e.RowIndex];
                dataGrid.CurrentCell = row.Cells[e.ColumnIndex == -1 ? 1 : e.ColumnIndex];
                row.Selected = true;
                SRDataGridView_CellClick(this.SRDataGridView, new DataGridViewCellEventArgs(0, 0));
                SampleReturnContextMenuStrip.Show(this, PointToClient(Cursor.Position));
                right_click_formcode = SRDataGridView.CurrentRow.Cells[1].Value.ToString();
                right_click_id = SRDataGridView.CurrentRow.Cells[7].Value.ToString();
                right_click_date = SRDataGridView.CurrentRow.Cells[6].Value.ToString();
                right_click_source = "SR";
                right_click_customer = SRDataGridView.CurrentRow.Cells[0].Value.ToString();
            }
        }


        //PDF Generator
        private string right_click_source;
        private string right_click_formcode;
        private string right_click_id;
        private string right_click_customer;
        private string right_click_date;
        private string company_name;
        private string company_address_one;
        private string company_address_two;
        private string company_phone_one;
        private string company_phone_two;
        private string company_email;
        private string company_email_pw;
        private string customer_fax;
        class FormcodeItem
        {
            public string itemcode { get; set; } = " ";
            public string finalresult { get; set; } = " ";
            public string sampleweight { get; set; } = " ";
            public string samplereturn { get; set; } = " ";
        }
        public List<string> ItemcodeList = new List<string>();
        private List<FormcodeItem> FormcodeItemList = new List<FormcodeItem>();

        iTextSharp.text.Font small_helvetica = FontFactory.GetFont("Helvetica", 7f);
        iTextSharp.text.Font medium_helvetica = FontFactory.GetFont("Helvetica", 8f);
        iTextSharp.text.Font title_bold_helvetica = FontFactory.GetFont("Helvetica-Bold", 14f);
        iTextSharp.text.Font bold_helvetica = FontFactory.GetFont("Helvetica-Bold", 16f);
        iTextSharp.text.Font fineness_helvetica = FontFactory.GetFont("Helvetica-Bold", 12f);

        public void UpdateFormcodeItemList(string PDF_SQL_query)
        {
            FormcodeItemList.Clear();
            for (int i = 0; i < 14; i++)
            {
                FormcodeItemList.Add(new FormcodeItem());
            }
            ItemcodeList.Clear();

            //formcode/multiple choice
            var con = new MySqlConnection(connection_string);
            con.Open();
            int data_count = 0;
            sql = PDF_SQL_query;
            var cmd = new MySqlCommand(sql, con);
            MySqlDataReader data_reader = cmd.ExecuteReader();

            if (data_reader.HasRows)
            {
                while (data_reader.Read())
                {
                    if (data_count == 0)
                    {
                        if (!data_reader.IsDBNull(4))
                        {
                            customer_fax = data_reader.GetString("fax");
                        }
                    }
                    ItemcodeList.Add(data_reader.GetString("itemcode"));
                    FormcodeItemList[data_count].itemcode = data_reader.GetString("itemcode");

                    if (!data_reader.IsDBNull(1))
                    {
                        if (data_reader.GetString("finalresult") == "-1.0")
                        {
                            FormcodeItemList[data_count].finalresult = "REJ";
                        }
                        else if (data_reader.GetString("finalresult") == "-2.0")
                        {
                            FormcodeItemList[data_count].finalresult = "REDO";
                        }
                        else if (data_reader.GetString("finalresult") == "-3.0")
                        {
                            FormcodeItemList[data_count].finalresult = "LOW";
                        }
                        else
                        {

                            FormcodeItemList[data_count].finalresult = data_reader.GetString("finalresult");
                        }
                    }

                    FormcodeItemList[data_count].sampleweight = $"{data_reader.GetString("sampleweight")}g";
                    if (data_reader.IsDBNull(3))
                    {
                        FormcodeItemList[data_count].samplereturn = "None";
                    }
                    else
                    {
                        FormcodeItemList[data_count].samplereturn = $"{data_reader.GetString("samplereturn")}g";
                    }
                    data_count++;
                }
            }
            data_reader.Close();
            con.Close();
        }
        private static FaxServer faxServer;
        public void FaxPDF(string faxpath, string customerfax, string customer)
        {
            try
            {
                var faxServer = new FAXCOMEXLib.FaxServer();
                var faxDoc = new FAXCOMEXLib.FaxDocument();
                faxServer.Connect("");
                faxDoc.Body = faxpath;
                faxDoc.Recipients.Add(customerfax, customer);
                faxDoc.ConnectedSubmit(faxServer);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        public void EmailPDF(string emailpath, string customername, string itemcode, string customeremail)
        {
            using (var client = new SmtpClient())
            {
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(company_email, "eisg plyr vwug qnid");
                using (var message = new MailMessage(
                    from: new MailAddress(company_email, company_name),
                    to: new MailAddress(customeremail, customername)
                    ))
                {
                    message.Subject = $"ASSAY REPORT ({itemcode})";
                    message.Body = $"Attached is the assay report. Contact {company_phone_one} or {company_phone_two} for assistance.";
                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment(emailpath);
                    attachment.ContentDisposition.FileName = $"{customername} {itemcode}.pdf";
                    message.Attachments.Add(attachment);
                    client.Send(message);
                }
            }


        }

        public void PrintPDF(string printpath)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.Verb = "print";
            info.FileName = printpath;
            info.CreateNoWindow = true;
            info.WindowStyle = ProcessWindowStyle.Hidden;

            Process p = new Process();
            p.StartInfo = info;
            p.Start();
        }

        public void GeneratePDF(string source, string customer, string date, string filename = "0")
        {
            FileStream fs = new FileStream($"temp/{filename}.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document(PageSize.A5, 20f, 20f, 20f, 20f);
            PdfWriter.GetInstance(document, fs);
            //COMPANY NAME
            Paragraph companyname_paragraph = new Paragraph(company_name, title_bold_helvetica);
            companyname_paragraph.Leading = 10f;
            //ADDRESS
            Paragraph address_paragraph = new Paragraph(company_address_one + company_address_two, medium_helvetica);
            address_paragraph.Leading = 10f;
            //LAYOUT TABLE
            PdfPTable layout_table = new PdfPTable(2);
            layout_table.TotalWidth = 380;
            layout_table.LockedWidth = true;
            //relative col widths
            float[] layout_widths = new float[] { 7f, 3f };
            layout_table.SetWidths(layout_widths);
            //layout_table.DefaultCell.Border = Border.NO_BORDER;
            layout_table.SpacingBefore = 0;
            layout_table.SpacingAfter = 0;
            layout_table.HorizontalAlignment = 0;
            //layout_table.SpacingBefore = 5f;
            PdfPCell layout_left_cell = new PdfPCell(new Paragraph(company_phone_one + " " + company_phone_two, medium_helvetica));
            layout_left_cell.HorizontalAlignment = (Element.ALIGN_LEFT);
            layout_left_cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            layout_table.AddCell(layout_left_cell);
            PdfPCell layout_right_cell = new PdfPCell(new Paragraph("Date: " + date, medium_helvetica));
            layout_right_cell.HorizontalAlignment = (Element.ALIGN_RIGHT);
            layout_right_cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            layout_table.AddCell(layout_right_cell);
            //TELEPHONE
            //Paragraph tel_paragraph = new Paragraph(company_phone_one + " " + company_phone_two, medium_helvetica);
            //tel_paragraph.Leading = 10f;
            //ASSAY DATE
            //Paragraph date_paragraph = new Paragraph("Date: " + date);
            //date_paragraph.Leading = 13f;

            //CUSTOMER
            Paragraph customer_paragraph = new Paragraph(customer, title_bold_helvetica);
            customer_paragraph.Leading = 15f;

            //RESULT TABLE
            PdfPTable result_table = new PdfPTable(3);
            result_table.TotalWidth = 380;
            result_table.LockedWidth = true;

            //relative col widths
            float[] result_widths = new float[] { 7f, 1f, 1.5f };
            result_table.SetWidths(result_widths);
            result_table.HorizontalAlignment = 0;
            result_table.SpacingBefore = 5f;
            //result_table.SpacingAfter = 5f;
            //Title Row
            result_table.AddCell(new Phrase("ITEM CODE", title_bold_helvetica));
            PdfPTable title_nested = new PdfPTable(1);
            PdfPCell title_sw = new PdfPCell(new Phrase("S.Weight", small_helvetica));
            title_sw.HorizontalAlignment = (Element.ALIGN_CENTER);
            title_nested.AddCell(title_sw);
            PdfPCell title_sr = new PdfPCell(new Phrase("S.Return", small_helvetica));
            title_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            title_nested.AddCell(title_sr);
            PdfPCell title_insert_nested = new PdfPCell(title_nested);
            title_insert_nested.Padding = 0f;
            result_table.AddCell(title_insert_nested);
            result_table.AddCell(new Phrase("Fineness", fineness_helvetica));
            //First Row
            result_table.AddCell(new Phrase(FormcodeItemList[0].itemcode, bold_helvetica));
            PdfPTable first_nested = new PdfPTable(1);
            PdfPCell first_first_sr = new PdfPCell(new Phrase(FormcodeItemList[0].sampleweight, small_helvetica));
            first_first_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            first_nested.AddCell(first_first_sr);
            PdfPCell first_second_sr = new PdfPCell(new Phrase(FormcodeItemList[0].samplereturn, small_helvetica));
            first_second_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            first_nested.AddCell(first_second_sr);
            PdfPCell first_insert_nested = new PdfPCell(first_nested);
            first_insert_nested.Padding = 0f;
            result_table.AddCell(first_insert_nested);
            PdfPCell first_fineness = new PdfPCell(new Phrase(FormcodeItemList[0].finalresult, bold_helvetica));
            first_fineness.HorizontalAlignment = (Element.ALIGN_CENTER);
            result_table.AddCell(first_fineness);
            //Second Row
            result_table.AddCell(new Phrase(FormcodeItemList[1].itemcode, bold_helvetica));
            PdfPTable second_nested = new PdfPTable(1);
            PdfPCell second_first_sr = new PdfPCell(new Phrase(FormcodeItemList[1].sampleweight, small_helvetica));
            second_first_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            second_nested.AddCell(second_first_sr);
            PdfPCell second_second_sr = new PdfPCell(new Phrase(FormcodeItemList[1].samplereturn, small_helvetica));
            second_second_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            second_nested.AddCell(second_second_sr);
            PdfPCell second_insert_nested = new PdfPCell(second_nested);
            second_insert_nested.Padding = 0f;
            result_table.AddCell(second_insert_nested);
            PdfPCell second_fineness = new PdfPCell(new Phrase(FormcodeItemList[1].finalresult, bold_helvetica));
            second_fineness.HorizontalAlignment = (Element.ALIGN_CENTER);
            result_table.AddCell(second_fineness);
            //Third Row
            result_table.AddCell(new Phrase(FormcodeItemList[2].itemcode, bold_helvetica));
            PdfPTable third_nested = new PdfPTable(1);
            PdfPCell third_first_sr = new PdfPCell(new Phrase(FormcodeItemList[2].sampleweight, small_helvetica));
            third_first_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            third_nested.AddCell(third_first_sr);
            PdfPCell third_second_sr = new PdfPCell(new Phrase(FormcodeItemList[2].samplereturn, small_helvetica));
            third_second_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            third_nested.AddCell(third_second_sr);
            PdfPCell third_insert_nested = new PdfPCell(third_nested);
            third_insert_nested.Padding = 0f;
            result_table.AddCell(third_insert_nested);
            PdfPCell third_fineness = new PdfPCell(new Phrase(FormcodeItemList[2].finalresult, bold_helvetica));
            third_fineness.HorizontalAlignment = (Element.ALIGN_CENTER);
            result_table.AddCell(third_fineness);
            //Fourth Row
            result_table.AddCell(new Phrase(FormcodeItemList[3].itemcode, bold_helvetica));
            PdfPTable fourth_nested = new PdfPTable(1);
            PdfPCell fourth_first_sr = new PdfPCell(new Phrase(FormcodeItemList[3].sampleweight, small_helvetica));
            fourth_first_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            fourth_nested.AddCell(fourth_first_sr);
            PdfPCell fourth_second_sr = new PdfPCell(new Phrase(FormcodeItemList[3].samplereturn, small_helvetica));
            fourth_second_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            fourth_nested.AddCell(fourth_second_sr);
            PdfPCell fourth_insert_nested = new PdfPCell(fourth_nested);
            fourth_insert_nested.Padding = 0f;
            result_table.AddCell(fourth_insert_nested);
            PdfPCell fourth_fineness = new PdfPCell(new Phrase(FormcodeItemList[3].finalresult, bold_helvetica));
            fourth_fineness.HorizontalAlignment = (Element.ALIGN_CENTER);
            result_table.AddCell(fourth_fineness);
            //Fifth Row
            result_table.AddCell(new Phrase(FormcodeItemList[4].itemcode, bold_helvetica));
            PdfPTable fifth_nested = new PdfPTable(1);
            PdfPCell fifth_first_sr = new PdfPCell(new Phrase(FormcodeItemList[4].sampleweight, small_helvetica));
            fifth_first_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            fifth_nested.AddCell(fifth_first_sr);
            PdfPCell fifth_second_sr = new PdfPCell(new Phrase(FormcodeItemList[4].samplereturn, small_helvetica));
            fifth_second_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            fifth_nested.AddCell(fifth_second_sr);
            PdfPCell fifth_insert_nested = new PdfPCell(fifth_nested);
            fifth_insert_nested.Padding = 0f;
            result_table.AddCell(fifth_insert_nested);
            PdfPCell fifth_fineness = new PdfPCell(new Phrase(FormcodeItemList[4].finalresult, bold_helvetica));
            fifth_fineness.HorizontalAlignment = (Element.ALIGN_CENTER);
            result_table.AddCell(fifth_fineness);
            //Sixth Row
            result_table.AddCell(new Phrase(FormcodeItemList[5].itemcode, bold_helvetica));
            PdfPTable sixth_nested = new PdfPTable(1);
            PdfPCell sixth_first_sr = new PdfPCell(new Phrase(FormcodeItemList[5].sampleweight, small_helvetica));
            sixth_first_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            sixth_nested.AddCell(sixth_first_sr);
            PdfPCell sixth_second_sr = new PdfPCell(new Phrase(FormcodeItemList[5].samplereturn, small_helvetica));
            sixth_second_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            sixth_nested.AddCell(sixth_second_sr);
            PdfPCell sixth_insert_nested = new PdfPCell(sixth_nested);
            sixth_insert_nested.Padding = 0f;
            result_table.AddCell(sixth_insert_nested);
            PdfPCell sixth_fineness = new PdfPCell(new Phrase(FormcodeItemList[5].finalresult, bold_helvetica));
            sixth_fineness.HorizontalAlignment = (Element.ALIGN_CENTER);
            result_table.AddCell(sixth_fineness);
            //Seventh Row
            result_table.AddCell(new Phrase(FormcodeItemList[6].itemcode, bold_helvetica));
            PdfPTable seventh_nested = new PdfPTable(1);
            PdfPCell seventh_first_sr = new PdfPCell(new Phrase(FormcodeItemList[6].sampleweight, small_helvetica));
            seventh_first_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            seventh_nested.AddCell(seventh_first_sr);
            PdfPCell seventh_second_sr = new PdfPCell(new Phrase(FormcodeItemList[6].samplereturn, small_helvetica));
            seventh_second_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            seventh_nested.AddCell(seventh_second_sr);
            PdfPCell seventh_insert_nested = new PdfPCell(seventh_nested);
            seventh_insert_nested.Padding = 0f;
            result_table.AddCell(seventh_insert_nested);
            PdfPCell seventh_fineness = new PdfPCell(new Phrase(FormcodeItemList[6].finalresult, bold_helvetica));
            seventh_fineness.HorizontalAlignment = (Element.ALIGN_CENTER);
            result_table.AddCell(seventh_fineness);
            //Eighth Row
            result_table.AddCell(new Phrase(FormcodeItemList[7].itemcode, bold_helvetica));
            PdfPTable eighth_nested = new PdfPTable(1);
            PdfPCell eighth_first_sr = new PdfPCell(new Phrase(FormcodeItemList[7].sampleweight, small_helvetica));
            eighth_first_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            eighth_nested.AddCell(eighth_first_sr);
            PdfPCell eighth_second_sr = new PdfPCell(new Phrase(FormcodeItemList[7].samplereturn, small_helvetica));
            eighth_second_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            eighth_nested.AddCell(eighth_second_sr);
            PdfPCell eighth_insert_nested = new PdfPCell(eighth_nested);
            eighth_insert_nested.Padding = 0f;
            result_table.AddCell(eighth_insert_nested);
            PdfPCell eighth_fineness = new PdfPCell(new Phrase(FormcodeItemList[7].finalresult, bold_helvetica));
            eighth_fineness.HorizontalAlignment = (Element.ALIGN_CENTER);
            result_table.AddCell(eighth_fineness);
            //Ninth Row
            result_table.AddCell(new Phrase(FormcodeItemList[8].itemcode, bold_helvetica));
            PdfPTable ninth_nested = new PdfPTable(1);
            PdfPCell ninth_first_sr = new PdfPCell(new Phrase(FormcodeItemList[8].sampleweight, small_helvetica));
            ninth_first_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            ninth_nested.AddCell(ninth_first_sr);
            PdfPCell ninth_second_sr = new PdfPCell(new Phrase(FormcodeItemList[8].samplereturn, small_helvetica));
            ninth_second_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            ninth_nested.AddCell(ninth_second_sr);
            PdfPCell ninth_insert_nested = new PdfPCell(ninth_nested);
            ninth_insert_nested.Padding = 0f;
            result_table.AddCell(ninth_insert_nested);
            PdfPCell ninth_fineness = new PdfPCell(new Phrase(FormcodeItemList[8].finalresult, bold_helvetica));
            ninth_fineness.HorizontalAlignment = (Element.ALIGN_CENTER);
            result_table.AddCell(ninth_fineness);
            //Tenth Row
            result_table.AddCell(new Phrase(FormcodeItemList[9].itemcode, bold_helvetica));
            PdfPTable tenth_nested = new PdfPTable(1);
            PdfPCell tenth_first_sr = new PdfPCell(new Phrase(FormcodeItemList[9].sampleweight, small_helvetica));
            tenth_first_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            tenth_nested.AddCell(tenth_first_sr);
            PdfPCell tenth_second_sr = new PdfPCell(new Phrase(FormcodeItemList[9].samplereturn, small_helvetica));
            tenth_second_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            tenth_nested.AddCell(tenth_second_sr);
            PdfPCell tenth_insert_nested = new PdfPCell(tenth_nested);
            tenth_insert_nested.Padding = 0f;
            result_table.AddCell(tenth_insert_nested);
            PdfPCell tenth_fineness = new PdfPCell(new Phrase(FormcodeItemList[9].finalresult, bold_helvetica));
            tenth_fineness.HorizontalAlignment = (Element.ALIGN_CENTER);
            result_table.AddCell(tenth_fineness);
            //Eleventh Row
            result_table.AddCell(new Phrase(FormcodeItemList[10].itemcode, bold_helvetica));
            PdfPTable eleventh_nested = new PdfPTable(1);
            PdfPCell eleventh_first_sr = new PdfPCell(new Phrase(FormcodeItemList[10].sampleweight, small_helvetica));
            eleventh_first_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            eleventh_nested.AddCell(eleventh_first_sr);
            PdfPCell eleventh_second_sr = new PdfPCell(new Phrase(FormcodeItemList[10].samplereturn, small_helvetica));
            eleventh_second_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            eleventh_nested.AddCell(eleventh_second_sr);
            PdfPCell eleventh_insert_nested = new PdfPCell(eleventh_nested);
            eleventh_insert_nested.Padding = 0f;
            result_table.AddCell(eleventh_insert_nested);
            PdfPCell eleventh_fineness = new PdfPCell(new Phrase(FormcodeItemList[10].finalresult, bold_helvetica));
            eleventh_fineness.HorizontalAlignment = (Element.ALIGN_CENTER);
            result_table.AddCell(eleventh_fineness);
            //Twelve Row
            result_table.AddCell(new Phrase(FormcodeItemList[11].itemcode, bold_helvetica));
            PdfPTable twelfth_nested = new PdfPTable(1);
            PdfPCell twelfth_first_sr = new PdfPCell(new Phrase(FormcodeItemList[11].sampleweight, small_helvetica));
            twelfth_first_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            twelfth_nested.AddCell(twelfth_first_sr);
            PdfPCell twelfth_second_sr = new PdfPCell(new Phrase(FormcodeItemList[11].samplereturn, small_helvetica));
            twelfth_second_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            twelfth_nested.AddCell(twelfth_second_sr);
            PdfPCell twelfth_insert_nested = new PdfPCell(twelfth_nested);
            twelfth_insert_nested.Padding = 0f;
            result_table.AddCell(twelfth_insert_nested);
            PdfPCell twelfth_fineness = new PdfPCell(new Phrase(FormcodeItemList[11].finalresult, bold_helvetica));
            twelfth_fineness.HorizontalAlignment = (Element.ALIGN_CENTER);
            result_table.AddCell(twelfth_fineness);
            //Thirteen Row
            result_table.AddCell(new Phrase(FormcodeItemList[12].itemcode, bold_helvetica));
            PdfPTable thirteenth_nested = new PdfPTable(1);
            PdfPCell thirteenth_first_sr = new PdfPCell(new Phrase(FormcodeItemList[12].sampleweight, small_helvetica));
            thirteenth_first_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            thirteenth_nested.AddCell(thirteenth_first_sr);
            PdfPCell thirteenth_second_sr = new PdfPCell(new Phrase(FormcodeItemList[12].samplereturn, small_helvetica));
            thirteenth_second_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            thirteenth_nested.AddCell(thirteenth_second_sr);
            PdfPCell thirteenth_insert_nested = new PdfPCell(thirteenth_nested);
            thirteenth_insert_nested.Padding = 0f;
            result_table.AddCell(thirteenth_insert_nested);
            PdfPCell thirteenth_fineness = new PdfPCell(new Phrase(FormcodeItemList[12].finalresult, bold_helvetica));
            thirteenth_fineness.HorizontalAlignment = (Element.ALIGN_CENTER);
            result_table.AddCell(thirteenth_fineness);
            //Fourteen Row
            result_table.AddCell(new Phrase(FormcodeItemList[13].itemcode, bold_helvetica));
            PdfPTable fourteenth_nested = new PdfPTable(1);
            PdfPCell fourteenth_first_sr = new PdfPCell(new Phrase(FormcodeItemList[13].sampleweight, small_helvetica));
            fourteenth_first_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            fourteenth_nested.AddCell(fourteenth_first_sr);
            PdfPCell fourteenth_second_sr = new PdfPCell(new Phrase(FormcodeItemList[13].samplereturn, small_helvetica));
            fourteenth_second_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            fourteenth_nested.AddCell(fourteenth_second_sr);
            PdfPCell fourteenth_insert_nested = new PdfPCell(fourteenth_nested);
            fourteenth_insert_nested.Padding = 0f;
            result_table.AddCell(fourteenth_insert_nested);
            PdfPCell fourteenth_fineness = new PdfPCell(new Phrase(FormcodeItemList[13].finalresult, bold_helvetica));
            fourteenth_fineness.HorizontalAlignment = (Element.ALIGN_CENTER);
            result_table.AddCell(fourteenth_fineness);

            //TERMS
            Paragraph terms_paragraph = new Paragraph("\nNOTE:\n" +
                "1. The gold fire assay is conducted following the standardized reference utilized by assay laboratories globally for the purpose of hallmarking.\n" +
                "2. The indicated fineness of the precious metal content serves as a reference only and is not officially certified for any hallmarking purposes. \n" +
                "3. We shall not assume any legal liability for discrepancies identified.\n" +
                "4. We strongly encourage customer to take back their sample left as soon as possible.\n" +
                "5. We shall not assume any legal liability for any loss, damage, or theft of samples left.", medium_helvetica);
            terms_paragraph.Leading = 10f;

            //FOOTER
            Paragraph footer_paragraph = new Paragraph("\n\n\nReceived by: ______________");

            document.Open();
            document.Add(companyname_paragraph);
            document.Add(address_paragraph);
            document.Add(layout_table);
            //document.Add(tel_paragraph);
            //document.Add(date_paragraph);
            document.Add(customer_paragraph);
            document.Add(result_table);
            document.Add(terms_paragraph);
            document.Add(footer_paragraph);
            document.Close();
            PdfToJpg($"temp/{filename}.pdf", $"temp/{filename}");
        }

        public void GeneratePDFSplit(string source, string customer, string date, string filename = "0")
        {
            //MessageBox.Show(FormcodeItemList.Count.ToString());

            FileStream fs = new FileStream($"temp/{filename}.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document(PageSize.A5, 20f, 20f, 20f, 20f);
            PdfWriter.GetInstance(document, fs);
            //COMPANY NAME
            Paragraph companyname_paragraph = new Paragraph(company_name, title_bold_helvetica);
            companyname_paragraph.Leading = 10f;
            //ADDRESS
            Paragraph address_paragraph = new Paragraph(company_address_one + company_address_two, medium_helvetica);
            address_paragraph.Leading = 10f;
            //LAYOUT TABLE
            PdfPTable layout_table = new PdfPTable(2);
            layout_table.TotalWidth = 380;
            layout_table.LockedWidth = true;
            //relative col widths
            float[] layout_widths = new float[] { 7f, 3f };
            layout_table.SetWidths(layout_widths);
            //layout_table.DefaultCell.Border = Border.NO_BORDER;
            layout_table.SpacingBefore = 0;
            layout_table.SpacingAfter = 0;
            layout_table.HorizontalAlignment = 0;
            //layout_table.SpacingBefore = 5f;
            PdfPCell layout_left_cell = new PdfPCell(new Paragraph(company_phone_one + " " + company_phone_two, medium_helvetica));
            layout_left_cell.HorizontalAlignment = (Element.ALIGN_LEFT);
            layout_left_cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            layout_table.AddCell(layout_left_cell);
            PdfPCell layout_right_cell = new PdfPCell(new Paragraph("Date: " + date, medium_helvetica));
            layout_right_cell.HorizontalAlignment = (Element.ALIGN_RIGHT);
            layout_right_cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            layout_table.AddCell(layout_right_cell);
            //TELEPHONE
            //Paragraph tel_paragraph = new Paragraph(company_phone_one + " " + company_phone_two, medium_helvetica);
            //tel_paragraph.Leading = 10f;
            //ASSAY DATE
            //Paragraph date_paragraph = new Paragraph("Date: " + date);
            //date_paragraph.Leading = 13f;
            //CUSTOMER
            Paragraph customer_paragraph = new Paragraph(customer, title_bold_helvetica);
            customer_paragraph.Leading = 15f;

            //RESULT TABLE
            PdfPTable result_table = new PdfPTable(3);
            result_table.TotalWidth = 380;
            result_table.LockedWidth = true;

            //relative col widths
            float[] result_widths = new float[] { 7f, 1f, 1.5f };
            result_table.SetWidths(result_widths);
            result_table.HorizontalAlignment = 0;
            result_table.SpacingBefore = 5f;
            //result_table.SpacingAfter = 5f;
            //Title Row
            result_table.AddCell(new Phrase("ITEM CODE", title_bold_helvetica));
            PdfPTable title_nested = new PdfPTable(1);
            PdfPCell title_sw = new PdfPCell(new Phrase("S.Weight", small_helvetica));
            title_sw.HorizontalAlignment = (Element.ALIGN_CENTER);
            title_nested.AddCell(title_sw);
            PdfPCell title_sr = new PdfPCell(new Phrase("S.Return", small_helvetica));
            title_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            title_nested.AddCell(title_sr);
            PdfPCell title_insert_nested = new PdfPCell(title_nested);
            title_insert_nested.Padding = 0f;
            result_table.AddCell(title_insert_nested);
            result_table.AddCell(new Phrase("Fineness", fineness_helvetica));
            //First Row
            result_table.AddCell(new Phrase(FormcodeItemList[0].itemcode, bold_helvetica));
            PdfPTable first_nested = new PdfPTable(1);
            PdfPCell first_first_sr = new PdfPCell(new Phrase(FormcodeItemList[0].sampleweight, small_helvetica));
            first_first_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            first_nested.AddCell(first_first_sr);
            PdfPCell first_second_sr = new PdfPCell(new Phrase(FormcodeItemList[0].samplereturn, small_helvetica));
            first_second_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            first_nested.AddCell(first_second_sr);
            PdfPCell first_insert_nested = new PdfPCell(first_nested);
            first_insert_nested.Padding = 0f;
            result_table.AddCell(first_insert_nested);
            PdfPCell first_fineness = new PdfPCell(new Phrase(FormcodeItemList[0].finalresult, bold_helvetica));
            first_fineness.HorizontalAlignment = (Element.ALIGN_CENTER);
            result_table.AddCell(first_fineness);
            //Second Row
            result_table.AddCell(new Phrase(" ", bold_helvetica));
            PdfPTable second_nested = new PdfPTable(1);
            PdfPCell second_first_sr = new PdfPCell(new Phrase(" ", small_helvetica));
            second_first_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            second_nested.AddCell(second_first_sr);
            PdfPCell second_second_sr = new PdfPCell(new Phrase(" ", small_helvetica));
            second_second_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            second_nested.AddCell(second_second_sr);
            PdfPCell second_insert_nested = new PdfPCell(second_nested);
            second_insert_nested.Padding = 0f;
            result_table.AddCell(second_insert_nested);
            PdfPCell second_fineness = new PdfPCell(new Phrase(" ", bold_helvetica));
            second_fineness.HorizontalAlignment = (Element.ALIGN_CENTER);
            result_table.AddCell(second_fineness);
            //Third Row
            result_table.AddCell(new Phrase(" ", bold_helvetica));
            PdfPTable third_nested = new PdfPTable(1);
            PdfPCell third_first_sr = new PdfPCell(new Phrase(" ", small_helvetica));
            third_first_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            third_nested.AddCell(third_first_sr);
            PdfPCell third_second_sr = new PdfPCell(new Phrase(" ", small_helvetica));
            third_second_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            third_nested.AddCell(third_second_sr);
            PdfPCell third_insert_nested = new PdfPCell(third_nested);
            third_insert_nested.Padding = 0f;
            result_table.AddCell(third_insert_nested);
            PdfPCell third_fineness = new PdfPCell(new Phrase(" ", bold_helvetica));
            third_fineness.HorizontalAlignment = (Element.ALIGN_CENTER);
            result_table.AddCell(third_fineness);
            //Fourth Row
            result_table.AddCell(new Phrase(" ", bold_helvetica));
            PdfPTable fourth_nested = new PdfPTable(1);
            PdfPCell fourth_first_sr = new PdfPCell(new Phrase(" ", small_helvetica));
            fourth_first_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            fourth_nested.AddCell(fourth_first_sr);
            PdfPCell fourth_second_sr = new PdfPCell(new Phrase(" ", small_helvetica));
            fourth_second_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            fourth_nested.AddCell(fourth_second_sr);
            PdfPCell fourth_insert_nested = new PdfPCell(fourth_nested);
            fourth_insert_nested.Padding = 0f;
            result_table.AddCell(fourth_insert_nested);
            PdfPCell fourth_fineness = new PdfPCell(new Phrase(" ", bold_helvetica));
            fourth_fineness.HorizontalAlignment = (Element.ALIGN_CENTER);
            result_table.AddCell(fourth_fineness);
            //Fifth Row
            result_table.AddCell(new Phrase(" ", bold_helvetica));
            PdfPTable fifth_nested = new PdfPTable(1);
            PdfPCell fifth_first_sr = new PdfPCell(new Phrase(" ", small_helvetica));
            fifth_first_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            fifth_nested.AddCell(fifth_first_sr);
            PdfPCell fifth_second_sr = new PdfPCell(new Phrase(" ", small_helvetica));
            fifth_second_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            fifth_nested.AddCell(fifth_second_sr);
            PdfPCell fifth_insert_nested = new PdfPCell(fifth_nested);
            fifth_insert_nested.Padding = 0f;
            result_table.AddCell(fifth_insert_nested);
            PdfPCell fifth_fineness = new PdfPCell(new Phrase(" ", bold_helvetica));
            fifth_fineness.HorizontalAlignment = (Element.ALIGN_CENTER);
            result_table.AddCell(fifth_fineness);
            //Sixth Row
            result_table.AddCell(new Phrase(" ", bold_helvetica));
            PdfPTable sixth_nested = new PdfPTable(1);
            PdfPCell sixth_first_sr = new PdfPCell(new Phrase(" ", small_helvetica));
            sixth_first_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            sixth_nested.AddCell(sixth_first_sr);
            PdfPCell sixth_second_sr = new PdfPCell(new Phrase(" ", small_helvetica));
            sixth_second_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            sixth_nested.AddCell(sixth_second_sr);
            PdfPCell sixth_insert_nested = new PdfPCell(sixth_nested);
            sixth_insert_nested.Padding = 0f;
            result_table.AddCell(sixth_insert_nested);
            PdfPCell sixth_fineness = new PdfPCell(new Phrase(" ", bold_helvetica));
            sixth_fineness.HorizontalAlignment = (Element.ALIGN_CENTER);
            result_table.AddCell(sixth_fineness);
            //Seventh Row
            result_table.AddCell(new Phrase(" ", bold_helvetica));
            PdfPTable seventh_nested = new PdfPTable(1);
            PdfPCell seventh_first_sr = new PdfPCell(new Phrase(" ", small_helvetica));
            seventh_first_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            seventh_nested.AddCell(seventh_first_sr);
            PdfPCell seventh_second_sr = new PdfPCell(new Phrase(" ", small_helvetica));
            seventh_second_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            seventh_nested.AddCell(seventh_second_sr);
            PdfPCell seventh_insert_nested = new PdfPCell(seventh_nested);
            seventh_insert_nested.Padding = 0f;
            result_table.AddCell(seventh_insert_nested);
            PdfPCell seventh_fineness = new PdfPCell(new Phrase(" ", bold_helvetica));
            seventh_fineness.HorizontalAlignment = (Element.ALIGN_CENTER);
            result_table.AddCell(seventh_fineness);
            //Eighth Row
            result_table.AddCell(new Phrase(" ", bold_helvetica));
            PdfPTable eighth_nested = new PdfPTable(1);
            PdfPCell eighth_first_sr = new PdfPCell(new Phrase(" ", small_helvetica));
            eighth_first_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            eighth_nested.AddCell(eighth_first_sr);
            PdfPCell eighth_second_sr = new PdfPCell(new Phrase(" ", small_helvetica));
            eighth_second_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            eighth_nested.AddCell(eighth_second_sr);
            PdfPCell eighth_insert_nested = new PdfPCell(eighth_nested);
            eighth_insert_nested.Padding = 0f;
            result_table.AddCell(eighth_insert_nested);
            PdfPCell eighth_fineness = new PdfPCell(new Phrase(" ", bold_helvetica));
            eighth_fineness.HorizontalAlignment = (Element.ALIGN_CENTER);
            result_table.AddCell(eighth_fineness);
            //Ninth Row
            result_table.AddCell(new Phrase(" ", bold_helvetica));
            PdfPTable ninth_nested = new PdfPTable(1);
            PdfPCell ninth_first_sr = new PdfPCell(new Phrase(" ", small_helvetica));
            ninth_first_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            ninth_nested.AddCell(ninth_first_sr);
            PdfPCell ninth_second_sr = new PdfPCell(new Phrase(" ", small_helvetica));
            ninth_second_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            ninth_nested.AddCell(ninth_second_sr);
            PdfPCell ninth_insert_nested = new PdfPCell(ninth_nested);
            ninth_insert_nested.Padding = 0f;
            result_table.AddCell(ninth_insert_nested);
            PdfPCell ninth_fineness = new PdfPCell(new Phrase(" ", bold_helvetica));
            ninth_fineness.HorizontalAlignment = (Element.ALIGN_CENTER);
            result_table.AddCell(ninth_fineness);
            //Tenth Row
            result_table.AddCell(new Phrase(" ", bold_helvetica));
            PdfPTable tenth_nested = new PdfPTable(1);
            PdfPCell tenth_first_sr = new PdfPCell(new Phrase(" ", small_helvetica));
            tenth_first_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            tenth_nested.AddCell(tenth_first_sr);
            PdfPCell tenth_second_sr = new PdfPCell(new Phrase(" ", small_helvetica));
            tenth_second_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            tenth_nested.AddCell(tenth_second_sr);
            PdfPCell tenth_insert_nested = new PdfPCell(tenth_nested);
            tenth_insert_nested.Padding = 0f;
            result_table.AddCell(tenth_insert_nested);
            PdfPCell tenth_fineness = new PdfPCell(new Phrase(" ", bold_helvetica));
            tenth_fineness.HorizontalAlignment = (Element.ALIGN_CENTER);
            result_table.AddCell(tenth_fineness);
            //Eleventh Row
            result_table.AddCell(new Phrase(" ", bold_helvetica));
            PdfPTable eleventh_nested = new PdfPTable(1);
            PdfPCell eleventh_first_sr = new PdfPCell(new Phrase(" ", small_helvetica));
            eleventh_first_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            eleventh_nested.AddCell(eleventh_first_sr);
            PdfPCell eleventh_second_sr = new PdfPCell(new Phrase(" ", small_helvetica));
            eleventh_second_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            eleventh_nested.AddCell(eleventh_second_sr);
            PdfPCell eleventh_insert_nested = new PdfPCell(eleventh_nested);
            eleventh_insert_nested.Padding = 0f;
            result_table.AddCell(eleventh_insert_nested);
            PdfPCell eleventh_fineness = new PdfPCell(new Phrase(" ", bold_helvetica));
            eleventh_fineness.HorizontalAlignment = (Element.ALIGN_CENTER);
            result_table.AddCell(eleventh_fineness);
            //Twelve Row
            result_table.AddCell(new Phrase(" ", bold_helvetica));
            PdfPTable twelfth_nested = new PdfPTable(1);
            PdfPCell twelfth_first_sr = new PdfPCell(new Phrase(" ", small_helvetica));
            twelfth_first_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            twelfth_nested.AddCell(twelfth_first_sr);
            PdfPCell twelfth_second_sr = new PdfPCell(new Phrase(" ", small_helvetica));
            twelfth_second_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            twelfth_nested.AddCell(twelfth_second_sr);
            PdfPCell twelfth_insert_nested = new PdfPCell(twelfth_nested);
            twelfth_insert_nested.Padding = 0f;
            result_table.AddCell(twelfth_insert_nested);
            PdfPCell twelfth_fineness = new PdfPCell(new Phrase(" ", bold_helvetica));
            twelfth_fineness.HorizontalAlignment = (Element.ALIGN_CENTER);
            result_table.AddCell(twelfth_fineness);
            //Thirteen Row
            result_table.AddCell(new Phrase(" ", bold_helvetica));
            PdfPTable thirteenth_nested = new PdfPTable(1);
            PdfPCell thirteenth_first_sr = new PdfPCell(new Phrase(" ", small_helvetica));
            thirteenth_first_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            thirteenth_nested.AddCell(thirteenth_first_sr);
            PdfPCell thirteenth_second_sr = new PdfPCell(new Phrase(" ", small_helvetica));
            thirteenth_second_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            thirteenth_nested.AddCell(thirteenth_second_sr);
            PdfPCell thirteenth_insert_nested = new PdfPCell(thirteenth_nested);
            thirteenth_insert_nested.Padding = 0f;
            result_table.AddCell(thirteenth_insert_nested);
            PdfPCell thirteenth_fineness = new PdfPCell(new Phrase(" ", bold_helvetica));
            thirteenth_fineness.HorizontalAlignment = (Element.ALIGN_CENTER);
            result_table.AddCell(thirteenth_fineness);
            //Fourteen Row
            result_table.AddCell(new Phrase(" ", bold_helvetica));
            PdfPTable fourteenth_nested = new PdfPTable(1);
            PdfPCell fourteenth_first_sr = new PdfPCell(new Phrase(" ", small_helvetica));
            fourteenth_first_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            fourteenth_nested.AddCell(fourteenth_first_sr);
            PdfPCell fourteenth_second_sr = new PdfPCell(new Phrase(" ", small_helvetica));
            fourteenth_second_sr.HorizontalAlignment = (Element.ALIGN_CENTER);
            fourteenth_nested.AddCell(fourteenth_second_sr);
            PdfPCell fourteenth_insert_nested = new PdfPCell(fourteenth_nested);
            fourteenth_insert_nested.Padding = 0f;
            result_table.AddCell(fourteenth_insert_nested);
            PdfPCell fourteenth_fineness = new PdfPCell(new Phrase(" ", bold_helvetica));
            fourteenth_fineness.HorizontalAlignment = (Element.ALIGN_CENTER);
            result_table.AddCell(fourteenth_fineness);

            //TERMS
            Paragraph terms_paragraph = new Paragraph("\nNOTE:\n" +
                "1. The gold fire assay is conducted following the standardized reference utilized by assay laboratories globally for the purpose of hallmarking.\n" +
                "2. The indicated fineness of the precious metal content serves as a reference only and is not officially certified for any hallmarking purposes. \n" +
                "3. We shall not assume any legal liability for discrepancies identified.\n" +
                "4. We strongly encourage customer to take back their sample left as soon as possible.\n" +
                "5. We shall not assume any legal liability for any loss, damage, or theft of samples left.", medium_helvetica);
            terms_paragraph.Leading = 10f;

            //FOOTER
            Paragraph footer_paragraph = new Paragraph("\n\n\nReceived by: ______________");

            document.Open();
            document.Add(companyname_paragraph);
            document.Add(address_paragraph);
            document.Add(layout_table);
            //document.Add(tel_paragraph);
            //document.Add(date_paragraph);
            document.Add(customer_paragraph);
            document.Add(result_table);
            document.Add(terms_paragraph);
            document.Add(footer_paragraph);
            document.Close();
            PdfToJpg($"temp/{filename}.pdf", $"temp/{filename}");
            FormcodeItemList.RemoveAt(0);
        }

        //Ghostscript PDF to JPG
        private void PdfToJpg(string inputPDFFile, string outputImagesPath)
        {
            string ghostScriptPath = @"C:\Program Files\gs\gs9.54.0\bin\gswin64.exe";
            //string ghostScriptPath = @"C:\Program Files\gs\gs9.56.1\bin\gswin64.exe";
            String ars = "-dNOPAUSE -sDEVICE=jpeg -r300 -o" + outputImagesPath + "%d.jpg -sPAPERSIZE=a5 " + inputPDFFile;
            Process gs_process = new Process();
            gs_process.StartInfo.FileName = ghostScriptPath;
            gs_process.StartInfo.Arguments = ars;
            gs_process.StartInfo.CreateNoWindow = true;
            gs_process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            gs_process.Start();
            gs_process.WaitForExit();
        }
        public void LoadCompanyInfo()
        {
            try
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
                        company_name = data_reader.GetString("name");
                        company_address_one = data_reader.GetString("addressone");
                        company_address_two = data_reader.GetString("addresstwo");
                        company_phone_one = data_reader.GetString("phone");
                        company_phone_two = data_reader.GetString("phonetwo");
                        company_email = data_reader.GetString("companyemail");
                        company_email_pw = data_reader.GetString("mailpw");
                    }
                }
                data_reader.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }

        List<string> HistoryListboxItemList = new List<string>();
        //History

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
            {
                e.KeyChar -= (char)32;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 40)
            {
                HistoryListbox.Focus();
                HistoryListbox.SelectedIndex = 0;
                e.SuppressKeyPress = true;

            }
            if (e.KeyValue == 13)
            {
                HistoryItemcodeTextbox.Focus();
                e.SuppressKeyPress = true;

            }
        }
        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                HistoryCustomerTextbox.Focus();
                HistoryCustomerTextbox.Text = HistoryListbox.GetItemText(HistoryListbox.SelectedItem);
                HistoryCustomerTextbox.SelectionStart = HistoryCustomerTextbox.Text.Length;
                HistoryCustomerTextbox.SelectionLength = 0;
                HistoryListbox.Visible = false;
                e.SuppressKeyPress = true;

            }
            if (e.KeyValue == 38 && HistoryListbox.SelectedIndex == 0)
            {
                HistoryCustomerTextbox.Focus();
                e.SuppressKeyPress = true;

            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (HistoryCustomerTextbox.Text == string.Empty)
            {
                HistoryListbox.Visible = false;
                HistoryListbox.Items.Clear();
                for (int i = 0; i < HistoryListboxItemList.Count; i++)
                {
                    HistoryListbox.Items.Add(HistoryListboxItemList[i]);
                }
            }
            else
            {
                HistoryListbox.Items.Clear();
                string search_str = HistoryCustomerTextbox.Text;
                for (int i = 0; i < HistoryListboxItemList.Count; i++)
                {
                    if (HistoryListboxItemList[i].Contains(search_str))
                    {
                        HistoryListbox.Items.Add(HistoryListboxItemList[i]);
                    }
                }

                HistoryListbox.Visible = true;
                Cursor.Current = Cursors.Default;
                HistoryListbox.SelectedIndex = -1;

                //HistoryCustomerCombobox.Text = search_str;
                //listBox1.Select(listBox1.Text.Length, 0);

            }
        }
        public void LoadHistoryCustomerList()
        {
            try
            {
                var con = new MySqlConnection(connection_string);
                con.Open();

                sql = "SELECT name FROM user WHERE role ='customer' ORDER BY name ASC";
                var cmd = new MySqlCommand(sql, con);

                MySqlDataReader data_reader = cmd.ExecuteReader();
                HistoryListbox.Items.Clear();
                HistoryListboxItemList.Clear();
                if (data_reader.HasRows)
                {
                    while (data_reader.Read())
                    {
                        HistoryListbox.Items.Add(data_reader.GetString("name"));
                        HistoryListboxItemList.Add(data_reader.GetString("name"));
                    }
                }
                data_reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }

        private void HistorySearchButton_Click(object sender, EventArgs e)
        {
            try
            {

                if (HistoryCustomerTextbox.Text != "" && HistoryItemcodeTextbox.Text != "")
                {
                    sql = $"SELECT user.name AS customer, assayresult.formcode AS formcode, assayresult.itemcode AS itemcode, assayresult.created AS date, assayresult.fwa AS FWA, assayresult.fwb AS FWB, assayresult.lwa AS LWA, assayresult.lwb AS LWB, assayresult.finalresult AS finalresult, assayresult.sampleweight AS sampleweight, assayresult.samplereturn as samplereturn,assayresult.id AS id FROM assayresult INNER JOIN user ON assayresult.customer = user.id WHERE user.name = '{HistoryCustomerTextbox.Text}' AND assayresult.itemcode = '{HistoryItemcodeTextbox.Text}' ORDER BY assayresult.formcode DESC, assayresult.created DESC";
                }
                else if (HistoryCustomerTextbox.Text != "" && HistoryItemcodeTextbox.Text == "")
                {
                    sql = $"SELECT user.name AS customer, assayresult.formcode AS formcode, assayresult.itemcode AS itemcode, assayresult.created AS date, assayresult.fwa AS FWA, assayresult.fwb AS FWB, assayresult.lwa AS LWA, assayresult.lwb AS LWB, assayresult.finalresult AS finalresult, assayresult.sampleweight AS sampleweight, assayresult.samplereturn as samplereturn, assayresult.id AS id FROM assayresult INNER JOIN user ON assayresult.customer = user.id WHERE user.name = '{HistoryCustomerTextbox.Text}' ORDER BY assayresult.formcode DESC, assayresult.created DESC";
                }
                else if (HistoryCustomerTextbox.Text == "" && HistoryItemcodeTextbox.Text != "")
                {
                    sql = $"SELECT user.name AS customer, assayresult.formcode AS formcode, assayresult.itemcode AS itemcode, assayresult.created AS date, assayresult.fwa AS FWA, assayresult.fwb AS FWB, assayresult.lwa AS LWA, assayresult.lwb AS LWB, assayresult.finalresult AS finalresult, assayresult.sampleweight AS sampleweight, assayresult.samplereturn as samplereturn, assayresult.id AS id FROM assayresult INNER JOIN user ON assayresult.customer = user.id WHERE assayresult.itemcode = '{HistoryItemcodeTextbox.Text}' ORDER BY assayresult.formcode DESC, assayresult.created DESC";
                }
                else if (HistoryCustomerTextbox.Text == "" && HistoryItemcodeTextbox.Text == "")
                {
                    MessageBox.Show("Please enter customer or itemcode for normal search.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var con = new MySqlConnection(connection_string);
                con.Open();

                var cmd = new MySqlCommand(sql, con);

                MySqlDataReader data_reader = cmd.ExecuteReader();

                HistoryDataGridView.Rows.Clear();
                HistoryDataGridView.Refresh();

                List<DataGridViewRow> History_rows = new List<DataGridViewRow>();
                if (data_reader.HasRows)
                {
                    while (data_reader.Read())
                    {
                        DataGridViewRow HistoryDatagridViewRow = new DataGridViewRow() { Height = 30 };
                        HistoryDatagridViewRow.CreateCells(HistoryDataGridView);
                        HistoryDatagridViewRow.Cells[0].Value = data_reader.GetString("customer");
                        HistoryDatagridViewRow.Cells[1].Value = data_reader.GetString("formcode");
                        HistoryDatagridViewRow.Cells[2].Value = data_reader.GetString("itemcode");
                        HistoryDatagridViewRow.Cells[3].Value = data_reader.GetDateTime("date").ToString("dd/MM/yyyy");
                        if (data_reader.IsDBNull(4))
                        {
                            HistoryDatagridViewRow.Cells[4].Value = "";
                        }
                        else
                        {
                            HistoryDatagridViewRow.Cells[4].Value = data_reader.GetString("FWA");
                        }
                        if (data_reader.IsDBNull(5))
                        {
                            HistoryDatagridViewRow.Cells[5].Value = "";
                        }
                        else
                        {
                            HistoryDatagridViewRow.Cells[5].Value = data_reader.GetString("FWB");
                        }
                        if (data_reader.IsDBNull(6))
                        {
                            HistoryDatagridViewRow.Cells[6].Value = "";
                        }
                        else
                        {
                            HistoryDatagridViewRow.Cells[6].Value = data_reader.GetString("LWA");
                        }
                        if (data_reader.IsDBNull(7))
                        {
                            HistoryDatagridViewRow.Cells[7].Value = "";
                        }
                        else
                        {
                            HistoryDatagridViewRow.Cells[7].Value = data_reader.GetString("LWB");
                        }
                        if (data_reader.IsDBNull(8))
                        {
                            HistoryDatagridViewRow.Cells[8].Value = "";
                        }
                        else
                        {
                            if (data_reader.GetString("finalresult") == "-1.0")
                            {
                                HistoryDatagridViewRow.Cells[8].Value = "REJECT";
                                HistoryDatagridViewRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                            }
                            else if (data_reader.GetString("finalresult") == "-2.0")
                            {
                                HistoryDatagridViewRow.Cells[8].Value = "REDO";
                                HistoryDatagridViewRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                            }
                            else if (data_reader.GetString("finalresult") == "-3.0")
                            {
                                HistoryDatagridViewRow.Cells[8].Value = "LOW";
                                HistoryDatagridViewRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                HistoryDatagridViewRow.Cells[8].Value = data_reader.GetString("finalresult");
                            }
                        }
                        HistoryDatagridViewRow.Cells[9].Value = data_reader.GetString("sampleweight");
                        if (data_reader.IsDBNull(10))
                        {
                            HistoryDatagridViewRow.Cells[10].Value = "";
                        }
                        else
                        {
                            HistoryDatagridViewRow.Cells[10].Value = data_reader.GetString("samplereturn");
                        }

                        HistoryDatagridViewRow.Cells[11].Value = data_reader.GetString("id");

                        History_rows.Add(HistoryDatagridViewRow);
                    }
                }
                data_reader.Close();
                HistoryDataGridView.Rows.AddRange(History_rows.ToArray());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }
        private void HistorySearchSpoilButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (HistoryCustomerTextbox.Text != "" && HistoryItemcodeTextbox.Text != "")
                {
                    return;
                    sql = $"SELECT user.name AS customer, assayresult.formcode AS formcode, assayresult.itemcode AS itemcode, assayresult.finalresult AS finalresult, assayresult.sampleweight AS sampleweight, assayresult.samplereturn as samplereturn, assayresult.created AS date, assayresult.id AS id FROM assayresult INNER JOIN user ON assayresult.customer = user.id WHERE user.name = '{HistoryCustomerTextbox.Text}' AND assayresult.itemcode = '{HistoryItemcodeTextbox.Text}' ORDER BY assayresult.formcode DESC, assayresult.created DESC";
                }
                else if (HistoryCustomerTextbox.Text != "" && HistoryItemcodeTextbox.Text == "")
                {
                    return;
                    sql = $"SELECT user.name AS customer, assayresult.formcode AS formcode, assayresult.itemcode AS itemcode, assayresult.finalresult AS finalresult, assayresult.sampleweight AS sampleweight, assayresult.samplereturn as samplereturn, assayresult.created AS date, assayresult.id AS id FROM assayresult INNER JOIN user ON assayresult.customer = user.id WHERE user.name = '{HistoryCustomerTextbox.Text}' ORDER BY assayresult.formcode DESC, assayresult.created DESC";
                }
                else if (HistoryCustomerTextbox.Text == "" && HistoryItemcodeTextbox.Text != "")
                {
                    return;
                    sql = $"SELECT user.name AS customer, assayresult.formcode AS formcode, assayresult.itemcode AS itemcode, assayresult.finalresult AS finalresult, assayresult.sampleweight AS sampleweight, assayresult.samplereturn as samplereturn, assayresult.created AS date, assayresult.id AS id FROM assayresult INNER JOIN user ON assayresult.customer = user.id WHERE assayresult.itemcode = '{HistoryItemcodeTextbox.Text}' ORDER BY assayresult.formcode DESC, assayresult.created DESC";
                }
                else if (HistoryCustomerTextbox.Text == "" && HistoryItemcodeTextbox.Text == "")
                {
                    sql = $"SELECT user.name AS customer, spoilrecord.formcode AS formcode, spoilrecord.itemcode AS itemcode,  spoilrecord.created AS date, spoilrecord.fwa AS FWA, spoilrecord.fwb AS FWB, spoilrecord.lwa AS LWA, spoilrecord.lwb AS LWB, spoilrecord.finalresult AS finalresult, spoilrecord.sampleweight AS sampleweight, spoilrecord.samplereturn as samplereturn, spoilrecord.id AS id FROM spoilrecord INNER JOIN user ON spoilrecord.customer = user.id ORDER BY spoilrecord.formcode DESC, spoilrecord.created DESC LIMIT 1000";
                }

                var con = new MySqlConnection(connection_string);
                con.Open();

                var cmd = new MySqlCommand(sql, con);

                MySqlDataReader data_reader = cmd.ExecuteReader();

                HistoryDataGridView.Rows.Clear();
                HistoryDataGridView.Refresh();

                List<DataGridViewRow> History_rows = new List<DataGridViewRow>();
                if (data_reader.HasRows)
                {
                    while (data_reader.Read())
                    {
                        DataGridViewRow HistoryDatagridViewRow = new DataGridViewRow() { Height = 30 };
                        HistoryDatagridViewRow.CreateCells(HistoryDataGridView);
                        HistoryDatagridViewRow.Cells[0].Value = data_reader.GetString("customer");
                        HistoryDatagridViewRow.Cells[1].Value = data_reader.GetString("formcode");
                        HistoryDatagridViewRow.Cells[2].Value = data_reader.GetString("itemcode");
                        HistoryDatagridViewRow.Cells[3].Value = data_reader.GetDateTime("date").ToString("dd/MM/yyyy");
                        if (data_reader.IsDBNull(4))
                        {
                            HistoryDatagridViewRow.Cells[4].Value = "";
                        }
                        else
                        {
                            HistoryDatagridViewRow.Cells[4].Value = data_reader.GetString("FWA");
                        }
                        if (data_reader.IsDBNull(5))
                        {
                            HistoryDatagridViewRow.Cells[5].Value = "";
                        }
                        else
                        {
                            HistoryDatagridViewRow.Cells[5].Value = data_reader.GetString("FWB");
                        }
                        if (data_reader.IsDBNull(6))
                        {
                            HistoryDatagridViewRow.Cells[6].Value = "";
                        }
                        else
                        {
                            HistoryDatagridViewRow.Cells[6].Value = data_reader.GetString("LWA");
                        }
                        if (data_reader.IsDBNull(7))
                        {
                            HistoryDatagridViewRow.Cells[7].Value = "";
                        }
                        else
                        {
                            HistoryDatagridViewRow.Cells[7].Value = data_reader.GetString("LWB");
                        }
                        if (data_reader.IsDBNull(8))
                        {
                            HistoryDatagridViewRow.Cells[8].Value = "";
                        }
                        else
                        {
                            if (data_reader.GetString("finalresult") == "-1.0")
                            {
                                HistoryDatagridViewRow.Cells[8].Value = "REJECT";
                                HistoryDatagridViewRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                            }
                            else if (data_reader.GetString("finalresult") == "-2.0")
                            {
                                HistoryDatagridViewRow.Cells[8].Value = "REDO";
                                HistoryDatagridViewRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                            }
                            else if (data_reader.GetString("finalresult") == "-3.0")
                            {
                                HistoryDatagridViewRow.Cells[8].Value = "LOW";
                                HistoryDatagridViewRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                HistoryDatagridViewRow.Cells[8].Value = data_reader.GetString("finalresult");
                            }
                        }
                        HistoryDatagridViewRow.Cells[9].Value = data_reader.GetString("sampleweight");
                        if (data_reader.IsDBNull(10))
                        {
                            HistoryDatagridViewRow.Cells[10].Value = "";
                        }
                        else
                        {
                            HistoryDatagridViewRow.Cells[10].Value = data_reader.GetString("samplereturn");
                        }

                        HistoryDatagridViewRow.Cells[11].Value = data_reader.GetString("id");

                        History_rows.Add(HistoryDatagridViewRow);
                    }
                }
                data_reader.Close();
                HistoryDataGridView.Rows.AddRange(History_rows.ToArray());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }
        //Customer Info
        List<string> CustomerListboxItemList = new List<string>();
        public void LoadCustomerCustomerList()
        {
            try
            {
                var con = new MySqlConnection(connection_string);
                con.Open();

                sql = "SELECT name FROM user WHERE role ='customer' ORDER BY name ASC";
                var cmd = new MySqlCommand(sql, con);

                MySqlDataReader data_reader = cmd.ExecuteReader();
                CustomerCustomerListbox.Items.Clear();
                CustomerListboxItemList.Clear();
                if (data_reader.HasRows)
                {
                    while (data_reader.Read())
                    {
                        CustomerCustomerListbox.Items.Add(data_reader.GetString("name"));
                        CustomerListboxItemList.Add(data_reader.GetString("name"));
                    }
                }
                data_reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }

        public void LoadCustomerTable()
        {
            try
            {
                var con = new MySqlConnection(connection_string);
                con.Open();
                sql = "SELECT name, phone, email, fax, area, billing, coupon FROM user WHERE role ='customer' ORDER BY name, created";
                var cmd = new MySqlCommand(sql, con);

                MySqlDataReader data_reader = cmd.ExecuteReader();

                CustomerDataGridView.Rows.Clear();
                CustomerDataGridView.Refresh();

                List<DataGridViewRow> Customer_rows = new List<DataGridViewRow>();
                if (data_reader.HasRows)
                {
                    while (data_reader.Read())
                    {
                        DataGridViewRow CustomerDatagridViewRow = new DataGridViewRow() { Height = 30 };
                        CustomerDatagridViewRow.CreateCells(CustomerDataGridView);
                        CustomerDatagridViewRow.Cells[0].Value = data_reader.GetString("name");
                        CustomerDatagridViewRow.Cells[1].Value = data_reader.GetString("phone");
                        if (data_reader.IsDBNull(2))
                        {
                            CustomerDatagridViewRow.Cells[2].Value = "";
                        }
                        else
                        {

                            CustomerDatagridViewRow.Cells[2].Value = data_reader.GetString("email");
                        }
                        CustomerDatagridViewRow.Cells[3].Value = data_reader.GetString("fax");
                        CustomerDatagridViewRow.Cells[4].Value = data_reader.GetString("area");
                        if (data_reader.GetBoolean("billing"))
                        {
                            CustomerDatagridViewRow.Cells[5].Value = "Yes";
                        }
                        else
                        {
                            CustomerDatagridViewRow.Cells[5].Value = "No";
                        }
                        if (data_reader.GetBoolean("coupon"))
                        {
                            CustomerDatagridViewRow.Cells[6].Value = "Yes";
                        }
                        else
                        {
                            CustomerDatagridViewRow.Cells[6].Value = "No";
                        }
                        Customer_rows.Add(CustomerDatagridViewRow);
                    }
                }
                data_reader.Close();
                CustomerDataGridView.Rows.AddRange(Customer_rows.ToArray());
                con.Close();
                WriteToLogFile("Customer Table Loaded.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }

        private void CustomerResetButton_Click(object sender, EventArgs e)
        {
            LoadCustomerTable();
            CustomerCustomerTextbox.Text = "";
        }

        private void CustomerNewButton_Click(object sender, EventArgs e)
        {
            NewCustomer newcustomer = new NewCustomer(this);
            newcustomer.clicksource = "NEW";
            newcustomer.ShowDialog();
        }

        private void CustomerEditButton_Click(object sender, EventArgs e)
        {
            NewCustomer newcustomer = new NewCustomer(this);
            //MessageBox.Show(CustomerDataGridView.CurrentRow.Cells[0].Value.ToString());
            newcustomer.clicksource = "EDIT";
            newcustomer.customer = CustomerDataGridView.CurrentRow.Cells[0].Value.ToString();
            newcustomer.phone = CustomerDataGridView.CurrentRow.Cells[1].Value.ToString();
            newcustomer.email = CustomerDataGridView.CurrentRow.Cells[2].Value.ToString();
            newcustomer.fax = CustomerDataGridView.CurrentRow.Cells[3].Value.ToString();
            newcustomer.area = CustomerDataGridView.CurrentRow.Cells[4].Value.ToString();
            newcustomer.billing = CustomerDataGridView.CurrentRow.Cells[5].Value.ToString();
            newcustomer.coupon = CustomerDataGridView.CurrentRow.Cells[6].Value.ToString();
            newcustomer.ShowDialog();
        }

        private void CustomerDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult;
                dialogResult = MessageBox.Show($"Delete Customer {CustomerDataGridView.CurrentRow.Cells[0].Value.ToString()}?", "Delete Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                if (dialogResult == DialogResult.Yes)
                {

                    var con = new MySqlConnection(connection_string);
                    con.Open();
                    sql = $"DELETE from user WHERE name='{CustomerDataGridView.CurrentRow.Cells[0].Value.ToString()}'";

                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.ExecuteReader();
                    con.Close();
                    LoadCustomerTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }
        private void CustomerCustomerTextbox_TextChanged(object sender, EventArgs e)
        {
            if (CustomerCustomerTextbox.Text == string.Empty)
            {
                CustomerCustomerListbox.Visible = false;
                CustomerCustomerListbox.Items.Clear();
                for (int i = 0; i < CustomerListboxItemList.Count; i++)
                {
                    CustomerCustomerListbox.Items.Add(CustomerListboxItemList[i]);
                }
            }
            else
            {
                CustomerCustomerListbox.Items.Clear();
                string search_str = CustomerCustomerTextbox.Text;
                for (int i = 0; i < CustomerListboxItemList.Count; i++)
                {
                    if (CustomerListboxItemList[i].Contains(search_str))
                    {
                        CustomerCustomerListbox.Items.Add(CustomerListboxItemList[i]);
                    }
                }

                CustomerCustomerListbox.Visible = true;
                Cursor.Current = Cursors.Default;
                CustomerCustomerListbox.SelectedIndex = -1;

                //HistoryCustomerCombobox.Text = search_str;
                //listBox1.Select(listBox1.Text.Length, 0);

            }
        }

        private void CustomerCustomerTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 40)
            {
                CustomerCustomerListbox.Focus();
                CustomerCustomerListbox.SelectedIndex = 0;
                e.SuppressKeyPress = true;

            }
            if (e.KeyValue == 13)
            {
                CustomerSearchButton.Focus();
                e.SuppressKeyPress = true;

            }
        }

        private void CustomerCustomerTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
            {
                e.KeyChar -= (char)32;
            }
        }

        private void CustomerCustomerListbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                CustomerCustomerTextbox.Focus();
                CustomerCustomerTextbox.Text = CustomerCustomerListbox.GetItemText(CustomerCustomerListbox.SelectedItem);
                CustomerCustomerTextbox.SelectionStart = CustomerCustomerTextbox.Text.Length;
                CustomerCustomerTextbox.SelectionLength = 0;
                CustomerCustomerListbox.Visible = false;
                e.SuppressKeyPress = true;

            }
            if (e.KeyValue == 38 && CustomerCustomerListbox.SelectedIndex == 0)
            {
                CustomerCustomerTextbox.Focus();
                e.SuppressKeyPress = true;

            }
        }
        private void CustomerSearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CustomerCustomerTextbox.Text == "")
                {
                    return;
                }

                var con = new MySqlConnection(connection_string);
                con.Open();
                sql = $"SELECT name, phone, email, fax, area, billing, coupon FROM user WHERE role ='customer' AND name='{CustomerCustomerTextbox.Text}' ORDER BY name, created";
                var cmd = new MySqlCommand(sql, con);

                MySqlDataReader data_reader = cmd.ExecuteReader();

                CustomerDataGridView.Rows.Clear();
                CustomerDataGridView.Refresh();

                List<DataGridViewRow> Customer_rows = new List<DataGridViewRow>();
                if (data_reader.HasRows)
                {
                    while (data_reader.Read())
                    {
                        DataGridViewRow CustomerDatagridViewRow = new DataGridViewRow() { Height = 30 };
                        CustomerDatagridViewRow.CreateCells(CustomerDataGridView);
                        CustomerDatagridViewRow.Cells[0].Value = data_reader.GetString("name");
                        CustomerDatagridViewRow.Cells[1].Value = data_reader.GetString("phone");
                        if (data_reader.IsDBNull(2))
                        {
                            CustomerDatagridViewRow.Cells[2].Value = "";
                        }
                        else
                        {

                            CustomerDatagridViewRow.Cells[2].Value = data_reader.GetString("email");
                        }
                        CustomerDatagridViewRow.Cells[3].Value = data_reader.GetString("fax");
                        CustomerDatagridViewRow.Cells[4].Value = data_reader.GetString("area");
                        if (data_reader.GetBoolean("billing"))
                        {
                            CustomerDatagridViewRow.Cells[5].Value = "Yes";
                        }
                        else
                        {
                            CustomerDatagridViewRow.Cells[5].Value = "No";
                        }
                        if (data_reader.GetBoolean("coupon"))
                        {
                            CustomerDatagridViewRow.Cells[6].Value = "Yes";
                        }
                        else
                        {
                            CustomerDatagridViewRow.Cells[6].Value = "No";
                        }
                        Customer_rows.Add(CustomerDatagridViewRow);
                    }
                }
                data_reader.Close();
                CustomerDataGridView.Rows.AddRange(Customer_rows.ToArray());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }



        //Tool Strip Menus
        private void assaySettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm(this);
            settingForm.ShowDialog();
        }

        private void saveFormcodePDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "LW";
            string query = $"SELECT assayresult.itemcode AS itemcode, assayresult.finalresult AS finalresult, assayresult.sampleweight AS sampleweight, assayresult.samplereturn AS samplereturn, user.fax AS fax FROM assayresult INNER JOIN user ON assayresult.customer = user.id WHERE assayresult.formcode = {right_click_formcode} ORDER BY assayresult.created;";
            PreviewForm previewForm = new PreviewForm(this);
            //Update List
            UpdateFormcodeItemList(query);
            //Generate PDF
            GeneratePDF(right_click_source, right_click_customer, right_click_date);
            //Open Preview
            previewForm.PreviewActionButton.Text = "SAVE";
            previewForm.customer = right_click_customer;
            previewForm.pdf_count = 1;
            previewForm.ItemcodeList = ItemcodeList;
            previewForm.button_enable = true;
            previewForm.ShowDialog();
        }
        private void saveItemPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "LW";
            string query = $"SELECT assayresult.itemcode AS itemcode, assayresult.finalresult AS finalresult, assayresult.sampleweight AS sampleweight, assayresult.samplereturn AS samplereturn, user.fax AS fax FROM assayresult INNER JOIN user ON assayresult.customer = user.id WHERE assayresult.id = {right_click_id};";
            PreviewForm previewForm = new PreviewForm(this);
            //Update List
            UpdateFormcodeItemList(query);
            //Generate PDF
            GeneratePDF(right_click_source, right_click_customer, right_click_date);
            //Open Preview            
            previewForm.PreviewActionButton.Text = "SAVE";
            previewForm.customer = right_click_customer;
            previewForm.pdf_count = 1;
            previewForm.ItemcodeList = ItemcodeList;
            previewForm.button_enable = true;
            previewForm.ShowDialog();
        }

        private void saveSplitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "LW";
            ChooseItemForm chooseItemForm = new ChooseItemForm(this);
            chooseItemForm.customer = right_click_customer;
            chooseItemForm.formcode = right_click_formcode;
            chooseItemForm.date = right_click_date;
            chooseItemForm.source = right_click_source;
            chooseItemForm.split = true;
            chooseItemForm.action = "SAVE ALL";
            chooseItemForm.ShowDialog();

        }

        private void saveMultipleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "LW";
            ChooseItemForm chooseItemForm = new ChooseItemForm(this);
            chooseItemForm.customer = right_click_customer;
            chooseItemForm.formcode = right_click_formcode;
            chooseItemForm.date = right_click_date;
            chooseItemForm.source = right_click_source;
            chooseItemForm.split = false;
            chooseItemForm.action = "SAVE ALL";
            chooseItemForm.ShowDialog();
        }

        private void printFormcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "SR";
            string query = $"SELECT assayresult.itemcode AS itemcode, assayresult.finalresult AS finalresult, assayresult.sampleweight AS sampleweight, assayresult.samplereturn AS samplereturn, user.fax AS fax FROM assayresult INNER JOIN user ON assayresult.customer = user.id WHERE assayresult.formcode = {right_click_formcode} ORDER BY assayresult.created;";
            PreviewForm previewForm = new PreviewForm(this);
            //Update List
            UpdateFormcodeItemList(query);
            //Generate PDF
            GeneratePDF(right_click_source, right_click_customer, right_click_date);
            //Open Preview
            previewForm.PreviewActionButton.Text = "PRINT";
            previewForm.customer = right_click_customer;
            previewForm.pdf_count = 1;
            previewForm.ItemcodeList = ItemcodeList;
            previewForm.button_enable = true;
            previewForm.ShowDialog();
        }

        private void printItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "SR";
            string query = $"SELECT assayresult.itemcode AS itemcode, assayresult.finalresult AS finalresult, assayresult.sampleweight AS sampleweight, assayresult.samplereturn AS samplereturn, user.fax AS fax FROM assayresult INNER JOIN user ON assayresult.customer = user.id WHERE assayresult.id = {right_click_id};";
            PreviewForm previewForm = new PreviewForm(this);
            //Update List
            UpdateFormcodeItemList(query);
            //Generate PDF
            GeneratePDF(right_click_source, right_click_customer, right_click_date);
            //Open Preview            
            previewForm.PreviewActionButton.Text = "PRINT";
            previewForm.customer = right_click_customer;
            previewForm.pdf_count = 1;
            previewForm.ItemcodeList = ItemcodeList;
            previewForm.button_enable = true;
            previewForm.ShowDialog();
        }

        private void printSplitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "SR";
            ChooseItemForm chooseItemForm = new ChooseItemForm(this);
            chooseItemForm.customer = right_click_customer;
            chooseItemForm.formcode = right_click_formcode;
            chooseItemForm.date = right_click_date;
            chooseItemForm.source = right_click_source;
            chooseItemForm.split = true;
            chooseItemForm.action = "PRINT ALL";
            chooseItemForm.ShowDialog();
        }

        private void printMultipleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "SR";
            ChooseItemForm chooseItemForm = new ChooseItemForm(this);
            chooseItemForm.customer = right_click_customer;
            chooseItemForm.formcode = right_click_formcode;
            chooseItemForm.date = right_click_date;
            chooseItemForm.source = right_click_source;
            chooseItemForm.split = false;
            chooseItemForm.action = "PRINT ALL";
            chooseItemForm.ShowDialog();
        }

        private void faxFormcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "LW";
            string query = $"SELECT assayresult.itemcode AS itemcode, assayresult.finalresult AS finalresult, assayresult.sampleweight AS sampleweight, assayresult.samplereturn AS samplereturn, user.fax AS fax FROM assayresult INNER JOIN user ON assayresult.customer = user.id WHERE assayresult.formcode = {right_click_formcode} ORDER BY assayresult.created;";
            PreviewForm previewForm = new PreviewForm(this);
            //Update List
            UpdateFormcodeItemList(query);
            //Generate PDF
            GeneratePDF(right_click_source, right_click_customer, right_click_date);
            string customerfax = "";
            //Check if customer has fax
            try
            {
                var con = new MySqlConnection(connection_string);
                con.Open();

                sql = $"SELECT fax FROM user WHERE name='{right_click_customer}'";
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
            //Open Preview
            previewForm.PreviewActionButton.Text = "FAX";
            previewForm.customer = right_click_customer;
            previewForm.pdf_count = 1;
            previewForm.ItemcodeList = ItemcodeList;
            previewForm.action = "FAX";
            previewForm.ShowDialog();
        }

        private void faxItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "LW";
            string query = $"SELECT assayresult.itemcode AS itemcode, assayresult.finalresult AS finalresult, assayresult.sampleweight AS sampleweight, assayresult.samplereturn AS samplereturn, user.fax AS fax FROM assayresult INNER JOIN user ON assayresult.customer = user.id WHERE assayresult.id = {right_click_id};";
            PreviewForm previewForm = new PreviewForm(this);
            //Update List
            UpdateFormcodeItemList(query);
            //Generate PDF
            GeneratePDF(right_click_source, right_click_customer, right_click_date);
            string customerfax = "";
            //Check if customer has fax
            try
            {
                var con = new MySqlConnection(connection_string);
                con.Open();

                sql = $"SELECT fax FROM user WHERE name='{right_click_customer}'";
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
            //Open Preview            
            previewForm.PreviewActionButton.Text = "FAX";
            previewForm.customer = right_click_customer;
            previewForm.pdf_count = 1;
            previewForm.ItemcodeList = ItemcodeList;
            previewForm.action = "FAX";
            previewForm.ShowDialog();
        }

        private void faxSplitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "LW";
            ChooseItemForm chooseItemForm = new ChooseItemForm(this);
            chooseItemForm.customer = right_click_customer;
            chooseItemForm.formcode = right_click_formcode;
            chooseItemForm.date = right_click_date;
            chooseItemForm.source = right_click_source;
            chooseItemForm.split = true;
            chooseItemForm.action = "FAX ALL";
            chooseItemForm.ShowDialog();
        }
        private void faxMultipleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "LW";
            ChooseItemForm chooseItemForm = new ChooseItemForm(this);
            chooseItemForm.customer = right_click_customer;
            chooseItemForm.formcode = right_click_formcode;
            chooseItemForm.date = right_click_date;
            chooseItemForm.source = right_click_source;
            chooseItemForm.split = false;
            chooseItemForm.action = "FAX ALL";
            chooseItemForm.ShowDialog();
        }
        private void emailFormcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "LW";
            string query = $"SELECT assayresult.itemcode AS itemcode, assayresult.finalresult AS finalresult, assayresult.sampleweight AS sampleweight, assayresult.samplereturn AS samplereturn, user.fax AS fax FROM assayresult INNER JOIN user ON assayresult.customer = user.id WHERE assayresult.formcode = {right_click_formcode} ORDER BY assayresult.created;";
            PreviewForm previewForm = new PreviewForm(this);
            //Update List
            UpdateFormcodeItemList(query);
            //Generate PDF
            GeneratePDF(right_click_source, right_click_customer, right_click_date);
            string customeremail = "";
            //check if customer has email
            try
            {
                var con = new MySqlConnection(connection_string);
                con.Open();

                sql = $"SELECT email FROM user WHERE name='{right_click_customer}'";
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
            //Open Preview
            previewForm.PreviewActionButton.Text = "EMAIL";
            previewForm.customer = right_click_customer;
            previewForm.pdf_count = 1;
            previewForm.ItemcodeList = ItemcodeList;
            previewForm.other_button_enable = true;
            previewForm.action = "EMAIL";
            previewForm.ShowDialog();
        }

        private void emailItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "LW";
            string query = $"SELECT assayresult.itemcode AS itemcode, assayresult.finalresult AS finalresult, assayresult.sampleweight AS sampleweight, assayresult.samplereturn AS samplereturn, user.fax AS fax FROM assayresult INNER JOIN user ON assayresult.customer = user.id WHERE assayresult.id = {right_click_id};";
            PreviewForm previewForm = new PreviewForm(this);
            //Update List
            UpdateFormcodeItemList(query);
            //Generate PDF
            GeneratePDF(right_click_source, right_click_customer, right_click_date);
            string customeremail = "";
            //check if customer has email
            try
            {
                var con = new MySqlConnection(connection_string);
                con.Open();

                sql = $"SELECT email FROM user WHERE name='{right_click_customer}'";
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
            //Open Preview            
            previewForm.PreviewActionButton.Text = "EMAIL";
            previewForm.customer = right_click_customer;
            previewForm.pdf_count = 1;
            previewForm.ItemcodeList = ItemcodeList;
            previewForm.other_button_enable = true;
            previewForm.action = "EMAIL";
            previewForm.ShowDialog();
        }

        private void emailSplitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "LW";
            ChooseItemForm chooseItemForm = new ChooseItemForm(this);
            chooseItemForm.customer = right_click_customer;
            chooseItemForm.formcode = right_click_formcode;
            chooseItemForm.date = right_click_date;
            chooseItemForm.source = right_click_source;
            chooseItemForm.split = true;
            chooseItemForm.action = "EMAIL ALL";
            chooseItemForm.ShowDialog();
        }

        private void emailMultipleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "LW";
            ChooseItemForm chooseItemForm = new ChooseItemForm(this);
            chooseItemForm.customer = right_click_customer;
            chooseItemForm.formcode = right_click_formcode;
            chooseItemForm.date = right_click_date;
            chooseItemForm.source = right_click_source;
            chooseItemForm.split = false;
            chooseItemForm.action = "EMAIL ALL";
            chooseItemForm.ShowDialog();
        }

        private void HistoryDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dataGrid = (DataGridView)sender;
            if (e.Button == MouseButtons.Right && e.RowIndex != -1)
            {
                var row = dataGrid.Rows[e.RowIndex];
                dataGrid.CurrentCell = row.Cells[e.ColumnIndex == -1 ? 1 : e.ColumnIndex];
                row.Selected = true;
                HistoryContextMenuStrip.Show(this, PointToClient(Cursor.Position));
                right_click_formcode = HistoryDataGridView.CurrentRow.Cells[1].Value.ToString();
                right_click_id = HistoryDataGridView.CurrentRow.Cells[11].Value.ToString();
                right_click_date = HistoryDataGridView.CurrentRow.Cells[3].Value.ToString();
                right_click_source = "History";
                right_click_customer = HistoryDataGridView.CurrentRow.Cells[0].Value.ToString();
            }
        }

        private void HistorySaveFormCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "History";
            string query = $"SELECT assayresult.itemcode AS itemcode, assayresult.finalresult AS finalresult, assayresult.sampleweight AS sampleweight, assayresult.samplereturn AS samplereturn, user.fax AS fax FROM assayresult INNER JOIN user ON assayresult.customer = user.id WHERE assayresult.formcode = {right_click_formcode} ORDER BY assayresult.created;";
            PreviewForm previewForm = new PreviewForm(this);
            //Update List
            UpdateFormcodeItemList(query);
            //Generate PDF
            GeneratePDF(right_click_source, right_click_customer, right_click_date);
            //Open Preview
            previewForm.PreviewActionButton.Text = "SAVE";
            previewForm.customer = right_click_customer;
            Debug.WriteLine(right_click_customer);
            previewForm.pdf_count = 1;
            previewForm.ItemcodeList = ItemcodeList;
            previewForm.button_enable = true;
            previewForm.ShowDialog();
        }

        private void HistorySaveItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "History";
            string query = $"SELECT assayresult.itemcode AS itemcode, assayresult.finalresult AS finalresult, assayresult.sampleweight AS sampleweight, assayresult.samplereturn AS samplereturn, user.fax AS fax FROM assayresult INNER JOIN user ON assayresult.customer = user.id WHERE assayresult.id = {right_click_id};";
            PreviewForm previewForm = new PreviewForm(this);
            //Update List
            UpdateFormcodeItemList(query);
            //Generate PDF
            GeneratePDF(right_click_source, right_click_customer, right_click_date);
            //Open Preview            
            previewForm.PreviewActionButton.Text = "SAVE";
            previewForm.customer = right_click_customer;
            previewForm.pdf_count = 1;
            previewForm.ItemcodeList = ItemcodeList;
            previewForm.button_enable = true;
            previewForm.ShowDialog();
        }

        private void HistorySaveSplitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "History";
            ChooseItemForm chooseItemForm = new ChooseItemForm(this);
            chooseItemForm.customer = right_click_customer;
            chooseItemForm.formcode = right_click_formcode;
            chooseItemForm.date = right_click_date;
            chooseItemForm.source = right_click_source;
            chooseItemForm.split = true;
            chooseItemForm.action = "SAVE ALL";
            chooseItemForm.ShowDialog();
        }

        private void HistorySaveMultipleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "History";
            ChooseItemForm chooseItemForm = new ChooseItemForm(this);
            chooseItemForm.customer = right_click_customer;
            chooseItemForm.formcode = right_click_formcode;
            chooseItemForm.date = right_click_date;
            chooseItemForm.source = right_click_source;
            chooseItemForm.split = false;
            chooseItemForm.action = "SAVE ALL";
            chooseItemForm.ShowDialog();
        }

        private void HistoryFaxFormCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "History";
            string query = $"SELECT assayresult.itemcode AS itemcode, assayresult.finalresult AS finalresult, assayresult.sampleweight AS sampleweight, assayresult.samplereturn AS samplereturn, user.fax AS fax FROM assayresult INNER JOIN user ON assayresult.customer = user.id WHERE assayresult.formcode = {right_click_formcode} ORDER BY assayresult.created;";
            PreviewForm previewForm = new PreviewForm(this);
            //Update List
            UpdateFormcodeItemList(query);
            //Generate PDF
            GeneratePDF(right_click_source, right_click_customer, right_click_date);
            string customerfax = "";
            //Check if customer has fax
            try
            {
                var con = new MySqlConnection(connection_string);
                con.Open();

                sql = $"SELECT fax FROM user WHERE name='{right_click_customer}'";
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
            //Open Preview
            previewForm.PreviewActionButton.Text = "FAX";
            previewForm.customer = right_click_customer;
            previewForm.pdf_count = 1;
            previewForm.ItemcodeList = ItemcodeList;
            previewForm.ShowDialog();
        }

        private void HistoryFaxItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "History";
            string query = $"SELECT assayresult.itemcode AS itemcode, assayresult.finalresult AS finalresult, assayresult.sampleweight AS sampleweight, assayresult.samplereturn AS samplereturn, user.fax AS fax FROM assayresult INNER JOIN user ON assayresult.customer = user.id WHERE assayresult.id = {right_click_id};";
            PreviewForm previewForm = new PreviewForm(this);
            //Update List
            UpdateFormcodeItemList(query);
            //Generate PDF
            GeneratePDF(right_click_source, right_click_customer, right_click_date);
            string customerfax = "";
            //Check if customer has fax
            try
            {
                var con = new MySqlConnection(connection_string);
                con.Open();

                sql = $"SELECT fax FROM user WHERE name='{right_click_customer}'";
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
            //Open Preview            
            previewForm.PreviewActionButton.Text = "FAX";
            previewForm.customer = right_click_customer;
            previewForm.pdf_count = 1;
            previewForm.ItemcodeList = ItemcodeList;
            previewForm.ShowDialog();
        }

        private void HistoryFaxSplitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "History";
            ChooseItemForm chooseItemForm = new ChooseItemForm(this);
            chooseItemForm.customer = right_click_customer;
            chooseItemForm.formcode = right_click_formcode;
            chooseItemForm.date = right_click_date;
            chooseItemForm.source = right_click_source;
            chooseItemForm.split = true;
            chooseItemForm.action = "FAX ALL";
            chooseItemForm.ShowDialog();
        }

        private void HistoryFaxMultipleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "History";
            ChooseItemForm chooseItemForm = new ChooseItemForm(this);
            chooseItemForm.customer = right_click_customer;
            chooseItemForm.formcode = right_click_formcode;
            chooseItemForm.date = right_click_date;
            chooseItemForm.source = right_click_source;
            chooseItemForm.split = false;
            chooseItemForm.action = "FAX ALL";
            chooseItemForm.ShowDialog();
        }

        private void HistoryPrintFormcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "History";
            string query = $"SELECT assayresult.itemcode AS itemcode, assayresult.finalresult AS finalresult, assayresult.sampleweight AS sampleweight, assayresult.samplereturn AS samplereturn, user.fax AS fax FROM assayresult INNER JOIN user ON assayresult.customer = user.id WHERE assayresult.formcode = {right_click_formcode} ORDER BY assayresult.created;";
            PreviewForm previewForm = new PreviewForm(this);
            //Update List
            UpdateFormcodeItemList(query);
            //Generate PDF
            GeneratePDF(right_click_source, right_click_customer, right_click_date);
            //Open Preview
            previewForm.PreviewActionButton.Text = "PRINT";
            previewForm.customer = right_click_customer;
            previewForm.pdf_count = 1;
            previewForm.ItemcodeList = ItemcodeList;
            previewForm.button_enable = true;
            previewForm.ShowDialog();
        }

        private void HistoryPrintItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "History";
            string query = $"SELECT assayresult.itemcode AS itemcode, assayresult.finalresult AS finalresult, assayresult.sampleweight AS sampleweight, assayresult.samplereturn AS samplereturn, user.fax AS fax FROM assayresult INNER JOIN user ON assayresult.customer = user.id WHERE assayresult.id = {right_click_id};";
            PreviewForm previewForm = new PreviewForm(this);
            //Update List
            UpdateFormcodeItemList(query);
            //Generate PDF
            GeneratePDF(right_click_source, right_click_customer, right_click_date);
            //Open Preview            
            previewForm.PreviewActionButton.Text = "PRINT";
            previewForm.customer = right_click_customer;
            previewForm.pdf_count = 1;
            previewForm.ItemcodeList = ItemcodeList;
            previewForm.button_enable = true;
            previewForm.ShowDialog();
        }

        private void HistoryPrintSplitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "History";
            ChooseItemForm chooseItemForm = new ChooseItemForm(this);
            chooseItemForm.customer = right_click_customer;
            chooseItemForm.formcode = right_click_formcode;
            chooseItemForm.date = right_click_date;
            chooseItemForm.source = right_click_source;
            chooseItemForm.split = true;
            chooseItemForm.action = "PRINT ALL";
            chooseItemForm.ShowDialog();
        }

        private void HistoryPrintMultipleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "History";
            ChooseItemForm chooseItemForm = new ChooseItemForm(this);
            chooseItemForm.customer = right_click_customer;
            chooseItemForm.formcode = right_click_formcode;
            chooseItemForm.date = right_click_date;
            chooseItemForm.source = right_click_source;
            chooseItemForm.split = false;
            chooseItemForm.action = "PRINT ALL";
            chooseItemForm.ShowDialog();
        }

        private void HistoryEmailFormcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "History";
            string query = $"SELECT assayresult.itemcode AS itemcode, assayresult.finalresult AS finalresult, assayresult.sampleweight AS sampleweight, assayresult.samplereturn AS samplereturn, user.fax AS fax FROM assayresult INNER JOIN user ON assayresult.customer = user.id WHERE assayresult.formcode = {right_click_formcode} ORDER BY assayresult.created;";
            PreviewForm previewForm = new PreviewForm(this);
            //Update List
            UpdateFormcodeItemList(query);
            //Generate PDF
            GeneratePDF(right_click_source, right_click_customer, right_click_date);
            string customeremail = "";
            //check if customer has email
            try
            {
                var con = new MySqlConnection(connection_string);
                con.Open();

                sql = $"SELECT email FROM user WHERE name='{right_click_customer}'";
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
            //Open Preview
            previewForm.PreviewActionButton.Text = "EMAIL";
            previewForm.customer = right_click_customer;
            previewForm.pdf_count = 1;
            previewForm.ItemcodeList = ItemcodeList;
            previewForm.ShowDialog();
        }

        private void HistoryEmailItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "History";
            string query = $"SELECT assayresult.itemcode AS itemcode, assayresult.finalresult AS finalresult, assayresult.sampleweight AS sampleweight, assayresult.samplereturn AS samplereturn, user.fax AS fax FROM assayresult INNER JOIN user ON assayresult.customer = user.id WHERE assayresult.id = {right_click_id};";
            PreviewForm previewForm = new PreviewForm(this);
            //Update List
            UpdateFormcodeItemList(query);
            //Generate PDF
            GeneratePDF(right_click_source, right_click_customer, right_click_date);
            string customeremail = "";
            //check if customer has email
            try
            {
                var con = new MySqlConnection(connection_string);
                con.Open();

                sql = $"SELECT email FROM user WHERE name='{right_click_customer}'";
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
            //Open Preview            
            previewForm.PreviewActionButton.Text = "EMAIL";
            previewForm.customer = right_click_customer;
            previewForm.pdf_count = 1;
            previewForm.ItemcodeList = ItemcodeList;
            previewForm.ShowDialog();
        }

        private void HistoryEmailSplitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "History";
            ChooseItemForm chooseItemForm = new ChooseItemForm(this);
            chooseItemForm.customer = right_click_customer;
            chooseItemForm.formcode = right_click_formcode;
            chooseItemForm.date = right_click_date;
            chooseItemForm.source = right_click_source;
            chooseItemForm.split = true;
            chooseItemForm.action = "EMAIL ALL";
            chooseItemForm.ShowDialog();
        }

        private void HistoryEmailMultipleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            right_click_source = "History";
            ChooseItemForm chooseItemForm = new ChooseItemForm(this);
            chooseItemForm.customer = right_click_customer;
            chooseItemForm.formcode = right_click_formcode;
            chooseItemForm.date = right_click_date;
            chooseItemForm.source = right_click_source;
            chooseItemForm.split = false;
            chooseItemForm.action = "EMAIL ALL";
            chooseItemForm.ShowDialog();
        }
        //TIMER
        internal struct LASTINPUTINFO
        {
            public uint cbSize;

            public uint dwTime;
        }
        /// <summary>
        /// Helps to find the idle time, (in milliseconds) spent since the last user input
        /// </summary>
        public class IdleTimeFinder
        {
            [DllImport("User32.dll")]
            private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

            [DllImport("Kernel32.dll")]
            private static extern uint GetLastError();

            public static uint GetIdleTime()
            {
                LASTINPUTINFO lastInPut = new LASTINPUTINFO();
                lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
                GetLastInputInfo(ref lastInPut);

                return ((uint)Environment.TickCount - lastInPut.dwTime);
            }
            /// <summary>
            /// Get the Last input time in milliseconds
            /// </summary>
            /// <returns></returns>
            public static long GetLastInputTime()
            {
                LASTINPUTINFO lastInPut = new LASTINPUTINFO();
                lastInPut.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInPut);
                if (!GetLastInputInfo(ref lastInPut))
                {
                    throw new Exception(GetLastError().ToString());
                }
                return lastInPut.dwTime;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IdleTimeFinder.GetIdleTime() > 900000 && Visible == true)
            {
                Login login = new Login(this);
                // hide MainForm
                Hide();
                // show Login
                login.ShowDialog();
            }
        }

        private void refreshF1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadMainPageTable();
            LoadFirstWeightTable();
            LoadLastWeightTable();
            LoadSampleReturnTable();
            FWPointToBlank();
            LWPointToBlank();
            SRPointToBlank();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                LoadMainPageTable();
                LoadFirstWeightTable();
                LoadLastWeightTable();
                LoadSampleReturnTable();
                FWPointToBlank();
                LWPointToBlank();
                SRPointToBlank();
                return true;    // indicate that you handled this keystroke
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void MainBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (MainLeftDataGridView.InvokeRequired)
            {
                //Invoke only the ui-interaction code
                MainLeftDataGridView.Invoke(new MethodInvoker(this.LoadMainPageTable));
            }
        }

        private void FWBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (FWDataGridView.InvokeRequired)
            {
                //Invoke only the ui-interaction code
                FWDataGridView.Invoke(new MethodInvoker(this.LoadFirstWeightTable));
            }
        }

        private void LWBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (LWDataGridView.InvokeRequired)
            {
                //Invoke only the ui-interaction code
                LWDataGridView.Invoke(new MethodInvoker(this.LoadLastWeightTable));
            }
        }

        private void SRBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (SRDataGridView.InvokeRequired)
            {
                //Invoke only the ui-interaction code
                SRDataGridView.Invoke(new MethodInvoker(this.LoadSampleReturnTable));
            }
        }

        private void FWGoToRedoButton_Click(object sender, EventArgs e)
        {
            bool redo_found = false;

            foreach (DataGridViewRow row in FWDataGridView.Rows)
            {
                if (row.Cells[6].Value.ToString() == "REDO")
                {
                    FWDataGridView.ClearSelection();
                    FWDataGridView.Rows[row.Cells[0].RowIndex].Selected = true;
                    FWDataGridView.FirstDisplayedScrollingRowIndex = row.Cells[0].RowIndex - 1;
                    FWDataGridView.CurrentCell = FWDataGridView.Rows[row.Cells[0].RowIndex].Cells[0];
                    FWDatagridview_CellClick(this.FWDataGridView, new DataGridViewCellEventArgs(0, 0));
                    redo_found = true;
                    break;
                }

            }
            if (redo_found == false)
            {
                MessageBox.Show("No REDO assay is found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LWGoToRedoButton_Click(object sender, EventArgs e)
        {
            bool redo_found = false;
            foreach (DataGridViewRow row in LWDataGridView.Rows)
            {
                if (row.Cells[7].Value.ToString() == "REDO")
                {
                    LWDataGridView.ClearSelection();
                    LWDataGridView.Rows[row.Cells[0].RowIndex].Selected = true;
                    LWDataGridView.FirstDisplayedScrollingRowIndex = row.Cells[0].RowIndex - 1;
                    LWDataGridView.CurrentCell = LWDataGridView.Rows[row.Cells[0].RowIndex].Cells[0];
                    LWDataGridView_CellClick(this.LWDataGridView, new DataGridViewCellEventArgs(0, 0));
                    redo_found = true;
                    break;
                }

            }
            if (redo_found == false)
            {
                MessageBox.Show("No REDO assay is found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SRGoToNonRedoButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in SRDataGridView.Rows)
            {
                if (row.Cells[3].Value.ToString() != "REDO" && row.Cells[5].Value.ToString() == "")
                {
                    SRDataGridView.ClearSelection();
                    SRDataGridView.Rows[row.Cells[0].RowIndex].Selected = true;
                    SRDataGridView.FirstDisplayedScrollingRowIndex = row.Cells[0].RowIndex - 1;
                    SRDataGridView.CurrentCell = SRDataGridView.Rows[row.Cells[0].RowIndex].Cells[0];
                    SRDataGridView_CellClick(this.SRDataGridView, new DataGridViewCellEventArgs(0, 0));
                    break;
                }

            }
        }

        public void AddNewToMainLeft(string formcode, DateTime created, string customer, bool color)
        {
            //Compare formcode and last row formcode, if diff, add new row, if same, change number
            if (formcode.ToString() != MainLeftDataGridView.Rows[MainLeftDataGridView.Rows.Count - 1].Cells[0].Value.ToString())
            {
                DataGridViewRow newLeftRow = new DataGridViewRow() { Height = 30 };
                newLeftRow.CreateCells(MainLeftDataGridView);
                newLeftRow.Cells[0].Value = formcode;
                newLeftRow.Cells[1].Value = 1;
                newLeftRow.Cells[2].Value = created;
                newLeftRow.Cells[3].Value = customer;

                if (color)
                {
                    newLeftRow.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                }
                else
                {
                    newLeftRow.DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                }
                MainLeftDataGridView.Rows.Add(newLeftRow);
            }
            else
            {
                MainLeftDataGridView.Rows[MainLeftDataGridView.Rows.Count - 1].Cells[1].Value = Int32.Parse(MainLeftDataGridView.Rows[MainLeftDataGridView.Rows.Count - 1].Cells[1].Value.ToString()) + 1;
            }
            MainLeftDataGridView.FirstDisplayedScrollingRowIndex = MainLeftDataGridView.RowCount - 1;
        }

        public void AddNewToMainRight(string formcode, string itemcode, string sampleweight, int id, bool color)
        {

            DataGridViewRow newRightRow = new DataGridViewRow() { Height = 30 };
            newRightRow.CreateCells(MainRightDataGridView);
            newRightRow.Cells[0].Value = formcode;
            newRightRow.Cells[1].Value = itemcode;
            newRightRow.Cells[2].Value = sampleweight;
            newRightRow.Cells[3].Value = "";
            newRightRow.Cells[4].Value = "";
            newRightRow.Cells[5].Value = id;
            if (color)
            {
                newRightRow.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
            }
            else
            {
                newRightRow.DefaultCellStyle.BackColor = System.Drawing.Color.Pink;

            }
            MainRightDataGridView.Rows.Add(newRightRow);
            MainRightDataGridView.FirstDisplayedScrollingRowIndex = MainRightDataGridView.RowCount - 1;
        }

        public void AddNewToFW(string customer, string itemcode, int id, bool color)
        {

            DataGridViewRow newFWRow = new DataGridViewRow() { Height = 30 };
            newFWRow.CreateCells(FWDataGridView);
            newFWRow.Cells[0].Value = customer;
            newFWRow.Cells[1].Value = itemcode;
            newFWRow.Cells[2].Value = "";
            newFWRow.Cells[3].Value = "";
            newFWRow.Cells[4].Value = "";
            newFWRow.Cells[5].Value = id;
            newFWRow.Cells[6].Value = "";
            if (color)
            {
                newFWRow.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
            }
            else
            {
                newFWRow.DefaultCellStyle.BackColor = System.Drawing.Color.Pink;

            }
            FWDataGridView.Rows.Add(newFWRow);
        }

        public void AddNewToLW(string customer, string itemcode, int id, bool color, string formcode, DateTime created)
        {

            DataGridViewRow newLWRow = new DataGridViewRow() { Height = 30 };
            newLWRow.CreateCells(LWDataGridView);
            newLWRow.Cells[0].Value = customer;
            newLWRow.Cells[1].Value = itemcode;
            newLWRow.Cells[2].Value = "";
            newLWRow.Cells[3].Value = "";
            newLWRow.Cells[4].Value = "";
            newLWRow.Cells[5].Value = "";
            newLWRow.Cells[6].Value = "";
            newLWRow.Cells[7].Value = "";
            newLWRow.Cells[8].Value = "";
            newLWRow.Cells[9].Value = "";
            newLWRow.Cells[10].Value = "";
            newLWRow.Cells[11].Value = "";
            newLWRow.Cells[12].Value = id;
            newLWRow.Cells[13].Value = formcode;
            newLWRow.Cells[14].Value = created;
            if (color)
            {
                newLWRow.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
            }
            else
            {
                newLWRow.DefaultCellStyle.BackColor = System.Drawing.Color.Pink;

            }
            LWDataGridView.Rows.Add(newLWRow);
        }

        public void AddNewToSR(string customer, string formcode, string itemcode, string sampleweight, DateTime created, int id, bool color)
        {

            DataGridViewRow newSRRow = new DataGridViewRow() { Height = 30 };
            newSRRow.CreateCells(SRDataGridView);
            newSRRow.Cells[0].Value = customer;
            newSRRow.Cells[1].Value = formcode;
            newSRRow.Cells[2].Value = itemcode;
            newSRRow.Cells[3].Value = "";
            newSRRow.Cells[4].Value = sampleweight;
            newSRRow.Cells[5].Value = "";
            newSRRow.Cells[6].Value = created;
            newSRRow.Cells[7].Value = id;
            if (color)
            {
                newSRRow.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
            }
            else
            {
                newSRRow.DefaultCellStyle.BackColor = System.Drawing.Color.Pink;

            }
            SRDataGridView.Rows.Add(newSRRow);
        }

        public void UpdateEdited(string itemcode, string sampleweight, string id)
        {
            //Update Main Right
            foreach (DataGridViewRow row in MainRightDataGridView.Rows)
            {
                if (id == row.Cells[5].Value.ToString())
                {
                    row.Cells[1].Value = itemcode;
                    row.Cells[2].Value = sampleweight;
                    break;
                }
            }
            //Update FW
            foreach (DataGridViewRow row in FWDataGridView.Rows)
            {
                if (id == row.Cells[5].Value.ToString())
                {
                    row.Cells[1].Value = itemcode;
                    break;
                }
            }
            //Update LW
            foreach (DataGridViewRow row in LWDataGridView.Rows)
            {
                if (id == row.Cells[12].Value.ToString())
                {
                    row.Cells[1].Value = itemcode;
                    break;
                }
            }
            //Update SR
            foreach (DataGridViewRow row in SRDataGridView.Rows)
            {
                if (id == row.Cells[7].Value.ToString())
                {
                    row.Cells[2].Value = itemcode;
                    row.Cells[4].Value = sampleweight;
                    break;
                }
            }
        }
        string add_previous_record_ID;
        public void UpdateAdded(string customer, string formcode, string itemcode, string sampleweight, string id, DateTime created, bool color)
        {
            //Update Main Left
            foreach (DataGridViewRow row in MainLeftDataGridView.Rows)
            {
                if (formcode == row.Cells[0].Value.ToString())
                {
                    row.Cells[1].Value = (int.Parse(row.Cells[1].Value.ToString()) + 1).ToString();
                    break;
                }
            }
            //Update Main Right and get the previous record ID
            bool main_right_added = false;
            bool add_to_last = false;
            DataGridViewRow insert_main_right = new DataGridViewRow() { Height = 30 };
            insert_main_right.CreateCells(MainRightDataGridView);
            foreach (DataGridViewRow row in MainRightDataGridView.Rows)
            {
                if (row.Index > 0)
                {
                    if (MainRightDataGridView.Rows[row.Index - 1].Cells[0].Value.ToString() == formcode && row.Cells[0].Value.ToString() != formcode)
                    {
                        add_previous_record_ID = MainRightDataGridView.Rows[row.Index - 1].Cells[5].Value.ToString();
                        if (color)
                        {
                            insert_main_right.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                        }
                        else
                        {
                            insert_main_right.DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                        }
                        insert_main_right.Cells[0].Value = formcode;
                        insert_main_right.Cells[1].Value = itemcode;
                        insert_main_right.Cells[2].Value = sampleweight;
                        insert_main_right.Cells[3].Value = "";
                        insert_main_right.Cells[4].Value = "";
                        insert_main_right.Cells[5].Value = id;
                        MainRightDataGridView.Rows.Insert(row.Index, insert_main_right);
                        main_right_added = true;
                        break;
                    }
                }
            }
            //add at bottom if already loop finish
            if (main_right_added == false)
            {
                add_previous_record_ID = MainRightDataGridView.Rows[MainRightDataGridView.Rows.Count - 1].Cells[5].Value.ToString();
                if (color)
                {
                    insert_main_right.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                }
                else
                {
                    insert_main_right.DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                }
                insert_main_right.Cells[0].Value = formcode;
                insert_main_right.Cells[1].Value = itemcode;
                insert_main_right.Cells[2].Value = sampleweight;
                insert_main_right.Cells[3].Value = "";
                insert_main_right.Cells[4].Value = "";
                insert_main_right.Cells[5].Value = id;
                MainRightDataGridView.Rows.Insert(MainRightDataGridView.Rows.Count, insert_main_right);
                MainRightDataGridView.FirstDisplayedScrollingRowIndex = MainRightDataGridView.RowCount - 1;
                add_to_last = true;
            }
            //Update FW
            DataGridViewRow insert_fw = new DataGridViewRow() { Height = 30 };
            insert_fw.CreateCells(FWDataGridView);
            if (add_to_last)
            {
                //add at bottom

                add_previous_record_ID = FWDataGridView.Rows[FWDataGridView.Rows.Count - 1].Cells[5].Value.ToString();
                if (color)
                {
                    insert_fw.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                }
                else
                {
                    insert_fw.DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                }
                insert_fw.Cells[0].Value = customer;
                insert_fw.Cells[1].Value = itemcode;
                insert_fw.Cells[2].Value = "";
                insert_fw.Cells[3].Value = "";
                insert_fw.Cells[4].Value = "";
                insert_fw.Cells[5].Value = id;
                FWDataGridView.Rows.Insert(FWDataGridView.Rows.Count, insert_fw);

            }
            else
            {
                foreach (DataGridViewRow row in FWDataGridView.Rows)
                {
                    if (add_previous_record_ID == row.Cells[5].Value.ToString())
                    {
                        if (color)
                        {
                            insert_fw.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                        }
                        else
                        {
                            insert_fw.DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                        }
                        insert_fw.Cells[0].Value = customer;
                        insert_fw.Cells[1].Value = itemcode;
                        insert_fw.Cells[2].Value = "";
                        insert_fw.Cells[3].Value = "";
                        insert_fw.Cells[4].Value = "";
                        insert_fw.Cells[5].Value = id;
                        FWDataGridView.Rows.Insert(row.Index + 1, insert_fw);
                        break;
                    }
                }
            }


            //Update LW
            DataGridViewRow insert_lw = new DataGridViewRow() { Height = 30 };
            insert_lw.CreateCells(LWDataGridView);
            if (add_to_last)
            {
                add_previous_record_ID = LWDataGridView.Rows[LWDataGridView.Rows.Count - 1].Cells[5].Value.ToString();
                if (color)
                {
                    insert_lw.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                }
                else
                {
                    insert_lw.DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                }
                insert_lw.Cells[0].Value = customer;
                insert_lw.Cells[1].Value = itemcode;
                insert_lw.Cells[2].Value = "";
                insert_lw.Cells[3].Value = "";
                insert_lw.Cells[4].Value = "";
                insert_lw.Cells[5].Value = "";
                insert_lw.Cells[6].Value = "";
                insert_lw.Cells[7].Value = "";
                insert_lw.Cells[8].Value = "";
                insert_lw.Cells[9].Value = "";
                insert_lw.Cells[10].Value = "";
                insert_lw.Cells[11].Value = "";
                insert_lw.Cells[12].Value = id;
                insert_lw.Cells[13].Value = formcode;
                insert_lw.Cells[14].Value = created;
                LWDataGridView.Rows.Insert(LWDataGridView.Rows.Count, insert_lw);
            }
            else
            {
                foreach (DataGridViewRow row in LWDataGridView.Rows)
                {
                    if (add_previous_record_ID == row.Cells[12].Value.ToString())
                    {
                        if (color)
                        {
                            insert_lw.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                        }
                        else
                        {
                            insert_lw.DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                        }
                        insert_lw.Cells[0].Value = customer;
                        insert_lw.Cells[1].Value = itemcode;
                        insert_lw.Cells[2].Value = "";
                        insert_lw.Cells[3].Value = "";
                        insert_lw.Cells[4].Value = "";
                        insert_lw.Cells[5].Value = "";
                        insert_lw.Cells[6].Value = "";
                        insert_lw.Cells[7].Value = "";
                        insert_lw.Cells[8].Value = "";
                        insert_lw.Cells[9].Value = "";
                        insert_lw.Cells[10].Value = "";
                        insert_lw.Cells[11].Value = "";
                        insert_lw.Cells[12].Value = id;
                        insert_lw.Cells[13].Value = formcode;
                        insert_lw.Cells[14].Value = created;
                        LWDataGridView.Rows.Insert(row.Index + 1, insert_lw);
                        break;
                    }
                }
            }

            //Update SR
            DataGridViewRow insert_sr = new DataGridViewRow() { Height = 30 };
            insert_sr.CreateCells(SRDataGridView);
            if (add_to_last)
            {
                add_previous_record_ID = SRDataGridView.Rows[SRDataGridView.Rows.Count - 1].Cells[5].Value.ToString();
                if (color)
                {
                    insert_sr.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                }
                else
                {
                    insert_sr.DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                }
                insert_sr.Cells[0].Value = customer;
                insert_sr.Cells[1].Value = formcode;
                insert_sr.Cells[2].Value = itemcode;
                insert_sr.Cells[3].Value = "";
                insert_sr.Cells[4].Value = sampleweight;
                insert_sr.Cells[5].Value = "";
                insert_sr.Cells[6].Value = created;
                insert_sr.Cells[7].Value = id;
                SRDataGridView.Rows.Insert(SRDataGridView.Rows.Count, insert_sr);
            }
            else
            {
                foreach (DataGridViewRow row in SRDataGridView.Rows)
                {
                    if (add_previous_record_ID == row.Cells[7].Value.ToString())
                    {
                        if (color)
                        {
                            insert_sr.DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                        }
                        else
                        {
                            insert_sr.DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                        }
                        insert_sr.Cells[0].Value = customer;
                        insert_sr.Cells[1].Value = formcode;
                        insert_sr.Cells[2].Value = itemcode;
                        insert_sr.Cells[3].Value = "";
                        insert_sr.Cells[4].Value = sampleweight;
                        insert_sr.Cells[5].Value = "";
                        insert_sr.Cells[6].Value = created;
                        insert_sr.Cells[7].Value = id;
                        SRDataGridView.Rows.Insert(row.Index + 1, insert_sr);
                        break;
                    }
                }
            }
        }

        
    }
}
