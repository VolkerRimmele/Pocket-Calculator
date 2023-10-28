using Microsoft.VisualBasic;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Taschenrechner_Volker_Rimmele_in_WPF_18_10_23
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (txtBox_Eingabe.Text == "Eingabe") txtBox_Eingabe.Text = "";
            Button btn = (Button)sender;

            txtBox_Eingabe.Text += btn.Content.ToString();
        }
         

        private void btn_Click_Gleich(object sender, RoutedEventArgs e)
        {
            bool rechenoperationGefunden = false;
            string eingabe1string = "";
            string eingabe2string = "";
            char rechenoperation = ' ';
            int indexRechOperation = 0;
            int zaehlerRechenzeichen = 0;

            for (int i=0; i < txtBox_Eingabe.Text.Length-1; i++) 
            {
                if (i > 0  && (txtBox_Eingabe.Text[i] == '+' || txtBox_Eingabe.Text[i] == '-' || txtBox_Eingabe.Text[i] == '*' || txtBox_Eingabe.Text[i] == '/'))
                {
                    zaehlerRechenzeichen = zaehlerRechenzeichen + 1;

                    if (zaehlerRechenzeichen == 1)
                    {

                        rechenoperation = txtBox_Eingabe.Text[i];
                        indexRechOperation = i;
                        rechenoperationGefunden = true;
                        for (int j = 0; j < i; j++)
                        {
                            char[] eingabe1 = new char[i];
                            eingabe1[j] = txtBox_Eingabe.Text[j];
                            eingabe1string = eingabe1string + eingabe1[j];
                        }
                    }
  
                }
                if (rechenoperationGefunden == true)
                {
                        char[] eingabe2 = new char[(txtBox_Eingabe.Text.Length - 1) - indexRechOperation];
                        eingabe2[i - indexRechOperation] = txtBox_Eingabe.Text[i + 1];
                        eingabe2string = eingabe2string + eingabe2[i - indexRechOperation];
                }
            }
            Rechne(eingabe1string, rechenoperation, eingabe2string);

        }
        private void Rechne(string eingabe1string, char rechenoperation, string eingabe2string)
        {
            double eingabe1Double;
            double eingabe2Double;
            double ergebnis=0;

            if ((double.TryParse(eingabe1string, out eingabe1Double)) && double.TryParse(eingabe2string, out eingabe2Double))
            {
                if (rechenoperation == '+')
                {
                    ergebnis = eingabe1Double + eingabe2Double;
                    txtBox_Ausgabe.Text = ergebnis.ToString();
                }
                else if (rechenoperation == '-')
                {
                    ergebnis = eingabe1Double - eingabe2Double;
                    txtBox_Ausgabe.Text = ergebnis.ToString();
                }
                else if (rechenoperation == '*')
                {
                    ergebnis = eingabe1Double * eingabe2Double;
                    txtBox_Ausgabe.Text = ergebnis.ToString();
                }
                else if (rechenoperation == '/')
                {
                    ergebnis = eingabe1Double / eingabe2Double;
                    txtBox_Ausgabe.Text = ergebnis.ToString();
                }
                else
                {
                    MessageBox.Show("Bitte nur Zahlen und +-+/= eingeben");
                }
            }
            else
            {
                MessageBox.Show("Der Rechner funktioniert nur mit 2 Zahlen");
                if (txtBox_Eingabe.Text != "Eingabe") txtBox_Eingabe.Text = "";
                if (txtBox_Ausgabe.Text != "Ausgabe") txtBox_Ausgabe.Text = "";
            }
        }

        private void btn_CE_Click(object sender, RoutedEventArgs e)
        {
            txtBox_Eingabe.Text = txtBox_Eingabe.Text.Remove(txtBox_Eingabe.Text.Length - 1);
        }

        private void btn_C_Click(object sender, RoutedEventArgs e)
        {
            if (txtBox_Eingabe.Text != "Eingabe") txtBox_Eingabe.Text = "";
            if (txtBox_Ausgabe.Text != "Ausgabe") txtBox_Ausgabe.Text = "";
        }
               
        
        private void btn_Prozent_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBox_Ausgabe.Text) && txtBox_Ausgabe.Text != "Ausgabe")
            {
                double prozentErgebnis = Convert.ToDouble(txtBox_Ausgabe.Text) * 0.01;
                txtBox_Ausgabe.Text = prozentErgebnis.ToString();
            }

            if ((!String.IsNullOrEmpty(txtBox_Eingabe.Text)) && (String.IsNullOrEmpty(txtBox_Ausgabe.Text) || txtBox_Ausgabe.Text == "Ausgabe"))
            {
                int indexRechOperation = 0;
                bool rechenoperationGefunden = false;
                string eingabe2string = "";
                string eingabe1string = "";
                char rechenoperation = ' ';
                int taste = 1;

                TeileString(eingabe1string, eingabe2string, indexRechOperation, rechenoperationGefunden, rechenoperation, taste);
               
            }
        }

        private void btn_PlusMinus_Click(object sender, RoutedEventArgs e)
        {
            if ((!String.IsNullOrEmpty(txtBox_Eingabe.Text)) && (String.IsNullOrEmpty(txtBox_Ausgabe.Text) || txtBox_Ausgabe.Text == "Ausgabe"))
            {
                int indexRechOperation = 0;
                bool rechenoperationGefunden = false;
                string eingabe2string = "";
                string eingabe1string = "";
                char rechenoperation = ' ';
                int taste = 2;

                TeileString(eingabe1string, eingabe2string, indexRechOperation, rechenoperationGefunden, rechenoperation, taste);

            }
        }


        private void btn_Quadrat_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBox_Ausgabe.Text) && txtBox_Ausgabe.Text != "Ausgabe")
            {
                double prozentErgebnis = Convert.ToDouble(txtBox_Ausgabe.Text);
                prozentErgebnis = prozentErgebnis * prozentErgebnis;
                txtBox_Ausgabe.Text = prozentErgebnis.ToString();
            }
            if ((!String.IsNullOrEmpty(txtBox_Eingabe.Text)) && (String.IsNullOrEmpty(txtBox_Ausgabe.Text) || txtBox_Ausgabe.Text == "Ausgabe"))
            {
                int indexRechOperation = 0;
                bool rechenoperationGefunden = false;
                string eingabe2string = "";
                string eingabe1string = "";
                char rechenoperation = ' ';
                int taste = 3;

                TeileString(eingabe1string, eingabe2string, indexRechOperation, rechenoperationGefunden, rechenoperation, taste);
            }
        }

        private void btn_Wurzel_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBox_Ausgabe.Text) && txtBox_Ausgabe.Text != "Ausgabe")
            {
                double prozentErgebnis = Convert.ToDouble(txtBox_Ausgabe.Text);


                if (prozentErgebnis >= 0)
                {
                    prozentErgebnis = Math.Sqrt(prozentErgebnis);
                    txtBox_Ausgabe.Text = prozentErgebnis.ToString();
                }
                else
                {
                    txtBox_Ausgabe.Text = "Wurzel negative Zahl";
                }
            }
            if ((!String.IsNullOrEmpty(txtBox_Eingabe.Text)) && (String.IsNullOrEmpty(txtBox_Ausgabe.Text) || txtBox_Ausgabe.Text == "Ausgabe"))
            {
                int indexRechOperation = 0;
                bool rechenoperationGefunden = false;
                string eingabe2string = "";
                string eingabe1string = "";
                char rechenoperation = ' ';

                int taste = 4;

                TeileString(eingabe1string, eingabe2string, indexRechOperation, rechenoperationGefunden, rechenoperation, taste);
            }
        }

        private void btn_geteiltDurchX_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBox_Ausgabe.Text) && txtBox_Ausgabe.Text != "Ausgabe")
            {
                double prozentErgebnis = Convert.ToDouble(txtBox_Ausgabe.Text);
                prozentErgebnis = 1 / prozentErgebnis;
                txtBox_Ausgabe.Text = prozentErgebnis.ToString();
            }
            if ((!String.IsNullOrEmpty(txtBox_Eingabe.Text)) && (String.IsNullOrEmpty(txtBox_Ausgabe.Text) || txtBox_Ausgabe.Text == "Ausgabe"))
            {
                int indexRechOperation = 0;
                bool rechenoperationGefunden = false;
                string eingabe2string = "";
                string eingabe1string = "";
                char rechenoperation = ' ';

                int taste = 5;

                TeileString(eingabe1string, eingabe2string, indexRechOperation, rechenoperationGefunden, rechenoperation, taste);
            }
        }

        public void TeileString(string eingabe1string, string eingabe2string, int indexRechOperation, bool rechenoperationGefunden, char rechenoperation, int taste)
        {

            int zaehlerRechenzeichen = 0;
            for (int i = 0; i < txtBox_Eingabe.Text.Length; i++)
            {

                if (!rechenoperationGefunden)
                {
                    char[] eingabe1 = new char[i + 1];
                    eingabe1[i] = txtBox_Eingabe.Text[i];
                    eingabe1string = eingabe1string + eingabe1[i];
                    rechenoperationGefunden = false;
                }

                if (i>0 && (txtBox_Eingabe.Text[i] == '+' || txtBox_Eingabe.Text[i] == '-' || txtBox_Eingabe.Text[i] == '*' || txtBox_Eingabe.Text[i] == '/'))
                {

                    zaehlerRechenzeichen = zaehlerRechenzeichen + 1;

                    if (zaehlerRechenzeichen == 1)
                    {
                        rechenoperationGefunden = true;
                        indexRechOperation = i;
                        rechenoperation = txtBox_Eingabe.Text[i];
                        eingabe1string = "";
                        for (int j = 0; j < i; j++)
                        {
                            char[] eingabe1 = new char[i];
                            eingabe1[j] = txtBox_Eingabe.Text[j];
                            eingabe1string = eingabe1string + eingabe1[j];
                        }
                    }
                }

                if (rechenoperationGefunden)
                {
                    char[] eingabe2 = new char[(txtBox_Eingabe.Text.Length - 1) - indexRechOperation];
                    //if (txtBox_Eingabe.Text[i] != '=')
                    if (i < txtBox_Eingabe.Text.Length - 1)
                    {
                        eingabe2[i - indexRechOperation] = txtBox_Eingabe.Text[i + 1];
                        eingabe2string = eingabe2string + eingabe2[i - indexRechOperation];
                    }
                    //rechenoperationGefunden = true;
                }
            }


            if (!rechenoperationGefunden)
            {
               
                if (taste == 1)
                {
                    double prozentErgebnis1 = Convert.ToDouble(eingabe1string) * 0.01;
                    eingabe1string = prozentErgebnis1.ToString();
                }
                if (taste == 2)
                {
                    double prozentErgebnis1 = Convert.ToDouble(eingabe1string) * (-1);
                    eingabe1string = prozentErgebnis1.ToString();
                }
                if (taste == 3)
                {
                    double prozentErgebnis1 = Convert.ToDouble(eingabe1string);
                    prozentErgebnis1 = prozentErgebnis1 * prozentErgebnis1;
                    eingabe1string = prozentErgebnis1.ToString();
                }
                if (taste == 4)
                {
                    double prozentErgebnis1 = Convert.ToDouble(eingabe1string);
                    {
                        if (prozentErgebnis1 >= 0)
                        {
                            prozentErgebnis1 = Math.Sqrt(prozentErgebnis1);
                            eingabe1string = prozentErgebnis1.ToString();
                        }
                        else
                        {
                            eingabe1string = "Wurzel negative Zahl";
                        }

                    }
                }
                if (taste == 5)
                {
                    double prozentErgebnis1 = Convert.ToDouble(eingabe1string);
                    prozentErgebnis1 = 1/prozentErgebnis1;
                    eingabe1string = prozentErgebnis1.ToString();
                }

            }
            if (rechenoperationGefunden)
            {
                
                if (taste == 1)
                {
                    double prozentErgebnis2 = Convert.ToDouble(eingabe2string) * 0.01;
                    eingabe2string = prozentErgebnis2.ToString();
                }
                if (taste == 2)
                {
                    if (rechenoperation == '+') rechenoperation = 'A';
                    if (rechenoperation == '-') rechenoperation = '+';
                    if (rechenoperation == 'A') rechenoperation = '-';

                    if (rechenoperation == '+' || rechenoperation == '-')
                    {
                        double prozentErgebnis2 = Convert.ToDouble(eingabe2string);
                        eingabe2string = prozentErgebnis2.ToString();
                    }
                    else if (rechenoperation == '*' || rechenoperation == '/')
                    {
                        double prozentErgebnis2 = Convert.ToDouble(eingabe2string) * (-1);
                        eingabe2string = prozentErgebnis2.ToString();
                        
                    }
                
                }
                if (taste == 3)
                {
                    double prozentErgebnis2 = Convert.ToDouble(eingabe2string);
                    prozentErgebnis2 = prozentErgebnis2 * prozentErgebnis2;
                    eingabe2string = prozentErgebnis2.ToString();
                }
                if (taste == 4) 
                {
                    double prozentErgebnis2 = Convert.ToDouble(eingabe2string);
                    if (prozentErgebnis2 > 0)
                    {
                        prozentErgebnis2 = Math.Sqrt(prozentErgebnis2);
                        eingabe2string = prozentErgebnis2.ToString();
                    }
                    else
                    {
                        eingabe2string = "Wurzel negative Zahl";
                    }

                }
                if (taste == 5)
                {
                    double prozentErgebnis2 = Convert.ToDouble(eingabe2string);
                    prozentErgebnis2 = 1/prozentErgebnis2;
                    eingabe2string = prozentErgebnis2.ToString();
                }

            }

            txtBox_Eingabe.Text = "";
            if (rechenoperationGefunden) txtBox_Eingabe.Text = eingabe1string + rechenoperation + eingabe2string;
            if (!rechenoperationGefunden) txtBox_Eingabe.Text = eingabe1string;
        }
                
    }
}
