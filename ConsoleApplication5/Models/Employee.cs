using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5.Models
{
    class Employee
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }
        public int Salary { get; set; }
        public short? IsInVacation { get; set; }
        public string DateVacationStart { get; set; }
        public string DateVacationEnd { get; set; }
    }
}
