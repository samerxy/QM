using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Inventory_Management.DAL;
using System.Data;

namespace Inventory_Management.BL
{
    class C_Order
    {
        DataAccessLayer cs = new DataAccessLayer();
        public DataTable Get_last_Order_id()
        {

            DataTable dt = new DataTable();
            dt = cs.SelectData("get_lastorder_id", null);
            return dt;
        }
        public DataTable Get_last_Order_id_print()
        {

            DataTable dt = new DataTable();
            dt = cs.SelectData("get_lastorder_id_print", null);
            return dt;
        }
        public DataTable Getorders(int id_order)
        {
            DAL.DataAccessLayer dataAccessLayer = new DataAccessLayer();
            DataTable DT = new DataTable();
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@id_order", SqlDbType.Int);
            parameters[0].Value = id_order;
            DT = dataAccessLayer.SelectData("get_orders", parameters);
            dataAccessLayer.Close();
            return DT;
        }
        public void Add_order(int id_order, int CUSTOMER_ID, string DESCRPTION_ORDER, string SALESMAN, DateTime DATE_ORDER)
        {
            cs.Open();
            SqlParameter[] param = new SqlParameter[5];
          
            param[0] = new SqlParameter("@date", SqlDbType.DateTime);
            param[0].Value = DATE_ORDER;
            param[1] = new SqlParameter("@Order_des", SqlDbType.NVarChar);
            param[1].Value = DESCRPTION_ORDER;
            param[2] = new SqlParameter("@ID_customer", SqlDbType.Int);
            param[2].Value = CUSTOMER_ID;
            param[3] = new SqlParameter("@saller", SqlDbType.NVarChar);
            param[3].Value = SALESMAN;
            param[4] = new SqlParameter("@ID_order", SqlDbType.Int);
            param[4].Value = id_order;
            
            cs.ExecuteCommand("add_orderr ", param);
            cs.Close();
        }
        public void Add_order_details(int id_order, string ID_product,int qte,float discount, string price, string amount, string total_amount)
        {
            cs.Open();
            SqlParameter[] param = new SqlParameter[7];

            param[0] = new SqlParameter("@ID_order", SqlDbType.Int);
            param[0].Value = id_order;
            param[1] = new SqlParameter("@ID_product", SqlDbType.NVarChar);
            param[1].Value = ID_product;
            param[2] = new SqlParameter("@qte", SqlDbType.Int);
            param[2].Value = qte;
            param[3] = new SqlParameter("@price", SqlDbType.NVarChar);
            param[3].Value = price;
            param[4] = new SqlParameter("@discount", SqlDbType.Float);
            param[4].Value = discount;
            param[5] = new SqlParameter("@amount", SqlDbType.NVarChar);
            param[5].Value = price;
            param[6] = new SqlParameter("@total_amount", SqlDbType.NVarChar);
            param[6].Value = total_amount;

            cs.ExecuteCommand("add_order_details", param);
            cs.Close();
        }
    }
}
