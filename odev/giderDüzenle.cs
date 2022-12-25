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
    public partial class giderDüzenle : Form
    {
        public giderDüzenle()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user Id=postgres; password=12345");

        private void txtGiderNo_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM \"gider\" WHERE \"giderNo\"='" + int.Parse(txtGiderNo.Text) + "'", baglanti);
            NpgsqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                dtpGiderTarih.Text = dataReader["giderTarih"].ToString();
                cmbGiderTur.Text = dataReader["giderTuru"].ToString();
                txtGiderTutar.Text = dataReader["giderTutar"].ToString();
            }
            baglanti.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand command2 = new NpgsqlCommand("UPDATE gider SET \"giderTarih\"=@k1,\"giderTuru\"=@k2,\"giderTutar\"=@k3 WHERE \"giderNo\"='" + int.Parse(txtGiderNo.Text) + "'", baglanti);
            command2.Parameters.AddWithValue("@k1", dtpGiderTarih.Value);
            command2.Parameters.AddWithValue("@k2", cmbGiderTur.Text);
            command2.Parameters.AddWithValue("@k3", double.Parse(txtGiderTutar.Text));
            command2.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Gider Basariyla Güncellendi");
        }

        private void btnMenü_Click(object sender, EventArgs e)
        {
            gider gider = new gider();
            this.Close();
            gider.ShowDialog();
        }
    }
}
