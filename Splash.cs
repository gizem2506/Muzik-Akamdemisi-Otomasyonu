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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }
        int second = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            second++;

            panel2.Left += 2;

            if (panel2.Left + panel2.Width > panel1.Width + 50)
            {
                panel2.Left = 0;
            }

            if (second == 390)
            {
                SifreEkranı form = new SifreEkranı();
                timer1.Stop();
                form.Show();
                this.Hide();

            }
        }

     
    }
}
