using System;

namespace DatabaseCompare.Domain
{
	/// <summary>
	/// Summary description for Column.
	/// </summary>
	public class Column
	{
        string name;
        string type;
        double? length;
        int? scale;

	    public Column( string name, string type, double? length, int? scale)
	    {
	        this.name = name;
	        this.type = type;
	        this.length = length;
	        this.scale = scale;
	    }

	    public string Name
	    {
	        get { return name; }
	        set { name = value; }
	    }

	    public string Type
	    {
	        get { return type; }
	        set { type = value; }
	    }

	    public double? Length
	    {
	        get { return length; }
	        set { length = value; }
	    }

	    public int? Scale
        {
	        get { return scale; }
	        set { scale = value; }
	    }

        public bool CompareTo( Column c )
        {
            return this.Name == c.Name && this.Type == c.Type && this.Length == c.Length && this.Scale == c.Scale;
        }
	}
}
