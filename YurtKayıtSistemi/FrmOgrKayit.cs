using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace YurtKayıtSistemi
{
    public partial class FrmOgrKayit : Form
    {
        public FrmOgrKayit()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-P7OUVT3;Initial Catalog=YurtOtomasyonu;Integrated Security=True");
        

        private void FrmOgrKayit_Load(object sender, EventArgs e)
        {
            //bolumleri listeleme komutları
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select  BolumAd From Bolumler", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cmbBolum.Items.Add(oku[0].ToString());
            }
            baglanti.Close();
            // boş odsaları listeleme komutları
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select Odano From Odalar where OdaKapasite != OdaAktif", baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                cmbOdaNo.Items.Add(oku2[0].ToString());
            }
            baglanti.Close();
        }
    }
}
//Data Source=DESKTOP-P7OUVT3;Initial Catalog=YurtOtomasyonu;Integrated Security=True