using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Inventory_Management.PL
{
    public partial class F_Main : Form
    {
        public F_Main()
        {
            InitializeComponent();
            this.productToolStripMenuItem.Enabled = false;
            this.usersToolStripMenuItem.Enabled = false;
            this.cusomersToolStripMenuItem.Enabled = false;
            this.backupDataToolStripMenuItem.Enabled = false;
            this.restoreDataToolStripMenuItem.Enabled = false;
            this.button4.Enabled = false;
            this.button3.Enabled = false;
            this.button5.Enabled = false;
            
            
           
        }

        private void F_Main_Load(object sender, EventArgs e)
        {

        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Login login = new F_Login();
            login.ShowDialog();
            this.button4.Enabled = true;
            this.button3.Enabled = true;
            this.button5.Enabled = true;
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_AddProduct f_Add = new F_AddProduct();
             f_Add.ShowDialog();
        }

        private void productManagingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_ProductsManaging managing = new F_ProductsManaging();
            managing.ShowDialog();
        }

        private void categuryManagingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_CatManaging _CatManaging = new F_CatManaging();
            _CatManaging.ShowDialog();
        }

        private void usersManagingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_AddUsers f_AddUsers = new F_AddUsers();
            f_AddUsers.ShowDialog();
        }

        private void newSellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_sale f_Sale = new F_sale();
            f_Sale.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            productManagingToolStripMenuItem.PerformClick();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            customersManagingToolStripMenuItem.PerformClick();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            newSellToolStripMenuItem.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            logInToolStripMenuItem.PerformClick();
        }

        private void customersManagingToolStripMenuItem_Click(object sender, EventArgs e)
        {

            F_Users f_Users = new F_Users();
            f_Users.ShowDialog();
        }

        private void backupDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Backup f_Backup = new F_Backup();
            f_Backup.ShowDialog();
        }
    }
}
