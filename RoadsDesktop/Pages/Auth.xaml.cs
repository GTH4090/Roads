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


namespace RoadsDesktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if(Db.Employee.FirstOrDefault(el => el.Code == CodeTbx.Text) != null)
                {
                    var item = Db.Employee.FirstOrDefault(el => el.Code == CodeTbx.Text);
                    NavigationService.Navigate(new LogginedPage(item.Id));
                }
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }
    }
}
