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
using System.Windows.Navigation;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace ProyekSDP
{
    /// <summary>
    /// Interaction logic for register.xaml
    /// </summary>
    public partial class register : Page
    {

        Connection conn = new Connection();
        MySqlCommand cmd;
        public register()
        {
            InitializeComponent();
            conn.Connect();
        }

        private void lblogin_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var page1 = new Page1();
            this.NavigationService.Navigate(page1);
        }

        private void lblogin_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblogin_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void btnregister_Click(object sender, RoutedEventArgs e)
        {
            string email = tbemail.Text.ToString();
            string username = tbusername.Text.ToString();
            string pass = tbpassword.Password.ToString();
            string passconf = tbpassconf.Password.ToString();
            string nomor = tbnomor.Text.ToString();
            string name = tbname.Text.ToString();


            if (email.Length > 0 && username.Length > 0 && pass.Length > 0 && passconf.Length > 0 && nomor.Length > 0)
            {
                if(pass == passconf)
                {
                    try
                    {
                        conn.conn.Open();
                        MySqlCommand cmd = new MySqlCommand($"INSERT INTO CUSTOMER(USERNAME, NAMA_CUST, EMAIL,NO_TELP,PASSWORD, SALDO) VALUES('{username}', '{name}', '{email}', '{nomor}', '{pass}', 0)", conn.conn);
                        
                        cmd.ExecuteNonQuery();
                        conn.conn.Close();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        conn.conn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Konfirmasi password tidak sesuai");
                }
            }
            else
            {
                MessageBox.Show("Data tidak boleh kosong");
            }
        }

        private void tbnomor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
