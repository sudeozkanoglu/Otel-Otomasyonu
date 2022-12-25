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
    public partial class calisanListele : Form
    {
        public calisanListele()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user Id=postgres; password=12345");
        DataSet dataSet = new DataSet();
        string calisanTür = "";
        private void calisanListele_Load(object sender, EventArgs e)
        { 
            baglanti.Open();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter("SELECT * FROM \"calisan\" INNER JOIN \"kadroluCalisan\" ON \"calisan\".\"calisanNo\" = \"kadroluCalisan\".\"calisanNo\" INNER JOIN \"iletisimBilgileri\" ON \"calisan\".\"calisanNo\" = \"iletisimBilgileri\".\"calisanNo\"", baglanti);
            adapter.Fill(dataSet, "calisan");
            adapter.Fill(dataSet, "kadroluCalisan");
            adapter.Fill(dataSet, "iletisimBilgileri");
            dataGridViewCalisan.DataSource = dataSet.Tables["calisan"];
            dataGridViewCalisan.DataSource = dataSet.Tables["kadroluCalisan"];
            dataGridViewCalisan.DataSource = dataSet.Tables["iletisimBilgileri"];
            baglanti.Close();

            baglanti.Open();
            NpgsqlDataAdapter adapter2 = new NpgsqlDataAdapter("SELECT * FROM \"calisan\" INNER JOIN \"sezonlukCalisan\" ON \"calisan\".\"calisanNo\" = \"sezonlukCalisan\".\"calisanNo\" INNER JOIN \"iletisimBilgileri\" ON \"calisan\".\"calisanNo\" = \"iletisimBilgileri\".\"calisanNo\"", baglanti);
            adapter2.Fill(dataSet, "calisan");
            adapter2.Fill(dataSet, "sezonlukCalisan");
            adapter2.Fill(dataSet, "iletisimBilgileri");
            dataGridViewCalisan.DataSource = dataSet.Tables["calisan"];
            dataGridViewCalisan.DataSource = dataSet.Tables["sezonlukCalisan"];
            dataGridViewCalisan.DataSource = dataSet.Tables["iletisimBilgileri"];
            baglanti.Close();
        }

        private void txtCalisanNo_TextChanged(object sender, EventArgs e)
        {
            dataSet.Tables.Clear();
            baglanti.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT \"calisanTür\"FROM calisan WHERE \"calisanNo\"='" + int.Parse(txtCalisanNo.Text) + "' ", baglanti);
            NpgsqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                calisanTür = dataReader["calisanTür"].ToString();
            }
            baglanti.Close();


            if (calisanTür == "Kadrolu")
            {
                baglanti.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter("SELECT * FROM \"calisan\" INNER JOIN \"kadroluCalisan\" ON \"calisan\".\"calisanNo\" = \"kadroluCalisan\".\"calisanNo\" INNER JOIN \"iletisimBilgileri\" ON \"calisan\".\"calisanNo\" = \"iletisimBilgileri\".\"calisanNo\" WHERE \"calisan\".\"calisanNo\"='" + int.Parse(txtCalisanNo.Text) + "'", baglanti);
                adapter.Fill(dataSet, "calisan");
                adapter.Fill(dataSet, "kadroluCalisan");
                adapter.Fill(dataSet, "iletisimBilgileri");
                dataGridViewCalisan.DataSource = dataSet.Tables["calisan"];
                dataGridViewCalisan.DataSource = dataSet.Tables["kadroluCalisan"];
                dataGridViewCalisan.DataSource = dataSet.Tables["iletisimBilgileri"];
                baglanti.Close();
            }
            else 
            {
                baglanti.Open();
                NpgsqlDataAdapter adapter2 = new NpgsqlDataAdapter("SELECT * FROM \"calisan\" INNER JOIN \"sezonlukCalisan\" ON \"calisan\".\"calisanNo\" = \"sezonlukCalisan\".\"calisanNo\" INNER JOIN \"iletisimBilgileri\" ON \"calisan\".\"calisanNo\" = \"iletisimBilgileri\".\"calisanNo\" WHERE \"calisan\".\"calisanNo\"='" + int.Parse(txtCalisanNo.Text) + "'", baglanti);
                adapter2.Fill(dataSet, "calisan");
                adapter2.Fill(dataSet, "sezonlukCalisan");
                adapter2.Fill(dataSet, "iletisimBilgileri");
                dataGridViewCalisan.DataSource = dataSet.Tables["calisan"];
                dataGridViewCalisan.DataSource = dataSet.Tables["sezonlukCalisan"];
                dataGridViewCalisan.DataSource = dataSet.Tables["iletisimBilgileri"];
                baglanti.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewCalisan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            personelIslemleri personelIslemleri = new personelIslemleri();
            this.Close();
            personelIslemleri.ShowDialog();
        }
    }
}
