using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace odev
{
    public partial class personelYakiniGüncelleme : Form
    {
        public personelYakiniGüncelleme()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user Id=postgres; password=12345");
        string calisanTür = "";
        int calisanNo = 0;
        private void txtPersonelYakiniNo_TextChanged(object sender, EventArgs e)
        {
           baglanti.Open();
           NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM \"personelYakini\" INNER JOIN \"iletisimBilgileri\" ON \"personelYakini\".\"personelYakiniNo\" = \"iletisimBilgileri\".\"personelYakiniNo\"  WHERE \"personelYakini\".\"personelYakiniNo\"='" + int.Parse(txtPersonelYakiniNo.Text) + "'", baglanti);
           NpgsqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                txtTC.Text = dataReader["personelYakiniTC"].ToString();
                txtIsim.Text = dataReader["personelYakiniAd"].ToString();
                txtSoyisim.Text = dataReader["personelYakiniSoyad"].ToString();
                cmbCinsiyet.Text = dataReader["cinsiyet"].ToString();
                dateTimePicker1.Text = dataReader["dogumTarihi"].ToString();
                cmbMedeni.Text = dataReader["medeniHal"].ToString();
                txtTelefon.Text = dataReader["telefonNo"].ToString();
                txtAdres.Text = dataReader["adres"].ToString();
                txtIl.Text = dataReader["il"].ToString();
                txtIlce.Text = dataReader["ilce"].ToString();
                txtPostaKodu.Text = dataReader["postaKodu"].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command8 = new NpgsqlCommand("SELECT \"calisanNo\" FROM \"personelYakini\" WHERE \"personelYakiniNo\"='" + int.Parse(txtPersonelYakiniNo.Text) + "'", baglanti);
            NpgsqlDataReader dataReader1 = command8.ExecuteReader();
            while (dataReader1.Read())
            {
                calisanNo = int.Parse(dataReader1["calisanNo"].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command2 = new NpgsqlCommand("SELECT \"calisanTür\" FROM calisan WHERE \"calisanNo\"='" + calisanNo + "'", baglanti);
            NpgsqlDataReader dataReader2 = command2.ExecuteReader();

            while (dataReader2.Read())
            {
                calisanTür = dataReader2["calisanTür"].ToString();
            }
            baglanti.Close();

            if (calisanTür == "Kadrolu")
            {
                baglanti.Open();
                NpgsqlCommand command3 = new NpgsqlCommand("SELECT * FROM \"calisan\" INNER JOIN \"kadroluCalisan\" ON \"calisan\".\"calisanNo\" = \"kadroluCalisan\".\"calisanNo\" WHERE \"kadroluCalisan\".\"calisanNo\"='" + calisanNo + "'", baglanti);
                NpgsqlDataReader dataReader3 = command3.ExecuteReader();

                while (dataReader3.Read())
                {
                    txtCalNo.Text = dataReader3["calisanNo"].ToString();
                    txtCalTC.Text = dataReader3["kadroluTC"].ToString();
                    txtCalAd.Text = dataReader3["calisanAd"].ToString();
                    txtCalSoyad.Text = dataReader3["calisanSoyad"].ToString();
                    txtDepartman.Text = dataReader3["departman"].ToString();
                }
                baglanti.Close();
            }
            else
            {
                baglanti.Open();
                NpgsqlCommand command4 = new NpgsqlCommand("SELECT * FROM \"calisan\" INNER JOIN \"sezonlukCalisan\" ON \"calisan\".\"calisanNo\" = \"sezonlukCalisan\".\"calisanNo\" WHERE \"sezonlukCalisan\".\"calisanNo\"='" + calisanNo + "'", baglanti);
                NpgsqlDataReader dataReader4 = command4.ExecuteReader();

                while (dataReader4.Read())
                {
                    txtCalNo.Text = dataReader4["calisanNo"].ToString();
                    txtCalTC.Text = dataReader4["sezonlukTC"].ToString();
                    txtCalAd.Text = dataReader4["calisanAd"].ToString();
                    txtCalSoyad.Text = dataReader4["calisanSoyad"].ToString();
                    txtDepartman.Text = dataReader4["departman"].ToString();
                }
                baglanti.Close();
            }


        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand command5 = new NpgsqlCommand("UPDATE \"personelYakini\" SET \"personelYakiniTC\"=@k1, \"personelYakiniAd\"=@k2, \"personelYakiniSoyad\"=@k3, \"medeniHal\"=@k4, \"cinsiyet\"=@k5, \"dogumTarihi\"=@k6 WHERE \"personelYakiniNo\"='" + int.Parse(txtPersonelYakiniNo.Text) + "'", baglanti);
            command5.Parameters.AddWithValue("@k1", txtTC.Text);
            command5.Parameters.AddWithValue("@k2", txtIsim.Text);
            command5.Parameters.AddWithValue("@k3", txtSoyisim.Text);
            command5.Parameters.AddWithValue("@k4", cmbMedeni.Text);
            command5.Parameters.AddWithValue("@k5", cmbCinsiyet.Text);
            command5.Parameters.AddWithValue("@k6", dateTimePicker1.Value);
            command5.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command6 = new NpgsqlCommand("UPDATE \"personelYakiniMusteri\" SET \"perYakMusTC\"=@l1 WHERE \"personelYakiniNo\"='" + int.Parse(txtPersonelYakiniNo.Text) + "'", baglanti);
            command6.Parameters.AddWithValue("@l1", txtTC.Text);
            command6.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command7 = new NpgsqlCommand("UPDATE \"iletisimBilgileri\" SET \"telefonNo\"=@h1,\"adres\"=@h2,\"il\"=@h3,\"ilce\"=@h4,\"postaKodu\"=@h5 WHERE \"personelYakiniNo\"='" + int.Parse(txtPersonelYakiniNo.Text) + "'", baglanti);
            command7.Parameters.AddWithValue("@h1", txtTelefon.Text);
            command7.Parameters.AddWithValue("@h2", txtAdres.Text);
            command7.Parameters.AddWithValue("@h3", txtIl.Text);
            command7.Parameters.AddWithValue("@h4", txtIlce.Text);
            command7.Parameters.AddWithValue("@h5", txtPostaKodu.Text);
            command7.ExecuteNonQuery();
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
