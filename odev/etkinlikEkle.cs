using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace odev
{
    public partial class etkinlikEkle : Form
    {
        public etkinlikEkle()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user Id=postgres; password=12345");
        int calisanNo = 0;
        string calisanTür = "";
        int etkinlikID;
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO etkinlik (\"etkinlikAdi\",\"etkinlikKontenjan\",\"etkinlikTarih\",\"hedefKitle\",\"etkinlikSaat\",\"otelID\",\"calisanNo\") VALUES (@k1,@k2,@k3,@k4,@k5,@k6,@k7)", baglanti);
                command.Parameters.AddWithValue("@k1", txtEtkinlikAd.Text);
                command.Parameters.AddWithValue("@k2", int.Parse(txtKontenjan.Text));
                command.Parameters.AddWithValue("@k3", dtpEtkinlikTarih.Value);
                command.Parameters.AddWithValue("@k4", cmbKimIcin.Text);
                command.Parameters.AddWithValue("@k5", txtEtkinlikSaat.Text);
                command.Parameters.AddWithValue("@k6", 1);
                command.Parameters.AddWithValue("@k7", int.Parse(txtCalNo1.Text));
                command.ExecuteNonQuery();
                baglanti.Close();

                baglanti.Open();
                NpgsqlCommand command40 = new NpgsqlCommand("SELECT \"etkinlikID\" FROM \"etkinlik\"", baglanti);
                NpgsqlDataReader dataReader40 = command40.ExecuteReader();
                while (dataReader40.Read())
                {
                    etkinlikID = int.Parse(dataReader40["etkinlikID"].ToString());
                }
                baglanti.Close();


                MessageBox.Show("Etknlik Basariyla Kaydedildi. Etkinlik ID =" + etkinlikID);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Etkinlik Kontenjan Sınırını Aştınız !");
                System.Environment.Exit(0);
            }
        }

        private void txtCalNo1_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand command2 = new NpgsqlCommand("SELECT \"calisanTür\" FROM calisan WHERE \"calisanNo\"='" + int.Parse(txtCalNo1.Text) + "'", baglanti);
            NpgsqlDataReader dataReader = command2.ExecuteReader();
            while (dataReader.Read())
            {
                calisanTür = dataReader["calisanTür"].ToString();
            }
            baglanti.Close();

            if (calisanTür == "Kadrolu")
            {
                baglanti.Open();
                NpgsqlCommand command3 = new NpgsqlCommand("SELECT * FROM \"calisan\" INNER JOIN \"kadroluCalisan\" ON \"calisan\".\"calisanNo\" = \"kadroluCalisan\".\"calisanNo\" WHERE \"kadroluCalisan\".\"calisanNo\"='" + int.Parse(txtCalNo1.Text) + "'", baglanti);
                NpgsqlDataReader dataReader2 = command3.ExecuteReader();

                while (dataReader2.Read())
                {
                    txtCalTC1.Text = dataReader2["kadroluTC"].ToString();
                    txtCalAd1.Text = dataReader2["calisanAd"].ToString();
                    txtCalSoayd1.Text = dataReader2["calisanSoyad"].ToString();
                    cmbCalCin1.Text = dataReader2["cinsiyet"].ToString();
                }
                baglanti.Close();
            }
            else
            {
                baglanti.Open();
                NpgsqlCommand command4 = new NpgsqlCommand("SELECT * FROM \"calisan\" INNER JOIN \"sezonlukCalisan\" ON \"calisan\".\"calisanNo\" = \"sezonlukCalisan\".\"calisanNo\" WHERE \"sezonlukCalisan\".\"calisanNo\"='" + int.Parse(txtCalNo1.Text) + "'", baglanti);
                NpgsqlDataReader dataReader3 = command4.ExecuteReader();

                while (dataReader3.Read())
                {
                    txtCalTC1.Text = dataReader3["sezonlukTC"].ToString();
                    txtCalAd1.Text = dataReader3["calisanAd"].ToString();
                    txtCalSoayd1.Text = dataReader3["calisanSoyad"].ToString();
                    cmbCalCin1.Text = dataReader3["cinsiyet"].ToString();
                }
                baglanti.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            etkinlik etkinlik = new etkinlik();
            this.Close();
            etkinlik.ShowDialog();
        }
    }
}
