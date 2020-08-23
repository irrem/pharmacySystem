using EczaneOtomasyon.Hasta_Bilgi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczaneOtomasyon.Hasta_Bilgi
{
    public partial class YeniHasta : Form
    {
        public YeniHasta()
        {
            InitializeComponent();
        }
        public int HastaId;

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        YeniHastaKod _yeniHastaKod = new YeniHastaKod();

        Regex regex = new Regex(@"(\d{11})");
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (regex.Match(tbxTc.Text).Success)//tc kimlik hane kontrol
            {
                _yeniHastaKod.Add(new Hasta
                {
                    HastaAd = tbxAd.Text,
                    HastaSoyad = tbxSoyad.Text,
                    Tc = tbxTc.Text,
                    Cinsiyet = cbxCinsiyet.Text,
                    HastaDogum = Convert.ToDateTime(tbxDogum.Text),
                    Telefon = tbxTelefon.Text,
                    Hastaliklar = tbxHastalık.Text,
                    RaporluIlac = tbxIlac.Text,
                    Adres = tbxAdres.Text,
                    SaglikGuvence = cbxSaglik.Text,
                    Alerji = tbxAlerji.Text

                });
                if (MessageBox.Show("Personelin bütün bilgilerinin doğruluğundan emin misiniz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show("Eczacı Sistemimize Başarıyla Eklenmiştir");
                }
            }
            else
            {
                MessageBox.Show("TC Kimlik numaranızı kontrol etmelisiniz!");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
          HastaBilgileri hastaBilgiForm = new HastaBilgileri();
        hastaBilgiForm.Show();
         this.Hide();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            HastaBilgileri hastaBilgileri = new HastaBilgileri();
            _yeniHastaKod.Update(new Hasta
            {
                HastaAd = tbxAd.Text,
                HastaSoyad = tbxSoyad.Text,
                Tc = tbxTc.Text,
                Cinsiyet = cbxCinsiyet.Text,
                HastaDogum = Convert.ToDateTime(tbxDogum.Text),
                Telefon = tbxTelefon.Text,
                Hastaliklar = tbxHastalık.Text,
                RaporluIlac = tbxIlac.Text,
                Adres = tbxAdres.Text,
                SaglikGuvence = cbxSaglik.Text,
                Alerji = tbxAlerji.Text,
                HastaId = HastaId

            }) ;
            if (MessageBox.Show("Personelin bütün bilgilerinin doğruluğundan emin misiniz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Eczacı Sistemimize Başarıyla Güncellenmiştir");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            HastaBilgileri hastaBilgileri = new HastaBilgileri();
            hastaBilgileri.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tbxTelefon_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
