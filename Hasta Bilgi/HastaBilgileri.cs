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

namespace EczaneOtomasyon.Hasta_Bilgi
{
    public partial class HastaBilgileri : Form
    {
        public HastaBilgileri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YeniHasta yeniHastaForm = new YeniHasta();
            yeniHastaForm.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GenelMenu anaMenuForm = new GenelMenu();
            anaMenuForm.Show();
            this.Hide();
        }

        YeniHastaKod yeniHastaKod = new YeniHastaKod();     
        private void HastaBilgileri_Load(object sender, EventArgs e)
        {
            dgwHastaGoruntuleme.DataSource = yeniHastaKod.GetAll();
        }
        YeniHasta yeniHasta = new YeniHasta();
        private void dgwHastaGoruntuleme_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            yeniHasta.tbxAd.Text = dgwHastaGoruntuleme.CurrentRow.Cells[1].Value.ToString();
            yeniHasta.tbxSoyad.Text= dgwHastaGoruntuleme.CurrentRow.Cells[2].Value.ToString();
            yeniHasta.tbxTc.Text= dgwHastaGoruntuleme.CurrentRow.Cells[3].Value.ToString();
            yeniHasta.cbxCinsiyet.Text= dgwHastaGoruntuleme.CurrentRow.Cells[4].Value.ToString();
            yeniHasta.tbxDogum.Text= dgwHastaGoruntuleme.CurrentRow.Cells[5].Value.ToString();
            yeniHasta.tbxTelefon.Text= dgwHastaGoruntuleme.CurrentRow.Cells[6].Value.ToString();
            yeniHasta.tbxHastalık.Text= dgwHastaGoruntuleme.CurrentRow.Cells[7].Value.ToString();
            yeniHasta.tbxIlac.Text= dgwHastaGoruntuleme.CurrentRow.Cells[8].Value.ToString();
            yeniHasta.tbxAdres.Text= dgwHastaGoruntuleme.CurrentRow.Cells[9].Value.ToString();
            yeniHasta.cbxSaglik.Text= dgwHastaGoruntuleme.CurrentRow.Cells[10].Value.ToString();
            yeniHasta.tbxAlerji.Text= dgwHastaGoruntuleme.CurrentRow.Cells[11].Value.ToString();
            yeniHasta.HastaId = Convert.ToInt32(dgwHastaGoruntuleme.CurrentRow.Cells[0].Value);

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            this.Hide();
            yeniHasta.ShowDialog();
           
        }

      
        private void btnArama_TextChanged(object sender, EventArgs e)
        {
            dgwHastaGoruntuleme.DataSource = yeniHastaKod.Search(tbxArama.Text);
        }

        private void btnSilme_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgwHastaGoruntuleme.CurrentRow.Cells[0].Value);
            yeniHastaKod.Delete(id);
         
            if (MessageBox.Show("Silmek istediğine emin misiniz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Eczacı Sistemimize Başarıyla Silinmiştir");
            }
            HastaGoruntule();


        }
        public void HastaGoruntule()
        {
            dgwHastaGoruntuleme.DataSource = yeniHastaKod.GetAll();
        }

        private void button1_Click_1(object sender, EventArgs e)
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
    }
}
