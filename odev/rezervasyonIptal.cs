using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace odev
{
    public partial class rezervasyonIptal : Form
    {
        public rezervasyonIptal()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user Id=postgres; password=12345");
        int musteriNo;
        int odaID;
        int odaTurID;
        int gelirNo;
        int indirimID;
        int personelYakiniNo;
        string musteriTipi = "";
        private void btnMenü_Click(object sender, EventArgs e)
        {
            Rezervasyon rezervasyon = new Rezervasyon();
            this.Close();
            rezervasyon.Show();
        }

        private void txtRezervasyonNo_TextChanged(object sender, EventArgs e)
        {

            baglanti.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT \"musteriNo\" , \"odaID\" , \"gelirNo\" FROM \"rezervasyon\" WHERE \"rezervasyonNo\"='" + int.Parse(txtRezervasyonNo.Text) + "'", baglanti);
            NpgsqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                musteriNo = int.Parse(dataReader["musteriNo"].ToString());
                odaID = int.Parse(dataReader["odaID"].ToString());
                gelirNo = int.Parse(dataReader["gelirNo"].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command2 = new NpgsqlCommand("SELECT * FROM \"devamliMusteri\" INNER JOIN \"musteri\" ON \"devamliMusteri\".\"musteriNo\" = \"musteri\".\"musteriNo\" INNER JOIN \"iletisimBilgileri\" ON \"devamliMusteri\".\"musteriNo\" = \"iletisimBilgileri\".\"musteriNo\" INNER JOIN \"rezervasyon\" ON \"devamliMusteri\".\"musteriNo\"=\"rezervasyon\".\"musteriNo\" WHERE \"devamliMusteri\".\"musteriNo\"='" + musteriNo + "'", baglanti);
            NpgsqlDataReader dataReader2 = command2.ExecuteReader();
            while (dataReader2.Read())
            {
                txtTC.Text = dataReader2["devamliMusteriTC"].ToString();
                txtIsim.Text = dataReader2["musteriAd"].ToString();
                txtSoyisim.Text = dataReader2["musteriSoyad"].ToString();
                cmbCinsiyet.Text = dataReader2["cinsiyet"].ToString();
                dateTimePicker1.Text = dataReader2["dogumTarihi"].ToString();
                cmbMedeni.Text = dataReader2["medeniHal"].ToString();
                txtTel.Text = dataReader2["telefonNo"].ToString();
                txtAdres.Text = dataReader2["adres"].ToString();
                txtIl.Text = dataReader2["il"].ToString();
                txtIlce.Text = dataReader2["ilce"].ToString();
                txtPostaKodu.Text = dataReader2["postaKodu"].ToString();
                dtpGiris.Text = dataReader2["girisTarih"].ToString();
                dtpCikis.Text = dataReader2["cikisTarih"].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command6 = new NpgsqlCommand("SELECT * FROM \"personelYakiniMusteri\" INNER JOIN \"musteri\" ON \"personelYakiniMusteri\".\"musteriNo\" = \"musteri\".\"musteriNo\" INNER JOIN \"iletisimBilgileri\" ON \"personelYakiniMusteri\".\"musteriNo\"=\"iletisimBilgileri\".\"musteriNo\" INNER JOIN \"rezervasyon\" ON \"personelYakiniMusteri\".\"musteriNo\"=\"rezervasyon\".\"musteriNo\" WHERE \"personelYakiniMusteri\".\"musteriNo\"='" + musteriNo + "'", baglanti);
            NpgsqlDataReader dataReader6 = command6.ExecuteReader();
            while (dataReader6.Read())
            {
                txtTC.Text = dataReader6["perYakMusTc"].ToString();
                txtIsim.Text = dataReader6["musteriAd"].ToString();
                txtSoyisim.Text = dataReader6["musteriSoyad"].ToString();
                cmbCinsiyet.Text = dataReader6["cinsiyet"].ToString();
                dateTimePicker1.Text = dataReader6["dogumTarihi"].ToString();
                cmbMedeni.Text = dataReader6["medeniHal"].ToString();
                txtTel.Text = dataReader6["telefonNo"].ToString();
                txtAdres.Text = dataReader6["adres"].ToString();
                txtIl.Text = dataReader6["il"].ToString();
                txtIlce.Text = dataReader6["ilce"].ToString();
                txtPostaKodu.Text = dataReader6["postaKodu"].ToString();
                dtpGiris.Text = dataReader6["girisTarih"].ToString();
                dtpCikis.Text = dataReader6["cikisTarih"].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command3 = new NpgsqlCommand("SELECT \"odaTurID\" FROM \"oda\" WHERE \"odaID\"='" + odaID + "'", baglanti);
            NpgsqlDataReader dataReader3 = command3.ExecuteReader();
            while (dataReader3.Read())
            {
                odaTurID = int.Parse(dataReader3["odaTurID"].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command4 = new NpgsqlCommand("SELECT * FROM \"odaTur\" INNER JOIN \"oda\" ON \"odaTur\".\"odaTurID\" = \"oda\".\"odaTurID\" WHERE \"odaTur\".\"odaTurID\" ='" + odaTurID + "'", baglanti);
            NpgsqlDataReader dataReader4 = command4.ExecuteReader();
            while (dataReader4.Read())
            {
                cmbOdaTipi.Text = dataReader4["odaTurAdi"].ToString();
                cmbOdaNo.Text = dataReader4["odaNo"].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command5 = new NpgsqlCommand("SELECT * FROM \"gelir\" INNER JOIN \"rezervasyon\" ON \"gelir\".\"gelirNo\" = \"rezervasyon\".\"gelirNo\" WHERE \"gelir\".\"gelirNo\"='" + gelirNo + "'", baglanti);
            NpgsqlDataReader dataReader5 = command5.ExecuteReader();
            while (dataReader5.Read())
            {
                txtTutar.Text = dataReader5["indirimsizTutar"].ToString();
                txtTotal.Text = dataReader5["gelirTutar"].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command11 = new NpgsqlCommand("SELECT \"indirimID\" FROM \"personelYakini\" WHERE \"personelYakiniTC\"='" + txtTC.Text + "'", baglanti);
            NpgsqlDataReader dataReader11 = command11.ExecuteReader();
            while (dataReader11.Read())
            {
                indirimID = int.Parse(dataReader11["indirimID"].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command7 = new NpgsqlCommand("SELECT \"personelIndirim\" FROM \"indirim\" WHERE \"indirimID\"='" + indirimID + "'", baglanti);
            NpgsqlDataReader dataReader7 = command7.ExecuteReader();
            while (dataReader7.Read())
            {
                txtIndirim.Text = dataReader7["personelIndirim"].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command8 = new NpgsqlCommand("SELECT \"indirimID\" FROM \"devamliMusteri\" WHERE \"devamliMusteriTC\"='" + txtTC.Text + "'", baglanti);
            NpgsqlDataReader dataReader8 = command8.ExecuteReader();
            while (dataReader8.Read())
            {
                indirimID = int.Parse(dataReader8["indirimID"].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command9 = new NpgsqlCommand("SELECT \"devamliIndirim\" FROM \"indirim\" WHERE \"indirimID\"='" + indirimID + "'", baglanti);
            NpgsqlDataReader dataReader9 = command9.ExecuteReader();
            while (dataReader9.Read())
            {
                txtIndirim.Text = dataReader9["devamliIndirim"].ToString();
            }
            baglanti.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand command17 = new NpgsqlCommand("SELECT \"musteriTipi\" FROM \"musteri\" WHERE \"musteriNo\"='" + musteriNo + "'", baglanti);
            NpgsqlDataReader dataReader17 = command17.ExecuteReader();
            while (dataReader17.Read())
            {
                musteriTipi = dataReader17["musteriTipi"].ToString();
            }
            baglanti.Close();

            if (musteriTipi == "Devamli Musteri")
            {
                baglanti.Open();
                NpgsqlCommand command18 = new NpgsqlCommand("DELETE FROM \"iletisimBilgileri\" WHERE \"musteriNo\"=(@w6)", baglanti);
                command18.Parameters.AddWithValue("@w6", musteriNo);
                command18.ExecuteNonQuery();
                baglanti.Close();
            }
            else if (musteriTipi == "Yeni Musteri")
            {
                baglanti.Open();
                NpgsqlCommand command19 = new NpgsqlCommand("DELETE FROM \"iletisimiBilgileri\" WHERE \"musteriNo\"=(@w7)", baglanti);
                command19.Parameters.AddWithValue("@w7", musteriNo);
                command19.ExecuteNonQuery();
                baglanti.Close();
            }
            else
            {
                baglanti.Open();
                NpgsqlCommand command20 = new NpgsqlCommand("UPDATE \"iletisimBilgileri\" SET \"musteriNo\"= null WHERE \"musteriNo\"='" + musteriNo + "'", baglanti);
                command20.ExecuteNonQuery();
                baglanti.Close();
            }

            baglanti.Open();
            NpgsqlCommand command12 = new NpgsqlCommand("DELETE FROM \"yeniMusteri\" WHERE \"musteriNo\"=(@w1)", baglanti);
            command12.Parameters.AddWithValue("@w1", musteriNo);
            command12.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command13 = new NpgsqlCommand("DELETE FROM \"devamliMusteri\" WHERE \"musteriNo\"=(@w2)", baglanti);
            command13.Parameters.AddWithValue("@w2", musteriNo);
            command13.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command15 = new NpgsqlCommand("DELETE FROM \"rezervasyon\" WHERE \"musteriNo\"=(@w4)", baglanti);
            command15.Parameters.AddWithValue("@w4", musteriNo);
            command15.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command21 = new NpgsqlCommand("DELETE FROM \"gelir\" WHERE \"gelirNo\"=(@w9)", baglanti);
            command21.Parameters.AddWithValue("@w9", gelirNo);
            command21.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command22 = new NpgsqlCommand("SELECT \"personelYakiniNo\" FROM \"rezervasyon\" WHERE \"musteriNo\"='" + musteriNo + "'", baglanti);
            NpgsqlDataReader dataReader22 = command22.ExecuteReader();
            while (dataReader22.Read())
            {
                personelYakiniNo = int.Parse(dataReader22["personelYakiniNo"].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command16 = new NpgsqlCommand("DELETE FROM \"musteri\" WHERE \"musteriNo\"=(@w5)", baglanti);
            command16.Parameters.AddWithValue("@w5", musteriNo);
            command16.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command14 = new NpgsqlCommand("DELETE FROM \"personelYakiniMusteri\" WHERE \"personelYakiniNo\"=(@w3)", baglanti);
            command14.Parameters.AddWithValue("@w3", personelYakiniNo);
            command14.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Rezervasyon Iptal Islemi Basarili");
        }
       
    }
}
