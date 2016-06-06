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
using System.Data.SQLite;
using iMasomo_Teacher;

namespace iMasomo
{
    /// <summary>
    /// Interaction logic for CreationCenter.xaml
    /// </summary>
    public partial class CreationCenter : Page
    {
        string fileName = Environment.CurrentDirectory + @"\myImage.bin";
        private static Random random = new Random();
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
                case "Kuchora!":
                    this.myInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
                    break;
                case "Kufuta!":
                    this.myInkCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;
                case "Kuchagua!":
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

            }

            //save as .jpg
            MemoryStream ms = new MemoryStream();
            string file = Environment.CurrentDirectory + @"\Michoro\" + GetRandomFileName() + ".jpg";
            using (FileStream fs = new FileStream(file, FileMode.Create))
            {
                RenderTargetBitmap rtb = new RenderTargetBitmap(797, 572, 96d, 96d, PixelFormats.Default);
                rtb.Render(myInkCanvas);
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(rtb));
                encoder.Save(fs);
                SavetoDatabase(file);

            }
        }

        private void SavetoDatabase(string path)
        {
            string query = "insert into michoro(path) values ('"+path+"')";
            try
            {
                SQLiteCommand sqliteCommand = new SQLiteCommand(query, Database.GetDatabaseConnection());
                if (sqliteCommand.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Vizuri!","iMasomo",MessageBoxButton.OK,MessageBoxImage.Information);
                    
                }
                else
                {
                    MessageBox.Show("Jaribu Tena","iMasomo",MessageBoxButton.OK,MessageBoxImage.Exclamation);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string GetRandomFileName()
        {
            string[] alphanumeric = { "a", "b","c","d","e","f","g","h","i","j","k","l",
                                 "m","n","o","p","q","r","s","t","u","v","w","x","y","z","0","1",
                                    "2","3","4","5","6","7","8","9"};
            string randomString="Mchoro_";
            for(int i=0;i<5;i++)
            {
                randomString += alphanumeric[random.Next(0, 35)];
            }
            return randomString;
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
