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
    public partial class personelYakiniListeleme : Form
    {
        public personelYakiniListeleme()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user Id=postgres; password=12345");
        DataSet dataSet = new DataSet();
        private void txtPersonelYakNo_TextChanged(object sender, EventArgs e)
        {
            dataSet.Tables.Clear();
            baglanti.Open();
            NpgsqlDataAdapter adapter3 = new NpgsqlDataAdapter("SELECT * FROM \"personelYakini\" INNER JOIN \"personelYakiniMusteri\" ON \"personelYakini\".\"personelYakiniNo\" = \"personelYakiniMusteri\".\"personelYakiniNo\" WHERE \"personelYakini\".\"personelYakiniNo\"='" + int.Parse(txtPersonelYakNo.Text) + "'", baglanti);
            adapter3.Fill(dataSet, "personelYakini");
            adapter3.Fill(dataSet, "personelYakiniMusteri");
            dataGridViewPersonel.DataSource = dataSet.Tables["personelYakini"];
            dataGridViewPersonel.DataSource = dataSet.Tables["personelYakiniMusteri"];
            baglanti.Close();
        }

        private void personelYakiniListeleme_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter("SELECT * FROM \"personelYakini\" INNER JOIN \"personelYakiniMusteri\" ON \"personelYakini\".\"personelYakiniNo\" = \"personelYakiniMusteri\".\"personelYakiniNo\"", baglanti);
            adapter.Fill(dataSet, "personelYakini");
            adapter.Fill(dataSet, "personelYakiniMusteri");
            dataGridViewPersonel.DataSource = dataSet.Tables["personelYakini"];
            dataGridViewPersonel.DataSource = dataSet.Tables["personelYakiniMusteri"];
            baglanti.Close();

            baglanti.Open();
            NpgsqlDataAdapter adapter2 = new NpgsqlDataAdapter("SELECT * FROM \"personelYakini\"", baglanti);
            adapter2.Fill(dataSet, "personelYakini");
            dataGridViewPersonel.DataSource = dataSet.Tables["personelYakini"];
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            personelIslemleri personelIslemleri = new personelIslemleri();
            this.Close();
            personelIslemleri.ShowDialog();
        }
    }
}
