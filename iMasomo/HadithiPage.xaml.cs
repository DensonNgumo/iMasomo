using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Navigation;
using System.Windows.Input;
using System.Data.SQLite;


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
                hadithiTitle.Cursor = Cursors.Hand;
                hadithiTitle.MouseDown+=hadithiTitle_MouseDown;
                hadithiPanel.Children.Add(hadithiTitle);
            }
            
        }

        private void hadithiTitle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string path = hadithi_details[((TextBlock)sender).Text];
            MessageBox.Show(path);
            PDFViewer myPdfViewer = new PDFViewer();
            myPdfViewer.LoadPDF(path);
            myPdfViewer.Show();
        }
    }
}
