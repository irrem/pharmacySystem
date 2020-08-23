using EczaneOtomasyon.Hasta_Bilgi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EczaneOtomasyon.Hastane;


namespace EczaneOtomasyon
{
    public partial class GenelMenu : Form
    {
        public GenelMenu()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormKasa formKasa = new FormKasa();
            formKasa.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HastaBilgileri hastaBilgiForm = new HastaBilgileri();
            hastaBilgiForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DigerUrunler digerUrunlerForm = new DigerUrunler();
            digerUrunlerForm.Show();
            this.Hide();

        }

        private void hastaneButon_Click(object sender, EventArgs e)
        {
            AnlasmaliHastane anlasmaliHastaneForm = new AnlasmaliHastane();
            anlasmaliHastaneForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IlacGoruntuleme ilacBilgileriForm = new IlacGoruntuleme();
            ilacBilgileriForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            SaglikArsiv ekleArsiv = new SaglikArsiv();
            ekleArsiv.Show();
            this.Hide(); 
            
        }

        private void ECZANE_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Minimized;
        }
    }
}
