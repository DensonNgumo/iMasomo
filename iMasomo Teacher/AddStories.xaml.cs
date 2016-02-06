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
            title = titleTxtBox.Text;
            CopyFile();
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

        private void CopyFile()
        {
            newPath=Environment.CurrentDirectory+@"\Resources\"+title+".pdf";
            File.Copy(hadithiFilePath, newPath);
        }
    }
}
