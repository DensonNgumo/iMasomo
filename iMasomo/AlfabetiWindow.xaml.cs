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
using System.Windows.Shapes;
using System.Data.SQLite;

namespace iMasomo
{
    /// <summary>
    /// Interaction logic for AlfabetiWindow.xaml
    /// </summary>
    public partial class AlfabetiWindow : Window
    {
        private string alfabeti;
        private SQLiteConnection sqliteConn;
        
        

        public AlfabetiWindow()
        {
            InitializeComponent();
            Database.OpenDatabase();
            SetConnection();
        }

        public void SetAlphabet(string a)
        {
            alfabeti=a;
            alphabetTxtBlock.Text = alfabeti;
        }

        public void LoadWords()
        {
            
            string query = "select word from word_details where alphabet='" + alfabeti + "'";
            SQLiteCommand sqlComm = new SQLiteCommand(query, sqliteConn);
            sqlComm.ExecuteNonQuery();
            SQLiteDataReader dr = sqlComm.ExecuteReader();
            while(dr.Read())
            {
                TextBlock wordLabel = new TextBlock();
                wordLabel.Text = "- " + dr.GetString(0); 
                wordListPanel.Children.Add(wordLabel);
            }
            
        }

        public void SetConnection()
        {
            sqliteConn = Database.GetDatabaseConnection();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadWords();
        }
    }
}
