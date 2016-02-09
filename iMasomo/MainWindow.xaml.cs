using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using iMasomo_Teacher;



namespace iMasomo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
               
        public MainWindow()
        {
            InitializeComponent();
            Database.OpenDatabase();
            Sound.PlayBackgroundMusic();
           
        }


        private void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new WelcomePage());
        }
    }
}
