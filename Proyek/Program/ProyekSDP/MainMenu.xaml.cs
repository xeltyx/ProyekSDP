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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        Connection conn = new Connection();
        loggedUser user;
        List<string> kategori = new List<string>();
        List<Barang> barangList = new List<Barang>();
        Label[] labelList = new Label[4];
        Image[] imgList = new Image[4];
        public MainMenu(int id)
        {
            InitializeComponent();
            conn.Connect();
            labelList[0] = lblprod1;
            labelList[1] = lblprod2;
            labelList[2] = lblprod3;
            labelList[3] = lblprod4;

            imgList[0] = imgprod1;
            imgList[1] = imgprod2;
            imgList[2] = imgprod3;
            imgList[3] = imgprod4;


            loadData(id);
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

        private void menugrid_MouseLeave(object sender, MouseEventArgs e)
        {
            menugrid.Visibility = Visibility.Hidden;
        }

        private void loadData(int id)
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

            cbkategori.Items.Add("All");
            kategori.Add("All");
            conn.conn.Open();
            cmd = new MySqlCommand("SELECT * FROM KATEGORI", conn.conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbkategori.Items.Add(reader[1].ToString());
                kategori.Add(reader[0].ToString());
            }
            conn.conn.Close();

            cbkategori.SelectedIndex = 0;
            loadBarang(cbkategori.SelectedIndex);

        }

        private void loadBarang(int kat)
        {
            barangList.Clear();

            if(kategori[kat] == "All")
            {
                conn.conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM BARANG ORDER BY ID DESC", conn.conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    barangList.Add(new Barang(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), Convert.ToInt32(reader[4].ToString()), Convert.ToInt32(reader[5].ToString())));
                }

                conn.conn.Close();

                for (int i = 0; i < 4; i++)
                {
                    labelList[i].Content = barangList[i].namaBarang;
                    imgList[i].Visibility = Visibility.Visible;
                    labelList[i].Visibility = Visibility.Visible;
                }
            }
            else
            {
                conn.conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM BARANG WHERE KATEGORI='{kategori[kat]}' ORDER BY ID DESC", conn.conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    barangList.Add(new Barang(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), Convert.ToInt32(reader[4].ToString()), Convert.ToInt32(reader[5].ToString())));
                }

                conn.conn.Close();

                for (int i = 0; i < 4; i++)
                {
                    if(i < barangList.Count())
                    {
                        labelList[i].Content = barangList[i].namaBarang;
                        imgList[i].Visibility = Visibility.Visible;
                        labelList[i].Visibility = Visibility.Visible;
                    }
                    else
                    {
                        imgList[i].Visibility = Visibility.Hidden;
                        labelList[i].Visibility = Visibility.Hidden;
                    }
                    
                }
            }
            

        }

        private void findbtn_Click(object sender, RoutedEventArgs e)
        {
            int id = cbkategori.SelectedIndex;
            loadBarang(id);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var profil = new userprofil(user.id);
            this.NavigationService.Navigate(profil);
        }
    }

    
}
