namespace PlakDukkan.UI
{
    partial class KayitOlEkrani
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
            this.txtSifreTekrari = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnKayitOl = new System.Windows.Forms.Button();
            this.txtTelefonNumarasi = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSifreTekrari
            // 
            this.txtSifreTekrari.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSifreTekrari.Location = new System.Drawing.Point(68, 401);
            this.txtSifreTekrari.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSifreTekrari.Name = "txtSifreTekrari";
            this.txtSifreTekrari.PlaceholderText = "  Şifre Tekrarı";
            this.txtSifreTekrari.Size = new System.Drawing.Size(279, 29);
            this.txtSifreTekrari.TabIndex = 16;
            // 
            // txtSifre
            // 
            this.txtSifre.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSifre.Location = new System.Drawing.Point(68, 359);
            this.txtSifre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PlaceholderText = "  Şifre";
            this.txtSifre.Size = new System.Drawing.Size(279, 29);
            this.txtSifre.TabIndex = 14;
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtKullaniciAdi.Location = new System.Drawing.Point(68, 275);
            this.txtKullaniciAdi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.PlaceholderText = "  Kullanıcı Adı";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(279, 29);
            this.txtKullaniciAdi.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PlakDukkan.UI.Properties.Resources.kayit;
            this.pictureBox1.Location = new System.Drawing.Point(68, 41);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(278, 188);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // btnKayitOl
            // 
            this.btnKayitOl.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnKayitOl.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnKayitOl.Location = new System.Drawing.Point(68, 447);
            this.btnKayitOl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKayitOl.Name = "btnKayitOl";
            this.btnKayitOl.Size = new System.Drawing.Size(278, 33);
            this.btnKayitOl.TabIndex = 18;
            this.btnKayitOl.Text = "KAYIT OL";
            this.btnKayitOl.UseVisualStyleBackColor = false;
            this.btnKayitOl.Click += new System.EventHandler(this.btnKayitOl_Click);
            // 
            // txtTelefonNumarasi
            // 
            this.txtTelefonNumarasi.Location = new System.Drawing.Point(68, 320);
            this.txtTelefonNumarasi.Mask = "(999) 000-0000";
            this.txtTelefonNumarasi.Name = "txtTelefonNumarasi";
            this.txtTelefonNumarasi.Size = new System.Drawing.Size(279, 23);
            this.txtTelefonNumarasi.TabIndex = 19;
            // 
            // KayitOlEkrani
            // 
            this.AcceptButton = this.btnKayitOl;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(422, 565);
            this.Controls.Add(this.txtTelefonNumarasi);
            this.Controls.Add(this.btnKayitOl);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtSifreTekrari);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtKullaniciAdi);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "KayitOlEkrani";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KayitOlEkrani";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.KayitOlEkrani_FormClosed);
            this.Load += new System.EventHandler(this.KayitOlEkrani_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtSifreTekrari;
        private TextBox txtSifre;
        private TextBox txtKullaniciAdi;
        private PictureBox pictureBox1;
        private Button btnKayitOl;
        private MaskedTextBox txtTelefonNumarasi;
    }
}