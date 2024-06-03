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

    public partial class EditWindow : Window
    {
        int _id;
        DB.Application app;
        public EditWindow(int id)
        {
            InitializeComponent();
            _id = id;
            app = ProgectEntities1.GetContext().Application.Where(a => a.id == _id).ToList()[0];
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
            List<Status> status = ProgectEntities1.GetContext().Status.ToList();
            foreach (Status s in status)
            {
                StatusBox.Items.Add(s.Title);
            }
            FullNameBox.Text = app.FullName;
            PassportNumber.Text = app.PassportNumber;
            PhoneBox.Text = app.Phone;
            ProfessionBox.Text = ProgectEntities1.GetContext().Professions.Where(p => p.idProfession == app.idProfession).ToList()[0].Profession;
            ExamBox.Text = ProgectEntities1.GetContext().Exams.Where(e => e.idExam == app.idExam).ToList()[0].Exam;
            StatusBox.Text = ProgectEntities1.GetContext().Status.Where(s => s.idStatus == app.idStatus).ToList()[0].Title;

        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            List<DB.Application> application = ProgectEntities1.GetContext().Application.Where(a => a.id == _id).ToList();
            application[0].FullName = FullNameBox.Text;
            application[0].PassportNumber = PassportNumber.Text;
            application[0].Phone = PhoneBox.Text;
            application[0].idProfession = ProgectEntities1.GetContext().Professions.Where(p => p.Profession == ProfessionBox.Text).ToList()[0].idProfession;
            application[0].idExam = ProgectEntities1.GetContext().Exams.Where(ex => ex.Exam == ExamBox.Text).ToList()[0].idExam;
            application[0].idStatus = ProgectEntities1.GetContext().Status.Where(s => s.Title == StatusBox.Text).ToList()[0].idStatus;
            ProgectEntities1.GetContext().SaveChanges();
            MessageBox.Show("Успешно сохранено!");
            Close();


        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ProgectEntities1.GetContext().Application.Remove(app);
            ProgectEntities1.GetContext().SaveChanges();
            MessageBox.Show("Удаление прошло успешно");
            Close();

        }

        
    }
}
