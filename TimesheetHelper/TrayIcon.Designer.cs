namespace TimesheetHelper
{
    partial class TrayIcon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.globalHookProvider = new MouseKeyboardActivityMonitor.Controls.MouseKeyEventProvider();
            this.SuspendLayout();
            // 
            // globalHookProvider
            // 
            this.globalHookProvider.Enabled = true;
            this.globalHookProvider.HookType = MouseKeyboardActivityMonitor.Controls.HookType.Global;
            this.globalHookProvider.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnGlobalMouseClick);
            this.globalHookProvider.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnGlobalKeyPress);
            // 
            // TrayIcon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "TrayIcon";
            this.Text = "TrayIcon";
            this.ResumeLayout(false);

        }

        #endregion

        private MouseKeyboardActivityMonitor.Controls.MouseKeyEventProvider globalHookProvider;
    }
}