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
    public partial class odaGüncelle : Form
    {
        public odaGüncelle()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user Id=postgres; password=12345");
        int odaTurID = 0;
        private void txtOdaNo_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM \"oda\" WHERE \"odaNo\"='" + int.Parse(txtOdaNo.Text) + "'", baglanti);
            NpgsqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                cmbOdaKat.Text = dataReader["odaKat"].ToString();
                txtOdaManzara.Text = dataReader["odaManzara"].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command2 = new NpgsqlCommand("SELECT \"odaTurID\" FROM \"oda\" WHERE \"odaNo\"='" + int.Parse(txtOdaNo.Text) + "'", baglanti);
            NpgsqlDataReader dataReader2 = command2.ExecuteReader();
            while (dataReader2.Read())
            {
                odaTurID = int.Parse(dataReader2["odaTurID"].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command3 = new NpgsqlCommand("SELECT * FROM \"odaTur\" WHERE \"odaTurID\"='" + odaTurID + "'", baglanti);
            NpgsqlDataReader dataReader3 = command3.ExecuteReader();
            while (dataReader3.Read())
            {
                cmbOdaTur.Text = dataReader3["odaTurAdi"].ToString();
                txtOdaFiyat.Text = dataReader3["odaFiyat"].ToString();
            }
            baglanti.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand command4 = new NpgsqlCommand("UPDATE oda SET \"odaKat\"=@k1,\"odaManzara\"=@k2 WHERE \"odaNo\"='" + int.Parse(txtOdaNo.Text) + "'", baglanti);
            command4.Parameters.AddWithValue("@k1", int.Parse(cmbOdaKat.Text));
            command4.Parameters.AddWithValue("@k2", txtOdaManzara.Text);
            command4.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command5 = new NpgsqlCommand("UPDATE \"odaTur\" SET \"odaTurAdi\"=@k3, \"odaFiyat\"=@k4 WHERE \"odaTurID\"='" + odaTurID + "'", baglanti);
            command5.Parameters.AddWithValue("@k3", cmbOdaTur.Text);
            command5.Parameters.AddWithValue("@k4", int.Parse(txtOdaFiyat.Text));
            command5.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Oda Bilgileri Basariyla Güncellendi");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oda oda = new oda();
            this.Close();
            oda.ShowDialog();
        }
    }
}
