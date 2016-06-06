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
using System.Windows.Media.Imaging;
using System.Text.RegularExpressions;
using System.Data.SQLite;
using iMasomo_Teacher;

namespace iMasomo
{
    /// <summary>
    /// Interaction logic for ZoeziTemplate.xaml
    /// </summary>
    public partial class ZoeziTemplate : Page
    {
        string question;
        string category;
        public ZoeziTemplate()
        {
            InitializeComponent();
            
        }
        public void SetZoeziAContent()
        {
            category = "Tarakimu";
            question = "Andika majina ya nambari yafuatayo:";
            questionTxtBlock.Text = question;
            int no1=0,no2=0,no3=0,no4=0;
            no1=Tarakimu.GetRandomNumber();
            no2=Tarakimu.GetRandomNumber();
            no3=Tarakimu.GetRandomNumber();
            no4=Tarakimu.GetRandomNumber();
            qn1TxtBlock.Text += no1.ToString();
            qn1TxtBlock.Tag = no1;
            qn2TxtBlock.Text += no2.ToString();
            qn2TxtBlock.Tag = no2;
            qn3TxtBlock.Text += no3.ToString();
            qn3TxtBlock.Tag = no3;
            qn4TxtBlock.Text += no4.ToString();
            qn4TxtBlock.Tag = no4;
        }

        public void SetZoeziBContent()
        {
            category = "Kuongea";
            question = "Andika majibu ya salamu haya:";
            questionTxtBlock.Text = question;
            int count = 0;
            string[] questions= new string[5];
            string[] answers = new string[5];
            string query = "select salamu,jibu from salamu_info";
            try
            {
                SQLiteCommand sqliteCommand = new SQLiteCommand(query, Database.GetDatabaseConnection());
                sqliteCommand.ExecuteNonQuery();
                SQLiteDataReader reader = sqliteCommand.ExecuteReader();
                while (reader.Read() && count < 4)
                {
                    questions[count + 1] = reader.GetString(0);
                    answers[count + 1] = reader.GetString(1).ToLower();
                    count++;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
           
            qn1TxtBlock.Text += questions[1];
            qn1TxtBlock.Tag = answers[1];
            qn2TxtBlock.Text += questions[2];
            qn2TxtBlock.Tag = answers[2];
            qn3TxtBlock.Text += questions[3];
            qn3TxtBlock.Tag = answers[3];
            qn4TxtBlock.Text += questions[4];
            qn4TxtBlock.Tag = answers[4];
        }

        public void SetZoeziC_Content()
        {
            category = "UmojaWingi";
            question = "Andika wingi wa maneno haya:";
            questionTxtBlock.Text = question;
            int count = 0;
            string[] questions = new string[5];
            string[] answers = new string[5];
            string query = "select umoja_image_id,wingi_image_id from umoja_wingi";
            try
            {
                SQLiteCommand sqliteCommand = new SQLiteCommand(query, Database.GetDatabaseConnection());
                sqliteCommand.ExecuteNonQuery();
                SQLiteDataReader reader = sqliteCommand.ExecuteReader();
                while (reader.Read() && count < 4)
                {
                    string query2="select kiswahili_tag from image_details where image_id='"+reader.GetValue(0)+"'";
                    string query3 = "select kiswahili_tag from image_details where image_id='" + reader.GetValue(1) + "'";
                    SQLiteCommand sqliteCommand2 = new SQLiteCommand(query2, Database.GetDatabaseConnection());
                    sqliteCommand2.ExecuteNonQuery();
                    SQLiteDataReader reader2 = sqliteCommand2.ExecuteReader();
                    while (reader2.Read())
                    {
                        questions[count + 1] = reader2.GetString(0);
                        
                    }
                    SQLiteCommand sqliteCommand3 = new SQLiteCommand(query3, Database.GetDatabaseConnection());
                    sqliteCommand3.ExecuteNonQuery();
                    SQLiteDataReader reader3 = sqliteCommand3.ExecuteReader();
                    while (reader3.Read())
                    {                       
                        answers[count + 1] = reader3.GetString(0).ToLower();

                    }
                    count++;
                    
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            qn1TxtBlock.Text += questions[1];
            qn1TxtBlock.Tag = answers[1];
            qn2TxtBlock.Text += questions[2];
            qn2TxtBlock.Tag = answers[2];
            qn3TxtBlock.Text += questions[3];
            qn3TxtBlock.Tag = answers[3];
            qn4TxtBlock.Text += questions[4];
            qn4TxtBlock.Tag = answers[4];
            
        }

        public void SetZoeziDContent()
        {
            category = "KikeKiume";
            question = "Andika kike ya maneno haya:";
            questionTxtBlock.Text = question;
            int count = 0;
            string[] questions = new string[5];
            string[] answers = new string[5];
            string query = "select kiume_image_id,kike_image_id from kike_kiume";
            try
            {
                SQLiteCommand sqliteCommand = new SQLiteCommand(query, Database.GetDatabaseConnection());
                sqliteCommand.ExecuteNonQuery();
                SQLiteDataReader reader = sqliteCommand.ExecuteReader();
                while (reader.Read() && count < 4)
                {
                    string query2 = "select kiswahili_tag from image_details where image_id='" + reader.GetValue(0) + "'";
                    string query3 = "select kiswahili_tag from image_details where image_id='" + reader.GetValue(1) + "'";
                    SQLiteCommand sqliteCommand2 = new SQLiteCommand(query2, Database.GetDatabaseConnection());
                    sqliteCommand2.ExecuteNonQuery();
                    SQLiteDataReader reader2 = sqliteCommand2.ExecuteReader();
                    while (reader2.Read())
                    {
                        questions[count + 1] = reader2.GetString(0);

                    }
                    SQLiteCommand sqliteCommand3 = new SQLiteCommand(query3, Database.GetDatabaseConnection());
                    sqliteCommand3.ExecuteNonQuery();
                    SQLiteDataReader reader3 = sqliteCommand3.ExecuteReader();
                    while (reader3.Read())
                    {
                        answers[count + 1] = reader3.GetString(0).ToLower();

                    }
                    count++;

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            qn1TxtBlock.Text += questions[1];
            qn1TxtBlock.Tag = answers[1];
            qn2TxtBlock.Text += questions[2];
            qn2TxtBlock.Tag = answers[2];
            qn3TxtBlock.Text += questions[3];
            qn3TxtBlock.Tag = answers[3];
            qn4TxtBlock.Text += questions[4];
            qn4TxtBlock.Tag = answers[4];
        }

        private void evaluateBtn_Click(object sender, RoutedEventArgs e)
        {
            if(IsNullAnswersPresent())
            {
                return;
            }
            else
            {
                if (category == "Tarakimu")
                {
                    int ans1 = int.Parse(qn1TxtBlock.Tag.ToString());
                    int ans2 = int.Parse(qn2TxtBlock.Tag.ToString());
                    int ans3 = int.Parse(qn3TxtBlock.Tag.ToString());
                    int ans4 = int.Parse(qn4TxtBlock.Tag.ToString());
                    if(ans1TxtBox.Text.ToLower()==Tarakimu.GetNumberName(ans1))
                    {
                        img1.Source = new BitmapImage(new Uri("/Images/tick.png", UriKind.Relative));
                        img1.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        img1.Source = new BitmapImage(new Uri("/Images/cross.png",UriKind.Relative));
                        img1.Visibility = Visibility.Visible;
                    }
                    if (ans2TxtBox.Text.ToLower() == Tarakimu.GetNumberName(ans2))
                    {
                        img2.Source = new BitmapImage(new Uri("/Images/tick.png", UriKind.Relative));
                        img2.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        img2.Source = new BitmapImage(new Uri("/Images/cross.png", UriKind.Relative));
                        img2.Visibility = Visibility.Visible;
                    }
                    if (ans3TxtBox.Text.ToLower() == Tarakimu.GetNumberName(ans3))
                    {
                        img3.Source = new BitmapImage(new Uri("/Images/tick.png", UriKind.Relative));
                        img3.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        img3.Source = new BitmapImage(new Uri("/Images/cross.png", UriKind.Relative));
                        img3.Visibility = Visibility.Visible;
                    }
                    if (ans4TxtBox.Text.ToLower() == Tarakimu.GetNumberName(ans4))
                    {
                        img4.Source = new BitmapImage(new Uri("/Images/tick.png", UriKind.Relative));
                        img4.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        img4.Source = new BitmapImage(new Uri("/Images/cross.png", UriKind.Relative));
                        img4.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    if (ans1TxtBox.Text.ToLower() == qn1TxtBlock.Tag.ToString())
                    {
                        img1.Source = new BitmapImage(new Uri("/Images/tick.png", UriKind.Relative));
                        img1.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        img1.Source = new BitmapImage(new Uri("/Images/cross.png", UriKind.Relative));
                        img1.Visibility = Visibility.Visible;
                    }
                    if (ans2TxtBox.Text.ToLower() == qn2TxtBlock.Tag.ToString())
                    {
                        img2.Source = new BitmapImage(new Uri("/Images/tick.png", UriKind.Relative));
                        img2.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        img2.Source = new BitmapImage(new Uri("/Images/cross.png", UriKind.Relative));
                        img2.Visibility = Visibility.Visible;
                    }
                    if (ans3TxtBox.Text.ToLower() == qn3TxtBlock.Tag.ToString())
                    {
                        img3.Source = new BitmapImage(new Uri("/Images/tick.png", UriKind.Relative));
                        img3.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        img3.Source = new BitmapImage(new Uri("/Images/cross.png", UriKind.Relative));
                        img3.Visibility = Visibility.Visible;
                    }
                    if (ans4TxtBox.Text.ToLower() == qn4TxtBlock.Tag.ToString())
                    {
                        img4.Source = new BitmapImage(new Uri("/Images/tick.png", UriKind.Relative));
                        img4.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        img4.Source = new BitmapImage(new Uri("/Images/cross.png", UriKind.Relative));
                        img4.Visibility = Visibility.Visible;
                    }
                }
            }
            
            
            
        }

        private bool IsNullAnswersPresent()
        {
            IEnumerable<TextBox> answers = mainGrid.Children.OfType<TextBox>();

            foreach(TextBox answer in answers)
            {
                if(String.IsNullOrEmpty(answer.Text))
                {
                    MessageBox.Show("Tafadhali jibu maswali yote","iMasomo",MessageBoxButton.OK,MessageBoxImage.Exclamation);
                    answer.Focus();
                    return true;
                }
              
            }
            return false;
           
        }

        private void ClearText()
        {
            IEnumerable<TextBox> answers = mainGrid.Children.OfType<TextBox>();
            foreach(TextBox answer in answers)
            {
                answer.Clear();
            }
           
        }

        private void answerTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox answer = sender as TextBox;           
            answer.Text = Regex.Replace(answer.Text,@"[\d-]",String.Empty);
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
