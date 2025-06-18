using System;
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
using SLRDbConnector;

namespace Telecomunic
{
    public partial class LoginForm : Form
    {
        DbConnector db;
        string username;
        string password;
        public LoginForm()
        {
            InitializeComponent();
            db = new DbConnector();
            WindowState = FormWindowState.Maximized;
        }
        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        public string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }

        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";

        private void submitTxt_Click(object sender, EventArgs e)
        {


            if (isFormValid())
            {
                if (checkLogin())
                {
                    SetValueForText1 = username;
                    SetValueForText2 = password;

                    var psi = new ProcessStartInfo
                    {
                        FileName = "python",
                        Arguments = "C:\\Users\\User\\Desktop\\Telecomunic\\Telecomunic\\face_cam.py",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        WindowStyle = ProcessWindowStyle.Hidden
                    };

                    Process.Start(psi);

                    string verdict = null;
                    int timeout = 60;
                    string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "verdict.txt");

                    while (timeout-- > 0)
                    {
                        if (File.Exists(filePath))
                        {
                            verdict = File.ReadAllText(filePath).Trim();
                            break;
                        }
                        System.Threading.Thread.Sleep(1000);
                    }

                    if (verdict == "YES")
                    {
                        using (MainApp fd = new MainApp())
                        {

                            fd.ShowDialog();
                            this.Hide();
                        }
                    }
                    else if (verdict == "NO")
                    {
                        MessageBox.Show("Acces refuzat.");
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Fără răspuns. Încercare eșuată.");
                    }

                    if (File.Exists(filePath))
                        File.Delete(filePath);




                }
            }

        }

        private bool checkLogin()
        {

            username = db.getSingleValue("select nume from Abonati where nume = '" + numeTxt.Text + "' and parola = '" + EncodePasswordToBase64(parolaTxt.Text) + "'", out username, 0);
            password = db.getSingleValue("select parola from Abonati where nume = '" + numeTxt.Text + "' and parola = '" + EncodePasswordToBase64(parolaTxt.Text) + "'", out password, 0);
            if (username == null)
            {
                MessageBox.Show("User Name or Password is Incorrect", "Incorrect details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool isFormValid()
        {
            if (numeTxt.Text.ToString().Trim() == string.Empty || parolaTxt.Text.ToString().Trim().Trim() == string.Empty)
            {
                MessageBox.Show("Required Fields are empty", "Please fill all required fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            else
            {
                return true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Form1 fd = new Form1())
            {
                fd.ShowDialog();
                this.Hide();
            }
        }
    }
}
