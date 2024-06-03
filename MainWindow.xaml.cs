using AppManagement.DB;
using AppManagement.Views;
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

namespace AppManagement
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            if (LoginBox.Text == string.Empty || PasswordBox.Text == string.Empty)
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else
            {
                List<Users> users = ProgectEntities1.GetContext().Users.ToList();
                foreach (Users u in users)
                {
                    if (LoginBox.Text == u.Login && PasswordBox.Text == u.Password)
                    {
                        flag = true;
                        if (u.idRole == 1)
                        {
                            AdminWindow adminWindow = new AdminWindow();
                            adminWindow.Show();
                            Close();
                            break;
                        }
                        else if (u.idRole == 2)
                        {
                            EditorWindow editorWindow = new EditorWindow();
                            editorWindow.Show();
                            Close();
                            break;
                        }
                        else if (u.idRole == 3)
                        {
                            ApplicantWindow applicantWindow = new ApplicantWindow();
                            applicantWindow.Show();
                            Close();
                            break;
                        }
                        

                    }
                }
                if (flag == false)
                {
                    MessageBox.Show("Логин или пароль неверны");
                }
            }
        }


        private void Guest_Click(object sender, RoutedEventArgs e)
        {
            GuestWindow guestWindow = new GuestWindow();
            guestWindow.Show();
            Close();
        }

        private void Registr_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            if (LoginBox.Text == string.Empty || PasswordBox.Text == string.Empty)
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else
            {
                List<Users> users = ProgectEntities1.GetContext().Users.ToList();
                foreach (Users u in users)
                {
                    if(LoginBox.Text == u.Login && PasswordBox.Text == u.Password)
                    {
                        MessageBox.Show("Данный пользователь уже существует");
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    Users user = new Users();
                    user.Login = LoginBox.Text;
                    user.Password = PasswordBox.Text;
                    user.idRole = 3;

                    ProgectEntities1.GetContext().Users.Add(user);
                    ProgectEntities1.GetContext().SaveChanges();
                    ApplicantWindow applicantWindow = new ApplicantWindow();
                    applicantWindow.Show();
                    Close();
                }
                
            }
        }
    }
}
