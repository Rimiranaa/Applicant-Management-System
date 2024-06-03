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
    /// Логика взаимодействия для ExamWindow.xaml
    /// </summary>
    public partial class ExamWindow : Window
    {
        public ExamWindow()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            Exams exams = new Exams();
            exams.Exam = ExamBox.Text;
            ProgectEntities1.GetContext().Exams.Add(exams);
            ProgectEntities1.GetContext().SaveChanges();
            MessageBox.Show("Экзамен успешно добавлен!");
            Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
