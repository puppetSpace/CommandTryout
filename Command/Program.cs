using System;
using System.Threading.Tasks;

namespace Command
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var device = new SwitchDevice();
			var commandHandler = new VlanChangeCommandHandler(new AuditService());

			await commandHandler.Execute(new VlanChangeCommand(device, new VlanChangeCommandData("12", "fddd")));
			await commandHandler.Execute(new VlanChangeCommand(device, new VlanChangeCommandData("32", "dksdklf")));

			await commandHandler.Undo();

			await commandHandler.Execute(new VlanChangeCommand(device, new VlanChangeCommandData("1", "dkdsdsddklf")));
			await commandHandler.Execute(new VlanChangeCommand(device, new VlanChangeCommandData("34", "fsdf")));

			await commandHandler.Undo();

			await commandHandler.Execute(new VlanChangeCommand(device, new VlanChangeCommandData("54", "sdf")));
			await commandHandler.Execute(new VlanChangeCommand(device, new VlanChangeCommandData("43", "sdfsfd")));

		}
	}
}
