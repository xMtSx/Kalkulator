using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

namespace Kalkulator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double equal;
        bool operandPressed;
        string action;
        List<string> operands;
        List<string> dane;
        private int openedBracketsCount;

        public MainWindow()
        {
            InitializeComponent();
            equal = .0;
            operandPressed = false;
            action = "";
            operands = new List<string>();
            string[] tmp = { "+", "-", "*", "/", "=", "%" };
            //inicjalizacja listy operacji i danych
            dane = new List<String>();

            operands.AddRange(tmp.ToList());

        }

        private void equal_Click(object sender, RoutedEventArgs e)
        {

            if (dane.Count > 0)
            {
                int index;

                if (operands.Contains(dane[dane.Count - 1]))
                {
                    dane.RemoveAt(dane.Count - 1);
                }

                while (dane.Contains("*"))
                {
                    index = dane.FindIndex(str => str.Contains("*"));
                    double newVal = Convert.ToDouble(dane[index - 1]) * Convert.ToDouble(dane[index + 1]);
                    dane[index] = newVal.ToString();
                    dane.RemoveAt(index + 1);
                    dane.RemoveAt(index - 1);
                }

                while (dane.Contains("/"))
                {
                    index = dane.FindIndex(str => str.Contains("/"));
                    double newVal = Convert.ToDouble(dane[index - 1]) / Convert.ToDouble(dane[index + 1]);
                    dane[index] = newVal.ToString();
                    dane.RemoveAt(index + 1);
                    dane.RemoveAt(index - 1);
                }

                while (dane.Contains("%"))
                {
                    index = dane.FindIndex(str => str.Contains("%"));
                    double newVal = Convert.ToDouble(dane[index - 1]) % Convert.ToDouble(dane[index + 1]);
                    dane[index] = newVal.ToString();
                    dane.RemoveAt(index + 1);
                    dane.RemoveAt(index - 1);
                }

                while (dane.Contains("+"))
                {
                    index = dane.FindIndex(str => str.Contains("+"));
                    double newVal = Convert.ToDouble(dane[index - 1]) + Convert.ToDouble(dane[index + 1]);
                    dane[index] = newVal.ToString();
                    dane.RemoveAt(index + 1);
                    dane.RemoveAt(index - 1);
                }

                while (dane.Contains("-"))
                {
                    index = dane.FindIndex(str => str.Contains("-"));
                    double newVal = Convert.ToDouble(dane[index - 1]) - Convert.ToDouble(dane[index + 1]);
                    dane[index] = newVal.ToString();
                    dane.RemoveAt(index + 1);
                    dane.RemoveAt(index - 1);
                }

                ekran.Text += "=" + dane[0];
                dane.Clear();

            }
        }

        private void btnnumber_Click(object sender, RoutedEventArgs e)
        {
            //Pobranie wartosci z przycisku
            var data = ((Button)sender).Content.ToString();

            //dodaj do ekranu + do pamieci
            if (dane.Count > 0)
            {
                if (!operands.Contains(data) && !operands.Contains(dane[dane.Count - 1])) //jezeli sa dane to jezeli budujemy liczbe to trzeba sprawdzic poprzednia wartosc i ja ewentualnie rozszerzyc o kolejna cyfre
                {
                    dane[dane.Count - 1] = dane[dane.Count - 1] + data;
                    ekran.Text += data;
                }
                else //reszta przypadkow
                {
                    dane.Add(data);
                    ekran.Text += data;
                }
            }
            else //jezeli nie ma jeszcze danych to mozesz podac tylko cyfre na start
            {
                if (!operands.Contains(data))
                {
                    dane.Add(data);
                    ekran.Text = data;
                }
            }
        }

        private void OK_Button_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C)
            {
                ((Button)sender).Content = "WITAJ";
            }
            if (e.Key == Key.D)
            {
                ((Button)sender).Content = "ŻEGNAJ";
            }
        }

        private void clearbutton_Click(object sender, RoutedEventArgs e)
        {
            ekran.Text = "";
            action = "";
            operandPressed = false;
            equal = .0;
            dane.Clear();
        }

        private void etykieta1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (ekran.Text)
        }

        // obsługa przycisku sin
        private void Sin_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ekran.Text))
            {
                double value = double.Parse(ekran.Text);
                double radians = Math.PI * value / 180.0;
                double result = Math.Sin(radians);
                ekran.Text = result.ToString();
            }
        }


        // obsługa przycisku cos
        private void Cos_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ekran.Text))
            {
                double value = double.Parse(ekran.Text);
                double radians = Math.PI * value / 180.0;
                double result = Math.Cos(radians);
                ekran.Text = result.ToString();
            }
        }


        // obsługa przycisku tangens
        private void Tan_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ekran.Text))
            {
                double value = double.Parse(ekran.Text);
                double radians = Math.PI * value / 180.0;
                double result = Math.Tan(radians);
                ekran.Text = result.ToString();
            }
        }


        // obsługa przycisku potęga
        private void Pow_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ekran.Text))
            {
                double value = double.Parse(ekran.Text);
                double result = Math.Pow(value, 2); // tutaj wartość wykładnika może być inna, w zależności od potrzeb
                ekran.Text = result.ToString();
            }
        }

        // obsługa przycisku logarytm dziesiętny
        private void Log_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ekran.Text))
            {
                double value = double.Parse(ekran.Text);
                double result = Math.Log10(value);
                ekran.Text = result.ToString();
            }
        }

        private void Logn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ekran.Text))
            {
                double value = double.Parse(ekran.Text);
                double result = Math.Log(value);
                ekran.Text = result.ToString();
            }
        }

        private void Dms_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ekran.Text))
            {
                string wyrazenie = ekran.Text;
                string[] podzial = wyrazenie.Split(',');

                if (podzial.Length >= 2 && podzial.Length <= 3)
                {
                    double stopnie, minuty, sekundy;

                    if (double.TryParse(podzial[0], out stopnie) && double.TryParse(podzial[1], out minuty))
                    {
                        sekundy = 0;
                        if (podzial.Length == 3)
                        {
                            if (!double.TryParse(podzial[2], out sekundy))
                            {
                                // Obsługa błędu
                                MessageBox.Show("Nieprawidłowy format danych.");
                                return;
                            }
                        }

                        minuty += sekundy / 60; // Dodaj resztę sekund do minut
                        double wynik = stopnie + (minuty / 60);
                        ekran.Text = wynik.ToString();
                    }
                    else
                    {
                        // Obsługa błędu
                        MessageBox.Show("Nieprawidłowy format danych.");
                    }
                }
                else
                {
                    // Nieprawidłowa liczba argumentów
                    MessageBox.Show("Nieprawidłowa liczba argumentów.");
                }
            }
        }

        private void Deg_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ekran.Text))
            {
                string wyrazenie = ekran.Text;
                double wynik;

                if (wyrazenie.Contains(","))
                {
                    // Zamiana przecinka na kropkę
                    wyrazenie = wyrazenie.Replace(',', '.');
                }

                if (double.TryParse(wyrazenie, out wynik))
                {
                    double stopnie = Math.Truncate(wynik);
                    double minuty = Math.Truncate((wynik - stopnie) * 60);
                    double sekundy = ((wynik - stopnie) * 60 - minuty) * 60;

                    ekran.Text = $"{stopnie},{minuty},{sekundy}";
                }
                else
                {
                    // Obsługa błędu
                    MessageBox.Show("Nieprawidłowy format danych.");
                }
            }
        }

        private void Nawiasl_Click(object sender, RoutedEventArgs e)
        {
            dane.Add("(");
            ekran.Text += "(";
            openedBracketsCount++;
        }

        private void Nawiasp_Click(object sender, RoutedEventArgs e)
        {
            dane.Add(")");
            ekran.Text += ")";
            openedBracketsCount--;
        }

        private void Silnia_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ekran.Text))
            {
                int value = int.Parse(ekran.Text);

                if (value >= 0)
                {
                    int result = ObliczSilnie(value);
                    ekran.Text = result.ToString();
                }
                else
                {
                    // Obsługa błędu dla wartości ujemnych
                    MessageBox.Show("Silnia jest zdefiniowana tylko dla liczb nieujemnych.");
                }
            }
        }

        private int ObliczSilnie(int n)
        {
            if (n == 0)
                return 1;
            else
                return n * ObliczSilnie(n - 1);
        }


        private void Jedendox_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ekran.Text))
            {
                double value = double.Parse(ekran.Text);

                if (value != 0)
                {
                    double result = ObliczOdwrotnosc(value);
                    ekran.Text = result.ToString();
                }
                else
                {
                    // Obsługa błędu dla wartości zero
                    MessageBox.Show("Nie można obliczyć odwrotności liczby zero.");
                }
            }
        }

        private double ObliczOdwrotnosc(double x)
        {
            return 1 / x;
        }

        private void Dycha_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ekran.Text))
            {
                double value = double.Parse(ekran.Text);

                double result = Math.Pow(10, value);

                ekran.Text = result.ToString();
            }
        }

        private void xdoy_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ekran.Text))
            {
                double x = double.Parse(ekran.Text);

                if (!string.IsNullOrEmpty(ekran.Text))
                {
                    double y = double.Parse(ekran.Text);

                    double result = Math.Pow(x, y);

                    ekran.Text = result.ToString();
                }
                else
                {
                    // Obsługa błędu dla braku wartości y
                    MessageBox.Show("Wprowadź wartość dla y.");
                }
            }
            else
            {
                // Obsługa błędu dla braku wartości x
                MessageBox.Show("Wprowadź wartość dla x.");
            }
        }
    }
}
