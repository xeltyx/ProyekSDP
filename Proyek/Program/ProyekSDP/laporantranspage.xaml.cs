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
using System.Data;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace ProyekSDP
{
    /// <summary>
    /// Interaction logic for laporantranspage.xaml
    /// </summary>
    public partial class laporantranspage : Page
    {
        Connection conn = new Connection();
        DataTable dt;
        string nama;
        int totalbiaya;
        public laporantranspage(int id)
        {
            conn.Connect();
            InitializeComponent();
            totalbiaya = 0;
            loadUser(id);
            conn.conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd = new MySqlCommand($"SELECT BARANG.NAMA_BARANG AS \"NAMA BARANG\",H_BELI.NOMOR_NOTA AS \"NOMOR NOTA\",D_BELI.jumlah,D_BELI.SUBTOTAL as \"Subtotal\" from BARANG,H_BELI,D_BELI,CUSTOMER where CUSTOMER.ID={id} and H_BELI.ID_CUSTOMER=CUSTOMER.ID and D_BELI.NOMOR_NOTA=H_BELI.NOMOR_NOTA and BARANG.ID=D_BELI.ID_BARANG ORDER BY BARANG.NAMA_BARANG", conn.conn);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dgv.ItemsSource = dt.DefaultView;
            conn.conn.Close();

            conn.conn.Open();
            cmd = new MySqlCommand($"SELECT D_BELI.SUBTOTAL as \"Subtotal\" from BARANG,H_BELI,D_BELI,CUSTOMER where CUSTOMER.ID={id} and H_BELI.ID_CUSTOMER=CUSTOMER.ID and D_BELI.NOMOR_NOTA=H_BELI.NOMOR_NOTA and BARANG.ID=D_BELI.ID_BARANG ORDER BY BARANG.NAMA_BARANG", conn.conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                totalbiaya += reader.GetInt32(0); 
            }
            conn.conn.Close();

            total.Content = $"Total Pembelian Seumur Hidup: {String.Format(CultureInfo.GetCultureInfo("id-ID"), "{0:C2}", totalbiaya)}";
        }

        public void loadUser(int id)
        {
            conn.conn.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT NAMA_CUST FROM CUSTOMER WHERE ID=\"{id}\"", conn.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                nama = reader.GetString(0);
            }

            conn.conn.Close();
            labelnama.Content = $"Nama: {nama}";
        }
    }
}
