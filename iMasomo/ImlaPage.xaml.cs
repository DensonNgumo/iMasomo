using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Media;
using System.Data.SQLite;
using iMasomo_Teacher;



namespace iMasomo
{
    /// <summary>
    /// Interaction logic for ImlaPage.xaml
    /// </summary>
    public partial class ImlaPage : Page
    {
        
        private string currDirectoryPath = Environment.CurrentDirectory;
        private string path;
        private string neno;
        int count = 0;
        
        bool isGrowing = false;

        SortedList<string, string> wordInfo = new SortedList<string, string>();
        

        public ImlaPage()
        {
            InitializeComponent();
      
        }


        

        public void ShowPageElements()
        {
            
            endeleaBtn.Visibility = Visibility.Visible;
            inputStackPanel.Visibility = Visibility.Visible;
            jibuBtn.Visibility = Visibility.Visible;
        }

        public void HidePageElements()
        {
            onyeshaJibuBtn.Visibility = Visibility.Hidden;
            endeleaBtn.Visibility = Visibility.Hidden;
            inputStackPanel.Visibility = Visibility.Hidden;
            jibuBtn.Visibility = Visibility.Hidden;
            jawabuTxtBlock.Visibility = Visibility.Hidden;
        }

        public void RefreshPageElements()
        {
            HidePageElements();
            jibuTxt.Clear();
        }

 

        private void PlaySound()
        {
            
            Sound.PlaySound(path);
             
        }

        private void LoadManeno()
        {
            
            string loadManenoQuery = "select word, sound_path from word_details where category='imla'";
            SQLiteCommand sqliteComm = new SQLiteCommand(loadManenoQuery, Database.GetDatabaseConnection());
            sqliteComm.ExecuteNonQuery();
            SQLiteDataReader dr = sqliteComm.ExecuteReader();
            while (dr.Read())
            {
                wordInfo.Add(dr.GetString(0), dr.GetString(1));

            }
            wordInfo.Reverse();
            path = wordInfo.Values[count];
            neno = wordInfo.Keys[count];
        }

        private int  GetTotalNumberOfWords()
        {
            string loadManenoQuery = "select count(*) from word_details where category='imla'";
            SQLiteCommand sqliteComm = new SQLiteCommand(loadManenoQuery, Database.GetDatabaseConnection());
            sqliteComm.ExecuteNonQuery();
            SQLiteDataReader dr = sqliteComm.ExecuteReader();
            int no = 0;
            while (dr.Read())
            {
                var value = dr.GetValue(0);
                no = int.Parse(value.ToString());

            }
            return no;
        }
        private void LoadNextWord()
        {
            int totalNumberOfWords = GetTotalNumberOfWords();
            if(++count>=totalNumberOfWords)
            {
                count = 0;
            }
            //count++;
            path = wordInfo.Values[count];
            neno = wordInfo.Keys[count];
        }

      
       

        private void anzaTxtBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlaySound();
            anzaTxtBlock.Visibility = Visibility.Hidden;
            ShowPageElements();
        }

        private void Image_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PlaySound();
        }

        private void jibuBtn_Click(object sender, RoutedEventArgs e)
        {
            
            //validation
            if(String.IsNullOrEmpty(jibuTxt.Text)||jibuTxt.Text.Any(c=>Char.IsNumber(c)))
            {
                MessageBox.Show("Andika neno");
                jibuTxt.Focus();
                return;
            }
            //if jibu is correct
            if(jibuTxt.Text.ToLower()==neno)
            {
                Sound.PlaySound(@"\Media\Hongera.mp3");
                MessageBox.Show("Hongera!");
                jawabuTxtBlock.Visibility = Visibility.Hidden;
                onyeshaJibuBtn.Visibility = Visibility.Hidden;
                LoadNextWord();
                PlaySound();
             
            }
            else
            {
                //jibu is wrong
                MessageBox.Show("La Hasha! Jaribu Tena.");
                onyeshaJibuBtn.Visibility = Visibility.Visible;
            }

        }

        private void endeleaBtn_Click(object sender, RoutedEventArgs e)
        {
            jawabuTxtBlock.Visibility = Visibility.Hidden;
            onyeshaJibuBtn.Visibility = Visibility.Hidden;
            LoadNextWord();
            PlaySound();

        }

        private void onyeshaJibuBtn_Click(object sender, RoutedEventArgs e)
        {
            jawabuTxtBlock.Text = neno;
            jawabuTxtBlock.Visibility = Visibility.Visible;
            (sender as Button).Visibility = Visibility.Hidden;
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            wordInfo.Clear();
            RefreshPageElements();
            Sound.PlayBackgroundMusic();
           
        }

        private void imlaPage_Loaded(object sender, RoutedEventArgs e)
        {
            
            LoadManeno();
            HidePageElements();
            anzaTxtBlock.Visibility = Visibility.Visible;
            Sound.PauseBackgroundMusic();
                      
        }

        private void anzaTxtBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            if(!isGrowing)
            {
                isGrowing = true;

                //DoubleAnimation object registered with the Completed event
                DoubleAnimation dblAnim = new DoubleAnimation();
                dblAnim.Completed += (o, s) => { isGrowing = false; };

                dblAnim.From = 0;
                dblAnim.To = 30;

                anzaTxtBlock.BeginAnimation(FontSizeProperty, dblAnim);
            }
        }

        private void jibuTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            //input validation
            jibuTxt.Text = string.Concat(jibuTxt.Text.Where(char.IsLetter));
        }

       

    }
}
