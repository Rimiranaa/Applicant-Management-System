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
    /// Логика взаимодействия для ProfessionWindow.xaml
    /// </summary>
    public partial class ProfessionWindow : Window
    {
        public ProfessionWindow()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            Professions professions = new Professions();
            professions.Profession = ProfessionBox.Text;
            ProgectEntities1.GetContext().Professions.Add(professions);
            ProgectEntities1.GetContext().SaveChanges();
            MessageBox.Show("Специальность успешно добавлена!");
            Close();

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
