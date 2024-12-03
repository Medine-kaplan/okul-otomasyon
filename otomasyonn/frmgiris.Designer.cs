namespace otomasyonn
{
    partial class frmgiris
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmgiris));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtsifre = new DevExpress.XtraEditors.TextEdit();
            this.BtnYonetici = new System.Windows.Forms.Button();
            this.BtnOgretmen = new System.Windows.Forms.Button();
            this.BtnOgrenci = new System.Windows.Forms.Button();
            this.msktc = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtsifre.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Gray;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(169, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(673, 85);
            this.panelControl1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(48, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(608, 42);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "ATATÜRK ORTAOKULU GİRİŞ PANELİ";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(186, 305);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(162, 33);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "KULLANICI:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(568, 305);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(93, 33);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "ŞİFRE:";
            // 
            // txtsifre
            // 
            this.txtsifre.Location = new System.Drawing.Point(667, 306);
            this.txtsifre.Name = "txtsifre";
            this.txtsifre.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtsifre.Properties.Appearance.Options.UseFont = true;
            this.txtsifre.Properties.UseSystemPasswordChar = true;
            this.txtsifre.Size = new System.Drawing.Size(167, 32);
            this.txtsifre.TabIndex = 3;
            // 
            // BtnYonetici
            // 
            this.BtnYonetici.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnYonetici.BackgroundImage")));
            this.BtnYonetici.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnYonetici.Location = new System.Drawing.Point(215, 361);
            this.BtnYonetici.Name = "BtnYonetici";
            this.BtnYonetici.Size = new System.Drawing.Size(176, 112);
            this.BtnYonetici.TabIndex = 5;
            this.BtnYonetici.UseVisualStyleBackColor = true;
            this.BtnYonetici.Click += new System.EventHandler(this.BtnYonetici_Click);
            // 
            // BtnOgretmen
            // 
            this.BtnOgretmen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnOgretmen.BackgroundImage")));
            this.BtnOgretmen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnOgretmen.Location = new System.Drawing.Point(418, 361);
            this.BtnOgretmen.Name = "BtnOgretmen";
            this.BtnOgretmen.Size = new System.Drawing.Size(176, 112);
            this.BtnOgretmen.TabIndex = 6;
            this.BtnOgretmen.UseVisualStyleBackColor = true;
            this.BtnOgretmen.Click += new System.EventHandler(this.BtnOgretmen_Click);
            // 
            // BtnOgrenci
            // 
            this.BtnOgrenci.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnOgrenci.BackgroundImage")));
            this.BtnOgrenci.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnOgrenci.Location = new System.Drawing.Point(614, 361);
            this.BtnOgrenci.Name = "BtnOgrenci";
            this.BtnOgrenci.Size = new System.Drawing.Size(176, 112);
            this.BtnOgrenci.TabIndex = 7;
            this.BtnOgrenci.UseVisualStyleBackColor = true;
           // this.BtnOgrenci.Click += new System.EventHandler(this.BtnOgrenci_Click);
            // 
            // msktc
            // 
            this.msktc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.msktc.Location = new System.Drawing.Point(368, 305);
            this.msktc.Mask = "00000000000";
            this.msktc.Name = "msktc";
            this.msktc.Size = new System.Drawing.Size(141, 31);
            this.msktc.TabIndex = 8;
            this.msktc.ValidatingType = typeof(int);
            // 
            // frmgiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(966, 485);
            this.Controls.Add(this.msktc);
            this.Controls.Add(this.BtnOgrenci);
            this.Controls.Add(this.BtnOgretmen);
            this.Controls.Add(this.BtnYonetici);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtsifre);
            this.Controls.Add(this.panelControl1);
            this.DoubleBuffered = true;
            this.Name = "frmgiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OKUL GİRİŞİ";
            this.Load += new System.EventHandler(this.frmgiris_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtsifre.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtsifre;
        private System.Windows.Forms.Button BtnYonetici;
        private System.Windows.Forms.Button BtnOgretmen;
        private System.Windows.Forms.Button BtnOgrenci;
        private System.Windows.Forms.MaskedTextBox msktc;
    }
}