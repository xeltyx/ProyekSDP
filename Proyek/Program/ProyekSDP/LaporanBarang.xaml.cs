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
using System.Data;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace ProyekSDP
{
    /// <summary>
    /// Interaction logic for LaporanBarang.xaml
    /// </summary>
    public partial class LaporanBarang : Page
    {
        Connection conn = new Connection();
        DataTable dt;
        public LaporanBarang(string nota)
        {
            InitializeComponent();
            conn.Connect();

            if(nota == "")
            {
                tgl.Content = "Tanggal: Semua";
                conn.conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT BARANG.NAMA_BARANG, COUNT(*) AS COUNT FROM BARANG INNER JOIN D_BELI ON BARANG.ID = D_BELI.ID_BARANG GROUP BY BARANG.ID ORDER BY COUNT DESC", conn.conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                dgvBarang.ItemsSource = null;
                dgvBarang.ItemsSource = dt.DefaultView;
                conn.conn.Close();
            }
            else
            {
                int totalsub = 0;
                string year = nota.Substring(0, 4);
                string month = nota.Substring(4, 2);
                string day = nota.Substring(6, 2);
                tgl.Content = $"Tanggal: {day}/{month}/{year}";
                conn.conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT BARANG.NAMA_BARANG, COUNT(*) AS JUMLAH, BARANG.HARGA * JUMLAH AS SUBTOTAL FROM BARANG INNER JOIN D_BELI ON BARANG.ID = D_BELI.ID_BARANG WHERE D_BELI.NOMOR_NOTA LIKE '%{nota}%' GROUP BY BARANG.ID, SUBTOTAL, JUMLAH ORDER BY JUMLAH DESC", conn.conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                dgvBarang.ItemsSource = null;
                dgvBarang.ItemsSource = dt.DefaultView;
                conn.conn.Close();

                conn.conn.Open();
                cmd = new MySqlCommand($"SELECT COUNT(*) AS JUMLAH, BARANG.HARGA * JUMLAH AS SUBTOTAL FROM BARANG INNER JOIN D_BELI ON BARANG.ID = D_BELI.ID_BARANG WHERE D_BELI.NOMOR_NOTA LIKE '%{nota}%' GROUP BY BARANG.ID, SUBTOTAL, JUMLAH ORDER BY JUMLAH DESC", conn.conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    totalsub += reader.GetInt32(1);
                }

                conn.conn.Close();

                total.Content = "Total: " + String.Format(CultureInfo.GetCultureInfo("id-ID"), "{0:C2}", totalsub);

            }


        }
    }
}
