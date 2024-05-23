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
using static RoadsDesktop.Classes.Helper;
using RoadsDesktop.Models;

namespace RoadsDesktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeeMissesPage.xaml
    /// </summary>
    public partial class EmployeeMissesPage : Page
    {
        public EmployeeMissesPage()
        {
            InitializeComponent();
        }
        private void loadEmps()
        {

            try
            {
                missDataGrid.ItemsSource = Db.Miss.ToList();


            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            loadEmps();
        }

        

        private void missDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                ReplaceBtn.Visibility = Visibility.Visible;

                var item = missDataGrid.SelectedItem as Miss;

                grid1.DataContext = item.Employee;
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void ReplaceBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var item = missDataGrid.SelectedItem as Miss;
                grid1.DataContext = item.Employee1;
                ReplaceBtn.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }
    }
}
