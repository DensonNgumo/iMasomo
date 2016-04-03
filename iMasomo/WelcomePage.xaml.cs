using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using iMasomo_Teacher;

namespace iMasomo
{
    /// <summary>
    /// Interaction logic for WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        
        public WelcomePage()
        {
            InitializeComponent();
                               
        }

        private void Endelea()
        {
            Sound.PlayButtonSound();
            this.NavigationService.Navigate(new HomePage());
        }
        private void endeleaBtn_Click(object sender, RoutedEventArgs e)
        {
            Endelea();
           
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.PreviewKeyDown += KeyPressed;
        }

        private void KeyPressed(object sender, KeyEventArgs e)
        {
            MessageBox.Show("pressed");
            if(e.Key==Key.Enter)
            {
                MessageBox.Show("pressed");
                Endelea();
            }
            
        }

      

 
    }
}
