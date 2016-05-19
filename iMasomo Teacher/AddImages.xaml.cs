using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.IO;
using iMasomo;
using System.Data.SQLite;



namespace iMasomo_Teacher
{
    /// <summary>
    /// Interaction logic for AddImages.xaml
    /// </summary>
    public partial class AddImages : Page
    {
        string newImagePath;
        string fileName;
        bool overwrite = false;

        public AddImages()
        {
            InitializeComponent();
        
        }

        private void LoadComboBoxElements()
        {
            ObservableCollection<string> list = new ObservableCollection<string>();
            list.Add("Wanyama na Ndege");
            list.Add("Sehemu za Mwili");
            list.Add("Nyumbani");
            list.Add("Darasani");
            list.Add("Shuleni");
            list.Add("Dunai");
            list.Add("Sokoni");
            list.Add("Mavazi");
            list.Add("Vyakula");
            list.Add("Afya na usafi");
            list.Add("Maumbo");
            list.Add("Angani");
            list.Add("Maswala ya Ibuka");
            list.Add("Umoja na Wingi");
            list.Add("Vihusishi");
            list.Add("Kike na Kiume");
            list.Add("Vitenzi");
            categoryComboBox.ItemsSource = list;
            categoryComboBox.SelectedIndex = 0;
        }
        private void browseImagesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Create OpenFileDialog
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

                //set filter for file extension and default file extension
                dlg.DefaultExt = ".png";
                dlg.Filter = "IMAGE Files(*.jpeg;*.jpg;*.png)|*.jpeg;*.jpg;*.png";

                //display OpenFileDialog by calling ShowDialog method
                Nullable<bool> result = dlg.ShowDialog();

                //get the selected file name and display in a TextBox
                if (result.HasValue)
                {
                    //Open document
                    fileName = dlg.FileName;
                    imagePathTextBox.Text = fileName;
                    imagePathTextBox.Text = imagePathTextBox.Text.Replace("'", "''");
                   
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
    
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadComboBoxElements();
        }

        private void CopyImage()
        {
            string ext = Path.GetExtension(fileName);
            kiswahiliTagTxtBox.Text = kiswahiliTagTxtBox.Text.Replace("'", "''");//To enable the text with an apostrophe to be added to the database
            newImagePath=Environment.CurrentDirectory + @"\Images\" + kiswahiliTagTxtBox.Text + ext;
            File.Copy(fileName,newImagePath,overwrite);
            
        }

        private void addImageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(kiswahiliTagTxtBox.Text))
            {
                MessageBox.Show("No title has been entered", "iMasomoAdmin", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                kiswahiliTagTxtBox.Focus();
                return;
            }
            if (String.IsNullOrEmpty(imagePathTextBox.Text))
            {
                MessageBox.Show("No image has been selected", "iMasomoAdmin", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                imagePathTextBox.Focus();
                return;
            }
            if(DuplicateExists())
            {
                MessageBoxResult result = MessageBox.Show("Image with the same title and in the same category already exists, do you wish to overwrite?", "iMasomoAdmin", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (result == MessageBoxResult.No)
                {
                    return;
                }
                if (result == MessageBoxResult.Yes)
                {
                    overwrite = true;
                    CopyImage();
                }
            }
            else
            {
                CopyImage();
                SaveImage();
            }
            
           
            
        }

        private bool DuplicateExists()
        {
            
            string query = "select * from image_details where kiswahili_tag ='" + kiswahiliTagTxtBox.Text + "' and category='"+categoryComboBox.SelectedItem.ToString().ToLower()+"' ";
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

        private void SaveImage()
        {
            try
            {

                string query = "insert into image_details(kiswahili_tag,category,path,image_type,utangulizi) values ('" + kiswahiliTagTxtBox.Text.ToLower() + "','" + categoryComboBox.SelectedItem.ToString().ToLower() + "','" + newImagePath + "','user_defined','" + utanguliziTxtBox.Text + "')";
                SQLiteCommand sqliteCommand = new SQLiteCommand(query, Database.GetDatabaseConnection());
                if (sqliteCommand.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Image added to the system","iMasomoAdmin",MessageBoxButton.OK,MessageBoxImage.Information);
                    ClearText();
                }
                else
                {
                    MessageBox.Show("Error:Image not added","iMasomoAdmin",MessageBoxButton.OK,MessageBoxImage.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearText()
        {
            kiswahiliTagTxtBox.Clear();
            imagePathTextBox.Clear();
            categoryComboBox.SelectedIndex = -1;
        }

    }
}
