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

    public partial class ApplicantWindow : Window
    {
        public ApplicantWindow()
        {
            InitializeComponent();
            Table.ItemsSource = ProgectEntities1.GetContext().Application.ToList();

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();
            Table.ItemsSource = null;
            Table.ItemsSource = ProgectEntities1.GetContext().Application.ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
