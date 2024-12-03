using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base.ViewInfo;

namespace otomasyonn
{
    public partial class FrmVeliler : Form
    {
        public FrmVeliler()
        {
            InitializeComponent();
        }

        OkulEntities db =new OkulEntities();
        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            var query = from item in db.TBL_VELILER
                        select new { item.VELIID, item.VELIANNE, item.VELIBABA, item.VELITEL1, item.VELITEL2, item.VELIMAIL };
            gridControl1.DataSource = query.ToList();

        }
        void temizle()
        {
            TxtId.Text = "";
            Txtanne.Text = "";
            Txtbaba.Text = "";
            Msktel1.Text = "";
            Msktel2.Text = "";
            txtmail.Text = "";
        }
        private void FrmVeliler_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }
       
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            TBL_VELILER veli = new TBL_VELILER();
            veli.VELIANNE = Txtanne.Text;
            veli.VELIBABA = Txtbaba.Text;
            veli.VELITEL1 = Msktel1.Text;
            veli.VELITEL2 = Msktel2.Text;
            veli.VELIMAIL = txtmail.Text;
            db.TBL_VELILER.Add(veli);
            db.SaveChanges();
            listele();
        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            TxtId.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VELIID").ToString();
            Txtanne.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VELIANNE").ToString();
            Txtbaba.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VELIBABA").ToString();
            Msktel1.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VELITEL1").ToString();
            Msktel2.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VELITEL2").ToString();
            txtmail.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VELIMAIL").ToString();
         

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VELIID").ToString());
            //var item = db.TBL_VELILER.Find(id);
            //item.VELIANNE = Txtanne.Text;
            //item.VELIBABA = Txtbaba.Text;

            //item.VELITEL1 = Msktel1.Text;
            //item.VELITEL2 = Msktel2.Text;
            //item.VELIMAIL = txtmail.Text;



            //db.SaveChanges();
            //listele();
            //temizle();


            using (OkulEntities db=new OkulEntities())
            {
                var item = db.TBL_VELILER.FirstOrDefault(x => x.VELIID == id);
                item.VELIANNE = Txtanne.Text;
                item.VELIBABA = Txtbaba.Text;
                item.VELITEL1 = Msktel1.Text;
                item.VELITEL2 = Msktel2.Text;
                item.VELIMAIL = txtmail.Text;
                db.SaveChanges();
                listele();
                temizle();

            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VELIID").ToString());
            //var item = db.TBL_VELILER.Find(id);
            //db.TBL_VELILER.Remove(item);
            //db.SaveChanges();
            //listele();
            //temizle();
            using(OkulEntities db=new OkulEntities())
            {
                var item = db.TBL_VELILER.First(x => x.VELIID == id);
                db.TBL_VELILER.Remove(item);
                db.SaveChanges();
                listele();
                temizle();
            }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
