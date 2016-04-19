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
using System.IO;
using System.Windows.Navigation;
using System.Data.SQLite;
using iMasomo;


namespace iMasomo_Teacher
{
    /// <summary>
    /// Interaction logic for AddWords.xaml
    /// </summary>
    public partial class AddWords : Page
    {
        char alphabet;
        string kiswahiliWord;
        string recordingPath;
        string category;

        bool recording = false;
        bool useRecording = false;

        public AddWords()
        {
            InitializeComponent();
            
        }

        public void AddWordsToDatabase()
        {
                     
            kiswahiliWord = kiswahiliWordTxtBox.Text.ToLower();
            alphabet = kiswahiliWord[0]; 

            if(yesRadioBtn.IsChecked==true)
            {
                category = "imla";
            }
            else
            {
                category = "zote";
            }
            string query = "insert into word_details (word,alphabet,sound_path,category) values('"+kiswahiliWord+"'"
            +",'"+alphabet+"','"+recordingPath+"','"+category+"')";
            SQLiteCommand sqliteComm = new SQLiteCommand(query, Database.GetDatabaseConnection());
            if (sqliteComm.ExecuteNonQuery()==1)
            {
                MessageBox.Show("The word has been added to the system");
            }
            else
            {
                MessageBox.Show("Error:Word not added");
            }
                
        }
            

        private void addWordBtn_Click(object sender, RoutedEventArgs e)
        {
            //input validation
            if (String.IsNullOrEmpty(kiswahiliWordTxtBox.Text))
            {
                MessageBox.Show("Please enter the Kiswahili word", "iMasomoAdmin", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                kiswahiliWordTxtBox.Focus();
                return;
            }
            if(useRecording)
            {
                AddWordsToDatabase();
            }
            else
            {
                //input validation
                if(String.IsNullOrEmpty(recordingPathTxtBox.Text))
                {
                    MessageBox.Show("Please select sound recording again", "iMasomoAdmin", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    recordingPathTxtBox.Focus();
                }
                else
                {
                    CopySound();
                    AddWordsToDatabase();
                }
                
            }
            
        }

        private void CopySound()
        {
            string ext = Path.GetExtension(recordingPathTxtBox.Text);
            kiswahiliWord = kiswahiliWordTxtBox.Text;
            recordingPath =@"\Media\" +kiswahiliWord+ ext;
            File.Copy(recordingPathTxtBox.Text, Environment.CurrentDirectory+recordingPath);

        }

        private void browseBtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fileDlg = new Microsoft.Win32.OpenFileDialog();
            fileDlg.DefaultExt = ".wav";
            fileDlg.Filter = "Sound File(*.wav;*.mp3)|*.wav;*.mp3";

            Nullable<bool> result = fileDlg.ShowDialog();
            if(result.HasValue)
            {
                
                recordingPathTxtBox.Text = fileDlg.FileName;
                useRecording = false;
            }
            
        }

       
        private void recordBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if(recording)
            {
                Sound.StopRecording();
                recording = false;
                recordBtnText.Text = "Press Button To Record Sound";

            }
            else
            {
                if(String.IsNullOrEmpty(kiswahiliWordTxtBox.Text))
                {
                    MessageBox.Show("Enter the Kiswahili word first", "iMasomoAdmin", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    kiswahiliWordTxtBox.Focus();
                }
                else
                {
                    Sound.RecordSound(kiswahiliWordTxtBox.Text);
                    recording = true;
                    recordBtnText.Text = "Stop Recording";
                    recordingPath = @"\Media\" + kiswahiliWordTxtBox.Text + ".wav";
                    useRecording = true;
                }
                
                
            }
           
        }
        
    }
}
