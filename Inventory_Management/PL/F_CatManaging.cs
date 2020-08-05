using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Inventory_Management.PL
{
    public partial class F_CatManaging : Form
    {
        SqlConnection SqlConnection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=QM;Integrated Security=true");
        SqlDataAdapter da;
        DataTable dt=new DataTable();
        BindingManagerBase bmb;
        SqlCommandBuilder builder;
        public F_CatManaging()
        {
            
            InitializeComponent();
            da = new SqlDataAdapter("select ID,DESCRPTION_CAT as 'Category' from CATEGORIES", SqlConnection);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            txtID.DataBindings.Add("text", dt, "ID");
            txtDes.DataBindings.Add("text", dt, "Category");
            bmb = this.BindingContext[dt];
            label3.Text = (bmb.Position+1) + " / " + bmb.Count;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bmb.Position  -= 1;
            label3.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bmb.Position = bmb.Count;
            label3.Text = (bmb.Position + 1) + " / " + bmb.Count;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bmb.Position = 0;
            label3.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bmb.Position += 1;
            label3.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bmb.AddNew();
            btnedit.Enabled = true;
            btnOK.Enabled = false;
            int id = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0])+1;
            txtID.Text = id.ToString();
            txtDes.Focus();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            bmb.EndCurrentEdit();
            builder = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("succsfully Added", "Adding Opration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnedit.Enabled = false;
            btnOK.Enabled = true;
            label3.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            bmb.RemoveAt(bmb.Position);
            bmb.EndCurrentEdit();
            builder = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("succsfully ", "Deleting Opration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            label3.Text = (bmb.Position + 1) + " / " + bmb.Count;

        }

        private void btnset_Click(object sender, EventArgs e)
        {
            bmb.EndCurrentEdit();
            builder = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("succsfully ", "Editting Opration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            label3.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            REPORT.rpt_cat_single rpt_Getall_ = new REPORT.rpt_cat_single();
            REPORT.F_RPT_PRODUCT rPT_PRODUCT = new REPORT.F_RPT_PRODUCT();
            rpt_Getall_.SetParameterValue("@ID", Convert.ToInt32(txtID.Text));
          
            rPT_PRODUCT.crystalReportViewer1.ReportSource = rpt_Getall_;
            rPT_PRODUCT.ShowDialog();
        }
    }
}
