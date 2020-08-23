using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneOtomasyon.Diğer_Ürünler
{
   public class DigerUrun
    {
        public int DisId { get; set; }
        public int KategoriId { get; set; }
        public string Ad { get; set; }
        public string Firma { get; set; }
        public decimal Fiyat { get; set; }
        public string BarkodNo { get; set; }
        public int Stok { get; set; }
    }
}
