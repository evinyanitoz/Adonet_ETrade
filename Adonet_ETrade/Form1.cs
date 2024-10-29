using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adonet_ETrade
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ProductDal product= new ProductDal();
            //dgwProducts.DataSource = product.GetAll();
            //dgwProducts.Columns[0].Visible = false;

            //aoutosizecolumn-u  FİLL seçelimki doldursun.
            //Kuruumsal projelerde Datatable kullanılmaz.Bu nedenle biz Listelerle çalışacağız.
         this.BackColor=Color.Teal;


            ProductDal productDal = new ProductDal();
            dgwProducts.DataSource = productDal.GetAll2();
         

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                Name = txtName.Text,
                UnitPrice = Convert.ToDecimal(txtFiyat.Text),
                StockAmount = Convert.ToInt32(txtAdet.Text)


            };

            ProductDal productDal=new ProductDal();
            productDal.Add(product);
            MessageBox.Show("ÜRÜN BAŞARIYLA EKLENDİ");
            dgwProducts.DataSource = productDal.GetAll2();

        }
    }
}
