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
        string wordMeaning;
        string recordingPath;
        string category;

        bool recording = false;

        public AddWords()
        {
            InitializeComponent();
            
        }

        public void AddWordsToDatabase()
        {
            alphabet = kiswahiliWordTxtBox.Text[0];
            wordMeaning = wordMeaningTxtBox.Text;
            kiswahiliWord = kiswahiliWordTxtBox.Text;

            if(yesRadioBtn.IsChecked==true)
            {
                category = "imla";
            }
            else
            {
                category = "zote";
            }
            string query = "insert into word_details (word,alphabet,sound_path,category,meaning) values('"+kiswahiliWord+"'"
            +",'"+alphabet+"','"+recordingPath+"','"+category+"','"+wordMeaning+"')";
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
            kiswahiliWord = kiswahiliWordTxtBox.Text;
            CopySound();
        }

        private void CopySound()
        {
            string ext = Path.GetExtension(recordingPathTxtBox.Text);
            recordingPath = Environment.CurrentDirectory + @"\Media\" +kiswahiliWord+ ext;
            File.Copy(recordingPathTxtBox.Text, recordingPath);

        }

        private void browseBtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fileDlg = new Microsoft.Win32.OpenFileDialog();
            fileDlg.DefaultExt = ".wav";
            fileDlg.Filter = "Sound File(*.wav)|*.wav";

            Nullable<bool> result = fileDlg.ShowDialog();
            if(result.HasValue)
            {
                
                recordingPathTxtBox.Text = fileDlg.FileName;
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
                Sound.RecordSound(kiswahiliWordTxtBox.Text);
                recording = true;
                recordBtnText.Text = "Stop Recording";
                
            }
           
        }
        
    }
}
