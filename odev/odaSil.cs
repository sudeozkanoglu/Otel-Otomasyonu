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
    public partial class odaSil : Form
    {
        public odaSil()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user Id=postgres; password=12345");
        int odaTurID = 0;
        int odaID = 0;
        int odaTurID2 = 0;

        private void txtOdaNo_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM \"oda\" WHERE \"odaNo\"='" + int.Parse(txtOdaNo.Text) + "'", baglanti);
            NpgsqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                cmbOdaKat.Text = dataReader["odaKat"].ToString();
                txtOdaManzara.Text = dataReader["odaManzara"].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command2 = new NpgsqlCommand("SELECT \"odaTurID\" FROM \"oda\" WHERE \"odaNo\"='" + int.Parse(txtOdaNo.Text) + "'", baglanti);
            NpgsqlDataReader dataReader2 = command2.ExecuteReader();
            while (dataReader2.Read())
            {
                odaTurID = int.Parse(dataReader2["odaTurID"].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command3 = new NpgsqlCommand("SELECT * FROM \"odaTur\" WHERE \"odaTurID\"='" + odaTurID + "'", baglanti);
            NpgsqlDataReader dataReader3 = command3.ExecuteReader();
            while (dataReader3.Read())
            {
                cmbOdaTur.Text = dataReader3["odaTurAdi"].ToString();
                txtOdaFiyat.Text = dataReader3["odaFiyat"].ToString();
            }
            baglanti.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand command4 = new NpgsqlCommand("SELECT \"odaID\" FROM \"oda\" WHERE \"odaNo\"='" + int.Parse(txtOdaNo.Text) + "'", baglanti);
            NpgsqlDataReader dataReader4 = command4.ExecuteReader();
            while (dataReader4.Read())
            {
                odaID = int.Parse(dataReader4["odaID"].ToString());
            }
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command6 = new NpgsqlCommand("DELETE FROM \"rezervasyon\" WHERE \"odaID\"=(@l1)", baglanti);
            command6.Parameters.AddWithValue("@l1", odaID);
            command6.ExecuteNonQuery();
            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command7 = new NpgsqlCommand("DELETE FROM \"oda\" WHERE \"odaNo\"=(@l2)", baglanti);
            command7.Parameters.AddWithValue("@l2", int.Parse(txtOdaNo.Text));
            command7.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Oda Basariyla Silindi");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oda oda = new oda();
            this.Close();
            oda.ShowDialog();
        }
    }
}
