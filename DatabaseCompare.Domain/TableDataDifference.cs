namespace DatabaseCompare.Domain
{
    public class TableDataDifference
    {
        string name;
        string status;

        public TableDataDifference(string type, string name, string status)
        {
            this.name = name;
            this.status = status;
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
    }
}
