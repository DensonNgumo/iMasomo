﻿using System;
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

        private void menuTileList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedTile = menuTileList.SelectedItem as Tile;
            Frame myFrame = new Frame();
            AlfabetiPage alfabetiPage = new AlfabetiPage();
            SilabiPage silabiPage = new SilabiPage();


            switch (selectedTile.Name)
            {
                case "alfabetiTile":
                    myFrame.Content = alfabetiPage;
                    break;
                case "silabiTile":
                    myFrame.Content = silabiPage;
                    break;
                

            }
            kusikilizaPage.Content = myFrame;
        }

       

       
    }
}
