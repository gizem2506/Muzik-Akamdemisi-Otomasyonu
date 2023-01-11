using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Müzik_Akamdemisi_Otomasyonu
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            Brans frm = new Brans();
            frm.Show();
            this.Hide();
        }

        private void btn_ogrenciler_Click(object sender, EventArgs e)
        {

            Ogrenciler frm = new Ogrenciler();
            frm.Show();
            this.Hide();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            Ogretmenler frm = new Ogretmenler();
            frm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SınıflarDersler frm = new SınıflarDersler();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kurs frm = new Kurs();
            frm.Show();
            this.Hide();
        }
    }
}
