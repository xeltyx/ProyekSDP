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

        }
    }
}
