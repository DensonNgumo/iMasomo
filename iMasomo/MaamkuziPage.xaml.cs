using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Data.SQLite;


namespace iMasomo
{
    /// <summary>
    /// Interaction logic for MaamkuziPage.xaml
    /// </summary>
    public partial class MaamkuziPage : Page
    {
        int txtID = 1;
        public MaamkuziPage()
        {
            InitializeComponent();
        }
        public void LoadSalamu()
        {
            string query = "select salamu,jibu from salamu_info where salamu_id='" + txtID + "'";
            SQLiteCommand sqliteComm = new SQLiteCommand(query, Database.GetDatabaseConnection());
            sqliteComm.ExecuteNonQuery();
            SQLiteDataReader dr = sqliteComm.ExecuteReader();
            while(dr.Read())
            {
                salamuTxt.Text = dr.GetString(0);
                jibuTxt.Text = dr.GetString(1);
            }
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSalamu();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtID++;
            LoadSalamu();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtID--;
            LoadSalamu();
        }
    }
}
