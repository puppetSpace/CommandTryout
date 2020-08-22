using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public readonly struct VlanChangeCommandData
    {
		public VlanChangeCommandData(string portNumber, string vlan)
		{
			PortNumber = portNumber;
			Vlan = vlan;
		}

		public string PortNumber { get; }

		public string Vlan { get;}
	}
}
