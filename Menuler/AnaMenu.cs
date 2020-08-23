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
    public partial class AnaMenu : Form
    {
        public AnaMenu()
        {
            InitializeComponent();
        }

        private void btnPersonel_Click(object sender, EventArgs e)
        {
            PersonelGirisi personelGirisi = new PersonelGirisi();
            personelGirisi.Show();
            this.Hide();
        }

        private void AnaMenu_Load(object sender, EventArgs e)
        {
            
        }

        private void btnYonetici_Click(object sender, EventArgs e)
        {
            YoneticiGirisi yoneticiGirisi = new YoneticiGirisi();
            yoneticiGirisi.Show();
            this.Hide();
        }

        private void btnYonetici_MouseHover(object sender, EventArgs e)
        {
            btnYonetici.BackColor = Color.FromArgb(39, 73, 109);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hakkinda hakkinda = new Hakkinda();
            hakkinda.Show();

        }
    }
}
