using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management.PL
{
    public partial class F_allcus : Form
    {
        SqlConnection SqlConnection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=QM;Integrated Security=true");
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        BindingManagerBase bmb;
        SqlCommandBuilder builder;
        public F_allcus()
        {
            InitializeComponent();
            da = new SqlDataAdapter("select ID_CUSTOMER as 'ID', FIRST_NAMR as 'First name',LAST_NAME as 'Last name',TEL,EMAIL from CUSTOMERS", SqlConnection);
            da.Fill(dt);
            dvc.DataSource = dt;
        }

        private void dvc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dvc_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
