using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakDukkan.DATA.Sınıflar
{
    public class Yonetici
    {
        public int ID { get; set; }
        public string KullaniciAdi { get; set; } = null!;
        public string Sifre { get; set; } = null!;
        public string TelefonNumarasi { get; set; } = null!;
    }
}
