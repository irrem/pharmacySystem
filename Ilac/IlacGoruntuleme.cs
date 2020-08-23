using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EczaneOtomasyon.Metot;

namespace EczaneOtomasyon
{
    public partial class IlacGoruntuleme : Form
    {
        public IlacGoruntuleme()
        {
            InitializeComponent();
        }
        Ilac ilac = new Ilac();
        private void btnEkle_Click(object sender, EventArgs e)
        {
            IlacBilgileri ilacBilgileriForm = new IlacBilgileri();
            ilacBilgileriForm.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GenelMenu anaMenuForm = new GenelMenu();
            this.Close();
            anaMenuForm.Show();
            this.Close();
        }
        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IlacBilgileri GnclFrm = new IlacBilgileri();

            GnclFrm.ilacLbl.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            GnclFrm.ilacAdTxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            GnclFrm.receteCesit.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            GnclFrm.receteTxt.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            GnclFrm.ilacKategoriCombo.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            GnclFrm.ilacMarkaTxt.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            GnclFrm.destekTxt.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            GnclFrm.fiyatTxt.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            GnclFrm.indirimliFiyatTxt.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            GnclFrm.stokTxt.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            GnclFrm.gramTxt.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            GnclFrm.Show();
;
        }

        private void IlacGoruntuleme_Load(object sender, EventArgs e)
        {

            arananGelsin(tbxAramaIlac.Text);
        }
        private void arananGelsin(string ara)
        {
            if (ara =="")
            {
                dataGridView1.DataSource = ilac.Getir();
            }
            else
            {
                dataGridView1.DataSource = ilac.Getir(ara);
            }
        }

        public void btnGuncelleIlac_Click(object sender, EventArgs e)

        {
            try{
                dataGridView1.DataSource = ilac.Getir();
            IlacBilgileri GnclFrm = new IlacBilgileri();

            GnclFrm.Show();

            GnclFrm.ilacLbl.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            GnclFrm.ilacAdTxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            GnclFrm.receteCesit.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            GnclFrm.receteTxt.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            GnclFrm.ilacKategoriCombo.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            GnclFrm.ilacMarkaTxt.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            GnclFrm.destekTxt.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            GnclFrm.fiyatTxt.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            GnclFrm.indirimliFiyatTxt.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            GnclFrm.stokTxt.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            GnclFrm.gramTxt.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();


            this.Hide();
            //ilac.ilacSil(ilac);
            dataGridView1.DataSource = ilac.Getir();
            }
            catch (Exception _hata)
            {
                MessageBox.Show("Hata!" + _hata);
            }

        }

        private void btnIlacSil_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = ilac.Getir();
               // ilac.ilacId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

                ilac.ilacSil(ilac.ilacId);
                MessageBox.Show("Başarıyla Silindi");
                //ilac.ilacSil(ilac);
                dataGridView1.DataSource = ilac.Getir();
            }
            catch(Exception _hata)
            {
                MessageBox.Show("Hata!" + _hata);
            }
        }

        private void tbxArama_TextChanged(object sender, EventArgs e)
        {
            arananGelsin(tbxAramaIlac.Text);
        }

        private void cbxKategori_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = ilac.GetirKategori(ilacKategoriCombo.SelectedItem.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Minimized;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ilac.ilacId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
        }
    }
}
