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
            conn = new MySqlConnection("Datasource=127.0.0.1;username=root;password=;database=dbsdp");
        }
    }
}
