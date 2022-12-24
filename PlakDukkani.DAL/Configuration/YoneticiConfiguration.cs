using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlakDukkan.DATA.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakDukkan.DAL.Configuration
{
    internal class YoneticiConfiguration : IEntityTypeConfiguration<Yonetici>
    {
        public void Configure(EntityTypeBuilder<Yonetici> builder)
        {
            builder.HasKey(x => x.ID); //Tablonun PK kolonu olarak belirlendi.

            builder.Property(x => x.KullaniciAdi).HasMaxLength(30).IsRequired(); //Kullanici adı maksimum uzunluğu 30 karakter girildi.

            builder.Property(x => x.TelefonNumarasi).HasMaxLength(14).IsRequired(); //Telefon Numarası MaskedTextBox formatından dolayı maksimum uzunluğu 14 karakter girildi.

            builder.Property(x => x.Sifre).HasMaxLength(64).IsRequired(); //Sifre sha256_hash metodundan dolayı 64 karakter alabiliyor maksimum uzunluğu 64 karakter girildi.
        }
    }
}
