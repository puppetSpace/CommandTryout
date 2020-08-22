using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
	public class VlanChangeCommand : ICommand
	{
		private readonly IDevice _device;
		private readonly VlanChangeCommandData _vlanChangeCommandData;
		private string _previousValue;

		public VlanChangeCommand(IDevice device, VlanChangeCommandData vlanChangeCommandData)
		{
			_device = device;
			_vlanChangeCommandData = vlanChangeCommandData;
		}

		public async Task Execute()
		{
			var previousValue = await _device.GetCurrentValueOfPort(_vlanChangeCommandData.PortNumber);
			if (!string.IsNullOrWhiteSpace(previousValue))
				_previousValue = previousValue;

			await _device.DoSomething(_vlanChangeCommandData.PortNumber, _vlanChangeCommandData.Vlan);
		}

		public async Task Undo()
		{
			await _device.DoSomething(_vlanChangeCommandData.PortNumber, _previousValue);
		}
	}
}
