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
    public partial class oda : Form
    {
        public oda()
        {
            InitializeComponent();
        }

        private void btnOdaEkle_Click(object sender, EventArgs e)
        {
            this.Close();
            odaEkle odaEkle = new odaEkle();
            odaEkle.ShowDialog();
        }

        private void btnOdaGüncelle_Click(object sender, EventArgs e)
        {
            this.Hide();
            odaGüncelle odaGüncelle = new odaGüncelle();
            odaGüncelle.ShowDialog();
        }

        private void btnOdaSil_Click(object sender, EventArgs e)
        {
            this.Hide();
            odaSil odaSil = new odaSil();
            odaSil.ShowDialog();
        }

        private void btnOdaListe_Click(object sender, EventArgs e)
        {
            this.Hide();
            odaListele odaListele = new odaListele();
            odaListele.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            otelIslemleri otelIslemleri = new otelIslemleri();
            this.Close();
            otelIslemleri.ShowDialog();
        }

        private void oda_Load(object sender, EventArgs e)
        {

        }
    }
}
