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
    /// Interaction logic for AlfabetiWindow.xaml
    /// </summary>
    public partial class AlfabetiWindow : Window
    {
        private string alfabeti;

        
        

        public AlfabetiWindow()
        {
            InitializeComponent();
            //Database.OpenDatabase();
            
        }

        public void SetAlphabet(string a)
        {
            alfabeti=a;
            alphabetTxtBlock.Text = alfabeti;
        }

        public void LoadWords()
        {
            
            string query = "select word,category from word_details where alphabet='" + alfabeti + "'";
            SQLiteCommand sqlComm = new SQLiteCommand(query, Database.GetDatabaseConnection());
            sqlComm.ExecuteNonQuery();
            SQLiteDataReader dr = sqlComm.ExecuteReader();
            while(dr.Read())
            {
                TextBlock wordLabel = new TextBlock();
                wordLabel.Text = "- " + dr.GetString(0);
                wordLabel.Tag = dr.GetValue(1);
                wordLabel.MouseEnter += wordLabel_MouseEnter;
                wordListPanel.Children.Add(wordLabel);
            }
            
        }

        void wordLabel_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBlock wordTxtBlock = sender as TextBlock;
            string path="";
            if(wordTxtBlock.Tag.ToString()=="imla")
            {
                
                string query = "select sound_path from word_details where word='" + wordTxtBlock.Text + "'";
                SQLiteCommand sqlComm = new SQLiteCommand(query, Database.GetDatabaseConnection());
                sqlComm.ExecuteNonQuery();
                SQLiteDataReader dr = sqlComm.ExecuteReader(); 
                while (dr.Read())
                {
                    path = dr.GetString(0); MessageBox.Show(path);
                    //Sound.PlaySound(path);
                    
                }
                
                
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadWords();
        }
    }
}
