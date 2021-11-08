using System;
using System.Collections.Generic;
using System.Data;
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
using MySql.Data.MySqlClient;

namespace ProyekSDP
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        Connection conn = new Connection();
        MySqlCommand cmd;
        MySqlDataAdapter dataAdapter;
        DataTable dt;
        public Page1()
        {
            InitializeComponent();
            conn.Connect();
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
