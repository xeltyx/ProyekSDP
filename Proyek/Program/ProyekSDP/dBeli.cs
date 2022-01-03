using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyekSDP
{
    public class dBeli
    {
        public int idBarang { get; set; }
        public string namaBarang { get; set; }
        public int hargaBarang { get; set; }

        public dBeli(int idBarang,string namaBarang, int hargaBarang)
        {
            this.idBarang = idBarang;
            this.namaBarang = namaBarang;
            this.hargaBarang = hargaBarang;
        }
    }
}
