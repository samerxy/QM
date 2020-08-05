using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Inventory_Management.DAL
{
    class DataAccessLayer
    {
        SqlConnection sqlConnection;
        //for database connection initil
        public DataAccessLayer()
        {
            sqlConnection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=QM;Integrated Security=true");

        }
        //open connection method
        public void Open()
        {
            if(sqlConnection.State!=ConnectionState.Open)
            {
                sqlConnection.Open();
            }
        }

        // close connection method
        public void Close()
        {
            if(sqlConnection.State==ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        //read data from database method
        public DataTable SelectData(string stored_procedure,SqlParameter[]param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = sqlConnection;

            if(param!=null)
            {
                
                    sqlcmd.Parameters.AddRange(param);
                
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        //Insert,Update,Delete data from database method
        public void ExecuteCommand(string stored_procedure,SqlParameter[]param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = sqlConnection;
            if (param!=null)
            {
                sqlcmd.Parameters.AddRange(param);
            }
            sqlcmd.ExecuteNonQuery();
        }
    }

}
