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
    public partial class F_AddProduct : Form
    {
        BL.C_Products prd = new BL.C_Products();
        public string state = "add";
        public F_AddProduct()
        {
            InitializeComponent();
            comboBox1.DataSource = prd.Get_All_Categories();
            comboBox1.DisplayMember = "DESCRPTION_CAT";
            comboBox1.ValueMember = "ID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter="Image File |*.jpg; *.png;";
            if(openFile.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFile.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (state == "add")
            {
                MemoryStream stream = new MemoryStream();
                pictureBox1.Image.Save(stream, pictureBox1.Image.RawFormat);
                byte[] byteimage = stream.ToArray();


                prd.Add_Product(Convert.ToInt32(comboBox1.SelectedValue), txtDes.Text,
                    txtID.Text, Convert.ToInt32(txtQun.Text), txtPrice.Text, byteimage);
                MessageBox.Show("succsfully Added", "Adding Opration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MemoryStream stream = new MemoryStream();
                pictureBox1.Image.Save(stream, pictureBox1.Image.RawFormat);
                byte[] byteimage = stream.ToArray();


                prd.UpdateProdect(Convert.ToInt32(comboBox1.SelectedValue), txtDes.Text,
                    txtID.Text, Convert.ToInt32(txtQun.Text), txtPrice.Text, byteimage);
                MessageBox.Show("succsfully Updated", "Update product", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtID_Validating(object sender, CancelEventArgs e)
        {
            //DataTable dt = new DataTable();
            ////dt = prd.checkProductID(txtID.Text);
            ////if(dt.Rows.Count>0)
            ////{
            ////    MessageBox.Show("Already Exist", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ////}
        }

        private void txtID_Validated(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //dt = prd.checkProductID(txtID.Text);
            //if (dt.Rows.Count > 0)
            //{
            //    MessageBox.Show("Already Exist", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }
    }
}
