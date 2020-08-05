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
    public partial class F_Users : Form
    {
        BL.C_Products prd = new BL.C_Products();
        SqlConnection SqlConnection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=QM;Integrated Security=true");
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        BindingManagerBase bmb;
        SqlCommandBuilder builder;
        public F_Users()

        {
            InitializeComponent();
            
            da = new SqlDataAdapter("select ID_CUSTOMER as 'ID', FIRST_NAMR as 'First name',LAST_NAME as 'Last name',TEL,EMAIL from CUSTOMERS", SqlConnection);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            textBox1.DataBindings.Add("text", dt, "First name");
            textBox2.DataBindings.Add("text", dt, "Last name");
            textBox3.DataBindings.Add("text", dt, "TEL");
            textBox4.DataBindings.Add("text", dt, "EMAIL");
            textBox6.DataBindings.Add("text", dt, "ID");

            bmb = this.BindingContext[dt];
            countlbl.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bmb.AddNew();
            btnedit.Enabled = true;
            btnOK.Enabled = false;

            textBox1.Focus();
            textBox2.Focus();
            textBox3.Focus();
            textBox4.Focus();
            textBox6.Focus();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            bmb.EndCurrentEdit();
            builder = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("succsfully Added", "Adding Opration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnedit.Enabled = false;
            btnOK.Enabled = true;
            countlbl.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            bmb.RemoveAt(bmb.Position);
            bmb.EndCurrentEdit();
            builder = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("succsfully ", "Deleting Opration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            countlbl.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void btnset_Click(object sender, EventArgs e)
        {
            bmb.EndCurrentEdit();
            builder = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("succsfully ", "Editting Opration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            countlbl.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bmb.Position = 0;
            countlbl.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bmb.Position -= 1;
            countlbl.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bmb.Position += 1;
            countlbl.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bmb.Position = bmb.Count;
            countlbl.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void btnser_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = prd.search_cos(textBox5.Text);
            dataGridView1.DataSource = dt;
        }
    }
}
