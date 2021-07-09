using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5.Models
{
    class Pays
	{
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }
        public int Incentives { get; set; }
        public int AFP { get; set; }
        public int ARS { get; set; }
        public int Discounts { get; set; }
        public int NetIncome { get; set; }
    }
}
