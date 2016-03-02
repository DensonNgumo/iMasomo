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
using iMasomo_Teacher;

namespace iMasomo
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        
       
        public HomePage()
        {
            InitializeComponent();
           

        }

        private void playButtonSound(object sender,MouseButtonEventArgs e)
        {
            Sound.PlayButtonSound();
        }

        private void creationTile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CreationCenter creationPage = new CreationCenter();
            this.NavigationService.Navigate(creationPage);
        }

        private void mazoeziTile_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void kusikilizaTile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            KusikilizaPage kusikilizaPage = new KusikilizaPage();
            this.NavigationService.Navigate(kusikilizaPage);
        }

        private void msamiatiTile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MsamiatiPage msamiatiMenu = new MsamiatiPage();
            this.NavigationService.Navigate(msamiatiMenu);
        }

        private void imlaTile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ImlaPage imlaPage = new ImlaPage();
            this.NavigationService.Navigate(imlaPage);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
