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
    public partial class FrmBolumler : Form
    {
        public FrmBolumler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-P7OUVT3;Initial Catalog=YurtOtomasyonu;Integrated Security=True");


        private void FrmBolumler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtOtomasyonuDataSet.Bolumler' table. You can move, or remove it, as needed.
            this.bolumlerTableAdapter.Fill(this.yurtOtomasyonuDataSet.Bolumler);

        }

        private void pcbBolumEkle_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand komut1 = new SqlCommand("insert into Bolumler(BolumAd) values (@p1)", baglanti);
                komut1.Parameters.AddWithValue("@p1", txtBolumad.Text);
                komut1.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("bölüm eklendi");
                this.bolumlerTableAdapter.Fill(this.yurtOtomasyonuDataSet.Bolumler);
            }
            catch (Exception)
            {

                MessageBox.Show("hata oluştu yeniden deneyin");
            }
        }

        private void pcbBolumSil_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("delete from Bolumler where Bolumid=@p1", baglanti);
                komut2.Parameters.AddWithValue("@p1", txtBolumid.Text);
                komut2.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Silme işlemi gerçekleşti");
                this.bolumlerTableAdapter.Fill(this.yurtOtomasyonuDataSet.Bolumler);
            }
            catch (Exception)
            {

                MessageBox.Show("İşlem gerçekleşmedi");
            }
        }
        int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id, bolumad;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            bolumad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();

            txtBolumid.Text = id;
            txtBolumad.Text = bolumad;

        }

        private void pcbBolumDuzenle_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand komut3 = new SqlCommand("update Bolumler set Bolumad=@p1 where Bolumid=@p2", baglanti);
                komut3.Parameters.AddWithValue("@p2", txtBolumid.Text);
                komut3.Parameters.AddWithValue("@p1", txtBolumad.Text);
                komut3.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Güncelleme gerçekleşti");
                this.bolumlerTableAdapter.Fill(this.yurtOtomasyonuDataSet.Bolumler);
            }
            catch (Exception)
            {

                MessageBox.Show("Hata");
            }
        }
    }
}
