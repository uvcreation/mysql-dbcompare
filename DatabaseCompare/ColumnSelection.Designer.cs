namespace DatabaseCompare
{
    partial class ColumnSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColumnSelection));
            this.leftTableGrid = new System.Windows.Forms.DataGridView();
            this.rightTableGrid = new System.Windows.Forms.DataGridView();
            this.btnCompareData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.leftTableGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightTableGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // leftTableGrid
            // 
            this.leftTableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.leftTableGrid.Location = new System.Drawing.Point(12, 33);
            this.leftTableGrid.Name = "leftTableGrid";
            this.leftTableGrid.Size = new System.Drawing.Size(614, 606);
            this.leftTableGrid.TabIndex = 0;
            // 
            // rightTableGrid
            // 
            this.rightTableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rightTableGrid.Location = new System.Drawing.Point(678, 33);
            this.rightTableGrid.Name = "rightTableGrid";
            this.rightTableGrid.Size = new System.Drawing.Size(614, 606);
            this.rightTableGrid.TabIndex = 1;
            // 
            // btnCompareData
            // 
            this.btnCompareData.BackColor = System.Drawing.Color.AliceBlue;
            this.btnCompareData.Location = new System.Drawing.Point(560, 719);
            this.btnCompareData.Name = "btnCompareData";
            this.btnCompareData.Size = new System.Drawing.Size(183, 40);
            this.btnCompareData.TabIndex = 9;
            this.btnCompareData.Text = "Compare Tables";
            this.btnCompareData.UseVisualStyleBackColor = false;
            this.btnCompareData.Click += new System.EventHandler(this.btnCompareData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.AliceBlue;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "1st Database Table";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.AliceBlue;
            this.label2.Location = new System.Drawing.Point(675, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "2nd Database Table";
            // 
            // ColumnSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1306, 774);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCompareData);
            this.Controls.Add(this.rightTableGrid);
            this.Controls.Add(this.leftTableGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ColumnSelection";
            this.Text = "ColumnSelection";
            ((System.ComponentModel.ISupportInitialize)(this.leftTableGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightTableGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView leftTableGrid;
        private System.Windows.Forms.DataGridView rightTableGrid;
        private System.Windows.Forms.Button btnCompareData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}