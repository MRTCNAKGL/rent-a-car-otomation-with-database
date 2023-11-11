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

namespace arac_kiralama
{
    public partial class Yonetici : Form
    {
        public Yonetici()
        {
            InitializeComponent();
        }

        sqlconn conn = new sqlconn();

        private void button4_Click(object sender, EventArgs e)
        {
            giris yntcgrs=new giris();
            yntcgrs.Show();
            this.Hide();
        }

        private void Yonetici_Load(object sender, EventArgs e)
        {
           
            DataTable dt2= new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select * from tbl_araclar",conn.connsql());
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_randevu where aracdurum='1'", conn.connsql());
            da.Fill(dt);
            dataGridView2.DataSource = dt;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            randevu rnd=new randevu();
            rnd.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            araçlar arc=new araçlar();
            arc.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            musteri mst=new musteri();
            mst.Show();
        }
    }
}
