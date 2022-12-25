using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace odev
{
    public partial class rezervasyonOlustur : Form
    {

       
        public rezervasyonOlustur()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user Id=postgres; password=12345");
        int sayac;
        double odaFiyat;
        double odaToplamFiyat;
        int aradakiFark;
        int indirimID;
        int odaTurID;
        double indirimTutar;
        double genelTutar;
        int odaID;
        string personelYakiniMusTC = "";
        string personelYakiniTC = "";
        int musNo;
        string devamliTC = "";
        int devamliMusNo;
        int yeniMusNo;
        int perYakMusTC;
        int personelYakiniNo;
        int musNo2;
        int gelirNo;
        int newIndirimID;
        DateTime dateTimeGiris;
        DateTime dateTimeCikis;
        private void btnMenü_Click(object sender, EventArgs e)
        {
            Rezervasyon rezervasyon = new Rezervasyon();
            this.Close();
            rezervasyon.Show();
        }
        private void rezervasyonOlustur_Load(object sender, EventArgs e)
        {
            txtIndirim.Text = "0";
            dateTimeGiris = dtpGiris.Value;
            dateTimeCikis = dtpCikis.Value;
            fiyatHesaplama();
        }
        private void txtTC_TextChanged_1(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM \"personelYakini\" INNER JOIN \"iletisimBilgileri\" ON \"personelYakini\".\"personelYakiniNo\" = \"iletisimBilgileri\".\"personelYakiniNo\" WHERE \"personelYakiniTC\"='" + txtTC.Text + "'", baglanti);
            NpgsqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                txtSicil.Text = dataReader["perYakSicilNo"].ToString();
                txtIsim.Text = dataReader["personelYakiniAd"].ToString();
                txtSoyisim.Text = dataReader["personelYakiniSoyad"].ToString();
                cmbCinsiyet.Text = dataReader["cinsiyet"].ToString();
                dtpDogum.Text = dataReader["dogumTarihi"].ToString();
                cmbMedeni.Text = dataReader["medeniHal"].ToString();
                txtTel.Text = dataReader["telefonNo"].ToString();
                txtAdres.Text = dataReader["adres"].ToString();
                txtIl.Text = dataReader["il"].ToString();
                txtIlce.Text = dataReader["ilce"].ToString();
                txtPostaKodu.Text = dataReader["postaKodu"].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command4 = new NpgsqlCommand("SELECT * FROM \"musteri\" INNER JOIN \"devamliMusteri\" ON \"musteri\".\"musteriNo\" = \"devamliMusteri\".\"musteriNo\" INNER JOIN \"iletisimBilgileri\" ON \"musteri\".\"musteriNo\" = \"iletisimBilgileri\".\"musteriNo\" WHERE \"devamliMusteriTC\"='" + txtTC.Text + "'", baglanti);
            NpgsqlDataReader dataReader1 = command4.ExecuteReader();
            while (dataReader1.Read())
            {
                txtSicil.Text = dataReader1["sicilNo"].ToString();
                txtIsim.Text = dataReader1["musteriAd"].ToString();
                txtSoyisim.Text = dataReader1["musteriSoyad"].ToString();
                cmbCinsiyet.Text = dataReader1["cinsiyet"].ToString();
                dtpDogum.Text = dataReader1["dogumTarihi"].ToString();
                cmbMedeni.Text = dataReader1["medeniHal"].ToString();
                txtTel.Text = dataReader1["telefonNo"].ToString();
                txtAdres.Text = dataReader1["adres"].ToString();
                txtIl.Text = dataReader1["il"].ToString();
                txtIlce.Text = dataReader1["ilce"].ToString();
                txtPostaKodu.Text = dataReader1["postaKodu"].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command401 = new NpgsqlCommand("SELECT * FROM \"musteri\" INNER JOIN \"yeniMusteri\" ON \"musteri\".\"musteriNo\"=\"yeniMusteri\".\"musteriNo\" INNER JOIN \"iletisimBilgileri\" ON \"musteri\".\"musteriNo\" = \"iletisimBilgileri\".\"musteriNo\" WHERE \"yeniMusteriTC\"='" + txtTC.Text + "'", baglanti);
            NpgsqlDataReader dataReader401 = command401.ExecuteReader();
            while (dataReader401.Read())
            {
                txtSicil.Text = dataReader401["sicilNo"].ToString();
                txtIsim.Text = dataReader401["musteriAd"].ToString();
                txtSoyisim.Text = dataReader401["musteriSoyad"].ToString();
                cmbCinsiyet.Text = dataReader401["cinsiyet"].ToString();
                dtpDogum.Text = dataReader401["dogumTarihi"].ToString();
                cmbMedeni.Text = dataReader401["medeniHal"].ToString();
                txtTel.Text = dataReader401["telefonNo"].ToString();
                txtAdres.Text = dataReader401["adres"].ToString();
                txtIl.Text = dataReader401["il"].ToString();
                txtIlce.Text = dataReader401["ilce"].ToString();
                txtPostaKodu.Text = dataReader401["postaKodu"].ToString();
            }
            baglanti.Close();
        }

        private void cmbOdaTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbOdaNo.Items.Clear();
            baglanti.Open();
            NpgsqlCommand command2 = new NpgsqlCommand("SELECT \"odaFiyat\" FROM \"odaTur\" WHERE \"odaTurAdi\"='" + cmbOdaTipi.SelectedItem + "'", baglanti);
            NpgsqlDataReader dataReader2 = command2.ExecuteReader();
            while (dataReader2.Read())
            {
                odaFiyat = double.Parse(dataReader2["odaFiyat"].ToString());

            }
            fiyatHesaplama();
            baglanti.Close();
            toplamTutar();

            baglanti.Open();
            NpgsqlCommand command12 = new NpgsqlCommand("SELECT \"odaTurID\" FROM \"odaTur\" WHERE \"odaTurAdi\"='" + cmbOdaTipi.SelectedItem + "'", baglanti);
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
                cmbOdaNo.Items.Add(dataReader13["odaNo"].ToString());
            }
            baglanti.Close();
        }

        private void dtpGiris_ValueChanged(object sender, EventArgs e)
        {
            dateTimeGiris = dtpGiris.Value;
            fiyatHesaplama();
            toplamTutar();
        }

        private void dtpCikis_ValueChanged(object sender, EventArgs e)
        {
            dateTimeCikis = dtpCikis.Value;
            fiyatHesaplama();
            toplamTutar();
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
            baglanti.Open();
            NpgsqlCommand command500 = new NpgsqlCommand("SELECT \"indirimID\" FROM \"indirim\"",baglanti);
            NpgsqlDataReader dataReader500 = command500.ExecuteReader();
            while (dataReader500.Read())
            {
                newIndirimID = int.Parse(dataReader500["indirimID"].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command6 = new NpgsqlCommand("SELECT \"indirimID\" FROM \"personelYakini\" WHERE \"personelYakiniTC\"='" + txtTC.Text + "'", baglanti);
            NpgsqlDataReader dataReader6 = command6.ExecuteReader();
            while (dataReader6.Read())
            {
                indirimID = int.Parse(dataReader6["indirimID"].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command7 = new NpgsqlCommand("SELECT \"personelIndirim\" FROM \"indirim\" WHERE \"indirimID\"='" + indirimID + "'", baglanti);
            NpgsqlDataReader dataReader7 = command7.ExecuteReader();
            while (dataReader7.Read())
            {
                txtIndirim.Text = dataReader7["personelIndirim"].ToString();
            }
            indirimTutar = double.Parse(txtIndirim.Text);
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
            indirimTutar = double.Parse(txtIndirim.Text); 
            baglanti.Close();

            genelTutar = odaToplamFiyat - indirimTutar;
            txtTotal.Text = genelTutar.ToString();
        }
        private void cmbOdaNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime dateGiris = DateTime.Today;
            DateTime dateCikis = DateTime.Today;
            baglanti.Open();
            NpgsqlCommand command20 = new NpgsqlCommand("SELECT \"odaID\" FROM \"oda\" WHERE \"odaNo\"='" + cmbOdaNo.Text + "'", baglanti);
            NpgsqlDataReader dataReader20 = command20.ExecuteReader();
            while (dataReader20.Read())
            {
                odaID = int.Parse(dataReader20["odaID"].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command21 = new NpgsqlCommand("SELECT \"girisTarih\" , \"cikisTarih\" FROM \"rezervasyon\" WHERE \"odaID\"='" + odaID + "'", baglanti);
            NpgsqlDataReader dataReader21 = command21.ExecuteReader();
            while (dataReader21.Read())
            {
                dateGiris = Convert.ToDateTime(dataReader21["girisTarih"].ToString());
                dateCikis = Convert.ToDateTime(dataReader21["cikisTarih"].ToString());
            }
            baglanti.Close();


            DateTime musGiris = dtpGiris.Value;

            if (musGiris < dateCikis)
            {
                MessageBox.Show("Bu Tarihler Arasında Sectiginiz Oda Dolu");
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand command25 = new NpgsqlCommand("SELECT \"personelYakiniTC\" FROM \"personelYakini\" WHERE \"personelYakiniTC\"='" + txtTC.Text + "'", baglanti);
            NpgsqlDataReader dataReader25 = command25.ExecuteReader();
            while (dataReader25.Read())
            {
                personelYakiniTC = dataReader25["personelYakiniTC"].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command125 = new NpgsqlCommand("SELECT \"perYakMusTC\" FROM \"personelYakiniMusteri\" WHERE \"perYakMusTC\"='" + txtTC.Text + "'", baglanti);
            NpgsqlDataReader dataReader125 = command125.ExecuteReader();
            while (dataReader125.Read())
            {
                personelYakiniMusTC = dataReader125["perYakMusTC"].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command35 = new NpgsqlCommand("SELECT \"devamliMusteriTC\" FROM \"devamliMusteri\" WHERE \"devamliMusteriTC\"='" + txtTC.Text + "'", baglanti);
            NpgsqlDataReader dataReader35 = command35.ExecuteReader();
            while (dataReader35.Read())
            {
                devamliTC = dataReader35["devamliTC"].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command27 = new NpgsqlCommand("INSERT INTO \"gelir\" (\"gelirTuru\", \"gelirTutar\", \"otelID\",\"indirimsizTutar\") VALUES (@s1,@s2,@s3,@s4)", baglanti);
            command27.Parameters.AddWithValue("@s1", "Oda Rezervasyon");
            command27.Parameters.AddWithValue("@s2", double.Parse(txtTotal.Text));
            command27.Parameters.AddWithValue("@s3", 1);
            command27.Parameters.AddWithValue("@s4", double.Parse(txtTutar.Text));
            command27.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command202 = new NpgsqlCommand("SELECT \"gelirNo\" FROM \"gelir\"", baglanti);
            NpgsqlDataReader dataReader202 = command202.ExecuteReader();
            while (dataReader202.Read())
            {
                gelirNo = int.Parse(dataReader202["gelirNo"].ToString());
            }
            baglanti.Close(); 
            
            baglanti.Open();
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand("SELECT \"musteriNo\" FROM \"musteri\" WHERE \"sicilNo\"='" + txtSicil.Text + "'", baglanti);
            NpgsqlDataReader npgsqlDataReader = npgsqlCommand.ExecuteReader();
            while (npgsqlDataReader.Read())
            {
                musNo2 = int.Parse(npgsqlDataReader["musteriNo"].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command66 = new NpgsqlCommand("SELECT COUNT(*) FROM \"rezervasyon\" WHERE \"musteriNo\"='" + musNo2 + "'", baglanti);
            NpgsqlDataReader command66DataReader = command66.ExecuteReader();
            while (command66DataReader.Read())
            {
                sayac = int.Parse(command66DataReader["count"].ToString());
            }
            baglanti.Close();

            if (sayac >= 1)
            {
                baglanti.Open();
                NpgsqlCommand command80 = new NpgsqlCommand("SELECT \"musteriNo\" FROM \"musteri\" WHERE \"sicilNo\"='" + txtSicil.Text + "'", baglanti);
                NpgsqlDataReader dataReader80 = command80.ExecuteReader();
                while (dataReader80.Read())
                {
                    yeniMusNo = int.Parse(dataReader80["musteriNo"].ToString());
                }
                baglanti.Close();

                baglanti.Open();
                NpgsqlCommand command90 = new NpgsqlCommand("INSERT INTO \"devamliMusteri\" (\"musteriNo\",\"devamliMusteriTC\",\"indirimID\") VALUES (@r1,@r2,@r3)", baglanti);
                command90.Parameters.AddWithValue("@r1", yeniMusNo);
                command90.Parameters.AddWithValue("@r2", txtTC.Text);
                command90.Parameters.AddWithValue("@r3", newIndirimID);
                command90.ExecuteNonQuery();
                baglanti.Close();

                baglanti.Open();
                NpgsqlCommand command405 = new NpgsqlCommand("INSERT INTO \"rezervasyon\" (\"girisTarih\",\"cikisTarih\",\"odaID\",\"musteriNo\",\"gelirNo\") VALUES (@R1,@R2,@R3,@R4,@R5)", baglanti);
                command405.Parameters.AddWithValue("@R1", dtpGiris.Value);
                command405.Parameters.AddWithValue("@R2", dtpCikis.Value);
                command405.Parameters.AddWithValue("@R3", odaID);
                command405.Parameters.AddWithValue("@R4", yeniMusNo);
                command405.Parameters.AddWithValue("@R5", gelirNo);
                command405.ExecuteNonQuery();
                baglanti.Close();

                baglanti.Open();
                NpgsqlCommand command201 = new NpgsqlCommand("UPDATE \"musteri\" SET \"musteriTipi\"=(@f1) WHERE \"musteriNo\"='" + yeniMusNo + "'", baglanti);
                command201.Parameters.AddWithValue("@f1", "Devamli Musteri");
                command201.ExecuteNonQuery();
                baglanti.Close();

                baglanti.Open();
                NpgsqlCommand command100 = new NpgsqlCommand("DELETE FROM \"yeniMusteri\" WHERE \"musteriNo\"=(@o1)", baglanti);
                command100.Parameters.AddWithValue("@o1", yeniMusNo);
                command100.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Rezervasyon Basariyla Yapildi");


            }
            else if (sayac == 0)
            {
                if (string.IsNullOrEmpty(personelYakiniMusTC) == false)
                {
                    baglanti.Open();
                    NpgsqlCommand command140 = new NpgsqlCommand("SELECT \"musteriNo\" FROM \"personelYakiniMusteri\" WHERE \"perYakMusTC\"='" + txtTC.Text + "'", baglanti);
                    NpgsqlDataReader dataReader140 = command140.ExecuteReader();
                    while (dataReader140.Read())
                    {
                        perYakMusTC = int.Parse(dataReader140["musteriNo"].ToString());
                    }
                    baglanti.Close();

                    baglanti.Open();
                    NpgsqlCommand command41 = new NpgsqlCommand("INSERT INTO \"rezervasyon\" (\"girisTarih\",\"cikisTarih\",\"odaID\",\"musteriNo\",\"personelYakiniNo\",\"gelirNo\") VALUES (@t1,@t2,@t3,@t4,@t5,@t6)", baglanti);
                    command41.Parameters.AddWithValue("@t1", dtpGiris.Value);
                    command41.Parameters.AddWithValue("@t2", dtpCikis.Value);
                    command41.Parameters.AddWithValue("@t3", odaID);
                    command41.Parameters.AddWithValue("@t4", perYakMusTC);
                    command41.Parameters.AddWithValue("@t5", personelYakiniNo);
                    command41.Parameters.AddWithValue("@t6", gelirNo);
                    command41.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Rezervasyon Basariyla Yapildi");
                    

                }
                else if (string.IsNullOrEmpty(devamliTC) == false)
                {
                    baglanti.Open();
                    NpgsqlCommand command40 = new NpgsqlCommand("SELECT \"musteriNo\" FROM \"devamliMusteri\" WHERE \"devamliMusteriTC\"='" + txtTC.Text + "'", baglanti);
                    NpgsqlDataReader dataReader40 = command40.ExecuteReader();
                    while (dataReader40.Read())
                    {
                        devamliMusNo = int.Parse(dataReader40["musteriNo"].ToString());
                    }
                    baglanti.Close();

                    baglanti.Open();
                    NpgsqlCommand command41 = new NpgsqlCommand("INSERT INTO \"rezervasyon\" (\"girisTarihi\",\"cikisTarihi\",\"odaID\",\"musteriNo\",\"gelirNo\") VALUES (@t1,@t2,@t3,@t4,@t5)", baglanti);
                    command41.Parameters.AddWithValue("@t1", dtpGiris.Value);
                    command41.Parameters.AddWithValue("@t2", dtpCikis.Value);
                    command41.Parameters.AddWithValue("@t3", odaID);
                    command41.Parameters.AddWithValue("@t4", devamliMusNo);
                    command41.Parameters.AddWithValue("@t5", gelirNo);
                    command41.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Rezervasyon Basariyla Yapildi");

                }
                else if (string.IsNullOrEmpty(personelYakiniTC) == false)
                {
                    baglanti.Open();
                    NpgsqlCommand command26 = new NpgsqlCommand("INSERT INTO \"musteri\" (\"musteriAd\", \"musteriSoyad\" , \"dogumTarihi\", \"medeniHal\" , \"cinsiyet\" ,\"otelID\" , \"sicilNo\") VALUES (@m1,@m2,@m3,@m4,@m5,@m6,@m7) ", baglanti);
                    command26.Parameters.AddWithValue("@m1", txtIsim.Text);
                    command26.Parameters.AddWithValue("@m2", txtSoyisim.Text);
                    command26.Parameters.AddWithValue("@m3", dtpDogum.Value);
                    command26.Parameters.AddWithValue("@m4", cmbMedeni.Text);
                    command26.Parameters.AddWithValue("@m5", cmbCinsiyet.Text);
                    command26.Parameters.AddWithValue("@m6", 1);
                    command26.Parameters.AddWithValue("@m7", txtSicil.Text);
                    command26.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    NpgsqlCommand command33 = new NpgsqlCommand("SELECT \"musteriNo\" FROM \"musteri\" WHERE \"sicilNo\"='" + txtSicil.Text + "'", baglanti);
                    NpgsqlDataReader dataReader33 = command33.ExecuteReader();
                    while (dataReader33.Read())
                    {
                        musNo = int.Parse(dataReader33["musteriNo"].ToString());
                    }
                    baglanti.Close();

                    baglanti.Open();
                    NpgsqlCommand command50 = new NpgsqlCommand("SELECT \"personelYakiniNo\" FROM \"personelYakini\" WHERE \"personelYakiniTC\"='" + txtTC.Text + "'", baglanti);
                    NpgsqlDataReader dataReader50 = command50.ExecuteReader();
                    while (dataReader50.Read())
                    {
                        personelYakiniNo = int.Parse(dataReader50["personelYakiniNo"].ToString());
                    }
                    baglanti.Close();

                    baglanti.Open();
                    NpgsqlCommand command150 = new NpgsqlCommand("UPDATE \"iletisimBilgileri\" SET \"musteriNo\"=@p1  WHERE \"personelYakiniNo\"='" + personelYakiniNo + "'", baglanti);
                    command150.Parameters.AddWithValue("@p1", musNo);
                    command150.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    NpgsqlCommand command34 = new NpgsqlCommand("INSERT INTO \"personelYakiniMusteri\" (\"personelYakiniNo\",\"perYakMusTC\",\"musteriNo\") VALUES (@w1,@w2,@w3)", baglanti);
                    command34.Parameters.AddWithValue("@w1", personelYakiniNo);
                    command34.Parameters.AddWithValue("@w2", txtTC.Text);
                    command34.Parameters.AddWithValue("@w3", musNo);
                    command34.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    NpgsqlCommand command41 = new NpgsqlCommand("INSERT INTO \"rezervasyon\" (\"girisTarih\",\"cikisTarih\",\"odaID\",\"musteriNo\",\"personelYakiniNo\",\"gelirNo\") VALUES (@t1,@t2,@t3,@t4,@t5,@t6)", baglanti);
                    command41.Parameters.AddWithValue("@t1", dtpGiris.Value);
                    command41.Parameters.AddWithValue("@t2", dtpCikis.Value);
                    command41.Parameters.AddWithValue("@t3", odaID);
                    command41.Parameters.AddWithValue("@t4", musNo);
                    command41.Parameters.AddWithValue("@t5", personelYakiniNo);
                    command41.Parameters.AddWithValue("@t6", gelirNo);
                    command41.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    NpgsqlCommand command400 = new NpgsqlCommand("UPDATE \"personelYakini\" SET \"perYakMus\"=@w1 WHERE \"personelYakiniNo\"='" + personelYakiniNo + "'", baglanti);
                    command400.Parameters.AddWithValue("@w1", "Musteri");
                    command400.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Rezervasyon Basariyla Yapildi");
                }
                else
                {
                    try 
                    {
                        baglanti.Open();
                        NpgsqlCommand command43 = new NpgsqlCommand("INSERT INTO \"musteri\" (\"musteriAd\", \"musteriSoyad\" , \"dogumTarihi\", \"medeniHal\" , \"cinsiyet\" ,\"musteriTipi\", \"otelID\" , \"sicilNo\") VALUES (@m1,@m2,@m3,@m4,@m5,@m6,@m7,@m8) ", baglanti);
                        command43.Parameters.AddWithValue("@m1", txtIsim.Text);
                        command43.Parameters.AddWithValue("@m2", txtSoyisim.Text);
                        command43.Parameters.AddWithValue("@m3", dtpDogum.Value);
                        command43.Parameters.AddWithValue("@m4", cmbMedeni.Text);
                        command43.Parameters.AddWithValue("@m5", cmbCinsiyet.Text);
                        command43.Parameters.AddWithValue("@m6", "Yeni Musteri");
                        command43.Parameters.AddWithValue("@m7", 1);
                        command43.Parameters.AddWithValue("@m8", txtSicil.Text);
                        command43.ExecuteNonQuery();
                        baglanti.Close();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Sicil Numarası 10 Haneden Fazla Olamaz !");
                        System.Environment.Exit(0);
                    }
                    

                    baglanti.Open();
                    NpgsqlCommand command40 = new NpgsqlCommand("SELECT \"musteriNo\" FROM \"musteri\" WHERE \"sicilNo\"='" + txtSicil.Text + "'", baglanti);
                    NpgsqlDataReader dataReader40 = command40.ExecuteReader();
                    while (dataReader40.Read())
                    {
                        yeniMusNo = int.Parse(dataReader40["musteriNo"].ToString());
                    }
                    baglanti.Close();

                    baglanti.Open();
                    NpgsqlCommand command151 = new NpgsqlCommand("INSERT INTO \"iletisimBilgileri\" (\"telefonNo\",\"adres\",\"il\",\"ilce\",\"postaKodu\",\"musteriNo\",\"otelID\") VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", baglanti);
                    command151.Parameters.AddWithValue("@p1", txtTel.Text);
                    command151.Parameters.AddWithValue("@p2", txtAdres.Text);
                    command151.Parameters.AddWithValue("@p3", txtIl.Text);
                    command151.Parameters.AddWithValue("@p4", txtIlce.Text);
                    command151.Parameters.AddWithValue("@p5", txtPostaKodu.Text);
                    command151.Parameters.AddWithValue("@p6", yeniMusNo);
                    command151.Parameters.AddWithValue("@p7", 1);
                    command151.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    NpgsqlCommand command51 = new NpgsqlCommand("INSERT INTO \"yeniMusteri\" (\"musteriNo\",\"yeniMusteriTC\") VALUES (@r1,@r2)", baglanti);
                    command51.Parameters.AddWithValue("@r1", yeniMusNo);
                    command51.Parameters.AddWithValue("@r2", txtTC.Text);
                    command51.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    NpgsqlCommand command41 = new NpgsqlCommand("INSERT INTO \"rezervasyon\" (\"girisTarih\",\"cikisTarih\",\"odaID\",\"musteriNo\",\"gelirNo\") VALUES (@t1,@t2,@t3,@t4,@t5)", baglanti);
                    command41.Parameters.AddWithValue("@t1", dtpGiris.Value);
                    command41.Parameters.AddWithValue("@t2", dtpCikis.Value);
                    command41.Parameters.AddWithValue("@t3", odaID);
                    command41.Parameters.AddWithValue("@t4", yeniMusNo);
                    command41.Parameters.AddWithValue("@t5", gelirNo);
                    command41.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Rezervasyon Basariyla Yapildi !");
                }
            }
        }
    }
}
