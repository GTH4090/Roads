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

namespace RoadsDesktop.Classes
{
    /// <summary>
    /// Логика взаимодействия для LearningCalendar.xaml
    /// </summary>
    public partial class LearningCalendar : Page
    {
        DateTime start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        DateTime end = new DateTime();
        public LearningCalendar()
        {
            end = start.AddMonths(1).AddDays(-1);
            InitializeComponent();

            DateLb.Content = start.ToString("yyyy MMMM");
            loadСalendar();
        }

        private void loadСalendar()
        {

            try
            {
                Calendar.Children.Clear();
                
                var items = Db.Event.ToList();
                var date = start;

               

                for (int i = 1; i <= 6; i++)
                {
                    
                    for(int j = 0; j < 7; j++)
                    {
                        if(i == 1 && j == 0)
                        {
                            j = (int)start.AddDays(-1).DayOfWeek;
                        }
                        if(date <= end)
                        {
                            if (items.FirstOrDefault(el => el.TypeId == 1 && el.DateStart == date) == null)
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
                                var item = items.FirstOrDefault(el => el.TypeId == 1 && el.DateStart == date);
                                Button label = new Button();
                                label.Width = double.NaN;

                                label.Content = date.ToString("d");
                                Grid.SetColumn(label, j);
                                Grid.SetRow(label, i);
                                label.Tag = item;
                                label.Click += Label_Click;
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


            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        private void Label_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void PrevBtn_Click(object sender, RoutedEventArgs e)
        {
            start = start.AddMonths(-1);
            end = start.AddMonths(1).AddDays(-1);
            loadСalendar();
            DateLb.Content = start.ToString("yyyy MMMM");

        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            start = start.AddMonths(1);
            end = start.AddMonths(1).AddDays(-1);
            loadСalendar();
            DateLb.Content = start.ToString("yyyy MMMM");

        }
    }
}
