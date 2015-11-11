using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
using System.Windows.Shapes;

namespace iMasomo
{
    /// <summary>
    /// Interaction logic for Vocabularies.xaml
    /// </summary>
    public partial class Vocabularies : Window
    {
        SortedList<String, BitmapImage> imageCollection = new SortedList<string, BitmapImage>();
        string systemImagesPath = Environment.CurrentDirectory;

        private int currImage = 0;
        private int MAXIMAGE = 6;

        public Vocabularies()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //load system images
            imageCollection.Add("cat", new BitmapImage(new Uri(String.Format(@"/Images/cat.jpg"),UriKind.Relative)));
            imageCollection.Add("fish", new BitmapImage(new Uri(String.Format(@"/Images/fish.jpg"), UriKind.Relative)));
            imageCollection.Add("footballer", new BitmapImage(new Uri(String.Format(@"/Images/footballer.jpg"), UriKind.Relative)));
            imageCollection.Add("leaves", new BitmapImage(new Uri(String.Format(@"/Images/leaves.jpg"), UriKind.Relative)));
            imageCollection.Add("pumpkins", new BitmapImage(new Uri(String.Format(@"/Images/pumpkins.jpg"), UriKind.Relative)));
            imageCollection.Add("snow-leopard", new BitmapImage(new Uri(String.Format(@"/Images/snow-leopard.jpg"), UriKind.Relative)));
            imageCollection.Add("tree", new BitmapImage(new Uri(String.Format(@"/Images/tree.jpg"), UriKind.Relative)));
            imageHolder.Source = imageCollection.Values[0];

        }

       

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (--currImage < 0)
                currImage = MAXIMAGE;
            imageHolder.Source = imageCollection.Values[currImage];

        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (++currImage > MAXIMAGE)
                currImage = 0;
            imageHolder.Source = imageCollection.Values[currImage];
        }
    }
}
