using MySql.Data.MySqlClient;
using System;
using System.Collections;

namespace DatabaseCompare.Domain
{
    /// <summary>
    /// Summary description for DatabaseObject.
    /// </summary>
    public abstract class DatabaseObject
    {
        int? rows;
        string name;
        string dbName;
        private Hashtable columns;

        public DatabaseObject(int? rows, string name, string dbName)
        {
            this.name = name.ToLower();
            this.rows = rows;
            this.dbName = dbName;
            columns = new Hashtable();
        }

        public int? Rows
        {
            get { return rows; }
            set { rows = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string DatabaseName
        {
            get { return dbName; }
            set { dbName = value; }
        }
        public Hashtable Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        public virtual void GatherData(MySqlConnection conn)
        {
            GetColumns(conn);
        }

        private void GetColumns(MySqlConnection conn)
        {
            var query = string.Format("SELECT COLUMN_NAME,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH,NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='{0}' AND TABLE_SCHEMA='{1}'", Name, DatabaseName);
            using (MySqlCommand command = conn.CreateCommand())
            {
                command.CommandText = query;
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        try
                        {
                            columns[reader.SafeGetString(0)] = new Column(reader.SafeGetString(0), reader.SafeGetString(1), reader.SafeGetDouble(2), reader.SafeGetInt(3));
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    reader.Close();
                }
            }
        }
        public bool CompareTo(DatabaseObject obj)
        {
            return CompareColumns(obj) && LocalCompare(obj);
        }

        protected virtual bool LocalCompare(DatabaseObject obj)
        {
            return true;
        }

        private bool CompareColumns(DatabaseObject obj)
        {
            if (this.Columns.Values.Count != obj.Columns.Values.Count)
                return false;
            foreach (Column c in this.Columns.Values)
            {
                Column oc = obj.Columns[c.Name] as Column;
                if (oc == null)
                    return false;
                if (!c.CompareTo(oc))
                    return false;
            }
            return true;
        }
    }
}
