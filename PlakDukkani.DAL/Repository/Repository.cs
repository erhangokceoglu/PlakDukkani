using Microsoft.EntityFrameworkCore;
using PlakDukkan.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakDukkan.DAL.Repository
{
    public class Repository<T> where T : class
    {
        private ProjectContext _db;

        private DbSet<T> varliklarim;

        public Repository(ProjectContext db)
        {
            _db = db;
            varliklarim = _db.Set<T>();
        }
        public void Ekle(T varlik)
        {
            varliklarim.Add(varlik);
            _db.SaveChanges();
        }
        public void Guncelle()
        {
            _db.SaveChanges();
        }
        public void Sil(T varlik)
        {
            varliklarim.Remove(varlik);
            _db.SaveChanges();
        }
        public List<T> TumunuGetir()
        {
            return varliklarim.ToList();
        }
    }
}
