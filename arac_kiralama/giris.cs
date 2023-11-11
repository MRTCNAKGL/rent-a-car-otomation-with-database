using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace arac_kiralama
{
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }

        sqlconn conn= new sqlconn();
        
        private void button2_Click(object sender, EventArgs e)
        {
            baslangic connbslngc=new baslangic();
            connbslngc.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            kayitol connkyt=new kayitol();
            connkyt.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sifreunuttum connsfre=new sifreunuttum();
            connsfre.Show();
        }

        private void giris_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("select yoneticiad,yoneticisıfre from tbl_yonetici where yoneticiad=@y1 and yoneticisıfre=@y2", conn.connsql());
            kmt.Parameters.AddWithValue("@y1", txtad.Text);
            kmt.Parameters.AddWithValue("@y2",txtsifre.Text);
            SqlDataReader dr= kmt.ExecuteReader();
            if (dr.Read())
            {
                Yonetici yntc=new Yonetici();
                yntc.Show();
                this.Hide();

                

            }
            else
            {
                MessageBox.Show("Yanlış kullanıcı adı veya şifre!");
            }
        }
    }
}
