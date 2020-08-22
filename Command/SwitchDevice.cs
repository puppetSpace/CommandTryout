using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
	public class SwitchDevice : IDevice
	{
		private Dictionary<string, string> _state = new Dictionary<string, string>();

		public Task DoSomething(string port, string vlan)
		{
			Console.WriteLine($"vlan {vlan} attached to port {port}");
			_state[port] = vlan;
			return Task.CompletedTask;
		}

		public Task<string> GetCurrentValueOfPort(string port)
		{
			if (_state.ContainsKey(port))
				return Task.FromResult(_state[port]);
			else
				return Task.FromResult("");
		}
	}
}
