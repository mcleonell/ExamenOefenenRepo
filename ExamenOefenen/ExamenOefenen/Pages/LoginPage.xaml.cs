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
using System.Data.SqlClient;

namespace ExamenOefenen
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        bool userSelected = false;

        public LoginPage()
        {
            InitializeComponent();
            try
            {
                FillUserList();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error details: " + ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.connectionString))
                {
                    con.Close();
                }
            }
        }

        #region events
        #region btnClick
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(userSelected)
            {
                User.LoggedIn = true;
                User.CurrentUser = User.AllUsers().Find(x => x.Username == lstUsers.SelectedItem.ToString());
                NavigationService.Navigate(new Uri("Pages/VakSelectionPage.xaml", UriKind.Relative));
            }
            else
            {
                lblError.Content = "Please select a user first.";
            }
        }
        private void btnCreateNewUser_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Pages/CreateUserPage.xaml", UriKind.Relative));
        }
        #endregion
        #region selectionChanged
        private void lstUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            userSelected = true;
            lblSelectedUsername.Content = lstUsers.SelectedItem.ToString();
        }
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
        #endregion
    }
}
