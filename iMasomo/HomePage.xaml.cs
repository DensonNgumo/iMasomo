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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        CreationCenter creationPage = null;
        MsamiatiPage msamiatiMenu = null;
        ImlaPage imlaPage = null;
        KusikilizaPage kusikilizaPage = null;
        public HomePage()
        {
            InitializeComponent();
            creationPage = new CreationCenter();
            msamiatiMenu = new MsamiatiPage();
            imlaPage = new ImlaPage();
            kusikilizaPage = new KusikilizaPage();
        }

        private void creationTile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(creationPage);
        }

        private void mazoeziTile_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void kusikilizaTile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(kusikilizaPage);
        }

        private void msamiatiTile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(msamiatiMenu);
        }

        private void imlaTile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(imlaPage);
        }
    }
}
