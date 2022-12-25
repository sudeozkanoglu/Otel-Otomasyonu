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
    public partial class Rezervasyon : Form
    {
        public Rezervasyon()
        {
            InitializeComponent();
        }

        private void btnOdaOlus_Click(object sender, EventArgs e)
        {
            this.Hide();
            rezervasyonOlustur rezervasyonOlustur = new rezervasyonOlustur();  
            rezervasyonOlustur.ShowDialog();
        }

        private void btnOdaIptal_Click(object sender, EventArgs e)
        {
            this.Hide();
            rezervasyonIptal rezervasyonIptal = new rezervasyonIptal();
            rezervasyonIptal.ShowDialog();
        }

        private void btnOdaGuncel_Click(object sender, EventArgs e)
        {
            this.Hide();
            rezervasyonGuncelleme rezervasyonGuncelleme = new rezervasyonGuncelleme();
            rezervasyonGuncelleme.ShowDialog();
        }


        private void btnAna_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Close();
            form1.Show();
        }
    }
}
