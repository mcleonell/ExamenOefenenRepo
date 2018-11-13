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
            User u = new User();
            foreach(string username in u.UsernameList())
            {
                lstUsers.Items.Add(username);
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
    }
}
