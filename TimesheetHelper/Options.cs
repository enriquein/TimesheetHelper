using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace TimesheetHelper
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread.Sleep(5000);
            MessageBox.Show(Win32.GetCurrentWindowTitle());
        }
    }
}
