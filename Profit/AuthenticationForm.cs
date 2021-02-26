using Bunifu.Framework;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Profit
{
    public partial class AuthenticationForm : Form
    {
        Encoder encoder = new Encoder();
        RNGCryptoServiceProvider randomizeIt = new RNGCryptoServiceProvider();
        public MySqlConnection conn = new MySqlConnection("Server=ironside.dev; Port=3306; Database=licenca; Uid=root; Pwd=95653549Hh*;Convert Zero Datetime=True");
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();
        MySqlDataReader dr;
        public string hwid;
        public string key;
        public int remaining_days;
        protected internal string vigpwd = @"EFEMERO";
        Credentials CREDENTIALS = new Credentials();

        public AuthenticationForm()
        {
            InitializeComponent();
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (client.OpenRead("http://google.com/generate_204"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
        public int CalculateDaysLeft(DateTime DateLimit, DateTime CurrentDate)
        {
            try
            {
                int res = (DateLimit - CurrentDate).Days;

                return res;
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função CalculateDaysLeft -> AuthenticationForm\n" + e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public bool SignupAlready()
        {
            try
            {
                bool res = false;
                var encoded_data = File.ReadAllText(Directory.GetCurrentDirectory() + @"\x64\sqlite3.5.dll");
                var data = encoder.Base64Decode(encoder.Decipher(encoded_data, vigpwd)).Split(',').ToList();

                if (data.Count > 1)
                {
                    CREDENTIALS.User = data[0];
                    CREDENTIALS.License = data[1];
                    CREDENTIALS.HWID = data[2];
                    CREDENTIALS.DateLimit = data[3];
                    CREDENTIALS.Banned = Convert.ToBoolean(data[4]);

                    BeginInvoke((MethodInvoker)delegate
                    {
                        tbName.Text = tbName.Text != CREDENTIALS.User ? tbName.Text : CREDENTIALS.User;
                        tbKey.Text = CREDENTIALS.License;
                    });

                    res = true;
                }

                return res;
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função SignupAlready -> AuthenticationForm\n" + e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool IsKeyActive()
        {
            try
            {
                bool res = false;
                string query = "SELECT active FROM profit WHERE licensekey='" + tbKey.Text + "'";

                conn.Open();
                cmd = new MySqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                da = new MySqlDataAdapter(cmd.CommandText, conn);
                da.Fill(dt);
                conn.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["active"].ToString() == "1")
                    {
                        res = true;
                        break;
                    }
                }

                return res;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na função IsKeyActive -> AuthenticationForm\n" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                return false;
            }
        }
        public bool IsUniqueHWID()
        {
            try
            {
                bool res = false;
                string query = "SELECT hwid FROM profit WHERE licensekey='" + tbKey.Text + "'";

                conn.Open();
                cmd = new MySqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                da = new MySqlDataAdapter(cmd.CommandText, conn);
                da.Fill(dt);
                conn.Close();

                if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0][0].ToString() == "0")
                    {
                        res = true;
                    }
                    else if (dt.Rows[0][0].ToString() == hwid)
                    {
                        res = true;
                    }
                }

                return res;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na função IsUniqueHWID -> AuthenticationForm\n\n" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                return false;
            }
        }
        void Connect()
        {
            if (!SignupAlready())
            {
                if (tbKey.Text != "" && tbName.Text != "")
                {
                    if (IsValidKey(tbKey.Text))
                    {
                        if (IsUniqueHWID())
                        {
                            if (IsKeyActive())
                            {
                                try
                                {
                                    conn.Open();
                                    string query = "UPDATE profit SET user=@user,hwid=@hwid WHERE licensekey=@licensekey";
                                    cmd = new MySqlCommand(query, conn);
                                    cmd.Parameters.AddWithValue("@user", tbName.Text);
                                    cmd.Parameters.AddWithValue("@hwid", hwid);
                                    cmd.Parameters.AddWithValue("@licensekey", tbKey.Text);
                                    cmd.ExecuteNonQuery();

                                    query = "SELECT validade FROM profit WHERE hwid='" + hwid + "' AND licensekey='" + tbKey.Text + "'";
                                    cmd = new MySqlCommand(query, conn);
                                    MySqlDataAdapter da = null;
                                    DataTable dt = new DataTable();
                                    da = new MySqlDataAdapter(cmd.CommandText, conn);
                                    da.Fill(dt);
                                    conn.Close();

                                    remaining_days = (DateTime.Parse(dt.Rows[0][0].ToString()) - DateTime.Now).Days;

                                    var credentials = new Credentials
                                    {
                                        User = tbName.Text,
                                        License = tbKey.Text,
                                        HWID = hwid,
                                        DateLimit = dt.Rows[0][0].ToString(),
                                        Banned = false
                                    };

                                    string data = encoder.Encipher(encoder.Base64Encode(credentials.User + "," + credentials.License + "," + credentials.HWID + "," + credentials.DateLimit + "," + credentials.Banned.ToString()), vigpwd);
                                    File.WriteAllText(Directory.GetCurrentDirectory() + @"\x64\sqlite3.5.dll", data);

                                    RegistryKey key;
                                    key = Registry.CurrentUser.CreateSubKey("Profit");
                                    key.SetValue("Limit", encoder.Encipher(encoder.Base64Encode(DateTime.Today.ToString()), vigpwd));
                                    key.Close();

                                    btnConnect.Enabled = true;                                    

                                    if (remaining_days >= 0)
                                    {
                                        AutoClosingMessageBox.Show("Bem vindo à sua gerência de lucro!", "Olá!", 3000);

                                        BeginInvoke((MethodInvoker)delegate
                                        {
                                            MainForm open = new MainForm(tbKey.Text, hwid, remaining_days);
                                            this.Hide();
                                            open.ShowDialog();
                                        });
                                    }
                                    else
                                    {
                                        MessageBox.Show("Essa chave de licença está expirada. Entre em contato com a administração.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Erro no 1º estágio da função Connect -> AuthenticationForm\n" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("A chave está desativada.", "Chave Inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                conn.Close();
                                BeginInvoke((MethodInvoker)delegate
                                {
                                    tbKey.Focus();
                                });
                            }
                        }
                        else
                        {
                            MessageBox.Show("A chave já está registrada para outro computador.", "Chave Inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            conn.Close();
                            BeginInvoke((MethodInvoker)delegate
                            {
                                tbKey.Focus();
                            });
                        }
                    }
                    else
                    {
                        MessageBox.Show("A chave é inválida.", "Chave Inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        conn.Close();
                        BeginInvoke((MethodInvoker)delegate
                        {
                            tbKey.Focus();
                        });
                    }
                }
            }
            else
            {
                try
                {
                    if (CREDENTIALS.HWID == hwid)
                    {
                        int res = (DateTime.Parse(CREDENTIALS.DateLimit) - DateTime.Today).Days;

                        if (res >= 0)
                        {
                            CREDENTIALS.Banned = false;
                            string data = encoder.Encipher(encoder.Base64Encode(CREDENTIALS.User + "," + CREDENTIALS.License + "," + CREDENTIALS.HWID + "," + CREDENTIALS.DateLimit + "," + CREDENTIALS.Banned.ToString()), vigpwd);
                            File.WriteAllText(Directory.GetCurrentDirectory() + @"\x64\sqlite3.5.dll", data);

                            MessageBox.Show("A data de validade da sua chave expirou. Entre em contato com a administração.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {       
                            if (DateCheck())
                            {
                                CheckUpdate();
                                btnConnect.Enabled = true;
                                MainForm open = new MainForm(tbKey.Text, hwid, res);
                                conn.Close();
                                this.Hide();
                                open.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Sincronize o horário do seu computador.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Essa chave de validade está registrada para outro computador.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro no 2º estágio da função Connect -> AuthenticationForm\n\n" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
            }
        }
        void CheckUpdate()
        {
            try
            {
                Task.Run(() =>
                {
                    string URL = "http://" + File.ReadLines("pid").Skip(1).Take(1).First() + "/data/data.zip";
                    string client_version = File.ReadLines("pid").Skip(3).Take(1).First();

                    WebClient wc = new WebClient();
                    string query = "http://" + File.ReadAllLines("pid").Skip(1).Take(1).First() + "/pid.txt";
                    string server_version = wc.DownloadString("http://" + File.ReadAllLines("pid").Skip(1).Take(1).First() + "/pid.txt");

                    if (client_version != server_version)
                    {
                        if (DialogResult.Yes == MessageBox.Show("A atualização " + server_version + " está disponível. Deseja atualizar agora?", "Atualização Disponível", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            Process.Start(Directory.GetCurrentDirectory() + @"\Atualizador.exe");
                            GC.Collect();
                            Process p = Process.GetCurrentProcess();
                            p.Kill();
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na função CheckUpdate -> AuthenticationForm\n\n" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            Task.Run(() => Connect());
        }
        private bool DateCheck()
        {
            try
            {
                bool res = false;

                var registro = Registry.CurrentUser.CreateSubKey("Profit").GetValue("Limit").ToString();                
                var lastDate = DateTime.Parse(encoder.Base64Decode(encoder.Decipher(registro, vigpwd)));

                if ((DateTime.Compare(DateTime.Now, lastDate)) >= 0)
                {
                    RegistryKey key;
                    key = Registry.CurrentUser.CreateSubKey("Profit");
                    key.SetValue("Limit", encoder.Encipher(encoder.Base64Encode(DateTime.Today.ToString()), vigpwd));
                    key.Close();
                    
                    res = true;
                }

                return res;
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na função DateCheck -> AuthenticationForm\n\n" + e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }            
        }

        private bool IsValidKey(string userKey)
        {
            try
            {
                bool res = false;

                string query = "SELECT licensekey FROM profit WHERE licensekey=@userKey";
                conn.Open();
                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("userKey", userKey);
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();

                dr.ReadAsync();

                if (dr.HasRows)
                {
                    res = true;
                }

                conn.Close();
                return res;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na função IsValidKey -> AuthenticationForm\n" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                return false;
            }
        }
        private void AuthenticationForm_Load(object sender, EventArgs e)
        {
            try
            {
                UserEncryptedHwid();

                if (SignupAlready())
                {
                    Connect();

                    tbKey.Text = CREDENTIALS.License;
                    tbName.Text = CREDENTIALS.User;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no evento Load -> AuthenticationForm\n" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        protected internal string UserEncryptedHwid()
        {
            ManagementClass managClass = new ManagementClass("win32_processor");
            ManagementObjectCollection managCollec = managClass.GetInstances();

            foreach (ManagementObject managObj in managCollec)
            {
                hwid = managObj.Properties["processorID"].Value.ToString();
                break;
            }

            return hwid;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                if (tbName.Text.Trim() != string.Empty && tbKey.Text.Trim() != string.Empty && hwid.Trim() != string.Empty)
                {
                    Task.Run(() => CheckValidate(tbName.Text, tbKey.Text, hwid));
                }

                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public async void CheckValidate(string user, string key, string hwid)
        {
            try
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    this.BackColor = Color.Red;
                });

                conn.Open();
                string query = "SELECT validade FROM profit WHERE hwid='" + hwid + "' AND licensekey='" + key + "' AND user='" + user + "'";
                cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter da = null;
                DataTable dt = new DataTable();
                da = new MySqlDataAdapter(cmd.CommandText, conn);
                da.Fill(dt);
                conn.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (CalculateDaysLeft(DateTime.Parse(dt.Rows[0][0].ToString()), DateTime.Parse(CREDENTIALS.DateLimit)) > 0)
                    {
                        CREDENTIALS.DateLimit = dt.Rows[0][0].ToString();
                        string data = encoder.Encipher(encoder.Base64Encode(CREDENTIALS.User + "," + CREDENTIALS.License + "," + CREDENTIALS.HWID + "," + CREDENTIALS.DateLimit + "," + CREDENTIALS.Banned.ToString()), vigpwd);
                        File.WriteAllText(Directory.GetCurrentDirectory() + @"\x64\sqlite3.5.dll", data);

                        MessageBox.Show("Data limite atualizada.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                BeginInvoke((MethodInvoker)delegate
                {
                    this.BackColor = Color.White;
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na função CheckValidate-> AuthenticationForm\n" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error); throw;
            }
        }
        private void linkBuy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://wa.me/5528999218073");
        }
        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void tbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tbKey.Focus();
        }
        private void tbKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Task.Run(() => Connect());
        }
    }
}