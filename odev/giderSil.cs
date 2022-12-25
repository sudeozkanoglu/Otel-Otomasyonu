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
    public partial class giderSil : Form
    {
        public giderSil()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost; port=5432; Database=proje; user Id=postgres; password=12345");
        int faturaID = 0;
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

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand command4 = new NpgsqlCommand("DELETE FROM \"gider\" WHERE \"giderNo\"=(@s1)", baglanti);
            command4.Parameters.AddWithValue("@s1", int.Parse(txtGiderNo.Text));
            command4.ExecuteNonQuery();
            baglanti.Close();
        }

        private void btnMenü_Click(object sender, EventArgs e)
        {
            gider gider = new gider();
            this.Close();
            gider.ShowDialog();
        }
    }
}
