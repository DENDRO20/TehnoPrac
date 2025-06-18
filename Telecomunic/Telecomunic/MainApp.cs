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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Telecomunic
{
    public partial class MainApp : Form
    {
        DbConnector db;
        string username;
        string username1;
        public static string name;
        string password;
        string password1;
        public static string pass;
        public static bool isMenu;
        public static int id;
        String id1;

        public MainApp()
        {

            InitializeComponent();
            username = LoginForm.SetValueForText1;
            username1 = SignUpForm.SetValueForText11;
            password = LoginForm.SetValueForText2;
            password1 = SignUpForm.SetValueForText22;
            //MBox box = new MBox();
            //box.ShowDialog();
            //MessageBox.Show(username);
            WindowState = FormWindowState.Maximized;
            db = new DbConnector();
            if (username.Trim() != string.Empty)
            {
                user.Text = username;
                name = username;
            }
            if (username1.Trim() != string.Empty)
            {
                user.Text = username1;
                name = username1;
            }
            if (password.Trim() != string.Empty) pass = password;
            if (password1.Trim() != string.Empty) pass = password1;

            db.getSingleValue("SELECT id FROM Abonati where nume = '" + name + "' and parola='" + pass + "'", out id1, 0);
            id = Int32.Parse(id1);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void user_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Test");
            GetSubscription mc = new GetSubscription();
            panel2.Controls.Add(mc);
            panel2.Controls["GetSubscription"].BringToFront();
            mc.tabControl1.SelectTab(0);
            isMenu = true;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            MyContracts mc = new MyContracts();
            panel2.Controls.Add(mc);
            mc.UpdateDetails();
            panel2.Controls["MyContracts"].BringToFront();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GetSubscription mc = new GetSubscription();
            panel2.Controls.Clear();
            panel2.Controls.Add(mc);
            panel2.Controls["GetSubscription"].BringToFront();
            mc.tabControl1.SelectTab(5);
            isMenu = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MyContracts mc = new MyContracts();
            mc.UpdateDetails();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            GetSubscription mc = new GetSubscription();
            panel2.Controls.Clear();
            panel2.Controls.Add(mc);
            panel2.Controls["GetSubscription"].BringToFront();
            mc.tabControl1.SelectTab(0);
            isMenu = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            isMenu = false;
            panel2.Controls.Clear();
            GetSubscription mc = new GetSubscription();
            panel2.Controls.Add(mc);
            
            mc.tabControl1.SelectTab(6);
            panel2.Controls["GetSubscription"].BringToFront();


        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

        }
    }
}