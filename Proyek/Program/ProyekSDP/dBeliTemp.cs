using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyekSDP
{
    class dBeliTemp
    {
        public string namaBarang { get; set; }
        public int jumlah { get; set; }

        public int hargaBarang { get; set; }

        public dBeliTemp(string namaBarang, int jumlah, int hargaBarang)
        {
            this.namaBarang = namaBarang;
            this.jumlah = jumlah;

            this.hargaBarang = hargaBarang;
        }
    }
}
