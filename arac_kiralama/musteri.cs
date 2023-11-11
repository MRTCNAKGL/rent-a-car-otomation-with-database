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
    public partial class musteri : Form
    {
        public musteri()
        {
            InitializeComponent();
        }

        sqlconn conn= new sqlconn();
        private void musteri_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da=new SqlDataAdapter("select * from tbl_musteri",conn.connsql());
            da.Fill(dt);
            dataGridView1.DataSource= dt;

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into tbl_musteri (musteriad,musterisoyad,musteritelefon) values (@m1,@m2,@m3)", conn.connsql());
            cmd.Parameters.AddWithValue("@m1", txtad.Text);
            cmd.Parameters.AddWithValue("@m2", txtsoyad.Text);
            cmd.Parameters.AddWithValue("@m3", msktelefon.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Başarıyla Müşteri Eklendi");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Silmek İstediğinize Emin misiniz?","Teyit",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if(result == DialogResult.OK)
            {
                SqlCommand cmddlete = new SqlCommand("delete from tbl_musteri where musteriad=@m1", conn.connsql());
                cmddlete.Parameters.AddWithValue("@m1", txtad.Text);
                cmddlete.ExecuteNonQuery();
                MessageBox.Show("Başarıyla Müşteri Silindi","başarı",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }

            else
            {

            }
           

        }
    }
}
