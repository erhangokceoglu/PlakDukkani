namespace PlakDukkan.UI
{
    partial class SifreyiGosterEkrani
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTelefonNumarasi = new System.Windows.Forms.MaskedTextBox();
            this.btnSifreyiGoster = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(29, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Telefon Numarasi:";
            // 
            // txtTelefonNumarasi
            // 
            this.txtTelefonNumarasi.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTelefonNumarasi.Location = new System.Drawing.Point(187, 29);
            this.txtTelefonNumarasi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTelefonNumarasi.Mask = "(999) 000-0000";
            this.txtTelefonNumarasi.Name = "txtTelefonNumarasi";
            this.txtTelefonNumarasi.Size = new System.Drawing.Size(110, 29);
            this.txtTelefonNumarasi.TabIndex = 1;
            // 
            // btnSifreyiGoster
            // 
            this.btnSifreyiGoster.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSifreyiGoster.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSifreyiGoster.Location = new System.Drawing.Point(29, 85);
            this.btnSifreyiGoster.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSifreyiGoster.Name = "btnSifreyiGoster";
            this.btnSifreyiGoster.Size = new System.Drawing.Size(268, 28);
            this.btnSifreyiGoster.TabIndex = 2;
            this.btnSifreyiGoster.Text = "ŞİFREYİ GÖSTER";
            this.btnSifreyiGoster.UseVisualStyleBackColor = false;
            this.btnSifreyiGoster.Click += new System.EventHandler(this.btnSifreyiGoster_Click);
            // 
            // SifreyiGosterEkrani
            // 
            this.AcceptButton = this.btnSifreyiGoster;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(334, 152);
            this.Controls.Add(this.btnSifreyiGoster);
            this.Controls.Add(this.txtTelefonNumarasi);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SifreyiGosterEkrani";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SifreyiGosterEkrani";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SifreyiGosterEkrani_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private MaskedTextBox txtTelefonNumarasi;
        private Button btnSifreyiGoster;
    }
}