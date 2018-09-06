using System;
using System.Collections;
using System.Data.SqlClient;

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

		public Database( string connString )
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
                using ( SqlConnection conn = new SqlConnection( connString ) )
                {
                    conn.Open();
                    using ( SqlCommand command = conn.CreateCommand() )
                    {
                        command.CommandText = "select count(*) from sysobjects";
                        object o = command.ExecuteScalar();
                        if ( o == null || o == DBNull.Value )
                            return false;
                        int i = (int)o;
                        if ( i <= 0 )
                            return false;
                    }
                    conn.Close();
                }
            }
//            catch ( Exception ex )
            catch
            {
                return false;
            }
            return true;
        }

        public void LoadObjects()
        {
            try
            {
                using ( SqlConnection conn = new SqlConnection( connString ) )
                {
                    conn.Open();
                    using ( SqlCommand command = conn.CreateCommand() )
                    {
                        // get the tables
                        // get the views
                        // get the stored procs
                        // get the functions
                        command.CommandText = "select name, id from sysobjects where xtype='U'";
                        using( SqlDataReader reader = command.ExecuteReader() )
                        {
                            while( reader.Read() )
                            {
                                UserTable t = new UserTable( reader.GetString( 0 ), reader.GetInt32( 1 ) );
                                userTables[t.Name] = t;
                            }
                        }
                        command.CommandText = "select name, id from sysobjects where xtype='V' and category=0";
                        using( SqlDataReader reader = command.ExecuteReader() )
                        {
                            while( reader.Read() )
                            {
                                View v = new View( reader.GetString( 0 ), reader.GetInt32( 1 ) );
                                views[v.Name] = v;
                            }
                        }
                        command.CommandText = "select name, id from sysobjects where xtype='P' and category=0";
                        using( SqlDataReader reader = command.ExecuteReader() )
                        {
                            while( reader.Read() )
                            {
                                StoredProc sp = new StoredProc( reader.GetString( 0 ), reader.GetInt32( 1 ) );
                                storedProcs[sp.Name] = sp;
                            }
                        }
                        command.CommandText = "select name, id from sysobjects where xtype='FN' and category=0";
                        using( SqlDataReader reader = command.ExecuteReader() )
                        {
                            while( reader.Read() )
                            {
                                Function f = new Function( reader.GetString( 0 ), reader.GetInt32( 1 ) );
                                functions[f.Name] = f;
                            }
                        }
                    }
                    // gather the data for the tables, views, procs and functions
                    foreach( UserTable t in userTables.Values )
                        t.GatherData( conn );
                    foreach( View v in views.Values )
                        v.GatherData( conn );
                    foreach( StoredProc sp in storedProcs.Values )
                        sp.GatherData( conn );
                    foreach( Function f in functions.Values )
                        f.GatherData( conn );

                    conn.Close();
                }
            }
            catch ( Exception ex )
            {
                throw ex;
            }
        }

        public ArrayList CompareTo( Database db2 )
        {
            ArrayList diffs = new ArrayList();
            CompareObjects( this.UserTables, db2.UserTables, "Table", diffs );
            CompareObjects( this.Views, db2.Views, "View", diffs );
            CompareObjects( this.StoredProcs, db2.StoredProcs, "StoredProc", diffs );
            CompareObjects( this.Functions, db2.Functions, "Function", diffs );

            return diffs;
        }

        private void CompareObjects( Hashtable ht1, Hashtable ht2, string type, ArrayList diffs )
        {
            foreach( DatabaseObject t in ht1.Values )
            {
                if ( ht2[t.Name] == null )
                {
                    diffs.Add( new DBDifference( type, t.Name, "Missing in Database 2" ) );
                }
            }
            foreach( DatabaseObject t in ht2.Values )
            {
                if ( ht1[t.Name] == null )
                {
                    diffs.Add( new DBDifference( type, t.Name, "Missing in Database 1" ) );
                }
            }
            foreach( DatabaseObject t in ht1.Values )
            {
                DatabaseObject o = ht2[t.Name] as DatabaseObject;
                if ( o != null )
                {
                    if ( !t.CompareTo( o ) )
                    {
                        diffs.Add( new DBDifference( type, t.Name, "Different" ) );
                    }
                }
            }
        }
	}
}
