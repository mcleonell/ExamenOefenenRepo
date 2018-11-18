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
    /// Interaction logic for CreateVakPage.xaml
    /// </summary>
    public partial class CreateVakPage : Page
    {
        public CreateVakPage()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string vaknaam = txtVakNaam.Text;
            string vakBeschrijving = txtVakDescription.Text;

            if (vaknaam != "" && vakBeschrijving != "")
            {
                if (Vak.DoesntExist(vaknaam, User.CurrentUser.UserID))
                {
                    Vak.Create(vaknaam, vakBeschrijving, User.CurrentUser.UserID);
                    MessageBox.Show("New course created!");
                    NavigationService.GoBack();
                }
                else
                {
                    lblError.Content = "Course already exists, pick a different name.";
                }
            }
            else if (vaknaam != "" && vakBeschrijving == "")
            {
                lblError.Content = "Please add a brief description.";
            }
            else if (vaknaam == "" && vakBeschrijving != "")
            {
                lblError.Content = "Please add a name for the course.";
            }
            else
            {
                lblError.Content = "No input detected.";
            }
        }
    }
}
