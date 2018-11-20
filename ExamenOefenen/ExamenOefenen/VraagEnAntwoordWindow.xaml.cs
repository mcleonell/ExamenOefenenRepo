using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ExamenOefenen
{
    /// <summary>
    /// Interaction logic for VraagEnAntwoordWindow.xaml
    /// </summary>
    public partial class VraagEnAntwoordWindow : Window
    {
        int vragenCounter = 0;
        bool isAntwoord = true;

        public VraagEnAntwoordWindow()
        {
            InitializeComponent();
            tbVraagAntwoord.Text = Vak.CurrentVak.Vragen()[vragenCounter].Antwoord;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (vragenCounter == Vak.CurrentVak.Vragen().Count - 2)
            {
                btnNext.Visibility = Visibility.Hidden;
            }
            if (vragenCounter < Vak.CurrentVak.Vragen().Count -1)
            {
                vragenCounter++;
                tbVraagAntwoord.Text = Vak.CurrentVak.Vragen()[vragenCounter].Vraagstuk;
                lblVraagnummer.Content = vragenCounter + 1;
            }
            else
            {
                vragenCounter = 0;
            }
        }

        private void btnAntwoord_Click(object sender, MouseButtonEventArgs e)
        {
            if(!isAntwoord)
            {
                tbVraagAntwoord.Text = Vak.CurrentVak.Vragen()[vragenCounter].Antwoord;
                isAntwoord = true;
            }
            else
            {
                tbVraagAntwoord.Text = Vak.CurrentVak.Vragen()[vragenCounter].Vraagstuk;
                isAntwoord = false;
            }
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAntwoord_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
