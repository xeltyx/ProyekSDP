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
using System.Windows.Navigation;

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
        string email;
        string password;
        public Page1()
        {
            InitializeComponent();
            conn.Connect();
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {

            email = tbemail.Text.ToString();
            password = tbpassword.Password.ToString();

            if (email.Length > 0 && password.Length > 0)
            {
                if (email.ToLower() == "admin" && password.ToLower() == "admin")
                {
                    var admin = new Admin();
                    this.NavigationService.Navigate(admin);
                }
                else
                {
                    conn.conn.Open();
                    cmd = new MySqlCommand();
                    cmd = new MySqlCommand($"SELECT * FROM CUSTOMER WHERE EMAIL = '{email}'", conn.conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    bool isFound = false;
                    while (reader.Read())
                    {
                        //data2txt.Text = reader.GetString("id");
                        //datatxt.Text = reader.GetString("userId");
                        if (reader[3].ToString() == email)
                        {
                            isFound = true;
                            if (reader[5].ToString() == password)
                            {
                                int id = Convert.ToInt32(reader[0].ToString());
                                var menu = new MainMenu(id);
                                this.NavigationService.Navigate(menu);
                                break;
                            }
                            else
                            {
                                MessageBox.Show("password salah");
                            }
                        }
                    }
                    conn.conn.Close();
                    if (!isFound)
                    {
                        MessageBox.Show("User tidak ditemukan");
                    }
                }
            }
            else
            {
                MessageBox.Show("data tidak boleh kosong");
            }
        }

        private void lbregister_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            
            var reg = new register();
            this.NavigationService.Navigate(reg);
        }

        private void lbregister_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lbregister_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }
    }
}
