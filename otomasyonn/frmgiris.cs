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
using DevExpress.Utils.DirectXPaint;
namespace otomasyonn
{
    public partial class frmgiris : Form
    {
        public frmgiris()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void frmgiris_Load(object sender, EventArgs e)
        {

        }

        private void BtnYonetici_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select OGRTTC,OGRTSIFRE from TBL_AYARLAR inner join TBL_OGRETMENLER on TBL_AYARLAR.AYARLARID=TBL_OGRETMENLER.OGRTID where OGRTTC=@p1 and OGRTSIFRE=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", msktc.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Form1 frm1 = new Form1();
                frm1.Show();
                this.Hide();

            }
            else
            {
                Form1 frm1 = new Form1();
                msktc.Text="" ;
                txtsifre.Text = "";

            }
            bgl.baglanti().Close();
        }

        private void BtnOgretmen_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select OGRTTC,OGRTSIFRE from TBL_AYARLAR inner join TBL_OGRETMENLER on TBL_AYARLAR.AYARLARID=TBL_OGRETMENLER.OGRTID where OGRTTC=@p1 and OGRTSIFRE=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", msktc.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FormOgretmenlerAnaModül frm2 = new FormOgretmenlerAnaModül();
                frm2.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("HATALI KULLANICI ADI VEYA ŞİFRE");
                msktc.Text = "";
                txtsifre.Text = "";

            }
            bgl.baglanti().Close();
        }

       private void BtnOgrenci_Click(object sender, EventArgs e)
        {
          /*  var sorgu = from d1 in TBL_OGRAYARLAR
                        join d2 in TBL_OGRENCILER
                        on d1.OGRAYARLARID equals d2.OGRID
                        where d2.OGRTC == msktc &&
                        d1.OGRSİFRE == txtsifre.Text
                        select new { };
            if (sorgu.any())
            {
                FrmOgrenciAnaModul frm3 = new FrmOgrenciAnaModul();
                frm3.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("HATALI KULLANICI ADI VEYA ŞİFRE");
                msktc.Text = "";
                txtsifre.Text = "";
            }*/
        }
    }
}
