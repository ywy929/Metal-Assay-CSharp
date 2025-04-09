using System;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace Metal_Assay
{
    public partial class SendReportForm : Form
    {
        public SendReportForm()
        {
            InitializeComponent();
        }
        readonly string connection_string = GlobalConfig.ConnectionString;
        private void button1_Click(object sender, EventArgs e)
        {
            string senderEmail = string.Empty;
            string receiverEmail = "mcyeap25@gmail.com";
            string mailPW = string.Empty;
            string subject = $"Report: {fromDateTimePicker.Value:dd/MM/yyyy} to {toDateTimePicker.Value:dd/MM/yyyy}";

            //get email data from DB
            MySqlConnection con = new MySqlConnection(connection_string);
            con.Open();
            string sql = "SELECT companyemail, mailpw FROM user WHERE role = 'worker'";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader data_reader = cmd.ExecuteReader();
            if (data_reader.HasRows)
            {
                while (data_reader.Read())
                {
                    senderEmail = data_reader.GetString("companyemail");
                    mailPW = data_reader.GetString("mailpw");
                }
            }
            data_reader.Close();
            con.Close();


            //get BW assay data of selected range from DB
            int totalbw = 0;
            int bwbillingcoupon = 0;
            int bwnobillingcoupon = 0;
            int bwbillingnocoupon = 0;
            int bwnobillingnocoupon = 0;
            int bwbillingtotal = 0;
            int bwnobillingtotal = 0;
            int bwcoupontotal = 0;
            int bwnocoupontotal = 0;
            con = new MySqlConnection(connection_string);
            con.Open();
            sql = $"SELECT user.billing AS billing, user.coupon AS coupon FROM assayresult INNER JOIN user ON assayresult.customer = user.id " +
                $"WHERE assayresult.created >= '{fromDateTimePicker.Value:yyyy-MM-dd HH:mm:ss}' and assayresult.created <= '{toDateTimePicker.Value.AddDays(1):yyyy-MM-dd HH:mm:ss}' " +
                $"and user.area = 'BW' ORDER BY assayresult.formcode, assayresult.created";
            cmd = new MySqlCommand(sql, con);
            data_reader = cmd.ExecuteReader();
            if (data_reader.HasRows)
            {
                while (data_reader.Read())
                {
                    bool billing = data_reader.GetBoolean("billing");
                    bool coupon = data_reader.GetBoolean("coupon");

                    if (billing && coupon)
                    {
                        bwbillingcoupon++;
                        bwbillingtotal++;
                        bwcoupontotal++;
                    }
                    else if (!billing && coupon)
                    {
                        bwnobillingcoupon++;
                        bwnobillingtotal++;
                        bwcoupontotal++;
                    }
                    else if (billing && !coupon)
                    {
                        bwbillingnocoupon++;
                        bwbillingtotal++;
                        bwnocoupontotal++;
                    }
                    else // !billing && !coupon
                    {
                        bwnobillingnocoupon++;
                        bwnobillingtotal++;
                        bwnocoupontotal++;
                    }
                    totalbw++;
                }
            }
            data_reader.Close();
            con.Close();

            //get PG assay data of selected range from DB
            int totalpg = 0;
            int pgbillingcoupon = 0;
            int pgnobillingcoupon = 0;
            int pgbillingnocoupon = 0;
            int pgnobillingnocoupon = 0;
            int pgbillingtotal = 0;
            int pgnobillingtotal = 0;
            int pgcoupontotal = 0;
            int pgnocoupontotal = 0;


            con = new MySqlConnection(connection_string);
            con.Open();
            sql = $"SELECT user.billing AS billing, user.coupon AS coupon FROM assayresult INNER JOIN user ON assayresult.customer = user.id " +
                $"WHERE assayresult.created >= '{fromDateTimePicker.Value:yyyy-MM-dd HH:mm:ss}' and assayresult.created <= '{toDateTimePicker.Value.AddDays(1):yyyy-MM-dd HH:mm:ss}' " +
                $"and user.area = 'PG' ORDER BY assayresult.formcode, assayresult.created";
            cmd = new MySqlCommand(sql, con);
            data_reader = cmd.ExecuteReader();
            if (data_reader.HasRows)
            {
                while (data_reader.Read())
                {
                    while (data_reader.Read())
                    {
                        bool billing = data_reader.GetBoolean("billing");
                        bool coupon = data_reader.GetBoolean("coupon");

                        if (billing && coupon)
                        {
                            pgbillingcoupon++;
                            pgbillingtotal++;
                            pgcoupontotal++;
                        }
                        else if (!billing && coupon)
                        {
                            pgnobillingcoupon++;
                            pgnobillingtotal++;
                            pgcoupontotal++;
                        }
                        else if (billing && !coupon)
                        {
                            pgbillingnocoupon++;
                            pgbillingtotal++;
                            pgnocoupontotal++;
                        }
                        else // !billing && !coupon
                        {
                            pgnobillingnocoupon++;
                            pgnobillingtotal++;
                            pgnocoupontotal++;
                        }
                        totalpg++;
                    }
                }
            }
            data_reader.Close();
            con.Close();

            //create csv
            // Path to save the CSV file
            string filePath = "sendreport.csv";

            string[] dateinfo = { "Date", $"{fromDateTimePicker.Value:dd/MM/yyyy} to {toDateTimePicker.Value.AddDays(1):dd/MM/yyyy}" };
            string[] totalinfo = { "Total", (totalbw + totalpg).ToString() };
            //create BW section
            string[][] bwdata = new string[][] {
                new string[] {"BW", "", "", "" },
                new string[] {"", "Coupon", "No Coupon", "Total" },
                new string[] {"Billing", bwbillingcoupon.ToString(), bwbillingnocoupon.ToString(), bwbillingtotal.ToString() },
                new string[] {"No Billing", bwnobillingcoupon.ToString(), bwnobillingnocoupon.ToString(), bwnobillingtotal.ToString() },
                new string[] {"Total", bwcoupontotal.ToString(), bwnocoupontotal.ToString(), totalbw.ToString() },
                new string[] {"", "", "", "" }
            };
            //create PG section
            string[][] pgdata = new string[][] {
                new string[] {"PG", "", "", "" },
                new string[] {"", "Coupon", "No Coupon", "Total" },
                new string[] {"Billing", pgbillingcoupon.ToString(), pgbillingnocoupon.ToString(), pgbillingtotal.ToString() },
                new string[] {"No Billing", pgnobillingcoupon.ToString(), pgnobillingnocoupon.ToString(), pgnobillingtotal.ToString() },
                new string[] {"Total", pgcoupontotal.ToString(), pgnocoupontotal.ToString(), totalpg.ToString() }
            };

            // Create the CSV
            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                // Write header
                writer.WriteLine(string.Join(",", dateinfo));
                writer.WriteLine(string.Join(",", totalinfo));
                // Write rows
                foreach (var row in bwdata)
                {
                    writer.WriteLine(string.Join(",", row));
                }

                foreach (var row in pgdata)
                {
                    writer.WriteLine(string.Join(",", row));
                }
            }


            //Send email
            using (var client = new SmtpClient())
            {
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("BRIGHTNESSASSAY25@GMAIL.COM", "eisg plyr vwug qnid");
                using (var message = new MailMessage(
                    from: new MailAddress("BRIGHTNESSASSAY25@GMAIL.COM", "BRIGTNESS ASSAY SDN BHD"),
                    to: new MailAddress(receiverEmail, "MCYEAP")
                    ))
                {

                    message.Subject = subject;
                    message.Body = $"Assay Report: {fromDateTimePicker.Value:dd/MM/yyyy} to {toDateTimePicker.Value:dd/MM/yyyy}";
                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment(@"sendreport.csv");
                    attachment.ContentDisposition.FileName = $"Report: {fromDateTimePicker.Value:dd/MM/yyyy} to {toDateTimePicker.Value:dd/MM/yyyy}.csv";
                    message.Attachments.Add(attachment);
                    client.Send(message);
                }
            }
        }
    }
}
