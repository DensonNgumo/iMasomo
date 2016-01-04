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
    /// Interaction logic for AlfabetiPage.xaml
    /// </summary>
    public partial class AlfabetiPage : Page
    {
        public AlfabetiPage()
        {
            InitializeComponent();
            this.comboBoxAlfabeti.SelectedIndex = 0;
        }

        private void LoadAlfabeti(object sender, SelectionChangedEventArgs e)
        {
            string alfabeti = (comboBoxAlfabeti.SelectedItem as ComboBoxItem).Content.ToString();
            
           

        }

        private void Label_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            string alphabet = (sender as Label).Content.ToString();
            AlfabetiWindow words = new AlfabetiWindow();
            words.SetAlphabet(alphabet);
            words.Show();

            
        }
    }
}
