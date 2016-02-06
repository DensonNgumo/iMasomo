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
    public partial class KusikilizaPage : Page
    {
               

        public KusikilizaPage()
        {
            InitializeComponent();
                               
        }

       

        private void alfabetiTile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AlfabetiPage alfabetiPage = new AlfabetiPage();
            this.NavigationService.Navigate(alfabetiPage);
        }

        private void silabiTile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SilabiPage silabiPage = new SilabiPage();
            this.NavigationService.Navigate(silabiPage);
        }

        private void hadithiTile_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HadithiPage hadithiPage = new HadithiPage();
            this.NavigationService.Navigate(hadithiPage);
        }

       

       
    }
}
