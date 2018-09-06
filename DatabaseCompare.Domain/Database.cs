using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DatabaseCompare.Domain
{
    /// <summary>
    /// Summary description for Database.
    /// </summary>
    public class Database
    {
        private string connString;
        private Hashtable userTables;
        private Hashtable views;
        private Hashtable storedProcs;
        private Hashtable functions;

        public Database(string connString)
        {
            this.connString = connString;
            this.userTables = new Hashtable();
            this.views = new Hashtable();
            this.storedProcs = new Hashtable();
            this.functions = new Hashtable();
        }

        public Hashtable UserTables
        {
            get { return userTables; }
            set { userTables = value; }
        }

        public Hashtable Views
        {
            get { return views; }
            set { views = value; }
        }

        public Hashtable StoredProcs
        {
            get { return storedProcs; }
            set { storedProcs = value; }
        }

        public Hashtable Functions
        {
            get { return functions; }
            set { functions = value; }
        }

        public bool TestConnection()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "select count(*) from INFORMATION_SCHEMA.TABLES";
                        object o = command.ExecuteScalar();
                        if (o == null || o == DBNull.Value)
                            return false;
                        int i = Convert.ToInt32(o);
                        if (i <= 0)
                            return false;
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            //catch
            {
                return false;
            }
            return true;
        }

        public DataTable LoadTables(string databaseName)
        {
            DataTable dt = new DataTable();
            try
            {
                var tableQuery = string.Format("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA='{0}' ORDER BY TABLE_NAME", databaseName);
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(tableQuery, conn))
                        {
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            dt = ds.Tables[0];
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public void LoadObjects(string databaseName)
        {
            try
            {
                var tableQuery = string.Format("SELECT TABLE_ROWS,TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA='{0}'", databaseName);
                var procQuery = string.Format("SELECT ROUTINE_SCHEMA,ROUTINE_NAME FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE='PROCEDURE' AND ROUTINE_SCHEMA='{0}'", databaseName);
                var funcQuery = string.Format("SELECT ROUTINE_SCHEMA,ROUTINE_NAME FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE='FUNCTION' AND ROUTINE_SCHEMA='{0}'", databaseName);

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = tableQuery;
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserTable t = new UserTable(reader.SafeGetInt(0), reader.SafeGetString(1), databaseName);
                                userTables[t.Name] = t;
                            }
                        }

                        command.CommandText = procQuery;
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StoredProc sp = new StoredProc(0, reader.SafeGetString(1), databaseName);
                                storedProcs[sp.Name] = sp;
                            }
                        }
                        command.CommandText = funcQuery;
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Function f = new Function(0, reader.SafeGetString(1), databaseName);
                                functions[f.Name] = f;
                            }
                        }
                    }

                    foreach (UserTable t in userTables.Values)
                    {
                        t.GatherData(conn);
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ArrayList CompareTo(Database db2)
        {
            ArrayList diffs = new ArrayList();
            CompareObjects(this.UserTables, db2.UserTables, "Table", diffs);
            CompareObjects(this.Views, db2.Views, "View", diffs);
            CompareObjects(this.StoredProcs, db2.StoredProcs, "StoredProc", diffs);
            CompareObjects(this.Functions, db2.Functions, "Function", diffs);

            return diffs;
        }

        private void CompareObjects(Hashtable ht1, Hashtable ht2, string type, ArrayList diffs)
        {
            foreach (DatabaseObject t in ht1.Values)
            {
                if (ht2[t.Name] == null)
                {
                    diffs.Add(new DBDifference(type, t.Name, "Missing in Database 2"));
                }
            }
            foreach (DatabaseObject t in ht2.Values)
            {
                if (ht1[t.Name] == null)
                {
                    diffs.Add(new DBDifference(type, t.Name, "Missing in Database 1"));
                }
            }
            foreach (DatabaseObject t in ht1.Values)
            {
                DatabaseObject o = ht2[t.Name] as DatabaseObject;
                if (o != null)
                {
                    if (!t.CompareTo(o))
                    {
                        diffs.Add(new DBDifference(type, t.Name, "Column Difference"));
                    }
                }
            }
        }


        public string FetchQueryBasedOnType(string missingDatabaseName, string databaseName, string name, string type)
        {
            switch (type)
            {
                case "table":
                    return ModifySqlQueryForDatabase(missingDatabaseName, FetchCreateTableQuery(databaseName, name));
                case "storedproc":
                    return FetchStoreProcQuery(databaseName, name);
                default:
                    return string.Empty;
            }
        }
        private string FetchCreateTableQuery(string databaseName, string tableName)
        {
            var tableQuery = string.Empty;
            try
            {
                var query = string.Format("SHOW CREATE TABLE `{0}`.`{1}`", databaseName, tableName);
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = query;
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tableQuery = string.Format("{0}{1}", reader.SafeGetString(1), ";");
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tableQuery;
        }

        private string FetchStoreProcQuery(string databaseName, string spName)
        {
            var storeProcQuery = string.Empty;
            try
            {
                var query = string.Format("SHOW CREATE PROCEDURE `{0}`.`{1}`", databaseName, spName);
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = query;
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                storeProcQuery = string.Format("{0}{1}", reader.SafeGetString(2), ";");
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return storeProcQuery;
        }

        private string ModifySqlQueryForDatabase(string databaseName, string query)
        {
            query = query.Insert(13, "`" + databaseName + "`.");
            return query;
        }
        public string ExecuteQuery(string query, string currentExecutingQuery)
        {
            string result;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = query;
                        command.ExecuteNonQuery();
                        result = string.Format("{0} Executed Successfully!", currentExecutingQuery);
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    result = string.Format("{0} {1}", currentExecutingQuery, ex.InnerException.Message);
                else
                    result = string.Format("{0} {1}", currentExecutingQuery, ex.Message);
            }

            return result;
        }


        public DataTable LoadTableInfo(string databaseName, string tableName)
        {
            DataTable dt = new DataTable();
            try
            {
                var tableQuery = string.Format("DESCRIBE `{0}`.`{1}`", databaseName, tableName);
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(tableQuery, conn))
                        {
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            dt = ds.Tables[0];
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable LoadTableData(List<string> selectedColumns, Dictionary<string, string> orderByColumn, string databaseName, string tableName)
        {
            DataTable dt = new DataTable();
            try
            {
                string columnsNames = string.Join(",", selectedColumns.Select(c => c).ToArray());
                string[] columns = selectedColumns.Select(c => c).ToArray();
                var tableQuery = string.Format("SELECT {0} FROM `{1}`.`{2}`", columnsNames, databaseName, tableName);

                foreach (var column in columns)
                {
                    if (orderByColumn.ContainsKey(column))
                    {
                        tableQuery += string.Format(" ORDER BY {0} {1}", column, orderByColumn[column]);
                    }
                }

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand command = conn.CreateCommand())
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(tableQuery, conn))
                        {
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            dt = ds.Tables[0];
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
