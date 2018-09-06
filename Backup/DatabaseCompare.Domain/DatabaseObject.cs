using System;
using System.Collections;
using System.Data.SqlClient;

namespace DatabaseCompare.Domain
{
	/// <summary>
	/// Summary description for DatabaseObject.
	/// </summary>
	public abstract class DatabaseObject
	{
		string name;
        int id;
        private Hashtable columns;

	    public DatabaseObject( string name, int id )
	    {
	        this.name = name.ToLower();
	        this.id = id;
            columns = new Hashtable();
	    }

	    public string Name
	    {
	        get { return name; }
	        set { name = value; }
	    }

	    public int Id
	    {
	        get { return id; }
	        set { id = value; }
	    }

	    public Hashtable Columns
	    {
	        get { return columns; }
	        set { columns = value; }
	    }

	    public virtual void GatherData( SqlConnection conn )
        {
            GetColumnData( conn );
        }

        private void GetColumnData( SqlConnection conn )
        {
            using( SqlCommand command = conn.CreateCommand() )
            {
                command.CommandText = "select name, xtype, length, xscale from syscolumns where id=@id order by colorder";
                command.Parameters.Add( "@id", this.id );
                using( SqlDataReader reader = command.ExecuteReader() )
                {
                    while( reader.Read() )
                    {
                       columns[reader.GetString(0)] = new Column( reader.GetString( 0 ), reader.GetByte( 1 ),
                           reader.GetInt16( 2 ), reader.GetByte( 3 ) ); 
                    }
                }
            }
        }

        public bool CompareTo( DatabaseObject obj )
        {
            return CompareColumns( obj ) && LocalCompare( obj );
        }

        protected virtual bool LocalCompare( DatabaseObject obj )
        {
            return true;
        }

        private bool CompareColumns( DatabaseObject obj )
        {
            if ( this.Columns.Values.Count != obj.Columns.Values.Count )
                return false;
            foreach( Column c in this.Columns.Values )
            {
                Column oc = obj.Columns[c.Name] as Column;
                if ( oc == null )
                    return false;
                if ( !c.CompareTo( oc ) )
                    return false;
            }
            return true;
        }
	}
}
