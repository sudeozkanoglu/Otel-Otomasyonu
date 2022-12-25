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
    public partial class personelIslemleri : Form
    {
        public personelIslemleri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            calisanEkle calisanEkle = new calisanEkle();
            calisanEkle.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            calisanGüncelle calisanGüncelle = new calisanGüncelle();
            calisanGüncelle.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            calisanSil calisanSil = new calisanSil();
            calisanSil.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            calisanListele calisanListele = new calisanListele();
            calisanListele.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            hotel hotel = new hotel();
            this.Close();
            hotel.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            personelYakiniEkleme personelYakiniEkleme = new personelYakiniEkleme();
            personelYakiniEkleme.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            personelYakiniGüncelleme personelYakiniGüncelleme = new personelYakiniGüncelleme();
            personelYakiniGüncelleme.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            personelYakiniSilme personelYakiniSilme = new personelYakiniSilme();
            personelYakiniSilme.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            personelYakiniListeleme personelYakiniListeleme = new personelYakiniListeleme();
            personelYakiniListeleme.ShowDialog();
        }
    }
}
