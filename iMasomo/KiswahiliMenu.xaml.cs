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
    public partial class KiswahiliMenu : Page
    {
        public KiswahiliMenu()
        {
            InitializeComponent();
        }

        private void kiswahiliMenuTileList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedTile = kiswahiliMenuTileList.SelectedItem as Tile;
            Frame myFrame = new Frame();
            MsamiatiPage msamiatiMenu = new MsamiatiPage();
            ImlaPage imlaPage = new ImlaPage();
            
            switch (selectedTile.Name)
            {
                case "msamiatiTile":
                   myFrame.Content = msamiatiMenu;
                 //  kiswahiliMenuPage.Content = myFrame;
                    break;
                case "imlaTile":
                    myFrame.Content = imlaPage;
                    
                    break;
               

            }
            kiswahiliMenuPage.Content = myFrame;
           
        }
    }
}
