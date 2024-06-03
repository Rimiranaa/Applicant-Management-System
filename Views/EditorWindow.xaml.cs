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
    /// Логика взаимодействия для EditorWindow.xaml
    /// </summary>
    public partial class EditorWindow : Window
    {
        public EditorWindow()
        {
            InitializeComponent();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            AddApplicantWindow addApplicantWindow = new AddApplicantWindow();
            addApplicantWindow.ShowDialog();
            Table.ItemsSource = null;
            Table.ItemsSource = ProgectEntities1.GetContext().Application.ToList();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            DB.Application selected = (DB.Application)Table.SelectedItem;

            if (selected == null)
            {
                MessageBox.Show("Для редактирования необходимо выбрать элемент.");
            }
            else
            {
                EditWindow editWindow = new EditWindow(selected.id);
                editWindow.ShowDialog();
                Table.ItemsSource = null;
                Table.ItemsSource = ProgectEntities1.GetContext().Application.ToList();
            }
        }

        private void EditProfession_Click(object sender, RoutedEventArgs e)
        {
            ProfessionWindow professionWindow = new ProfessionWindow();
            professionWindow.ShowDialog();
        }

        private void EditExam_Click(object sender, RoutedEventArgs e)
        {
            ExamWindow examWindow = new ExamWindow();
            examWindow.ShowDialog();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
