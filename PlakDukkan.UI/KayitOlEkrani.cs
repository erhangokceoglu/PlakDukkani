using PlakDukkan.DAL.Context;
using PlakDukkan.DAL.Repository;
using PlakDukkan.DATA.Sınıflar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlakDukkan.UI
{
    public partial class KayitOlEkrani : Form
    {
        ProjectContext _db;
        Yonetici secilenYonetici;
        Repository<Yonetici> _repository;
        public KayitOlEkrani()
        {
            InitializeComponent();
        }
        private void KayitOlEkrani_Load(object sender, EventArgs e)
        {
            _db = new ProjectContext();
            _repository = new Repository<Yonetici>(_db);
        }

        private void KayitOlEkrani_FormClosed(object sender, FormClosedEventArgs e)
        {
            YoneticiEkranınaGirisYap();
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            #region Boşluk Kontrol İşlemleri

            if (txtKullaniciAdi.Text == "" || txtSifre.Text == "" || txtSifreTekrari.Text == "" || txtTelefonNumarasi.MaskFull == false)
            {
                MessageBox.Show("Boş bıraktığınız alanlar var lütfen bu alanları doldurunuz!");
                return;
            }

            #endregion
            
            bool sonucSifre = SifreKontrolEt();

            if (sonucSifre == true)
            {
                KullaniciKayıtEt();
            }
        }

        private bool SifreKontrolEt()
        {
            #region Şifre Kriterleri işlemleri       
            char[] sifre = txtSifre.Text.ToCharArray();
            int kucukHarfSayisi = 0;
            int buyukHarfSayisi = 0;
            int ozelKarakterSayisi = 0;

            if (sifre.Length < 8 || sifre.Length > 16)
            {
                MessageBox.Show("Girmiş olduğunuz şifre 8 ile 16 karakter arasında olmalıdır!");
                return false;
            }

            foreach (char item in sifre)
            {
                int ascOfItem = (int)item;

                if (ascOfItem >= 97 && ascOfItem <= 122)
                {
                    kucukHarfSayisi++;
                }
                else if (ascOfItem >= 65 && ascOfItem <= 90)
                {
                    buyukHarfSayisi++;
                }
                else if (ascOfItem == 33 || ascOfItem == 42 || ascOfItem == 43 || ascOfItem == 58)
                {
                    ozelKarakterSayisi++;
                }
            }
            if (kucukHarfSayisi < 3)
            {
                MessageBox.Show("Girmiş olduğunuz şifre içerisinde en az 3 tane küçük harf olmalıdır!");
                return false;
            }
            else if (buyukHarfSayisi < 2)
            {
                MessageBox.Show("Girmiş olduğunuz şifre içerisinde en az 2 tane büyük harf olmalıdır!");
                return false;
            }
            else if (ozelKarakterSayisi < 2)
            {
                MessageBox.Show("Girmiş olduğunuz şifre içerisinde en az 2 tane özel karakter olmalıdır!. Özel Karakterler için (!),(:),(+),(*) kullanılmalıdır.");
                return false;
            }
            return true;
            #endregion
        }

        private void KullaniciKayıtEt()
        {
            #region Kullanici Kayıt İşlemleri 
            secilenYonetici = new Yonetici();
            try
            {
                if (_db.Yoneticiler.Where(x => x.KullaniciAdi == txtKullaniciAdi.Text || x.TelefonNumarasi == txtTelefonNumarasi.Text).Count() > 0) 
                 //Daha önce kayıt yapılmış kullanıcı adı ve telefon numarası mevcutta varsa kayıt yapaması sağlanmıştır. Unique olarak belirlenmiştir. 
                {
                    MessageBox.Show("Daha önce kaydedilmiş Kullanıcı adı veya telefon numarası ile tekrar kullanıcı oluşturulamaz!");
                    Temizle();
                    return;
                }
                else
                {
                    if (txtSifre.Text == txtSifreTekrari.Text) //şifre ve şifre tekrarı eşitse if koşuluna giriyor kayıt oluyor.
                    {
                        secilenYonetici.KullaniciAdi = txtKullaniciAdi.Text.ToLower();
                        secilenYonetici.TelefonNumarasi = txtTelefonNumarasi.Text.Trim();
                        secilenYonetici.Sifre = Metotlar.sha256_hash(txtSifre.Text.Trim());
                        _repository.Ekle(secilenYonetici);
                        MessageBox.Show("Yonetici Kaydedilmiştir.");
                        Temizle();
                        YoneticiEkranınaGirisYap();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Şifreler birbiriyle eşleşmiyor.");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata" + ex.Message);
            }
            #endregion
        }

        private void YoneticiEkranınaGirisYap()
        {
            YoneticiGirisEkrani yonetici = new YoneticiGirisEkrani();
            yonetici.Show();
            this.Hide();
        }
        private void Temizle()
        {
            txtKullaniciAdi.Text = txtSifre.Text = txtSifreTekrari.Text = txtTelefonNumarasi.Text = string.Empty;
        }
    }
}
