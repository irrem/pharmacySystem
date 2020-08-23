using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneOtomasyon.Personel_bilgileri
{
     public class PersonelBilgi
    {
        public int PersonelId { get; set; }
        public string PersonelAd { get; set; }
        public string PersonelSoyad { get; set; }
        public DateTime PersonelTarih { get; set; }
        public string OkuduguYer { get; set; }
        public int MezunYil { get; set; }
        public string YasadıgıYer { get; set; }
        public string Ozgecmis { get; set; }
        public string NotOrt { get; set; }
        public string Tc { get; set; }
        public string Sifre { get; set; }

    }
}
