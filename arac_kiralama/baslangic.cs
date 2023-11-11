using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arac_kiralama
{
    public partial class baslangic : Form
    {
        public baslangic()
        {
            InitializeComponent();
        }

        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           giris conngrs= new giris();
            conngrs.Show();
            this.Hide();
        }

        private void baslangic_Load(object sender, EventArgs e)
        {
          
        }

        private void iletişimToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
