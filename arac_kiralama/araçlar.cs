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
    public partial class araçlar : Form
    {
        public araçlar()
        {
            InitializeComponent();
        }
        sqlconn conn=new sqlconn();
      
        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("insert into tbl_araclar (aracmarka,aracmodel,aracyıl,aracplaka) values (@a1,@a2,@a3,@a4)", conn.connsql());
            cmd.Parameters.AddWithValue("@a1", txtad.Text);
            cmd.Parameters.AddWithValue("@a2",txtmodel.Text);
            cmd.Parameters.AddWithValue("@a3", mskyıl.Text);
            cmd.Parameters.AddWithValue("@a4",mskplaka.Text);
           

            cmd.ExecuteNonQuery();
            MessageBox.Show("Araç Başarıyla Eklendi!");
           

        }

        private void araçlar_Load(object sender, EventArgs e)
        {
            DataTable dt=new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_araclar", conn.connsql());
            da.Fill(dt);
            dataGridView1.DataSource= dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dtt = MessageBox.Show("Silmek istediğinize emin misiniz", "başarılı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dtt == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("delete from tbl_araclar where aracplaka=@a1", conn.connsql());
                cmd.Parameters.AddWithValue("@a1", mskplaka.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Araç Başarıyla Silindi", "başarılı");
            }

            else
            {

                MessageBox.Show("Kaydınız Silinmedi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          
        }
    }
}
