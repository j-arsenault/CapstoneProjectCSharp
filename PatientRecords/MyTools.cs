using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PatientRecords
{
    class MyTools
    {
        //Create a string that will get connected and return the SQL connection string
        public static string GetConnected()
        {
            string strConn;

            strConn = "Server=sql.neit.edu;Database=se255_JArsenault;User Id=se255_JArsenault; Password=001031823;";

            return strConn;
        }
    }
}
