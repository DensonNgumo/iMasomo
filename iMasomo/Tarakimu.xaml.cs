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

namespace iMasomo
{
    /// <summary>
    /// Interaction logic for Tarakimu.xaml
    /// </summary>
    public partial class Tarakimu : Window
    {
        int nambari = 0;
        string[] tarakimuJina = {"nunge","moja","mbili","tatu","nne","tano","sita","saba","nane","tisa" };
        string nambariJina="";
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
                LoadNumberName();
                nambariTextBlock.Text = nambari.ToString();
                nambariJinaTextBlock.Text = nambariJina.ToUpper();
            }
            
        }

        private void LoadPreviousNumber()
        {
            if(nambari>0)
            {
                nambari--;
                LoadNumberName();
                nambariTextBlock.Text = nambari.ToString();
                nambariJinaTextBlock.Text = nambariJina.ToUpper();
            }
            
        }

        private void LoadNumberName()
        {
            //load name for single digit number
            if(nambari>=0 && nambari<10)
            {
                nambariJina = tarakimuJina[nambari];
            }
            
            else if(nambari>=10 && nambari<=100)
            {
                nambariJina=LoadDoubleDigits(nambari);//load name for double digit number
            }
               
        }

        //returns the first digit of an integer
        private int GetFirstDigit(int number)
        {
            if (number < 10)
            {
                return number;
            }
            return GetFirstDigit((number - (number % 10)) / 10);
        }

        private string LoadDoubleDigits(int no)
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
