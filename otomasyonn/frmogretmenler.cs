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
using System.Data.Common;
using System.IO;
using DevExpress.XtraPrinting.BarCode;

namespace otomasyonn
{
    public partial class frmogretmenler : Form
    {
        public frmogretmenler()
        {
            InitializeComponent();
        }


        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_OGRETMENLER",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource=dt;
        }
        void ilekle()
        {
            SqlCommand komut = new SqlCommand("select*from TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbIl.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();
        }
        void temizle()
        {
            TxtId.Text = " ";
            TxtAd.Text = " ";
            TxtSoyad.Text = " ";
            Msktc.Text = " ";
            Msktelefon.Text = " ";
            CmbIl.Text = " ";
            CmbIlce.Text = " ";
            Cmbbrans.Text = " ";
            txtmail.Text = " ";
            richadres.Text = " ";
            ptrresim.ImageLocation = " ";
        }
        void bransgetir()
        {
            SqlCommand komut = new SqlCommand("select*from TBL_BRANSLAR", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbbrans.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();
        }
      
        private void frmogretmenler_Load(object sender, EventArgs e)
        {
            listele();
            ilekle();
            bransgetir();
        }

        private void CmbIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void CmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbIlce.Properties.Items.Clear();
            CmbIlce.Text = " ";

            SqlCommand komut = new SqlCommand("select*from TBL_ILCELER where sehirid=@1", bgl.baglanti());
            komut.Parameters.AddWithValue("@1", CmbIl.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbIlce.Properties.Items.Add(dr[1]);
            }
            
            bgl.baglanti().Close();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_OGRETMENLER(OGRTAD,OGRTSOYAD,OGRTTC,OGRTTEL,OGRTMAIL,OGRTIL,OGRTILCE,OGRTADRES,OGRTBRANS,OGRTFOTO)values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", Msktc.Text);
            komut.Parameters.AddWithValue("@p4", Msktelefon.Text);
            komut.Parameters.AddWithValue("@p5", txtmail.Text);
            komut.Parameters.AddWithValue("@p6", CmbIl.Text);
            komut.Parameters.AddWithValue("@p7", CmbIlce.Text);
            komut.Parameters.AddWithValue("@p8", richadres.Text);
            komut.Parameters.AddWithValue("@p9", Cmbbrans.Text);
            komut.Parameters.AddWithValue("@p10", Path.GetFileName(yeniyol));
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Eklendi","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();





        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtId.Text = dr["OGRTID"].ToString();
                TxtAd.Text = dr["OGRTAD"].ToString();
                TxtSoyad.Text = dr["OGRTSOYAD"].ToString();
                Msktc.Text = dr["OGRTTC"].ToString();
                Msktelefon.Text = dr["OGRTTEL"].ToString();
               CmbIl.Text = dr["OGRTIL"].ToString();
                CmbIlce.Text = dr["OGRTILCE"].ToString();
                Cmbbrans.Text = dr["OGRTBRANS"].ToString();
                txtmail.Text = dr["OGRTMAIL"].ToString();
                richadres.Text = dr["OGRTADRES"].ToString();
                yeniyol = "D:\\görsel programlama ödev\\otomasyonn\\otomasyonn" + "\\resim" + dr["OGRTFOTO"].ToString();





            }
        }
        public string yeniyol;
        private void btnresim_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası| *.jpg;*png;*nef|Tüm Dosyalar|*.*";
            dosya.ShowDialog();
            string dosyayolu = dosya.FileName;
            yeniyol= "D:\\görsel programlama ödev\\otomasyonn\\otomasyonn"+"\\resim"+Guid.NewGuid().ToString()+".jpg";
            File.Copy(dosyayolu, yeniyol);
            ptrresim.ImageLocation = yeniyol;
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_OGRETMENLER set OGRTAD=@p1,OGRTSOYAD=@p2,OGRTTC=@p3,OGRTTEL=@p4,OGRTMAIL=@p5,OGRTIL=@P6,OGRTILCE=@p7,OGRTADRES=@p8,OGRTBRANS=@p9,OGRTFOTO=@p10 where OGRTID=@p11", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", Msktc.Text);
            komut.Parameters.AddWithValue("@p4", Msktelefon.Text);
            komut.Parameters.AddWithValue("@p5", txtmail.Text);
            komut.Parameters.AddWithValue("@p6", CmbIl.Text);
            komut.Parameters.AddWithValue("@p7", CmbIlce.Text);
            komut.Parameters.AddWithValue("@p8", richadres.Text);
            komut.Parameters.AddWithValue("@p9", Cmbbrans.Text);
            komut.Parameters.AddWithValue("@p10", Path.GetFileName(yeniyol));
            komut.Parameters.AddWithValue("@p11", TxtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete TBL_OGRETMENLER where OGRTID=@p11", bgl.baglanti());
            komut.Parameters.AddWithValue("@p11", TxtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
