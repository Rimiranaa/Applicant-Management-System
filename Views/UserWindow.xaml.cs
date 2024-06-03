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
using static System.Net.Mime.MediaTypeNames;

namespace AppManagement.Views
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
            List<Roles> roles = ProgectEntities1.GetContext().Roles.ToList();
            foreach (Roles e in roles)
            {
                RoleBox.Items.Add(e.Role);
            }

        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            Users users = new Users();
            users.Login = LoginBox.Text;
            users.Password = PasswordBox.Text;
            users.idRole = ProgectEntities1.GetContext().Roles.Where(p => p.Role == RoleBox.Text).ToList()[0].idRole;
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
