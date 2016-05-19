using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Data.SQLite;
using iMasomo;
namespace iMasomo_Teacher
{
    /// <summary>
    /// Interaction logic for ViewDrawings.xaml
    /// </summary>
    public partial class ViewDrawings : Page
    {
        
        private ObservableCollection<string> images = new ObservableCollection<string>();

        public ViewDrawings()
        {
            InitializeComponent();
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string query = "select path from michoro";
            try
            {
                SQLiteCommand sqliteCommand = new SQLiteCommand(query, Database.GetDatabaseConnection());
                sqliteCommand.ExecuteNonQuery();
                SQLiteDataReader reader = sqliteCommand.ExecuteReader();
                while(reader.Read())
                {
                    images.Add(reader.GetString(0));
                }
                pathComboBox.ItemsSource = images;
                pathComboBox.SelectedIndex = -1;
               
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
        }

        private void pathComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string path = (sender as ComboBox).SelectedItem.ToString();
            image.Source = new BitmapImage(new Uri(path));
        }
       
    }

   
}
