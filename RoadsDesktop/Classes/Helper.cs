using RoadsDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RoadsDesktop.Classes
{
    public class Helper
    {
        public static RoadsDbEntities Db = new RoadsDbEntities();

        public static void Error(string message = "Ошибка бд") 
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK , MessageBoxImage.Error);
        }

    }
}
