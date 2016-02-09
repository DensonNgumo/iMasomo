using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Navigation;
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
            MessageBox.Show(Environment.CurrentDirectory);
            Database.OpenDatabase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(this.Name=="addStories")
            {
                mainFrame.NavigationService.Navigate(new AddImages());
                this.Name = "else";
            }
            else 
            {
                mainFrame.NavigationService.Navigate(new AddWords());
            }
            
        }
    }
}
