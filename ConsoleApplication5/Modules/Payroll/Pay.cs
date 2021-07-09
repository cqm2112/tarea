using ClosedXML.Excel;
using ConsoleApplication5.Models;
using ConsoleApplication5.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5.Modules.Payroll
{
    class Pay
    {
        public static void Process()
        {
            Console.Write("¿Seguro qué desea generar los pagos? [S/N]: ");
            bool yes = Console.ReadLine().ToUpper() == "S";
            if (yes)
            {
                Console.WriteLine("Generando pagos....");
                IEnumerable<Employee> employees = EmployeeService.GetAll();
                foreach (var employee in employees)
                {
                    int afp = (int)((2.87 / 100) * employee.Salary);
                    int ars = (int)((3.01 / 100) * employee.Salary);
                    int incentives = EmployeesDetailsService.GetIncentives(employee.CardId);
                    int discounts = EmployeesDetailsService.GetDiscounts(employee.CardId);
                    int netIncome = (employee.Salary + incentives) - (afp + ars + discounts);

                    var pay = new Pays()
                    {
                        EmployeeName = employee.Name,
                        Department = employee.Department,
                        Salary = employee.Salary,
                        Incentives = incentives,
                        AFP = afp,
                        ARS = ars,
                        Discounts = discounts,
                        NetIncome = netIncome
                    };

                    PaysService.Insert(pay);
                }
                Console.WriteLine("Pagos generados!");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
        public static void Excel()
        {
            Console.Write("¿Seguro qué desea exportar los pagos generados a excel? [S/N]: ");
            bool yes = Console.ReadLine().ToUpper() == "S";
            if (yes)
            {
                Console.WriteLine("Generando excel...");
                XLWorkbook wb = new XLWorkbook();
                wb.Worksheets.Add(PaysService.GetDataTable(), "WorksheetName");
                wb.SaveAs($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/pays-{DateTime.Now.ToFileTime()}.xlsx");
                Console.WriteLine("Excel exportado en el escritorio!");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
