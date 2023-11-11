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
using System.Diagnostics.Eventing.Reader;

namespace arac_kiralama
{
    public partial class kayitol : Form
    {
        public kayitol()
        {
            InitializeComponent();
        }
        sqlconn conn=new sqlconn();
       
        private void kayitol_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {



            if (cptcha.Text != maskedTextBox1.Text)
            {
                MessageBox.Show("CAPTCHA kodunu hatalı girdiniz...", "hata", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            else
            {
                if (txtad.Text == string.Empty || txtsifre.Text == string.Empty)
                {

                    MessageBox.Show("Alanları boş bırakamazsınız...", "hata", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }


            

            else
            {

                SqlCommand kmt = new SqlCommand("insert into tbl_yonetici (yoneticiad,yoneticisıfre) values (@y1,@y2)", conn.connsql());
                kmt.Parameters.AddWithValue("@y1", txtad.Text);
                kmt.Parameters.AddWithValue("@y2", txtsifre.Text);
                kmt.ExecuteNonQuery();
                MessageBox.Show("Kaydınız Başarıyla Yapılmıştır...", "başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
 
           


            conn.connsql().Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {

            string[] array1 = { "a", "b", "c", "d", "e", "f", "g" };
            string[] array2 = { "+", "-", "/", "*", "." };

            Random rnd = new Random();

            int a1 = rnd.Next(array1.Length);
            int a2 = rnd.Next(array2.Length);
            int a3 = rnd.Next(1, 10);
            int a4 = rnd.Next(1, 10);

            cptcha.Text = array1[a1].ToString() + array2[a2].ToString() + a3.ToString() + a4.ToString();


        }
    }
}
