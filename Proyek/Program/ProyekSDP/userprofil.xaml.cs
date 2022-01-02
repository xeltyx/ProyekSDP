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
        int iduser;
        loggedUser user;
        public userprofil(int id)
        {
            InitializeComponent();
            conn.Connect();
            loaduser(id);
            iduser = id;
        }
        private void Update(string name, string email, string notelp)
        {
            conn.conn.Open();
            MySqlCommand cmd = new MySqlCommand($"UPDATE customer SET NAMA_CUST=@name,EMAIL=@email, NO_TELP=@notelp WHERE ID={iduser}", conn.conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@notelp", notelp);
            cmd.ExecuteNonQuery();
            conn.conn.Close();
            loaduser(user.id);
            MessageBox.Show("Update berhasil");
        }

        private void changepass(string password)
        {
            if(tbupdate_oldpass.Password == user.password)
            {
                if (tbupdate_newpass.Password == tbupdate_confirm.Password)
                {
                    conn.conn.Open();
                    MySqlCommand cmd = new MySqlCommand($"UPDATE customer SET Password=@password WHERE ID={iduser}", conn.conn);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.ExecuteNonQuery();
                    conn.conn.Close();
                    loaduser(user.id);
                    MessageBox.Show("Change Password Success");
                }
                else
                {
                    MessageBox.Show("Password baru dan password confirmation tidak sama");
                }

            }
            else
            {
                MessageBox.Show("Password salah");
            }

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
            var cart = new cartpage(user.id);
            this.NavigationService.Navigate(cart);
        }

        private void namaUpd_GotFocus(object sender, RoutedEventArgs e)
        {
            if (namaUpd.Text == user.nama)
            {
                namaUpd.Text = "";
            }
        }

        private void namaUpd_LostFocus(object sender, RoutedEventArgs e)
        {
            if (namaUpd.Text == "")
            {
                namaUpd.Text = user.nama;
            }
        }

        private void emailUpd_GotFocus(object sender, RoutedEventArgs e)
        {
            if (emailUpd.Text == user.email)
            {
                emailUpd.Text = "";
            }
        }

        private void emailUpd_LostFocus(object sender, RoutedEventArgs e)
        {
            if (emailUpd.Text == "")
            {
                emailUpd.Text = user.email;
            }
        }

        private void notelpUpd_LostFocus(object sender, RoutedEventArgs e)
        {
            if (notelpUpd.Text == "")
            {
                notelpUpd.Text = user.nomor;
            }
        }

        private void notelpUpd_GotFocus(object sender, RoutedEventArgs e)
        {
            if (notelpUpd.Text == user.nomor)
            {
                notelpUpd.Text = "";
            }
        }

        private void updBtn_Click(object sender, RoutedEventArgs e)
        {
            string nama = namaUpd.Text.ToString();
            string email = emailUpd.Text.ToString();
            string notelp = notelpUpd.Text.ToString();
            Update(nama,email,notelp);
        }

        private void notelpUpd_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
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

        private void btngotoupdate_Click(object sender, RoutedEventArgs e)
        {
            gridprofilupdate.Visibility = Visibility.Visible;
            gridprofil.Visibility = Visibility.Hidden;
            gridprofil_password.Visibility = Visibility.Hidden;
            namaUpd.Text = user.nama;
            emailUpd.Text = user.email;
            notelpUpd.Text = user.nomor;
        }

        private void btn_to_editpass_Click(object sender, RoutedEventArgs e)
        {
            gridprofilupdate.Visibility = Visibility.Hidden;
            gridprofil.Visibility = Visibility.Hidden;
            gridprofil_password.Visibility = Visibility.Visible;
        }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            gridprofilupdate.Visibility = Visibility.Hidden;
            gridprofil.Visibility = Visibility.Visible;
            gridprofil_password.Visibility = Visibility.Hidden;
        }

        private void btnupdatepass_Click(object sender, RoutedEventArgs e)
        {
            changepass(tbupdate_newpass.Password);
        }
    }
}
