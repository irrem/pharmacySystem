using EczaneOtomasyon.Diğer_Ürünler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczaneOtomasyon
{
    public partial class DigerUrunEkle : Form
    {
        public DigerUrunEkle()
        {
            InitializeComponent();
        }
        public int Id;
        public int kategoriId;
        string UrunResimYer = "";
        string UrunResimDestination = "";
        //string Path = @"C:\Users\LENOVO\Desktop\EczaneOtomasyon - Kopya\Properties\ResimIlac\";
        //string Path = @"C:\Users\srsyi\OneDrive\Masaüstü\Eczane\EczaneOtomasyon - Kopya\Properties\ResimIlac";
        string Path = "";
        public string dgwBarkod;
        string directory = AppDomain.CurrentDomain.BaseDirectory;
        private void DigerUrunEkle_Load(object sender, EventArgs e)
        {
            Path = directory + @"ResimlerIlac\";
            KategorileriDoldur();
        }
        Regex regex = new Regex(@"(\d{5})");
        DigerUrunKod digerUrunKod = new DigerUrunKod();
        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (regex.Match(tbxBarkod.Text).Success)
                {

                    digerUrunKod.Add(new DigerUrun
                    {

                        Ad = tbxAd.Text,
                        KategoriId = Convert.ToInt32(cbxKategori.SelectedValue),
                        Firma = tbxMarka.Text,
                        Fiyat = Convert.ToDecimal(tbxFiyat.Text),
                        BarkodNo = tbxBarkod.Text,
                        Stok = Convert.ToInt32(tbxStok.Text)

                    });
                }
                else { MessageBox.Show("Barkod Kodu 5 Haneli Olmalıdır."); }
                UrunResimSec();
                if (MessageBox.Show("Bütün bilgilerinin doğruluğundan emin misiniz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show("Ürün Sistemimize Başarıyla Eklenmiştir.");
                }
            }
            catch (Exception) {
                MessageBox.Show("Hata!");
            }
        }

        public void UrunleriDoldur()
        {
            DigerUrunler digerUrunler = new DigerUrunler();
            List<DigerUrun> urunler = digerUrunKod.GetAll();
            digerUrunler.dgwDigerUrunGoruntule.DataSource = urunler;
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            DigerUrunler digerUrunler = new DigerUrunler();
            digerUrunKod.Update(new DigerUrun
            {
                DisId = Id,
                KategoriId = Convert.ToInt32(cbxKategori.SelectedValue),
                Ad = tbxAd.Text,
                Firma = tbxMarka.Text,
                Fiyat = Convert.ToDecimal(tbxFiyat.Text),
                BarkodNo = tbxBarkod.Text,
                Stok = Convert.ToInt32(tbxStok.Text)

            }) ;
            if(TıklandıMi)
            {
                File.Delete(Path + tbxBarkod.Text + ".jpg");
                UrunResimSec(tbxBarkod.Text);
            }
            if (MessageBox.Show("Bütün bilgilerinin doğruluğundan emin misiniz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Ürün Sistemimize Başarıyla Guncellenmiştir.");
            }

        }
        KategoriUrunKod kategoriUrunKod = new KategoriUrunKod();
        public void KategorileriDoldur()
        {
            cbxKategori.DataSource = kategoriUrunKod.GetAll();
            cbxKategori.DisplayMember = "UrunKategoriAd";
            cbxKategori.ValueMember = "UrunKategoriId";
        }
       

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DigerUrunler digerUrunler = new DigerUrunler();
            digerUrunler.ShowDialog();
            UrunleriDoldur();
        }
        public void UrunResimSec(string Urunresim)
        {
            UrunResimDestination = Path + Urunresim + ".jpg";
            File.Copy(UrunResimYer, UrunResimDestination);

        }
        public void UrunResimSec()
        {
            string resim = tbxBarkod.Text;
            UrunResimDestination = Path + resim + ".jpg";
            File.Copy(UrunResimYer, UrunResimDestination);


        }
        private void btnResimEkle_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.Filter = "Image Files(*.JPG;)|*.JPG;";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    UrunResimYer = dialog.FileName;
                    pbxUrun.ImageLocation = UrunResimYer;

                }

            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        bool TıklandıMi;
        private void btnResimGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files(*.JPG;)|*.JPG;";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    
                    UrunResimYer = dialog.FileName;
                    pbxUrun.ImageLocation = UrunResimYer;
                    TıklandıMi = true;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

   
    }
}
