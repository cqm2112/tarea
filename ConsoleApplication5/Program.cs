﻿using ConsoleApplication5.Modules.HHRR;
using ConsoleApplication5.Modules.HHRR.Hiring;
using ConsoleApplication5.Services;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq

;
using System.Threading;

namespace ConsoleApplication5
{
    class Program
    {
        static IEnumerable<string> GetEnabledModules()
        {
            string binPath = Path.GetDirectoryName(Environment.CurrentDirectory);
            using (StreamReader sr = new StreamReader(Path.Combine(binPath, "..", "modules.json")))
            {
                string jsonStr = sr.ReadToEnd();
                var data = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, bool>>>(jsonStr);
                Func<int, IEnumerable<KeyValuePair<string, bool>>> function = d => data.ElementAt(d).Value.Where(u => u.Value);
                return function(0).Concat(function(1)).Select(d => d.Key);
            }
        }

        static void Main()
        {
            DbContext.Up();
            var enabledModules = GetEnabledModules();
            var options = new List<Option>
            {
                new Option("a", "A - Contratacion", Hiring.Form, "Hiring"),
                new Option("b", "B - Vacaciones", Vacations.Form, "Vacations"),
                //new Option("c", "C - Accion", Vacations., "Action")
            }.Where(o => enabledModules.Contains(o.ID))
             .ToList();
            Menu.Render(options);
        }
    }

}
