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
    public partial class YoneticiGirisi : Form
    {
        public YoneticiGirisi()
        {
            InitializeComponent();
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tbxKullanici_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB; initial catalog=EczaneOtoData;integrated security=true");
        //SqlCommand command;
        //SqlDataReader reader;


        public void GirisYap(string ad, string parola)
        {
            SqlCommand command = new SqlCommand("Select * From YoneticiGirisBilgiler where yoneticiGirisAd='" + ad + "' and yoneticiGirisSifre='" + parola + "'", baglanti);
            baglanti.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                PersonelGoruntule frm2 = new PersonelGoruntule();

                frm2.Show();
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

               
        private void YoneticiGirisi_Load_1(object sender, EventArgs e)
        {
            tbxSifre.PasswordChar = '*';
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AnaMenu acilis = new AnaMenu();
            acilis.Show();
            this.Hide();
        }
    }
}
