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
        bool overwrite = false;

        public AddWords()
        {
            InitializeComponent();
            noRadioBtn.IsChecked = true;
            
        }

        public void AddWordsToDatabase()
        {
                                
            alphabet = kiswahiliWord[0]; 

            string query = "insert into word_details (word,alphabet,sound_path,category) values('"+kiswahiliWord+"'"
            +",'"+alphabet+"','"+recordingPath+"','"+category+"')";
            try
            {
                SQLiteCommand sqliteComm = new SQLiteCommand(query, Database.GetDatabaseConnection());
                if (sqliteComm.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("The word has been added to the system");
                    ClearInput();
                }
                else
                {
                    MessageBox.Show("Error:Word not added");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
                
        }

       public void UpdateDatabase()
        {
            string query = "update word_details set sound_path ='" + recordingPath + "' where word ='" + kiswahiliWord + "' ";
            try
            {
                SQLiteCommand sqliteComm = new SQLiteCommand(query, Database.GetDatabaseConnection());
                if (sqliteComm.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("The word has been updated");
                    ClearInput();
                }
                else
                {
                    MessageBox.Show("Error:Word not added");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
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
            kiswahiliWord = kiswahiliWordTxtBox.Text.ToLower();
           
            //check for duplicates
            if(DuplicateExists())
            {
                MessageBoxResult result = MessageBox.Show("That word is already in the system, do you wish to overwrite?", "iMasomoAdmin", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (result == MessageBoxResult.No)
                {
                    return;
                }
                if (result == MessageBoxResult.Yes)
                {
                    
                    if(yesRadioBtn.IsChecked==true)
                    {
                        if(useRecording)
                        {
                            UpdateDatabase();
                        }
                        else
                        {
                            overwrite = true;
                            CopySound();
                            UpdateDatabase();
                        }

                        
                    }
            
                }

            }
            else
            {
                if (yesRadioBtn.IsChecked == true)
                {
                    category = "imla";
                    overwrite = true;
                    Save();

                }
                else
                {
                    category = "kuongea";
                    recordingPath = "n/a";
                    AddWordsToDatabase();
                }
                
            }
            
        }

        private bool DuplicateExists()
        {
            string query = "select * from word_details where word ='" + kiswahiliWord + "' ";
            int count = 0;
            try
            {
                SQLiteCommand sqliteCommand = new SQLiteCommand(query, Database.GetDatabaseConnection());
                sqliteCommand.ExecuteNonQuery();
                SQLiteDataReader reader = sqliteCommand.ExecuteReader();
                while (reader.Read())
                {
                    count++;
                }

                if (count > 0)
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return false;
        }

        private void Save()
        {
            if (useRecording)
            {
                AddWordsToDatabase();
            }
            else
            {
                CopySound();
                AddWordsToDatabase();
               
            }
        }

        private void CopySound()
        {
            //input validation
            if (String.IsNullOrEmpty(recordingPathTxtBox.Text))
            {
                MessageBox.Show("Please select sound recording again", "iMasomoAdmin", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                recordingPathTxtBox.Focus();
            }
            else
            {
                string ext = Path.GetExtension(recordingPathTxtBox.Text);
                kiswahiliWord = kiswahiliWordTxtBox.Text;
                recordingPath = @"\Media\" + kiswahiliWord + ext;
                File.Copy(recordingPathTxtBox.Text, Environment.CurrentDirectory + recordingPath, overwrite);
            }
            

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

        void ClearInput()
        {
            kiswahiliWordTxtBox.Clear();
            recordingPathTxtBox.Clear();
            
        }
        
    }
}
