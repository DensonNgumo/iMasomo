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
using System.Windows.Shapes;
using iMasomo;
using System.Data.SQLite;


namespace iMasomo_Teacher
{
    /// <summary>
    /// Interaction logic for AddImages.xaml
    /// </summary>
    public partial class AddImages : Page
    {
        private SQLiteConnection sqliteConn;
        public AddImages()
        {
            try
            {
                InitializeComponent();
                Database.OpenDatabase();
                SetDatabaseConnection();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void SetDatabaseConnection()
        {
            sqliteConn = Database.GetDatabaseConnection();
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
            categoryComboBox.ItemsSource = list;
        }
        private void browseImagesButton_Click(object sender, RoutedEventArgs e)
        {
            //Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            //set filter for file extension and default file extension
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files(*.jpeg)|*.jpeg|PNG Files(*.png)|*.png|JPG Files (*.jpg)|*.jpg";

            //display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            //get the selected file name and display in a TextBox
            if(result.HasValue)
            {
                //Open document
                string filename = dlg.FileName;
                imagePathTextBox.Text = filename;
            }
    
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadComboBoxElements();
        }

        private void addImageBtn_Click(object sender, RoutedEventArgs e)
        {
            string query="insert into image_details(kiswahili_tag,category,path,image_type) values ('"+kiswahiliTagTxtBox.Text.ToLower()+"','"+categoryComboBox.SelectedItem.ToString().ToLower()+"','"+imagePathTextBox.Text+"','user_defined')";
            try
            {
                SQLiteCommand sqliteCommand = new SQLiteCommand(query, sqliteConn);
                if(sqliteCommand.ExecuteNonQuery()==1)
                {
                    MessageBox.Show("Image added to the system");
                }
                else
                {
                    MessageBox.Show("Error:Image not added");
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
