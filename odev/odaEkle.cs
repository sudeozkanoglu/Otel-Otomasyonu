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
    public partial class odaEkle : Form
    {
        public odaEkle()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user Id=postgres; password=12345");
        int odaTurID = 0;
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try {
                baglanti.Open();
                NpgsqlCommand command2 = new NpgsqlCommand("SELECT \"odaTurID\" FROM \"odaTur\" WHERE \"odaTurAdi\"='" + cmbOdaTur.Text + "'", baglanti);
                NpgsqlDataReader dataReader = command2.ExecuteReader();

                while (dataReader.Read())
                {
                    odaTurID = int.Parse(dataReader["odaTurID"].ToString());
                }
                baglanti.Close();

                baglanti.Open();
                NpgsqlCommand command3 = new NpgsqlCommand("INSERT INTO oda (\"odaTurID\",\"odaNo\",\"odaKat\",\"odaManzara\") VALUES (@h1,@h2,@h3,@h4)", baglanti);
                command3.Parameters.AddWithValue("@h1", odaTurID);
                command3.Parameters.AddWithValue("@h2", int.Parse(txtOdaNo.Text));
                command3.Parameters.AddWithValue("@h3", int.Parse(cmbOdaKat.Text));
                command3.Parameters.AddWithValue("@h4", txtOdaManzara.Text);
                command3.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Oda Basariyla Eklendi");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Oteldeki Oda Sayısı 20'den Fazla Olamaz");
                NpgsqlCommand command4 = new NpgsqlCommand("DELETE FROM \"odaTur\" WHERE \"odaTurID\"=(@j1)", baglanti);
                command4.Parameters.AddWithValue("@j1", odaTurID);
                command4.ExecuteNonQuery();
                baglanti.Close();
            }  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oda oda = new oda();
            this.Close();
            oda.ShowDialog();
        }
    }
}
