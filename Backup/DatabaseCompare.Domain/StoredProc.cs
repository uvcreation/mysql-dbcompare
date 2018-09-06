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

	    public StoredProc( string name, int id ) : base( name, id )
	    {
	    }

        public override void GatherData( SqlConnection conn )
        {
            base.GatherData( conn );
            using( SqlCommand command = conn.CreateCommand() )
            {
                command.CommandText = "select text from syscomments where id=@id";
                command.Parameters.Add( "@id", this.Id );
                using ( SqlDataReader reader = command.ExecuteReader() )
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
