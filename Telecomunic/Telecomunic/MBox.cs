using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telecomunic
{
    public partial class MBox : Form
    {
        public MBox()
        {
            InitializeComponent();
        }

        private void MBox_Load(object sender, EventArgs e)
        {
            Thread.Sleep(3000);
            Hide();
        }
    }
}
