using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace odev
{
    public partial class calisanEkle : Form
    {
        public calisanEkle()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user Id=postgres; password=12345"); 
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            int calisanNumara = 0;
            baglanti.Open();
            NpgsqlCommand command = new NpgsqlCommand("INSERT INTO calisan (\"calisanAd\",\"calisanSoyad\",\"dogumTarihi\",\"medeniHal\",\"cinsiyet\",\"calisanTür\",\"iseGiris\",\"departman\",\"otelID\") VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", baglanti);
            command.Parameters.AddWithValue("@p1", txtIsim.Text);
            command.Parameters.AddWithValue("@p2", txtSoyisim.Text);
            command.Parameters.AddWithValue("@p3", dtpDogumTarihi.Value);
            command.Parameters.AddWithValue("@p4", cmbMedeni.Text);
            command.Parameters.AddWithValue("@p5", cmbCinsiyet.Text);
            command.Parameters.AddWithValue("@p6", cmbCalTur.Text);
            command.Parameters.AddWithValue("@p7", dtpIseGiris.Value);
            command.Parameters.AddWithValue("@p8", cmbDepartman.Text);
            command.Parameters.AddWithValue("@p9", 1);
            command.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command2 = new NpgsqlCommand("SELECT \"calisanNo\" FROM calisan", baglanti);
            NpgsqlDataReader dataReader = command2.ExecuteReader();

            while (dataReader.Read())
            {
                calisanNumara = int.Parse(dataReader["calisanNo"].ToString());
            }

            baglanti.Close();
            Exception myException = null;
            try {
                baglanti.Open();
                NpgsqlCommand command1 = new NpgsqlCommand("INSERT INTO \"iletisimBilgileri\" (\"telefonNo\",\"adres\",\"il\",\"ilce\",\"postaKodu\",\"calisanNo\") VALUES (@s1,@s2,@s3,@s4,@s5,@s6)", baglanti);
                command1.Parameters.AddWithValue("@s1", txtTel.Text);
                command1.Parameters.AddWithValue("@s2", txtAdres.Text);
                command1.Parameters.AddWithValue("@s3", txtIl.Text);
                command1.Parameters.AddWithValue("@s4", txtIlce.Text);
                command1.Parameters.AddWithValue("@s5", txtPosta.Text);
                command1.Parameters.AddWithValue("@s6", calisanNumara);
                command1.ExecuteNonQuery();
                baglanti.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Telefon Numarası 11 Haneden Fazla Olamaz");
                NpgsqlCommand command44 = new NpgsqlCommand("DELETE FROM \"calisan\" WHERE \"calisanNo\"=(@p1)", baglanti);
                command44.Parameters.AddWithValue("@p1", calisanNumara);
                command44.ExecuteNonQuery();
                baglanti.Close();
                myException = ex;
            }

            if (myException == null)
            {
                baglanti.Open();

                if (cmbCalTur.Text == "Kadrolu")
                {
                    NpgsqlCommand command3 = new NpgsqlCommand("INSERT INTO \"kadroluCalisan\"(\"calisanNo\",\"kadroluTC\",\"maas\") VALUES (@k1,@k2,@k3)", baglanti);
                    command3.Parameters.AddWithValue("@k1", calisanNumara);
                    command3.Parameters.AddWithValue("@k2", txtTC.Text);
                    command3.Parameters.AddWithValue("@k3", double.Parse(txtMaas.Text));
                    command3.ExecuteNonQuery();
                }
                else
                {
                    NpgsqlCommand command4 = new NpgsqlCommand("INSERT INTO \"sezonlukCalisan\"(\"calisanNo\",\"sezonlukTC\",\"maas\",\"sezonTuru\") VALUES (@h1,@h2,@h3,@h4)", baglanti);
                    command4.Parameters.AddWithValue("@h1", calisanNumara);
                    command4.Parameters.AddWithValue("@h2", txtTC.Text);
                    command4.Parameters.AddWithValue("@h3", int.Parse(txtMaas.Text));
                    command4.Parameters.AddWithValue("@h4", cmbSezon.Text);
                    command4.ExecuteNonQuery();
                }
                baglanti.Close();

                MessageBox.Show("Calisan Basariyla Kaydedilmiştir. Calisan No =" + calisanNumara);
            }
           
        }

        private void cmbCalTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCalTur.Text == "Kadrolu")
            {
                cmbSezon.Enabled = false;
            }
            else
            { 
                cmbSezon.Enabled = true;
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            personelIslemleri personel = new personelIslemleri();
            this.Close();
            personel.ShowDialog();
        }
    }
}
