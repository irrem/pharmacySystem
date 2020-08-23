using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczaneOtomasyon.Metot
{
    public class Ilac
    {
        public int ilacId { get; set; }
        public string ilacAd  { get; set; }
    
        public string ReceteDurum { get; set; }
        public string ReceteKod { get; set; }
        public string kategoriAd { get; set; }
        public string firma { get; set; }
        public string DevletDestek { get; set; }
        public int Fiyat { get; set; }
        public int inFiyat { get; set; }
        public int stok { get; set; }
        public int gram { get; set; }

        SqlConnection baglanti = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB; initial catalog=EczaneOtoData;integrated security=true");

        public void baglan()
        {
            

            if (baglanti.State == ConnectionState.Closed){
                baglanti.Open();

            }
            

        }
        public void IlacKaydet(Ilac _ilac)
        {
            try
            {
                baglan();
                SqlCommand komut = new SqlCommand("INSERT INTO Ilac  (IlacAd, ReceteDurumu,ReceteKod,KategoriName,Firma,DevletDestek,Fiyat,IndirilmisFiyat,Stok,Gram) values (@ilacAd, @ReceteDurum,@ReceteKod,@kategoriAd,@firma,@DevletDestek,@Fiyat,@inFiyat,@stok,@gram)", baglanti);

                komut.Parameters.AddWithValue("@ilacAd", _ilac.ilacAd);
                komut.Parameters.AddWithValue("@ReceteDurum", _ilac.ReceteDurum);
                komut.Parameters.AddWithValue("@ReceteKod", _ilac.ReceteKod);
                komut.Parameters.AddWithValue("@kategoriAd", _ilac.kategoriAd);
                komut.Parameters.AddWithValue("@firma", _ilac.firma);
                komut.Parameters.AddWithValue("@DevletDestek", _ilac.DevletDestek);
                komut.Parameters.AddWithValue("@Fiyat", _ilac.Fiyat);
                komut.Parameters.AddWithValue("@inFiyat", _ilac.inFiyat);
                komut.Parameters.AddWithValue("@stok", _ilac.stok);
                komut.Parameters.AddWithValue("@gram", _ilac.gram);
                komut.ExecuteNonQuery();
            }
            catch(Exception _hata)
            {
                MessageBox.Show("Hata!"+_hata.Message);
            }
        }
        public List<Ilac> Getir()
        {
            baglan();
            SqlCommand komut = new SqlCommand("Select * From Ilac", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            List<Ilac> ilacListe = new List<Ilac>();
            while (oku.Read()){

                Ilac _ilac = new Ilac();
                  _ilac.ilacId = Convert.ToInt32(oku["IlacId"]);
                _ilac.ilacAd=oku["IlacAd"].ToString();
                _ilac.ReceteDurum=oku["ReceteDurumu"].ToString();
                _ilac.ReceteKod=oku["ReceteKod"].ToString();
                _ilac.kategoriAd=oku["KategoriName"].ToString();
                _ilac.firma= oku["Firma"].ToString(); 
                _ilac.DevletDestek= oku["DevletDestek"].ToString(); 
                _ilac.Fiyat= Convert.ToInt32(oku["Fiyat"]);
                _ilac.inFiyat= Convert.ToInt32(oku["IndirilmisFiyat"]);
                _ilac.stok = Convert.ToInt32(oku["Stok"]);
               _ilac.gram = Convert.ToInt32(oku["Gram"]);
              
                  ilacListe.Add(_ilac);

            }

            oku.Close();
            baglanti.Close();
            return ilacListe;
        }
        public List<Ilac> Getir(string ara)
        {
            baglan();
            SqlCommand komut = new SqlCommand("Select * From Ilac where IlacAd LIKE '%" + ara +"%' order by IlacId DESC", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            List<Ilac> ilacListe = new List<Ilac>();
            while (oku.Read())
            {

                Ilac _ilac = new Ilac();
               // _ilac.ilacId = Convert.ToInt32(oku["IlacId"]);
                _ilac.ilacAd = oku["IlacAd"].ToString();
                _ilac.ReceteDurum = oku["ReceteDurumu"].ToString();
                _ilac.ReceteKod = oku["ReceteKod"].ToString();
                _ilac.kategoriAd = oku["KategoriName"].ToString();
                _ilac.firma = oku["Firma"].ToString();
                _ilac.DevletDestek = oku["DevletDestek"].ToString();
                _ilac.Fiyat = Convert.ToInt32(oku["Fiyat"]);
                _ilac.inFiyat = Convert.ToInt32(oku["IndirilmisFiyat"]);
                _ilac.stok = Convert.ToInt32(oku["Stok"]);
                _ilac.gram = Convert.ToInt32(oku["Gram"]);

                ilacListe.Add(_ilac);

            }

            oku.Close();
            baglanti.Close();
            return ilacListe;
        }
        public List<Ilac> GetirKategori(string ara)
        {
            baglan();
            SqlCommand komut = new SqlCommand("Select * From Ilac where KategoriName LIKE '%" + ara + "%' order by IlacId DESC", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            List<Ilac> ilacListe = new List<Ilac>();
            while (oku.Read())
            {

                Ilac _ilac = new Ilac();
                // _ilac.ilacId = Convert.ToInt32(oku["IlacId"]);
                _ilac.ilacAd = oku["IlacAd"].ToString();
                _ilac.ReceteDurum = oku["ReceteDurumu"].ToString();
                _ilac.ReceteKod = oku["ReceteKod"].ToString();
                _ilac.kategoriAd = oku["KategoriName"].ToString();
                _ilac.firma = oku["Firma"].ToString();
                _ilac.DevletDestek = oku["DevletDestek"].ToString();
                _ilac.Fiyat = Convert.ToInt32(oku["Fiyat"]);
                _ilac.inFiyat = Convert.ToInt32(oku["IndirilmisFiyat"]);
                _ilac.stok = Convert.ToInt32(oku["Stok"]);
                _ilac.gram = Convert.ToInt32(oku["Gram"]);

                ilacListe.Add(_ilac);

            }

            oku.Close();
            baglanti.Close();
            return ilacListe;
        }

        public void ilacGuncelle(Ilac _ilac) {
            baglan();
            SqlCommand komut=new SqlCommand("UPDATE Ilac set IlacAd=@ilacAd, ReceteDurumu=@ReceteDurum,ReceteKod=@ReceteKod,KategoriName=@kategoriAd,Firma=@firma,DevletDestek=@DevletDestek,Fiyat=@Fiyat,IndirilmisFiyat=@inFiyat,Stok=@stok,Gram=@gram WHERE IlacId=@ilacId", baglanti);
            //Ilac _ilac = new Ilac();
            komut.Parameters.AddWithValue("@ilacId", _ilac.ilacId);
            komut.Parameters.AddWithValue("@ilacAd", _ilac.ilacAd);
            komut.Parameters.AddWithValue("@ReceteDurum", _ilac.ReceteDurum);
            komut.Parameters.AddWithValue("@ReceteKod", _ilac.ReceteKod);
            komut.Parameters.AddWithValue("@kategoriAd", _ilac.kategoriAd);
            komut.Parameters.AddWithValue("@firma", _ilac.firma);
            komut.Parameters.AddWithValue("@DevletDestek", _ilac.DevletDestek);
            komut.Parameters.AddWithValue("@Fiyat", _ilac.Fiyat);
            komut.Parameters.AddWithValue("@inFiyat", _ilac.inFiyat);
            komut.Parameters.AddWithValue("@stok", _ilac.stok);
            komut.Parameters.AddWithValue("@gram", _ilac.gram);
            komut.ExecuteNonQuery();
            baglanti.Close();

        }
        
        public void ilacSil(int ilacId)
        {
            baglan();
            SqlCommand silKomutu = new SqlCommand("DELETE FROM Ilac where IlacId=@ilacId", baglanti);
            silKomutu.Parameters.AddWithValue("@ilacId", ilacId);
            silKomutu.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
//Data Source =.\SQLEXPRESS;Initial Catalog = EczaneOtoData; Integrated Security = True