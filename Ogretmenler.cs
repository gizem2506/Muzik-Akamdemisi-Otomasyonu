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
    public partial class Ogretmenler : Form
    {

        OleDbConnection Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Veri.accdb");
        OleDbCommand Veri_Komutu = new OleDbCommand();
        OleDbDataAdapter Veri_Adaptor = new OleDbDataAdapter();
        DataSet tasima = new DataSet();
        DataSet Veri_Seti;

        public Ogretmenler()
        {
            InitializeComponent();
        }

        void Listele()
        {
            Veri_Adaptor = new OleDbDataAdapter("Select * from OGRETMEN", Veritabani_Baglanti);
            Veri_Seti = new DataSet();
            Veritabani_Baglanti.Open();
            Veri_Adaptor.Fill(Veri_Seti, "OGRETMEN");
            dataGridView1.DataSource = Veri_Seti.Tables["OGRETMEN"];
            Veritabani_Baglanti.Close();
        }
        private void Ogretmenler_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            if (btn_kaydet.Text != "")
            {
                Veri_Komutu.Connection = Veritabani_Baglanti;
                Veri_Komutu.CommandText = "Insert into OGRETMEN(OGRETMEN_ID,OGRETMEN_ADI, OGRETMEN_SOYADI, OGRETMEN_TC, DOGUM_T, CINSIYET, TELEFON, ADRES, MAIL, BRANS,RESIM)values " + "('" + txt_ad.Text + "','" + txt_soyad.Text + "','" + txt_tc.Text.ToString() + "','" + txt_dogumt.Text + "','" + txt_cinsyt.Text + "','" + txt_telefon.Text.ToString() + "','" + txt_adres.Text + "','" + txt_mail.Text + "','" + txt_bransadi.Text + "','" + textBox7.Text + "')";
                Veritabani_Baglanti.Open();
                Veri_Komutu.ExecuteNonQuery();
                Veri_Komutu.Dispose();
                Veritabani_Baglanti.Close();
                MessageBox.Show("Öğretmen Bilgileri Eklendi!");
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
                Veri_Komutu.CommandText = "delete from OGRETMEN where OGRETMEN_ID=" + txt_sil.Text + "";
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
            Veri_Komutu.CommandText = "update OGRETMEN set OGRETMEN_ADI='" + txt_ad.Text + "',OGRETMEN_SOYADI = '" + txt_soyad.Text + "', OGRETMEN_TC = '" + txt_tc.Text.ToString() + "',DOGUM_T = '" + txt_dogumt.Text + "',CINSIYET = '" + txt_cinsyt.Text + "',TELEFON = '" + txt_telefon.Text.ToString() + "',ADRES = '" + txt_adres.Text + "',MAIL='" + txt_mail.Text + "',BRANS'" + txt_bransadi.Text +"',RESIM='"+textBox7+ "'where OGRETMEN_ID = " + txt_güncelle.Text + "";
            Veri_Komutu.ExecuteNonQuery();
            Veritabani_Baglanti.Close();
            tasima.Clear();
            Listele();
        }
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            txt_ad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_soyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_tc.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_dogumt.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_cinsyt.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txt_telefon.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txt_adres.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txt_mail.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txt_bransadi.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
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
    }
}