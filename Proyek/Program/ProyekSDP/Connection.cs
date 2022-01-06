using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace ProyekSDP
{
    class Connection
    {
        public MySqlConnection conn;
        public void Connect()
        {
            //conn = new MySqlConnection("server=204.2.63.91;user=admin;database=sdp_db;port=19353;password=doA2q9wq;SSL Mode=None");
            conn = new MySqlConnection("server=localhost;user=root;database=sdp_db;port=3306;password=;SSL Mode=None");

            conn.Open();
            conn.Close();
        }
    }
}
