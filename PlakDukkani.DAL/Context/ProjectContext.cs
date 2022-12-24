using Microsoft.EntityFrameworkCore;
using PlakDukkan.DAL.Configuration;
using PlakDukkan.DATA.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakDukkan.DAL.Context
{
    public class ProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=PlakDukkaniDb;User Id = sa;Password=1234");
        }
        public DbSet<Yonetici> Yoneticiler => Set<Yonetici>(); //Veritabanında Yoneticiler tablosu oluşturuldu.

        public DbSet<Album> Albumler => Set<Album>(); //Veritabanında Albumler tablosu oluşturuldu.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new YoneticiConfiguration());
            modelBuilder.ApplyConfiguration(new AlbumConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
