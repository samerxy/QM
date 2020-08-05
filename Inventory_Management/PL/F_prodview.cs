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
    public partial class F_prodview : Form
    {
        BL.C_Products C_Products = new BL.C_Products();
        public F_prodview()
        {
            InitializeComponent();
          
            dvp.DataSource = C_Products.Get_All_Products();
        }

        private void dvp_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
