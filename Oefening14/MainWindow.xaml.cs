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
using System.Windows.Threading;

namespace Oefening14
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = "Leeftijd in jaren, maanden en dagen voor " + DateTime.Today.ToLongDateString();

            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            LblTijd.Content = DateTime.Now.ToString("dddd dd MMMM yyyy  HH:mm:ss");
        }

        private void BtnBereken_Click(object sender, RoutedEventArgs e)
        {
            DateTime geboorteDatum;

            if(DateTime.TryParse(TxtGeboorte.Text, out geboorteDatum))
            {
                //berekening
                TimeSpan verschil = DateTime.Today - geboorteDatum;
                TxtDagen.Text = verschil.Days.ToString();

                int geboorteJaar = geboorteDatum.Year; 
                int huidigJaar = DateTime.Today.Year; //2023

                int aantalMaanden = 0;
                int aantalJaren = 0;

                //berekening maanden/jaren:
                if(geboorteDatum.Month < DateTime.Today.Month && geboorteDatum.Day < DateTime.Today.Day)
                {
                    aantalJaren = (huidigJaar - geboorteJaar);
                    //TODO: aantalMaanden = 
                }
                else
                {
                    aantalJaren = (huidigJaar - geboorteJaar - 1);
                    //TODO: aantalMaanden = 
                }

                TxtMaanden.Text = aantalMaanden.ToString();
                TxtJaren.Text = aantalJaren.ToString();

            }
            else
            {
                MessageBox.Show("Ongeldige datum");
            }


        }
    }
}
