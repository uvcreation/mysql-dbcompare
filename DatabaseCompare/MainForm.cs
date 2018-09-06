using DatabaseCompare.Domain;
using System;
using System.Collections;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DatabaseCompare
{
    /// <summary>
    /// Summary description for MainForm.
    /// </summary>
    public class MainForm : System.Windows.Forms.Form
    {
        delegate void UIHelperDelegate(Boolean working);
        delegate void StatusDelegate(string statusMessage);

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtServer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUN1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtP1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtP2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUN2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDB2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtServer2;
        private System.Windows.Forms.Button btnTestConnections;
        private System.Windows.Forms.TextBox txtDB1;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        private string connString1 = "";
        private string connString2 = "";

        private Database db1;
        private System.Windows.Forms.Button btnCompareDatabases;
        private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView lvDifferences;
        private System.Windows.Forms.Button btnChangeScript;
        private GroupBox groupBox3;
        private Button btnNext;
        private ComboBox lstTablesDB2;
        private ComboBox lstTablesDB1;
        private Label label3;
        private Label label15;
        private Label label8;
        private LinkLabel linkLabel1;
        private Database db2;

        public MainForm()
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

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtP1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUN1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDB1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServer1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtP2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUN2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDB2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtServer2 = new System.Windows.Forms.TextBox();
            this.btnTestConnections = new System.Windows.Forms.Button();
            this.btnCompareDatabases = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.lvDifferences = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnChangeScript = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.lstTablesDB2 = new System.Windows.Forms.ComboBox();
            this.lstTablesDB1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtP1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtUN1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDB1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtServer1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 168);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database 1";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(7, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Password";
            // 
            // txtP1
            // 
            this.txtP1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtP1.Location = new System.Drawing.Point(96, 121);
            this.txtP1.Name = "txtP1";
            this.txtP1.Size = new System.Drawing.Size(198, 24);
            this.txtP1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "User Name";
            // 
            // txtUN1
            // 
            this.txtUN1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtUN1.Location = new System.Drawing.Point(96, 88);
            this.txtUN1.Name = "txtUN1";
            this.txtUN1.Size = new System.Drawing.Size(198, 24);
            this.txtUN1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Database";
            // 
            // txtDB1
            // 
            this.txtDB1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtDB1.Location = new System.Drawing.Point(96, 55);
            this.txtDB1.Name = "txtDB1";
            this.txtDB1.Size = new System.Drawing.Size(198, 24);
            this.txtDB1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server";
            // 
            // txtServer1
            // 
            this.txtServer1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtServer1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtServer1.Location = new System.Drawing.Point(96, 24);
            this.txtServer1.Name = "txtServer1";
            this.txtServer1.Size = new System.Drawing.Size(198, 24);
            this.txtServer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtP2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtUN2);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtDB2);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtServer2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.groupBox2.Location = new System.Drawing.Point(11, 260);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 170);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database 2";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Password";
            // 
            // txtP2
            // 
            this.txtP2.BackColor = System.Drawing.Color.Beige;
            this.txtP2.Location = new System.Drawing.Point(96, 123);
            this.txtP2.Name = "txtP2";
            this.txtP2.Size = new System.Drawing.Size(198, 24);
            this.txtP2.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "User Name";
            // 
            // txtUN2
            // 
            this.txtUN2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtUN2.Location = new System.Drawing.Point(96, 89);
            this.txtUN2.Name = "txtUN2";
            this.txtUN2.Size = new System.Drawing.Size(198, 24);
            this.txtUN2.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(8, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 16);
            this.label9.TabIndex = 3;
            this.label9.Text = "Database";
            // 
            // txtDB2
            // 
            this.txtDB2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtDB2.Location = new System.Drawing.Point(96, 56);
            this.txtDB2.Name = "txtDB2";
            this.txtDB2.Size = new System.Drawing.Size(198, 24);
            this.txtDB2.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "Server";
            // 
            // txtServer2
            // 
            this.txtServer2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txtServer2.Location = new System.Drawing.Point(96, 25);
            this.txtServer2.Name = "txtServer2";
            this.txtServer2.Size = new System.Drawing.Size(198, 24);
            this.txtServer2.TabIndex = 0;
            // 
            // btnTestConnections
            // 
            this.btnTestConnections.BackColor = System.Drawing.Color.AliceBlue;
            this.btnTestConnections.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestConnections.Location = new System.Drawing.Point(11, 439);
            this.btnTestConnections.Name = "btnTestConnections";
            this.btnTestConnections.Size = new System.Drawing.Size(145, 33);
            this.btnTestConnections.TabIndex = 2;
            this.btnTestConnections.Text = "Test Connections";
            this.btnTestConnections.UseVisualStyleBackColor = false;
            this.btnTestConnections.Click += new System.EventHandler(this.btnTestConnections_Click);
            // 
            // btnCompareDatabases
            // 
            this.btnCompareDatabases.BackColor = System.Drawing.Color.AliceBlue;
            this.btnCompareDatabases.Enabled = false;
            this.btnCompareDatabases.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnCompareDatabases.Location = new System.Drawing.Point(162, 439);
            this.btnCompareDatabases.Name = "btnCompareDatabases";
            this.btnCompareDatabases.Size = new System.Drawing.Size(176, 33);
            this.btnCompareDatabases.TabIndex = 3;
            this.btnCompareDatabases.Text = "Compare Database";
            this.btnCompareDatabases.UseVisualStyleBackColor = false;
            this.btnCompareDatabases.Click += new System.EventHandler(this.btnCompareDatabases_Click);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 774);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1096, 22);
            this.statusBar.TabIndex = 4;
            // 
            // lvDifferences
            // 
            this.lvDifferences.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvDifferences.Enabled = false;
            this.lvDifferences.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvDifferences.FullRowSelect = true;
            this.lvDifferences.Location = new System.Drawing.Point(369, 7);
            this.lvDifferences.Name = "lvDifferences";
            this.lvDifferences.Size = new System.Drawing.Size(717, 727);
            this.lvDifferences.TabIndex = 5;
            this.lvDifferences.UseCompatibleStateImageBehavior = false;
            this.lvDifferences.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Type";
            this.columnHeader1.Width = 148;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 335;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            this.columnHeader3.Width = 230;
            // 
            // btnChangeScript
            // 
            this.btnChangeScript.BackColor = System.Drawing.Color.AliceBlue;
            this.btnChangeScript.Enabled = false;
            this.btnChangeScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnChangeScript.Location = new System.Drawing.Point(369, 740);
            this.btnChangeScript.Name = "btnChangeScript";
            this.btnChangeScript.Size = new System.Drawing.Size(715, 28);
            this.btnChangeScript.TabIndex = 6;
            this.btnChangeScript.Text = "Get Change Script";
            this.btnChangeScript.UseVisualStyleBackColor = false;
            this.btnChangeScript.Click += new System.EventHandler(this.btnChangeScript_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox3.Controls.Add(this.btnNext);
            this.groupBox3.Controls.Add(this.lstTablesDB2);
            this.groupBox3.Controls.Add(this.lstTablesDB1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.groupBox3.Location = new System.Drawing.Point(12, 490);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(327, 244);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data Comparer";
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.AliceBlue;
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(95, 180);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(105, 30);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnCompareData_Click);
            // 
            // lstTablesDB2
            // 
            this.lstTablesDB2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lstTablesDB2.FormattingEnabled = true;
            this.lstTablesDB2.Location = new System.Drawing.Point(36, 124);
            this.lstTablesDB2.Name = "lstTablesDB2";
            this.lstTablesDB2.Size = new System.Drawing.Size(239, 26);
            this.lstTablesDB2.TabIndex = 4;
            // 
            // lstTablesDB1
            // 
            this.lstTablesDB1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lstTablesDB1.FormattingEnabled = true;
            this.lstTablesDB1.Location = new System.Drawing.Point(36, 50);
            this.lstTablesDB1.Name = "lstTablesDB1";
            this.lstTablesDB1.Size = new System.Drawing.Size(239, 26);
            this.lstTablesDB1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(85, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tables Database 2";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(85, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(145, 16);
            this.label15.TabIndex = 1;
            this.label15.Text = "Tables Database 1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.AliceBlue;
            this.label8.Location = new System.Drawing.Point(36, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(275, 31);
            this.label8.TabIndex = 8;
            this.label8.Text = "MySQL DBCompare";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(191, 52);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(107, 13);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "www.uvcreation.com";
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1096, 796);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnChangeScript);
            this.Controls.Add(this.lvDifferences);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.btnCompareDatabases);
            this.Controls.Add(this.btnTestConnections);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Compare";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        [STAThread]
        static void Main()
        {
            Application.Run(new MainForm());
        }

        private void btnTestConnections_Click(object sender, System.EventArgs e)
        {
            SetDoingLengthyOperation(true);
            WaitCallback doWork = new WaitCallback(this.DoTestConnections);
            ThreadPool.QueueUserWorkItem(doWork);
        }

        private void DoTestConnections(object o)
        {
            CreateConnectionStrings(out connString1, out connString2);
            db1 = new Database(connString1);
            db2 = new Database(connString2);
            bool b1 = db1.TestConnection();
            bool b2 = db2.TestConnection();
            string s = "";
            if (!b1)
                s = "Database 1 is configured incorrectly.  Please check the configuration.";
            if (!b2)
                s = s.Length == 0 ? "Database 2 is configured incorrectly.  Please check the configuration." : s + "\r\nDatabase 2 is configured incorrectly.  Please check the configuration.";
            if (!b1 || !b2)
            {
                SetDoingLengthyOperation(false);
                btnCompareDatabases.Enabled = false;
                MessageBox.Show(s, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Both Connections tested successfully!", "Success");

            if (lstTablesDB1.InvokeRequired)
            {
                lstTablesDB1.Invoke(new MethodInvoker(delegate
                {
                    lstTablesDB1.DisplayMember = "TABLE_NAME";
                    lstTablesDB1.ValueMember = "TABLE_NAME";
                    lstTablesDB1.DataSource = db1.LoadTables(txtDB1.Text.Trim());
                }));
            }

            if (lstTablesDB2.InvokeRequired)
            {
                lstTablesDB2.Invoke(new MethodInvoker(delegate
                {
                    lstTablesDB2.DisplayMember = "TABLE_NAME";
                    lstTablesDB2.ValueMember = "TABLE_NAME";
                    lstTablesDB2.DataSource = db2.LoadTables(txtDB2.Text.Trim());
                }));
            }

            SetDoingLengthyOperation(false);
            btnCompareDatabases.Enabled = true;
            btnNext.Enabled = true;

        }

        internal void CreateConnectionStrings(out string conn1, out string conn2)
        {
            conn1 = string.Format("server={0};port=3306;database={1};User Id={2};password={3};CharacterSet=utf8;Convert Zero Datetime=True;Allow Zero Datetime=True;AllowUserVariables=True;SslMode=none",
                    txtServer1.Text, txtDB1.Text, txtUN1.Text, txtP1.Text);
            conn2 = string.Format("server={0};port=3306;database={1};User Id={2};password={3};CharacterSet=utf8;Convert Zero Datetime=True;Allow Zero Datetime=True;AllowUserVariables=True;SslMode=none",
                txtServer2.Text, txtDB2.Text, txtUN2.Text, txtP2.Text);
        }

        private void btnCompareDatabases_Click(object sender, System.EventArgs e)
        {
            SetDoingLengthyOperation(true);
            lvDifferences.Items.Clear();
            WaitCallback doWork = new WaitCallback(this.DoGatherDatabaseData);
            ThreadPool.QueueUserWorkItem(doWork);
        }

        private void DoGatherDatabaseData(object param)
        {
            try
            {
                try
                {
                    UpdateStatusBar("Loading Database 1 objects");
                    db1.LoadObjects(txtDB1.Text.Trim());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading Database 1 objects:\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    UpdateStatusBar("Loading Database 2 objects");
                    db2.LoadObjects(txtDB2.Text.Trim());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading Database 2 objects:\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                UpdateStatusBar("Comparing Database objects");
                ArrayList differences = db1.CompareTo(db2);
                differences.Sort();
                foreach (DBDifference d in differences)
                {
                    if (lvDifferences.InvokeRequired)
                    {
                        lvDifferences.Invoke(new MethodInvoker(delegate
                        {
                            lvDifferences.Items.Add(new ListViewItem(new string[] { d.Type, d.Name, d.Status }));
                            lvDifferences.Enabled = true;
                            btnChangeScript.Enabled = true;
                        }));
                    }
                }
                UpdateStatusBar("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error comparing Database objects:\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                SetDoingLengthyOperation(false);
            }
        }

        void SetDoingLengthyOperation(Boolean working)
        {
            if (this.InvokeRequired)
            {
                UIHelperDelegate setDoingLengthyOperation = new UIHelperDelegate(this.SetDoingLengthyOperation);
                Object[] arguments = new Object[] { working };
                this.Invoke(setDoingLengthyOperation, arguments);
                return;
            }

            btnCompareDatabases.Enabled = !working;
            btnTestConnections.Enabled = !working;
            btnNext.Enabled = !working;
            groupBox1.Enabled = !working;
            groupBox2.Enabled = !working;

            if (working)
            {
                this.Cursor = Cursors.WaitCursor;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        void UpdateStatusBar(string message)
        {
            if (this.InvokeRequired)
            {
                StatusDelegate del = new StatusDelegate(this.UpdateStatusBar);
                Object[] arguments = new Object[] { message };
                this.Invoke(del, arguments);
                return;
            }
            statusBar.Text = message;
        }

        private void btnChangeScript_Click(object sender, System.EventArgs e)
        {
            SetDoingLengthyOperation(false);
            WaitCallback doWork = new WaitCallback(this.GenerateSqlScript);
            ThreadPool.QueueUserWorkItem(doWork);
        }

        private void GenerateSqlScript(object o)
        {
            try
            {
                UpdateStatusBar("Generating SQL Script....");
                if (lvDifferences.InvokeRequired)
                {
                    lvDifferences.Invoke(new MethodInvoker(delegate
                    {
                        if (lvDifferences.SelectedItems.Count == 0)
                        {
                            MessageBox.Show("Please select some items to build a change script for.");
                            return;
                        }

                        db1 = new Database(connString1);
                        db2 = new Database(connString2);

                        StringBuilder sb = new StringBuilder();
                        int queryCount = 1;
                        foreach (ListViewItem li in lvDifferences.SelectedItems)
                        {
                            if (li.SubItems != null)
                            {
                                var type = li.SubItems[0].Text.Trim();
                                var name = li.SubItems[1].Text.Trim();
                                var status = li.SubItems[2].Text.Trim();
                                sb.Append(string.Format("=========================== Query {0} ===========================", queryCount));
                                sb.Append(Environment.NewLine);
                                sb.Append(Environment.NewLine);
                                if (status == "Missing in Database 1")
                                {
                                    sb.Append(db2.FetchQueryBasedOnType(txtDB1.Text.Trim().ToLower(), txtDB2.Text.Trim().ToLower(), name.ToLower(), type.ToLower()));
                                }
                                else if (status == "Missing in Database 2")
                                {
                                    sb.Append(db1.FetchQueryBasedOnType(txtDB2.Text.Trim().ToLower(), txtDB1.Text.Trim().ToLower(), name.ToLower(), type.ToLower()));
                                }
                                else if (status == "Column Difference")
                                {
                                    sb.Append("Functionality isn't implemented");
                                }
                                sb.Append(Environment.NewLine);
                                sb.Append(Environment.NewLine);
                                queryCount++;
                            }
                        }
                        UpdateStatusBar("SQL Script Generated");
                        ChangeScript cs = new ChangeScript();
                        cs.SetText(sb.ToString());
                        cs.ShowDialog();

                    }));
                }

                UpdateStatusBar("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while generating script:\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                SetDoingLengthyOperation(false);
            }
        }

        private void btnCompareData_Click(object sender, EventArgs e)
        {
            if (lstTablesDB1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select at least one table of DB1");
                return;
            }
            else if (lstTablesDB2.SelectedIndex == -1)
            {
                MessageBox.Show("Please select at least one table of DB2");
                return;
            }
            else
            {
                db1 = new Database(connString1);
                db2 = new Database(connString2);
                ColumnSelection cs = new ColumnSelection();
                cs.Init(db1, db2, txtDB1.Text.Trim(), txtDB2.Text.Trim(), lstTablesDB1.SelectedValue.ToString(), lstTablesDB2.SelectedValue.ToString());
                cs.ShowDialog();
            }
        }
    }
}
