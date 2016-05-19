using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using iMasomo_Teacher;

namespace iMasomo
{
    /// <summary>
    /// Interaction logic for TicTacToe.xaml
    /// </summary>
    public partial class TicTacToe : Window
    {
        bool turn = true;//true=X turn;false=O turn
        int turn_count = 0;
        public TicTacToe()
        {
            InitializeComponent();
        }

      

        private void exitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonClick(object sender, RoutedEventArgs e)
        {
            Sound.PlayButton2Sound();
            Button button=(Button)sender;
            if(turn)
                button.Content="X";
            else
                button.Content="O";
            turn=!turn;
            button.IsEnabled = false;
            turn_count++;

            CheckForWinner();
        }

        private void CheckForWinner()
        {
            bool there_is_winner=false;

            //horizontal checks
            if ((A1.Content == A2.Content) && (A2.Content == A3.Content)&&(!A1.IsEnabled))
                there_is_winner = true;
            else if ((B1.Content == B2.Content) && (B2.Content == B3.Content) && (!B1.IsEnabled))
                there_is_winner = true;
            else if ((C1.Content == C2.Content) && (C2.Content == C3.Content) && (!C1.IsEnabled))
                there_is_winner = true;

            //vertical checks
            if ((A1.Content == B1.Content) && (B1.Content == C1.Content) && (!A1.IsEnabled))
                there_is_winner = true;
            else if ((A2.Content == B2.Content) && (B2.Content == C2.Content) && (!A2.IsEnabled))
                there_is_winner = true;
            else if ((A3.Content == B3.Content) && (B3.Content == C3.Content) && (!A3.IsEnabled))
                there_is_winner = true;

            //diagonal checks
            if ((A1.Content == B2.Content) && (B2.Content == C3.Content) && (!A1.IsEnabled))
                there_is_winner = true;
            else if ((A3.Content == B2.Content) && (B2.Content == C1.Content) && (!C1.IsEnabled))
                there_is_winner = true;
          

            if(there_is_winner)
            {
                DisableButtons();
                string winner = "";
                if (turn)
                    winner = "O";
                else
                    winner = "X";
                Sound.PlaySound(@"\Media\Hongera.mp3");
                MessageBox.Show(winner + " ameshinda!","iMasomo");
                
            }
            else
            {
                if(turn_count==9)
                {
                    MessageBox.Show("Hakuna aliye shinda! Cheza Tena..");
                    ResetGame();
                }
                    
                
            }

        }
        

    

        private void DisableButtons()
        {
            try
            {
                IEnumerable<Button> collection = mainGrid.Children.OfType<Button>();
                foreach (Button b in collection)
                {
                    b.IsEnabled = false;
                }
            }
            catch { }
            
        }

        private void ResetGame()
        {
            turn = true;
            turn_count = 0;
            try
            {
                IEnumerable<Button> collection = mainGrid.Children.OfType<Button>();
                foreach (Button b in collection)
                {
                    b.IsEnabled = true;
                    b.Content = "";
                }
            }
            catch { }
        }

        private void newGameMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ResetGame();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Sound.PauseBackgroundMusic();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Sound.PlayBackgroundMusic();
        }
        
    }
}
