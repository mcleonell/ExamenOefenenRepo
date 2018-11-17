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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region vars
        User CurrentUser()
        {
            return User.AllUsers().Find(x => x.Username == lstUsers.SelectedItem.ToString());
        }
        Vak CurrentVak()
        {
            return CurrentUser().Vakken(CurrentUser().UserID).Find(x => x.VakNaam == lstVakken.SelectedItem.ToString());
        }
        Vraag CurrentVraag()
        {
            return CurrentVak().Vragen(CurrentVak().VakID).Find(x => x.Vraagstuk == lstVragen.SelectedItem.ToString());
        }
        #endregion vars

        public MainWindow()
        {
            InitializeComponent();
            FillUserList();
        }

        #region Events
        #region btnClicks
        private void btnAntwoord_Click(object sender, RoutedEventArgs e)
        {
            lblAntwoord.Content = CurrentVraag().Antwoord;
        }
        private void btnCreateUser_Click(object sender, RoutedEventArgs e)
        {
            string username = txtNewUsername.Text;

            if (User.DoesntExist(username))
            {
                User.Create(username);
                RefreshUserList();
            }
            else
            {
                MessageBox.Show("Username exists already, pick a different one.");
            }
        }
        private void btnCreateVak_Click(object sender, RoutedEventArgs e)
        {
            string vaknaam = txtVakNaam.Text;
            string vakBeschrijving = txtVakBeschrijving.Text;

            if (User.LoggedIn)
            {
                if (vaknaam != "" && vakBeschrijving != "")
                {
                    if (Vak.DoesntExist(vaknaam, CurrentUser().UserID))
                    {
                        Vak.Create(vaknaam, vakBeschrijving, CurrentUser().UserID);
                        RefreschVakkenList();
                    }
                    else
                    {
                        MessageBox.Show("Vak bestaat al voor deze user.");
                    }
                }
                else if (vaknaam != "" && vakBeschrijving == "")
                {
                    MessageBox.Show("Gelieve een beschrijving in te geven.");
                }
                else if (vaknaam == "" && vakBeschrijving != "")
                {
                    MessageBox.Show("Gelieve een vaknaam in te geven.");
                }
                else
                {
                    MessageBox.Show("Gelieve een vak naam alsook een beschrijving in te geven");
                }
            }
            else
            {
                MessageBox.Show("Gelieve eerst in te loggen.");
            }
        }
        private void btnCreateVraag_Click(object sender, RoutedEventArgs e)
        {
            string vraag = txtVraag.Text;
            string antwoord = txtAntwoord.Text;

            if (vraag != "" && antwoord != "")
            {
                if (Vraag.DoesntExist(vraag, CurrentVak().VakID))
                {
                    Vraag.Create(vraag, antwoord, CurrentVak().VakID);
                    RefreshVragenList();
                }
                else
                {
                    MessageBox.Show("Vraag bestaat al voor dit vak.");
                }
            }
            else if (vraag != "" && antwoord == "")
            {
                MessageBox.Show("Gelieve een antwoord in te vullen.");
            }
            else if (vraag == "" && antwoord != "")
            {
                MessageBox.Show("Gelieve een vraag in te vullen.");
            }
            else
            {
                MessageBox.Show("Gelieve een vraag alsook een antwoord in te vullen.");
            }
        }
        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            User.Delete(CurrentUser().UserID);
            RefreshUserList();
        }
        private void btnDeleteVak_Click(object sender, RoutedEventArgs e)
        {
            Vak.Delete(CurrentVak().VakID);
            RefreschVakkenList();
        }
        private void btnDeleteVraag_Click(object sender, RoutedEventArgs e)
        {
            Vraag.Delete(CurrentVraag().VraagID);
            RefreshVragenList();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(!User.LoggedIn)
            {
                lstUsers.IsEnabled = false;
                btnLogin.Content = "Logout";
                User.LoggedIn = true;
                FillVakkenList();
            }
            else
            {
                lstUsers.IsEnabled = true;
                lstVakken.Items.Clear();
                lstVragen.Items.Clear();
                btnLogin.Content = "Login";
                User.LoggedIn = false;
            }
        }
        private void btnSelectVak_Click(object sender, RoutedEventArgs e)
        {
            FillVragenList();
        }
        #endregion
        private void lstVakken_MouseUp(object sender, MouseButtonEventArgs e)
        {
            lblVakDescription.Content = CurrentVak().VakBeschrijving;
        }
        #region mouseUp
        #endregion
        #endregion


        #region methods
        void FillUserList()
        {
            foreach (var user in User.AllUsers())
            {
                lstUsers.Items.Add(user.Username);
            }
        }
        void FillVakkenList()
        {
            lstVakken.Items.Clear();
            foreach(var vak in CurrentUser().Vakken(CurrentUser().UserID))
            {
                lstVakken.Items.Add(vak.VakNaam);
            }
        }
        void FillVragenList()
        {
            lstVragen.Items.Clear();
            foreach(var vraag in CurrentVak().Vragen(CurrentVak().VakID))
            {
                lstVragen.Items.Add(vraag.Vraagstuk);
            }
        }
        void RefreshUserList()
        {
            lstUsers.Items.Clear();
            lstVakken.Items.Clear();
            lstVragen.Items.Clear();
            FillUserList();
        }
        void RefreschVakkenList()
        {
            lstVakken.Items.Clear();
            lstVragen.Items.Clear();
            FillVakkenList();
        }
        void RefreshVragenList()
        {
            lstVragen.Items.Clear();
            FillVragenList();
        }
        #endregion



    }
}
