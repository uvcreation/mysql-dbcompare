using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DatabaseCompare.Domain;

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
        private System.Windows.Forms.CheckBox chkSSPI1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUN1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtP1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtP2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUN2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkSSPI2;
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtP1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUN1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkSSPI1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDB1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServer1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtP2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUN2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkSSPI2 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDB2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtServer2 = new System.Windows.Forms.TextBox();
            this.btnTestConnections = new System.Windows.Forms.Button();
            this.btnCompareDatabases = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.lvDifferences = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.btnChangeScript = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtP1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtUN1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chkSSPI1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDB1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtServer1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 144);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database 1";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Password";
            // 
            // txtP1
            // 
            this.txtP1.Location = new System.Drawing.Point(96, 112);
            this.txtP1.Name = "txtP1";
            this.txtP1.TabIndex = 8;
            this.txtP1.Text = "";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "User Name";
            // 
            // txtUN1
            // 
            this.txtUN1.Location = new System.Drawing.Point(96, 88);
            this.txtUN1.Name = "txtUN1";
            this.txtUN1.TabIndex = 6;
            this.txtUN1.Text = "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Use Integrated";
            // 
            // chkSSPI1
            // 
            this.chkSSPI1.Location = new System.Drawing.Point(96, 64);
            this.chkSSPI1.Name = "chkSSPI1";
            this.chkSSPI1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Database";
            // 
            // txtDB1
            // 
            this.txtDB1.Location = new System.Drawing.Point(96, 40);
            this.txtDB1.Name = "txtDB1";
            this.txtDB1.TabIndex = 2;
            this.txtDB1.Text = "";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server";
            // 
            // txtServer1
            // 
            this.txtServer1.Location = new System.Drawing.Point(96, 16);
            this.txtServer1.Name = "txtServer1";
            this.txtServer1.TabIndex = 0;
            this.txtServer1.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtP2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtUN2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.chkSSPI2);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtDB2);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtServer2);
            this.groupBox2.Location = new System.Drawing.Point(228, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 144);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database 2";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Password";
            // 
            // txtP2
            // 
            this.txtP2.Location = new System.Drawing.Point(96, 112);
            this.txtP2.Name = "txtP2";
            this.txtP2.TabIndex = 8;
            this.txtP2.Text = "";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "User Name";
            // 
            // txtUN2
            // 
            this.txtUN2.Location = new System.Drawing.Point(96, 88);
            this.txtUN2.Name = "txtUN2";
            this.txtUN2.TabIndex = 6;
            this.txtUN2.Text = "";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 5;
            this.label8.Text = "Use Integrated";
            // 
            // chkSSPI2
            // 
            this.chkSSPI2.Location = new System.Drawing.Point(96, 64);
            this.chkSSPI2.Name = "chkSSPI2";
            this.chkSSPI2.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(8, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 3;
            this.label9.Text = "Database";
            // 
            // txtDB2
            // 
            this.txtDB2.Location = new System.Drawing.Point(96, 40);
            this.txtDB2.Name = "txtDB2";
            this.txtDB2.TabIndex = 2;
            this.txtDB2.Text = "";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "Server";
            // 
            // txtServer2
            // 
            this.txtServer2.Location = new System.Drawing.Point(96, 16);
            this.txtServer2.Name = "txtServer2";
            this.txtServer2.TabIndex = 0;
            this.txtServer2.Text = "";
            // 
            // btnTestConnections
            // 
            this.btnTestConnections.Location = new System.Drawing.Point(168, 160);
            this.btnTestConnections.Name = "btnTestConnections";
            this.btnTestConnections.Size = new System.Drawing.Size(104, 23);
            this.btnTestConnections.TabIndex = 2;
            this.btnTestConnections.Text = "Test Connections";
            this.btnTestConnections.Click += new System.EventHandler(this.btnTestConnections_Click);
            // 
            // btnCompareDatabases
            // 
            this.btnCompareDatabases.Enabled = false;
            this.btnCompareDatabases.Location = new System.Drawing.Point(160, 192);
            this.btnCompareDatabases.Name = "btnCompareDatabases";
            this.btnCompareDatabases.Size = new System.Drawing.Size(120, 23);
            this.btnCompareDatabases.TabIndex = 3;
            this.btnCompareDatabases.Text = "Compare Databases";
            this.btnCompareDatabases.Click += new System.EventHandler(this.btnCompareDatabases_Click);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 264);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(824, 22);
            this.statusBar.TabIndex = 4;
            // 
            // lvDifferences
            // 
            this.lvDifferences.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                            this.columnHeader1,
                                                                                            this.columnHeader2,
                                                                                            this.columnHeader3});
            this.lvDifferences.Enabled = false;
            this.lvDifferences.FullRowSelect = true;
            this.lvDifferences.Location = new System.Drawing.Point(440, 16);
            this.lvDifferences.Name = "lvDifferences";
            this.lvDifferences.Size = new System.Drawing.Size(376, 208);
            this.lvDifferences.TabIndex = 5;
            this.lvDifferences.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Type";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 151;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            this.columnHeader3.Width = 137;
            // 
            // btnChangeScript
            // 
            this.btnChangeScript.Enabled = false;
            this.btnChangeScript.Location = new System.Drawing.Point(600, 232);
            this.btnChangeScript.Name = "btnChangeScript";
            this.btnChangeScript.Size = new System.Drawing.Size(112, 23);
            this.btnChangeScript.TabIndex = 6;
            this.btnChangeScript.Text = "Get Change Script";
            this.btnChangeScript.Click += new System.EventHandler(this.btnChangeScript_Click);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(824, 286);
            this.Controls.Add(this.btnChangeScript);
            this.Controls.Add(this.lvDifferences);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.btnCompareDatabases);
            this.Controls.Add(this.btnTestConnections);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Database Compare";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

        [STAThread]
        static void Main() 
        {
            Application.Run(new MainForm());
        }

        private void btnTestConnections_Click(object sender, System.EventArgs e)
        {
            SetDoingLengthyOperation( true );
            WaitCallback doWork = new WaitCallback( this.DoTestConnections );
            ThreadPool.QueueUserWorkItem( doWork );
        }

        private void DoTestConnections( object o )
        {
            CreateConnectionStrings( out connString1, out connString2 );
            db1 = new Database( connString1 );
            db2 = new Database( connString2 );
            bool b1 = db1.TestConnection();
            bool b2 = db2.TestConnection();
            string s = "";
            if ( !b1 ) 
                s = "Database 1 is configured incorrectly.  Please check the configuration.";
            if ( !b2 )
                s = s.Length == 0 ? "Database 2 is configured incorrectly.  Please check the configuration." : s + "\r\nDatabase 2 is configured incorrectly.  Please check the configuration.";
            if ( !b1 || !b2 )
            {
                SetDoingLengthyOperation( false );
                btnCompareDatabases.Enabled = false;
                MessageBox.Show( s, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }
            MessageBox.Show( "Both Connections tested successfully!", "Success" );
            SetDoingLengthyOperation( false );
            btnCompareDatabases.Enabled = true;

        }

        private void CreateConnectionStrings( out string conn1, out string conn2 )
        {
            if ( chkSSPI1.Checked )
                conn1 = string.Format( "Data Source={0};Initial Catalog={1};Integrated Security=SSPI;",
                   txtServer1.Text, txtDB1.Text ); 
            else
                conn1 = string.Format( "Data Source={0};Initial Catalog={1};UId={2};Pwd={3};",
                    txtServer1.Text, txtDB1.Text, txtUN1.Text, txtP1.Text ); 
            if ( chkSSPI2.Checked )
                conn2 = string.Format( "Data Source={0};Initial Catalog={1};Integrated Security=SSPI;",
                   txtServer2.Text, txtDB2.Text ); 
            else
                conn2 = string.Format( "Data Source={0};Initial Catalog={1};UId={2};Pwd={3};",
                    txtServer2.Text, txtDB2.Text, txtUN2.Text, txtP2.Text ); 
        }

        private void btnCompareDatabases_Click(object sender, System.EventArgs e)
        {
            SetDoingLengthyOperation( true );
            WaitCallback doWork = new WaitCallback( this.DoGatherDatabaseData );
            ThreadPool.QueueUserWorkItem( doWork );
        }

        private void DoGatherDatabaseData( object param ) 
        {
            try
            {
                try
                {
                    UpdateStatusBar( "Loading Database 1 objects" );
                    db1.LoadObjects();    
                }
                catch ( Exception ex )
                {
                    MessageBox.Show( "Error loading Database 1 objects:\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    return;
                }   
                try
                {
                    UpdateStatusBar( "Loading Database 2 objects" );
                 db2.LoadObjects();
                }
                catch ( Exception ex )
                {
                    MessageBox.Show( "Error loading Database 2 objects:\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    return;
                } 
                UpdateStatusBar( "Comparing Database objects" );
                ArrayList differences = db1.CompareTo( db2 );
                differences.Sort();
                foreach( DBDifference d in differences )
                {
                    lvDifferences.Items.Add( new ListViewItem( new string[] {d.Type, d.Name, d.Status } ) );
                }
                lvDifferences.Enabled = true;
                btnChangeScript.Enabled = true;
                UpdateStatusBar( "" );

            }
            catch ( Exception ex )
            {
                MessageBox.Show( "Error comparing Database objects:\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }
            finally
            {
                SetDoingLengthyOperation( false );
            }
        }

        void SetDoingLengthyOperation(Boolean working) 
        {
            if (this.InvokeRequired) 
            { 
                UIHelperDelegate setDoingLengthyOperation = new UIHelperDelegate(this.SetDoingLengthyOperation);
                Object[] arguments = new Object[]{working};
                this.Invoke( setDoingLengthyOperation, arguments);
                return;
            }
            btnCompareDatabases.Enabled = !working;
            btnTestConnections.Enabled = !working;
            groupBox1.Enabled = !working;
            groupBox2.Enabled = !working;

            if ( working )
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
                Object[] arguments = new Object[]{message};
                this.Invoke( del, arguments);
                return;
            }
            statusBar.Text = message;
        }

        private void btnChangeScript_Click(object sender, System.EventArgs e)
        {
            if ( lvDifferences.SelectedItems.Count == 0 )
            {
                MessageBox.Show( "Please select some items to build a change script for." );
                return;
            }
            StringBuilder sb = new StringBuilder();
            foreach( ListViewItem li in lvDifferences.SelectedItems )
            {
                if ( li.Text == "Table" )
                {
                    sb.AppendFormat( "\r\n-- Table {0} \r\n-- Type unsupported\r\n", li.SubItems[1].Text );
                }
                else
                {
                    if ( li.SubItems[2].Text == "Different" )
                    {
                        sb.Append( GetDropScript( li.SubItems[1].Text, li.Text ) );
                        sb.Append( "\r\nGO\r\n" );
                        if ( li.Text == "Function")
                            sb.Append( ((Function)db1.Functions[li.SubItems[1].Text]).TextDefinition );
                        if ( li.Text == "View")
                            sb.Append( ((Domain.View)db1.Views[li.SubItems[1].Text]).TextDefinition );
                        if ( li.Text == "StoredProc")
                            sb.Append( ((StoredProc)db1.StoredProcs[li.SubItems[1].Text]).TextDefinition );
                        sb.Append( "\r\nGO\r\n" );
                    }
                    if ( li.SubItems[2].Text == "Missing in Database 2" )
                    {
                        if ( li.Text == "Function")
                            sb.Append( ((Function)db1.Functions[li.SubItems[1].Text]).TextDefinition );
                        if ( li.Text == "View")
                            sb.Append( ((Domain.View)db1.Views[li.SubItems[1].Text]).TextDefinition );
                        if ( li.Text == "StoredProc")
                            sb.Append( ((StoredProc)db1.StoredProcs[li.SubItems[1].Text]).TextDefinition );
                        sb.Append( "\r\nGO\r\n" );
                    }
                }
            }
            ChangeScript cs = new ChangeScript();
            cs.SetText( sb.ToString() );
            cs.ShowDialog();
        }

        private string GetDropScript( string name, string type )
        {
            if ( type == "StoredProc" )
                type = "procedure";
            string s = @"
                    if ( exists( select 'x' from sysobjects where name='" + name + @"' ) )
                    begin drop " + type + @" " + name + " end";
            return s.Trim();
        }
	}
}
