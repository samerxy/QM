using Inventory_Management.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management.BL
{
    class C_Products
    {
        DataAccessLayer cs = new DataAccessLayer();
        public DataTable Get_All_Categories()
        {

            DataTable dt = new DataTable();
            dt = cs.SelectData("Get_All_Categories", null);
            return dt;
        }

        public DataTable Get_All_Products()
        {

            DataTable dt = new DataTable();
            dt = cs.SelectData("Get_All_Products", null);
            return dt;
        }
        public DataTable search_product(string name)
        {
            DataTable dt = new DataTable();
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@ID", SqlDbType.NVarChar, 30);
            parameters[0].Value = name;
            dt = cs.SelectData("search_product", parameters);
            cs.Close();
            return dt;
        }
        public DataTable search_cos(string name)
        {
            DataTable dt = new DataTable();
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            parameters[0].Value = name;
            dt = cs.SelectData("search_cos", parameters);
            cs.Close();
            return dt;
        }
        public DataTable getimage(string name)
        {
            DataTable dt = new DataTable();
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@ID", SqlDbType.NVarChar, 30);
            parameters[0].Value = name;
            dt = cs.SelectData("getimge", parameters);
            cs.Close();
            return dt;
        }
        public void Add_Product(int ID_Catg,string ID_PROD,string PROD_NAME,int QTE,string PRICE,byte[] IMG)
        {
            cs.Open();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@ID_Catg", SqlDbType.Int);
            param[0].Value = ID_Catg;
            param[1] = new SqlParameter("@ID_PROD", SqlDbType.NVarChar);
            param[1].Value = ID_PROD;
            param[2] = new SqlParameter("@name", SqlDbType.NVarChar);
            param[2].Value = PROD_NAME;
            param[3] = new SqlParameter("@QTE", SqlDbType.Int);
            param[3].Value = QTE;
            param[4] = new SqlParameter("@price", SqlDbType.NVarChar);
            param[4].Value = PRICE;
            param[5] = new SqlParameter("@img", SqlDbType.Image);
            param[5].Value = IMG;
            cs.ExecuteCommand("Add_Product", param);
            cs.Close();
        }

        public void UpdateProdect(int ID_Catg, string ID_PROD, string PROD_NAME, int QTE, string PRICE, byte[] IMG)
        {
            
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@ID_Catg", SqlDbType.Int);
            param[0].Value = ID_Catg;
            param[1] = new SqlParameter("@ID_PROD", SqlDbType.NVarChar);
            param[1].Value = ID_PROD;
            param[2] = new SqlParameter("@name", SqlDbType.NVarChar);
            param[2].Value = PROD_NAME;
            param[3] = new SqlParameter("@QTE", SqlDbType.Int);
            param[3].Value = QTE;
            param[4] = new SqlParameter("@price", SqlDbType.NVarChar);
            param[4].Value = PRICE;
            param[5] = new SqlParameter("@img", SqlDbType.Image);
            param[5].Value = IMG;
            cs.Open();
            cs.ExecuteCommand("UpdateProdect", param);
            cs.Close();
        }

        public DataTable checkProductID(string id)
        {

            cs.Open();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.NVarChar ,30);
            param[0].Value = id;
            dt = cs.SelectData("checkProductID", null);
            cs.Close();

            return dt;
        }

        public void Delete_Product(string ID_Prod)
        {
            cs.Open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.NVarChar);
            param[0].Value = ID_Prod;
            
            cs.ExecuteCommand("delete_product", param);
            cs.Close();
        }

    }
}
