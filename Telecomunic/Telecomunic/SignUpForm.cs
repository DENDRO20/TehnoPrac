using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SLRDbConnector;

namespace Telecomunic
{
    public partial class SignUpForm : Form
    {
        DbConnector db;
        public SignUpForm()
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
        //this function Convert to Decord your Password
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

        private void submitTxt_Click(object sender, EventArgs e)
        {
            if (isFormValid())
            {
                string localitate = localitateTxt.Text;
                string strada = stradaTxt.Text;
                int casa = Int32.Parse(casaTxt.Text);
                int apartament = Int32.Parse(apartamentTxt.Text);
                string nume = numeTxt.Text;
                SetValueForText11 = nume;
                string gen = genCombo.SelectedItem.ToString();
                string id_adresa;
                string parola = EncodePasswordToBase64(parolaTxt.Text);
                SetValueForText22 = parola;
                db.getSingleValue("select id from Adrese where localitate = '" + localitate + "' and strada = '" + strada + "' and nrCasa = '" + casa + "' and apartament = '" + apartament + "'", out id_adresa, 0);
                if (id_adresa == null)
                {
                    db.performCRUD("insert into Adrese values('" + localitate + "', '" + strada + "', " + casa + ", " + apartament + ")");
                    db.getSingleValue("select id from Adrese where localitate = '" + localitate + "' and strada = '" + strada + "' and nrCasa = '" + casa + "' and apartament = '" + apartament + "'", out id_adresa, 0);
                    db.performCRUD("insert into Abonati values('" + nume + "', '" + gen + "', " + Int32.Parse(id_adresa) + ", '" + parola + "')");
                    foreach (var c in this.Controls)
                    {
                        if (c is TextBox)
                        {
                            ((TextBox)c).Text = String.Empty;
                        }
                        if (c is ComboBox)
                        {
                            ((ComboBox)c).SelectedIndex = 0;
                        }
                    }

                    using (MainApp fd = new MainApp())
                    {
                        fd.ShowDialog();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("This address is already taken! Check your spelling.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static string SetValueForText11 = "";
        public static string SetValueForText22 = "";

        private bool isFormValid()
        {
            if (numeTxt.Text.ToString().Trim() == string.Empty || genCombo.SelectedItem.ToString().Trim().Trim() == string.Empty || parolaTxt.Text.ToString().Trim().Trim() == string.Empty || localitateTxt.Text.ToString().Trim().Trim() == string.Empty || stradaTxt.Text.ToString().Trim().Trim() == string.Empty || casaTxt.Text.ToString().Trim().Trim() == string.Empty || apartamentTxt.Text.ToString().Trim().Trim() == string.Empty)
            {
                MessageBox.Show("Required Fields are empty", "Please fill all required fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            else
            {
                return true;
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            foreach (var c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = String.Empty;
                }
                if (c is ComboBox)
                {
                    ((ComboBox)c).SelectedIndex = 0;
                }
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
