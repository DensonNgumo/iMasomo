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



namespace iMasomo
{
    /// <summary>
    /// Interaction logic for Tarakimu.xaml
    /// </summary>
    public partial class Tarakimu : Window
    {
        private static Random random = new Random();
        int nambari = 0;
        static string[] tarakimuJina = {"nunge","moja","mbili","tatu","nne","tano","sita","saba","nane","tisa" };
        
        public Tarakimu()
        {
            InitializeComponent();
            nambariTextBlock.Text = nambari.ToString();
            nambariJinaTextBlock.Text = tarakimuJina[nambari].ToUpper();
        }

        private void LoadNextNumber()
        {
            if(nambari<100)
            {
                nambari++;
                nambariTextBlock.Text = nambari.ToString();
                nambariJinaTextBlock.Text = GetNumberName(nambari).ToUpper();
            }
            
        }

        private void LoadPreviousNumber()
        {
            if(nambari>0)
            {
                nambari--;              
                nambariTextBlock.Text = nambari.ToString();
                nambariJinaTextBlock.Text =GetNumberName(nambari).ToUpper();
            }
            
        }


        public static string GetNumberName(int no)
        {
            string nambariJina = "";
            //load name for single digit number
            if (no >= 0 && no < 10)
            {
                nambariJina = tarakimuJina[no];
                return nambariJina;
            }

            else if (no >= 10 && no <= 100)
            {
                //load name for double digit number
                nambariJina = LoadDoubleDigits(no);
                return nambariJina;
            }
            else
            {
                return nambariJina;
            }
            
        }

        public static int GetRandomNumber()
        {
            
            int number = 0;
            number = random.Next(0, 100);
            return number;
        }
        private static string LoadDoubleDigits(int no)
        {
            int n = no % 10;
            
            switch (no)
            {
                case 10:
                    return "kumi";
                case 20:
                    return "ishirini";
                case 30:
                    return "thelathini";
                case 40:
                    return "arobaini";
                case 50:
                    return "hamsini";
                case 60:
                    return "sitini";
                case 70:
                    return "sabini";
                case 80:
                    return "themanini";
                case 90:
                    return "tisini";   
                case 100:
                    return "mia moja";
                
            }
            if (no > 10 && no < 20)
            {
                return "kumi na " + tarakimuJina[n];
            }
            if (no > 20 && no < 30)
            {
                return "ishirini na " + tarakimuJina[n];
            }
            if (no > 30 && no < 40)
            {
                return "thelathini na " + tarakimuJina[n];
            }
            if (no > 40 && no < 50)
            {
                return "arobaini na " + tarakimuJina[n];
            }
            if (no > 50 && no < 60)
            {
                return "hamsini na " + tarakimuJina[n];
            }
            if (no > 60 && no < 70)
            {
                return "sitini na " + tarakimuJina[n];
            }
            if (no > 70 && no < 80)
            {
                return "sabini na " + tarakimuJina[n];
            }
            if (no > 80 && no < 90)
            {
                return "themanini na " + tarakimuJina[n];
            }
            else
            {
                return "tisini na " + tarakimuJina[n];
            }
            
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Left)
            {
                LoadPreviousNumber();
            }
            if(e.Key==Key.Right)
            {
                LoadNextNumber();
            }
        }

        private void nextArrowRectangle_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            LoadNextNumber();
        }

        private void previousArrowRectangle_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            LoadPreviousNumber();
        }
    }
}
