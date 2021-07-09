using ConsoleApplication5.Models;
using ConsoleApplication5.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5.Modules.HHRR.Hiring
{
    public class Hiring
    {
        public static void Form()
        {
            Employee employee = new Employee();
            employee.CardId = Forms.CaptureWithParse<int>("Introduzca su Cedula: ");
            employee.Name = Forms.Capture("Introduzca su nombre completo: ");
            employee.Department = Forms.Capture("Introduzca el departamento: ");
            employee.Role = Forms.Capture("Introduzca el cargo: ");
            employee.Salary = Forms.CaptureWithParse<int>("Introduzca el salario: ");
            EmployeeService.Insert(employee);
            Console.WriteLine("El candidado se ha registrado correctamente!!!!!!!!!!!!!!!!!!!!\nPresione una tecla para continuar... rata");
        }
    }
}
