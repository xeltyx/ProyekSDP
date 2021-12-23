using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyekSDP
{
    class ReportData
    {
        public string namaBarang { get; set; }
        public string nomorNota { get; set; }
        public int jumlahBarang { get; set; }
        public int subTotal { get; set; }

        public ReportData(string namaBarang, string nomorNota, int jumlahBarang, int subTotal)
        {
            this.namaBarang = namaBarang;
            this.nomorNota = nomorNota;
            this.jumlahBarang = jumlahBarang;
            this.subTotal = subTotal;
        }
    }
}
