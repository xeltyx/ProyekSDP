using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyekSDP
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        Connection conn = new Connection();
        MySqlCommand cmd;
        public Admin()
        {
            InitializeComponent();
        }

        private void loadUser()
        {
            conn.conn.Open();
            cmd = new MySqlCommand();
            cmd = new MySqlCommand($"SELECT * FROM CUSTOMER", conn.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            conn.conn.Close();
        }

        private void loadBarang()
        {
            conn.conn.Open();
            cmd = new MySqlCommand();
            cmd = new MySqlCommand($"SELECT * FROM BARANG", conn.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            conn.conn.Close();
        }

    }
}
