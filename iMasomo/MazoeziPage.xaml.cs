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

namespace iMasomo
{
    /// <summary>
    /// Interaction logic for MazoeziPage.xaml
    /// </summary>
    public partial class MazoeziPage : Page
    {
        public MazoeziPage()
        {
            InitializeComponent();
        }

        private void zoeziATxtBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ZoeziTemplate zoeziA = new ZoeziTemplate();
            zoeziA.SetZoeziAContent();
            this.NavigationService.Navigate(zoeziA);
        }

        private void zoeziBTxtBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ZoeziTemplate zoeziB = new ZoeziTemplate();
            zoeziB.SetZoeziBContent();
            this.NavigationService.Navigate(zoeziB);
        }

        private void zoeziCTxtBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ZoeziTemplate zoeziC = new ZoeziTemplate();
            zoeziC.SetZoeziC_Content();
            this.NavigationService.Navigate(zoeziC);
        }

        private void zoeziDiTxtBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ZoeziTemplate zoeziD = new ZoeziTemplate();
            zoeziD.SetZoeziDContent();
            this.NavigationService.Navigate(zoeziD);
        }
        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as TextBlock).Foreground = (Brush)(new BrushConverter().ConvertFrom("#880880"));
            (sender as TextBlock).Background = Brushes.BurlyWood;
        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as TextBlock).Foreground = (Brush)(new BrushConverter().ConvertFrom("#000000"));
            (sender as TextBlock).Background = Brushes.Orange;
        }
    }
}
