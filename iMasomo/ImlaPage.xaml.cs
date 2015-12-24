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
    /// Interaction logic for ImlaPage.xaml
    /// </summary>
    public partial class ImlaPage : Page
    {
        public ImlaPage()
        {
            InitializeComponent();
        }

        private void PlaySound(object sender, MouseButtonEventArgs e)
        {
            var uri = new Uri(@"/Media/test.mp3",UriKind.RelativeOrAbsolute);

            var player = new MediaPlayer();

            player.Open(uri);
            player.Play();
        }
    }
}
