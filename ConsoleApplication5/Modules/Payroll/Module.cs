using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5.Modules.Payroll
{
    //Con esta funcionalidad, se pretende agregar un descuento o un incentivo(excepcionales) a determinado empleado. (Debe brindarse la opcion de elegir cuál acción ha de realizarse). Al momento de ingresar alguno de estos se debe agregar el monto y el concepto.Por ejemplo: Descuento: 1000, Concepto: Ausencia no justificada.La idea es que el descuento o incentivo que se haya agregado para determinado empleado, sea tomado en cuenta al momento de hacer el pago.
    interface IAction
    {

    }
//Aquí se pretende aplicar el pago a los empleados existentes.El procedimiento de pago tomará en cuenta lo siguiente:
//Ingresos:
//Salario (el salario del empleado)
//(Si tiene registrada una acción de personal[incentivo], debe salir reflejada aquí )
//Deducciones:
//2.87% por concepto de AFP
//3.01% por concepto de ARS
//(Si tiene registrada una acción de personal[descuento], debe salir reflejada aquí)
//El procedimiento de pago será automático.Cuando se ejecute, tomará a los empleados existentes y les realizará el cálculo correspondiente según lo antes descrito.
//Debe incluir una opción de imprimir la nómina, la cual consistirá en imprimir (en un archivo de excel) un listado mostrando lo siguiente de cada empleado:
//Nombre: Fulano
//Departamento: Tal
//Salario: XXX
//Otros ingresos: XXX(0 si no tiene)
//AFP: XXX
//ARS: XXX
//Otros descuentos: XXX(0 si no tiene)
//Sueldo neto: XXX
    interface IPay
    {

    }
}
