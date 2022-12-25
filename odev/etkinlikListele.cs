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
    public partial class etkinlikListele : Form
    {
        public etkinlikListele()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user Id=postgres; password=12345");
        DataSet dataSet = new DataSet();
        string calisanTür = "";
        private void txtEtkinlikID_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();

        }

        private void etkinlikListele_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter("SELECT \"etkinlikID\",\"etkinlikAdi\",\"etkinlikKontenjan\",\"etkinlikTarih\",\"hedefKitle\",\"etkinlikSaat\",\"kadroluTC\",\"calisanAd\",\"calisanSoyad\",\"cinsiyet\" FROM \"etkinlik\" INNER JOIN \"calisan\" ON \"etkinlik\".\"calisanNo\" = \"calisan\".\"calisanNo\" INNER JOIN \"kadroluCalisan\" ON \"etkinlik\".\"calisanNo\" = \"kadroluCalisan\".\"calisanNo\"",baglanti);
            adapter.Fill(dataSet, "etkinlik");
            adapter.Fill(dataSet, "calisan");
            adapter.Fill(dataSet, "kadroluCalisan");
            dataGridViewEtkinlik.DataSource = dataSet.Tables["etkinlik"];
            dataGridViewEtkinlik.DataSource = dataSet.Tables["calisan"];
            dataGridViewEtkinlik.DataSource = dataSet.Tables["kadroluCalisan"];
            baglanti.Close();

            baglanti.Open();
            NpgsqlDataAdapter adapter2 = new NpgsqlDataAdapter("SELECT \"etkinlikID\",\"etkinlikAdi\",\"etkinlikKontenjan\",\"etkinlikTarih\",\"hedefKitle\",\"etkinlikSaat\",\"sezonlukTC\",\"calisanAd\",\"calisanSoyad\",\"cinsiyet\"  FROM \"etkinlik\" INNER JOIN \"calisan\" ON \"etkinlik\".\"calisanNo\" = \"calisan\".\"calisanNo\" INNER JOIN \"sezonlukCalisan\" ON \"etkinlik\".\"calisanNo\" = \"sezonlukCalisan\".\"calisanNo\"", baglanti);
            adapter2.Fill(dataSet, "etkinlik");
            adapter2.Fill(dataSet, "calisan");
            adapter2.Fill(dataSet, "sezonlukCalisan");
            dataGridViewEtkinlik.DataSource = dataSet.Tables["etkinlik"];
            dataGridViewEtkinlik.DataSource = dataSet.Tables["calisan"];
            dataGridViewEtkinlik.DataSource = dataSet.Tables["sezonlukCalisan"];
            baglanti.Close();
        }
    }
}
