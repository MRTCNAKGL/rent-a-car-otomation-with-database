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
    public partial class randevu : Form
    {
        public randevu()
        {
            InitializeComponent();
        }
        sqlconn conn= new sqlconn();    
        private void button1_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                SqlCommand cmd = new SqlCommand("insert into tbl_randevu (musteriad,musterisoyad,aracmodel,aracmarka,aracplaka,aracyıl,aracdurum) values(@a1,@a2,@a3,@a4,@a5,@a6,@a7)", conn.connsql());
                cmd.Parameters.AddWithValue("@a1", cmbad.Text);
                cmd.Parameters.AddWithValue("@a2", cmbsoyad.Text);
                cmd.Parameters.AddWithValue("@a3", cmbmodel.Text);
                cmd.Parameters.AddWithValue("@a4", cmbmarka.Text);
                cmd.Parameters.AddWithValue("@a5", cmbplaka.Text);
                cmd.Parameters.AddWithValue("@a6", cmbyıl.Text);
                cmd.Parameters.AddWithValue("@a7", checkBox1.Checked);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Randevu Başarıyla Oluşturuldu...");

            }

            else
            {
                MessageBox.Show("Kirala seçeniğine tıklamalısınız");
            }

           
            SqlCommand cmd2 = new SqlCommand("insert into tbl_araclar (aracdurum) values(@c1) where aracplaka=p1", conn.connsql());
            cmd2.Parameters.AddWithValue("@p1",cmbplaka.Text);
            cmd2.Parameters.AddWithValue("@c1", checkBox1.Checked);
            cmd2.ExecuteNonQuery();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dtt = MessageBox.Show("Silmek istediğinize emin misiniz","başarılı",MessageBoxButtons.YesNo ,MessageBoxIcon.Information);
            if (dtt==DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("delete from tbl_randevu where aracplaka=@a1", conn.connsql());
                cmd.Parameters.AddWithValue("@a1", cmbplaka.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Randevu başarıyla silindi");
            }

            else
            {
                MessageBox.Show("Kaydınız Silinmedi","bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


           
        }

        private void randevu_Load(object sender, EventArgs e)
        {
            DataTable dt=new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_araclar",conn.connsql());
            da.Fill(dt);
            dataGridView1.DataSource = dt;


            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select * from tbl_randevu where aracdurum='1'", conn.connsql());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;



            SqlCommand cmd3 = new SqlCommand("select aracplaka from tbl_araclar", conn.connsql());
            SqlDataReader dr2 = cmd3.ExecuteReader();
            while (dr2.Read())
            {
                cmbplaka.Items.Add(dr2[0].ToString());
            }

            SqlCommand cmd4 = new SqlCommand("select musteriad, musterisoyad from tbl_musteri", conn.connsql());
            //cmd4.Parameters.AddWithValue("@m1", cmbad.Text);
            SqlDataReader dr4= cmd4.ExecuteReader();
            while (dr4.Read())
            {
                cmbad.Items.Add(dr4[0].ToString());
                cmbsoyad.Items.Add(dr4[1].ToString());
            }



       

           

        }

        private void cmbmodel_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cmbplaka_SelectedIndexChanged(object sender, EventArgs e)
        {

            cmbmarka.Items.Clear();
            cmbmodel.Items.Clear();
            cmbyıl.Items.Clear();
            //comboboxa araçları getirme
            SqlCommand cmd2 = new SqlCommand("select aracmodel,aracmarka,aracyıl from tbl_araclar where aracplaka=@k1 ", conn.connsql());
            cmd2.Parameters.AddWithValue("@k1", cmbplaka.Text);
            SqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                cmbmodel.Items.Add(dr[0].ToString());
                cmbmarka.Items.Add(dr[1].ToString());

                cmbyıl.Items.Add(dr[2].ToString());
            }
        }

        private void cmbmarka_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }
    }
}
