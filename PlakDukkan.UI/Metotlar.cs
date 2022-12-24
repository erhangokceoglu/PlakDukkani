using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PlakDukkan.UI
{
    public static class Metotlar
    {
        public static void Temizle(GroupBox grp) //GroupBoxtaki elemanları temizliyor.
        {
            foreach (var item in grp.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = string.Empty;
                }
                else if (item is DateTimePicker)
                {
                    ((DateTimePicker)item).Value = DateTime.Now;
                }
                else if (item is NumericUpDown)
                {
                    ((NumericUpDown)item).Value = 0;
                }
                else if(item is ComboBox)
                {
                    ((ComboBox)item).SelectedIndex = 0;
                }
            }
        }
        public static string sha256_hash(string sifre) //Şifrenin veritabanında direkt(clear-text) olarak tutulmaması için gereklidir.
        {
            using (SHA256 hash = SHA256Managed.Create())
            {
                return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(sifre)).Select(l => l.ToString("X2")));
            }
        }
    }
}
