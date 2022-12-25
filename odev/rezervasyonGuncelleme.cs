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
    public partial class rezervasyonGuncelleme : Form
    {
        public rezervasyonGuncelleme()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user Id=postgres; password=12345");
        int musteriNo;
        int odaID;
        int odaTurID;
        int gelirNo;
        int indirimID;
        int aradakiFark;
        int odaYeniID;
        double genelTutar;
        double indirimTutar;
        double odaFiyat;
        double odaToplamFiyat;
        DateTime dateTimeGiris;
        DateTime dateTimeCikis;
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
                dtpGirisEski.Text = dataReader2["girisTarih"].ToString();
                dtpCikisEski.Text = dataReader2["cikisTarih"].ToString();
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
                dtpGirisEski.Text = dataReader6["girisTarih"].ToString();
                dtpCikisEski.Text = dataReader6["cikisTarih"].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command3 = new NpgsqlCommand("SELECT \"odaTurID\" FROM \"oda\" WHERE \"odaID\"='" + odaID + "'", baglanti);
            NpgsqlDataReader dataReader3 = command3.ExecuteReader();
            while(dataReader3.Read())
            {
                odaTurID = int.Parse(dataReader3["odaTurID"].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command4 = new NpgsqlCommand("SELECT * FROM \"odaTur\" INNER JOIN \"oda\" ON \"odaTur\".\"odaTurID\" = \"oda\".\"odaTurID\" WHERE \"odaTur\".\"odaTurID\" ='" + odaTurID + "'", baglanti);
            NpgsqlDataReader dataReader4 = command4.ExecuteReader();
            while (dataReader4.Read())
            {
                cmbOdaTipEski.Text = dataReader4["odaTurAdi"].ToString();
                cmbOdaNoEski.Text = dataReader4["odaNo"].ToString();
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
                indirimTutar = double.Parse(dataReader7["personelIndirim"].ToString());
            }
            baglanti.Close();
            txtIndirim.Text = indirimTutar.ToString();

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
                indirimTutar = double.Parse(dataReader9["devamliIndirim"].ToString());
            }
            baglanti.Close();
            txtIndirim.Text = indirimTutar.ToString();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand command20 = new NpgsqlCommand("UPDATE \"iletisimBilgileri\" SET \"telefonNo\"=(@a1), \"adres\"=(@a2), \"il\"=(@a3), \"ilce\"=(@a4), \"postaKodu\"=(@a5) WHERE \"musteriNo\"='" + musteriNo + "'", baglanti);
            command20.Parameters.AddWithValue("@a1", txtTel.Text);
            command20.Parameters.AddWithValue("@a2", txtAdres.Text);
            command20.Parameters.AddWithValue("@a3", txtIl.Text);
            command20.Parameters.AddWithValue("@a4", txtIlce.Text);
            command20.Parameters.AddWithValue("@a5", txtPostaKodu.Text);
            command20.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command22 = new NpgsqlCommand("SELECT \"odaID\" FROM \"oda\" WHERE \"odaNo\"='" + cmbOdaNoYeni.Text + "'", baglanti);
            NpgsqlDataReader dataReader22 = command22.ExecuteReader();
            while (dataReader22.Read())
            {
                odaYeniID = int.Parse(dataReader22["odaID"].ToString()); 
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command21 = new NpgsqlCommand("UPDATE \"rezervasyon\" SET \"girisTarih\"=(@s1), \"cikisTarih\"=(@s2), \"odaID\"=(@s3) WHERE \"musteriNo\" ='" + musteriNo + "'", baglanti);
            command21.Parameters.AddWithValue("@s1", dtpGirisYeni.Value);
            command21.Parameters.AddWithValue("@s2", dtpCikisYeni.Value);
            command21.Parameters.AddWithValue("@s3", odaYeniID);
            command21.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command23 = new NpgsqlCommand("UPDATE \"gelir\" SET \"gelirTutar\"=(@d1), \"indirimsizTutar\"=(@d2) WHERE \"gelirNo\"='" + gelirNo + "'", baglanti);
            command23.Parameters.AddWithValue("@d1", double.Parse(txtTotal.Text));
            command23.Parameters.AddWithValue("@d2", double.Parse(txtTutar.Text));
            command23.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command26 = new NpgsqlCommand("UPDATE \"musteri\" SET \"musteriAd\"=(@h1), \"musteriSoyad\"=(@h2), \"dogumTarihi\"=(@h3), \"medeniHal\"=(@h4), \"cinsiyet\"=(@h5) WHERE \"musteriNo\"='" + musteriNo + "'", baglanti);
            command26.Parameters.AddWithValue("@h1", txtIsim.Text);
            command26.Parameters.AddWithValue("@h2", txtSoyisim.Text);
            command26.Parameters.AddWithValue("@h3", dateTimePicker1.Value);
            command26.Parameters.AddWithValue("@h4", cmbMedeni.Text);
            command26.Parameters.AddWithValue("@h5", cmbCinsiyet.Text);
            command26.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command27 = new NpgsqlCommand("UPDATE \"devamliMusteri\" SET \"devamliMusteriTC\"=(@j1) WHERE \"musteriNo\"='" + musteriNo + "'", baglanti);
            command27.Parameters.AddWithValue("@j1", txtTC.Text);
            command27.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command50 = new NpgsqlCommand("UPDATE \"yeniMusteri\" SET \"yeniMusteriTC\"=(@v1) WHERE \"musteriNo\"='" + musteriNo + "'", baglanti);
            command50.Parameters.AddWithValue("@v1", txtTC.Text);
            command50.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command24 = new NpgsqlCommand("UPDATE \"personelYakini\" SET \"personelYakiniTC\"=(@f1), \"personelYakiniAd\"=(@f2), \"personelYakiniSoyad\"=(@f3), \"medeniHal\"=(@f4), \"cinsiyet\"=(@f5), \"dogumTarihi\"=(@f6) WHERE \"personelYakiniTC\"='" + txtTC.Text + "'", baglanti);
            command24.Parameters.AddWithValue("@f1", txtTC.Text);
            command24.Parameters.AddWithValue("@f2", txtIsim.Text);
            command24.Parameters.AddWithValue("@f3", txtSoyisim.Text);
            command24.Parameters.AddWithValue("@f4", cmbMedeni.Text);
            command24.Parameters.AddWithValue("@f5", cmbCinsiyet.Text);
            command24.Parameters.AddWithValue("@f6", dateTimePicker1.Value);
            command24.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command25 = new NpgsqlCommand("UPDATE \"personelYakiniMusteri\" SET \"perYakMusTC\"=(@g1) WHERE \"perYakMusTC\"='" + txtTC.Text + "'", baglanti);
            command25.Parameters.AddWithValue("@g1", txtTC.Text);
            command25.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Oda Güncelleme Islemi Basarili");
            
        }

        private void fiyatHesaplama()
        {
            TimeSpan timeSpan = dateTimeCikis - dateTimeGiris;
            aradakiFark = timeSpan.Days;

            if (aradakiFark < 0)
            {
                aradakiFark = aradakiFark * -1;
            }

            odaToplamFiyat = odaFiyat * aradakiFark;

            txtTutar.Text = odaToplamFiyat.ToString();
        }

        private void toplamTutar()
        {
            genelTutar = odaToplamFiyat - indirimTutar;
            txtTotal.Text = genelTutar.ToString();
        }
        
        private void cmbOdaTipiYeni_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbOdaNoYeni.Items.Clear();
            baglanti.Open();
            NpgsqlCommand command30 = new NpgsqlCommand("SELECT \"odaFiyat\" FROM \"odaTur\" WHERE \"odaTurAdi\"='" + cmbOdaTipiYeni.SelectedItem + "'", baglanti);
            NpgsqlDataReader dataReader30 = command30.ExecuteReader();
            while (dataReader30.Read())
            {
                odaFiyat = double.Parse(dataReader30["odaFiyat"].ToString());

            }
            fiyatHesaplama();
            baglanti.Close();
            toplamTutar();

            baglanti.Open();
            NpgsqlCommand command12 = new NpgsqlCommand("SELECT \"odaTurID\" FROM \"odaTur\" WHERE \"odaTurAdi\"='" + cmbOdaTipiYeni.SelectedItem + "'", baglanti);
            NpgsqlDataReader dataReader12 = command12.ExecuteReader();
            while (dataReader12.Read())
            {
                odaTurID = int.Parse(dataReader12["odaTurID"].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command13 = new NpgsqlCommand("SELECT \"odaNo\" FROM \"oda\" WHERE \"odaTurID\"='" + odaTurID + "'", baglanti);
            NpgsqlDataReader dataReader13 = command13.ExecuteReader();
            while (dataReader13.Read())
            {
                cmbOdaNoYeni.Items.Add(dataReader13["odaNo"].ToString());
            }
            baglanti.Close();
        }

        private void cmbOdaNoYeni_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime dateGiris = DateTime.Today;
            DateTime dateCikis = DateTime.Today;
            baglanti.Open();
            NpgsqlCommand command32 = new NpgsqlCommand("SELECT \"odaID\" FROM \"oda\" WHERE \"odaNo\"='" + cmbOdaNoYeni.Text + "'", baglanti);
            NpgsqlDataReader dataReader32 = command32.ExecuteReader();
            while (dataReader32.Read())
            {
                odaID = int.Parse(dataReader32["odaID"].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command33 = new NpgsqlCommand("SELECT \"girisTarih\" , \"cikisTarih\" FROM \"rezervasyon\" WHERE \"odaID\"='" + odaID + "'", baglanti);
            NpgsqlDataReader dataReader33 = command33.ExecuteReader();
            while (dataReader33.Read())
            {
                dateGiris = Convert.ToDateTime(dataReader33["girisTarih"].ToString());
                dateCikis = Convert.ToDateTime(dataReader33["cikisTarih"].ToString());
            }
            baglanti.Close();


            DateTime musGiris = dtpGirisYeni.Value;

            if (musGiris < dateCikis)
            {
                MessageBox.Show("Bu Tarihler Arasında Sectiginiz Oda Dolu");
            }
        }

        private void dtpGirisYeni_ValueChanged(object sender, EventArgs e)
        {
            dateTimeGiris = dtpGirisYeni.Value;
            fiyatHesaplama();
            toplamTutar();
        }

        private void dtpCikisYeni_ValueChanged(object sender, EventArgs e)
        {
            dateTimeCikis = dtpCikisYeni.Value;
            fiyatHesaplama();
            toplamTutar();
        }
    }
}
