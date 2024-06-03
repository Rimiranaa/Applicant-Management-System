using AppManagement.DB;
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
using System.Windows.Shapes;

namespace AppManagement.Views
{
    /// <summary>
    /// Логика взаимодействия для AddApplicantWindow.xaml
    /// </summary>
    public partial class AddApplicantWindow : Window
    {
        public AddApplicantWindow()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            Users users = new Users();
            users.Login = LoginBox.Text;
            users.Password = PasswordBox.Text;
            users.idRole = 3;
            ProgectEntities1.GetContext().Users.Add(users);
            ProgectEntities1.GetContext().SaveChanges();
            Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
