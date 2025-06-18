using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telecomunic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SignUpForm signUp = new SignUpForm();
            signUp.ShowDialog();
            this.Hide();
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginForm logIn = new LoginForm();
            logIn.ShowDialog();
            this.Hide();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
