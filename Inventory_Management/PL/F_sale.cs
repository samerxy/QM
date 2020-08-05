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
    public partial class F_sale : Form
    {
        BL.C_Order _Order = new BL.C_Order();
        DataTable dt = new DataTable();
        void Calculateamount()
        {
            if (textBoxprice.Text != string.Empty && textBoxqte.Text != string.Empty)
            
                
                textBoxamount.Text = (Convert.ToDouble(textBoxprice.Text) * Convert.ToInt32(textBoxqte.Text)).ToString();
            
        }
        void totalcost()
        {
            if (textBoxdis.Text != string.Empty && textBoxamount.Text!=string.Empty)
            {
                double discount = Convert.ToDouble(textBoxdis.Text);
                double amount = Convert.ToDouble(textBoxamount.Text);
                double total = amount - (amount * (discount / 100));
                textBoxcost.Text = total.ToString();
            }
        }
        void clearbox()
        {
             txtidpro.Clear();
           textBoxname.Clear();
           textBoxprice.Clear();
            textBoxqte.Clear();
            textBoxamount.Clear();
             textBoxdis.Clear();
             textBoxcost.Clear();
            button2.Focus();
        }
        void CreateDataTable()
        {
            dt.Columns.Add("ID");
            dt.Columns.Add("produt name");
            dt.Columns.Add("price");
            dt.Columns.Add("QTE");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Discount(%)");
            dt.Columns.Add("Total cost");
            dataGridView1.DataSource = dt;
            //DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            //btn.HeaderText = "select";
            //btn.Text = "search";
            //btn.UseColumnTextForButtonValue = true;
            //dataGridView1.Columns.Insert(0, btn);
        }
        public F_sale()
        {
            InitializeComponent();
            CreateDataTable();
            txtsaller.Text = Program.salesman.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.txtorid.Text = _Order.Get_last_Order_id().Rows[0][0].ToString();
        }

        private void btnser_Click(object sender, EventArgs e)
        {
            F_allcus _Allcus = new F_allcus();
            _Allcus.ShowDialog();
            this.txtcusid.Text = _Allcus.dvc.CurrentRow.Cells[0].Value.ToString();
            this.txtfname.Text = _Allcus.dvc.CurrentRow.Cells[1].Value.ToString();
            this.txtlname.Text = _Allcus.dvc.CurrentRow.Cells[2].Value.ToString();
            this.txtph.Text = _Allcus.dvc.CurrentRow.Cells[3].Value.ToString();
            this.txtemail.Text = _Allcus.dvc.CurrentRow.Cells[4].Value.ToString();
            
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearbox();

               F_prodview f_Prodview = new F_prodview();
            f_Prodview.ShowDialog();
            txtidpro.Text = f_Prodview.dvp.CurrentRow.Cells[0].Value.ToString();
            textBoxname.Text = f_Prodview.dvp.CurrentRow.Cells[1].Value.ToString();
            textBoxprice.Text = f_Prodview.dvp.CurrentRow.Cells[3].Value.ToString();
            textBoxqte.Focus();
        }

        private void textBoxqte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar)&& e.KeyChar!=8)
            {
                e.Handled = true;
            }
        }

        private void textBoxprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar( System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void textBoxprice_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter && textBoxprice.Text!=string.Empty)
            {
                textBoxqte.Focus();
            }
        }

        private void textBoxqte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textBoxqte.Text != string.Empty)
            {
                textBoxqte.Focus();
            }
        }

        private void textBoxprice_KeyUp(object sender, KeyEventArgs e)
        {
            Calculateamount();
            totalcost();
        }

        private void textBoxqte_KeyUp(object sender, KeyEventArgs e)
        {
            Calculateamount();
            totalcost();
        }

        private void textBoxdis_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBoxdis_KeyUp(object sender, KeyEventArgs e)
        {
            totalcost();
        }

        private void textBoxdis_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _Order.Add_order(Convert.ToInt32(txtorid.Text),Convert.ToInt32(txtcusid.Text),txtdesor.Text,txtsaller.Text,dateTimePicker1.Value);

            //for(int i =0; i<dataGridView1.Rows.Count - 1; i++)
            //{
            //    _Order.Add_order_details(Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString()),
            //        txtorid.Text,
            //       Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value),
            //       Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value),
            //       Convert.ToString(dataGridView1.Rows[i].Cells[5].Value),
            //        dataGridView1.Rows[i].Cells[4].Value.ToString(),
            //        dataGridView1.Rows[i].Cells[6].Value.ToString()
            //     );
            //}
            MessageBox.Show("succsfully Added", "Adding Opration", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBoxdis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                for(int i = 0; i<dataGridView1.Rows.Count - 1;i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == txtidpro.Text)
                    {
                        MessageBox.Show("product exist", "alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                    }
                }
                DataRow dr = dt.NewRow();
                dr[0] = txtidpro.Text;
                dr[1] = textBoxname.Text;
                dr[2] = textBoxprice.Text;
                dr[3] = textBoxqte.Text;
                dr[4] = textBoxamount.Text;
                dr[5] = textBoxdis.Text;
                dr[6] = textBoxcost.Text;

                dt.Rows.Add(dr);
                dataGridView1.DataSource = dt;
                clearbox();
                texttoalprice.Text = (from DataGridViewRow row in dataGridView1.Rows
                                      where row.Cells[6].FormattedValue.ToString() != string.Empty
                                      select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtidpro.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBoxname.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBoxprice.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBoxqte.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBoxamount.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBoxdis.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBoxcost.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                textBoxqte.Focus();
            }
            catch
            {
                return;
            }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            texttoalprice.Text = (from DataGridViewRow row in dataGridView1.Rows
                                  where row.Cells[6].FormattedValue.ToString() != string.Empty
                                  select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int orderid = Convert.ToInt32(_Order.Get_last_Order_id_print().Rows[0][0]);
            REPORT.bill bill = new REPORT.bill();
            REPORT.F_RPT_PRODUCT f_RPT_PRODUCT = new REPORT.F_RPT_PRODUCT();
            bill.SetDataSource(_Order.Getorders(orderid));
            f_RPT_PRODUCT.crystalReportViewer1.ReportSource = bill;
            f_RPT_PRODUCT.ShowDialog();
            this.Cursor = Cursors.Default;
        }
    }
}
