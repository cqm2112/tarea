using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApplication5.Modules.HHRR
{
    public interface IPermission
    {
        bool SetPermission();
    }

    class Permission : IPermission
    {
        public bool SetPermission()
        {
            throw new NotImplementedException();
        }

    }
}
