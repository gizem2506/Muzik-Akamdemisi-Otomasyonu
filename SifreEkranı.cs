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
    public partial class SifreEkranı : Form
    {
        OleDbConnection Veritabani_Baglanti;
        OleDbCommand Veri_Komutu;
        OleDbDataReader Veri_Adaptor;
        public SifreEkranı()
        {
            InitializeComponent();
        }

      

      
       

        private void SifreEkranı_Load(object sender, EventArgs e)
        {
            
            comboBox1.Text = "Admin";
            textBox2.Text = "Admin123";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sifre = textBox2.Text;
            Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Veri.accdb");
            Veri_Komutu = new OleDbCommand();
            Veritabani_Baglanti.Open();
            Veri_Komutu.Connection = Veritabani_Baglanti;
            Veri_Komutu.CommandText = "SELECT * FROM Users where UserName='" + comboBox1.Text + "' AND UserPass='" + textBox2.Text + "'";
            Veri_Adaptor = Veri_Komutu.ExecuteReader();
            if (Veri_Adaptor.Read())
            {
                Anasayfa f2 = new Anasayfa();
                this.Hide();
                f2.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre HATALI!");
            }

            Veritabani_Baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
