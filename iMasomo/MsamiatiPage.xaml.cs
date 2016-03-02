using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Telerik.Windows.Controls;
using iMasomo_Teacher;

namespace iMasomo
{
    /// <summary>
    /// Interaction logic for KiswahiliMenu.xaml
    /// </summary>
    public partial class MsamiatiPage : Page
    {
        public MsamiatiPage()
        {
            InitializeComponent();
            Sound.PauseBackgroundMusic();
            
        }

       
        private void OpenMsamiatiImages(object sender, MouseButtonEventArgs e)
        {
            Sound.PlayButtonSound();
            string categoryName = ((Tile)sender).Tag.ToString().ToLower();            
            MsamiatiImages msamiatiWindow = new MsamiatiImages();
            msamiatiWindow.SetCategory(categoryName);
            msamiatiWindow.Show();
             
        }


        private void Tile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Sound.PlayButtonSound();
            Tarakimu tarakimuWindow = new Tarakimu();
            tarakimuWindow.ShowActivated = true;
            tarakimuWindow.Show();
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Sound.PauseBackgroundMusic();
        }
       
    }
}
