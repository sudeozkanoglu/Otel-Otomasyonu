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
    public partial class hotel : Form
    {
        public hotel()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            personelIslemleri personelIslemleri = new personelIslemleri();
            personelIslemleri.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            otelHakkinda otelHakkinda = new otelHakkinda();
            otelHakkinda.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            otelIslemleri otelIslemleri = new otelIslemleri();
            otelIslemleri.ShowDialog();
        }

        private void btnMenü_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Close();
            form1.ShowDialog();
        }
    }
}
