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
using System.Data.SQLite;
using iMasomo_Teacher;


namespace iMasomo
{
    /// <summary>
    /// Interaction logic for NyimboPage.xaml
    /// </summary>
    public partial class NyimboPage : Page
    {
        public NyimboPage()
        {
            InitializeComponent();
            Sound.PauseBackgroundMusic();
            
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string videoTitle = (sender as TextBlock).Tag.ToString();
            string songName=(sender as TextBlock).Text;

            MediaPlayer mediaPlayer = new MediaPlayer(Environment.CurrentDirectory + @"\Media\" + videoTitle,songName);
            
            mediaPlayer.Show();
                                
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Sound.PlayBackgroundMusic();
        }
        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as TextBlock).Foreground = (Brush)(new BrushConverter().ConvertFrom("#880880"));
            (sender as TextBlock).Background = Brushes.BurlyWood;
        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as TextBlock).Foreground = (Brush)(new BrushConverter().ConvertFrom("#000000"));
            (sender as TextBlock).Background = Brushes.Orange;
        }
        
        public void LoadUserVideos()
        {
            string query = "select video_tag,title from video_details";
            try
            {
                SQLiteCommand sqliteComm = new SQLiteCommand(query, Database.GetDatabaseConnection());
                sqliteComm.ExecuteNonQuery();
                SQLiteDataReader dr = sqliteComm.ExecuteReader();
                while (dr.Read())
                {
                    TextBlock videoEntry = new TextBlock();
                    videoEntry.Text = dr.GetString(1);
                    videoEntry.Tag = dr.GetValue(0);
                    videoEntry.HorizontalAlignment = HorizontalAlignment.Center;
                    contentStackPanel.Children.Add(videoEntry);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadUserVideos();
        }
    }
}
