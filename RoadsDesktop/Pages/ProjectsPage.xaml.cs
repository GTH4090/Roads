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
    /// Логика взаимодействия для ProjectsPage.xaml
    /// </summary>
    public partial class ProjectsPage : Page
    {
        public ProjectsPage()
        {
            InitializeComponent();
            projectDataGrid.DataContext = Db.Project.ToList();
        }

        private void projectDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                var item = projectDataGrid.SelectedItem as Project;
                projectHistoryDataGrid.DataContext = item.ProjectHistory;
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }
    }
}
