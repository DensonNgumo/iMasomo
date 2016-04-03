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
using System.Windows.Navigation;
using System.IO;
using System.Data.SQLite;
using iMasomo;

namespace iMasomo_Teacher
{
    /// <summary>
    /// Interaction logic for AddMusicVideos.xaml
    /// </summary>
    public partial class AddMusicVideos : Page
    {
        private string videoFile;
        private string newPath;
        private string ext;
        public AddMusicVideos()
        {
            InitializeComponent();
        }

        private void browseBtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Video Files(*.mp4;*.mkv;*.wmv;)|*.mp4;*.mkv;*.wmv";
            dialog.DefaultExt = ".mp4";
            Nullable<bool> result = dialog.ShowDialog();

            //get the selected file name and display in a TextBox
            if (result.HasValue)
            {                
                videoFile = dialog.FileName;
                
            }
        }

        private void previewBtn_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrEmpty(videoFile))
            {
                MessageBox.Show("No video has been selected", "iMasomoAdmin", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                iMasomo.MediaPlayer mediaPlayer = new iMasomo.MediaPlayer(videoFile, titleTxtBox.Text);
                mediaPlayer.Show();
            }
            
        }
        private void CopyVideo()
        {
            ext = Path.GetExtension(videoFile);
            newPath = Environment.CurrentDirectory + @"\Media\" + titleTxtBox.Text + ext;
            File.Copy(videoFile, newPath);

        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(videoFile))
            {
                MessageBox.Show("No video has been selected", "iMasomoAdmin", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            if(String.IsNullOrEmpty(titleTxtBox.Text))
            {
                MessageBox.Show("No title has been entered", "iMasomoAdmin", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            else
            {
                CopyVideo();
                string title = titleTxtBox.Text;
                string tag=titleTxtBox.Text + ext;

                string query = "insert into video_details (title,video_tag) values('"+title+"','"+tag+"')";
                try
                {
                    SQLiteCommand sqliteComm = new SQLiteCommand(query, Database.GetDatabaseConnection());
                    if (sqliteComm.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Video added to system", "iMasomoAdmin", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Video not added to system", "iMasomoAdmin", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
                
            }
        }
    }
}
