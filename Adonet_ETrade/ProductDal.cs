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

        public DataTable GetAll()
        {
            SqlConnection baglan = new SqlConnection(@"Server=LAPTOP-F5PIAQHS\BOTANIKSQL;Initial Catalog=ETrade;integrated security=true");
           
            if (baglan.State ==ConnectionState.Closed)
            {
                
                baglan.Open();
            }
            SqlCommand komut = new SqlCommand("select * from Products",baglan);
            //Listelediğimizi nereye gönderecez komutu bağlana gönder.
            //komutu yazdık şimdi EXECUTE Edeceğiz.

            SqlDataReader oku = komut.ExecuteReader(); 
            DataTable dt=new DataTable();
            dt.Load(oku);
            oku.Close();
            baglan.Close();
            return dt;

                    
        }

    }
}
