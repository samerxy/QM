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
    public partial class F_AddUsers : Form
    {
        BL.C_Login lg = new BL.C_Login();
        public F_AddUsers()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==string.Empty||textBox2.Text==string.Empty||textBox3.Text==string.Empty||textBox4.Text==string.Empty)
            {
                MessageBox.Show("please fill the blanks", "Adding Opration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("password not the same", "Adding Opration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lg.Add_User(textBox1.Text,textBox2.Text,textBox3.Text,comboBox1.Text);
            MessageBox.Show("succsfully Added", "Adding Opration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox1.Focus();
        }

        private void btnCnl_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox4_Validated(object sender, EventArgs e)
        {
            if(textBox3.Text!=textBox4.Text)
            {
                MessageBox.Show("password not the same", "Adding Opration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
