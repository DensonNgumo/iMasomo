using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void menuTileList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedTile = menuTileList.SelectedItem as Tile;
           // MessageBox.Show(selectedTile.Name);
            Frame myFrame= new Frame();
            EnglishMenu englishMenu= new EnglishMenu();
            KiswahiliMenu kiswahiliMenu = new KiswahiliMenu();
            switch(selectedTile.Name)
            {
                case "englishTile":
                    myFrame.Content = englishMenu;
                    mainWindow.Content = myFrame;
                    break;
                case "kiswahiliTile":
                    myFrame.Content = kiswahiliMenu;
                    mainWindow.Content = myFrame;
                    break;
            }
        }
    }
}
