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
        public MainWindow()
        {
            InitializeComponent();
            FillUserList();
        }

        void FillUserList()
        {
            foreach (User user in User.UserList())
            {
                ListItem lstItem = new ListItem();
                // TODO - geef ieder listitem een text (UserList.username) en een value (UserList.userID)
            }
        }

        void FillVakkenList()
        {
            // TODO - Get user ID other way, not by list selected index
            lstVakken.Items.Clear();
            Vak v = new Vak();
            foreach(Vak vak in v.CurrentUserVakken(1))
            {
                lstVakken.Items.Add(vak.VakNaam);
            }
        }

        bool CreateUserCheck(string _input)
        {
            if (_input != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // TODO - Open vakken selectie
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string userInput = txtNewUsername.Text;
            if (CreateUserCheck(userInput))
            {
                User u = new User();
                u.CreateUser(userInput);
            }
            else
            {
                MessageBox.Show("Username mag niet leeg zijn.");
            }
        }

        private void btnLaadVakken_Click(object sender, RoutedEventArgs e)
        {
            FillVakkenList();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            lstUsers.Items.Clear();
            FillUserList();
        }
    }
}
