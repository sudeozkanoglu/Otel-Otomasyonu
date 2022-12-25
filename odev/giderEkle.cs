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
    public partial class giderEkle : Form
    {
        public giderEkle()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user Id=postgres; password=12345");

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            int giderNo = 0;
            baglanti.Open();
            NpgsqlCommand command = new NpgsqlCommand("INSERT INTO gider (\"giderTuru\",\"giderTutar\",\"giderTarih\",\"otelID\") VALUES (@k1,@k2,@k3,@k4)",baglanti);
            command.Parameters.AddWithValue("@k1",cmbGiderTur.Text);
            command.Parameters.AddWithValue("@k2",double.Parse(txtGiderTutar.Text));
            command.Parameters.AddWithValue("@k3",dtpGiderTarih.Value);
            command.Parameters.AddWithValue("k4", 1);
            command.ExecuteNonQuery();

            baglanti.Close();

            baglanti.Open();
            NpgsqlCommand command2 = new NpgsqlCommand("SELECT \"giderNo\" FROM gider", baglanti);
            NpgsqlDataReader dataReader = command2.ExecuteReader();

            while (dataReader.Read())
            {
                giderNo = int.Parse(dataReader["giderNo"].ToString());
            }

            baglanti.Close();

            MessageBox.Show("Gider Ekleme Islemi Basarılı. Gider No=" + giderNo);
        }

        private void btnMenü_Click(object sender, EventArgs e)
        {
            gider gider = new gider();
            this.Close();
            gider.ShowDialog();
        }
    }
}
