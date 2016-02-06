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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace iMasomo
{
    /// <summary>
    /// Interaction logic for MediaPlayer.xaml
    /// </summary>
    public partial class MediaPlayer : Window
    {
        DispatcherTimer timer;

        public MediaPlayer()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += timer_Tick;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            seek_slider.Value = myMediaElement.Position.TotalSeconds;
        }

        private void playBtn_Click(object sender, RoutedEventArgs e)
        {
            myMediaElement.Play();
        }

        private void pauseBtn_Click(object sender, RoutedEventArgs e)
        {
            myMediaElement.Pause();
        }

        private void stopBtn_Click(object sender, RoutedEventArgs e)
        {
            myMediaElement.Stop();
        }

        private void vol_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            myMediaElement.Volume = (double)vol_slider.Value;
        }

        private void seek_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            myMediaElement.Position = TimeSpan.FromSeconds(seek_slider.Value);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string fileName = @"C:\Users\Davinci\Downloads\Video\KICD_Sehemu_ya_mwili.mp4";
            myMediaElement.Source = new Uri(fileName,UriKind.RelativeOrAbsolute);
            myMediaElement.LoadedBehavior = MediaState.Manual;
            myMediaElement.UnloadedBehavior = MediaState.Manual;

            myMediaElement.Volume = (double)vol_slider.Value;
            myMediaElement.Play();
        }

        private void myMediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            TimeSpan ts = myMediaElement.NaturalDuration.TimeSpan;
            seek_slider.Maximum = ts.TotalSeconds;
            timer.Start();
        }
    }
}
