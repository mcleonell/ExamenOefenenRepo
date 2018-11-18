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
    /// Interaction logic for VakSelectionPage.xaml
    /// </summary>
    public partial class VakSelectionPage : Page
    {

        bool vakSelected = false;

        public VakSelectionPage()
        {
            InitializeComponent();
            FillUserList();
        }
        #region events
        #region btnClicks
        private void btnCreateNewVak_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Pages/CreateVakPage.xaml", UriKind.Relative));
        }
        private void btnSelecteer_Click(object sender, RoutedEventArgs e)
        {
            if (vakSelected)
            {
                NavigationService.Navigate(new Uri("Pages/VragenPage.xaml", UriKind.Relative));
            }
            else
            {
                lblError.Content = "Please select a course first.";
            }
        }
        #endregion
        #region selectionChanged
        private void lstVakken_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Vak.CurrentVak = User.CurrentUser.Vakken(User.CurrentUser.UserID).Find(x => x.VakNaam == lstVakken.SelectedItem.ToString());
            tbVakbeschrijving.Text = Vak.CurrentVak.VakBeschrijving;
            vakSelected = true;
        }
        #endregion
        #endregion

        #region methods
        void FillUserList()
        {
            foreach (var vak in User.CurrentUser.Vakken(User.CurrentUser.UserID))
            {
                lstVakken.Items.Add(vak.VakNaam);
            }
        }
        #endregion

    }
}
