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
    public partial class SaglikArsiv : Form
    {
        public SaglikArsiv()
        {
            InitializeComponent();
        }
        string directory = AppDomain.CurrentDomain.BaseDirectory;
       
      

 

        private void btnAgiz_Click(object sender, EventArgs e)
        {
            SaglikArsivGoruntuleme arsivGoruntuleme = new SaglikArsivGoruntuleme();
            StreamReader reader = File.OpenText(directory + @"\CokluSaglikArsivi\AgizDis.txt");
            string metin;
            while ((metin = reader.ReadLine()) != null)
            {
                arsivGoruntuleme.lsbGoruntule.Items.Add(metin);
            }
            arsivGoruntuleme.Show();
            this.Hide();
        }

        private void btnCildiye_Click(object sender, EventArgs e)
        {
            SaglikArsivGoruntuleme arsivGoruntuleme = new SaglikArsivGoruntuleme();
            StreamReader reader = File.OpenText(directory + @"\CokluSaglikArsivi\Cildiye.txt");
            string metin;
            while ((metin = reader.ReadLine()) != null)
            {
                arsivGoruntuleme.lsbGoruntule.Items.Add(metin);
            }
            arsivGoruntuleme.Show();
            this.Hide();
        }

        private void btnSac_Click(object sender, EventArgs e)
        {
            SaglikArsivGoruntuleme arsivGoruntuleme = new SaglikArsivGoruntuleme();
            StreamReader reader = File.OpenText(directory + @"\CokluSaglikArsivi\Sac.txt");
            string metin;
            while ((metin = reader.ReadLine()) != null)
            {
                arsivGoruntuleme.lsbGoruntule.Items.Add(metin);
            }
            arsivGoruntuleme.Show();
            this.Hide();
        }

        private void btnKulak_Click(object sender, EventArgs e)
        {
            SaglikArsivGoruntuleme arsivGoruntuleme = new SaglikArsivGoruntuleme();
            StreamReader reader = File.OpenText(directory + @"\CokluSaglikArsivi\KulakBurunBogaz.txt");
            string metin;
            while ((metin = reader.ReadLine()) != null)
            {
                arsivGoruntuleme.lsbGoruntule.Items.Add(metin);
            }
            arsivGoruntuleme.Show();
            this.Hide();
        }

        private void btnDiyet_Click(object sender, EventArgs e)
        {
            SaglikArsivGoruntuleme arsivGoruntuleme = new SaglikArsivGoruntuleme();
            StreamReader reader = File.OpenText(directory + @"\CokluSaglikArsivi\Diyet.txt");
            string metin;
            while ((metin = reader.ReadLine()) != null)
            {
                arsivGoruntuleme.lsbGoruntule.Items.Add(metin);
            }
            arsivGoruntuleme.Show();
            this.Hide();
        }

        private void btnBebek_Click(object sender, EventArgs e)
        {
            SaglikArsivGoruntuleme arsivGoruntuleme = new SaglikArsivGoruntuleme();
            StreamReader reader = File.OpenText(directory + @"\CokluSaglikArsivi\BebekBakim.txt");
            string metin;
            while ((metin = reader.ReadLine()) != null)
            {
                arsivGoruntuleme.lsbGoruntule.Items.Add(metin);
            }
            arsivGoruntuleme.Show();
            this.Hide();
        }

      

        private void btnGuncel_Click(object sender, EventArgs e)
        {
            SaglikArsivGoruntuleme arsivGoruntuleme = new SaglikArsivGoruntuleme();
            StreamReader reader = File.OpenText(directory + @"\CokluSaglikArsivi\Vucut.txt");
            string metin;
            while ((metin = reader.ReadLine()) != null)
            {
                arsivGoruntuleme.lsbGoruntule.Items.Add(metin);
            }
            arsivGoruntuleme.Show();
            this.Hide();
        }

      
    
        private void btnVitamin_Click(object sender, EventArgs e)
        {
            SaglikArsivGoruntuleme arsivGoruntuleme = new SaglikArsivGoruntuleme();
            StreamReader reader = File.OpenText(directory + @"\CokluSaglikArsivi\VitaminTakviyesi.txt");
            string metin;
            while ((metin = reader.ReadLine()) != null)
            {
                arsivGoruntuleme.lsbGoruntule.Items.Add(metin);
            }
            arsivGoruntuleme.Show();
            this.Hide();
        }

        private void btnMide_Click(object sender, EventArgs e)
        {
            SaglikArsivGoruntuleme arsivGoruntuleme = new SaglikArsivGoruntuleme();
            StreamReader reader = File.OpenText(directory + @"\CokluSaglikArsivi\MideHastalik.txt");
            string metin;
            while ((metin = reader.ReadLine()) != null)
            {
                arsivGoruntuleme.lsbGoruntule.Items.Add(metin);
            }
            arsivGoruntuleme.Show();
            this.Hide();
        }

        private void btnAlerji_Click(object sender, EventArgs e)
        {
            SaglikArsivGoruntuleme arsivGoruntuleme = new SaglikArsivGoruntuleme();
            StreamReader reader = File.OpenText(directory + @"\CokluSaglikArsivi\Alerjiler.txt");
            string metin;
            while ((metin = reader.ReadLine()) != null)
            {
                arsivGoruntuleme.lsbGoruntule.Items.Add(metin);
            }
            arsivGoruntuleme.Show();
            this.Hide();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            GenelMenu anaMenuForm = new GenelMenu();
            anaMenuForm.Show();
            this.Hide();
        }

        private void btnAlt_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
