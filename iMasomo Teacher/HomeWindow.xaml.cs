using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Media;
using iMasomo;


namespace iMasomo_Teacher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
            Database.OpenDatabase();
        }

       

        private void musicPanel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AddMusicVideos addMusicPage = new AddMusicVideos();
            mainFrame.Content = addMusicPage;
        }

        private void addImagesPanel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AddImages addImagesPage = new AddImages();
            mainFrame.Content = addImagesPage;
        }

        private void addWordsPanel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AddWords addWordsPage = new AddWords();
            mainFrame.Content = addWordsPage;
        }

        private void viewPerformancePanel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void addStoriesPanel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AddStories addStories = new AddStories();
            mainFrame.Content = addStories;
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as TextBlock).Foreground = (Brush)(new BrushConverter().ConvertFrom("#880880"));
            (sender as TextBlock).Background = Brushes.BurlyWood;
        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as TextBlock).Foreground = (Brush)(new BrushConverter().ConvertFrom("#000000"));
            (sender as TextBlock).Background = Brushes.Coral;
        }

        private void homeWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Database.CloseDatabase();
        }
    }
}
