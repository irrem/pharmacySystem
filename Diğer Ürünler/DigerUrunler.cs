using EczaneOtomasyon.Diğer_Ürünler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczaneOtomasyon
{
    public partial class DigerUrunler : Form
    {
        public DigerUrunler()
        {
            InitializeComponent();
        }
        //string Path = @"C:\Users\LENOVO\Desktop\EczaneOtomasyon - Kopya\Properties\ResimIlac\";
        //string Path = @"C:\Users\srsyi\OneDrive\Masaüstü\Eczane\EczaneOtomasyon - Kopya\Properties\ResimIlac";
        string Path = "";
        string directory = AppDomain.CurrentDomain.BaseDirectory;


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwDigerUrunGoruntule.DataSource = digerUrunKod.KategoriIleUrunGetir(Convert.ToInt32(cbxKategoriArama.SelectedValue));

            }
            catch (Exception)
            {
            }
        }
        KategoriUrunKod kategoriUrunKod = new KategoriUrunKod();
        public void KategoriDoldur()
        {
            cbxKategoriArama.DataSource = kategoriUrunKod.GetAll();
            cbxKategoriArama.DisplayMember = "UrunKategoriAd";
            cbxKategoriArama.ValueMember = "UrunKategoriId";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            GenelMenu anaMenuForm = new GenelMenu();
            anaMenuForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DigerUrunEkle urunEkleForm = new DigerUrunEkle();
            urunEkleForm.Show();
        }

        DigerUrunKod digerUrunKod = new DigerUrunKod();
        private void DigerUrunler_Load(object sender, EventArgs e)
        {
            dgwDigerUrunGoruntule.DataSource = digerUrunKod.GetAll();
            KategoriDoldur();
            Path = directory + @"ResimlerIlac\";
        }
        public void ÜrünleriDoldur()
        {
            dgwDigerUrunGoruntule.DataSource = digerUrunKod.GetAll();
        }

        DigerUrunEkle digerUrunEkle = new DigerUrunEkle();
        private void dgwDigerUrunGoruntule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            digerUrunEkle.cbxKategori.SelectedValue= dgwDigerUrunGoruntule.CurrentRow.Cells[1].Value;
            digerUrunEkle.tbxAd.Text = dgwDigerUrunGoruntule.CurrentRow.Cells[2].Value.ToString();         
            digerUrunEkle.tbxMarka.Text= dgwDigerUrunGoruntule.CurrentRow.Cells[3].Value.ToString();
            digerUrunEkle.tbxFiyat.Text = dgwDigerUrunGoruntule.CurrentRow.Cells[4].Value.ToString();
            digerUrunEkle.tbxBarkod.Text=dgwDigerUrunGoruntule.CurrentRow.Cells[5].Value.ToString();
            digerUrunEkle.Id = Convert.ToInt32(dgwDigerUrunGoruntule.CurrentRow.Cells[0].Value);
            digerUrunEkle.pbxUrun.ImageLocation = Path + dgwDigerUrunGoruntule.CurrentRow.Cells[5].Value.ToString() + ".jpg";
            digerUrunEkle.tbxStok.Text= dgwDigerUrunGoruntule.CurrentRow.Cells[6].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            digerUrunEkle.ShowDialog();
        }

        private void btnSilme_Click(object sender, EventArgs e)
        {
            int id= Convert.ToInt32(dgwDigerUrunGoruntule.CurrentRow.Cells[0].Value);
            digerUrunKod.Delete(id);
            if (MessageBox.Show("Silmek istediğine emin misiniz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Eczacı Sistemimize Başarıyla Silinmiştir");
            }
            dgwDigerUrunGoruntule.DataSource = digerUrunKod.GetAll();
        }

        private void tbxArama_TextChanged(object sender, EventArgs e)
        {
            dgwDigerUrunGoruntule.DataSource = digerUrunKod.Search(tbxArama.Text);
            
        }

        private void btnKategori_Click(object sender, EventArgs e)
        {
            this.Hide();
            KategoriUrunEkleme kategoriUrunEkleme = new KategoriUrunEkleme();
            kategoriUrunEkleme.Show();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
