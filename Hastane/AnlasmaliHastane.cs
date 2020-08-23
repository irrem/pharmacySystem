using EczaneOtomasyon.Hastane;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczaneOtomasyon.Hastane
{
    public partial class AnlasmaliHastane : Form
    {
        public AnlasmaliHastane()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GenelMenu anaMenuForm = new GenelMenu();
            anaMenuForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnlasmaliHastaneMetotlar _hstn = new AnlasmaliHastaneMetotlar();
            _hstn.hastaneAd = hstnAdTxt.Text;
            _hstn.hastaneAdres = hstnAdresTxt.Text;
            _hstn.telefonHastane = hstnTelNoTxt.Text;
            _hstn.KaydetHastane(_hstn);

            anlasmaliHastaneDatagrid.DataSource = anlasmaliHastne_.GetirHastaneler();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        AnlasmaliHastaneMetotlar anlasmaliHastne_ = new AnlasmaliHastaneMetotlar(); 
        private void AnlasmaliHastane_Load(object sender, EventArgs e)
        {
            anlasmaliHastaneDatagrid.DataSource = anlasmaliHastne_.GetirHastaneler();
        }

        private void btnHstnSil_Click(object sender, EventArgs e)
        {
            anlasmaliHastne_.hastaneId = Convert.ToInt32(anlasmaliHastaneDatagrid.CurrentRow.Cells[0].Value);
            anlasmaliHastne_.SilHastane(anlasmaliHastne_.hastaneId);
            MessageBox.Show("Seçiminiz başarıyla silinmiştir.");

            anlasmaliHastaneDatagrid.DataSource = anlasmaliHastne_.GetirHastaneler();
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
