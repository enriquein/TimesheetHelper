using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimesheetHelper
{
    public partial class TrayIcon : Form
    {
        public TrayIcon( /* something that can save the event */ )
        {
            InitializeComponent();
        }

        private void OnGlobalKeyPress(object sender, KeyPressEventArgs e)
        {
            /* tell that something that the event happened */
        }

        private void OnGlobalMouseClick(object sender, MouseEventArgs e)
        {
            /* tell that something that the event happened */
        }
    }
}
