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
using System.Text.RegularExpressions;
using iMasomo;
namespace iMasomo_Teacher
{
    /// <summary>
    /// Interaction logic for AddSarufiContent.xaml
    /// </summary>
    public partial class AddSarufiContent : Page
    {
        string category, maelezo,title;
        int imageID = 0,selectedImageID=0;
        private ObservableCollection<SarufiImage> images = new ObservableCollection<SarufiImage>();
        public AddSarufiContent()
        {
            InitializeComponent();
            List<string> categories = new List<string>();
            categories.Add("Vitenzi");
            categories.Add("Vihusishi");
            categoryComboBox.ItemsSource = categories;
            imageComboBox.SelectedIndex = 0;
            categoryComboBox.SelectedIndex = 0;
            category = categoryComboBox.SelectedValue.ToString().ToLower();
            LoadComboboxItems();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
           
            
        }

        private void LoadComboboxItems()
        {
            string query = "select image_id,kiswahili_tag from image_details where image_type='user_defined'";
            try
            {
                SQLiteCommand sqliteCommand = new SQLiteCommand(query, Database.GetDatabaseConnection());
                sqliteCommand.ExecuteNonQuery();
                SQLiteDataReader reader = sqliteCommand.ExecuteReader();
                while (reader.Read())
                {
                    var value = reader.GetValue(0);
                    imageID = int.Parse(value.ToString());
                    title = reader.GetString(1);
                    images.Add(new SarufiImage() { Title = title, ID = imageID });
                }
                imageComboBox.DataContext = images;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void imageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (sender as ComboBox).SelectedValue;
            selectedImageID = ((SarufiImage)item).ID; 
            string path = GetImagePath(selectedImageID);
            image.Source = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
        }
        public string GetImagePath(int id)
        {
            string path = "/Resources/iMasomoAdmin.png";
            string query = "select path from image_details where image_id='"+id+"'";
            try
            {
                SQLiteCommand sqliteCommand = new SQLiteCommand(query, Database.GetDatabaseConnection());
                sqliteCommand.ExecuteNonQuery();
                SQLiteDataReader reader = sqliteCommand.ExecuteReader();
                while (reader.Read())
                {
                    path =reader.GetString(0);
                }
                return path;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return path;
        }

        private bool DuplicateExists()
        {
            string query = "select * from '"+category+"' where image_id ='" + selectedImageID + "' ";
            int count = 0;
            try
            {
                SQLiteCommand sqliteCommand = new SQLiteCommand(query, Database.GetDatabaseConnection());
                sqliteCommand.ExecuteNonQuery();
                SQLiteDataReader reader = sqliteCommand.ExecuteReader();
                while (reader.Read())
                {
                    count++;
                }

                if (count > 0)
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return false;
        }

        private void categoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            category = ((ComboBox)sender).SelectedValue.ToString().ToLower();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrEmpty(maelezoTxtBox.Text))
            {
                MessageBox.Show("No information entered in the 'Maelezo' text box", "iMasomAdmin", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                maelezoTxtBox.Focus();
                return;
            }
            if(DuplicateExists())
            {
                MessageBoxResult result = MessageBox.Show("The image has already been used in the chosen category, do you wish to overwrite?", "iMasomoAdmin", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (result == MessageBoxResult.No)
                {
                    return;
                }
                if (result == MessageBoxResult.Yes)
                {
                    EditInfo();
                }
            }
            else
            {
                maelezo = maelezoTxtBox.Text;
                SaveInfo();
            }
        } 

        private void EditInfo()
        {
            string query = "update '"+category+"' set maelezo ='" + maelezoTxtBox.Text + "' where image_id ='" + selectedImageID + "' ";
            try
            {
                SQLiteCommand sqliteComm = new SQLiteCommand(query, Database.GetDatabaseConnection());
                if (sqliteComm.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("The information has been updated","iMasomo",MessageBoxButton.OK,MessageBoxImage.Information);
                    
                }
                else
                {
                    MessageBox.Show("Error:Information not updated");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void SaveInfo()
        {
            string query = "insert into '"+category+"'(image_id,maelezo) values ('" + selectedImageID + "','" + maelezo + "')";
            try
            {
                SQLiteCommand sqliteCommand = new SQLiteCommand(query, Database.GetDatabaseConnection());
                if (sqliteCommand.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Content Added","iMasomoAdmin",MessageBoxButton.OK,MessageBoxImage.Information);
                    
                }
                else
                {
                    MessageBox.Show("Error:Content not added. Try Again","iMasomoAdmin",MessageBoxButton.OK,MessageBoxImage.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void maelezoTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var txtBoxSender = (TextBox)sender;
            var cursorPosition = txtBoxSender.SelectionStart;
            txtBoxSender.Text = Regex.Replace(txtBoxSender.Text, "[^a-zA-Z0-9., ]","");
            txtBoxSender.SelectionStart = cursorPosition;
        }
    }

    public class SarufiImage
    {
        public string Title { get; set; }
        public int ID { get; set; }

    }
}
