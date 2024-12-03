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
using DevExpress.XtraEditors;

namespace otomasyonn
{
    public partial class FrmOgrenciler : Form
    {
        public FrmOgrenciler()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {//5.SINIF
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select  * from TBL_OGRENCILER where OGRSINIF='5.SINIF'", bgl.baglanti());
            da1.Fill(dt1);
            GridControl5.DataSource = dt1;

            //6.SINIF
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select  * from TBL_OGRENCILER where OGRSINIF='6.SINIF'", bgl.baglanti());
            da2.Fill(dt2);
            GridControl6.DataSource = dt2;

            //7.SINIF
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("select  * from TBL_OGRENCILER where OGRSINIF='7.SINIF'", bgl.baglanti());
            da3.Fill(dt3);
            GridControl7.DataSource = dt3;

            //8.SINIF
            DataTable dt4 = new DataTable();
            SqlDataAdapter da4 = new SqlDataAdapter("select  * from TBL_OGRENCILER where OGRSINIF='8.SINIF'", bgl.baglanti());
            da4.Fill(dt4);
            GridControl8.DataSource = dt4;
        }
        void sehirekle()
        {
            SqlCommand komut = new SqlCommand("select*from TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbIl.Properties.Items.Add(dr[1]);

            }
            bgl.baglanti().Close();
        }
        void velilistesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select VELIID, (VELIANNE + ' | ' + VELIBABA) as VELIANNEBABA from TBL_VELILER  ", bgl.baglanti());
            da.Fill(dt);
            lookUpEdit1.Properties.ValueMember = "VELIID";
            lookUpEdit1.Properties.DisplayMember = "VELIANNEBABA";
            lookUpEdit1.Properties.DataSource = dt;
        }
        void temizle()
        {
            TxtId.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            Mskogrencino.Text = "";
            Mskogrencino.Text = "";
            comboBoxEdit1.Text = "";
            richadres.Text = "";
            Msktc.Text = "";
            RbBtnerkek.Checked = false;
            rbbtnKadın.Checked = false;
            CmbIl.Text = "";
            CmbIlce.Text = "";
            dateEdit1.Text = "";
            pictureBox1.ImageLocation = "";

        }
        private void FrmOgrenciler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_dbo_OkulOtomasyonDataSet.TBL_OGRENCILER' table. You can move, or remove it, as needed.
            this.tBL_OGRENCILERTableAdapter.Fill(this._dbo_OkulOtomasyonDataSet.TBL_OGRENCILER);
            listele();
            sehirekle();
            temizle();
            velilistesi();
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
        public string cinsiyet;
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                string resimkayityeri = Path.Combine(Application.StartupPath, "Resimler");
                string resimokumayolu = pictureBox1.ImageLocation;
                string hedefDosyaYolu = Path.Combine(resimkayityeri, Path.GetFileName(resimokumayolu));

                // Resim klasörü yoksa oluştur
                if (!Directory.Exists(resimkayityeri))
                {
                    Directory.CreateDirectory(resimkayityeri);
                }

                // Resim seçilmiş mi kontrol et
                if (!string.IsNullOrEmpty(resimokumayolu) && File.Exists(resimokumayolu))
                {
                    // Veritabanına ekleme işlemi
                    using (SqlCommand komut = new SqlCommand("INSERT INTO TBL_OGRENCILER (OGRAD, OGRSOYAD, OGRNO, OGRSINIF, OGRDOGTAR, OGRCINSIYET, OGRTC, OGRIL, OGRILCE, OGRADRES, OGRFOTO, OGRVELIID) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12)", bgl.baglanti()))
                    {
                        komut.Parameters.AddWithValue("@p1", TxtAd.Text.Trim());
                        komut.Parameters.AddWithValue("@p2", TxtSoyad.Text.Trim());
                        komut.Parameters.AddWithValue("@p3", Mskogrencino.Text.Trim());
                        komut.Parameters.AddWithValue("@p4", comboBoxEdit1.Text.Trim());
                        komut.Parameters.AddWithValue("@p5", dateEdit1.DateTime.ToString("yyyy-MM-dd")); // Tarih formatına dikkat
                        komut.Parameters.AddWithValue("@p6", RbBtnerkek.Checked ? "E" : "K");
                        komut.Parameters.AddWithValue("@p7", Msktc.Text.Trim());
                        komut.Parameters.AddWithValue("@p8", CmbIl.Text.Trim());
                        komut.Parameters.AddWithValue("@p9", CmbIlce.Text.Trim());
                        komut.Parameters.AddWithValue("@p10", richadres.Text.Trim());
                        komut.Parameters.AddWithValue("@p11", Path.GetFileName(resimokumayolu)); // Sadece dosya adını kaydet
                        komut.Parameters.AddWithValue("@p12", lookUpEdit1.EditValue);

                        komut.ExecuteNonQuery();
                    }

                    // Resim kopyalama işlemi
                    File.Copy(resimokumayolu, hedefDosyaYolu, true);

                    MessageBox.Show("Öğrenci Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Listeyi güncelle
                    listele();
                }
                else
                {
                    MessageBox.Show("Lütfen geçerli bir resim seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                bgl.baglanti().Close();
            }


        }
        public string yeniyol;

        //private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        //{
        //    DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
        //    if (dr != null)
        //    {
        //        TxtId.Text = dr["OGRID"].ToString();
        //        TxtAd.Text = dr["OGRAD"].ToString();
        //        TxtSoyad.Text = dr["OGRSOYAD"].ToString();
        //        Msktc.Text = dr["OGRTC"].ToString();
        //        Mskogrencino.Text = dr["OGRNO"].ToString();
        //        comboBoxEdit1.Text = dr["OGRSINIF"].ToString();
        //        if (dr["OGRCINSIYET"].ToString() == "E")
        //        {
        //            RbBtnerkek.Checked = true;


        //        }
        //        else
        //        {
        //            rbbtnKadın.Checked = true;
        //        }
        //        CmbIl.Text = dr["OGRIL"].ToString();
        //        CmbIlce.Text = dr["OGRILCE"].ToString();
        //        dateEdit1.Text = dr["OGRDOGTAR"].ToString();
        //        richadres.Text = dr["OGRADRES"].ToString();
        //        //yeniyol = "D:\\görsel programlama ödev\\otomasyonn\\otomasyonn" + "\\resim\\" + dr["OGRFOTO"].ToString();
        //      //  pictureEdit1.Image = Image.FromFile(yeniyol);
        //       // lookUpEdit1.Text = dr["VELIANNEBABA"].ToString();


        //    }
        //}

        //private void gridView2_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        //{

        //    //DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
        //    //if (dr != null)
        //    //{
        //    //    TxtId.Text = dr["OGRID"].ToString();
        //    //    TxtAd.Text = dr["OGRAD"].ToString();
        //    //    TxtSoyad.Text = dr["OGRSOYAD"].ToString();
        //    //    Msktc.Text = dr["OGRTC"].ToString();
        //    //    Mskogrencino.Text = dr["OGRNO"].ToString();
        //    //    comboBoxEdit1.Text = dr["OGRSINIF"].ToString();
        //    //    if (dr["OGRCINSIYET"].ToString() == "E")
        //    //    {
        //    //        RbBtnerkek.Checked = true;


        //    //    }
        //    //    else
        //    //    {
        //    //        rbbtnKadın.Checked = true;
        //    //    }
        //    //    CmbIl.Text = dr["OGRIL"].ToString();
        //    //    CmbIlce.Text = dr["OGRILCE"].ToString();
        //    //    dateEdit1.Text = dr["OGRDOGTAR"].ToString();
        //    //    richadres.Text = dr["OGRADRES"].ToString();
        //    //    // yeniyol = "D:\\görsel programlama ödev\\otomasyonn\\otomasyonn" + "\\resim\\" + dr["OGRFOTO"].ToString();
        //    //    //pictureEdit1.Image = Image.FromFile(yeniyol);
        //    //    //lookUpEdit1.Text = dr[" VELIANNEBABA"].ToString();

        //    //}
        //}

        //private void gridView3_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        //{

        //    DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
        //    if (dr != null)
        //    {
        //        TxtId.Text = dr["OGRID"].ToString();
        //        TxtAd.Text = dr["OGRAD"].ToString();
        //        TxtSoyad.Text = dr["OGRSOYAD"].ToString();
        //        Msktc.Text = dr["OGRTC"].ToString();
        //        Mskogrencino.Text = dr["OGRNO"].ToString();
        //        comboBoxEdit1.Text = dr["OGRSINIF"].ToString();
        //        if (dr["OGRCINSIYET"].ToString() == "E")
        //        {
        //            RbBtnerkek.Checked = true;


        //        }
        //        else
        //        {
        //            rbbtnKadın.Checked = true;
        //        }
        //        CmbIl.Text = dr["OGRIL"].ToString();
        //        CmbIlce.Text = dr["OGRILCE"].ToString();
        //        dateEdit1.Text = dr["OGRDOGTAR"].ToString();
        //        richadres.Text = dr["OGRADRES"].ToString();
        //        // yeniyol = "D:\\görsel programlama ödev\\otomasyonn\\otomasyonn" + "\\resim\\" + dr["OGRFOTO"].ToString();
        //        // pictureEdit1.Image = Image.FromFile(yeniyol);

        //        //lookUpEdit1.Text = dr["VELIANNEBABA"].ToString();


        //    }
        //}

        //private void gridView4_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        //{
        //    DataRow dr = gridView4.GetDataRow(gridView4.FocusedRowHandle);
        //    if (dr != null)
        //    {
        //        TxtId.Text = dr["OGRID"].ToString();
        //        TxtAd.Text = dr["OGRAD"].ToString();
        //        TxtSoyad.Text = dr["OGRSOYAD"].ToString();
        //        Msktc.Text = dr["OGRTC"].ToString();
        //        Mskogrencino.Text = dr["OGRNO"].ToString();
        //        comboBoxEdit1.Text = dr["OGRSINIF"].ToString();
        //        if (dr["OGRCINSIYET"].ToString() == "E")
        //        {
        //            RbBtnerkek.Checked = true;


        //        }
        //        else
        //        {
        //            rbbtnKadın.Checked = true;
        //        }
        //        CmbIl.Text = dr["OGRIL"].ToString();
        //        CmbIlce.Text = dr["OGRILCE"].ToString();
        //        dateEdit1.Text = dr["OGRDOGTAR"].ToString();
        //        richadres.Text = dr["OGRADRES"].ToString();
        //       // yeniyol = "D:\\görsel programlama ödev\\otomasyonn\\otomasyonn" + "\\resim\\" + dr["OGRFOTO"].ToString();
        //      //  pictureEdit1.Image = Image.FromFile(yeniyol);
        //       // lookUpEdit1.Text = dr["VELIANNEBABA"].ToString();

        //    }
        //}

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_OGRENCILER set OGRAD=@p1,OGRSOYAD=@p2,OGRNO=@p3,OGRSINIF=@p4,OGRDOGTAR=@p5,OGRCINSIYET=@p6,OGRTC=@p7,OGRIL=@p8,OGRILCE=@p9,OGRADRES=@p10,OGRFOTO=@p11,OGRVELIID=@p13 where OGRID=@p12", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", Mskogrencino.Text);
            komut.Parameters.AddWithValue("@p4", comboBoxEdit1.Text);
            komut.Parameters.AddWithValue("@p5", dateEdit1.Text);
            if (RbBtnerkek.Checked == true)
            {
                komut.Parameters.AddWithValue("@p6", cinsiyet = "E");
            }
            else
            {
                komut.Parameters.AddWithValue("@p6", cinsiyet = "K");
            }
            komut.Parameters.AddWithValue("@p7", Msktc.Text);
            komut.Parameters.AddWithValue("@p8", CmbIl.Text);
            komut.Parameters.AddWithValue("@p9", CmbIlce.Text);
            komut.Parameters.AddWithValue("@p10", richadres.Text);
            komut.Parameters.AddWithValue("@p11", Path.GetFileName(yeniyol));
            komut.Parameters.AddWithValue("@p12", TxtId.Text);
            komut.Parameters.AddWithValue("@p13", lookUpEdit1.EditValue);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Öğrenci Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();


        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from TBL_OGRENCILER where OGRID=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", TxtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Öğrenci Bilgileri Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();

        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            FrmNufusCuzdani frm = new FrmNufusCuzdani();
            if (dr != null)
            {
                frm.ad = dr["OGRAD"].ToString();
                frm.soyad = dr["OGRSOYAD"].ToString();

                frm.tc = dr["OGRTC"].ToString();
                frm.cinsiyet = dr["OGRCINSIYET"].ToString();
                frm.ad = dr["OGRDOGTAR"].ToString();
                //   frm.uzanti = "D:\\görsel programlama ödev\\otomasyonn\\otomasyonn" + "\\resim\\" + dr["OGRFOTO"].ToString();



            }
            frm.Show();
        }

        private void btnresim_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.png; *.jpeg; *.gif; *.bmp";
            if (file.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(file.FileName);
                // image dosya yolunu text de göster  
                txtResimAdi.Text = file.SafeFileName;
                pictureBox1.ImageLocation = file.FileName;
            }

        }
        //5.sınıf
        private void GridControl5_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtId.Text = dr["OGRID"].ToString();
                TxtAd.Text = dr["OGRAD"].ToString();
                TxtSoyad.Text = dr["OGRSOYAD"].ToString();
                Msktc.Text = dr["OGRTC"].ToString();
                Mskogrencino.Text = dr["OGRNO"].ToString();
                comboBoxEdit1.Text = dr["OGRSINIF"].ToString();
                if (dr["OGRCINSIYET"].ToString() == "E")
                {
                    RbBtnerkek.Checked = true;


                }
                else
                {
                    rbbtnKadın.Checked = true;
                }
                CmbIl.Text = dr["OGRIL"].ToString();
                CmbIlce.Text = dr["OGRILCE"].ToString();
                dateEdit1.Text = dr["OGRDOGTAR"].ToString();
                richadres.Text = dr["OGRADRES"].ToString();
                // yeniyol = "D:\\görsel programlama ödev\\otomasyonn\\otomasyonn" + "\\resim\\" + dr["OGRFOTO"].ToString();
                pictureBox1.ImageLocation = Application.StartupPath + "/Resimler/" + dr["OGRFOTO"];




            }
        }
        //6.sınıf
        private void GridControl6_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (dr != null)
            {
                TxtId.Text = dr["OGRID"].ToString();
                TxtAd.Text = dr["OGRAD"].ToString();
                TxtSoyad.Text = dr["OGRSOYAD"].ToString();
                Msktc.Text = dr["OGRTC"].ToString();
                Mskogrencino.Text = dr["OGRNO"].ToString();
                comboBoxEdit1.Text = dr["OGRSINIF"].ToString();
                if (dr["OGRCINSIYET"].ToString() == "E")
                {
                    RbBtnerkek.Checked = true;


                }
                else
                {
                    rbbtnKadın.Checked = true;
                }
                CmbIl.Text = dr["OGRIL"].ToString();
                CmbIlce.Text = dr["OGRILCE"].ToString();
                dateEdit1.Text = dr["OGRDOGTAR"].ToString();
                richadres.Text = dr["OGRADRES"].ToString();
                // yeniyol = "D:\\görsel programlama ödev\\otomasyonn\\otomasyonn" + "\\resim\\" + dr["OGRFOTO"].ToString();
                pictureBox1.ImageLocation = Application.StartupPath + "/Resimler/" + dr["OGRFOTO"];

            }
        }
        //7.sınıf
        private void GridControl7_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView4.GetDataRow(gridView4.FocusedRowHandle);
            if (dr != null)
            {
                TxtId.Text = dr["OGRID"].ToString();
                TxtAd.Text = dr["OGRAD"].ToString();
                TxtSoyad.Text = dr["OGRSOYAD"].ToString();
                Msktc.Text = dr["OGRTC"].ToString();
                Mskogrencino.Text = dr["OGRNO"].ToString();
                comboBoxEdit1.Text = dr["OGRSINIF"].ToString();
                if (dr["OGRCINSIYET"].ToString() == "E")
                {
                    RbBtnerkek.Checked = true;


                }
                else
                {
                    rbbtnKadın.Checked = true;
                }
                CmbIl.Text = dr["OGRIL"].ToString();
                CmbIlce.Text = dr["OGRILCE"].ToString();
                dateEdit1.Text = dr["OGRDOGTAR"].ToString();
                richadres.Text = dr["OGRADRES"].ToString();
                // yeniyol = "D:\\görsel programlama ödev\\otomasyonn\\otomasyonn" + "\\resim\\" + dr["OGRFOTO"].ToString();
                // pictureEdit1.Image = Image.FromFile(yeniyol);

                //lookUpEdit1.Text = dr["VELIANNEBABA"].ToString();

            }
        }
        //8,sınıf
        private void GridControl8_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView12.GetDataRow(gridView12.FocusedRowHandle);
            if (dr != null)
            {
                TxtId.Text = dr["OGRID"].ToString();
                TxtAd.Text = dr["OGRAD"].ToString();
                TxtSoyad.Text = dr["OGRSOYAD"].ToString();
                Msktc.Text = dr["OGRTC"].ToString();
                Mskogrencino.Text = dr["OGRNO"].ToString();
                comboBoxEdit1.Text = dr["OGRSINIF"].ToString();
                if (dr["OGRCINSIYET"].ToString() == "E")
                {
                    RbBtnerkek.Checked = true;


                }
                else
                {
                    rbbtnKadın.Checked = true;
                }
                CmbIl.Text = dr["OGRIL"].ToString();
                CmbIlce.Text = dr["OGRILCE"].ToString();
                dateEdit1.Text = dr["OGRDOGTAR"].ToString();
                richadres.Text = dr["OGRADRES"].ToString();
                // yeniyol = "D:\\görsel programlama ödev\\otomasyonn\\otomasyonn" + "\\resim\\" + dr["OGRFOTO"].ToString();
                // pictureEdit1.Image = Image.FromFile(yeniyol);

                //lookUpEdit1.Text = dr["VELIANNEBABA"].ToString();
            }
        }
    }
}