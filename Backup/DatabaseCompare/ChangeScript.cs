using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DatabaseCompare
{
	/// <summary>
	/// Summary description for ChangeScript.
	/// </summary>
	public class ChangeScript : System.Windows.Forms.Form
	{
        private System.Windows.Forms.TextBox txtChangeScript;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ChangeScript()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

        public void SetText( string s )
        {
            txtChangeScript.Text = s;
        }

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.txtChangeScript = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtChangeScript
            // 
            this.txtChangeScript.Location = new System.Drawing.Point(8, 8);
            this.txtChangeScript.Multiline = true;
            this.txtChangeScript.Name = "txtChangeScript";
            this.txtChangeScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtChangeScript.Size = new System.Drawing.Size(584, 456);
            this.txtChangeScript.TabIndex = 0;
            this.txtChangeScript.Text = "";
            // 
            // ChangeScript
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(600, 470);
            this.Controls.Add(this.txtChangeScript);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeScript";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Script";
            this.ResumeLayout(false);

        }
		#endregion
	}
}
