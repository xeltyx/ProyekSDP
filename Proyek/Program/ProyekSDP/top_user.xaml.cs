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
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace ProyekSDP
{
    /// <summary>
    /// Interaction logic for top_user.xaml
    /// </summary>
    public partial class top_user : Page
    {
        int nominal;
        Connection conn = new Connection();
        MySqlCommand cmd;
        string request="pending";
        int iduser=-1;
        loggedUser user;
        public top_user(int id)
        {
            InitializeComponent();
            conn.Connect();
            iduser = id;
        }

        private void cb_custom_nominal_Checked(object sender, RoutedEventArgs e)
        {
            tb_nominal.IsEnabled = true;
            nominal_grid.IsEnabled = false;
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
            var Main = new Page1();
            this.NavigationService.Navigate(Main);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var profil = new userprofil(iduser);
            this.NavigationService.Navigate(profil);
        }

        private void cb_custom_nominal_Unchecked(object sender, RoutedEventArgs e)
        {
            tb_nominal.IsEnabled = false;
            nominal_grid.IsEnabled = true;
            nominal = 0;
        }

        private void btn_100k_Click(object sender, RoutedEventArgs e)
        {
            btn_100k.Background = new SolidColorBrush(Colors.Blue);
            btn_200k.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            btn_400k.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            btn_600k.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            btn_1m.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            btn_2m.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            nominal = 100000;
        }

        private void btn_200k_Click(object sender, RoutedEventArgs e)
        {
            btn_100k.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            btn_200k.Background = new SolidColorBrush(Colors.Blue);
            btn_400k.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            btn_600k.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            btn_1m.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            btn_2m.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            nominal = 200000;
        }

        private void btn_400k_Click(object sender, RoutedEventArgs e)
        {
            btn_100k.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            btn_200k.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            btn_400k.Background = new SolidColorBrush(Colors.Blue);
            btn_600k.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            btn_1m.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            btn_2m.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            nominal = 400000;
        }

        private void btn_600k_Click(object sender, RoutedEventArgs e)
        {
            btn_100k.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            btn_200k.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            btn_400k.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            btn_600k.Background = new SolidColorBrush(Colors.Blue);
            btn_1m.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            btn_2m.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            nominal = 600000;
        }

        private void btn_1m_Click(object sender, RoutedEventArgs e)
        {
            btn_100k.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            btn_200k.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            btn_400k.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            btn_600k.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            btn_1m.Background = new SolidColorBrush(Colors.Blue);
            btn_2m.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            nominal = 1000000;
        }

        private void btn_2m_Click(object sender, RoutedEventArgs e)
        {
            btn_100k.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            btn_200k.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            btn_400k.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            btn_600k.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            btn_1m.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD"));
            btn_2m.Background = new SolidColorBrush(Colors.Blue);
            nominal = 2000000;
        }

        

        private void btntopup_Click(object sender, RoutedEventArgs e)
        {
            if(cb_custom_nominal.IsChecked==true)
            {
                nominal = Int32.Parse(tb_nominal.Text.ToString());
            }

            if(nominal>0)
            {
                try
                {
                    conn.conn.Open();
                    MySqlCommand cmd = new MySqlCommand($"INSERT INTO REQ_SALDO(ID_CUST, SALDOREQ,KONFIRMASI) VALUES('{iduser}','{nominal}','{request}')", conn.conn);
                    MessageBox.Show("Sedang memproses topup, jika topup tidak masuk dalam kurung 1x24 jam. Hubungi admin");
                    cmd.ExecuteNonQuery();
                    conn.conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.conn.Close();
                }
            }
        }

        private void tb_nominal_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
