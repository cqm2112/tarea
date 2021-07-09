using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication5.Models;
using ConsoleApplication5.Services;
using Newtonsoft.Json;

namespace ConsoleApplication5.Modules.HHRR
{
    class Permission
    {
        public static void Form()
        {
            Employee employee = EmployeeService.CaptureEmployeeCardId();
            if (employee == null)
            {
                Console.WriteLine("No existe");
                Form();
                return;
            }
            EmployeeService.ShowEmployeeData(employee);
            employee.Permission = Forms.CaptureWithParse<DateTime>("Introduzca la fecha del permiso: ").ToString("yyyy-MM-dd");
            employee.PerReason = Forms.Capture("Introduzca la razón del permiso: ");
            EmployeeService.Update(employee);
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
