using AppManagement.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
            List<Professions> professions = ProgectEntities1.GetContext().Professions.ToList();
            List<Exams> exams = ProgectEntities1.GetContext().Exams.ToList();
            foreach (Professions p in professions)
            {
                ProfessionBox.Items.Add(p.Profession);
            }

            foreach (Exams e in exams)
            {
                ExamBox.Items.Add(e.Exam);
            }

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if(FullNameBox.Text ==string.Empty || PassportNumber.Text == string.Empty || PhoneBox.Text == string.Empty || ProfessionBox.Text == string.Empty || ExamBox.Text == string.Empty)
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else
            {
                DB.Application application = new DB.Application();
                application.FullName = FullNameBox.Text;
                application.PassportNumber = PassportNumber.Text;
                application.Phone = PhoneBox.Text;
                application.idProfession = ProgectEntities1.GetContext().Professions.Where(p => p.Profession == ProfessionBox.Text).ToList()[0].idProfession;
                application.idExam = ProgectEntities1.GetContext().Exams.Where(p => p.Exam == ExamBox.Text).ToList()[0].idExam;
                application.idStatus = 1;
                ProgectEntities1.GetContext().Application.Add(application);
                ProgectEntities1.GetContext().SaveChanges();
                Close();
            }

        }


    }
}
