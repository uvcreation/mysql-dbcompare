using DatabaseCompare.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DatabaseCompare
{
    /// <summary>
    /// Summary description for ChangeScript.
    /// </summary>
    public class ChangeScript : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TextBox txtChangeScript;
        private Button btnGenerate;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        private string connString1 = string.Empty;
        private string connString2 = string.Empty;
        private Database db;

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
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        public void SetText(string s)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeScript));
            this.txtChangeScript = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtChangeScript
            // 
            this.txtChangeScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChangeScript.Location = new System.Drawing.Point(8, 8);
            this.txtChangeScript.Multiline = true;
            this.txtChangeScript.Name = "txtChangeScript";
            this.txtChangeScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtChangeScript.Size = new System.Drawing.Size(584, 456);
            this.txtChangeScript.TabIndex = 0;
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.AliceBlue;
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(8, 468);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(580, 30);
            this.btnGenerate.TabIndex = 9;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // ChangeScript
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(600, 502);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtChangeScript);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeScript";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Script";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.CreateConnectionStrings(out connString1, out connString2);
            db = new Database(connString1);

            if (btnGenerate.Text == "Generate")
            {
                SetText(GenerateResult(db));
                btnGenerate.Text = "Close";
            }
            else if (btnGenerate.Text == "Close")
            {
                this.Close();
            }
        }

        private string GenerateResult(Database db)
        {
            string currentExecutingQuery = string.Empty;
            StringBuilder executionResults = new StringBuilder();

            executionResults.Append(txtChangeScript.Text);
            executionResults.Append(Environment.NewLine);
            executionResults.Append(Environment.NewLine);
            executionResults.Append("======================== Execution Result ========================");
            List<string> lstQuery = txtChangeScript.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList().Where(x => x != string.Empty).ToList();
            if (lstQuery.Count > 0)
            {
                foreach (var query in lstQuery)
                {
                    executionResults.Append(Environment.NewLine);
                    executionResults.Append(Environment.NewLine);
                    if (query.ToString().Contains("Query"))
                    {
                        currentExecutingQuery = query.Replace("===========================", "").Trim();
                        continue;
                    }
                    executionResults.Append(db.ExecuteQuery(query, currentExecutingQuery));
                }
            }

            return executionResults.ToString();
        }
    }
}
