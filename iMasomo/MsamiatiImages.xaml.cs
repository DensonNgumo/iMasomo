using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
using System.Data.SQLite;


namespace iMasomo
{
    /// <summary>
    /// Interaction logic for Vocabularies.xaml
    /// </summary>
    public partial class MsamiatiImages : Window
    {
        SortedList<string, BitmapImage> imageCollection = new SortedList<string, BitmapImage>();
        string systemImagesPath = Environment.CurrentDirectory;

        private int currImage = 0;
        private int MAXIMAGE = 0;
        private string category="michezo";
        private SQLiteConnection databaseConn;
        
       
        public MsamiatiImages()
        {
            InitializeComponent();
            Database.OpenDatabase();
            SetDatabaseConnection();
           
                             
        }
        private void SetDatabaseConnection()
        {
            databaseConn = Database.GetDatabaseConnection();
        }

        public void SetCategory(string cat)
        {
            category = cat;
        }
        void SetMAXImages()
        {
            try
            {
                 string query = "select count(*) from image_details where category='"+category+"'";
                SQLiteCommand sqliteComm = new SQLiteCommand(query, databaseConn);
                sqliteComm.ExecuteNonQuery();
                SQLiteDataReader dr = sqliteComm.ExecuteReader();
                while (dr.Read())
                {

                    var value = dr.GetValue(0);
                    MAXIMAGE = int.Parse(value.ToString());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetMAXImages();
            //load system images
            string query = "select kiswahili_tag,path from image_details where  category='"+category+"'";
            SQLiteCommand sqliteComm = new SQLiteCommand(query,databaseConn);
            sqliteComm.ExecuteNonQuery();
            SQLiteDataReader dr = sqliteComm.ExecuteReader();
            while (dr.Read())
            {
               imageCollection.Add(dr.GetString(0), new BitmapImage(new Uri(dr.GetString(1), UriKind.RelativeOrAbsolute)));
                             
            }
 
            imageHolder.Source = imageCollection.Values[0];
            imageNameLabel.Content = imageCollection.Keys[0].ToUpper();
            categoryNameLabel.Content = category.ToUpper();
            

        }
      


        private void nextArrowImage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (++currImage >= MAXIMAGE)
            {
                currImage = 0;
            }

            imageHolder.Source = imageCollection.Values[currImage];
            imageNameLabel.Content = imageCollection.Keys[currImage].ToUpper();
        }

        private void previousArrowImage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (--currImage < 0)

                currImage = MAXIMAGE - 1;
            imageHolder.Source = imageCollection.Values[currImage];
            imageNameLabel.Content = imageCollection.Keys[currImage].ToUpper();

        }
    }
}
