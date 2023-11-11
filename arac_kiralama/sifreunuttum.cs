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
    public partial class sifreunuttum : Form
    {
        public sifreunuttum()
        {
            InitializeComponent();
        }

        sqlconn conn=new sqlconn();
        private void sifreunuttum_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (txtsifre1.Text != txtsifre2.Text)
            {

                MessageBox.Show("Girdiğiniz şifreler aynı olmak zorunda!");
                
            }
            else
            {
            if(txtsifre1.Text ==string.Empty||txtsifre2.Text ==string.Empty)
                {
                    MessageBox.Show("Şifreleri boş bırakamazsanız");


                }
                else
                {
                    SqlCommand kmt = new SqlCommand("update tbl_yonetici set yoneticisıfre=@y1 where yoneticiad=@y2", conn.connsql());
                    kmt.Parameters.AddWithValue("@y1", txtsifre1.Text);
                    kmt.Parameters.AddWithValue("@y2", txtad.Text);
                    kmt.ExecuteNonQuery();

                    MessageBox.Show("Şifreniz başarıyla değiştirildi.");
                }
         
            }

        }
    }
}
