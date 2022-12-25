using Npgsql;
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
    public partial class giderListele : Form
    {
        public giderListele()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user Id=postgres; password=12345");
        DataSet dataSet = new DataSet();
        int giderNo = 0;
        int giderNo2 = 0;

        private void giderListele_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter("SELECT * FROM \"gider\" ", baglanti);
            adapter.Fill(dataSet, "gider");
            dataGridViewGider.DataSource = dataSet.Tables["gider"];
            baglanti.Close();
        }

        private void txtGiderNo_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter("SELECT * FROM \"gider\"  WHERE \"giderNo\"='" + int.Parse(txtGiderNo.Text) + "'", baglanti);
            adapter.Fill(dataSet, "gider");
            dataGridViewGider.DataSource = dataSet.Tables["gider"];
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gider gider = new gider();
            this.Close();
            gider.ShowDialog();
        }
    }
}
