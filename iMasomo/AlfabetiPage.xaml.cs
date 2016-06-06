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

        private void silabiBtn_Click(object sender, RoutedEventArgs e)
        {
            SilabiPage silabiPage = new SilabiPage();
            this.NavigationService.Navigate(silabiPage);
        }

        private void lblB_MouseEnter(object sender, MouseEventArgs e)
        {
            Sound.PlaySound(@"\Media\b.mp3");
        }

        private void lblCh_MouseEnter(object sender, MouseEventArgs e)
        {
            Sound.PlaySound(@"\Media\ch.mp3");
        }

        private void lblDh_MouseEnter(object sender, MouseEventArgs e)
        {
            Sound.PlaySound(@"\Media\dh.mp3");
        }

        private void lblE_MouseEnter(object sender, MouseEventArgs e)
        {
            Sound.PlaySound(@"\Media\e.mp3");
        }

        private void lblGh_MouseEnter(object sender, MouseEventArgs e)
        {
            Sound.PlaySound(@"\Media\gh.mp3");
        }

        private void lblH_MouseEnter(object sender, MouseEventArgs e)
        {
            Sound.PlaySound(@"\Media\h.mp3");
        }

        private void lblJ_MouseEnter(object sender, MouseEventArgs e)
        {
            Sound.PlaySound(@"\Media\j.mp3");
        }

        private void lblP_MouseEnter(object sender, MouseEventArgs e)
        {
            Sound.PlaySound(@"\Media\p.mp3");
        }

        private void lblU_MouseEnter(object sender, MouseEventArgs e)
        {
            Sound.PlaySound(@"\Media\u.mp3");
        }

        private void lblA_MouseEnter(object sender, MouseEventArgs e)
        {
            Sound.PlaySound(@"\Media\a.mp3");
        }
    }
}
