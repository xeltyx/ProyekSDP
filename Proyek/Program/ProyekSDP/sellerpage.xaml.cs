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
        MySqlDataReader reader;
        loggedUser user;
        int userID;
        int barangID;
        public sellerpage(int id)
        {
            conn.Connect();
            InitializeComponent();
            userID = id;
            loadData();
        }

        private void loadData()
        {
            conn.conn.Open();
            cmd = new MySqlCommand("SELECT * FROM KATEGORI", conn.conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string kode = reader[0].ToString().Substring(3,2);
                if(kode.Equals("02"))
                    cb_seller_kat.Items.Add(reader[1].ToString());
            }
            conn.conn.Close();
            cb_seller_kat.SelectedIndex = 0;


            conn.conn.Open();
            cmd = new MySqlCommand("SELECT * FROM MERK", conn.conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string kode = reader[0].ToString().Substring(3, 2);
                if (kode.Equals("02"))
                    cb_seller_merk.Items.Add(reader[1].ToString());
            }
            conn.conn.Close();
            cb_seller_merk.SelectedIndex = 0;
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

        private void btnseller_gotoinsert_Click(object sender, RoutedEventArgs e)
        {
            gridseller_home.Visibility = Visibility.Hidden;
            gridseller_insert.Visibility = Visibility.Visible;
        }

        private void btn_seller_insert_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_seller_backtohome_Click(object sender, RoutedEventArgs e)
        {
            gridseller_home.Visibility = Visibility.Visible;
            gridseller_insert.Visibility = Visibility.Hidden;
        }

        private void btngoto_MainMenu_Click(object sender, RoutedEventArgs e)
        {
            var mainmenu = new MainMenu(userID);
            this.NavigationService.Navigate(mainmenu);
        }
    }
}
