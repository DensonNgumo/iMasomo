using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Ink;
using System.Windows.Media.Imaging;
using iMasomo_Teacher;

namespace iMasomo
{
    /// <summary>
    /// Interaction logic for CreationCenter.xaml
    /// </summary>
    public partial class CreationCenter : Page
    {
        string fileName = Environment.CurrentDirectory + @"\Resources\myImage.bin";
        public CreationCenter()
        {
            InitializeComponent();
            this.myInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            this.drawRadio.IsChecked = true;
            this.comboColors.SelectedIndex = 0;
        }
        private void RadioButtonClicked(object sender, RoutedEventArgs e)
        {
            switch ((sender as RadioButton).Content.ToString())
            {
                case "Draw Mode!":
                    this.myInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
                    break;
                case "Erase Mode!":
                    this.myInkCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;
                case "Select Mode!":
                    this.myInkCanvas.EditingMode = InkCanvasEditingMode.Select;
                    break;

            }
        }
        private void ColorChanged(object sender, SelectionChangedEventArgs e)
        {
            string colorToUse = (comboColors.SelectedItem as StackPanel).Tag.ToString();
            myInkCanvas.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(colorToUse);
        }
        
        private void Save()
        {
            //save strokes as .bin
            
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                myInkCanvas.Strokes.Save(fs);               
                fs.Close();

            }
        }

        private void Load()
        {
            
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                StrokeCollection strokes = new StrokeCollection(fs);
                myInkCanvas.Strokes = strokes;
            }
        }

        private void Clear()
        {
            myInkCanvas.Strokes.Clear();
        }

        private void SaveData(object sender, RoutedEventArgs e)
        {
            Save();
            
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void ClearData(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Sound.PauseBackgroundMusic();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Sound.PlayBackgroundMusic();
        }
    }
}
