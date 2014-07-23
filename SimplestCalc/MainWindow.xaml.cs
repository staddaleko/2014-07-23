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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimplestCalc
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

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double op1 = Convert.ToDouble(pierwsza.Text);
            double op2 = Convert.ToDouble(druga.Text);
            bool dod = Convert.ToBoolean(dodawanie.IsChecked);
            bool ode = Convert.ToBoolean(odejmowanie.IsChecked);
            bool mno = Convert.ToBoolean(mnozenie.IsChecked);
            bool dzie = Convert.ToBoolean(dzielenie.IsChecked);

            if (dod)
            {
                Wynik.Clear();
                Wynik.AppendText(Convert.ToString(op1 + op2));
            }
            else
            {
                if (ode)
                {
                    Wynik.Clear();
                    Wynik.AppendText(Convert.ToString(op1 - op2));
                }
                else
                {
                    if (mno)
                    {
                        Wynik.Clear();
                        Wynik.AppendText(Convert.ToString(op1 * op2));
                    }
                    else
                    {
                        if (dzie)
                        {
                            Wynik.Clear();
                            Wynik.AppendText(Convert.ToString(op1 / op2));
                        }
                    }
                }
            }

            
        }

       

        private void druga_GotFocus(object sender, RoutedEventArgs e)
        {
            druga.Clear();
        }

        private void druga_MouseEnter(object sender, MouseEventArgs e)
        {
            druga.Clear();
        }

        private void pierwsza_MouseEnter(object sender, MouseEventArgs e)
        {
            pierwsza.Clear();
        }

        private void pierwsza_GotFocus(object sender, RoutedEventArgs e)
        {
            pierwsza.Clear();
        }

        private void zamknij_Checked(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
