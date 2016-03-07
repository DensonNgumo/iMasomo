using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using iMasomo_Teacher;
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
            Sound.PauseBackgroundMusic();
            
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

        private void videoBtn_Click(object sender, RoutedEventArgs e)
        {
                    
            MediaPlayer myMediaPlayer = new MediaPlayer(Environment.CurrentDirectory + @"\Media\" + videoBtn.Tag.ToString(),"Vokali na Mwandiko");
            myMediaPlayer.Show();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Sound.PlayBackgroundMusic();
        }
    }
}
