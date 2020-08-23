using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczaneOtomasyon.Kasa
{
    public partial class KasaGecmis : Form
    {
        public KasaGecmis()
        {
            InitializeComponent();
        }
       
        SqlConnection baglanti = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB;Initial Catalog=EczaneOtoData;Integrated Security=True");
       
        public List<KasaBilgi> gor()
        {
            baglanti.Open();
            List<KasaBilgi> gecmis = new List<KasaBilgi>();
           
           
           
            SqlCommand komut = new SqlCommand("select * from Kasa", baglanti);
            SqlDataReader oku3 = komut.ExecuteReader();
            while (oku3.Read())
            {
                KasaBilgi kasa = new KasaBilgi();
               // Kasa = oku3["kasaDurum"].ToString();
                kasa.hastaTc = oku3["hastaTc"].ToString();
                kasa.barkod = oku3["barkod"].ToString();
                kasa.kasaGiris= oku3["kasaGiris"].ToString();
                kasa.kasadurum= oku3["kasaDurum"].ToString();
                kasa.tarih = Convert.ToDateTime(oku3["tarih"]);

                gecmis.Add(kasa);
            }
            
            oku3.Close();
            baglanti.Close();
            
            return gecmis;
        }
        private void dgwGoruntuleKasa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void KasaGeçmiş_Load(object sender, EventArgs e)
        {
            dgwGoruntuleKasa.DataSource = gor();
        }

     
        

        private void btnGeri_Click(object sender, EventArgs e)
        {

            FormKasa formKasa = new FormKasa();
            formKasa.ShowDialog();
            this.Hide();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAlt_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
