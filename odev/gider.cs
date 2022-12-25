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
    public partial class gider : Form
    {
        public gider()
        {
            InitializeComponent();
        }

        private void btnGiderEkle_Click(object sender, EventArgs e)
        {
            this.Hide();
            giderEkle giderEkle = new giderEkle();
            giderEkle.ShowDialog();
        }

        private void btnGiderGüncelle_Click(object sender, EventArgs e)
        {
            this.Hide();
            giderDüzenle giderDüzenle = new giderDüzenle();
            giderDüzenle.ShowDialog();
        }

        private void btnGiderSil_Click(object sender, EventArgs e)
        {
            this.Hide();
            giderSil giderSil = new giderSil();
            giderSil.ShowDialog();
        }

        private void btnGiderListele_Click(object sender, EventArgs e)
        {
            this.Hide();
            giderListele giderListele = new giderListele();
            giderListele.ShowDialog();
        }

        private void btnMenü_Click(object sender, EventArgs e)
        {
            otelIslemleri otelIslemleri = new otelIslemleri();
            this.Close();
            otelIslemleri.ShowDialog();
        }
    }
}
