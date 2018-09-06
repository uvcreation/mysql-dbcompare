using System;

namespace DatabaseCompare.Domain
{
	/// <summary>
	/// Summary description for UserTable.
	/// </summary>
	public class UserTable : DatabaseObject
	{
	    public UserTable( int? rows, string name, string dbName) : base(rows, name, dbName)
	    {
	    }

        
	}
}
