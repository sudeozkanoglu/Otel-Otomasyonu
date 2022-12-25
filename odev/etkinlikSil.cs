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
    public partial class etkinlikSil : Form
    {
        public etkinlikSil()
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

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM \"etkinlik\"  WHERE \"etkinlikID\"='" + int.Parse(textBox19.Text) + "'", baglanti);
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
                    cmbCalCin1.Text = dataReader3["cinsiyet"].ToString();
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
                    cmbCalCin1.Text = dataReader4["cinsiyet"].ToString();
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand command5 = new NpgsqlCommand("DELETE FROM \"etkinlik\" WHERE \"etkinlikID\"=(@k1)", baglanti);
            command5.Parameters.AddWithValue("@k1", int.Parse(textBox19.Text));
            command5.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Etkinlik Basariyla Silindi");

        }
    }
}
