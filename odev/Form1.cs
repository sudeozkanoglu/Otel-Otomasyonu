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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRezervasyon_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rezervasyon rezervasyon = new Rezervasyon();
            rezervasyon.ShowDialog();
        }

        private void btnHotel_Click(object sender, EventArgs e)
        {
            this.Hide();
            hotel hotel = new hotel();
            hotel.ShowDialog();
        }
    }
}
