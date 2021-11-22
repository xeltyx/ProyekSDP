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
            conn = new MySqlConnection("server=localhost;user=root;database=sdp_db;port=3306;password=");
            conn.Open();
            conn.Close();
        }
    }
}
