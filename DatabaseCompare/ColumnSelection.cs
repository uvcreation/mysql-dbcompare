using DatabaseCompare.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DatabaseCompare
{
    public partial class ColumnSelection : Form
    {
        private string connString1 = string.Empty;
        private string connString2 = string.Empty;
        private Database db1;
        private Database db2;
        private string database1;
        private string database2;
        private string table1;
        private string table2;

        public ColumnSelection()
        {
            InitializeComponent();
        }

        public void Init(Database db1, Database db2, string database1, string database2, string table1, string table2)
        {
            this.db1 = db1;
            this.db2 = db2;
            this.database1 = database1;
            this.database2 = database2;
            this.table1 = table1;
            this.table2 = table2;
            LoadLeftTable(db1, database1, table1);
            LoadRightTable(db2, database2, table2);
        }
        private void LoadLeftTable(Database db, string databaseName, string tableName)
        {
            leftTableGrid.DataSource = db.LoadTableInfo(databaseName, tableName);

            //Add a CheckBox Column to the DataGridView at the first position.
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "Select";
            leftTableGrid.Columns.Insert(0, checkBoxColumn);

            //Add a ComboBox Column to the DataGridView at the last position.
            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            comboBoxColumn.HeaderText = "OrderBy";
            comboBoxColumn.Width = 80;
            comboBoxColumn.Name = "OrderBy";
            comboBoxColumn.DataSource = new string[] { "", "ASC", "DESC" }; ;
            leftTableGrid.Columns.Insert(1, comboBoxColumn);
        }

        private void LoadRightTable(Database db, string databaseName, string tableName)
        {
            rightTableGrid.DataSource = db.LoadTableInfo(databaseName, tableName);

            //Add a CheckBox Column to the DataGridView at the first position.
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "Select";
            rightTableGrid.Columns.Insert(0, checkBoxColumn);

            //Add a ComboBox Column to the DataGridView at the last position.
            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            comboBoxColumn.HeaderText = "OrderBy";
            comboBoxColumn.Width = 80;
            comboBoxColumn.Name = "OrderBy";
            comboBoxColumn.DataSource = new string[] { "", "ASC", "DESC" }; ;
            rightTableGrid.Columns.Insert(1, comboBoxColumn);
        }

        private void btnCompareData_Click(object sender, System.EventArgs e)
        {
            GetDifferentDataFromBothTables();
        }

        private void GetDifferentDataFromBothTables()
        {
            List<string> leftSelectedColumns = new List<string>();
            Dictionary<string, string> leftOrderByColumn = new Dictionary<string, string>();
            foreach (DataGridViewRow row in leftTableGrid.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["Select"].Value);
                if (isSelected)
                {
                    leftSelectedColumns.Add(row.Cells["Field"].Value.ToString());
                    if (row.Cells["OrderBy"].Value != null && !string.IsNullOrEmpty(row.Cells["OrderBy"].Value.ToString()))
                        leftOrderByColumn.Add(row.Cells["Field"].Value.ToString(), row.Cells["OrderBy"].Value.ToString());
                }
            }

            List<string> rightSelectedColumns = new List<string>();
            Dictionary<string, string> rightOrderByColumn = new Dictionary<string, string>();
            foreach (DataGridViewRow row in rightTableGrid.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["Select"].Value);
                if (isSelected)
                {
                    rightSelectedColumns.Add(row.Cells["Field"].Value.ToString());
                    if (row.Cells["OrderBy"].Value != null && !string.IsNullOrEmpty(row.Cells["OrderBy"].Value.ToString()))
                        rightOrderByColumn.Add(row.Cells["Field"].Value.ToString(), row.Cells["OrderBy"].Value.ToString());
                }
            }

            var leftTableData = this.db1.LoadTableData(leftSelectedColumns.OrderBy(x=> x).ToList(), leftOrderByColumn, this.database1, this.table1);
            var rightTableData = this.db2.LoadTableData(rightSelectedColumns.OrderBy(x => x).ToList(), rightOrderByColumn, this.database2, this.table2);

            CompareDataTables(ref leftTableData, ref rightTableData);
            BindAndCompareGridData(leftTableData, rightTableData);
        }

        private void CompareDataTables(ref DataTable leftTableData, ref DataTable rightTableData)
        {
            DataTable MaxDataTable;
            DataTable MinDataTable;
            DataRow MaxDataTableRow;
            DataRow MinDataTableRow;

            if (leftTableData.Rows.Count >= rightTableData.Rows.Count)
            {
                MaxDataTable = leftTableData;
                MinDataTable = rightTableData;
            }
            else
            {
                MaxDataTable = rightTableData;
                MinDataTable = leftTableData;
            }

            bool isSame = false;
            for (int i = 0; i < MaxDataTable.Rows.Count; i++)
            {
                MaxDataTableRow = MaxDataTable.Rows[i];
                if (i < MinDataTable.Rows.Count)
                {
                    MinDataTableRow = MinDataTable.Rows[i];
                    for (int j = 0; j < MaxDataTable.Columns.Count; j++)
                    {
                        if (MaxDataTableRow.ItemArray[j].ToString().ToLower().Equals(MinDataTableRow.ItemArray[j].ToString().ToLower()))
                        {
                            isSame = true;
                        }else
                        {
                            isSame = false;
                            continue;
                        }
                    }

                    if (isSame)
                    {
                        MaxDataTable.Rows.Remove(MaxDataTableRow);
                        MinDataTable.Rows.Remove(MinDataTableRow);
                    }
                }
            }
            MaxDataTable.AcceptChanges();
            MinDataTable.AcceptChanges();
        }

        private void BindAndCompareGridData(DataTable leftTableData, DataTable rightTableData)
        {
            leftTableGrid.Columns.Remove("Select");
            leftTableGrid.Columns.Remove("OrderBy");
            rightTableGrid.Columns.Remove("Select");
            rightTableGrid.Columns.Remove("OrderBy");
            leftTableGrid.DataSource = leftTableData;
            rightTableGrid.DataSource = rightTableData;

            DataGridView MaxDataGrid;
            DataGridView MinDataGrid;
            DataGridViewRow MaxTableRow;
            DataGridViewRow MinTableRow;

            if (leftTableGrid.Rows.Count >= rightTableGrid.Rows.Count)
            {
                MaxDataGrid = leftTableGrid;
                MinDataGrid = rightTableGrid;
            }
            else
            {
                MaxDataGrid = rightTableGrid;
                MinDataGrid = leftTableGrid;
            }


            for (int i = 0; i < MaxDataGrid.Rows.Count; i++)
            {
                MaxTableRow = MaxDataGrid.Rows[i];
                if (i < MinDataGrid.Rows.Count)
                {
                    MinTableRow = rightTableGrid.Rows[i];
                    for (int j = 0; j < MaxDataGrid.Columns.Count; j++)
                    {
                        if (!MaxTableRow.Cells[j].Value.Equals(MinTableRow.Cells[j].Value))
                        {
                            MaxTableRow.Cells[j].Style.BackColor = Color.Red;
                            MinTableRow.Cells[j].Style.BackColor = Color.Red;
                        }
                    }
                }
                else
                {
                    MaxTableRow.DefaultCellStyle.BackColor = Color.Green;
                }
            }


        }
    }
}
