using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneOtomasyon.Hasta_Bilgi
{
   public class Hasta
    {
        public int HastaId { get; set; }
        public string HastaAd { get; set; }
        public string HastaSoyad { get; set; }
        public string Tc { get; set; }
        public string Cinsiyet { get; set; }
        public  DateTime HastaDogum { get; set; }
        public string Telefon { get; set; }
        public string Hastaliklar { get; set; }
        public string RaporluIlac { get; set; }
        public string Adres { get; set; }
        public string SaglikGuvence { get; set; }
        public string Alerji { get; set; }


    }
}
