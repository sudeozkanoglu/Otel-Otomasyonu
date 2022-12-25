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
    public partial class calisanGüncelle : Form
    {
        public calisanGüncelle()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user Id=postgres; password=12345");
        string calisanTür = "";
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
                cmbSezon.Enabled= false;
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

        private void cmbCalTür_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCalTür.SelectedItem == "Kadrolu")
            {
                cmbSezon.Enabled = false;
            }
            else 
            {
                cmbSezon.Enabled = true;
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            string calTur = "";
            baglanti.Open();
            NpgsqlCommand command4 = new NpgsqlCommand("UPDATE \"calisan\" SET \"calisanAd\"=@k1,\"calisanSoyad\"=@k2,\"cinsiyet\"=@k3,\"dogumTarihi\"=@k4,\"medeniHal\"=@k5,\"calisanTür\"=@k6,\"departman\"=@k7,\"iseGiris\"=@k8,\"otelID\"=@k9 WHERE \"calisanNo\"='" + int.Parse(txtCalNo.Text) + "'", baglanti);
            command4.Parameters.AddWithValue("@k1",txtIsim.Text);
            command4.Parameters.AddWithValue("@k2",txtSoyisim.Text);
            command4.Parameters.AddWithValue("@k3",cmbCinsiyet.Text);
            command4.Parameters.AddWithValue("@k4",dtpDogum.Value);
            command4.Parameters.AddWithValue("@k5",cmbMedeni.Text);
            command4.Parameters.AddWithValue("@k6",cmbCalTür.Text);
            command4.Parameters.AddWithValue("@k7",cmbDepartman.Text);
            command4.Parameters.AddWithValue("@k8",dtpIseGiris.Value);
            command4.Parameters.AddWithValue("@k9", 1);
            command4.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command5 = new NpgsqlCommand("UPDATE \"iletisimBilgileri\" SET \"telefonNo\"=@h1,\"adres\"=@h2,\"il\"=@h3,\"ilce\"=@h4,\"postaKodu\"=@h5 WHERE \"calisanNo\"='" + int.Parse(txtCalNo.Text) + "'", baglanti);
            command5.Parameters.AddWithValue("@h1",txtTel.Text);
            command5.Parameters.AddWithValue("@h2", txtAdres.Text);
            command5.Parameters.AddWithValue("@h3",txtIl.Text);
            command5.Parameters.AddWithValue("@h4", txtIlce.Text);
            command5.Parameters.AddWithValue("@h5",txtPosta.Text);
            command5.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command20 = new NpgsqlCommand("SELECT \"calisanTür\" FROM \"calisan\" WHERE \"calisanNo\"='" + int.Parse(txtCalNo.Text) + "'", baglanti);
            NpgsqlDataReader dataReader20 = command20.ExecuteReader();
            while (dataReader20.Read())
            {
                calTur = dataReader20["calisanTür"].ToString();
            }
            baglanti.Close();

            if (calTur == "Kadrolu")
            {
                if (cmbCalTür.SelectedItem == "Kadrolu")
                {
                    baglanti.Open();
                    NpgsqlCommand command21 = new NpgsqlCommand("UPDATE \"calisan\" SET \"calisanAd\"=@w1, \"calisanSoyad\"=@w2, \"cinsiyet\"=@w3,\"dogumTarih\"=@w4,\"medeniHal\"=@w6, \"calisanTür\"=@w7, \"departman\"=@w8, \"iseGiris\"=@w9, \"otelID\"=@w10 WHERE \"calisanNo\"='" + int.Parse(txtCalNo.Text) + "'", baglanti);
                    command4.Parameters.AddWithValue("@k1", txtIsim.Text);
                    command4.Parameters.AddWithValue("@k2", txtSoyisim.Text);
                    command4.Parameters.AddWithValue("@k3", cmbCinsiyet.Text);
                    command4.Parameters.AddWithValue("@k4", dtpDogum.Value);
                    command4.Parameters.AddWithValue("@k5", cmbMedeni.Text);
                    command4.Parameters.AddWithValue("@k6", cmbCalTür.Text);
                    command4.Parameters.AddWithValue("@k7", cmbDepartman.Text);
                    command4.Parameters.AddWithValue("@k8", dtpIseGiris.Value);
                    command4.Parameters.AddWithValue("@k9", 1);
                    baglanti.Close();

                    baglanti.Open();
                    NpgsqlCommand command22 = new NpgsqlCommand("UPDATE \"iletisimBilgileri\" SET \"telefonNo\"=@h1,\"adres\"=@h2,\"il\"=@h3,\"ilce\"=@h4,\"postaKodu\"=@h5 WHERE \"calisanNo\"='" + int.Parse(txtCalNo.Text) + "'", baglanti);
                    command22.Parameters.AddWithValue("@h1", txtTel.Text);
                    command22.Parameters.AddWithValue("@h2", txtAdres.Text);
                    command22.Parameters.AddWithValue("@h3", txtIl.Text);
                    command22.Parameters.AddWithValue("@h4", txtIlce.Text);
                    command22.Parameters.AddWithValue("@h5", txtPosta.Text);
                    command22.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    NpgsqlCommand command23 = new NpgsqlCommand("UPDATE \"kadroluCalisan\" SET \"calisanNo\"=@e1,\"kadroluTC\"=@e2,\"maas\"=@e3 WHERE \"calisanNo\"='" + int.Parse(txtCalNo.Text) + "'", baglanti);
                    command23.Parameters.AddWithValue("@e1", int.Parse(txtCalNo.Text));
                    command23.Parameters.AddWithValue("@e2", txtTC.Text);
                    command23.Parameters.AddWithValue("@e3", double.Parse(txtMaas.Text));
                    command23.ExecuteNonQuery();
                    baglanti.Close();
                }
                else 
                {
                    baglanti.Open();
                    NpgsqlCommand command8 = new NpgsqlCommand("INSERT INTO \"sezonlukCalisan\" (\"calisanNo\",\"sezonlukTC\",\"sezonTuru\",\"maas\") VALUES (@m1,@m2,@m3,@m4)", baglanti);
                    command8.Parameters.AddWithValue("@m1", int.Parse(txtCalNo.Text));
                    command8.Parameters.AddWithValue("@m2", txtTC.Text);
                    command8.Parameters.AddWithValue("@m3", cmbSezon.Text);
                    command8.Parameters.AddWithValue("@m4", double.Parse(txtMaas.Text));
                    command8.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    NpgsqlCommand command10 = new NpgsqlCommand("DELETE FROM \"kadroluCalisan\" WHERE \"calisanNo\"=(@s1)", baglanti);
                    command10.Parameters.AddWithValue("@s1", int.Parse(txtCalNo.Text));
                    command10.ExecuteNonQuery();
                    baglanti.Close();
                }
            }
            else 
            {
                if (cmbCalTür.SelectedItem == "Sezonluk")
                {
                    baglanti.Open();
                    NpgsqlCommand command21 = new NpgsqlCommand("UPDATE \"calisan\" SET \"calisanAd\"=@w1, \"calisanSoyad\"=@w2, \"cinsiyet\"=@w3,\"dogumTarih\"=@w4,\"medeniHal\"=@w6, \"calisanTür\"=@w7, \"departman\"=@w8, \"iseGiris\"=@w9, \"otelID\"=@w10 WHERE \"calisanNo\"='" + int.Parse(txtCalNo.Text) + "'", baglanti);
                    command4.Parameters.AddWithValue("@k1", txtIsim.Text);
                    command4.Parameters.AddWithValue("@k2", txtSoyisim.Text);
                    command4.Parameters.AddWithValue("@k3", cmbCinsiyet.Text);
                    command4.Parameters.AddWithValue("@k4", dtpDogum.Value);
                    command4.Parameters.AddWithValue("@k5", cmbMedeni.Text);
                    command4.Parameters.AddWithValue("@k6", cmbCalTür.Text);
                    command4.Parameters.AddWithValue("@k7", cmbDepartman.Text);
                    command4.Parameters.AddWithValue("@k8", dtpIseGiris.Value);
                    command4.Parameters.AddWithValue("@k9", 1);

                    baglanti.Open();
                    NpgsqlCommand command22 = new NpgsqlCommand("UPDATE \"iletisimBilgileri\" SET \"telefonNo\"=@h1,\"adres\"=@h2,\"il\"=@h3,\"ilce\"=@h4,\"postaKodu\"=@h5 WHERE \"calisanNo\"='" + int.Parse(txtCalNo.Text) + "'", baglanti);
                    command22.Parameters.AddWithValue("@h1", txtTel.Text);
                    command22.Parameters.AddWithValue("@h2", txtAdres.Text);
                    command22.Parameters.AddWithValue("@h3", txtIl.Text);
                    command22.Parameters.AddWithValue("@h4", txtIlce.Text);
                    command22.Parameters.AddWithValue("@h5", txtPosta.Text);
                    command22.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    NpgsqlCommand command23 = new NpgsqlCommand("UPDATE \"sezonlukCalisan\" SET \"calisanNo\"=@e1,\"sezonlukTC\"=@e2,\"maas\"=@e3, \"sezonTuru\"=@e4 WHERE \"calisanNo\"='" + int.Parse(txtCalNo.Text) + "'", baglanti);
                    command23.Parameters.AddWithValue("@e1", int.Parse(txtCalNo.Text));
                    command23.Parameters.AddWithValue("@e2", txtTC.Text);
                    command23.Parameters.AddWithValue("@e3", txtMaas.Text);
                    command23.Parameters.AddWithValue("@e4", cmbSezon.Text);
                    command23.ExecuteNonQuery();
                    baglanti.Close();
                }
                else 
                {
                    baglanti.Open();
                    NpgsqlCommand command7 = new NpgsqlCommand("INSERT INTO \"kadroluCalisan\" (\"calisanNo\",\"kadroluTC\",\"maas\") VALUES (@l1,@l2,@l3) ", baglanti);
                    command7.Parameters.AddWithValue("@l1", int.Parse(txtCalNo.Text));
                    command7.Parameters.AddWithValue("@l2", txtTC.Text);
                    command7.Parameters.AddWithValue("@l3", double.Parse(txtMaas.Text));
                    command7.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    NpgsqlCommand command9 = new NpgsqlCommand("DELETE FROM \"sezonlukCalisan\" WHERE \"calisanNo\"=(@p1)", baglanti);
                    command9.Parameters.AddWithValue("@p1", int.Parse(txtCalNo.Text));
                    command9.ExecuteNonQuery();
                    baglanti.Close();
                }
                
            }
          
            MessageBox.Show("Musteri Basariyla Güncellendi !");
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            personelIslemleri personelIslemleri = new personelIslemleri();
            this.Close();
            personelIslemleri.ShowDialog();
        }
    }
}
