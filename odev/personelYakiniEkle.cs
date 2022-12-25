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
    public partial class personelYakiniEkleme : Form
    {
        public personelYakiniEkleme()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user Id=postgres; password=12345");
        string calisanTür = "";
        string perYakTur = "";
        int personelYakiniNo = 0;
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO \"personelYakini\" (\"personelYakiniTC\",\"personelYakiniAd\",\"personelYakiniSoyad\",\"medeniHal\",\"cinsiyet\",\"dogumTarihi\",\"otelID\",\"calisanNo\",\"indirimID\",\"perYakSicilNo\") VALUES(@k1,@k2,@k3,@k4,@k5,@k6,@k7,@k8,@k9,@k10)", baglanti);
                command.Parameters.AddWithValue("@k1", txtTC.Text);
                command.Parameters.AddWithValue("@k2", txtIsim.Text);
                command.Parameters.AddWithValue("@k3", txtSoyisim.Text);
                command.Parameters.AddWithValue("@k4", cmbMedeni.Text);
                command.Parameters.AddWithValue("@k5", cmbCinsiyet.Text);
                command.Parameters.AddWithValue("@k6", dtpDogumTarihi.Value);
                command.Parameters.AddWithValue("@k7", 1);
                command.Parameters.AddWithValue("@k8", int.Parse(txtCalNo.Text));
                command.Parameters.AddWithValue("@k9", 1);
                command.Parameters.AddWithValue("@k10", txtSicil.Text);
                command.ExecuteNonQuery();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sicil Numarası 10 Haneden Fazla Olamaz");
                System.Environment.Exit(0);
            }
            
            baglanti.Open();
            NpgsqlCommand command13 = new NpgsqlCommand("SELECT \"personelYakiniNo\" FROM \"personelYakini\"", baglanti);
            NpgsqlDataReader reader2 = command13.ExecuteReader();
            while (reader2.Read())
            {
                personelYakiniNo = int.Parse(reader2["personelYakiniNo"].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command4 = new NpgsqlCommand("INSERT INTO \"iletisimBilgileri\" (\"telefonNo\",\"adres\",\"il\", \"ilce\", \"postaKodu\",\"personelYakiniNo\",\"otelID\") VALUES (@h1,@h2,@h3,@h4,@h5,@h6,@h7)", baglanti);
            command4.Parameters.AddWithValue("@h1", txtTelefon.Text);
            command4.Parameters.AddWithValue("@h2", txtAdres.Text);
            command4.Parameters.AddWithValue("@h3", txtIl.Text);
            command4.Parameters.AddWithValue("@h4", txtIlce.Text);
            command4.Parameters.AddWithValue("@h5", txtPostaKodu.Text);
            command4.Parameters.AddWithValue("@h6", personelYakiniNo);
            command4.Parameters.AddWithValue("@h7", 1);
            command4.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Personel Yakini Basariyla Kaydedilmistir. Personel Yakini No =" + personelYakiniNo);
        }

        private void txtCalNo_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand command4 = new NpgsqlCommand("SELECT \"calisanTür\"FROM calisan WHERE \"calisanNo\"='"+int.Parse(txtCalNo.Text)+"' ",baglanti);
            NpgsqlDataReader dataReader2 = command4.ExecuteReader();

            while (dataReader2.Read())
            {
                calisanTür = dataReader2["calisanTür"].ToString();
            }
            baglanti.Close();

            if (calisanTür == "Kadrolu")
            {
                baglanti.Open();
                NpgsqlCommand command5 = new NpgsqlCommand ("SELECT * FROM \"calisan\" INNER JOIN \"kadroluCalisan\" ON \"calisan\".\"calisanNo\" = \"kadroluCalisan\".\"calisanNo\" WHERE \"kadroluCalisan\".\"calisanNo\"='"+int.Parse(txtCalNo.Text)+"'", baglanti);
                NpgsqlDataReader dataReader3 = command5.ExecuteReader();

                while (dataReader3.Read())
                {
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
                NpgsqlCommand command6 = new NpgsqlCommand("SELECT * FROM \"calisan\" INNER JOIN \"sezonlukCalisan\" ON \"calisan\".\"calisanNo\" = \"sezonlukCalisan\".\"calisanNo\" WHERE \"sezonlukCalisan\".\"calisanNo\"='"+int.Parse(txtCalNo.Text)+"'", baglanti);
                NpgsqlDataReader dataReader4 = command6.ExecuteReader();

                while (dataReader4.Read())
                {
                    txtCalTC.Text = dataReader4["sezonlukTC"].ToString();
                    txtCalAd.Text = dataReader4["calisanAd"].ToString();
                    txtCalSoyad.Text = dataReader4["calisanSoyad"].ToString();
                    txtDepartman.Text = dataReader4["departman"].ToString();
                }
                baglanti.Close();
            }

        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            personelIslemleri personelIslemleri = new personelIslemleri();
            this.Close();
            personelIslemleri.ShowDialog();
        }
    }
}
