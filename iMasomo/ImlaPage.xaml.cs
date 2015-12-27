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
using System.Media;

namespace iMasomo
{
    /// <summary>
    /// Interaction logic for ImlaPage.xaml
    /// </summary>
    public partial class ImlaPage : Page
    {
        SoundPlayer mPlayer = new SoundPlayer();
        string currPath = Environment.CurrentDirectory;
        public ImlaPage()
        {
            InitializeComponent();
        }

        private void PlaySound(object sender, MouseButtonEventArgs e)
        {
            Uri testPath = new Uri(currPath + "/Media/sample.wav",UriKind.RelativeOrAbsolute);
            mPlayer.SoundLocation =testPath.ToString();
                                           
          //  mPlayer.SoundLocation = currPath + @"\Media\sample.wav";
            mPlayer.Load();
            mPlayer.Play();
             
        }
    }
}
