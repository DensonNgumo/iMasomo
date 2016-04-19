using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;



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
    }
}
