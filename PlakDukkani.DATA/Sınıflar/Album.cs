using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakDukkan.DATA.Sınıflar
{
    public class Album
    {
        public int ID { get; set; }

        public string AlbumAdi { get; set; } = null!;

        public string AlbumSanatcisi { get; set; } = null!;

        public DateTime AlbumCikisTarihi { get; set; }

        public decimal AlbumFiyati { get; set; }

        public decimal? IndirimOrani { get; set; }

        public string SatisDevamMı { get; set; } = null!;
    }
}
