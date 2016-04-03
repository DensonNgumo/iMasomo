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
using System.Data.SQLite;
using iMasomo_Teacher;

namespace iMasomo
{
    /// <summary>
    /// Interaction logic for HadithiPage.xaml
    /// </summary>
    public partial class HadithiPage : Page
    {
        SortedList<string, string> hadithi_details = new SortedList<string, string>();
        public HadithiPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadHadithi();
            Sound.PauseBackgroundMusic();
        }

        private void LoadHadithi()
        {
            string query = "select hadithi_title,location_path from hadithi_details";
            SQLiteCommand sqliteComm = new SQLiteCommand(query, Database.GetDatabaseConnection());
            sqliteComm.ExecuteNonQuery();
            SQLiteDataReader dr = sqliteComm.ExecuteReader();
            while(dr.Read())
            {
                hadithi_details.Add(dr.GetString(0), dr.GetString(1));
                TextBlock hadithiTitle = new TextBlock();
                hadithiTitle.Text = dr.GetString(0);
                hadithiTitle.MouseDown+=hadithiTitle_MouseDown;
                hadithiTitle.Style = (Style)mainGrid.FindResource("titleStyle");
                hadithiPanel.Children.Add(hadithiTitle);
            }
            
        }

        private void hadithiTitle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Sound.PlayButtonSound();
            string title = ((TextBlock)sender).Text.ToUpper();
            string path = Environment.CurrentDirectory+hadithi_details[((TextBlock)sender).Text];
            PDFViewer myPdfViewer = new PDFViewer(title);
            myPdfViewer.LoadPDF(path);
            myPdfViewer.Show();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Sound.PlayBackgroundMusic();
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as TextBlock).Foreground = (Brush)(new BrushConverter().ConvertFrom("#880880"));
            (sender as TextBlock).Background = Brushes.BurlyWood;
        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as TextBlock).Foreground = (Brush)(new BrushConverter().ConvertFrom("#000000"));
            (sender as TextBlock).Background = Brushes.Orange;
        }
    }
}
