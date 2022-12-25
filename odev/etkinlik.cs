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
    public partial class etkinlik : Form
    {
        public etkinlik()
        {
            InitializeComponent();
        }

        private void btnEtkinlikEkle_Click(object sender, EventArgs e)
        {
            this.Hide();
            etkinlikEkle etkinlikEkle = new etkinlikEkle();
            etkinlikEkle.ShowDialog();
        }

        private void btnEtkinlikGüncelle_Click(object sender, EventArgs e)
        {
            this.Hide();
            etkinlikGüncelle etkinlikGüncelle = new etkinlikGüncelle();
            etkinlikGüncelle.ShowDialog();
        }

        private void btnEtkinlikSil_Click(object sender, EventArgs e)
        {
            this.Hide();
            etkinlikSil etkinlikSil = new etkinlikSil();
            etkinlikSil.ShowDialog();
        }

        private void btnEtkinlikListele_Click(object sender, EventArgs e)
        {
            this.Hide();
            etkinlikListele etkinlikListele = new etkinlikListele();
            etkinlikListele.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            otelIslemleri otelIslemleri = new otelIslemleri();
            this.Close();
            otelIslemleri.ShowDialog();
        }
    }
}
