using System;
using System.Windows.Forms;

namespace TimesheetHelper
{
    public partial class TrayIcon : Form
    {
        private bool _isInitialLoad = true;
        private bool _hasFormLoaded = false; // If the form is never shown then closing it doesn't exit the app.

        public TrayIcon()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_hasFormLoaded) 
                this.Show();

            this.Close();
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(_isInitialLoad ? false : value);
            _isInitialLoad = false;
        }

        private void On_Tray_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                this.Visible = true;
        }

        private void TrayIcon_Load(object sender, EventArgs e)
        {
            _hasFormLoaded = true;
        }
    }
}
