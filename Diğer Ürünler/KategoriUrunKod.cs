using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneOtomasyon.Diğer_Ürünler
{
    public class KategoriUrunKod
    {


        SqlConnection _connection = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB; initial catalog=EczaneOtoData;integrated security=true");
        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
        public List<KategoriUrun2> GetAll()
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from KategoriUrun", _connection);

            SqlDataReader reader = command.ExecuteReader();
            List<KategoriUrun2> kategoriUrunler = new List<KategoriUrun2>();
            while (reader.Read())
            {
                KategoriUrun2 kategoriUrun = new KategoriUrun2
                {
                    UrunKategoriAd = reader["UrunKategoriAd"].ToString(),
                    UrunKategoriId = Convert.ToInt32(reader["UrunKategoriId"])

                };
                kategoriUrunler.Add(kategoriUrun);
            }
            reader.Close();
            _connection.Close();
            return kategoriUrunler;
        }

        public void Add(KategoriUrun2 kategoriUrun)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("insert into KategoriUrun values (@UrunKategoriAd)", _connection);
            command.Parameters.AddWithValue("UrunKategoriAd", kategoriUrun.UrunKategoriAd);
            command.ExecuteNonQuery();
            _connection.Close();

        }
        public void Update(KategoriUrun2 kategoriUrun)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Update KategoriUrun set UrunKategoriAd=@UrunKategoriAd where UrunKategoriId=@UrunKategoriId", _connection);
            command.Parameters.AddWithValue("UrunKategoriId", kategoriUrun.UrunKategoriId);
            command.Parameters.AddWithValue("UrunKategoriAd", kategoriUrun.UrunKategoriAd);
            command.ExecuteNonQuery();

            _connection.Close();

        }
        public void Delete(int id)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Delete from KategoriUrun where  UrunKategoriId=@UrunKategoriId", _connection);

            command.Parameters.AddWithValue("UrunKategoriId", id);
            command.ExecuteNonQuery();

            _connection.Close();

        }
    }
}




