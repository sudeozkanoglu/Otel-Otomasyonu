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
    public partial class odaListele : Form
    {
        public odaListele()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user Id=postgres; password=12345");
        DataSet dataSet = new DataSet();
        int odaTurID = 0;
        int odaTurID2 = 0;
        private void odaListele_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter("SELECT * FROM \"oda\" INNER JOIN \"odaTur\" ON \"oda\".\"odaTurID\" = \"odaTur\".\"odaTurID\"", baglanti);
            adapter.Fill(dataSet, "oda");
            adapter.Fill(dataSet, "odaTur");
            dataGridViewOda.DataSource = dataSet.Tables["oda"];
            dataGridViewOda.DataSource = dataSet.Tables["odaTur"];
            baglanti.Close();
        }

        private void txtOdaNo_TextChanged(object sender, EventArgs e)
        {
            dataSet.Tables.Clear();
            baglanti.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT \"odaTurID\" FROM \"oda\" WHERE \"odaNo\"='" + int.Parse(txtOdaNo.Text) + "'", baglanti);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                odaTurID = int.Parse(reader["odaTurID"].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command2 = new NpgsqlCommand("SELECT \"odaTurID\" FROM \"odaTur\"", baglanti);
            NpgsqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                odaTurID2 = int.Parse(reader2["odaTurID"].ToString());
            }
            baglanti.Close();

            if (odaTurID == odaTurID2)
            {
                baglanti.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter("SELECT \"odaID\", \"odaNo\" ,\"odaKat\", \"odaManzara\",\"odaTurAdi\",\"odaFiyat\" FROM \"oda\" INNER JOIN \"odaTur\" ON \"oda\".\"odaTurID\" = \"odaTur\".\"odaTurID\" WHERE \"odaNo\"='" + int.Parse(txtOdaNo.Text) + "'", baglanti);
                adapter.Fill(dataSet, "oda");
                adapter.Fill(dataSet, "odaTur");
                dataGridViewOda.DataSource = dataSet.Tables["oda"];
                dataGridViewOda.DataSource = dataSet.Tables["odaTur"];
                baglanti.Close();
            }
            else 
            {
                MessageBox.Show("Bu Oda Numarasına Ait Bilgi Bulunamadı");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oda oda = new oda();
            this.Close();
            oda.ShowDialog();
        }
    }
}
