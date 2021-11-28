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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        Connection conn = new Connection();
        MySqlCommand cmd;
        DataTable dt;
        string kodekat, kodemerk;
        int index = 0;
        public Admin()
        {
            InitializeComponent();
            conn.Connect();
            loadBarang();
            isimerk();
            isikategori();

        }

        private void loadBarang()
        {
            conn.conn.Open();
            cmd = new MySqlCommand();
            cmd = new MySqlCommand($"SELECT BARANG.ID ,BARANG.NAMA_BARANG AS \"NAMA BARANG\",MERK.NAMA_MERK ,KATEGORI.NAMA_KAT,STOK,HARGA FROM BARANG,MERK,KATEGORI WHERE BARANG.MERK = MERK.KODE_MERK AND BARANG.KATEGORI = KATEGORI.KODE_KAT ORDER BY id ASC", conn.conn);
          //  MySqlDataReader reader = cmd.ExecuteReader();
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dgvUser.ItemsSource = dt.DefaultView;
            conn.conn.Close();
        }

        private void normalmode()
        {
            text_nmbarang.Text = "";
            combo_kategori.SelectedIndex = -1;
            combo_merk.SelectedIndex = -1;
            text_stok.Text = "";
            text_harga.Text = "";
            btn_insert.IsEnabled = true;
            btn_update.IsEnabled = false;
            btn_delete.IsEnabled = false;
        }

        private void isikategori()
        {
            combo_kategori.Items.Clear();
            MySqlCommand cmd = new MySqlCommand($"select * from KATEGORI ORDER BY KODE_KAT", conn.conn);
            conn.conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                combo_kategori.Items.Add(reader.GetString(1));
            }
            combo_kategori.SelectedIndex = -1;
            conn.conn.Close();
        }

        private void isimerk()
        {
            combo_merk.Items.Clear();
            MySqlCommand cmd = new MySqlCommand($"select * from MERK", conn.conn);
            conn.conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                combo_merk.Items.Add(reader.GetString(1));
            }
            combo_merk.SelectedValuePath = "Name";
            combo_merk.SelectedIndex = -1;
            conn.conn.Close();
        }

        private void getkodekat()
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn.conn;
            conn.conn.Open();
            cmd.CommandText = $"select KODE_KAT from KATEGORI where NAMA_KAT = '{combo_kategori.SelectedItem}'";
            kodekat = cmd.ExecuteScalar().ToString();
            conn.conn.Close();
        }

        private void getkodemerk()
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn.conn;
            conn.conn.Open();
            cmd.CommandText = $"select KODE_MERK from MERK where NAMA_MERK = '{combo_merk.SelectedItem}'";
            kodemerk = cmd.ExecuteScalar().ToString();
            conn.conn.Close();
        }

        private void dgvUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
  
        }

        private void dgvUser_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgvUser.SelectedIndex != -1)
            {
                editmode();
                index = Convert.ToInt32(dgvUser.SelectedIndex.ToString());
                text_nmbarang.Text = dt.Rows[dgvUser.SelectedIndex][1].ToString();
                text_stok.Text = dt.Rows[dgvUser.SelectedIndex][4].ToString();
                text_harga.Text = dt.Rows[dgvUser.SelectedIndex][5].ToString();
                combo_kategori.SelectedIndex = combo_kategori.Items.IndexOf(dt.Rows[dgvUser.SelectedIndex][3]);
                combo_merk.SelectedIndex = combo_merk.Items.IndexOf(dt.Rows[dgvUser.SelectedIndex][2]);
            }

        }
        private void editmode()
        {
            btn_insert.IsEnabled = false;
            btn_update.IsEnabled = true;
            btn_delete.IsEnabled = true;
        }

        private void text_harga_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void text_harga_KeyDown(object sender, KeyEventArgs e)
        {
         
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            normalmode();
        }
        
        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            if (text_nmbarang.Text.Length != 0 || text_harga.Text.Length != 0 || text_stok.Text.Length != 0)
            {
                if (combo_kategori.SelectedIndex != -1 || combo_merk.SelectedIndex != -1)
                {
                    getkodekat();
                    getkodemerk();
                    conn.conn.Open();
                    using (MySqlTransaction trans = conn.conn.BeginTransaction())
                    {
                        try
                        {
                            MySqlCommand cmd = new MySqlCommand($"Update Barang SET NAMA_BARANG = '{ text_nmbarang.Text }',MERK = '{ kodemerk }',kategori = '{ kodekat }',STOK = {Convert.ToInt32(text_stok.Text)},HARGA = {Convert.ToInt32(text_harga.Text)} Where id = " + (index+1) ,conn.conn);
                            cmd.ExecuteNonQuery();
                            trans.Commit();
                            conn.conn.Close();
                            MessageBox.Show("Update berhasil");
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            conn.conn.Close();
                            MessageBox.Show(ex.Message);
                            MessageBox.Show(index+"");
                        }
                    }
                    conn.conn.Close();
                    loadBarang();
                    normalmode();
                }
                else
                {
                    MessageBox.Show("Pilih combobox terlebih dahulu");
                }
            }
            else
            {
                MessageBox.Show("isi textbox terlebih dahulu");
            }
        }

        private void btn_insert_Click(object sender, RoutedEventArgs e)
        {
            if (text_nmbarang.Text.Length != 0 || text_harga.Text.Length != 0 || text_stok.Text.Length != 0)
            {
                if (combo_kategori.SelectedIndex != -1 || combo_merk.SelectedIndex != -1)
                {
                    getkodekat();
                    getkodemerk();
                    conn.conn.Open();
                    using (MySqlTransaction trans = conn.conn.BeginTransaction())
                    {
                        try
                        {
                            MySqlCommand cmd = new MySqlCommand($"insert into BARANG(NAMA_BARANG, MERK, KATEGORI,STOK,HARGA) values('{text_nmbarang.Text}','{kodemerk}','{kodekat}',{Convert.ToInt32(text_stok.Text)},{Convert.ToInt32(text_harga.Text)})", conn.conn);
                            cmd.ExecuteNonQuery();
                            trans.Commit();
                            conn.conn.Close();
                            MessageBox.Show("Insert berhasil");
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            conn.conn.Close();
                            MessageBox.Show(ex.Message);
                        }
                    }
                    conn.conn.Close();
                    loadBarang();
                    normalmode();
                }
                else
                {
                    MessageBox.Show("Pilih combobox terlebih dahulu");
                }
            }
            else
            {
                MessageBox.Show("isi textbox terlebih dahulu");
            }
        }
    }
}
