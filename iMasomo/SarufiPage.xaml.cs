using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;


namespace iMasomo
{
    /// <summary>
    /// Interaction logic for SarufiPage.xaml
    /// </summary>
    public partial class SarufiPage : Page
    {
        public SarufiPage()
        {
            InitializeComponent();
        }

      

        private void kike_kiumeTxtBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SarufiImages sarufiImages = new SarufiImages();
            sarufiImages.SetCategory("Kike na Kiume");
            sarufiImages.GetMaxImageCount();
            sarufiImages.LoadKikeKiumeImages();
            this.NavigationService.Navigate(sarufiImages);
        }

        private void umoja_wingiTxtBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SarufiImages sarufiImages = new SarufiImages();
            sarufiImages.SetCategory("Umoja na Wingi");
            sarufiImages.GetMaxImageCount();
            sarufiImages.LoadUmojaWingiImages();
            this.NavigationService.Navigate(sarufiImages);
        }

        private void vihusishiTxtBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SarufiImages sarufiImages = new SarufiImages();
            sarufiImages.SetCategory("Vihusishi");
            sarufiImages.GetMaxImageCount();
            sarufiImages.ModifyPageUI();
            sarufiImages.LoadVihusishiImages();
            this.NavigationService.Navigate(sarufiImages);
        }

        private void vitenziTxtBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SarufiImages sarufiImages = new SarufiImages();
            sarufiImages.SetCategory("Vitenzi");
            sarufiImages.GetMaxImageCount();
            sarufiImages.ModifyPageUI();
            sarufiImages.LoadVitenziImages();
            this.NavigationService.Navigate(sarufiImages);
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
