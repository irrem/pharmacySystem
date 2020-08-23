using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneOtomasyon.Hastane
{
    class AnlasmaliHastaneMetotlar
    {
        public int hastaneId { get; set; }
        public string hastaneAd { get; set; }

        public string hastaneAdres { get; set; }
        public string telefonHastane { get; set; }

        SqlConnection baglanti = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB; initial catalog=EczaneOtoData;integrated security=true");

        public void baglan()
        {

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();

            }

        }
        public List<AnlasmaliHastaneMetotlar> GetirHastaneler()
        {
            baglan();
            SqlCommand komut = new SqlCommand("Select * From Hastane", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            List<AnlasmaliHastaneMetotlar> hastaneListe = new List<AnlasmaliHastaneMetotlar>();
            while (oku.Read())
            {

                AnlasmaliHastaneMetotlar hastaneler_ = new AnlasmaliHastaneMetotlar();
                hastaneler_.hastaneId = Convert.ToInt32(oku["HastaneId"]);
                hastaneler_.hastaneAd = oku["HastaneAd"].ToString();
                hastaneler_.hastaneAdres = oku["Adres"].ToString();
                hastaneler_.telefonHastane = oku["Telefon"].ToString();


                hastaneListe.Add(hastaneler_);

            }

            oku.Close();
            baglanti.Close();
            return hastaneListe;
        }
        public void KaydetHastane(AnlasmaliHastaneMetotlar _hstne)
        { 
            baglan();
            SqlCommand komut = new SqlCommand("Insert into Hastane (HastaneAd,Adres,Telefon) values(@hastaneAd,@hastaneAdres,@telefonHastane)", baglanti);
            komut.Parameters.AddWithValue("@hastaneAd", _hstne.hastaneAd);
            komut.Parameters.AddWithValue("@hastaneAdres", _hstne.hastaneAdres);
            komut.Parameters.AddWithValue("@telefonHastane", _hstne.telefonHastane);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public void SilHastane(int hstnId)
        {
            baglan();
            SqlCommand silKomut = new SqlCommand("Delete from Hastane where HastaneId=@hstnId", baglanti);
            silKomut.Parameters.AddWithValue("@hstnId", hstnId);
            silKomut.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
