using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using System.Windows;
using System.Windows.Forms;
using SLRDbConnector;
//using MailKit.Net.Smtp;
//using MailKit;
//using MimeKit;
//using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
//using System.Windows;
//using System.Xml.Linq;
//using MailKit.Security;
using EASendMail;

namespace Telecomunic
{
    public partial class GetSubscription : UserControl
    {
        DbConnector db;
        int idAbonat;
        int idAbonament;
        //String check;

        public GetSubscription()
        {
            idAbonat = MainApp.id;
            //MessageBox.Show(idAbonat.ToString());
            InitializeComponent();
            db = new DbConnector();
            timer1.Start();
            success_sign.Visible = false;
            successLabel.Visible = false;
        }

        private void pdfOriginal_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
            MainApp.isMenu = false;
        }

        private void pdfPlus_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
            MainApp.isMenu = false;
        }

        private void pdfMobile_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);
            MainApp.isMenu = false;
        }

        private void pdfMobilePlus_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(4);
            MainApp.isMenu = false;
        }



        private void tabControl1_Enter(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (MainApp.isMenu)
            {
                tabControl1.SelectTab(0);
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {

            idAbonament = 1;
            String sameContract = db.getSingleValue("SELECT id FROM Contracte where idAbonat = " + idAbonat + " and idAbonament = " + idAbonament + "", out sameContract, 0);
            String check = db.getSingleValue("SELECT id FROM Contracte where idAbonament<5 and idAbonat=" + idAbonat + "", out check, 0);

            //MessageBox.Show(sameContract);
            if (sameContract == null)
            {
                DialogResult rs = MessageBox.Show("Create listing?", "Confirm Purchase", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    db.performCRUD("insert into Contracte VALUES (" + idAbonat + "," + idAbonament + ",GETDATE(),DATEADD(month, 1, GETDATE()))");
                    if (check != null)
                    {
                        db.performCRUD("DELETE FROM Contracte WHERE id = " + check + "");
                    }

                    success_sign.Visible = true;
                    if (db.getSingleValue("SELECT id from Contracte where idAbonat = " + idAbonat + "", out check, 0) != null)
                    {

                        await Task.Delay(1000);
                        tabControl1.SelectTab(0);
                        MyContracts mc = new MyContracts();
                        mc.UpdateDetails();
                    }
                }
            }
            else
            {
                MessageBox.Show("You already have such a subscription!", "Wait a second...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            idAbonament = 3;
            String sameContract = db.getSingleValue("SELECT id FROM Contracte where idAbonat = " + idAbonat + " and idAbonament = " + idAbonament + "", out sameContract, 0);
            String check = db.getSingleValue("SELECT id FROM Contracte where idAbonament<5 and idAbonat=" + idAbonat + "", out check, 0);
            //MessageBox.Show(sameContract);
            if (sameContract == null)
            {
                DialogResult rs = MessageBox.Show("Create listing?", "Confirm Purchase", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    db.performCRUD("insert into Contracte VALUES (" + idAbonat + "," + idAbonament + ",GETDATE(),DATEADD(month, 1, GETDATE()))");
                    if (check != null)
                    {
                        db.performCRUD("DELETE FROM Contracte WHERE id = " + check + "");
                    }
                    successLabel.Visible = true;
                    if (db.getSingleValue("SELECT id from Contracte where idAbonat = " + idAbonat + "", out check, 0) != null)
                    {

                        await Task.Delay(1000);
                        tabControl1.SelectTab(0);
                        MyContracts mc = new MyContracts();
                        mc.UpdateDetails();
                    }
                }

            }
            else
            {
                MessageBox.Show("You already have such a subscription!", "Wait a second...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private async void button5_Click(object sender, EventArgs e)
        {
            idAbonament = 4;
            String sameContract = db.getSingleValue("SELECT id FROM Contracte where idAbonat = " + idAbonat + " and idAbonament = " + idAbonament + "", out sameContract, 0);
            String check = db.getSingleValue("SELECT id FROM Contracte where idAbonament<5 and idAbonat=" + idAbonat + "", out check, 0);
            //MessageBox.Show(sameContract);
            if (sameContract == null)
            {
                DialogResult rs = MessageBox.Show("Create listing?", "Confirm Purchase", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    db.performCRUD("insert into Contracte VALUES (" + idAbonat + "," + idAbonament + ",GETDATE(),DATEADD(month, 1, GETDATE()))");
                    if (check != null)
                    {
                        db.performCRUD("DELETE FROM Contracte WHERE id = " + check + "");
                    }
                    successLabel.Visible = true;
                    if (db.getSingleValue("SELECT id from Contracte where idAbonat = " + idAbonat + "", out check, 0) != null)
                    {

                        await Task.Delay(1000);
                        tabControl1.SelectTab(0);
                        MyContracts mc = new MyContracts();
                        mc.UpdateDetails();
                    }
                }
            }
            else
            {
                MessageBox.Show("You already have such a subscription!", "Wait a second...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            idAbonament = 5;
            String sameContract = db.getSingleValue("SELECT id FROM Contracte where idAbonat = " + idAbonat + " and idAbonament = " + idAbonament + "", out sameContract, 0);
            String check = db.getSingleValue("SELECT id FROM Contracte where idAbonament>4 and idAbonat=" + idAbonat + "", out check, 0);
            //MessageBox.Show(sameContract);
            if (sameContract == null)
            {
                DialogResult rs = MessageBox.Show("Create listing?", "Confirm Purchase", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    db.performCRUD("insert into Contracte VALUES (" + idAbonat + "," + idAbonament + ",GETDATE(),DATEADD(month, 1, GETDATE()))");
                    if (check != null)
                    {
                        db.performCRUD("DELETE FROM Contracte WHERE id = " + check + "");
                    }
                    successLabel.Visible = true;
                    if (db.getSingleValue("SELECT id from Contracte where idAbonat = " + idAbonat + "", out check, 0) != null)
                    {

                        await Task.Delay(1000);
                        tabControl1.SelectTab(0);
                        MyContracts mc = new MyContracts();
                        mc.UpdateDetails();
                    }
                }
            }
            else
            {
                MessageBox.Show("You already have such a subscription!", "Wait a second...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private async void button7_Click(object sender, EventArgs e)
        {
            idAbonament = 6;
            String sameContract = db.getSingleValue("SELECT id FROM Contracte where idAbonat = " + idAbonat + " and idAbonament = " + idAbonament + "", out sameContract, 0);
            String check = db.getSingleValue("SELECT id FROM Contracte where idAbonament>4 and idAbonat=" + idAbonat + "", out check, 0);
            //MessageBox.Show(sameContract);
            if (sameContract == null)
            {
                DialogResult rs = MessageBox.Show("Create listing?", "Confirm Purchase", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    db.performCRUD("insert into Contracte VALUES (" + idAbonat + "," + idAbonament + ",GETDATE(),DATEADD(month, 1, GETDATE()))");
                    if (check != null)
                    {
                        db.performCRUD("DELETE FROM Contracte WHERE id = " + check + "");
                    }
                    successLabel.Visible = true;
                    if (db.getSingleValue("SELECT id from Contracte where idAbonat = " + idAbonat + "", out check, 0) != null)
                    {

                        await Task.Delay(1000);
                        tabControl1.SelectTab(0);
                        MyContracts mc = new MyContracts();
                        mc.UpdateDetails();
                    }
                }
            }
            else
            {
                MessageBox.Show("You already have such a subscription!", "Wait a second...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private async void button8_Click(object sender, EventArgs e)
        {
            idAbonament = 7;
            String sameContract = db.getSingleValue("SELECT id FROM Contracte where idAbonat = " + idAbonat + " and idAbonament = " + idAbonament + "", out sameContract, 0);
            String check = db.getSingleValue("SELECT id FROM Contracte where idAbonament>4 and idAbonat=" + idAbonat + "", out check, 0);
            //MessageBox.Show(sameContract);
            if (sameContract == null)
            {
                DialogResult rs = MessageBox.Show("Create listing?", "Confirm Purchase", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    db.performCRUD("insert into Contracte VALUES (" + idAbonat + "," + idAbonament + ",GETDATE(),DATEADD(month, 1, GETDATE()))");
                    if (check != null)
                    {
                        db.performCRUD("DELETE FROM Contracte WHERE id = " + check + "");
                    }
                    successLabel.Visible = true;
                    if (db.getSingleValue("SELECT id from Contracte where idAbonat = " + idAbonat + "", out check, 0) != null)
                    {

                        await Task.Delay(1000);
                        tabControl1.SelectTab(0);
                        MyContracts mc = new MyContracts();
                        mc.UpdateDetails();
                    }
                }
            }
            else
            {
                MessageBox.Show("You already have such a subscription!", "Wait a second...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private async void button9_Click(object sender, EventArgs e)
        {
            idAbonament = 8;
            String sameContract = db.getSingleValue("SELECT id FROM Contracte where idAbonat = " + idAbonat + " and idAbonament = " + idAbonament + "", out sameContract, 0);
            String check = db.getSingleValue("SELECT id FROM Contracte where idAbonament>4 and idAbonat=" + idAbonat + "", out check, 0);
            //MessageBox.Show(sameContract);
            if (sameContract == null)
            {
                DialogResult rs = MessageBox.Show("Create listing?", "Confirm Purchase", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    db.performCRUD("insert into Contracte VALUES (" + idAbonat + "," + idAbonament + ",GETDATE(),DATEADD(month, 1, GETDATE()))");
                    if (check != null)
                    {
                        db.performCRUD("DELETE FROM Contracte WHERE id = " + check + "");
                    }
                    successLabel.Visible = true;
                    if (db.getSingleValue("SELECT id from Contracte where idAbonat = " + idAbonat + "", out check, 0) != null)
                    {

                        await Task.Delay(1000);
                        tabControl1.SelectTab(0);
                        MyContracts mc = new MyContracts();
                        mc.UpdateDetails();
                    }
                }
            }
            else
            {
                MessageBox.Show("You already have such a subscription!", "Wait a second...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
            MainApp.isMenu = true;
        }

        public void SendEmail(string email, string subject, string messageBody)
        {
            try
            {
                SmtpMail oMail = new SmtpMail("TryIt");

                // Your gmail email address
                oMail.From = textBox1.Text;
                // Set recipient email address
                oMail.To = "";

                // Set email subject
                oMail.Subject = "Support message";
                // Set email body
                oMail.TextBody = richTextBox1.Text;

                // Gmail SMTP server address
                SmtpServer oServer = new SmtpServer("");
                // Gmail user authentication
                // For example: your email is "gmailid@gmail.com", then the user should be the same
                oServer.User = "";

                // Create app password in Google account
                // https://support.google.com/accounts/answer/185833?hl=en
                oServer.Password = "";

                // Set 587 port, if you want to use 25 port, please change 587 5o 25
                oServer.Port = 587;

                // detect SSL/TLS automatically
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                Console.WriteLine("start to send email over SSL ...");

                SmtpClient oSmtp = new SmtpClient();
                oSmtp.SendMail(oServer, oMail);

                Console.WriteLine("email was sent successfully!");
            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SendEmail(textBox1.Text, "Test", "Text");
            textBox1.Text = "";
            richTextBox1.Clear();
            MessageBox.Show("Message Sent!", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }
    }
}

