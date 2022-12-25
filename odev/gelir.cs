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
    public partial class gelir : Form
    {
        public gelir()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user Id=postgres; password=12345");
        DataSet dataSet = new DataSet();
        private void button1_Click(object sender, EventArgs e)
        {
            otelIslemleri otelIslemleri = new otelIslemleri();
            this.Close();
            otelIslemleri.ShowDialog();
        }

        private void gelir_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter("SELECT * FROM \"gelir\"", baglanti);
            adapter.Fill(dataSet, "gelir");
            dataGridViewGelir.DataSource = dataSet.Tables["gelir"];
            baglanti.Close();
        }

        private void txtGelirNo_TextChanged(object sender, EventArgs e)
        {
            dataSet.Tables.Clear();
            baglanti.Open();
            NpgsqlDataAdapter adapter2 = new NpgsqlDataAdapter("SELECT * FROM \"gelir\" WHERE \"gelirNo\"='" + int.Parse(txtGelirNo.Text) + "'", baglanti);
            adapter2.Fill(dataSet, "gelir");
            dataGridViewGelir.DataSource = dataSet.Tables["gelir"];
            baglanti.Close();
        }
    }
}
