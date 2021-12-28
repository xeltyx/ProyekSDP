using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for userprofil.xaml
    /// </summary>
    public partial class userprofil : Page
    {
        Connection conn = new Connection();
        
        loggedUser user;
        public userprofil(int id)
        {
            InitializeComponent();
            conn.Connect();
            loaduser(id);
        }
        private void Update(string name, string email, string notelp,string password)
        {
            conn.conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE User SET name=@name,email=@email, Notelp=@notelp " +
                    "WHERE password =@password",conn.conn);
                cmd.Parameters.AddWithValue("@name",name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@notelp", notelp);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.ExecuteNonQuery();
                conn.conn.Close();
        }
        public void loaduser(int id)
        {
            conn.conn.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM CUSTOMER WHERE ID = {id}", conn.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                user = new loggedUser(id, reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), Convert.ToInt32(reader[6].ToString()));

            }
            conn.conn.Close();
            userLabel.Content = user.username;
            username.Content = "Username:" + user.username;
            name.Content = "Name:" + user.nama;
            email.Content = "Email:" + user.email;
            notelp.Content = "No.Telp:" + user.nomor;
            saldo.Content = "Saldo Anda:" + user.saldo;

        }

        private void menubtn_Click(object sender, RoutedEventArgs e)
        {
            menugrid.Visibility = Visibility.Visible;
        }
        private void menugrid_MouseLeave(object sender, MouseEventArgs e)
        {
            menugrid.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Main = new MainMenu(user.id);
            this.NavigationService.Navigate(Main);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<int> t = new List<int>();
            var cart = new cartpage(t, user.id);
            this.NavigationService.Navigate(cart);
        }

        private void namaUpd_GotFocus(object sender, RoutedEventArgs e)
        {
            if (namaUpd.Text == "Update nama")
            {
                namaUpd.Text = "";
            }
        }

        private void namaUpd_LostFocus(object sender, RoutedEventArgs e)
        {
            if (namaUpd.Text == "")
            {
                namaUpd.Text = "Update nama";
            }
        }

        private void emailUpd_GotFocus(object sender, RoutedEventArgs e)
        {
            if (emailUpd.Text == "Update email")
            {
                emailUpd.Text = "";
            }
        }

        private void emailUpd_LostFocus(object sender, RoutedEventArgs e)
        {
            if (emailUpd.Text == "")
            {
                emailUpd.Text = "Update email";
            }
        }

        private void notelpUpd_LostFocus(object sender, RoutedEventArgs e)
        {
            if (notelpUpd.Text == "")
            {
                notelpUpd.Text = "Update No.Telp";
            }
        }

        private void notelpUpd_GotFocus(object sender, RoutedEventArgs e)
        {
            if (notelpUpd.Text == "Update No.Telp")
            {
                notelpUpd.Text = "";
            }
        }

        private void updBtn_Click(object sender, RoutedEventArgs e)
        {
            string nama = namaUpd.Text.ToString();
            string email = emailUpd.Text.ToString();
            string notelp = notelpUpd.Text.ToString();
            string password = passwordUpd.Text.ToString();

        }

        private void notelpUpd_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void passwordUpd_GotFocus(object sender, RoutedEventArgs e)
        {
            if (passwordUpd.Text == "Masukkan Password")
            {
                passwordUpd.Text = "";
            }
        }

        private void passwordUpd_LostFocus(object sender, RoutedEventArgs e)
        {
            if (passwordUpd.Text == "")
            {
                passwordUpd.Text = "Masukkan Password";
            }
        }

        private void btn_to_topup_Click(object sender, RoutedEventArgs e)
        {
            var topup = new top_user(user.id);
            this.NavigationService.Navigate(topup);
        }

        private void Button_Logout(object sender, RoutedEventArgs e)
        {
            var logout = new Page1();
            this.NavigationService.Navigate(logout);
        }

        private void Button_Toko(object sender, RoutedEventArgs e)
        {
            var seller = new sellerpage(user.id);
            this.NavigationService.Navigate(seller);
        }
    }
}
