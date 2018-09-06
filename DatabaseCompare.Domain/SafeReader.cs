using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCompare.Domain
{
    public static class SafeReader
    {
        public static string SafeGetString(this MySqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
            {
                return reader.GetString(colIndex);
            }
            else
            {
                return null;
            }
        }

        public static int? SafeGetInt(this MySqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
            {
                return reader.GetInt32(colIndex);
            }
            else
            {
                return null;
            }
        }

        public static double? SafeGetDouble(this MySqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
            {
                return reader.GetDouble(colIndex);
            }
            else
            {
                return null;
            }
        }
    }
}
