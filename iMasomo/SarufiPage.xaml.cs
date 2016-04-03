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

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UmojaWingiPage umojaWingiPage = new UmojaWingiPage();
            this.NavigationService.Navigate(umojaWingiPage);
        }
    }
}
