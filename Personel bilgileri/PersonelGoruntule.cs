using EczaneOtomasyon.Personel_bilgileri;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczaneOtomasyon
{
    public partial class PersonelGoruntule : Form
    {
        public PersonelGoruntule()
        {
            InitializeComponent();
        }
        public int PersonelId;
        //string Path = @"C:\Users\LENOVO\Desktop\EczaneOtomasyon\Properties\Resimler\";
        //string Path = @"C:\Users\srsyi\OneDrive\Masaüstü\Eczane\EczaneOtomasyon - Kopya\Properties\ResimIlac";
        string Path = "";
        string directory = AppDomain.CurrentDomain.BaseDirectory;
        private void button3_Click(object sender, EventArgs e)
        {
            YoneticiGirisi Giris = new YoneticiGirisi();
            Giris.Show();
            this.Hide();

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            this.Hide();
            PersonelEkle personelEkleForm = new PersonelEkle();
            personelEkleForm.Show();
          
        }
        PersonelBilgiKod _personelBilgiKod = new PersonelBilgiKod();
        private void PersonelGoruntule_Load(object sender, EventArgs e)
        {
           
            dgwPersonelGoruntule.DataSource = _personelBilgiKod.GetAll();
            Path = directory + @"\Resimler\";
        }

        PersonelEkle Ekle = new PersonelEkle();
        private void dgwPersonelGoruntule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Ekle.tbxAd.Text = dgwPersonelGoruntule.CurrentRow.Cells[1].Value.ToString();
            Ekle.tbxSoyad.Text= dgwPersonelGoruntule.CurrentRow.Cells[2].Value.ToString();
            Ekle.tbxTarih.Text= dgwPersonelGoruntule.CurrentRow.Cells[3].Value.ToString();
            Ekle.tbxOkul.Text= dgwPersonelGoruntule.CurrentRow.Cells[4].Value.ToString();
            Ekle.tbxMezun.Text= dgwPersonelGoruntule.CurrentRow.Cells[5].Value.ToString();
            Ekle.tbxEv.Text= dgwPersonelGoruntule.CurrentRow.Cells[6].Value.ToString();
            Ekle.tbxGecmis.Text= dgwPersonelGoruntule.CurrentRow.Cells[7].Value.ToString();
            Ekle.tbxNot.Text = dgwPersonelGoruntule.CurrentRow.Cells[8].Value.ToString();
            Ekle.tbxTc.Text= dgwPersonelGoruntule.CurrentRow.Cells[9].Value.ToString();
            Ekle.Id = Convert.ToInt32(dgwPersonelGoruntule.CurrentRow.Cells[0].Value);
            Ekle.pcbDiploma.ImageLocation = Path + dgwPersonelGoruntule.CurrentRow.Cells[9].Value.ToString() +".jpg";
            Ekle.pcbKendi.ImageLocation = Path + dgwPersonelGoruntule.CurrentRow.Cells[10].Value.ToString() + ".jpg";
            Ekle.tbxSifre.Text = dgwPersonelGoruntule.CurrentRow.Cells[10].Value.ToString();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Ekle.ShowDialog();
        }

        private void btnSilme_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgwPersonelGoruntule.CurrentRow.Cells[0].Value);
            _personelBilgiKod.Delete(id);
            if (MessageBox.Show("Silmek istediğine emin misiniz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Eczacı Sistemimize Başarıyla Silinmiştir");
            }
            dgwPersonelGoruntule.DataSource = _personelBilgiKod.GetAll();

        }

        private void tbxArama_TextChanged(object sender, EventArgs e)
        {
           
            dgwPersonelGoruntule.DataSource = _personelBilgiKod.Search(tbxArama.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
