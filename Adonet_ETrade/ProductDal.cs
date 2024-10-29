using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adonet_ETrade
{
    public class ProductDal
    {
        SqlConnection _baglan = new SqlConnection(@"Server=LAPTOP-F5PIAQHS\BOTANIKSQL;Initial Catalog=ETrade;integrated security=true");
        public DataTable GetAll()
        {
            ConnectionControl();
            SqlCommand komut = new SqlCommand("select * from Products", _baglan);
            //Listelediğimizi nereye gönderecez komutu bağlana gönder.
            //komutu yazdık şimdi EXECUTE Edeceğiz.

            SqlDataReader oku = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(oku);

            oku.Close();
            _baglan.Close();
            return dt;


        }

        public List<Product> GetAll2()
        {
            SqlConnection _baglan = new SqlConnection(@"Server=LAPTOP-F5PIAQHS\BOTANIKSQL;Initial Catalog=ETrade;integrated security=true");

            if (_baglan.State == ConnectionState.Closed)
            {

                _baglan.Open();
            }
            SqlCommand komut = new SqlCommand("select * from Products", _baglan);
            SqlDataReader rd = komut.ExecuteReader();
            List<Product> products = new List<Product>();

            while (rd.Read())
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(rd["Id"]),
                    Name = rd["Name"].ToString(),
                    UnitPrice = Convert.ToDecimal(rd["UnitPrice"]),
                    StockAmount = Convert.ToInt32(rd["StockAmount"])
                };

                products.Add(product);


            }
            _baglan.Close();
            return products;     }

        public void ConnectionControl()
        {
            if (_baglan.State == ConnectionState.Closed)
            {

                _baglan.Open();
           }

        }
        public void Add(Product product)
        {
        ConnectionControl();
            SqlCommand komut = new SqlCommand("Insert into Products values(@Name,@UnitPrice,@StockAmount)",_baglan);
            komut.Parameters.AddWithValue("@Name", product.Name);
            komut.Parameters.AddWithValue("@Unitprice", product.UnitPrice);
            komut.Parameters.AddWithValue("@StockAmount", product.StockAmount);
            komut.ExecuteNonQuery();
            _baglan.Close();

        }
        public void Update(Product product) { 
            ConnectionControl() ;
            SqlCommand komut = new SqlCommand("Update Products set Name=@name, UnitPrice=@UnitPrice , StockAmount=@StockAmount where Id=@Id",_baglan) ;
            komut.Parameters.AddWithValue("@name", product.Name);
            komut.Parameters.AddWithValue("@UnitPrice",product.UnitPrice);
            komut.Parameters.AddWithValue("@StockAmount",product.StockAmount);
            komut.Parameters.AddWithValue("@Id", product.Id);
            komut.ExecuteNonQuery();
            _baglan.Close();
        }
        public void Delete(Product product)
        {   ConnectionControl() ;
            SqlCommand komut = new SqlCommand("delete from Products where Id=@Id", _baglan);
            komut.Parameters.AddWithValue("@Id",product.Id);
            komut.ExecuteNonQuery() ;
            _baglan.Close();
        }
    }
}
