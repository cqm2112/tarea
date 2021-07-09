using ConsoleApplication5.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5.Modules.HHRR
{
    class Disengagement
    {
        public static void Form()
        {
            var employee = EmployeeService.CaptureEmployeeCardId();
            if (employee == null)
            {
                Console.WriteLine("No existe");
                Form();
                return;
            }
            EmployeeService.ShowEmployeeData(employee);
            Console.Write("Digite la causa: ");
            Console.ReadLine();
            Console.Write("¿Seguro que desea desvincular a este empleado? [S/N]: ");
            bool yes = Console.ReadLine().ToUpper() == "S";
            if(yes)
            {
                EmployeeService.Delete(employee.Id);
                Console.WriteLine("Empleado eliminado correctamente.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
