using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Animation;
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
        SortedList<string, string> imageDetails;
        string systemImagesPath = Environment.CurrentDirectory;

        private int currImage = 0;
        private int MAXIMAGE = 0;
        private string category="";
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

        private void AnimateText()
        {
            imageNameLabel.Visibility = Visibility.Visible;
            DoubleAnimation dblAnim = new DoubleAnimation();
            dblAnim.To = 1.0;
            dblAnim.From = 0.0;
            dblAnim.BeginTime = TimeSpan.FromSeconds(5);
            dblAnim.Duration = TimeSpan.FromSeconds(5);

            var storyboard = new Storyboard();
            storyboard.Children.Add(dblAnim);
            Storyboard.SetTarget(dblAnim, imageNameLabel);
            Storyboard.SetTargetProperty(dblAnim, new PropertyPath(OpacityProperty));
            storyboard.Completed += delegate { imageNameLabel.Visibility = Visibility.Hidden; };
            storyboard.Begin();
           // imageNameLabel.BeginAnimation(OpacityProperty, dblAnim);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetMAXImages();
            imageDetails = new SortedList<string, string>();
            //load system images
            string query = "select kiswahili_tag,path,image_id,utangulizi from image_details where  category='"+category+"'";
            SQLiteCommand sqliteComm = new SQLiteCommand(query,databaseConn);
            sqliteComm.ExecuteNonQuery();
            SQLiteDataReader dr = sqliteComm.ExecuteReader();
            while (dr.Read())
            {
               imageCollection.Add(dr.GetString(0), new BitmapImage(new Uri(dr.GetString(1), UriKind.RelativeOrAbsolute)));
               
               imageDetails.Add(dr.GetString(0), dr.GetString(3)+"...");
                             
            }
 
            imageHolder.Source = imageCollection.Values[0];
            imageNameLabel.Content = imageCollection.Keys[0].ToUpper();
            categoryNameLabel.Content = category.ToUpper();
            imagePretext.Content = imageDetails.Values[0].ToUpper();
            AnimateText();

        }
      
        private void NextImage()
        {
            
            if (++currImage >= MAXIMAGE)
            {
                currImage = 0;
            }

            imageHolder.Source = imageCollection.Values[currImage];
            imagePretext.Content = imageDetails.Values[currImage].ToUpper();          
            imageNameLabel.Content = imageCollection.Keys[currImage].ToUpper();
            AnimateText();
            
            
        }

        private void PreviousImage()
        {
            if (--currImage < 0)

                currImage = MAXIMAGE - 1;
            imageHolder.Source = imageCollection.Values[currImage];
            imageNameLabel.Content = imageCollection.Keys[currImage].ToUpper();
            imagePretext.Content = imageDetails.Values[currImage].ToUpper();
            AnimateText();
        }

        private void nextArrowImage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            NextImage();
        }

        private void previousArrowImage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PreviousImage();

        }
    }
}
