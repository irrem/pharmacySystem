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
    public partial class SaglikArsivGoruntuleme : Form
    {
        public SaglikArsivGoruntuleme()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SaglikArsiv ekleArsiv = new SaglikArsiv();
            ekleArsiv.Show();
            this.Hide();
        }

        private void SaglikArsivGoruntuleme_Load(object sender, EventArgs e)
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
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GenelMenu anaMenuForm = new GenelMenu();
            anaMenuForm.Show();
            this.Hide();
        }

        private void lsbGoruntule_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
