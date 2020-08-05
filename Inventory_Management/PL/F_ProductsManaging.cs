using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management.PL
{
    public partial class F_ProductsManaging : Form

    {
        BL.C_Products prd = new BL.C_Products();
        public F_ProductsManaging()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = prd.Get_All_Products();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = prd.search_product(textBox1.Text);
            dataGridView1.DataSource = dt;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            F_AddProduct f_ = new F_AddProduct();
            f_.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "Deleting item", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                prd.Delete_Product(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("Done", "Deleting item", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Canceld", " Deleting item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            dataGridView1.DataSource = prd.Get_All_Products();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            F_AddProduct f_ = new F_AddProduct();
            f_.txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            f_.txtDes.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            f_.txtQun.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            f_.txtPrice.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            f_.comboBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            f_.Text = "Update Prodect" + dataGridView1.CurrentRow.Cells[1].Value.ToString();
            f_.state = "update";
            byte[] image = (byte[])prd.getimage(dataGridView1.CurrentRow.Cells[0].Value.ToString()).Rows[0][0];
            MemoryStream ms = new MemoryStream(image);
            f_.pictureBox1.Image = Image.FromStream(ms);
            f_.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            F_view f_ = new F_view();
            byte[] image = (byte[])prd.getimage(dataGridView1.CurrentRow.Cells[0].Value.ToString()).Rows[0][0];
            MemoryStream ms = new MemoryStream(image);
            f_.pictureBox1.Image = Image.FromStream(ms);
            f_.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            REPORT.RPT_PRODUCT_1 rPT_ = new REPORT.RPT_PRODUCT_1();
            rPT_.SetParameterValue("@ID", this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            REPORT.F_RPT_PRODUCT rPT_PRODUCT = new REPORT.F_RPT_PRODUCT();
            rPT_PRODUCT.crystalReportViewer1.ReportSource = rPT_;
            rPT_PRODUCT.ShowDialog();
    }

        private void button6_Click(object sender, EventArgs e)
        {
            REPORT.rpt_getall_products rpt_Getall_ = new REPORT.rpt_getall_products();
            REPORT.F_RPT_PRODUCT rPT_PRODUCT = new REPORT.F_RPT_PRODUCT();
            rPT_PRODUCT.crystalReportViewer1.ReportSource = rpt_Getall_;
            rPT_PRODUCT.ShowDialog();
        }
    } }
