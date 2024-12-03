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
using System.IO;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Resizing;

namespace otomasyonn
{
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        OkulEntities db = new OkulEntities();
        void listele()
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Execute AyarlarOgretmenler", bgl.baglanti());
            da1.Fill(dt1);
            gridControl1.DataSource = dt1;
        }
        void temizle()
        {
            txtogrtid.Text = "";
            txtogrıd.Text = "";
            txtbrans.Text = "";
            txtsinif.Text = "";

            txtogrsifre.Text = "";
            txtogrsifre.Text = "";

            msktcogrt.Text = "";
            msktcogr.Text = "";
            pcogrt.Text = "";
            pcogr.Text = "";
            lookUpEdit1.Text = "";
            lookupEdit2.Text = "";
            lookUpEdit1.Properties.NullText = "Öğretmen Seçiniz";
            lookupEdit2.Properties.NullText = "Öğrenci Seçiniz";


        }
        void ogrencilistesi()
        {
            var deger = from item in db.TBL_OGRENCILER
                        select new
                        {
                            OGRID = item.OGRID,
                            OGRADSOYAD = item.OGRAD + " " + item.OGRSOYAD,
                            OGRSINIF = item.OGRSINIF,


                        };
            lookupEdit2.Properties.ValueMember = "OGRID";
            lookupEdit2.Properties.DisplayMember = "OGRADSOYAD";
            lookupEdit2.Properties.NullText = "ÖĞRENCİ SEÇİNİZ";
            lookupEdit2.Properties.DataSource = deger.ToList();

;        }
        void ogrlistele()
        {
          //  gridControl2.DataSource = db.TBL_OGRAYARLAR ;
        }
        void ogretmenlistesi()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select OGRTID,(OGRTAD+' '+OGRTSOYAD)as 'OGRTADSOYAD',OGRTBRANS from TBL_OGRETMENLER", bgl.baglanti());
            da2.Fill(dt2);
            lookUpEdit1.Properties.ValueMember = "OGRTID";
            lookUpEdit1.Properties.DisplayMember = "OGRTADSOYAD";
            lookUpEdit1.Properties.NullText = "Öğretmen Seçiniz";
            lookUpEdit1.Properties.DataSource = dt2;
        }
        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            listele();
            ogretmenlistesi();
            ogrlistele();
            ogrencilistesi();
            temizle();

        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }
        public string yeniyol;
        private void gridView2_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            txtogrıd.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OGRAYARLARID").ToString();
            lookupEdit2.Text= gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OGRSOYAD").ToString();
            txtsinif.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OGRSINIF").ToString();
            msktcogr.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OGRTC").ToString();
            txtogrsifre.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OGRSIFRE").ToString();
            string uzanti= gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OGRFOTO").ToString();
            yeniyol = "D:\\görsel programlama ödev\\otomasyonn\\otomasyonn" + "\\resim\\" + uzanti;
            pcogr.Image = Image.FromFile(yeniyol);





        }

        private void lookUpEdit1_Properties_EditValueChanged(object sender, EventArgs e)
        {
            txtsifreogrt.Text = " ";
            SqlCommand komut = new SqlCommand("select*from TBL_OGRETMENLER where OGRTID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lookUpEdit1.ItemIndex + 1);
            SqlDataReader dr3= komut.ExecuteReader();
            while(dr3.Read())
            {

                txtogrtid.Text = dr3["AYARLARID"].ToString();
                lookUpEdit1.Text = dr3["OGRTADSOYAD"].ToString();
                txtbrans.Text = dr3["OGRTBRANS"].ToString();
                msktcogr.Text = dr3["OGRTTC"].ToString();
                txtogrsifre.Text = dr3["OGRTSIFRE"].ToString();
                yeniyol = "D:\\Odev\\otomasyonn\\otomasyonn\\Resimler" + "\\resimler\\" + dr3["OGRTFOTO"].ToString();
                pcogrt.Image = Image.FromFile(yeniyol);
            }
            bgl.baglanti().Close();
            listele();
        }

        private void btnkaydetogrt_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("insert into TBL_AYARLAR(AYARLARID,OGRSIFRE)values(@p1,@p2)", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", txtogrtid.Text);
            komut2.Parameters.AddWithValue("@p2", txtogrsifre.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("ŞİFRE OLUŞTURULDU", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();

        }

        private void btnguncelleogrt_Click(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("Update TBL_AYARLAR set OGRSIFRE=@p1  where AYARLARID=@p2", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", txtogrsifre.Text);
            komut3.Parameters.AddWithValue("@p2", txtogrtid.Text);
            komut3.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("ŞİFRE GÜNCELLENDİ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void btnsilogrt_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtogrtid.Text = dr["AYARLARID"].ToString();
                lookUpEdit1.Text = dr["OGRTADSOYAD"].ToString();
                txtbrans.Text = dr["OGRTBRANS"].ToString();
                msktcogr.Text = dr["OGRTTC"].ToString();
               txtogrsifre.Text = dr["OGRSIFRE"].ToString();
                 //pcogrt.FromFile =Image.Fr*/omFile()+ "/Resimler/" + dr["OGRFOTO"];
               // File.Copy(resimokumayolu, hedefDosyaYolu, true);
                yeniyol = "D:\\Odev\\otomasyonn\\otomasyonn\\Resimler" + "\\resimler\\" + dr["OGRTFOTO"].ToString();
                pcogrt.Image = Image.FromFile(yeniyol);
                listele();
            }
        }
        
        private void lookupEdit2_Properties_EditValueChanged(object sender, EventArgs e)
        {
            txtsifreogrt.Text = "";
            using(OkulEntities db=new OkulEntities())
            {
                TBL_OGRENCILER sorgu = db.TBL_OGRENCILER.Find(lookupEdit2.ItemIndex + 1);
                txtogrıd.Text = sorgu.OGRID.ToString();
                txtsinif.Text = sorgu.OGRSINIF;
                msktcogr.Text= sorgu.OGRTC;
                yeniyol= "D:\\Odev\\otomasyonn\\otomasyonn\\Resimler" + "\\resimler\\" +sorgu.ToString();
                pcogr.Image = Image.FromFile(yeniyol);
            }
        }

        private void btnkaydetogr_Click(object sender, EventArgs e)
        {
            TBL_OGRAYARLAR komut = new TBL_OGRAYARLAR();
            komut.AYARLAROGRID = Convert.ToInt32(txtogrıd.Text);
            komut.OGRSIFRE = txtogrsifre.Text;
            db.TBL_OGRAYARLAR.Add(komut);
            db.SaveChanges();
            MessageBox.Show("ŞİFRE OLUŞTURULDU", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            ogrlistele();
        }

        private void btnguncelleogr_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "AYARLAROGRID"));
            var item = db.TBL_OGRAYARLAR.FirstOrDefault(x =>x.AYARLAROGRID == id);
            item.OGRSIFRE = txtogrsifre.Text;
            db.SaveChanges();
            MessageBox.Show("ŞİFRE GÜNCELLENDİ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
            ogrlistele();
        }

        private void btnsilogr_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
