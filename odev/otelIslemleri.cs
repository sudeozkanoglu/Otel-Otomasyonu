using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace odev
{
    public partial class otelIslemleri : Form
    {
        public otelIslemleri()
        {
            InitializeComponent();
        }

        private void otelIslemleri_Load(object sender, EventArgs e)
        {

        }

        private void btnGider_Click(object sender, EventArgs e)
        {
            this.Hide();
            gider gider = new gider();
            gider.ShowDialog();
        }

        private void btnOda_Click(object sender, EventArgs e)
        {
            this.Hide();
            oda oda = new oda();
            oda.ShowDialog();
        }

        private void btnEtkinlik_Click(object sender, EventArgs e)
        {
            this.Hide();
            etkinlik etkinlik = new etkinlik();
            etkinlik.ShowDialog();
        }

        private void btnGelir_Click(object sender, EventArgs e)
        {
            this.Hide();
            gelir gelir = new gelir();
            gelir.ShowDialog();
        }

        private void btnMenü_Click(object sender, EventArgs e)
        {
            hotel hotel = new hotel();
            this.Close();
            hotel.ShowDialog();
        }
    }
}
