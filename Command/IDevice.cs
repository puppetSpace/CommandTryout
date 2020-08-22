using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public interface IDevice
    {
        Task DoSomething(string port,string vlan);

        Task<string> GetCurrentValueOfPort(string port);
    }
}
