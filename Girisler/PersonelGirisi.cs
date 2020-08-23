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

namespace EczaneOtomasyon
{
    public partial class PersonelGirisi : Form
    {
        public PersonelGirisi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB; initial catalog=EczaneOtoData;integrated security=true");


        public void GirisYap(string ad, string parola)
        {
            // baglan();
            SqlCommand command = new SqlCommand("Select * From Personel where Tc='" + ad + "' and Sifre='" + parola + "'", baglanti);
            baglanti.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                GenelMenu menuGenel = new GenelMenu();

                menuGenel.Show();
                this.Hide();

            }
            else
            {

                MessageBox.Show("Hatalı Giriş!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            baglanti.Close();
            command.Dispose();
        }
        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAd = tbxKullanici.Text;
            string kullaniciSifre = tbxSifre.Text;
            GirisYap(kullaniciAd, kullaniciSifre);
        }

      
       
        private void PersonelGirisi_Load_1(object sender, EventArgs e)
        {
            tbxSifre.PasswordChar = '*';
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            AnaMenu acilis = new AnaMenu();
            acilis.Show();
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
