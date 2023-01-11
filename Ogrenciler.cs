using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
namespace Müzik_Akamdemisi_Otomasyonu
{
    public partial class Ogrenciler : Form
    {

        OleDbConnection Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Veri.accdb");
        OleDbCommand Veri_Komutu = new OleDbCommand();
        OleDbDataAdapter Veri_Adaptor = new OleDbDataAdapter();
        DataSet tasima = new DataSet();
        DataSet Veri_Seti;

        public Ogrenciler()
        {
            InitializeComponent();
        }
        void Listele()
        {
            Veri_Adaptor = new OleDbDataAdapter("Select * from OGRENCI", Veritabani_Baglanti);
            Veri_Seti = new DataSet();
            Veritabani_Baglanti.Open();
            Veri_Adaptor.Fill(Veri_Seti, "OGRENCI");
            dataGridView1.DataSource = Veri_Seti.Tables["OGRENCI"];
            Veritabani_Baglanti.Close();
        }
        private void Ogrenciler_Load(object sender, EventArgs e)
        {
            Listele();

        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            if (btn_kaydet.Text != "")
            {
                Veri_Komutu.Connection = Veritabani_Baglanti;
                Veri_Komutu.CommandText = "Insert into OGRENCI (OGRENCI_ADI,OGRENCI_SOYADI,OGRENCI_TC,DOGUM_T,CINSIYET,TELEFON,ADRES,RESIM) values " + "('" + txt_adi.Text + "','" + txt_soyadi.Text + "','" + txt_tc.Text.ToString() + "','" + txt_dogumt.Text + "','" + txt_cinsiyet.Text + "','" + txt_telefon.Text.ToString() + "','" + txt_adres.Text + "','" + textBox7.Text + "')";
                Veritabani_Baglanti.Open();
                Veri_Komutu.ExecuteNonQuery();
                Veri_Komutu.Dispose();
                Veritabani_Baglanti.Close();
                MessageBox.Show("Öğrenci Eklendi!");
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
                Veri_Komutu.CommandText = "delete from OGRENCI where OGRENCI_ID=" + txt_silme.Text + "";
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
            Veri_Komutu.CommandText = "update OGRENCI set OGRENCI_ADI='" + txt_adi.Text + "',OGRENCI_SOYADI = '" + txt_soyadi.Text + "', OGRENCI_TC = '" + txt_tc.Text.ToString() + "',DOGUM_T = '" + txt_dogumt.Text + "',CINSIYET = '" + txt_cinsiyet.Text + "',TELEFON = '" + txt_telefon.Text.ToString() + "',ADRES = '" + txt_adres.Text +"',RESIM='" +textBox7+ "'where OGRENCI_ID = " + txt_güncelle.Text + "";
            Veri_Komutu.ExecuteNonQuery();
            Veritabani_Baglanti.Close();
            tasima.Clear();
            Listele();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            txt_adi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_soyadi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_tc.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_dogumt.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_cinsiyet.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txt_telefon.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txt_adres.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            pictureBox1.ImageLocation = textBox7.Text;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Anasayfa frm = new Anasayfa();
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.png |  Tüm Dosyalar |*.*";
            dosya.ShowDialog();
            string dosyayolu = dosya.FileName;
            textBox7.Text = dosyayolu;
            pictureBox1.ImageLocation = dosyayolu;
        }

        private void btn_sil_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_güncelle_Click_1(object sender, EventArgs e)
        {

        }
    }
}
