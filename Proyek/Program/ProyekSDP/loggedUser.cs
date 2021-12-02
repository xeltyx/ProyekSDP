using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyekSDP
{
    class loggedUser
    {
        public int id { get; set; }
        public string username { get; set; }
        public string nama { get; set; }
        public string email { get; set; }
        public string nomor { get; set; }
        public string password { get; set; }
        public int saldo { get; set; }

        public loggedUser(int id, string username, string nama, string email, string nomor, string password, int saldo)
        {
            this.id = id;
            this.username = username;
            this.nama = nama;
            this.email = email;
            this.nomor = nomor;
            this.password = password;
            this.saldo = saldo;
        }


    }
}
