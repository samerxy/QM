using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Inventory_Management.DAL;

namespace Inventory_Management.BL
{
    class C_Login
    {
        DataAccessLayer cs = new DataAccessLayer();
        public DataTable login(string username, string password)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@ID", SqlDbType.NVarChar, 50);
            parameters[0].Value = username;


            parameters[1] = new SqlParameter("@PWD", SqlDbType.NVarChar, 50);
            parameters[1].Value = password;

            DataTable dt = new DataTable();
            dt = cs.SelectData("sp_login", parameters);
            return dt;
        }

        public void Add_User( string ID, string FULLNAME,  string PWD,string USERTYPE)
        {
            cs.Open();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ID", SqlDbType.NVarChar);
            param[0].Value = ID;
            param[1] = new SqlParameter("@FULLNAME", SqlDbType.NVarChar);
            param[1].Value = FULLNAME;
            param[2] = new SqlParameter("@PWD", SqlDbType.NVarChar);
            param[2].Value = PWD;
            param[3] = new SqlParameter("@USERTYPE", SqlDbType.NVarChar);
            param[3].Value = USERTYPE;
            cs.ExecuteCommand("add_user", param);
            cs.Close();
        }
    }
}
