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
    public partial class Brans : Form
    {

        OleDbConnection Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Veri.accdb");
        OleDbCommand Veri_Komutu = new OleDbCommand();
        OleDbDataAdapter Veri_Adaptor = new OleDbDataAdapter();
        DataSet tasima = new DataSet();
        DataSet Veri_Seti;

        public Brans()
        {
            InitializeComponent();
        }

        void Listele()
        {
            Veri_Adaptor = new OleDbDataAdapter("Select * from BRANS", Veritabani_Baglanti);
            Veri_Seti = new DataSet();
            Veritabani_Baglanti.Open();
            Veri_Adaptor.Fill(Veri_Seti, "BRANS");
            dataGridView1.DataSource = Veri_Seti.Tables["BRANS"];
            Veritabani_Baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             Listele();
        }
        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            if (btn_kaydet.Text != "")
            {
                Veri_Komutu.Connection = Veritabani_Baglanti;
                Veri_Komutu.CommandText = "Insert into BRANS (BRANS_AD) values " + "('" + txt__bransAd.Text + "')";
                Veritabani_Baglanti.Open();
                Veri_Komutu.ExecuteNonQuery();
                Veri_Komutu.Dispose();
                Veritabani_Baglanti.Close();
                MessageBox.Show("Branş Eklendi!");
                Listele();
            }
        }

        private void btn_güncelle_Click(object sender, EventArgs e)
        {
            Veri_Komutu = new OleDbCommand();
            Veritabani_Baglanti.Open();
            Veri_Komutu.Connection = Veritabani_Baglanti;
            Veri_Komutu.CommandText = "update BRANS set BRANS_AD='" + txt__bransAd.Text + "' where BRANS_ID=" + txt_güncelle.Text +"";
            Veri_Komutu.ExecuteNonQuery();
            Veritabani_Baglanti.Close();
            tasima.Clear();
            Listele();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            DialogResult c;
            c = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (c == DialogResult.Yes)
            {
                Veritabani_Baglanti.Open();
                Veri_Komutu.Connection = Veritabani_Baglanti;
                Veri_Komutu.CommandText = "delete from BRANS where BRANS_ID=" + txt_sil.Text + "";
                Veri_Komutu.ExecuteNonQuery();
                Veri_Komutu.Dispose();
                Veritabani_Baglanti.Close();
                tasima.Clear();
                Listele();
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            txt__bransAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Anasayfa frm = new Anasayfa();
            frm.Show();
            this.Hide();
        }
    }
    }

