using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using HarfBuzzSharp;
using MySql.Data.MySqlClient;
using System.IO;

namespace Metal_Assay
{
    public partial class Login : Form
    {
        private Main MainForm;
        public Login(Main mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
        }
        string connection_string = @"server=192.168.0.36;uid=view1;pwd=Assay123!;database=assay";
        //string connection_string = @"server=localhost;uid=root;pwd=Assay123!;database=assay";
        string sql = "";
        //class that includes function for encryption
        public class EncryptionHelper
        {
            public const int SALT_SIZE = 32;
            public const int HASH_SIZE = 32;
            public const int ITERATIONS = 100000;

            // On declaring a new password for example
            public static (string salt, string hash) CreateHashWithExistingSalt(string input)
            {
                //var provider = new RNGCryptoServiceProvider();
                //provider.GetBytes(existing_salt);

                var pbkdf2 = new Rfc2898DeriveBytes(input, existing_salt, ITERATIONS, HashAlgorithmName.SHA256);
                var hash = pbkdf2.GetBytes(HASH_SIZE);

                var saltString = Convert.ToBase64String(existing_salt);
                var hashString = Convert.ToBase64String(hash);
                return (saltString, hashString);
            }
            public static (string salt, string hash) CreateHashWithNewSalt(string input)
            {
                var provider = new RNGCryptoServiceProvider();
                byte[] salt = new byte[SALT_SIZE];
                provider.GetBytes(salt);

                var pbkdf2 = new Rfc2898DeriveBytes(input, salt, ITERATIONS, HashAlgorithmName.SHA256);
                var hash = pbkdf2.GetBytes(HASH_SIZE);

                var saltString = Convert.ToBase64String(salt);
                var hashString = Convert.ToBase64String(hash);
                return (saltString, hashString);
            }

            public static string GetHash(string saltString, string passwordString)
            {
                byte[] salt = Convert.FromBase64String(saltString);
                var pbkdf2 = new Rfc2898DeriveBytes(passwordString, existing_salt, ITERATIONS, HashAlgorithmName.SHA256);
                return Convert.ToBase64String(pbkdf2.GetBytes(HASH_SIZE));
            }
        }
        byte[] existing_hash = new byte[64];
        static byte[] existing_salt = new byte[64];
        private void GetSaltAndHash()
        {
            var con = new MySqlConnection(connection_string);
            con.Open();
            if (textBox1.Text == "brightness")
            {
                sql = "SELECT pwhash, salt FROM user WHERE role='worker'";
            }
            else if (textBox1.Text == "admin")
            {
                sql = "SELECT pwhash, salt FROM user WHERE role='admin'";
            }
            else if (textBox1.Text == "boss")
            {
                sql = "SELECT pwhash, salt FROM user WHERE role='boss'";
            }
            else
            {
                con.Close();
                return;
            }
            var cmd = new MySqlCommand(sql, con);

            MySqlDataReader data_reader = cmd.ExecuteReader();

            if (data_reader.HasRows)
            {
                while (data_reader.Read())
                {
                    existing_hash = (byte[])data_reader.GetValue(0);
                    existing_salt = (byte[])data_reader.GetValue(1);
                    Console.WriteLine($"DB Salt: {Convert.ToBase64String(existing_salt)}");
                }
            }
            data_reader.Close();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //get hash and salt from db
                GetSaltAndHash();
                // Generate the hash
                var creds = EncryptionHelper.CreateHashWithExistingSalt(textBox2.Text);

                //compare existing hash and computed hash
                var loginHash = EncryptionHelper.GetHash(creds.salt, textBox2.Text);
                Console.WriteLine($"DB Hash: {Convert.ToBase64String(existing_hash)}");
                Console.WriteLine($"DB Salt: {Convert.ToBase64String(existing_salt)}");
                //Console.WriteLine($"Original Hash: {creds.hash}");
                //Console.WriteLine($"     New Hash: {loginHash}");
                Console.WriteLine($"Result: {Convert.ToBase64String(existing_hash) == creds.hash}");
                if (Convert.ToBase64String(existing_hash) == creds.hash)
                {
                    // show main form
                    MainForm.Visible = true;
                    // close login form
                    this.DialogResult = DialogResult.OK;
                    if (textBox1.Text == "admin" || textBox1.Text == "boss")
                    {
                        MainForm.assaySettingToolStripMenuItem.Visible = true;
                    }
                    WriteToLogFile($"Successful login. User:{textBox1.Text}");
                    Close();
                }
                else
                {
                    WriteToLogFile($"Failed login. User:{textBox1.Text}, PW:{textBox2.Text}");
                    MessageBox.Show("Wrong user or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.DialogResult == DialogResult.Cancel)
                {
                    MainForm.Close();
                    WriteToLogFile("Program closed with login form closed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteToLogFile($"Exception: {ex.ToString()}");
            }
        }

        private void Login_Shown(object sender, EventArgs e)
        {
            try
            {
                textBox2.Focus();
                WriteToLogFile("Login form opened.");
            }
            catch (Exception ex)
            {
                WriteToLogFile($"Exception: {ex.ToString()}");
                MessageBox.Show(ex.ToString());
            }
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
