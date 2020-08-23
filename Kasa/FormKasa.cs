using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using EczaneOtomasyon.Hasta_Bilgi;
using EczaneOtomasyon.Kasa;

namespace EczaneOtomasyon
{
    public partial class FormKasa : Form
    {
        public FormKasa()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB;Initial Catalog=EczaneOtoData;Integrated Security=True");
        public static int stok,toplam=0,kontrols=0,aratoplam=0;
        private void FormKasa_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
            comboBox1.DataSource = GetAll();
            comboBox1.DisplayMember = "Tc"; 
            comboBox1.ValueMember = "Tc";
            kasa();
        }
        public string HastaAd { get; set; }
        public string HastaSoyad { get; set; }
        public string Tc { get; set; }
        public int kasa_;
        public void kasa()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Kasa", baglanti);
            SqlDataReader oku3 = komut.ExecuteReader();
            while (oku3.Read())
            {

                labelkasa.Text = oku3["kasaDurum"].ToString();

            }


            

            baglanti.Close();

        }
        public List<Hasta> GetAll()
        {
            baglanti.Open();
            SqlCommand command = new SqlCommand("Select * from Hasta", baglanti);

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


                };
                hastalar.Add(hasta);
            }
            reader.Close();
            baglanti.Close();
            return hastalar;
        }
        public void satisKayit()
        {
            

            baglanti.Open();
            SqlCommand command = new SqlCommand("insert into Kasa values (@hastaTc,@barkod,@kasaGiris,@KasaDurum, @tarih)", baglanti);
            //command.Parameters.AddWithValue("@hastaAd", HastaAd);
            //command.Parameters.AddWithValue("@hastaSoyad", HastaSoyad);
            command.Parameters.AddWithValue("@hastaTc", comboBox1.SelectedValue);
            command.Parameters.AddWithValue("@barkod", lblkod.Text);
            command.Parameters.AddWithValue("@kasaGiris", aratoplam);
            command.Parameters.AddWithValue("@KasaDurum", labelkasa.Text);
            command.Parameters.AddWithValue("@tarih", DateTime.Now);
            command.ExecuteNonQuery();
            baglanti.Close();

        }
        private void button1_Click_1(object sender, EventArgs e)
        { // listeleme kısmı //sorgulama kısmı
           int  kontrol = 0;// hangi eri tabnı olduğu geçiş için
            if (radioButton2.Checked==true) 
            {
                while (kontrol < 2)// iki farklı veri tabanından çekmek için
                {
                    try
                    {
                        if (kontrol == 0)
                        {
                            baglanti.Open();
                            SqlCommand komut3 = new SqlCommand("Select * from Ilac", baglanti);
                            SqlDataReader oku3 = komut3.ExecuteReader();
                            while (oku3.Read())
                            {
                                if (oku3["ReceteKod"].ToString() == txtkod.Text.ToString())
                                {
                                    lblkod.Text = oku3["ReceteKod"].ToString();
                                    stok = Convert.ToInt16(oku3["Stok"].ToString());
                                    lblAd.Text = oku3["IlacAd"].ToString();
                                    lblrecete.Text = oku3["ReceteDurumu"].ToString();
                                    lblkategori.Text = oku3["KategoriName"].ToString();
                                    lblfirma.Text = oku3["Firma"].ToString();
                                    lbldestek.Text = oku3["DevletDestek"].ToString();
                                    lblfiyat.Text = oku3["Fiyat"].ToString();
                                    lblindirim.Text = oku3["IndirilmisFiyat"].ToString();
                                    lblstok.Text = oku3["Stok"].ToString();
                                    lblgram.Text = oku3["Gram"].ToString();
                                    kontrol = 2;
                                    kontrols = 0;
                                    if (Convert.ToInt16(oku3["Stok"].ToString()) <= 0)
                                    {
                                        button2.Text = "Ürün Stokta Yok";
                                        button2.BackColor = Color.Red;
                                        button2.Enabled = false;
                                    }
                                }


                            }
                            baglanti.Close();
                        }
                        else if (kontrol == 1)
                        {
                            baglanti.Open();
                            SqlCommand komut3 = new SqlCommand("Select * from IlacDisiUrun", baglanti);
                            SqlDataReader oku3 = komut3.ExecuteReader();
                            while (oku3.Read())
                            {
                                if (oku3["BarkodNo"].ToString() == txtkod.Text.ToString())
                                {
                                    lblkod.Text = oku3["BarkodNo"].ToString();
                                    stok = Convert.ToInt16(oku3["Stok"].ToString());
                                    lblAd.Text = oku3["Ad"].ToString();
                                    lblkategori.Text = "Özel Ürün";
                                    lblfirma.Text = oku3["Firma"].ToString();
                                    lblfiyat.Text = oku3["Fiyat"].ToString();
                                    lblstok.Text = oku3["Stok"].ToString();
                                    kontrol = 2;
                                    kontrols = 1;
                                    lblrecete.Text = "Reçete Gerekmez";
                                    lbldestek.Text = "Devlet Desteği Yok";
                                    lblindirim.Text = "0";
                                    lblgram.Text = "Belirtilmedi";
                                    if (Convert.ToInt16(oku3["Stok"].ToString()) <= 0)
                                    {
                                        //stok yoksa 
                                        button2.Text = "Ürün Stokta Yok";
                                        button2.BackColor = Color.Red;
                                        button2.Enabled = false;
                                    }
                                }


                            }
                            baglanti.Close();
                        }

                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("HATA" + hata.Message);
                    }
                    kontrol++;
                }
            }
            else if (radioButton1.Checked==true)
            {
                //eger barkod yoksa ad
                while (kontrol < 2)
                {
                    try
                    {
                        if (kontrol == 0)
                        {
                            baglanti.Open();
                            SqlCommand komut3 = new SqlCommand("Select * from Ilac", baglanti);
                            SqlDataReader oku3 = komut3.ExecuteReader();
                            while (oku3.Read())
                            {
                                if (oku3["IlacAd"].ToString() == txtkod.Text.ToString())
                                {
                                    lblkod.Text = oku3["ReceteKod"].ToString();
                                    stok = Convert.ToInt16(oku3["Stok"].ToString());
                                    lblAd.Text = oku3["IlacAd"].ToString();
                                    lblrecete.Text = oku3["ReceteDurumu"].ToString();
                                    lblkategori.Text = oku3["KategoriName"].ToString();
                                    lblfirma.Text = oku3["Firma"].ToString();
                                    lbldestek.Text = oku3["DevletDestek"].ToString();
                                    lblfiyat.Text = oku3["Fiyat"].ToString();
                                    lblindirim.Text = oku3["IndirilmisFiyat"].ToString();
                                    lblstok.Text = oku3["Stok"].ToString();
                                    lblgram.Text = oku3["Gram"].ToString();
                                    kontrol = 2;
                                    kontrols = 0;
                                    if (Convert.ToInt16(oku3["Stok"].ToString()) <= 0)
                                    {
                                        button2.Text = "Ürün Stokta Yok";
                                        button2.BackColor = Color.Red;
                                        button2.Enabled = false;
                                    }
                                }


                            }
                            baglanti.Close();
                        }
                        else if (kontrol == 1)
                        {
                            baglanti.Open();
                            SqlCommand komut3 = new SqlCommand("Select * from IlacDisiUrun", baglanti);
                            SqlDataReader oku3 = komut3.ExecuteReader();
                            while (oku3.Read())
                            {
                                if (oku3["Ad"].ToString() == txtkod.Text.ToString())
                                {
                                    lblkod.Text = oku3["BarkodNo"].ToString();
                                    stok = Convert.ToInt16(oku3["Stok"].ToString());
                                    lblAd.Text = oku3["Ad"].ToString();
                                    lblkategori.Text = "Özel Ürün";
                                    lblfirma.Text = oku3["Firma"].ToString();
                                    lblfiyat.Text = oku3["Fiyat"].ToString();
                                    lblstok.Text = oku3["Stok"].ToString();
                                    kontrol = 2;
                                    kontrols = 1;
                                    lblrecete.Text = "Reçete Gerekmez";
                                    lbldestek.Text = "Devlet Desteği Yok";
                                    lblindirim.Text = "0";
                                    lblgram.Text = "Belirtilmedi";
                                    if (Convert.ToInt16(oku3["Stok"].ToString()) <= 0)
                                    {
                                        button2.Text = "Ürün Stokta Yok";
                                        button2.BackColor = Color.Red;
                                        button2.Enabled = false;
                                    }
                                }


                            }
                            baglanti.Close();
                        }

                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("HATA" + hata.Message);
                    }
                    kontrol++;
                }
            }
           
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GenelMenu anaMenuForm = new GenelMenu();
            this.Close();
            anaMenuForm.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void button7_Click(object sender, EventArgs e)
        {
            KasaGecmis gecmis = new KasaGecmis();
            gecmis.Show();
            
           
        }

        private void txtkod_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        { // ilaç satış kısmı
            toplam = toplam + Convert.ToInt16(labeltutar.Text);
            foreach (var Listboks in listBox1.Items)
            {
                char ayrac = '|';
                string secilen = Listboks.ToString();
                string[] parcalar = secilen.Split(ayrac);
                baglanti.Open();
                SqlCommand komut3 = new SqlCommand("Update IlacDisiUrun set Stok =Stok -1 where BarkodNo=@kod", baglanti);
                komut3.Parameters.AddWithValue("@kod", parcalar[1].ToString());
                komut3.ExecuteNonQuery();
                baglanti.Close();

            }
            foreach (var Listboks in listBox1.Items)
            {
                char ayrac = '|';
                string secilen = Listboks.ToString();
                string[] parcalar = secilen.Split(ayrac);
                baglanti.Open();
                SqlCommand komut3 = new SqlCommand("Update Ilac set Stok =Stok -1 where ReceteKod=@kod", baglanti);
                komut3.Parameters.AddWithValue("@kod", parcalar[1].ToString());
                komut3.ExecuteNonQuery();
                baglanti.Close();

            }
            listBox1.Items.Clear();
            MessageBox.Show("Başarılı");
            labeltutar.Text = "0";
            labelkasa.Text = (Convert.ToInt32(labelkasa.Text)+aratoplam).ToString();
            satisKayit();
            aratoplam = 0;
            
        }

        private void listBox1_DoubleClick_1(object sender, EventArgs e)
        { //listbox silme
            if (listBox1.SelectedIndex > -1)
            {
                char ayrac = '*';
                string secilen = listBox1.SelectedItem.ToString();
                string[] parcalar = secilen.Split(ayrac);
                toplam = toplam - Convert.ToInt16(parcalar[1].ToString());
                listBox1.Items.Remove(listBox1.SelectedItem);
                labeltutar.Text = toplam.ToString();
            }
            else
            {
                MessageBox.Show("Liste Boş");
            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        { //siparişleri listboxa ata //sipariş ekle
           
            if (kontrols==0)
            {
                listBox1.Items.Add("Barkod No:  |" + lblkod.Text + "| Adı: " + lblAd.Text + " | Fiyat:*" + lblindirim.Text);
                aratoplam = aratoplam + Convert.ToInt16(lblindirim.Text);
            }
            else if(kontrols==1){
                listBox1.Items.Add("Barkod No:  |" + lblkod.Text + "| Adı: " + lblAd.Text + " | Fiyat:*" + lblfiyat.Text);
                aratoplam = aratoplam + Convert.ToInt16(lblfiyat.Text);
            }
            int stok = Convert.ToInt32(lblstok.Text);
            int stokGuncel;
            stokGuncel = stok - 1;
            lblstok.Text = stokGuncel.ToString();
            labeltutar.Text = aratoplam.ToString(); // kasa durumu     

            

        }
    }
}
