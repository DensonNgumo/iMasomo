using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Media.Animation;
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
            
            
           
        }


        private void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Sound.StartBackgroundMusic();
                      
            mainFrame.Navigate(new WelcomePage()); 
            
        }

        private void mainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Sound.Dispose();
            MessageBox.Show("Kwaheri!");
            
        }

       
    }
}
