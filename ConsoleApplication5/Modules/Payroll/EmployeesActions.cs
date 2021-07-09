using ConsoleApplication5.Models;
using ConsoleApplication5.Modules.HHRR;
using ConsoleApplication5.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5.Modules.Payroll
{
    class EmployeesActions
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
            var employeeDetail = new EmployeeDetails();
            employeeDetail.EmployeeCardId = employee.CardId;
            employeeDetail.ActionType = GetActionType();
            employeeDetail.Value =
                Forms.CaptureWithParse<int>($"Digite el valor del {(employeeDetail.ActionType == "D" ? "descuento" : "incentivo")}: ");
            employeeDetail.Concept = Forms.Capture("Digite el concepto: ");
            EmployeesDetailsService.Insert(employeeDetail);
            Console.WriteLine("Accion guardada correctamente");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static string GetActionType()
        {
            while(true)
            {
                Console.Write("Digite el tipo de acción [(D)escuento/(I)ncentivo]: ");
                string action = Console.ReadLine().ToUpper();
                if (action != "D" && action != "I")
                {
                    Console.WriteLine("El valor debe ser I o D.");
                    continue;
                }
                return action;
            }
        }
    }
}
