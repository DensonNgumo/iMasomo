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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

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
            
        }

       
        private void OpenMsamiatiImages(object sender, MouseButtonEventArgs e)
        {
            string categoryName = ((Tile)sender).Tag.ToString().ToLower();            
            MsamiatiImages msamiatiWindow = new MsamiatiImages();
            msamiatiWindow.SetCategory(categoryName);
            msamiatiWindow.Show();
             
        }


        private void Tile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Tarakimu tarakimuWindow = new Tarakimu();
            tarakimuWindow.ShowActivated = true;
            tarakimuWindow.Show();
        }

        private void OpenSehemuYaMwili(object sender, MouseButtonEventArgs e)
        {
            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Show();
        }
       
    }
}
