using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;

namespace DatabaseCompare.Domain
{
	/// <summary>
	/// Summary description for StoredProc.
	/// </summary>
	public class StoredProc : DatabaseObject
	{
        string textDefinition;

	    public StoredProc(int id, string name, string dbName) : base(id, name, dbName)
	    {
	    }

        public override void GatherData( MySqlConnection conn )
        {
            base.GatherData( conn );
            using( MySqlCommand command = conn.CreateCommand() )
            {
                command.CommandText = "select text from syscomments where id=@id";
                using ( MySqlDataReader reader = command.ExecuteReader() )
                {
                    while( reader.Read() )
                        textDefinition += reader.GetString( 0 ).Trim().ToLower();
                }
            }
        }

	    public string TextDefinition
	    {
	        get { return textDefinition; }
	        set { textDefinition = value; }
	    }

        protected override bool LocalCompare( DatabaseObject obj )
        {
            if ( obj is StoredProc )
                return this.TextDefinition == ((StoredProc)obj).TextDefinition;
            return false;
        }

	}
}
