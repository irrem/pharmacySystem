using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczaneOtomasyon.Diğer_Ürünler
{
    public partial class KategoriUrunEkleme : Form
    {
        public KategoriUrunEkleme()
        {
            InitializeComponent();
        }

        KategoriUrunKod kategoriUrunKod = new KategoriUrunKod();
        private void btnEkle_Click(object sender, EventArgs e)
        {
            kategoriUrunKod.Add( new KategoriUrun2{
                UrunKategoriAd= tbxAd.Text
                
            });
            if (MessageBox.Show("Bütün bilgilerinin doğruluğundan emin misiniz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Ürün Sistemimize Başarıyla Eklenmiştir.");
            }
            KategoriGosterme();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            kategoriUrunKod.Update(new KategoriUrun2
            {
                UrunKategoriId= Convert.ToInt32(dgwKategoriUrunGoruntule.CurrentRow.Cells[0].Value),
                UrunKategoriAd = tbxAd.Text
            });
            if (MessageBox.Show("Bütün bilgilerinin doğruluğundan emin misiniz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Ürün Sistemimize Başarıyla Guncellenmiştir.");
            }
            KategoriGosterme();
        }

        private void btnSilme_Click(object sender, EventArgs e)
        {
            kategoriUrunKod.Delete(Convert.ToInt32(dgwKategoriUrunGoruntule.CurrentRow.Cells[0].Value));

            if (MessageBox.Show("Bütün bilgilerinin doğruluğundan emin misiniz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Ürün Sistemimize Başarıyla Silinmiştir.");
            }
            KategoriGosterme();
        }
        public void KategoriGosterme()
        {
            dgwKategoriUrunGoruntule.DataSource = kategoriUrunKod.GetAll();
        }

        private void KategoriUrunEkleme_Load(object sender, EventArgs e)
        {
            KategoriGosterme();
        }

        private void dgwKategoriUrunGoruntule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxAd.Text = dgwKategoriUrunGoruntule.CurrentRow.Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            DigerUrunEkle ekle = new DigerUrunEkle();
            this.Close();
            ekle.Show();
        }
    }
}
