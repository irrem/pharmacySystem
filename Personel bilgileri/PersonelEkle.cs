using EczaneOtomasyon.Personel_bilgileri;
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
    public partial class PersonelEkle : Form
    {
        public PersonelEkle()
        {
            InitializeComponent();
        }

        public int Id;
        string ResimYer="";
        string FotoYer = "";
        string ResimDestination = "";
        string FotoDestination = "";
        //string Path= @"C:\Users\LENOVO\Desktop\EczaneOtomasyon\Properties\Resimler\";
        //string Path = @"C:\Users\OneDrive\Masaüstü\Eczane\EczaneOtomasyon - Kopya\Properties\Resimler\";
        string Path = "";
        string directory = AppDomain.CurrentDomain.BaseDirectory;
        public string dgwTc;
        bool ResimSecildiMi;
        bool FotoSecildiMi;
        Regex regex = new Regex(@"^(\d{11,11}$)");
        Regex regex2 = new Regex(@"^([3])");
        DateTime Tarih = new DateTime(2020, 12, 31);
        int yas;
        Regex regex3 = new Regex(@"^(?=.{6,15}$)(?=.*[A-Z])(?=.*[a-z])(?=.*[@#$%*?^:;+-._,])(?=.*[0-9]).*");

        private void button3_Click(object sender, EventArgs e)
        {
            PersonelGoruntule personelGoruntule = new PersonelGoruntule();
            personelGoruntule.Show();
            this.Hide();
        }
        PersonelBilgiKod _personelBilgiKod = new PersonelBilgiKod();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TimeSpan span = Tarih.Subtract(Convert.ToDateTime(tbxTarih.Text));
            yas = Convert.ToInt32(span.TotalDays) / 360;
            try
            {
                if (regex3.Match(tbxSifre.Text).Success)//şifre oluşturma kuralı
                {

                    if (yas > 18)//18 yaş kontrol noktası
                    {
                        if (regex.Match(tbxTc.Text).Success)//tc kimlik hane kontrol
                        {
                            if (regex2.Match(tbxNot.Text).Success)//not ortalaması 3<x !!
                            {

                                _personelBilgiKod.Add(new PersonelBilgi
                                {
                                    PersonelAd = tbxAd.Text,
                                    PersonelSoyad = tbxSoyad.Text,
                                    PersonelTarih = Convert.ToDateTime(tbxTarih.Text),
                                    OkuduguYer = tbxOkul.Text,
                                    MezunYil = Convert.ToInt32(tbxMezun.Text),
                                    YasadıgıYer = tbxEv.Text,
                                    Ozgecmis = tbxGecmis.Text,
                                    NotOrt = tbxNot.Text,
                                    Tc = tbxTc.Text,
                                    Sifre = tbxSifre.Text


                                });
                                ResimSec();
                                FotoSec();
                                if (MessageBox.Show("Personelin bütün bilgilerinin doğruluğundan emin misiniz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    MessageBox.Show("Eczacı Sistemimize Başarıyla Eklenmiştir");
                                }


                            }
                            else
                            {
                                MessageBox.Show("Not ortalaması uygun değildir.3 ve üzeri ortalama için kayıt yapılabilir!");
                            }
                        }

                        else
                        {
                            MessageBox.Show("TC Kimlik numarası kontrol ediniz!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("18 yaşın altında personel kaydedilemez.");
                    }
                }
                else
                {
                    MessageBox.Show("Eczacının Güvenliği Açısından oluşturduğunuz Şifre '6-15 karekter arasında olması ve min 1 küçük ve buyuk harf bulundurmaktadır.Güvenliği arttırmak amacıyla @#$%*?^:;+-._, özel karakterini kullanmanız gerekmektedir.");
                }

            }
            catch(Exception _hata)
            {
                MessageBox.Show("Beklenmedik bir hata oluştu!"+_hata.Message);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            PersonelGoruntule personelGoruntule = new PersonelGoruntule();
            _personelBilgiKod.Update(new PersonelBilgi
            {
                PersonelId = Id,
                PersonelAd = tbxAd.Text,
                PersonelSoyad = tbxSoyad.Text,
                PersonelTarih = Convert.ToDateTime(tbxTarih.Text),
                OkuduguYer = tbxOkul.Text,
                MezunYil = Convert.ToInt32(tbxMezun.Text),
                YasadıgıYer = tbxEv.Text,
                Ozgecmis = tbxGecmis.Text,
                NotOrt = tbxNot.Text,
                Tc = tbxTc.Text,
                Sifre = tbxSifre.Text


            });
            if (ResimSecildiMi)
            {
                File.Delete(Path + tbxTc.Text + ".jpg");
                ResimSec(tbxTc.Text);
            }
            if (FotoSecildiMi)
            {
                File.Delete(Path +tbxSifre.Text + ".jpg");
                FotoSec(tbxSifre.Text);
            }
           

            if (MessageBox.Show("Personelin bütün bilgilerinin doğruluğundan emin misiniz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Eczacı Sistemimize Başarıyla Güncellenmiştir");
            }
        }

        public void ResimSec( string resim)
        {
            ResimDestination = Path + resim + ".jpg";
            File.Copy(ResimYer, ResimDestination);

        }
        public void ResimSec()
        {
            string resim=tbxTc.Text;
            ResimDestination = Path + resim + ".jpg";
            File.Copy(ResimYer, ResimDestination);


        }
        public void FotoSec( string resim )
        {
            FotoDestination = Path + resim + ".jpg";
            File.Copy(FotoYer, FotoDestination);

        }
        public void FotoSec()
        {
            string resim = tbxSifre.Text ;
           FotoDestination = Path + resim + ".jpg";
            File.Copy(FotoYer, FotoDestination);


        }
        

        private void btnResimElkle_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.Filter = "Image Files(*.JPG;)|*.JPG;";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                   
                    ResimYer = dialog.FileName;
                    pcbDiploma.ImageLocation = ResimYer;
                    
                }

            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void btnResimGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files(*.JPG;)|*.JPG;";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ResimSecildiMi = true;
                    ResimYer = dialog.FileName;
                    pcbDiploma.ImageLocation = ResimYer ;

                }

            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnFotoGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files(*.JPG;)|*.JPG;";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    FotoSecildiMi = true;
                    FotoYer = dialog.FileName;
                    pcbKendi.ImageLocation = FotoYer ;

                }

            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btnFotoEkle_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files(*.JPG;)|*.JPG;";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    FotoYer = dialog.FileName;
                    pcbKendi.ImageLocation = FotoYer;

                }

            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void PersonelEkle_Load(object sender, EventArgs e)
        {
            Path = directory+@"Resimler\";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
