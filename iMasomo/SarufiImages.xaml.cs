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
using System.Windows.Media.Imaging;
using System.Data.SQLite;


namespace iMasomo
{
    /// <summary>
    /// Interaction logic for UmojaWingiPage.xaml
    /// </summary>
    public partial class SarufiImages : Page
    {
        int currImage = 1;
        int MAXIMAGE = 0;
        string umojaTxt, wingiTxt,kiumeTxt,kikeTxt,path1, path2,category;
        public SarufiImages()
        {
            InitializeComponent();
        }

        public void SetCategory(string cat)
        {
            category = cat;
            titleTxtBlock.Text = category;
            
        }

        public void GetMaxImageCount()///check
        {
            string tableName;
            switch(category)
            {
                case "Umoja na Wingi":
                    tableName = "umoja_wingi";
                    break;
                case "Kike na Kiume":
                    tableName="kike_kiume";
                    break;
                case "Vihusishi":
                    tableName = "vihusishi";
                    break;
                case "Vitenzi":
                    tableName = "vitenzi";
                    break;
                default:
                    tableName = "vihusishi";
                    break;
            }

            string query = "select count(*) from '" + tableName + "'";
            try
            {
                SQLiteCommand command = new SQLiteCommand(query, Database.GetDatabaseConnection());
                command.ExecuteNonQuery();
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    var value = reader.GetValue(0);
                    MAXIMAGE = int.Parse(value.ToString());
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
                      
    
        }

        public void LoadUmojaWingiImages()
        {
            //GetMaxImageCount();
            int umojaId = 0;
            int wingiId = 0;
            string query = "select umoja_image_id,wingi_image_id from umoja_wingi where id='" + currImage + "'";
            try
            {
                SQLiteCommand command = new SQLiteCommand(query, Database.GetDatabaseConnection());
                command.ExecuteNonQuery();
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var value1 = reader.GetValue(0);
                    var value2 = reader.GetValue(1);
                    umojaId = int.Parse(value1.ToString());
                    wingiId = int.Parse(value2.ToString());
                  
                     
                }
                path1 = LoadImagePath(umojaId);
                umojaTxt = LoadImageTag(umojaId);

                path2 = LoadImagePath(wingiId);
                wingiTxt = LoadImageTag(wingiId);
                /*
                string query1 = "select kiswahili_tag,path from image_details where image_id='" + umojaId + "'";
                string query2 = "select kiswahili_tag,path from image_details where image_id='" + wingiId + "'";

                SQLiteCommand sqliteCommand1 = new SQLiteCommand(query1, Database.GetDatabaseConnection());
                sqliteCommand1.ExecuteNonQuery();
                SQLiteDataReader sqliteReader1 = sqliteCommand1.ExecuteReader();
                while (sqliteReader1.Read())
                {

                    umojaTxt = sqliteReader1.GetString(0);
                    path1 = sqliteReader1.GetString(1);

                }

                SQLiteCommand sqliteCommand2 = new SQLiteCommand(query2, Database.GetDatabaseConnection());
                sqliteCommand2.ExecuteNonQuery();
                SQLiteDataReader sqliteReader2 = sqliteCommand2.ExecuteReader();
                while (sqliteReader2.Read())
                {
                    wingiTxt = sqliteReader2.GetString(0);
                    path2 = sqliteReader2.GetString(1);

                }*/

                leftTxtBlock.Text = umojaTxt;
                rightTxtBlock.Text = wingiTxt;
                image1.Source = new BitmapImage(new Uri(path1, UriKind.RelativeOrAbsolute));
                image2.Source = new BitmapImage(new Uri(path2, UriKind.RelativeOrAbsolute));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
        }

        public void LoadKikeKiumeImages()
        {
            //GetMaxImageCount();
            int kikeId = 0;
            int kiumeId = 0;
            string query = "select kike_image_id,kiume_image_id from kike_kiume where id='" + currImage + "'";
            try
            {
                SQLiteCommand command = new SQLiteCommand(query, Database.GetDatabaseConnection());
                command.ExecuteNonQuery();
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var value1 = reader.GetValue(0);
                    var value2 = reader.GetValue(1);
                    kikeId = int.Parse(value1.ToString());
                    kiumeId = int.Parse(value2.ToString());


                }

                path1 = LoadImagePath(kikeId);
                kikeTxt = LoadImageTag(kikeId);

                path2 = LoadImagePath(kiumeId);
                kiumeTxt = LoadImageTag(kiumeId);
                /*
                string query1 = "select kiswahili_tag,path from image_details where image_id='" + kikeId + "'";
                string query2 = "select kiswahili_tag,path from image_details where image_id='" + kiumeId + "'";

                SQLiteCommand sqliteCommand1 = new SQLiteCommand(query1, Database.GetDatabaseConnection());
                sqliteCommand1.ExecuteNonQuery();
                SQLiteDataReader sqliteReader1 = sqliteCommand1.ExecuteReader();
                while (sqliteReader1.Read())
                {

                    kikeTxt = sqliteReader1.GetString(0);
                    path1 = sqliteReader1.GetString(1);

                }

                SQLiteCommand sqliteCommand2 = new SQLiteCommand(query2, Database.GetDatabaseConnection());
                sqliteCommand2.ExecuteNonQuery();
                SQLiteDataReader sqliteReader2 = sqliteCommand2.ExecuteReader();
                while (sqliteReader2.Read())
                {
                    kiumeTxt = sqliteReader2.GetString(0);
                    path2 = sqliteReader2.GetString(1);

                }*/

                leftTxtBlock.Text = kikeTxt;
                rightTxtBlock.Text = kiumeTxt;
                image1.Source = new BitmapImage(new Uri(path1, UriKind.RelativeOrAbsolute));
                image2.Source = new BitmapImage(new Uri(path2, UriKind.RelativeOrAbsolute));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        public void LoadVihusishiImages()
        {
            //GetMaxImageCount();
            int imageId = 0;
            string maelezoTxt="kihusishi";
            string query = "select image_id,maelezo from vihusishi where id='" + currImage + "'";
            try
            {
                SQLiteCommand command = new SQLiteCommand(query, Database.GetDatabaseConnection());
                command.ExecuteNonQuery();
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var value1 = reader.GetValue(0);                
                    imageId = int.Parse(value1.ToString());
                    maelezoTxt = reader.GetString(1);
                }

                string query1 = "select path from image_details where image_id='" + imageId + "'";
                path1 = LoadImagePath(imageId);  
                leftTxtBlock.Text = maelezoTxt;
                image1.Source = new BitmapImage(new Uri(path1, UriKind.RelativeOrAbsolute));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        public void LoadVitenziImages()
        {
            //GetMaxImageCount();
            int imageId = 0;
            string maelezoTxt = "vitenzi";
            string query = "select image_id,maelezo from vitenzi where id='" + currImage + "'";
            try
            {
                SQLiteCommand command = new SQLiteCommand(query, Database.GetDatabaseConnection());
                command.ExecuteNonQuery();
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var value1 = reader.GetValue(0);
                    imageId = int.Parse(value1.ToString());
                    maelezoTxt = reader.GetString(1);
                }

                path1 = LoadImagePath(imageId);

                leftTxtBlock.Text = maelezoTxt;
                image1.Source = new BitmapImage(new Uri(path1, UriKind.RelativeOrAbsolute));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private string LoadImagePath(int id)
        {
            string path="";
            string query = "select path from image_details where image_id='" + id + "'";
            try 
            {
                SQLiteCommand sqliteCommand = new SQLiteCommand(query, Database.GetDatabaseConnection());
                sqliteCommand.ExecuteNonQuery();
                SQLiteDataReader sqliteReader = sqliteCommand.ExecuteReader();
                while (sqliteReader.Read())
                {

                    path = sqliteReader.GetString(0);

                }
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return path;
        }

        private string LoadImageTag(int id)
        {
            string tag="";
            string query = "select kiswahili_tag from image_details where image_id='" + id + "'";
            try
            {
                SQLiteCommand sqliteCommand = new SQLiteCommand(query, Database.GetDatabaseConnection());
                sqliteCommand.ExecuteNonQuery();
                SQLiteDataReader sqliteReader = sqliteCommand.ExecuteReader();
                while (sqliteReader.Read())
                {
                    tag = sqliteReader.GetString(0);

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return tag;

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //GetMaxImageCount();
            //LoadUmojaWingiImages();
        }

        private void leftArrow_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(--currImage<1)
            {
                currImage = MAXIMAGE;
            }
            if (category == "Umoja na Wingi")
            {
                LoadUmojaWingiImages();
            }
            else if (category == "Kike na Kiume")
            {
                LoadKikeKiumeImages();
            }
            else if (category == "Vihusishi")
            {
                LoadVihusishiImages();
            }
            else if (category == "Vitenzi")
            {
                LoadVitenziImages();
            }
        }

        private void rightArrow_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(++currImage>MAXIMAGE)
            {
                currImage = 1;
            }
            if (category == "Umoja na Wingi")
            {
                LoadUmojaWingiImages();
            }
            else if(category=="Kike na Kiume")
            {
                LoadKikeKiumeImages();
            }
            else if (category == "Vihusishi")
            {
                LoadVihusishiImages();
            }
            else if (category == "Vitenzi")
            {
                LoadVitenziImages();
            }
           
        }

        public void ModifyPageUI()
        {
            image2.Visibility = Visibility.Hidden;          
            rightTxtBlock.Visibility = Visibility.Hidden;
            gridSplitter.Visibility = Visibility.Hidden;
            image1.SetValue(Grid.ColumnSpanProperty, 3);
            image1.Stretch = Stretch.Uniform;
            leftTxtBlock.SetValue(Grid.ColumnSpanProperty, 3);
        }

     
    }
}
