using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneOtomasyon.Diğer_Ürünler
{
    public class DigerUrunKod
    {
        SqlConnection _connection = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB; initial catalog=EczaneOtoData;integrated security=true");
        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
        public List<DigerUrun> GetAll()
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from IlacDisiUrun", _connection);

            SqlDataReader reader = command.ExecuteReader();
            List<DigerUrun> digerUrunler = new List<DigerUrun>();
            while (reader.Read())
            {
                DigerUrun digerUrun = new DigerUrun
                {
                    DisId = Convert.ToInt32(reader["DisId"]),
                    KategoriId = Convert.ToInt32(reader["KategoriId"]),
                    Ad =reader["Ad"].ToString(),
                    Firma=reader["Firma"].ToString(),
                    Fiyat= Convert.ToDecimal(reader["Fiyat"]),
                    BarkodNo=reader["BarkodNo"].ToString(),
                    Stok= Convert.ToInt32(reader["Stok"])
                };
                digerUrunler.Add(digerUrun);
            }
            reader.Close();
            _connection.Close();
            return digerUrunler;
        }
        public List<DigerUrun> Search(string key)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from IlacDisiUrun where Ad like '%" + key + "%'", _connection);

            SqlDataReader reader = command.ExecuteReader();
            List<DigerUrun> digerUrunler = new List<DigerUrun>();
            while (reader.Read())
            {
                DigerUrun digerUrun = new DigerUrun
                {
                    DisId = Convert.ToInt32(reader["DisId"]),
                    KategoriId = Convert.ToInt32(reader["KategoriId"]),
                    Ad = reader["Ad"].ToString(),
                    Firma = reader["Firma"].ToString(),
                    Fiyat = Convert.ToDecimal(reader["Fiyat"]),
                    BarkodNo = reader["BarkodNo"].ToString(),
                    Stok = Convert.ToInt32(reader["Stok"])
                };
                digerUrunler.Add(digerUrun);
            }
            reader.Close();
            _connection.Close();
            return digerUrunler;
        }
        public List<DigerUrun> KategoriIleUrunGetir(int id) {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from IlacDisiUrun where KategoriId like '%" + id + "%'", _connection);

            SqlDataReader reader = command.ExecuteReader();
            List<DigerUrun> digerUrunler = new List<DigerUrun>();
            while (reader.Read())
            {
                DigerUrun digerUrun = new DigerUrun
                {
                    DisId = Convert.ToInt32(reader["DisId"]),
                    KategoriId= Convert.ToInt32(reader["KategoriId"]),
                    Ad = reader["Ad"].ToString(),
                    Firma = reader["Firma"].ToString(),
                    Fiyat = Convert.ToDecimal(reader["Fiyat"]),
                    BarkodNo = reader["BarkodNo"].ToString(),
                    Stok = Convert.ToInt32(reader["Stok"])
                };
                digerUrunler.Add(digerUrun);
            }
            reader.Close();
            _connection.Close();
            return digerUrunler;
        }
        public void Add(DigerUrun digerUrun)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("insert into IlacDisiUrun values (@KategoriId ,@Ad,@Firma,@Fiyat,@BarkodNo, @Stok)", _connection);
            command.Parameters.AddWithValue("@KategoriId", digerUrun.KategoriId);
            command.Parameters.AddWithValue("@Ad" , digerUrun.Ad );
            command.Parameters.AddWithValue("@Firma",digerUrun.Firma );
            command.Parameters.AddWithValue("@Fiyat", digerUrun.Fiyat );
            command.Parameters.AddWithValue("@BarkodNo",digerUrun.BarkodNo);
            command.Parameters.AddWithValue("@Stok", digerUrun.Stok);

            command.ExecuteNonQuery();

            _connection.Close();

        }
        public void Update(DigerUrun digerUrun)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Update IlacDisiUrun set KategoriId=@KategoriId, Ad=@Ad, Firma=@Firma, Fiyat=@Fiyat, BarkodNo=@BarkodNo , Stok=@Stok  where DisId=@DisId ", _connection);
            command.Parameters.AddWithValue("@KategoriId", digerUrun.KategoriId);
            command.Parameters.AddWithValue("@Ad", digerUrun.Ad);
            command.Parameters.AddWithValue("@Firma", digerUrun.Firma);
            command.Parameters.AddWithValue("@Fiyat", digerUrun.Fiyat);
            command.Parameters.AddWithValue("@BarkodNo", digerUrun.BarkodNo);
            command.Parameters.AddWithValue("@DisId", digerUrun.DisId);
            command.Parameters.AddWithValue("@Stok", digerUrun.Stok);

            command.ExecuteNonQuery();

            _connection.Close();

        }
        public void Delete(int id)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Delete from IlacDisiUrun where  DisId=@DisId", _connection);

            command.Parameters.AddWithValue("@DisId", id);
            command.ExecuteNonQuery();

            _connection.Close();

        }
    }
}
