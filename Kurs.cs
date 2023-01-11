using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
namespace Müzik_Akamdemisi_Otomasyonu
{
    public partial class Kurs : Form
    {

        OleDbConnection Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Veri.accdb");
        OleDbCommand Veri_Komutu = new OleDbCommand();
        OleDbDataAdapter Veri_Adaptor = new OleDbDataAdapter();
        DataSet tasima = new DataSet();
        DataSet Veri_Seti;

        public Kurs()
        {
            InitializeComponent();
        }

        void Listele()
        {
            Veri_Adaptor = new OleDbDataAdapter("Select * from KURSUCRET", Veritabani_Baglanti);
            Veri_Seti = new DataSet();
            Veritabani_Baglanti.Open();
            Veri_Adaptor.Fill(Veri_Seti, "KURSUCRET");
            dataGridView1.DataSource = Veri_Seti.Tables["KURSUCRET"];
            Veritabani_Baglanti.Close();
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            if (btn_kaydet.Text != "")
            {
                Veri_Komutu.Connection = Veritabani_Baglanti;
                Veri_Komutu.CommandText = "Insert into KURSUCRET (OGRENCI_TC,OGRENCI_AD,OGRENCI_SOYAD,BRANS_ADI,KURS_UCRETI) values " + "('" + txt_adi.Text + "','" + txt_soyadi.Text + "','" + txt_tc.Text.ToString() + "','" + txt_bransad.Text + "','" + txt_fiyat.Text  + "')";
                Veritabani_Baglanti.Open();
                Veri_Komutu.ExecuteNonQuery();
                Veri_Komutu.Dispose();
                Veritabani_Baglanti.Close();
                MessageBox.Show("Bilgiler Eklendi!");
                Listele();
            }

        }
        private void btn_sil_Click(object sender, EventArgs e)
        {
            DialogResult c;
            c = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (c == DialogResult.Yes)
            {
                Veritabani_Baglanti.Open();
                Veri_Komutu.Connection = Veritabani_Baglanti;
                Veri_Komutu.CommandText = "delete from KURSUCRET where OGRENCI_ID=" + txt_silme.Text + "";
                Veri_Komutu.ExecuteNonQuery();
                Veri_Komutu.Dispose();
                Veritabani_Baglanti.Close();
                tasima.Clear();
                Listele();
            }
        }

        private void btn_güncelle_Click(object sender, EventArgs e)
        {

            Veri_Komutu = new OleDbCommand();
            Veritabani_Baglanti.Open();
            Veri_Komutu.Connection = Veritabani_Baglanti;
            Veri_Komutu.CommandText = "update KURSUCRET set OGRENCI_AD='" + txt_adi.Text + "',OGRENCI_SOYAD = '" + txt_soyadi.Text + "', OGRENCI_TC = '" + txt_tc.Text.ToString()  + "',BRANS_ADI '"+ txt_bransad.Text + "' ,KURS_UCRETI '" + txt_fiyat.Text + "'where OGRENCI_ID = " + txt_güncelle.Text + "";
            Veri_Komutu.ExecuteNonQuery();
            Veritabani_Baglanti.Close();
            MessageBox.Show("Bilgiler Güncellendi!");
            tasima.Clear();
            Listele();

        }
        private void Kurs_Load(object sender, EventArgs e)
        {
            Listele();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Anasayfa frm = new Anasayfa();
            frm.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            txt_adi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_soyadi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_tc.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_bransad.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_fiyat.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
           
        }
    }
}
