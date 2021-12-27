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
    /// Interaction logic for cartpage.xaml
    /// </summary>
    public partial class cartpage : Page
    {
        int userid;
        List<int> cart = new List<int>();
        public cartpage(List<int> cart, int id)
        {
            InitializeComponent();
            this.cart = cart;
            this.userid = id;
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
    }
}
