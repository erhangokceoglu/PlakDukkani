using PlakDukkan.DAL.Context;
using PlakDukkan.DATA.Sınıflar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlakDukkan.UI
{
    public partial class SifreyiGosterEkrani : Form
    {
        ProjectContext _db;
        Yonetici yonetici;
        public SifreyiGosterEkrani()
        {
            InitializeComponent();
        }

        private void SifreyiGosterEkrani_FormClosed(object sender, FormClosedEventArgs e)
        {
            YoneticiEkraninaGirisYap();
        }

        private void btnSifreyiGoster_Click(object sender, EventArgs e)
        {
            #region Şifre Gösterme İşlemleri
            _db = new ProjectContext();
            yonetici = _db.Yoneticiler.FirstOrDefault(x => x.TelefonNumarasi == txtTelefonNumarasi.Text);
            //Yoneticiler tablosundaki herhangi bir yoneticinin telefon numarası yazılan telefon numarası ile eşleşiyorsa şifre gösteriliyor
            if (yonetici != null)
            {
                MessageBox.Show("Şifreniz: " + Metotlar.sha256_hash(yonetici.Sifre));
                YoneticiEkraninaGirisYap();
            }
            else
            {
                MessageBox.Show("Yanlış giriş yaptınız!");
            }
            #endregion
        }
        private void YoneticiEkraninaGirisYap()
        {
            YoneticiGirisEkrani yonetici = new YoneticiGirisEkrani();
            yonetici.Show();
            this.Hide();
        }
    }
}
