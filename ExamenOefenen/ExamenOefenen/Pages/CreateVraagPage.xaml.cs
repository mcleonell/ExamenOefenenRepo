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

namespace ExamenOefenen
{
    /// <summary>
    /// Interaction logic for CreateVraagPage.xaml
    /// </summary>
    public partial class CreateVraagPage : Page
    {
        public CreateVraagPage()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string vraag = txtQuestion.Text;
            string antwoord = txtAnswer.Text;

            if (vraag != "" && antwoord != "")
            {
                if (Vraag.DoesntExist(vraag, Vak.CurrentVak.VakID))
                {
                    Vraag.Create(vraag, antwoord, Vak.CurrentVak.VakID);
                    MessageBox.Show("New question created!");
                    NavigationService.GoBack();
                }
                else
                {
                    lblError.Content = "Course already exists, pick a different name.";
                }
            }
            else if (vraag != "" && antwoord == "")
            {
                lblError.Content = "Please add a answer to the question.";
            }
            else if (vraag == "" && antwoord != "")
            {
                lblError.Content = "A answer without a question, hmmmm...";
            }
            else
            {
                lblError.Content = "No input detected.";
            }
        }
    }
}
