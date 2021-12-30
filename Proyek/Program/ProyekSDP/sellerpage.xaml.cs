using MySql.Data.MySqlClient;
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

namespace ProyekSDP
{
    /// <summary>
    /// Interaction logic for sellerpage.xaml
    /// </summary>
    public partial class sellerpage : Page
    {
        Connection conn = new Connection();
        MySqlCommand cmd;
        DataTable dt;
        MySqlDataReader reader;
        loggedUser user;
        string kodekat, kodemerk;
        int userID;
        int barangID;
        public sellerpage(int id)
        {
            conn.Connect();
            InitializeComponent();
            userID = id;
            loadData();
            loaddatagrid();
        }


        private void getid()
        {
            conn.conn.Open();
            cmd = new MySqlCommand($"SELECT KODE_KAT FROM KATEGORI WHERE NAMA_KAT = '{cb_seller_kat.SelectedItem}'", conn.conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                kodekat = reader[0].ToString();
            }
            conn.conn.Close();

            conn.conn.Open();
            cmd = new MySqlCommand($"SELECT KODE_MERK FROM MERK WHERE NAMA_MERK = '{cb_seller_merk.SelectedItem}'", conn.conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                kodemerk = reader[0].ToString();
            }
            conn.conn.Close();
        }

        private void loaddatagrid()
        {
            conn.conn.Open();
            cmd = new MySqlCommand();
            cmd = new MySqlCommand($"SELECT BARANG.ID ,BARANG.NAMA_BARANG AS \"NAMA BARANG\",MERK.NAMA_MERK ,KATEGORI.NAMA_KAT,STOK,HARGA FROM BARANG,DIGITAL_SELLER,MERK,KATEGORI WHERE BARANG.MERK = MERK.KODE_MERK AND BARANG.KATEGORI = KATEGORI.KODE_KAT AND BARANG.ID=DIGITAL_SELLER.ID_BARANG AND DIGITAL_SELLER.ID_USER = {userID} ORDER BY id ASC", conn.conn);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dgvseller.ItemsSource = dt.DefaultView;
            conn.conn.Close();

            lbseller_info.Content = "";
        }

        private void loadData()
        {
            conn.conn.Open();
            cmd = new MySqlCommand("SELECT * FROM KATEGORI", conn.conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string kode = reader[0].ToString().Substring(3,2);
                if(kode.Equals("02"))
                    cb_seller_kat.Items.Add(reader[1].ToString());
            }
            conn.conn.Close();
            cb_seller_kat.SelectedIndex = 0;


            conn.conn.Open();
            cmd = new MySqlCommand("SELECT * FROM MERK", conn.conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string kode = reader[0].ToString().Substring(3, 2);
                if (kode.Equals("02"))
                    cb_seller_merk.Items.Add(reader[1].ToString());
            }
            conn.conn.Close();
            cb_seller_merk.SelectedIndex = 0;
        }

        private void insertProductDigital()
        {
            string namabarang = tb_seller_nama.Text.ToString();
            int stok = int.Parse(tb_seller_stok.Text.ToString());
            int harga = int.Parse(tb_seller_harga.Text.ToString());

            getid();
            
            try
            {
                conn.conn.Open();
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO BARANG(NAMA_BARANG,MERK,KATEGORI,STOK,HARGA,IMG) VALUES('{namabarang}','{kodemerk}','{kodekat}','{stok}','{harga}','iVBORw0KGgoAAAANSUhEUgAAAPoAAAD6BAMAAAB6wkcOAAAAG1BMVEXMzMwAAAB/f39MTEwZGRmysrKZmZlmZmYzMzNjTEbvAAAACXBIWXMAAA7EAAAOxAGVKw4bAAACeklEQVR4nO3WMU/bQBTA8cPh7IwYHKdjIoGUkaq0YmxIpWR0WkpXpxJRR6gQzUigLXzsvnc+F0ckqK09dPj/pDiPy9M9v8udgzEAAAAAAAAAAAAAAAAAAAAAAAAAAADNCI7iUSbvgwfRkyD6nrx5Ji/QvFsdWQxHec3iYfJ1PtiV4PibkNnsu+vPy4vNea17ybuW4HQ8H3TrVu/J5VKq3vmB7R/S3+7mvPahH5nISvR7Ncu7ijLjvY8vdXmPNue1/bpEHbm03jZQPZJJxj5279PexrxtX92926eL9G/VT4owTPVaLK/N3Ui2Wt3f2Mx9eGfq01l9F8FOOSCxu5PZxUrelq/ed9erBqprq6mda5PRzeM9uF0WdlfztvKzc40XlXuoR1bRdpdxIl22XPWw48ajdKV1t9rTRRzr3jguRjJT24N8x8mBeT+R6oeV6tJ8tXXNM9OTzO7LLb5qqnqgtXJ5nV74/VZWj9Jq6y4vlJcdl/utgeqzng9kV62svDTfXZenm62plbejMpKivvpOWTBdl6dFffW6xc1p+ew0NvVnrbjqhtdt/yTPTHN/1mqfODt5DDt+zYsV0A0fpWvyzDTza35ct3qlJT3m7qnjH6e64X83X8nTY77V02Bs6gkfv03XsvuB6RebSTd82Xw1T1t2PzBBx9RTPVL9XBZV/rbFTi/Oum9+5eilPmf69B+BvxLsfRSZCW4z80EnDPcys39TVHdzR3k1zwwOjH2pH8xem2CyftI/1o5Vx9irePjC1fkSD9d8m2We+TRM4p/u3pZJUrP1irN5GZw/m2fneRk08JAHAAAAAAAAAAAAAAAAAAAAAAAAAAD/mV+CPmI6PVs6jQAAAABJRU5ErkJggg==')", conn.conn);
                cmd.ExecuteNonQuery();
                conn.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.conn.Close();
            }

            conn.conn.Open();
            cmd = new MySqlCommand("SELECT MAX(ID) FROM BARANG", conn.conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                barangID = int.Parse(reader[0].ToString());
            }
            conn.conn.Close();

            try
            {
                conn.conn.Open();
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO DIGITAL_SELLER(ID_USER, ID_BARANG) VALUES('{userID}','{barangID}')", conn.conn);
                cmd.ExecuteNonQuery();
                conn.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.conn.Close();
            }

            MessageBox.Show("Berhasil insert");
        }


        private void deleteProductDigital()
        {
            try
            {
                conn.conn.Open();
                MySqlCommand cmd = new MySqlCommand($"DELETE FROM BARANG WHERE id = {barangID}", conn.conn);
                cmd.ExecuteNonQuery();
                conn.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.conn.Close();
            }

            try
            {
                conn.conn.Open();
                MySqlCommand cmd = new MySqlCommand($"DELETE FROM DIGITAL_SELLER WHERE id_user = {userID} and id_barang = {barangID}", conn.conn);
                cmd.ExecuteNonQuery();
                conn.conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.conn.Close();
            }

            loaddatagrid();
        }

        private void btnseller_gotoinsert_Click(object sender, RoutedEventArgs e)
        {
            gridseller_home.Visibility = Visibility.Hidden;
            gridseller_insert.Visibility = Visibility.Visible;
        }

        private void btn_seller_insert_Click(object sender, RoutedEventArgs e)
        {
            insertProductDigital();
        }

        private void btn_seller_backtohome_Click(object sender, RoutedEventArgs e)
        {
            gridseller_home.Visibility = Visibility.Visible;
            gridseller_insert.Visibility = Visibility.Hidden;
            loaddatagrid();
        }

        private void dgvseller_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgvseller.SelectedIndex != -1)
            {
                string kata = $"Id:              {dt.Rows[dgvseller.SelectedIndex][0]} \n" +
                              $"Nama:        {dt.Rows[dgvseller.SelectedIndex][1]} \n" +
                              $"Merk:         {dt.Rows[dgvseller.SelectedIndex][2]} \n" +
                              $"Kategori:    {dt.Rows[dgvseller.SelectedIndex][3]} \n" +
                              $"Stok:          {dt.Rows[dgvseller.SelectedIndex][4]} \n" +
                              $"Harga:       Rp.{dt.Rows[dgvseller.SelectedIndex][5]} \n";

                lbseller_info.Content = kata;
                barangID = int.Parse(dt.Rows[dgvseller.SelectedIndex][0].ToString());
            }
        }

        private void btnseller_delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure to delete?", "", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                deleteProductDigital();
            }
            
        }

        private void btngoto_MainMenu_Click(object sender, RoutedEventArgs e)
        {
            var mainmenu = new MainMenu(userID);
            this.NavigationService.Navigate(mainmenu);
        }
    }
}
