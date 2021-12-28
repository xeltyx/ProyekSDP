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
    /// Interaction logic for sellerpage.xaml
    /// </summary>
    public partial class sellerpage : Page
    {
        Connection conn = new Connection();
        MySqlCommand cmd;
        int userID;
        int barangID;
        public sellerpage(int id)
        {
            InitializeComponent();
            userID = id;
        }

        private void insertProductDigital()
        {
            try
            {
                conn.conn.Open();
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO DIGITAL_SELLER(ID_USER, ID_BARANG) VALUES('{userID}','{barangID}')", conn.conn);
                cmd.ExecuteNonQuery();
                conn.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.conn.Close();
            }
        }
        private void deleteProductDigital()
        {
            try
            {
                conn.conn.Open();
                MySqlCommand cmd = new MySqlCommand($"DELETE FROM DIGITAL_SELLER WHERE id = {userID})", conn.conn);
                cmd.ExecuteNonQuery();
                conn.conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.conn.Close();
            }
        }
    }
}
