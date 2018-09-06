using System;

namespace DatabaseCompare.Domain
{
	public class DBDifference : IComparable
	{
        string type;
        string name;
        string status;

	    public DBDifference( string type, string name, string status )
	    {
	        this.type = type;
	        this.name = name;
	        this.status = status;
	    }

	    public string Type
	    {
	        get { return type; }
	        set { type = value; }
	    }

	    public string Name
	    {
	        get { return name; }
	        set { name = value; }
	    }

	    public string Status
	    {
	        get { return status; }
	        set { status = value; }
        }
        #region IComparable Members

        public int CompareTo(object obj)
        {
            DBDifference d = obj as DBDifference;
            if ( d != null )
            {
                if ( d.Type != this.Type )
                    return this.Type.CompareTo( d.Type );
                return this.Name.CompareTo( d.Name );
            }
            return 0;
        }

        #endregion
    }
}
