using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using iMasomo_Teacher;


namespace iMasomo
{
    /// <summary>
    /// Interaction logic for SilabiPage.xaml
    /// </summary>
    public partial class SilabiPage : Page
    {
        string[] irabu = { "A", "E", "I", "O", "U" };
        string[] silabi = new string[5];
        string soundPath;
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
                silabi[i] = alfabeti.ToUpper() + irabu[i];
            }
            for(int i=0;i<5;i++)
            {
                silabiTextBlock.Text += silabi[i] + ",";
                silabiTextBlock.Margin = new Thickness(0, 25, 0, 0);
            }
            soundPath = string.Format("/Media/{0}.mp3", alfabeti+"Silabi");
            Sound.PlaySound(soundPath);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Sound.PauseBackgroundMusic();
        }
    }
}
