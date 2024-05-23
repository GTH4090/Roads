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
using System.Windows.Threading;
using static RoadsDesktop.Classes.Helper;

namespace RoadsDesktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для LogginedPage.xaml
    /// </summary>
    public partial class LogginedPage : Page
    {

        DateTime start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        DateTime end = new DateTime();

        DispatcherTimer Timer = new DispatcherTimer();
        int _id;
        public LogginedPage(int id)
        {
            _id = id;
            Timer.Interval = new TimeSpan(0, 0, 5);
            Timer.Tick += Timer_Tick;
            Timer.Start();
            end = start.AddMonths(1).AddDays(-1);
            InitializeComponent();
            loadСalendar();
        }

        private void loadСalendar()
        {

            try
            {
                Calendar.Children.Clear();

                var items = Db.Meeting.Where(el => el.EmployeeId == _id).ToList();
                var date = start;



                for (int i = 1; i <= 6; i++)
                {

                    for (int j = 0; j < 7; j++)
                    {
                        if (i == 1 && j == 0)
                        {
                            j = (int)start.AddDays(-1).DayOfWeek;
                        }
                        if (date <= end)
                        {
                            if (items.FirstOrDefault(el => el.Date == date) == null)
                            {
                                Label label = new Label();
                                label.Width = double.NaN;
                                label.Content = date.ToString("d");
                                Grid.SetColumn(label, j);
                                Grid.SetRow(label, i);
                                Calendar.Children.Add(label);
                            }
                            else
                            {
                                var item = items.FirstOrDefault(el => el.Date == date);
                                Button label = new Button();
                                label.Width = double.NaN;
                                label.Background = Brushes.LawnGreen;

                                label.Content = date.ToString("d");
                                Grid.SetColumn(label, j);
                                Grid.SetRow(label, i);
                                
                                
                                Calendar.Children.Add(label);

                            }
                            date = date.AddDays(1);
                        }

                    }
                }
                var d = new DateTime(2024, 5, 20);
                for (int i = 0; i < 7; i++)
                {
                    Label label = new Label();
                    label.Width = double.NaN;
                    label.Content = d.DayOfWeek.ToString();
                    Grid.SetColumn(label, i);
                    Grid.SetRow(label, 0);
                    Calendar.Children.Add(label);
                    d = d.AddDays(1);
                }

                newsDataGrid.ItemsSource = Db.News.Where(el => el.EmployeeId == _id);

            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            loadСalendar();
        }
    }
}
