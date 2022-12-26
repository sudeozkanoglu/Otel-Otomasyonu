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
    public partial class calisanSil : Form
    {
        public calisanSil()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user Id=postgres; password=12345");
        string calisanTür = "";
        int iletisimID = 0;
        int musteriNo = 0;
        private void txtCalNo_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT \"calisanTür\"FROM calisan WHERE \"calisanNo\"='" + int.Parse(txtCalNo.Text) + "' ", baglanti);
            NpgsqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                calisanTür = dataReader["calisanTür"].ToString();
            }
            baglanti.Close();

            if (calisanTür == "Kadrolu")
            {
                baglanti.Open();
                NpgsqlCommand command2 = new NpgsqlCommand("SELECT * FROM \"calisan\" INNER JOIN \"kadroluCalisan\" ON \"calisan\".\"calisanNo\" = \"kadroluCalisan\".\"calisanNo\" INNER JOIN \"iletisimBilgileri\" ON \"calisan\".\"calisanNo\" = \"iletisimBilgileri\".\"calisanNo\" WHERE \"kadroluCalisan\".\"calisanNo\"='" + int.Parse(txtCalNo.Text) + "'", baglanti);
                NpgsqlDataReader dataReader2 = command2.ExecuteReader();
                cmbSezon.Enabled = false;
                while (dataReader2.Read())
                {
                    txtTC.Text = dataReader2["kadroluTC"].ToString();
                    txtIsim.Text = dataReader2["calisanAd"].ToString();
                    txtSoyisim.Text = dataReader2["calisanSoyad"].ToString();
                    cmbCinsiyet.Text = dataReader2["cinsiyet"].ToString();
                    dtpDogum.Text = dataReader2["dogumTarihi"].ToString();
                    cmbMedeni.Text = dataReader2["medeniHal"].ToString();
                    cmbCalTür.Text = dataReader2["calisanTür"].ToString();
                    cmbDepartman.Text = dataReader2["departman"].ToString();
                    dtpIseGiris.Text = dataReader2["iseGiris"].ToString();
                    txtMaas.Text = dataReader2["maas"].ToString();
                    txtTel.Text = dataReader2["telefonNo"].ToString();
                    txtAdres.Text = dataReader2["adres"].ToString();
                    txtIl.Text = dataReader2["il"].ToString();
                    txtIlce.Text = dataReader2["ilce"].ToString();
                    txtPosta.Text = dataReader2["postaKodu"].ToString();
                }
                baglanti.Close();
            }
            else
            {
                baglanti.Open();
                NpgsqlCommand command3 = new NpgsqlCommand("SELECT * FROM \"calisan\" INNER JOIN \"sezonlukCalisan\" ON \"calisan\".\"calisanNo\" = \"sezonlukCalisan\".\"calisanNo\" INNER JOIN \"iletisimBilgileri\" ON \"calisan\".\"calisanNo\" = \"iletisimBilgileri\".\"calisanNo\" WHERE \"sezonlukCalisan\".\"calisanNo\"='" + int.Parse(txtCalNo.Text) + "'", baglanti);
                NpgsqlDataReader dataReader3 = command3.ExecuteReader();

                while (dataReader3.Read())
                {
                    txtTC.Text = dataReader3["sezonlukTC"].ToString();
                    txtIsim.Text = dataReader3["calisanAd"].ToString();
                    txtSoyisim.Text = dataReader3["calisanSoyad"].ToString();
                    cmbCinsiyet.Text = dataReader3["cinsiyet"].ToString();
                    dtpDogum.Text = dataReader3["dogumTarihi"].ToString();
                    cmbMedeni.Text = dataReader3["medeniHal"].ToString();
                    cmbCalTür.Text = dataReader3["calisanTür"].ToString();
                    cmbSezon.Text = dataReader3["sezonTuru"].ToString();
                    cmbDepartman.Text = dataReader3["departman"].ToString();
                    dtpIseGiris.Text = dataReader3["iseGiris"].ToString();
                    txtMaas.Text = dataReader3["maas"].ToString();
                    txtTel.Text = dataReader3["telefonNo"].ToString();
                    txtAdres.Text = dataReader3["adres"].ToString();
                    txtIl.Text = dataReader3["il"].ToString();
                    txtIlce.Text = dataReader3["ilce"].ToString();
                    txtPosta.Text = dataReader3["postaKodu"].ToString();
                }
                baglanti.Close();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand command4 = new NpgsqlCommand("SELECT \"iletisimID\" FROM \"iletisimBilgileri\" WHERE \"calisanNo\"='" + int.Parse(txtCalNo.Text) + "'", baglanti);
            NpgsqlDataReader dataReader4 = command4.ExecuteReader();
            while (dataReader4.Read())
            {
                iletisimID = int.Parse(dataReader4["iletisimID"].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command5 = new NpgsqlCommand("DELETE FROM \"iletisimBilgileri\" WHERE \"calisanNo\"=(@k1)", baglanti);
            command5.Parameters.AddWithValue("@k1", int.Parse(txtCalNo.Text));
            command5.ExecuteNonQuery();
            baglanti.Close();

            if (cmbCalTür.SelectedItem == "Kadrolu")
            {
                baglanti.Open();
                NpgsqlCommand command6 = new NpgsqlCommand("DELETE FROM \"kadroluCalisan\" WHERE \"calisanNo\"=(@p1)", baglanti);
                command6.Parameters.AddWithValue("@p1", int.Parse(txtCalNo.Text));
                command6.ExecuteNonQuery();
                baglanti.Close();
            }
            else
            {
                baglanti.Open();
                NpgsqlCommand command7 = new NpgsqlCommand("DELETE FROM \"sezonlukCalisan\" WHERE \"calisanNo\"=(@s1)", baglanti);
                command7.Parameters.AddWithValue("@s1", int.Parse(txtCalNo.Text));
                command7.ExecuteNonQuery();
                baglanti.Close();
            }

            baglanti.Open();
            NpgsqlCommand command8 = new NpgsqlCommand("SELECT \"calisanNo\" FROM \"calisan\" WHERE \"calisanNo\"='" + int.Parse(txtCalNo.Text) + "'", baglanti);
            NpgsqlDataReader dataReader5 = command8.ExecuteReader();
            while(dataReader5.Read())
            {
                musteriNo = int.Parse(dataReader5["calisanNo"].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command12 = new NpgsqlCommand("DELETE FROM \"personelYakini\" WHERE \"calisanNo\"=(@v1)" , baglanti);
            command12.Parameters.AddWithValue("@v1", int.Parse(txtCalNo.Text));
            command12.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command11 = new NpgsqlCommand("DELETE FROM \"calisan\" WHERE \"calisanNo\"=(@h1)", baglanti);
            command11.Parameters.AddWithValue("@h1", int.Parse(txtCalNo.Text));
            command11.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Calisan Bilgileri Basariyla Silindi.");
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            personelIslemleri personelIslemleri = new personelIslemleri();
            this.Close();
            personelIslemleri.ShowDialog();
        }
    }
}
