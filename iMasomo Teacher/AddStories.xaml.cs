using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using System.IO;
using System.Data.SQLite;
using iMasomo;


namespace iMasomo_Teacher
{
    /// <summary>
    /// Interaction logic for AddStories.xaml
    /// </summary>
    public partial class AddStories : Page
    {
        private string hadithiFilePath;
        private string title;
        string newPath;
        bool overwrite = false;

        public AddStories()
        {
            InitializeComponent();
            
        }

        private void browseBtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fileDlg = new Microsoft.Win32.OpenFileDialog();
            fileDlg.DefaultExt = ".pdf";
            fileDlg.Filter = "PDF Files(*.pdf)|*.pdf";
            Nullable<bool> result= fileDlg.ShowDialog();
            if(result.HasValue)
            {
                hadithiPath.Text = fileDlg.FileName;
                hadithiFilePath = fileDlg.FileName;
            }
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(titleTxtBox.Text))
            {
                MessageBox.Show("No title has been entered", "iMasomoAdmin", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                titleTxtBox.Focus();
                return;
            }
            if(String.IsNullOrEmpty(hadithiPath.Text))
            {
                MessageBox.Show("No file has been selected", "iMasomoAdmin", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                hadithiPath.Focus();
                return;
            }
            title = titleTxtBox.Text;
            if(DuplicateExists())
            {
                MessageBoxResult result = MessageBox.Show("Story with the same title already exists, do you wish to overwrite?", "iMasomoAdmin", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if(result==MessageBoxResult.No)
                {
                    return;
                }
                if(result==MessageBoxResult.Yes)
                {
                    overwrite = true;
                    CopyFile();
                }

            }
            else
            {
                CopyFile();
                SaveFile();
            }
            
            
        }

        private void SaveFile()
        {
            string query = "insert into hadithi_details(hadithi_title,location_path) values ('" + title + "','" + newPath + "')";
            try
            {
                SQLiteCommand sqliteCommand = new SQLiteCommand(query, Database.GetDatabaseConnection());
                if (sqliteCommand.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Hadithi added to the system");
                }
                else
                {
                    MessageBox.Show("Error:Hadithi not added");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool DuplicateExists()
        {
            string query = "select * from hadithi_details where hadithi_title ='" + title + "' ";
            int count = 0;
            try
            {
                SQLiteCommand sqliteCommand = new SQLiteCommand(query, Database.GetDatabaseConnection());
                sqliteCommand.ExecuteNonQuery();
                SQLiteDataReader reader = sqliteCommand.ExecuteReader();
                while(reader.Read())
                {
                    count++;
                }

                if(count>0)
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

        private void CopyFile()
        {
            string targetPath=Environment.CurrentDirectory+@"\Resources\"+title+".pdf";
            File.Copy(hadithiFilePath, targetPath,overwrite);
            newPath = @"\Resources\" + title + ".pdf";
        }
    }
}
