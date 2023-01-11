using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Müzik_Akamdemisi_Otomasyonu
{
    public partial class SınıflarDersler : Form
    {

        OleDbConnection Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Veri.accdb");
        OleDbCommand Veri_Komutu = new OleDbCommand();
        OleDbDataAdapter Veri_Adaptor = new OleDbDataAdapter();
        DataSet tasima = new DataSet();
        DataSet Veri_Seti;
        public SınıflarDersler()
        {
            InitializeComponent();
        }
        void SınıfListele()
        {
            Veri_Adaptor = new OleDbDataAdapter("Select SINIF_ID,SINIF_ADI from SINIFLAR", Veritabani_Baglanti);
            Veri_Seti = new DataSet();
            Veritabani_Baglanti.Open();
            Veri_Adaptor.Fill(Veri_Seti, "SINIFLAR");
            dataGridView1.DataSource = Veri_Seti.Tables["SINIFLAR"];
            Veritabani_Baglanti.Close();
        }
        void DersListele()
        {
            Veri_Adaptor = new OleDbDataAdapter("Select * from DERSLER", Veritabani_Baglanti);
            Veri_Seti = new DataSet();
            Veritabani_Baglanti.Open();
            Veri_Adaptor.Fill(Veri_Seti, "DERSLER");
            dataGridView2.DataSource = Veri_Seti.Tables["DERSLER"];
            Veritabani_Baglanti.Close();
        }
        private void btn_sınıf_ekle_Click(object sender, EventArgs e)
        {
            if (btn_sınıf_ekle.Text != "")
            {
                Veri_Komutu.Connection = Veritabani_Baglanti;
                Veri_Komutu.CommandText = "Insert into SINIFLAR(SINIF_ID)values " + "('" + txtb_sinif_adi.Text  + "')";
                Veritabani_Baglanti.Open();
                Veri_Komutu.ExecuteNonQuery();
                Veri_Komutu.Dispose();
                Veritabani_Baglanti.Close();
                MessageBox.Show("Sınıf Eklendi!");
                SınıfListele();
            }
        }

        private void btn_sinif_sil_Click(object sender, EventArgs e)
        {
            DialogResult c;
            c = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (c == DialogResult.Yes)
            {
                Veritabani_Baglanti.Open();
                Veri_Komutu.Connection = Veritabani_Baglanti;
                Veri_Komutu.CommandText = "delete from SINIFLAR where SINIF_ID=" + btn_sinif_sil.Text + "";
                Veri_Komutu.ExecuteNonQuery();
                Veri_Komutu.Dispose();
                Veritabani_Baglanti.Close();
                tasima.Clear();
                SınıfListele();
            }
        }

        private void btn_ders_ekle_Click(object sender, EventArgs e)
        {

            if (btn_ders_ekle.Text != "")
            {
                Veri_Komutu.Connection = Veritabani_Baglanti;
                Veri_Komutu.CommandText = "Insert into DERSLER(DERS_ID)values " + "('" + txt_ders_adı.Text + "')";
                Veritabani_Baglanti.Open();
                Veri_Komutu.ExecuteNonQuery();
                Veri_Komutu.Dispose();
                Veritabani_Baglanti.Close();
                MessageBox.Show("Ders Eklendi!");
                SınıfListele();
            }
        }

        private void btn_ders_sil_Click(object sender, EventArgs e)
        {
            DialogResult c;
            c = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (c == DialogResult.Yes)
            {
                Veritabani_Baglanti.Open();
                Veri_Komutu.Connection = Veritabani_Baglanti;
                Veri_Komutu.CommandText = "delete from DERSLER where DERS_ID=" + btn_ders_sil.Text + "";
                Veri_Komutu.ExecuteNonQuery();
                Veri_Komutu.Dispose();
                Veritabani_Baglanti.Close();
                tasima.Clear();
                SınıfListele();
            }
        }

        private void Sınıflar_Load(object sender, EventArgs e)
        {
            SınıfListele();
            DersListele();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            txtb_sinif_adi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            txt_ders_adı.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Anasayfa frm = new Anasayfa();
            frm.Show();
            this.Hide();
        }

    }
}
