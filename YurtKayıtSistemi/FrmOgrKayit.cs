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

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand komutKaydet = new SqlCommand("insert into Ogrenci (OgrAd,OgrSoyad,OgrTc,OgrTelefon,OgrDogum,OgrBolum,OgrMail,OgrOdaNo,OgrVeliAdSoyad,OgrVeliTelefon,OgrVeliAdres)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", baglanti);
                komutKaydet.Parameters.AddWithValue("@p1", txtOgrAd.Text);
                komutKaydet.Parameters.AddWithValue("@p2", txtOgrSoyad.Text);
                komutKaydet.Parameters.AddWithValue("@p3", mskTC.Text);
                komutKaydet.Parameters.AddWithValue("@p4", mskOgrTelefon.Text);
                komutKaydet.Parameters.AddWithValue("@p5", mskDogum.Text);
                komutKaydet.Parameters.AddWithValue("@p6", cmbBolum.Text);
                komutKaydet.Parameters.AddWithValue("@p7", txtMail.Text);
                komutKaydet.Parameters.AddWithValue("@p8", cmbOdaNo.Text);
                komutKaydet.Parameters.AddWithValue("@p9", txtVeliAdSoyad.Text);
                komutKaydet.Parameters.AddWithValue("@p10", mskVeliTelefon.Text);
                komutKaydet.Parameters.AddWithValue("@p11", rchAdres.Text);
                komutKaydet.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("kayıt başarılı bir şekilde eklendi");
            }
            catch (Exception)
            {

                MessageBox.Show("Hata lütfen yeniden deneyin");
            }
           
        }

    }
}
//Data Source=DESKTOP-P7OUVT3;Initial Catalog=YurtOtomasyonu;Integrated Security=True