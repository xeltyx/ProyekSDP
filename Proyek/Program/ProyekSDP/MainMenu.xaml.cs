using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
        Label[] labelList = new Label[8];
        Image[] imgList = new Image[8];
        int indexingItem = 0;
        String[] isicombosort = {"no filter","sort by highest price","sort by lowest price"};
        public MainMenu(int id)
        {
            InitializeComponent();
            conn.Connect();
            labelList[0] = lblprod1;
            labelList[1] = lblprod2;
            labelList[2] = lblprod3;
            labelList[3] = lblprod4;
            labelList[4] = lblprod5;
            labelList[5] = lblprod6;
            labelList[6] = lblprod7;
            labelList[7] = lblprod8;

            imgList[0] = imgprod1;
            imgList[1] = imgprod2;
            imgList[2] = imgprod3;
            imgList[3] = imgprod4;
            imgList[4] = imgprod5;
            imgList[5] = imgprod6;
            imgList[6] = imgprod7;
            imgList[7] = imgprod8;
            prevButton.IsEnabled = false;

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
            filtercombo();
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
        private void filtercombo()
        {
            filtercb.Items.Add(isicombosort[0]);
            filtercb.Items.Add(isicombosort[1]);
            filtercb.Items.Add(isicombosort[2]);
            filtercb.SelectedIndex = 0;
        }

        private void loadBarang(int kat)
        {
            barangList.Clear();
            indexingItem = 0;
            if (kategori[kat] == "All")
            {
                conn.conn.Open();
                if(filtercb.SelectedIndex == 0)
                {
                    if (tbsearch.Text.Length > 0)
                    {
                        MySqlCommand cmd = new MySqlCommand($"SELECT * FROM BARANG WHERE UPPER(NAMA_BARANG) like '%{tbsearch.Text.ToUpper()}%' ORDER BY ID DESC", conn.conn);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            byte[] binaryData = Convert.FromBase64String(Encoding.UTF8.GetString((byte[])(reader[6])));
                            barangList.Add(new Barang(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), Convert.ToInt32(reader[4].ToString()), Convert.ToInt32(reader[5].ToString()), binaryData));
                        }
                    }
                    else
                    {
                        MySqlCommand cmd = new MySqlCommand("SELECT * FROM BARANG ORDER BY ID DESC", conn.conn);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        int ctr = 1;
                        while (reader.Read())
                        {
                            MessageBox.Show(ctr + "");
                            ctr++;
                            byte[] binaryData = Convert.FromBase64String(Encoding.UTF8.GetString((byte[])(reader[6])));
                            barangList.Add(new Barang(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), Convert.ToInt32(reader[4].ToString()), Convert.ToInt32(reader[5].ToString()), binaryData));
                        }
                    }

                    conn.conn.Close();

                    
                }else if (filtercb.SelectedIndex == 1)
                {
                    if (tbsearch.Text.Length > 0)
                    {
                        MySqlCommand cmd = new MySqlCommand($"SELECT * FROM BARANG WHERE UPPER(NAMA_BARANG) like '%{tbsearch.Text.ToUpper()}%' ORDER BY harga DESC", conn.conn);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            byte[] binaryData = Convert.FromBase64String(Encoding.UTF8.GetString((byte[])(reader[6])));
                            barangList.Add(new Barang(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), Convert.ToInt32(reader[4].ToString()), Convert.ToInt32(reader[5].ToString()), binaryData));
                        }
                    }
                    else
                    {
                        MySqlCommand cmd = new MySqlCommand("SELECT * FROM BARANG ORDER BY harga DESC", conn.conn);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            byte[] binaryData = Convert.FromBase64String(Encoding.UTF8.GetString((byte[])(reader[6])));
                            barangList.Add(new Barang(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), Convert.ToInt32(reader[4].ToString()), Convert.ToInt32(reader[5].ToString()), binaryData));
                        }
                    }

                    conn.conn.Close();
                }else if (filtercb.SelectedIndex == 2)
                {
                    if (tbsearch.Text.Length > 0)
                    {
                        MySqlCommand cmd = new MySqlCommand($"SELECT * FROM BARANG WHERE  UPPER(NAMA_BARANG) like '%{tbsearch.Text.ToUpper()}%' ORDER BY harga ASC", conn.conn);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            byte[] binaryData = Convert.FromBase64String(Encoding.UTF8.GetString((byte[])(reader[6])));
                            barangList.Add(new Barang(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), Convert.ToInt32(reader[4].ToString()), Convert.ToInt32(reader[5].ToString()), binaryData));
                        }
                    }
                    else
                    {
                        MySqlCommand cmd = new MySqlCommand("SELECT * FROM BARANG ORDER BY harga ASC", conn.conn);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            byte[] binaryData = Convert.FromBase64String(Encoding.UTF8.GetString((byte[])(reader[6])));
                            barangList.Add(new Barang(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), Convert.ToInt32(reader[4].ToString()), Convert.ToInt32(reader[5].ToString()), binaryData));
                        }
                    }

                    conn.conn.Close();
                }
            }
            else
            {
                if(filtercb.SelectedIndex == 0)
                {
                    if (tbsearch.Text.Length > 0)
                    {
                        conn.conn.Open();
                        MySqlCommand cmd = new MySqlCommand($"SELECT * FROM BARANG WHERE KATEGORI='{kategori[kat]}' AND UPPER(NAMA_BARANG) like '%{tbsearch.Text.ToUpper()}%' ORDER BY ID DESC", conn.conn);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            byte[] binaryData = Convert.FromBase64String(Encoding.UTF8.GetString((byte[])(reader[6])));
                            barangList.Add(new Barang(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), Convert.ToInt32(reader[4].ToString()), Convert.ToInt32(reader[5].ToString()), binaryData));
                        }
                    }
                    else
                    {
                        conn.conn.Open();
                        MySqlCommand cmd = new MySqlCommand($"SELECT * FROM BARANG WHERE KATEGORI='{kategori[kat]}' ORDER BY ID DESC", conn.conn);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            byte[] binaryData = Convert.FromBase64String(Encoding.UTF8.GetString((byte[])(reader[6])));
                            barangList.Add(new Barang(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), Convert.ToInt32(reader[4].ToString()), Convert.ToInt32(reader[5].ToString()), binaryData));
                        }
                    }
                   
                    conn.conn.Close();

                    
                }else if (filtercb.SelectedIndex == 1)
                {
                    if (tbsearch.Text.Length > 0)
                    {
                        conn.conn.Open();
                        MySqlCommand cmd = new MySqlCommand($"SELECT * FROM BARANG WHERE KATEGORI='{kategori[kat]}' AND UPPER(NAMA_BARANG) like '%{tbsearch.Text.ToUpper()}%' ORDER BY harga DESC", conn.conn);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            byte[] binaryData = Convert.FromBase64String(Encoding.UTF8.GetString((byte[])(reader[6])));
                            barangList.Add(new Barang(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), Convert.ToInt32(reader[4].ToString()), Convert.ToInt32(reader[5].ToString()), binaryData));
                        }
                    }
                    else
                    {
                        conn.conn.Open();
                        MySqlCommand cmd = new MySqlCommand($"SELECT * FROM BARANG WHERE KATEGORI='{kategori[kat]}' ORDER BY harga DESC", conn.conn);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            byte[] binaryData = Convert.FromBase64String(Encoding.UTF8.GetString((byte[])(reader[6])));
                            barangList.Add(new Barang(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), Convert.ToInt32(reader[4].ToString()), Convert.ToInt32(reader[5].ToString()), binaryData));
                        }
                    }
                    conn.conn.Close();

                    
                }else if (filtercb.SelectedIndex == 2)
                {
                    if (tbsearch.Text.Length > 0)
                    {
                        conn.conn.Open();
                        MySqlCommand cmd = new MySqlCommand($"SELECT * FROM BARANG WHERE KATEGORI='{kategori[kat]}' AND UPPER(NAMA_BARANG) like '%{tbsearch.Text.ToUpper()}%' ORDER BY harga ASC", conn.conn);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            byte[] binaryData = Convert.FromBase64String(Encoding.UTF8.GetString((byte[])(reader[6])));
                            barangList.Add(new Barang(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), Convert.ToInt32(reader[4].ToString()), Convert.ToInt32(reader[5].ToString()), binaryData));
                        }
                    }
                    else
                    {
                        conn.conn.Open();
                        MySqlCommand cmd = new MySqlCommand($"SELECT * FROM BARANG WHERE KATEGORI='{kategori[kat]}' ORDER BY harga ASC", conn.conn);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            byte[] binaryData = Convert.FromBase64String(Encoding.UTF8.GetString((byte[])(reader[6])));
                            barangList.Add(new Barang(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), Convert.ToInt32(reader[4].ToString()), Convert.ToInt32(reader[5].ToString()), binaryData));
                        }
                    }
                    conn.conn.Close();
                }
            }
            loadBarangScreen();
            nextbtn.IsEnabled = true;
            MessageBox.Show(Math.Ceiling(Convert.ToDouble(barangList.Count() / 8)) + "");
            if (indexingItem == Math.Ceiling(Convert.ToDouble(barangList.Count() / 8)))
            {
                nextbtn.IsEnabled = false;
            }
            

            if (indexingItem == 0)
            {
                prevButton.IsEnabled = false;
            }
        }

 
        private void loadBarangScreen()
        {
            
            int ctr = 0;
            for (int i = 0 + (indexingItem * 8); i < 8 + (indexingItem * 8); i++)
            {
                if (i < barangList.Count())
                {   
                    labelList[ctr].Content = barangList[i].namaBarang + "\n" + String.Format(CultureInfo.GetCultureInfo("id-ID"), "{0:C2}", barangList[i].Harga);
                    imgList[ctr].Visibility = Visibility.Visible;
                    imgList[ctr].Source = ByteImageConverter.ByteToImage(barangList[i].Gambar);
                    labelList[ctr].Visibility = Visibility.Visible;

                } 
                else
                {
                    imgList[ctr].Visibility = Visibility.Hidden;
                    labelList[ctr].Visibility = Visibility.Hidden;
                }
                ctr++;

            }
            if (indexingItem == Math.Ceiling(Convert.ToDouble(barangList.Count() / 8)))
            {
                nextbtn.IsEnabled = false;
            }

            if (indexingItem == 0)
            {
                prevButton.IsEnabled = false;
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

        private void nextbtn_Click(object sender, RoutedEventArgs e)
        {
            indexingItem++;
            loadBarangScreen();
            prevButton.IsEnabled = true;
            if (indexingItem == Math.Ceiling(Convert.ToDouble(barangList.Count() / 4)))
            {
                nextbtn.IsEnabled = false;
            }
        }

        private void prevButton_Click(object sender, RoutedEventArgs e)
        {
            indexingItem--;
            loadBarangScreen();
            nextbtn.IsEnabled = true;

            if (indexingItem == 0)
            {
                prevButton.IsEnabled = false;
            }
        }

        private void cbkategori_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    public class ByteImageConverter
    {
        public static ImageSource ByteToImage(byte[] imageData)
        {
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            ImageSource imgSrc = biImg as ImageSource;

            return imgSrc;
        }
    }


}
