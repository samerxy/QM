using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management.PL
{
    public partial class F_view : Form
    {
        public F_view()
        {
            InitializeComponent();
        }

        private void btnCnl_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
