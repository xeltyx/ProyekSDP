﻿
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
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
        int getiduser;
        List<ReportData> dbeliData = new List<ReportData>();
        bool isAll = false;
        int index = 0;
        public Admin()
        {
            InitializeComponent();
            conn.Connect();
            loadBarang();
            isimerk();
            isikategori();
            loadUser();
            LoadSaldo();
            isilistcustomer();
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

        private void loadUser()
        {
            conn.conn.Open();
            cmd = new MySqlCommand();
            cmd = new MySqlCommand($"SELECT CUSTOMER.NAMA_CUST AS \"NAMA CUSTOMER\",CUSTOMER.SALDO AS \"SALDO\" FROM CUSTOMER ORDER BY id ASC", conn.conn);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dgvcustomer.ItemsSource = dt.DefaultView;
            conn.conn.Close();
        }
        private void LoadSaldo()
        {
            conn.conn.Open();
            cmd = new MySqlCommand();
            cmd = new MySqlCommand($"SELECT REQ_SALDO.ID AS \"ID\",CUSTOMER.NAMA_CUST AS  \"NAMA CUSTOMER\",REQ_SALDO.saldoreq AS  \"SALDO\",CUSTOMER.NO_TELP AS \"NOMOR TELEPON\" FROM REQ_SALDO,CUSTOMER WHERE CUSTOMER.ID = REQ_SALDO.ID_CUST AND REQ_SALDO.KONFIRMASI = 'pending' ORDER BY REQ_SALDO.id ASC", conn.conn);
            //  MySqlDataReader reader = cmd.ExecuteReader();
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dgvkonfirsaldo.ItemsSource = dt.DefaultView;
            conn.conn.Close();
        }

        private void loadLaporan()
        {//laporan
            int sub = 0;
            conn.conn.Open();
            cmd = new MySqlCommand();
            cmd = new MySqlCommand($"SELECT BARANG.NAMA_BARANG AS \"NAMA BARANG\",H_BELI.NOMOR_NOTA AS \"NOMOR NOTA\",D_BELI.jumlah,D_BELI.SUBTOTAL as \"Subtotal\" from BARANG,H_BELI,D_BELI,CUSTOMER where CUSTOMER.ID={getiduser} and H_BELI.ID_CUSTOMER=CUSTOMER.ID and D_BELI.NOMOR_NOTA=H_BELI.NOMOR_NOTA and BARANG.ID=D_BELI.ID_BARANG ORDER BY BARANG.NAMA_BARANG", conn.conn);
            
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dgvLaporan.ItemsSource = dt.DefaultView;
            conn.conn.Close();


            conn.conn.Open();
            cmd = new MySqlCommand($"SELECT D_BELI.SUBTOTAL FROM BARANG,H_BELI,D_BELI,CUSTOMER WHERE CUSTOMER.ID={getiduser} and H_BELI.ID_CUSTOMER=CUSTOMER.ID AND D_BELI.NOMOR_NOTA=H_BELI.NOMOR_NOTA and BARANG.ID=D_BELI.ID_BARANG ORDER BY BARANG.NAMA_BARANG", conn.conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                sub += Convert.ToInt32(reader[0].ToString());
            }
            customerLb.Content = "Name: " + (cblistcustomer.SelectedItem.ToString().Split('-'))[1];
            totalLb.Content = "Total: " + sub.ToString();
            conn.conn.Close();

        }

        private void isilistcustomer()
        {
            cblistcustomer.Items.Clear();
            MySqlCommand cmd = new MySqlCommand($"SELECT ID,NAMA_CUST as \"Nama customer\" from CUSTOMER ORDER BY id", conn.conn);
            conn.conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cblistcustomer.Items.Add(reader.GetString(0) + " - " + reader.GetString(1));
            }
            cblistcustomer.SelectedIndex = -1;
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
                            MySqlCommand cmd = new MySqlCommand($"Update BARANG SET NAMA_BARANG = '{ text_nmbarang.Text }',MERK = '{ kodemerk }',kategori = '{ kodekat }',STOK = {Convert.ToInt32(text_stok.Text)},HARGA = {Convert.ToInt32(text_harga.Text)} Where id = " + (index+1) ,conn.conn);
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

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            conn.conn.Open();
            using (MySqlTransaction trans = conn.conn.BeginTransaction())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand($"delete from BARANG where ID = {index+1}", conn.conn);
                    cmd.ExecuteNonQuery();
                    trans.Commit();
                    conn.conn.Close();
                    MessageBox.Show("delete berhasil");
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

        private void btnPageUser_Click(object sender, RoutedEventArgs e)
        {
            gridlaporan.Visibility = Visibility.Hidden;
            gridbarang.Visibility = Visibility.Hidden;
            griduser.Visibility = Visibility.Visible;
            gridsaldo.Visibility = Visibility.Hidden;
            gridlaporanbarang.Visibility = Visibility.Hidden;
            loadUser();
        }

        private void btnPageBarang_Click(object sender, RoutedEventArgs e)
        {
            gridlaporan.Visibility = Visibility.Hidden;
            gridbarang.Visibility = Visibility.Visible;
            griduser.Visibility = Visibility.Hidden;
            gridsaldo.Visibility = Visibility.Hidden;
            gridlaporanbarang.Visibility = Visibility.Hidden;
            loadBarang();
        }

        private void dgvcustomer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgvcustomer.SelectedIndex != -1)
            {
                tbcustomer_name.Text = dt.Rows[dgvcustomer.SelectedIndex][0].ToString();
                tbcustomer_saldo.Text = dt.Rows[dgvcustomer.SelectedIndex][1].ToString();
            }
        }

        private void btnloadlistcustomer_Click(object sender, RoutedEventArgs e)
        {
            if (cblistcustomer.SelectedIndex != -1)
            {
                string[] temp = cblistcustomer.SelectedItem.ToString().Split('-');
                getiduser = int.Parse(temp[0]);
                loadLaporan();
            }
        }

        private void btnlaporan_Click(object sender, RoutedEventArgs e)
        {
            gridlaporan.Visibility = Visibility.Visible;
            gridbarang.Visibility = Visibility.Hidden;
            griduser.Visibility = Visibility.Hidden;
            gridsaldo.Visibility = Visibility.Hidden;
            gridlaporanbarang.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var login = new Page1();
            this.NavigationService.Navigate(login);
        }

        private void btnreqsaldo_Click(object sender, RoutedEventArgs e)
        {
            gridlaporan.Visibility = Visibility.Hidden;
            gridbarang.Visibility = Visibility.Hidden;
            griduser.Visibility = Visibility.Hidden;
            gridsaldo.Visibility = Visibility.Visible;
            gridlaporanbarang.Visibility = Visibility.Hidden;
            LoadSaldo();
        }

        private void dgvkonfirsaldo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgvkonfirsaldo.SelectedIndex != -1)
            {
                tbnamacust.Text = dt.Rows[dgvkonfirsaldo.SelectedIndex][1].ToString();
                tbsaldo.Text = dt.Rows[dgvkonfirsaldo.SelectedIndex][2].ToString();
            }
        }

        private void btnterima_Click(object sender, RoutedEventArgs e)
        {
            if (tbnamacust.Text.Length != 0 || tbsaldo.Text.Length != 0)
            {
                conn.conn.Open();
                using (MySqlTransaction trans = conn.conn.BeginTransaction())
                {
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand($"Update CUSTOMER SET SALDO = {Convert.ToInt32(tbsaldo.Text)} WHERE NAMA_CUST = '{tbnamacust.Text}'" , conn.conn);
                        MySqlCommand cmd2 = new MySqlCommand($"Update REQ_SALDO SET KONFIRMASI = 'accepted' WHERE ID = {dt.Rows[dgvkonfirsaldo.SelectedIndex][0]}", conn.conn);
                        cmd.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        trans.Commit();
                        conn.conn.Close();
                        MessageBox.Show("Top Up Berhasil Diterima");
                        LoadSaldo();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        conn.conn.Close();
                        MessageBox.Show(ex.Message);
                    }
                }
                   
            }
            else
            {
                MessageBox.Show("pilihan tidak boleh kosong");
            }
        }

        private void btntolak_Click(object sender, RoutedEventArgs e)
        {
            if (tbnamacust.Text.Length != 0 || tbsaldo.Text.Length != 0)
            {
                conn.conn.Open();
                using (MySqlTransaction trans = conn.conn.BeginTransaction())
                {
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand($"Update REQ_SALDO SET KONFIRMASI = 'rejected' WHERE ID = {dt.Rows[dgvkonfirsaldo.SelectedIndex][0]}", conn.conn);
                        cmd.ExecuteNonQuery();
                        trans.Commit();
                        conn.conn.Close();
                        MessageBox.Show("Top Up Berhasil Ditolak");
                        LoadSaldo();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        conn.conn.Close();
                        MessageBox.Show(ex.Message);
                    }
                    tbnamacust.Clear();
                    tbsaldo.Clear();
                }
            }
            else
            {
                MessageBox.Show("pilihan tidak boleh kosong");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var lapor = new laporantranspage(getiduser);
            this.NavigationService.Navigate(lapor);

        }

        string date = "";
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isAll = false;
                date = tglbrg.SelectedDate.Value.Date.ToString("yyyyMMdd");
                conn.conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT BARANG.NAMA_BARANG, COUNT(*) AS COUNT FROM BARANG INNER JOIN D_BELI ON BARANG.ID = D_BELI.ID_BARANG WHERE D_BELI.NOMOR_NOTA LIKE '%{date}%' GROUP BY BARANG.ID ORDER BY COUNT DESC", conn.conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                dgbrg.ItemsSource = null;
                dgbrg.ItemsSource = dt.DefaultView;
                conn.conn.Close();
            }
            catch (Exception E) { }
        }

        private void Loadall_Click(object sender, RoutedEventArgs e)
        {
            tglbrg.SelectedDate = null;
            date = "";
            isAll = true;
            conn.conn.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT BARANG.NAMA_BARANG, COUNT(*) AS COUNT FROM BARANG INNER JOIN D_BELI ON BARANG.ID = D_BELI.ID_BARANG GROUP BY BARANG.ID ORDER BY COUNT DESC", conn.conn);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dgbrg.ItemsSource = null;
            dgbrg.ItemsSource = dt.DefaultView;
            conn.conn.Close();
        }

        private void reportbrg_Click(object sender, RoutedEventArgs e)
        {
            gridlaporan.Visibility = Visibility.Hidden;
            gridbarang.Visibility = Visibility.Hidden;
            griduser.Visibility = Visibility.Hidden;
            gridsaldo.Visibility = Visibility.Hidden;
            gridlaporanbarang.Visibility = Visibility.Visible;
        }

        private void print_Click(object sender, RoutedEventArgs e)
        {
            var lprbrg = new LaporanBarang(date);
            this.NavigationService.Navigate(lprbrg);
        }

        private void btn_insert_Click(object sender, RoutedEventArgs e)
        {
            if (text_nmbarang.Text.Length != 0 || text_harga.Text.Length != 0 || text_stok.Text.Length != 0)
            {
                if (combo_kategori.SelectedIndex != -1 || combo_merk.SelectedIndex != -1)
                {
                    var text = new TextRange(rtbgambar.Document.ContentStart, rtbgambar.Document.ContentEnd).Text;
                    getkodekat();
                    getkodemerk();
                    conn.conn.Open();
                    using (MySqlTransaction trans = conn.conn.BeginTransaction())
                    {
                        try
                        {
                            MySqlCommand cmd;
                            if (text.Length > 0)
                                cmd = new MySqlCommand($"insert into BARANG(NAMA_BARANG, MERK, KATEGORI,STOK,HARGA,IMG) values('{text_nmbarang.Text}','{kodemerk}','{kodekat}',{Convert.ToInt32(text_stok.Text)},{Convert.ToInt32(text_harga.Text)},'{text}')", conn.conn);
                            else
                                cmd = new MySqlCommand($"insert into BARANG(NAMA_BARANG, MERK, KATEGORI,STOK,HARGA,IMG) values('{text_nmbarang.Text}','{kodemerk}','{kodekat}',{Convert.ToInt32(text_stok.Text)},{Convert.ToInt32(text_harga.Text)},'iVBORw0KGgoAAAANSUhEUgAAAPoAAAD6BAMAAAB6wkcOAAAAG1BMVEXMzMwAAAB/f39MTEwZGRmysrKZmZlmZmYzMzNjTEbvAAAACXBIWXMAAA7EAAAOxAGVKw4bAAACeklEQVR4nO3WMU/bQBTA8cPh7IwYHKdjIoGUkaq0YmxIpWR0WkpXpxJRR6gQzUigLXzsvnc+F0ckqK09dPj/pDiPy9M9v8udgzEAAAAAAAAAAAAAAAAAAAAAAAAAAADNCI7iUSbvgwfRkyD6nrx5Ji/QvFsdWQxHec3iYfJ1PtiV4PibkNnsu+vPy4vNea17ybuW4HQ8H3TrVu/J5VKq3vmB7R/S3+7mvPahH5nISvR7Ncu7ijLjvY8vdXmPNue1/bpEHbm03jZQPZJJxj5279PexrxtX92926eL9G/VT4owTPVaLK/N3Ui2Wt3f2Mx9eGfq01l9F8FOOSCxu5PZxUrelq/ed9erBqprq6mda5PRzeM9uF0WdlfztvKzc40XlXuoR1bRdpdxIl22XPWw48ajdKV1t9rTRRzr3jguRjJT24N8x8mBeT+R6oeV6tJ8tXXNM9OTzO7LLb5qqnqgtXJ5nV74/VZWj9Jq6y4vlJcdl/utgeqzng9kV62svDTfXZenm62plbejMpKivvpOWTBdl6dFffW6xc1p+ew0NvVnrbjqhtdt/yTPTHN/1mqfODt5DDt+zYsV0A0fpWvyzDTza35ct3qlJT3m7qnjH6e64X83X8nTY77V02Bs6gkfv03XsvuB6RebSTd82Xw1T1t2PzBBx9RTPVL9XBZV/rbFTi/Oum9+5eilPmf69B+BvxLsfRSZCW4z80EnDPcys39TVHdzR3k1zwwOjH2pH8xem2CyftI/1o5Vx9irePjC1fkSD9d8m2We+TRM4p/u3pZJUrP1irN5GZw/m2fneRk08JAHAAAAAAAAAAAAAAAAAAAAAAAAAAD/mV+CPmI6PVs6jQAAAABJRU5ErkJggg==')", conn.conn);

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
