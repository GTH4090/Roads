using RoadsDesktop.Classes;
using RoadsDesktop.Pages;
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

namespace RoadsDesktop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            TitleLb.Content = (e.Content as Page).Title;

            if(MainFrame.CanGoBack)
            {
                BackBtn.Visibility = Visibility.Visible;
            }
            else
            {
                BackBtn.Visibility = Visibility.Hidden;
            }
        }

        private void EmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new EmployeeList());
        }

        private void LearningsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new LearningCalendar());
        }

        private void UserFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void MissesBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new EmployeeMissesPage());
        }

        private void ProjectBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProjectsPage());
        }
    }
}
