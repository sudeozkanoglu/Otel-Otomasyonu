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
    public partial class personelYakiniSilme : Form
    {
        public personelYakiniSilme()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user Id=postgres; password=12345");
        int calisanNo = 0;
        string calisanTür = "";
        int personelYakiniNo = 0;
        int iletisimID = 0;
        int musteriNo = 0;
        int faturaID = 0;
        private void txtTC_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM \"personelYakini\" INNER JOIN \"iletisimBilgileri\" ON \"personelYakini\".\"personelYakiniNo\"= \"iletisimBilgileri\".\"personelYakiniNo\" WHERE \"personelYakiniTC\"='" + txtTC.Text + "'", baglanti);
            NpgsqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
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
            NpgsqlCommand command2 = new NpgsqlCommand("SELECT \"calisanNo\" FROM \"personelYakini\" WHERE \"personelYakiniTC\"='" + txtTC.Text + "'", baglanti);
            NpgsqlDataReader dataReader2 = command2.ExecuteReader();
            while (dataReader2.Read())
            {
                calisanNo = int.Parse(dataReader2["calisanNo"].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command3 = new NpgsqlCommand("SELECT \"calisanTür\" FROM \"calisan\" WHERE \"calisanNo\"='" + calisanNo + "'", baglanti);
            NpgsqlDataReader dataReader3 = command3.ExecuteReader();
            while (dataReader3.Read())
            {
                calisanTür = dataReader3["calisanTür"].ToString();
            }
            baglanti.Close();

            if (calisanTür == "Kadrolu")
            {
                baglanti.Open();
                NpgsqlCommand command4 = new NpgsqlCommand("SELECT * FROM \"calisan\" INNER JOIN \"kadroluCalisan\" ON \"calisan\".\"calisanNo\" = \"kadroluCalisan\".\"calisanNo\" WHERE \"calisan\".\"calisanNo\"='" + calisanNo + "'", baglanti);
                NpgsqlDataReader dataReader4 = command4.ExecuteReader();
                while (dataReader4.Read())
                {
                    txtCalNo.Text = dataReader4["calisanNo"].ToString();
                    txtCalTC.Text = dataReader4["kadroluTC"].ToString();
                    txtCalAd.Text = dataReader4["calisanAd"].ToString();
                    txtCalSoyad.Text = dataReader4["calisanSoyad"].ToString();
                    txtDepartman.Text = dataReader4["departman"].ToString();
                }
                baglanti.Close();
            }
            else 
            {
                baglanti.Open();
                NpgsqlCommand command5 = new NpgsqlCommand("SELECT * FROM \"calisan\" INNER JOIN \"sezonlukCalisan\" ON \"calisan\".\"calisanNo\" = \"sezonlukCalisan\".\"calisanNo\" WHERE \"calisan\".\"calisanNo\"='" + calisanNo + "'", baglanti);
                NpgsqlDataReader dataReader5 = command5.ExecuteReader();
                while (dataReader5.Read())
                {
                    txtCalNo.Text = dataReader5["calisanNo"].ToString();
                    txtCalTC.Text = dataReader5["sezonlukTC"].ToString();
                    txtCalAd.Text = dataReader5["calisanAd"].ToString();
                    txtCalSoyad.Text = dataReader5["calisanSoyad"].ToString();
                    txtDepartman.Text = dataReader5["departman"].ToString();
                }
                baglanti.Close();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand command6 = new NpgsqlCommand("SELECT \"personelYakiniNo\" FROM \"personelYakini\" WHERE \"personelYakiniTC\"='" + txtTC.Text + "'", baglanti);
            NpgsqlDataReader dataReader6 = command6.ExecuteReader();
            while (dataReader6.Read())
            {
                personelYakiniNo = int.Parse(dataReader6["personelYakiniNo"].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command7 = new NpgsqlCommand("SELECT \"iletisimID\" FROM \"iletisimBilgileri\" WHERE \"personelYakiniNo\"='" + personelYakiniNo + "'", baglanti);
            NpgsqlDataReader dataReader7 = command7.ExecuteReader();
            while (dataReader7.Read())
            {
                iletisimID = int.Parse(dataReader7["iletisimID"].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command8 = new NpgsqlCommand("DELETE FROM \"iletisimBilgileri\" WHERE \"personelYakiniNo\"=(@k1)", baglanti);
            command8.Parameters.AddWithValue("@k1", personelYakiniNo);
            command8.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command9 = new NpgsqlCommand("SELECT \"musteriNo\" FROM \"personelYakiniMusteri\" WHERE \"personelYakiniNo\"='" + personelYakiniNo + "'", baglanti);
            NpgsqlDataReader dataReader9 = command9.ExecuteReader();
            while (dataReader9.Read())
            {
                musteriNo = int.Parse(dataReader9["musteriNo"].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command10 = new NpgsqlCommand("DELETE FROM \"musteri\" WHERE \"musteriNo\"=(@k2)", baglanti);
            command10.Parameters.AddWithValue("@k2", musteriNo);
            command10.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command11 = new NpgsqlCommand("SELECT \"faturaID\" FROM \"personelYakiniMusteri\" WHERE \"personelYakiniNo\"='" + personelYakiniNo + "'", baglanti);
            NpgsqlDataReader dataReader11 = command11.ExecuteReader();
            while (dataReader11.Read())
            {
                faturaID = int.Parse(dataReader11["faturaID"].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command12 = new NpgsqlCommand("DELETE FROM \"fatura\" WHERE \"faturaID\"=(@k3)", baglanti);
            command12.Parameters.AddWithValue("@k3", faturaID);
            command12.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command13 = new NpgsqlCommand("DELETE FROM \"personelYakiniMusteri\" WHERE \"personelYakiniNo\"=(@k4)", baglanti);
            command13.Parameters.AddWithValue("@k4", personelYakiniNo);
            command13.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command14 = new NpgsqlCommand("DELETE FROM \"personelYakini\" WHERE \"personelYakiniNo\"=(@k5)", baglanti);
            command14.Parameters.AddWithValue("@k5", personelYakiniNo);
            command14.ExecuteNonQuery();
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
