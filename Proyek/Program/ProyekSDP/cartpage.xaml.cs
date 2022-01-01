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
using MySql.Data.MySqlClient;
using System.Data;
using System.Globalization;

namespace ProyekSDP
{
    /// <summary>
    /// Interaction logic for cartpage.xaml
    /// </summary>
    public partial class cartpage : Page
    {
        Connection conn = new Connection();
        loggedUser user;
        DataTable dt;
        int userid;
        public cartpage(int id)
        {
            conn.Connect();
            InitializeComponent();
            this.userid = id;
            loadData();
            loadCart();
        }

        public void loadCart()
        {
            conn.conn.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT BARANG.ID, BARANG.NAMA_BARANG, BARANG.HARGA FROM BARANG, CART WHERE CART.ID_BARANG = BARANG.ID AND CART.USERNAME = '{user.username}'", conn.conn);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dgvCart.ItemsSource = dt.DefaultView;
            conn.conn.Close();
            int total = 0;

            conn.conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                total += Convert.ToInt32(reader[2].ToString());
            }

            conn.conn.Close();

            lbl_total.Content = $"Total: {String.Format(CultureInfo.GetCultureInfo("id-ID"), "{0:C2}", total)}";
        }

        public void loadData()
        {
            conn.conn.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM CUSTOMER WHERE ID = {userid}", conn.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                user = new loggedUser(userid, reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), Convert.ToInt32(reader[6].ToString()));
            }
            conn.conn.Close();
        }

        private void Homebtn_Click(object sender, RoutedEventArgs e)
        {
            var menu = new MainMenu(userid);
            this.NavigationService.Navigate(menu);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var profil = new userprofil(userid);
            this.NavigationService.Navigate(profil);
        }


        private void menugrid_MouseLeave(object sender, MouseEventArgs e)
        {
            menugrid.Visibility = Visibility.Hidden;
        }

        private void menubtn_Click(object sender, RoutedEventArgs e)
        {
            menugrid.Visibility = Visibility.Visible;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var login = new Page1();
            this.NavigationService.Navigate(login);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var toko = new sellerpage(userid);
            this.NavigationService.Navigate(toko);
        }

        int index = -1;
        private void dgvCart_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            index = dgvCart.SelectedIndex;
            if(index != -1)
            {
                conn.conn.Open();
                MySqlCommand cmd = new MySqlCommand($"DELETE FROM CART WHERE ID_BARANG = {dt.Rows[index][0].ToString()} AND USERNAME = '{user.username}'", conn.conn);
                cmd.ExecuteNonQuery();
                conn.conn.Close();
                MessageBox.Show("Sukses menghapus item dari cart");
                loadCart();
            }
        }
    }
}
