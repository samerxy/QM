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
    public partial class F_Login : Form
    {
        BL.C_Login log = new BL.C_Login();
        F_Main main = new F_Main();
        public F_Login()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
            DataTable dt = log.login(textBox1.Text, textBox2.Text);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][2].ToString() == "Admin")
                {
                    F_Main main = Application.OpenForms["F_Main"] as F_Main;
                    main.cusomersToolStripMenuItem.Enabled = true;
                    main.productToolStripMenuItem.Enabled = true;
                main.backupDataToolStripMenuItem.Enabled = true;
                    main.usersToolStripMenuItem.Enabled = true;
                    Program.salesman = dt.Rows[0]["FullName"].ToString();
                   
                    Close();
                }
                else if (dt.Rows[0][2].ToString() == "User")
                {
                    F_Main main = Application.OpenForms["F_Main"] as F_Main;
                    main.cusomersToolStripMenuItem.Enabled = true;
                    main.productToolStripMenuItem.Enabled = true;
                    main.usersToolStripMenuItem.Enabled = false;
                    Program.salesman = dt.Rows[0]["FullName"].ToString();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Username or password is wrong");
            }
           
            

        }
    }
}
