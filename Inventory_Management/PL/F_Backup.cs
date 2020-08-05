using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management.PL
{
    public partial class F_Backup : Form
    {
        SqlConnection SqlConnection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=QM;Integrated Security=true");
        SqlCommand cmd = new SqlCommand();
        public F_Backup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnCnl_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string fileName = textBox1.Text + "\\QM"+DateTime.Now.ToShortDateString().Replace('/','-')+" - "+DateTime.Now.ToLongTimeString().Replace(':','-');
            string str = "Backup Database QM to Disk='" + fileName+".bak'";
            cmd = new SqlCommand(str, SqlConnection);
            SqlConnection.Open();
            cmd.ExecuteNonQuery();
            SqlConnection.Close();
            MessageBox.Show("done");

        }
    }
}
