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
using System.Data.SQLite;

namespace iMasomo
{
    /// <summary>
    /// Interaction logic for ImlaPage.xaml
    /// </summary>
    public partial class ImlaPage : Page
    {
        SoundPlayer mPlayer = new SoundPlayer();
        private string currDirectoryPath = Environment.CurrentDirectory;
        private string path;
        private string word;
        int count = 0;

        SortedList<string, string> wordInfo = new SortedList<string, string>();

        private SQLiteConnection databaseConn;

        public ImlaPage()
        {
            InitializeComponent();
            Database.OpenDatabase();
            SetDatabaseConnection();
        }


        public void DisposeResources()
        {
            mPlayer.Dispose();
        }

        private void SetDatabaseConnection()
        {
            databaseConn = Database.GetDatabaseConnection();
        }

        private void PlaySound(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(path);
            Uri testPath = new Uri(currDirectoryPath +path, UriKind.RelativeOrAbsolute);
            mPlayer.SoundLocation =testPath.ToString();
            mPlayer.Load();
            mPlayer.Play();
             
        }

        private void LoadManeno(object sender, RoutedEventArgs e)
        {
            string loadManenoQuery = "select word, sound_path from word_details where word_id=3";
            SQLiteCommand sqliteComm = new SQLiteCommand(loadManenoQuery, databaseConn);
            sqliteComm.ExecuteNonQuery();
            SQLiteDataReader dr = sqliteComm.ExecuteReader();
            while (dr.Read())
            {
                wordInfo.Add(dr.GetString(0), dr.GetString(1));

            }
            path = wordInfo.Values[count];
            word = wordInfo.Keys[count];
        }

        private void LoadNextWord()
        {
            count++;
            path = wordInfo.Values[count];
            word = wordInfo.Keys[count];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadNextWord();
        }

        private void Dispose(object sender, RoutedEventArgs e)
        {
            DisposeResources();
        }

       

    }
}
