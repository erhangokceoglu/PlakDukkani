using PlakDukkan.DAL.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlakDukkan.UI
{
    public partial class YoneticiGirisEkrani : Form
    {
        ProjectContext _db;
        public YoneticiGirisEkrani()
        {
            InitializeComponent();
        }
        private void YoneticiEkrani_Load(object sender, EventArgs e)
        {
            _db = new ProjectContext();
        }

        private void lblSifremiUnuttum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifreyiGosterEkraniGetir();
        }


        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            KayitOlEkraniGetir();
        }


        private void checkBoxSifreyiGoster_CheckedChanged(object sender, EventArgs e)
        {
            txtSifre.PasswordChar = checkBoxSifreyiGoster.Checked ? '\0' : '*';
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            #region Yöneticinin Giriş Yapma İşlemleri
            if (_db.Yoneticiler.Where(x => x.KullaniciAdi == txtKullaniciAdi.Text.ToLower() && x.Sifre == Metotlar.sha256_hash(txtSifre.Text)).Count() > 0)
            //Daha önce kayıt yapmış yöneticinin giriş yapması için yazdığı kullanici adı ve şifresi veritabanıdaki ile eşleşirse sonraki ekrana geçebilir.
            {
                AlbumDetayEkraniGetir();
            }
            else if (_db.Yoneticiler.Where(x => x.KullaniciAdi == txtKullaniciAdi.Text.ToLower() && x.Sifre != Metotlar.sha256_hash(txtSifre.Text)).Count() > 0)
            {
                //Daha önce kayıt yapmış yöneticinin giriş yapması için yazdığı kullanici adı ve şifresi veritabanıdaki şifresi ile eşleşmezse uyarı verilir.
                MessageBox.Show("Yanlış kullanici adı veya şifre girdiniz.Tekrar Deneyiniz!");
                Temizle();
            }
            else
            {
                //Daha önce kayıt yapmış veya yapmamış yöneticinin giriş yapması için yazdığı kullanici adı ve şifresi veritabanıdaki ile eşleşmezse uyarı verilir.
                MessageBox.Show("Kayıt bulunamadı!");
                Temizle();
            }
            #endregion
        }

        private void Temizle()
        {
            txtKullaniciAdi.Text = txtSifre.Text = "";
        }

        private void AlbumDetayEkraniGetir()
        {
            AlbumDetayEkrani albumDetayEkrani = new AlbumDetayEkrani();
            albumDetayEkrani.Show();
            this.Hide();
        }
        private void SifreyiGosterEkraniGetir()
        {
            SifreyiGosterEkrani sifreyiGosterEkrani = new SifreyiGosterEkrani();
            sifreyiGosterEkrani.Show();
            this.Hide();
        }
        private void KayitOlEkraniGetir()
        {
            KayitOlEkrani kayitOlEkrani = new KayitOlEkrani();
            kayitOlEkrani.Show();
            this.Hide();
        }
    }
}
