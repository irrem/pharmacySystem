using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneOtomasyon.Personel_bilgileri
{
    public class PersonelBilgiKod
    {
        SqlConnection _connection = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB; initial catalog=EczaneOtoData;integrated security=true");
        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
    public List<PersonelBilgi> GetAll()
        {
            ConnectionControl();          
            SqlCommand command = new SqlCommand("Select * from Personel", _connection);

            SqlDataReader reader = command.ExecuteReader();
            List<PersonelBilgi> personelBilgiler = new List<PersonelBilgi>();
            while (reader.Read())
            {
                PersonelBilgi personelBilgi = new PersonelBilgi
                {
                    PersonelId = Convert.ToInt32(reader["PersonelId"]),
                    PersonelAd = reader["PersonelAd"].ToString(),
                    PersonelSoyad = reader["PersonelSoyad"].ToString(),
                    PersonelTarih= Convert.ToDateTime(reader["PersonelTarih"]),
                    OkuduguYer= reader["OkuduguYer"].ToString(),
                    MezunYil= Convert.ToInt32(reader["MezunYil"]),
                    YasadıgıYer= reader["YasadıgıYer"].ToString(),
                    Ozgecmis= reader["Ozgecmis"].ToString(),
                    NotOrt = reader["NotOrt"].ToString(),
                    Tc = reader["Tc"].ToString(),
                    Sifre= reader["Sifre"].ToString(),
                };
                personelBilgiler.Add(personelBilgi);
            }  
            reader.Close();
            _connection.Close();
            return personelBilgiler;           
        }
        public List<PersonelBilgi> Search(string key )
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from Personel where PersonelAd like '%" + key + "%'" , _connection);

            SqlDataReader reader = command.ExecuteReader();
            List<PersonelBilgi> personelBilgiler = new List<PersonelBilgi>();
            while (reader.Read())
            {
                PersonelBilgi personelBilgi = new PersonelBilgi
                {
                    PersonelId = Convert.ToInt32(reader["PersonelId"]),
                    PersonelAd = reader["PersonelAd"].ToString(),
                    PersonelSoyad = reader["PersonelSoyad"].ToString(),
                    PersonelTarih = Convert.ToDateTime(reader["PersonelTarih"]),
                    OkuduguYer = reader["OkuduguYer"].ToString(),
                    MezunYil = Convert.ToInt32(reader["MezunYil"]),
                    YasadıgıYer = reader["YasadıgıYer"].ToString(),
                    Ozgecmis = reader["Ozgecmis"].ToString(),
                    NotOrt = reader["NotOrt"].ToString(),
                    Tc = reader["Tc"].ToString(),
                    Sifre = reader["Sifre"].ToString(),
                };
                personelBilgiler.Add(personelBilgi);
            }
            reader.Close();
            _connection.Close();
            return personelBilgiler;
        }
        public void Add(PersonelBilgi personelBilgi)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("insert into Personel values(@PersonelAd,@PersonelSoyad,@PersonelTarih,@OkuduguYer,@MezunYil,@YasadıgıYer,@Ozgecmis ,@NotOrt , @Tc , @Sifre)", _connection);
            command.Parameters.AddWithValue("@PersonelAd", personelBilgi.PersonelAd);
            command.Parameters.AddWithValue("@PersonelSoyad", personelBilgi.PersonelSoyad);
            command.Parameters.AddWithValue("@PersonelTarih", personelBilgi.PersonelTarih);
            command.Parameters.AddWithValue("@OkuduguYer", personelBilgi.OkuduguYer);
            command.Parameters.AddWithValue("@MezunYil",personelBilgi.MezunYil);
            command.Parameters.AddWithValue("@YasadıgıYer",personelBilgi.YasadıgıYer);
            command.Parameters.AddWithValue("@Ozgecmis",personelBilgi.Ozgecmis);
            command.Parameters.AddWithValue("@NotOrt", personelBilgi.NotOrt);
            command.Parameters.AddWithValue("@Tc", personelBilgi.Tc);
            command.Parameters.AddWithValue("@Sifre", personelBilgi.Sifre);
            command.ExecuteNonQuery();

            _connection.Close();
            
        }
        public void Update(PersonelBilgi personelBilgi)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Update Personel set PersonelAd=@PersonelAd, PersonelSoyad=@PersonelSoyad, PersonelTarih=@PersonelTarih, OkuduguYer=@OkuduguYer, MezunYil=@MezunYil, YasadıgıYer=@YasadıgıYer, Ozgecmis=@Ozgecmis, NotOrt=@NotOrt , Tc=@Tc ,Sifre=@Sifre where PersonelId=@PersonelId", _connection);
            command.Parameters.AddWithValue("@PersonelAd", personelBilgi.PersonelAd);
            command.Parameters.AddWithValue("@PersonelSoyad", personelBilgi.PersonelSoyad);
            command.Parameters.AddWithValue("@PersonelTarih", personelBilgi.PersonelTarih);
            command.Parameters.AddWithValue("@OkuduguYer", personelBilgi.OkuduguYer);
            command.Parameters.AddWithValue("@MezunYil", personelBilgi.MezunYil);
            command.Parameters.AddWithValue("@YasadıgıYer", personelBilgi.YasadıgıYer);
            command.Parameters.AddWithValue("@Ozgecmis", personelBilgi.Ozgecmis);
            command.Parameters.AddWithValue("@PersonelId", personelBilgi.PersonelId);
            command.Parameters.AddWithValue("@NotOrt", personelBilgi.NotOrt);
            command.Parameters.AddWithValue("@Tc", personelBilgi.Tc);
            command.Parameters.AddWithValue("@Sifre", personelBilgi.Sifre);
            command.ExecuteNonQuery();

            _connection.Close();

        }
        public void Delete(int id)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Delete from Personel where PersonelId=@PersonelId", _connection);
            
            command.Parameters.AddWithValue("@PersonelId", id);
            command.ExecuteNonQuery();

            _connection.Close();

        }


    }
}
