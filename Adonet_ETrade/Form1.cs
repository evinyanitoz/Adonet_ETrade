using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adonet_ETrade
{
    public partial class PRODUCT : Form
    {
        public PRODUCT()
        {
            InitializeComponent();
        }
        ProductDal _productDal = new ProductDal();
        Product _product = new Product();
        private void Form1_Load(object sender, EventArgs e)
        {         
           //aoutosizecolumn-u  FİLL seçelimki doldursun.
            //Kuruumsal projelerde Datatable kullanılmaz.Bu nedenle biz Listelerle çalışacağız.
            //eventi form designerdanda silmek gerekir.

            this.BackColor=Color.Teal;
            GetProduct();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                Name = txtName.Text,
                UnitPrice = Convert.ToDecimal(txtFiyat.Text),
                StockAmount = Convert.ToInt32(txtAdet.Text)
            };

            _productDal.Add(product);
            MessageBox.Show("ÜRÜN BAŞARIYLA EKLENDİ");
            GetProduct();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetProduct();
            MessageBox.Show("LİSTE YENİLENDİ");


        }
        private void GetProduct() {
            dgwProducts.DataSource = _productDal.GetAll2();
            dgwProducts.Columns[0].Visible = false;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product
            {
                Name = tbxNameUpdate.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text),
                Id=Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)
            });
            MessageBox.Show("ÜRÜN GÜNCELLENDİ !!");
            tbxNameUpdate.Text = "";
            tbxStockAmountUpdate.Text = "";
            tbxUnitPriceUpdate.Text = "";
            GetProduct();

        }


        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text=dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text= dgwProducts.CurrentRow.Cells[3].Value.ToString();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)
            });
            MessageBox.Show("ÜRÜN SİLİNDİ !!");
            GetProduct();
        }
    }
}
