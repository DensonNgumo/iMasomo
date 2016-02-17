using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
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
            string videoTitle = (sender as TextBlock).Tag.ToString(); MessageBox.Show(videoTitle);
            MediaPlayer mediaPlayer = new MediaPlayer(Environment.CurrentDirectory + @"\Media\" + videoTitle);
            mediaPlayer.Show();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Sound.PlayBackgroundMusic();
        }
    }
}
