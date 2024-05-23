using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadsDesktop.Models
{
    public partial class Employee
    {
        public string Name
        {
            get
            {
                return this.LastName + " " + this.FirstName + " " + this.Patronomic;
            }
            set { }
        }
    }
}
