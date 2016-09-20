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
        //Create a function called GetStates to fill in the States combo box
        public static SqlDataReader GetMyStates()
        {
            //Create my DB objects needed for connection and communication
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //Create my strings to interact with the DB objects
            string strConn = @GetConnected();
            string strSQL = "SELECT * FROM States ORDER BY State";

            //Initialize DB Objects
            conn.ConnectionString = strConn;
            comm.Connection = conn;
            comm.CommandText = strSQL;

            //OleDbDataReader dr = comm.ExecuteReader();
            //ComboBox cmb = new ComboBox();
            //while (dr.Read())
            //{
            //    cmb.Items.Add(dr["state"].ToString());
            //}
            //return cmb;


            //open connection to the DB
            conn.Open();

            //Close connection to the DB
            //conn.Close();

            //Fill a Datareader and return it
            return comm.ExecuteReader();
        }

        //Create a string that will get connected and return the SQL connection string
        public static string GetConnected()
        {
            string strConn;

            strConn = "Server=sql.neit.edu;Database=se255_JArsenault;User Id=se255_JArsenault; Password=001031823;";

            return strConn;
        }
    }
}
