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
    /// Логика взаимодействия для EmployeeList.xaml
    /// </summary>
    public partial class EmployeeList : Page
    {
        private void loadData()
        {

            try
            {
                var items = Db.Employee.ToList().Where(el => el.HeadId == null).OrderBy(el => el.LastName).ToList();

                if(subdivisionTw.SelectedItem != null)
                {
                    var item = subdivisionTw.SelectedItem as Subdivision;
                    items = items.Where(el => el.SubdivisionId == item.Id).ToList();
                }
                

                employeeDataGrid.ItemsSource = items;
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }
        public EmployeeList()
        {
            InitializeComponent();
            loadData();

            var items = Db.Subdivision.ToList();
            items.Insert(0, new Subdivision() { Name = "Все" });
            subdivisionTw.ItemsSource = Db.Subdivision.Where(el => el.HeadId == null).ToList();
        }

        
        private void employeeDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                var item = employeeDataGrid.SelectedItem as Employee;
                employeeDataGrid.Visibility = Visibility.Collapsed;
                EmpSp.Visibility = Visibility.Visible;
                EmpSp.DataContext = item;
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void SubdivisionCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadData();
        }

        private void employeeDataGrid_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            loadData();
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            employeeDataGrid.Visibility = Visibility.Visible;
            EmpSp.Visibility = Visibility.Collapsed;

        }
    }
}
