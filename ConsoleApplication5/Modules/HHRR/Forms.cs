using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5.Modules.HHRR
{
    static class Forms
    {
        public static string Capture(string msg)
        {
            Console.Write(msg);
            return Console.ReadLine();
        }

        public static T CaptureWithParse<T>(string msg)
        {
            bool isValid = false;
            object parsedValue = null;
            while (!isValid)
            {
                try
                {
                    string value = Capture(msg);
                    parsedValue = Convert.ChangeType(value, typeof (T));
                    isValid = true;
                }
                catch(Exception)
                {
                    Console.WriteLine("Los datos insertados son incorrectos");
                }
            }
            return (T) parsedValue;
        }
    }
}
