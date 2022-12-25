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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace odev
{
    public partial class etkinlikGüncelle : Form
    {
        public etkinlikGüncelle()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user Id=postgres; password=12345");
        string calisanTür = "";
        private void button1_Click(object sender, EventArgs e)
        {
            etkinlik etkinlik = new etkinlik();
            this.Close();
            etkinlik.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM \"etkinlik\"  WHERE \"etkinlikID\"='" + int.Parse(textBox1.Text) + "'", baglanti);
            NpgsqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                txtEtkinlikAd.Text = dataReader["etkinlikAdi"].ToString();
                dtpEtkinlikTarih.Text = dataReader["etkinlikTarih"].ToString();
                txtEtkinlikSaat.Text = dataReader["etkinlikSaat"].ToString();
                txtKontenjan.Text = dataReader["etkinlikKontenjan"].ToString();
                cmbKimIcin.Text = dataReader["hedefKitle"].ToString();
                txtCalNo1.Text = dataReader["calisanNo"].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command2 = new NpgsqlCommand("SELECT \"calisanTür\" FROM calisan WHERE \"calisanNo\"='" + int.Parse(txtCalNo1.Text) + "'", baglanti);
            NpgsqlDataReader dataReader2 = command2.ExecuteReader();
            while (dataReader2.Read())
            {
                calisanTür = dataReader2["calisanTür"].ToString();
            }
            baglanti.Close();

            if (calisanTür == "Kadrolu")
            {
                baglanti.Open();
                NpgsqlCommand command3 = new NpgsqlCommand("SELECT * FROM \"calisan\" INNER JOIN \"kadroluCalisan\" ON \"calisan\".\"calisanNo\" = \"kadroluCalisan\".\"calisanNo\" WHERE \"kadroluCalisan\".\"calisanNo\"='" + int.Parse(txtCalNo1.Text) + "'", baglanti);
                NpgsqlDataReader dataReader3 = command3.ExecuteReader();

                while (dataReader3.Read())
                {
                    txtCalTC1.Text = dataReader3["kadroluTC"].ToString();
                    txtCalAd1.Text = dataReader3["calisanAd"].ToString();
                    txtCalSoayd1.Text = dataReader3["calisanSoyad"].ToString();
                    txtCinsiyet.Text = dataReader3["cinsiyet"].ToString();
                }
                baglanti.Close();
            }
            else
            {
                baglanti.Open();
                NpgsqlCommand command4 = new NpgsqlCommand("SELECT * FROM \"calisan\" INNER JOIN \"sezonlukCalisan\" ON \"calisan\".\"calisanNo\" = \"sezonlukCalisan\".\"calisanNo\" WHERE \"sezonlukCalisan\".\"calisanNo\"='" + int.Parse(txtCalNo1.Text) + "'", baglanti);
                NpgsqlDataReader dataReader4 = command4.ExecuteReader();

                while (dataReader4.Read())
                {
                    txtCalTC1.Text = dataReader4["sezonlukTC"].ToString();
                    txtCalAd1.Text = dataReader4["calisanAd"].ToString();
                    txtCalSoayd1.Text = dataReader4["calisanSoyad"].ToString();
                    txtCinsiyet.Text = dataReader4["cinsiyet"].ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                NpgsqlCommand command5 = new NpgsqlCommand("UPDATE \"etkinlik\" SET \"etkinlikAdi\"=@h1,\"etkinlikTarih\"=@h2,\"etkinlikSaat\"=@h3,\"etkinlikKontenjan\"=@h4,\"hedefKitle\"=@h5 WHERE \"etkinlikID\"='" + int.Parse(textBox1.Text) + "'", baglanti);
                command5.Parameters.AddWithValue("@h1", txtEtkinlikAd.Text);
                command5.Parameters.AddWithValue("@h2", dtpEtkinlikTarih.Value);
                command5.Parameters.AddWithValue("@h3", txtEtkinlikSaat.Text);
                command5.Parameters.AddWithValue("@h4", int.Parse(txtKontenjan.Text));
                command5.Parameters.AddWithValue("@h5", cmbKimIcin.Text);
                command5.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Etkinlik Basariyla Güncellendi");
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Kontenjan Sınırını Aştınız !");
                System.Environment.Exit(0);
            }
        }
    }
}
