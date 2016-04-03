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
using System.Windows.Threading;
using System.Runtime.InteropServices;

namespace iMasomo
{
    /// <summary>
    /// Interaction logic for MediaPlayer.xaml
    /// </summary>
    public partial class MediaPlayer : Window
    {
        DispatcherTimer timer,doubleClickTimer;

        string filePath;
        string category;
        private bool fullScreen = false;

        public MediaPlayer(string path,string cat)
        {
            try
            {
                InitializeComponent();
                timer = new DispatcherTimer();
                doubleClickTimer = new DispatcherTimer();
                doubleClickTimer.Interval = TimeSpan.FromMilliseconds(GetDoubleClickTime());
                doubleClickTimer.Tick += (s, e) => doubleClickTimer.Stop();
                timer.Interval = TimeSpan.FromMilliseconds(500);
                timer.Tick += timer_Tick;
                filePath = path;
                category = cat;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        void timer_Tick(object sender, EventArgs e)
        {
            seek_slider.Value = myMediaElement.Position.TotalSeconds;
        }

        private void playBtn_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void pauseBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void stopBtn_Click(object sender, RoutedEventArgs e)
        {
           
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
            this.Title = category;
            myMediaElement.Source = new Uri(filePath,UriKind.RelativeOrAbsolute);
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

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            myMediaElement.Stop();
            
        }

        private void myMediaElement_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(!doubleClickTimer.IsEnabled)
            {
                doubleClickTimer.Start();
            }
            else
            {
                if(!fullScreen)
                {
                    mainGrid.Children.Remove(play);
                    mainGrid.Children.Remove(pause);
                    mainGrid.Children.Remove(stop);
                    mainGrid.Children.Remove(seek_slider);
                    mainGrid.Children.Remove(vol_slider);
                    this.WindowStyle = WindowStyle.None;
                    this.WindowState = WindowState.Maximized;
                    myMediaElement.SetValue(Grid.RowSpanProperty, 2);
                    
                }
                else
                {
                    this.WindowStyle = WindowStyle.SingleBorderWindow;
                    this.WindowState = WindowState.Normal;
                    mainGrid.Children.Add(play);
                    mainGrid.Children.Add(pause);
                    mainGrid.Children.Add(stop);
                    mainGrid.Children.Add(seek_slider);
                    mainGrid.Children.Add(vol_slider);
                    myMediaElement.SetValue(Grid.RowSpanProperty, 1);
                }
                fullScreen = !fullScreen;
            }
        }
        [DllImport("user32.dll")]
        private static extern uint GetDoubleClickTime();

        private void play_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            myMediaElement.Play();
        }

        private void pause_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            myMediaElement.Pause();
        }

        private void stop_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            myMediaElement.Stop();
        }

       
    }
}
