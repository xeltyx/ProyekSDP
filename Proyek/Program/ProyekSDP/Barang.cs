using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyekSDP
{
    class Barang
    {
        public int id { get; set; }
        public string namaBarang { get; set; }
        public string Merk { get; set; }
        public string Kategori { get; set; }
        public int Stok { get; set; }
        public int Harga { get; set; }

        public byte[] Gambar { get; set; }
        public Barang(int id, string namaBarang, string merk, string kategori, int stok, int harga, byte[] Gambar)
        {
            this.id = id;
            this.namaBarang = namaBarang;
            Merk = merk;
            Kategori = kategori;
            Stok = stok;
            Harga = harga;
            this.Gambar = Gambar;
        }


    }
}
