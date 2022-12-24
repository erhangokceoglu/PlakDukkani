using PlakDukkan.DAL.Context;
using PlakDukkan.DAL.Repository;
using PlakDukkan.DATA.Sınıflar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PlakDukkan.UI
{
    public partial class AlbumDetayEkrani : Form
    {
        ProjectContext _db;
        Album album;
        Album guncellenecekAlbum;
        Repository<Album> _repository;
        public AlbumDetayEkrani()
        {
            InitializeComponent();
            cmbSatisDevamEdiyorMu.SelectedIndex = 0;
        }

        private void AlbumDetayEkrani_Load(object sender, EventArgs e)
        {
            _db = new ProjectContext();
            _repository = new Repository<Album>(_db);
            Listele();
        }

        private void Listele()
        {
            #region DataGridViewlere Listeleme İşlemleri
            dgvAlbumler.DataSource = _repository.TumunuGetir(); //Tüm albumler listeleniyor.

            dgvIndirimdekiAlbumler.DataSource = (from a in _db.Albumler.Where(x => x.IndirimOrani != 0).OrderByDescending(x => x.IndirimOrani)
                                                 select new { a.AlbumAdi, a.AlbumSanatcisi }).ToList(); //İndirimdeki albumler listeleniyor.

            dgvSon10Albumler.DataSource = (from a in _db.Albumler.AsEnumerable().TakeLast(10)
                                           select new { a.AlbumAdi, a.AlbumSanatcisi }).ToList(); //Eklenen son 10 albumu listeleniyor.

            dgvSatisiDevamEdenAlbumler.DataSource = (from a in _db.Albumler.Where(x => x.SatisDevamMı == "SatisDevamEdiyor")
                                                     select new { a.AlbumAdi, a.AlbumSanatcisi }).ToList();//Satışı devam eden albumler listeleniyor.

            dgvSatisiDurmusAlbumler.DataSource = (from a in _db.Albumler.Where(x => x.SatisDevamMı == "SatisDurduruldu")
                                                  select new { a.AlbumAdi, a.AlbumSanatcisi }).ToList(); //Satışı duran albumler listeleniyor.
            #endregion
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            #region Albüm Ekleme İşlemleri          
            try
            {
                #region Bosluk Kontrolleri İşlemi
                if (txtAlbumAdi.Text == "" || txtAlbumSanatcisi.Text == "" || nudAlbumFiyati.Value == 0)
                {
                    MessageBox.Show("Lütfen boş alanları doldurunuz!");
                    return;
                }
                #endregion

                if (_db.Albumler.Where(x => x.AlbumAdi == txtAlbumAdi.Text).Count() < 1) // Aynı isimde album yoksa if koşulunun içine giriyor.
                {
                    album = new Album();
                    album.AlbumAdi = txtAlbumAdi.Text.Trim();
                    album.AlbumSanatcisi = txtAlbumSanatcisi.Text.Trim();

                    #region Album Cıkış Tarihi Kontrolü
                    if (dtpAlbumCikisTarihi.Value <= new DateTime(1880, 1, 1)) //Araştırma yapılarak bilinen en eski plak 1880 yılında saptanmıştır. If Koşuluna bağlanmıştır.
                    {
                        MessageBox.Show("1880 öncesinde çıkış yapmış plak bulunamamıştır. Lütfen doğru bir tarih giriniz!");
                        return;
                    }
                    else if (dtpAlbumCikisTarihi.Value > DateTime.Now) //Uygulamamızda satışı devam eden ve durdurulan albumler olduğundan dolayı ileri bir tarih girilemez.
                    {
                        MessageBox.Show("İleri tarihte çıkış yapacak plak girilemez. Lütfen doğru bir tarih giriniz!");
                        return;
                    }
                    else
                    {
                        album.AlbumCikisTarihi = dtpAlbumCikisTarihi.Value;
                    }
                    #endregion

                    album.AlbumFiyati = nudAlbumFiyati.Value;
                    album.IndirimOrani = nudIndirimOrani.Value;
                    album.SatisDevamMı = cmbSatisDevamEdiyorMu.SelectedItem.ToString()!;
                    _repository.Ekle(album);
                    Metotlar.Temizle(grpAlbumDetay);
                    Listele();
                    MessageBox.Show("Albüm sisteme başarılı bir şekilde eklenmiştir.");
                }
                else
                {
                    MessageBox.Show("Aynı isimde Albüm mevcuttur.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata" + ex.Message);
            }
            #endregion
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            #region Albüm Silme İşlemleri
            try
            {
                var Id = dgvAlbumler.SelectedCells[0].Value; //DataGridViewden seçilen satırdaki ilk kolon değeri alınıyor.
                var silinenAlbum = _db.Albumler.FirstOrDefault(x => x.ID == (int)Id); //Değer int'e cast ediliyor.
                //Veritabanındaki albumler tablosundaki id'lerden biriyle eşleşerek silme işlemi yapılıyor.
                _repository.Sil(silinenAlbum!);
                _db.SaveChanges();
                MessageBox.Show("Albüm silinmiştir.");
                Metotlar.Temizle(grpAlbumDetay);
                Listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata" + ex.Message);
            }
            #endregion
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            #region Albüm Güncelleme İşlemleri
            try
            {
                var Id = dgvAlbumler.SelectedCells[0].Value; //DataGridViewden seçilen satırdaki ilk kolon değeri alınıyor.
                guncellenecekAlbum = _db.Albumler.FirstOrDefault(x => x.ID == (int)Id)!; //Değer int'e cast ediliyor.
                //Veritabanındaki albumler tablosundaki id'lerden biriyle eşleşerek güncelleme işlemi yapılıyor.
                guncellenecekAlbum.AlbumAdi = txtAlbumAdi.Text.Trim();
                guncellenecekAlbum.AlbumSanatcisi = txtAlbumSanatcisi.Text.Trim();

                #region Album Cıkış Tarihi Güncelleme Kontrolü
                if (dtpAlbumCikisTarihi.Value <= new DateTime(1880, 1, 1)) //Araştırma yapılarak bilinen en eski plak 1880 yılında saptanmıştır. If Koşuluna bağlanmıştır.
                {
                    MessageBox.Show("1880 öncesinde çıkış yapmış plak bulunamamıştır. Lütfen doğru bir güncelleme yapınız!");
                    return;
                }
                else if (dtpAlbumCikisTarihi.Value > DateTime.Now) //Uygulamamızda satışı devam eden ve durdurulan albumler olduğundan dolayı ileri bir tarih girilemez.
                {
                    MessageBox.Show("İleri tarihte çıkış yapacak plak girilemez. Lütfen doğru bir güncelleme yapınız!");
                    return;
                }
                else
                {
                    guncellenecekAlbum.AlbumCikisTarihi = dtpAlbumCikisTarihi.Value;
                }
                #endregion

                guncellenecekAlbum.AlbumFiyati = nudAlbumFiyati.Value;
                guncellenecekAlbum.IndirimOrani = nudIndirimOrani.Value;
                guncellenecekAlbum.SatisDevamMı = cmbSatisDevamEdiyorMu.SelectedItem.ToString()!;
                MessageBox.Show("Albüm bilgileri güncellenmiştir.");
                _repository.Guncelle();
                Metotlar.Temizle(grpAlbumDetay);
                Listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata" + ex.Message);
            }
            #endregion
        }

        private void dgvAlbumler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region DataGridViewden Seçilen Satırdaki Bilgileri Albüm Detay GroupBox'ın İçindeki Elemanlara Aktarma İşlemi
            txtAlbumAdi.Text = dgvAlbumler.CurrentRow.Cells[1].Value.ToString();
            txtAlbumSanatcisi.Text = dgvAlbumler.CurrentRow.Cells[2].Value.ToString();
            dtpAlbumCikisTarihi.Value = (DateTime)dgvAlbumler.CurrentRow.Cells[3].Value;
            nudAlbumFiyati.Value = (decimal)dgvAlbumler.CurrentRow.Cells[4].Value;
            nudIndirimOrani.Value = (decimal)dgvAlbumler.CurrentRow.Cells[5].Value;
            cmbSatisDevamEdiyorMu.Text = dgvAlbumler.CurrentRow.Cells[6].Value.ToString();
            #endregion
        }

        private void YoneticiEkraniGetir()
        {
            YoneticiGirisEkrani yoneticiEkrani = new YoneticiGirisEkrani();
            yoneticiEkrani.Show();
            this.Hide();
        }

        private void AlbumDetayEkrani_FormClosed(object sender, FormClosedEventArgs e)
        {
            YoneticiEkraniGetir();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
