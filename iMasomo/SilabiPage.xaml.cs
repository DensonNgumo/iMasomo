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
    /// Interaction logic for SilabiPage.xaml
    /// </summary>
    public partial class SilabiPage : Page
    {
        string[] irabu = { "a", "e", "i", "o", "u" };
        string[] silabi = new string[5];
        public SilabiPage()
        {
            InitializeComponent();
        }

        private void alfabetiComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            silabiTextBlock.Text = "";
            string alfabeti = (alfabetiComboBox.SelectedItem as ComboBoxItem).Content.ToString();
            for(int i=0;i<5;i++)
            {
                silabi[i] = alfabeti + irabu[i];
            }
            for(int i=0;i<5;i++)
            {
                silabiTextBlock.Text += silabi[i] + ",";
                silabiTextBlock.Margin = new Thickness(0, 25, 0, 0);
            }
        }
    }
}
