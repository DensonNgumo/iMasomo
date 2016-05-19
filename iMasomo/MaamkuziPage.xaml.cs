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
using iMasomo_Teacher;


namespace iMasomo
{
    /// <summary>
    /// Interaction logic for MaamkuziPage.xaml
    /// </summary>
    public partial class MaamkuziPage : Page
    {
        int txtID = 1;
        int MAXCOUNT = 0;

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

        public void GetMaxCount()
        {
            string query = "select count(*) from salamu_info";
            SQLiteCommand sqliteComm = new SQLiteCommand(query, Database.GetDatabaseConnection());
            sqliteComm.ExecuteNonQuery();
            SQLiteDataReader reader = sqliteComm.ExecuteReader();
            while (reader.Read())
            {
                var value = reader.GetValue(0);
                MAXCOUNT = int.Parse(value.ToString());
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Sound.PauseBackgroundMusic();
            GetMaxCount();
            LoadSalamu();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(++txtID>MAXCOUNT)
            {
                txtID = 1;
            }
            LoadSalamu();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(--txtID<1)
            {
                txtID = MAXCOUNT;
            }
            LoadSalamu();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Sound.PlayBackgroundMusic();
        }
    }
}
