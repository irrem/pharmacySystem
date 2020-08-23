using EczaneOtomasyon.Metot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczaneOtomasyon
{
    public partial class IlacBilgileri : Form
    {
         public IlacBilgileri()
        {
            InitializeComponent();
        }
        Ilac _ilac_ = new Ilac(); //metot klasöründeki ilaç sınıfı içerisinden veri iletişimi
        private void button3_Click_1(object sender, EventArgs e)
        {
            GenelMenu anaMenuForm = new GenelMenu();
            anaMenuForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //GenelMenu anaMenuForm = new GenelMenu();
            //anaMenuForm.Show();
            //this.Hide();
            IlacGoruntuleme ılacGoruntule = new IlacGoruntuleme();
            ılacGoruntule.Show();
            this.Hide();
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void kaydetButonu_Click(object sender, EventArgs e)
        {
           


        }
        public void TextAktar()
        {
            

        }

       public void receteTxt_TextChanged(object sender, EventArgs e)
        {

        }

        public void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnIlacGncelle_Click(object sender, EventArgs e)
        {
            try { 
            IlacGoruntuleme gid = new IlacGoruntuleme();
            SqlConnection baglanti = new SqlConnection(@"Data source=(localdb)\MSSQLLocalDB; initial catalog=EczaneOtoData;integrated security=true");


            _ilac_.ilacId = Convert.ToInt32(ilacLbl.Text);
            _ilac_.ilacAd = ilacAdTxt.Text;
            _ilac_.ReceteDurum = receteCesit.Text;
            _ilac_.ReceteKod = receteTxt.Text;
            _ilac_.kategoriAd = ilacKategoriCombo.Text;
            _ilac_.firma = ilacMarkaTxt.Text;
            _ilac_.DevletDestek = destekTxt.Text;
            _ilac_.Fiyat = Convert.ToInt32(fiyatTxt.Text);
            _ilac_.inFiyat = Convert.ToInt32(indirimliFiyatTxt.Text);
            _ilac_.stok = Convert.ToInt32(stokTxt.Text);
            _ilac_.gram = Convert.ToInt32(gramTxt.Text);
            MessageBox.Show(_ilac_.ilacId.ToString());
            _ilac_.ilacGuncelle(_ilac_);
        }
            catch(Exception _hata)
            {
                MessageBox.Show("Hata!" + _hata);
            }
}

        public void ilacLbl_Click(object sender, EventArgs e)
        {

        }

        private void IlacBilgileri_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }
        Regex regex = new Regex(@"^(\d{5,5}$)");
        private void kaydetButonu_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (regex.Match(receteTxt.Text).Success)
                {
                    SqlConnection baglanti = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB;Initial Catalog = EczaneOtoData; Integrated Security = True");

                    _ilac_.ilacAd = ilacAdTxt.Text;
                    _ilac_.ReceteDurum = receteCesit.Text;
                    _ilac_.ReceteKod = receteTxt.Text;
                    _ilac_.kategoriAd = ilacKategoriCombo.Text;
                    _ilac_.firma = ilacMarkaTxt.Text;
                    _ilac_.DevletDestek = destekTxt.Text;
                    _ilac_.Fiyat = Convert.ToInt32(fiyatTxt.Text);
                    _ilac_.inFiyat = Convert.ToInt32(indirimliFiyatTxt.Text);
                    _ilac_.stok = Convert.ToInt32(stokTxt.Text);
                    _ilac_.gram = Convert.ToInt32(gramTxt.Text);

                    _ilac_.IlacKaydet(_ilac_);
                }
                else
                {
                    MessageBox.Show("Hata! İlaç kodu 5 rakam içermelidir.");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("hata" + ex.Message);
            }
            
                
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
           // IlacGoruntuleme goruntuleIlac = new IlacGoruntuleme();
           // goruntuleIlac.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Minimized;
        }

        private void btnIlacGncelle_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
