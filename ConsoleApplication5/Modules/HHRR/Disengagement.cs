using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5.Modules.HHRR
{
    public interface IDisengagement
    {
        bool SetDisengagement();
    }

    class Disengagement : IDisengagement
    {
        public bool SetDisengagement()
        {
            throw new NotImplementedException();
        }

    }
}
