using ConsoleApplication5.Models;
using ConsoleApplication5.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5.Modules.HHRR
{
    static class Vacations
    {
        public static void Form()
        {
            int cardId = Forms.CaptureWithParse<int>("Introduzca la cedula del empleado: ");
            Employee employee = EmployeeService.GetByCardId(cardId);
            Console.WriteLine("Nombre empleado:" + employee.Name);
            Console.WriteLine("Departamento empleado:" + employee.Department);
            Console.WriteLine("Cargo empleado:" + employee.Role);
            Console.WriteLine("Salario empleado:" + employee.Salary);
         

            if (employee == null)
            {
                Console.WriteLine("No existe");
                Form();
                return;
            }
            employee.DateVacationStart = Forms.CaptureWithParse<DateTime>("Introduzca la fecha de inicio: ").ToString("yyyy-MM-dd");
            employee.DateVacationEnd = Forms.CaptureWithParse<DateTime>("Introduzca la fecha fin: ").ToString("yyyy-MM-dd");
            employee.IsInVacation = 1;
            EmployeeService.Update(employee);
            Console.WriteLine("Presione cualquier tecla para continuar... rata");
        }
    }
}
