using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for ReportPembelian.xaml
    /// </summary>
    public partial class ReportPembelian : Page
    {
        Connection conn = new Connection();
        loggedUser user;
        List<dBeli> dbeliList = new List<dBeli>();
        public ReportPembelian(int id, List<dBeli> dbeli)
        {
            conn.Connect();
            this.dbeliList = dbeli;
            InitializeComponent();
            loadData(id);
            tanggal_lbl.Content = "Tanggal: " + DateTime.Now.ToString("dd/MM/yyyy");
            namapembeli_lbl.Content = "Nama: " + user.nama;
            dgvList.ItemsSource = null;
            dgvList.ItemsSource = dbeli;

            int total = 0;

            foreach(dBeli data in dbeli)
            {
                total += data.hargaBarang;
            }

            foreach (DataGridColumn c in dgvList.Columns)
            {
                c.Width = 0;
                c.Width = DataGridLength.Auto;
            }
            total_lbl.Content = $"Total: {String.Format(CultureInfo.GetCultureInfo("id-ID"), "{0:C2}", total)}";
            


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

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mainmenu = new MainMenu(user.id);
            this.NavigationService.Navigate(mainmenu);
        }
    }
}
