using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneOtomasyon.Hasta_Bilgi
{
   public class YeniHastaKod
    {
        SqlConnection _connection = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB; initial catalog=EczaneOtoData;integrated security=true");
        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
        public List<Hasta> GetAll()
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from Hasta", _connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Hasta> hastalar = new List<Hasta>();
            while (reader.Read())
            {
                Hasta hasta = new Hasta
                {
                    HastaId = Convert.ToInt32(reader["HastaId"]),
                    HastaAd = reader["HastaAd"].ToString(),
                    HastaSoyad = reader["HastaSoyad"].ToString(),
                    Tc = reader["Tc"].ToString(),
                    Cinsiyet = reader["Cinsiyet"].ToString(),
                    HastaDogum = Convert.ToDateTime(reader["HastaDogum"]),
                    Telefon = reader["Telefon"].ToString(),
                    Hastaliklar = reader["Hastaliklar"].ToString(),
                    RaporluIlac = reader["RaporluIlac"].ToString(),
                    Adres = reader["Adres"].ToString(),
                    SaglikGuvence = reader["SaglikGuvence"].ToString(),
                    Alerji = reader["Alerji"].ToString(),
                };
                hastalar.Add(hasta);
            }
            reader.Close();
            _connection.Close();
            return hastalar;
        }
        public List<Hasta> Search(string key)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from Hasta where HastaAd like '%" + key + "%'", _connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Hasta> hastalar = new List<Hasta>();
            while (reader.Read())
            {
                Hasta hasta = new Hasta
                {
                    HastaId = Convert.ToInt32(reader["HastaId"]),
                    HastaAd = reader["HastaAd"].ToString(),
                    HastaSoyad = reader["HastaSoyad"].ToString(),
                    Tc = reader["Tc"].ToString(),
                    Cinsiyet = reader["Cinsiyet"].ToString(),
                    HastaDogum = Convert.ToDateTime(reader["HastaDogum"]),
                    Telefon = reader["Telefon"].ToString(),
                    Hastaliklar = reader["Hastaliklar"].ToString(),
                    RaporluIlac = reader["RaporluIlac"].ToString(),
                    Adres = reader["Adres"].ToString(),
                    SaglikGuvence = reader["SaglikGuvence"].ToString(),
                    Alerji = reader["Alerji"].ToString(),
                };
                hastalar.Add(hasta);
            }
            reader.Close();
            _connection.Close();
            return hastalar;
        }
        public void Add(Hasta hasta)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("insert into Hasta values(@HastaAd,@HastaSoyad,@Tc,@Cinsiyet,@HastaDogum,@Telefon,@Hastaliklar ,@RaporluIlac , @Adres, @SaglikGuvence, @Alerji )", _connection);
            command.Parameters.AddWithValue("@HastaAd", hasta.HastaAd);
            command.Parameters.AddWithValue("@HastaSoyad", hasta.HastaSoyad);
            command.Parameters.AddWithValue("@Tc", hasta.Tc);
            command.Parameters.AddWithValue("@Cinsiyet", hasta.Cinsiyet);
            command.Parameters.AddWithValue("@HastaDogum", hasta.HastaDogum);
            command.Parameters.AddWithValue("@Telefon", hasta.Telefon);
            command.Parameters.AddWithValue("@Hastaliklar", hasta.Hastaliklar);
            command.Parameters.AddWithValue("@RaporluIlac", hasta.RaporluIlac);
            command.Parameters.AddWithValue("@Adres", hasta.Adres);
            command.Parameters.AddWithValue("@SaglikGuvence", hasta.SaglikGuvence);
            command.Parameters.AddWithValue("@Alerji", hasta.Alerji);
           
            command.ExecuteNonQuery();

            _connection.Close();

        }
        public void Update(Hasta hasta)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Update Hasta set HastaAd=@HastaAd, HastaSoyad=@HastaSoyad , Tc=@Tc, Cinsiyet=@Cinsiyet , HastaDogum=@HastaDogum , Telefon=@Telefon , Hastaliklar=@Hastaliklar ,RaporluIlac=@RaporluIlac ,Adres=@Adres, SaglikGuvence=@SaglikGuvence, Alerji=@Alerji where HastaId=@HastaId ", _connection);
            command.Parameters.AddWithValue("@HastaAd", hasta.HastaAd);
            command.Parameters.AddWithValue("@HastaSoyad", hasta.HastaSoyad);
            command.Parameters.AddWithValue("@Tc", hasta.Tc);
            command.Parameters.AddWithValue("@Cinsiyet", hasta.Cinsiyet);
            command.Parameters.AddWithValue("@HastaDogum", hasta.HastaDogum);
            command.Parameters.AddWithValue("@Telefon", hasta.Telefon);
            command.Parameters.AddWithValue("@Hastaliklar", hasta.Hastaliklar);
            command.Parameters.AddWithValue("@RaporluIlac", hasta.RaporluIlac);
            command.Parameters.AddWithValue("@Adres", hasta.Adres);
            command.Parameters.AddWithValue("@SaglikGuvence", hasta.SaglikGuvence);
            command.Parameters.AddWithValue("@Alerji", hasta.Alerji);
            command.Parameters.AddWithValue("@HastaId", hasta.HastaId);



            command.ExecuteNonQuery();

            _connection.Close();

        } public void Delete(int id)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Delete from Hasta where HastaId=@HastaId ", _connection);

            command.Parameters.AddWithValue("@HastaId", id);
            command.ExecuteNonQuery();

            _connection.Close();

        }
       

    }
}
