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
    internal class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey(x => x.ID); //Tablonun PK kolonu olarak belirlendi.

            builder.Property(x => x.AlbumAdi).HasMaxLength(50).IsRequired(); // Albüm adı maksimum uzunluğu 50 karakter girildi.

            builder.Property(x => x.AlbumSanatcisi).HasMaxLength(30).IsRequired(); //Albüm Sanatcısı Maksimum uzunluğu 30 karakter girildi.

            builder.Property(x => x.AlbumCikisTarihi).HasColumnType("date").IsRequired(); //Album Çıkış Tarihi veritabanında date olarak görülmesi istendi.

            builder.Property(x => x.SatisDevamMı).HasMaxLength(30).IsRequired();  // SatısDevamMı property maksimum uzunluğu 30 karakter girildi.

            builder.Property(x => x.AlbumFiyati).HasMaxLength(10).IsRequired(); // Albüm fiyatı maksimum uzunluğu 10 karakter girildi.

            builder.Property(x => x.IndirimOrani).HasMaxLength(5); // Albüm indirim oranı maksimum uzunluğu 5 karakter girildi
        }
    }
}
