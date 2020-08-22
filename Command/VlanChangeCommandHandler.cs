using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
	public class VlanChangeCommandHandler : ICommandHandler<VlanChangeCommand>
	{
		private readonly Stack<VlanChangeCommand> _commands = new Stack<VlanChangeCommand>();
		private readonly IAuditService _auditService;

		public VlanChangeCommandHandler(IAuditService auditService)
		{
			_auditService = auditService;
		}

		public async Task Execute(VlanChangeCommand command)
		{
			await _auditService.Write();
			await command.Execute();
			_commands.Push(command);
		}

		public async Task Undo()
		{
			var currentCommand = _commands.Pop();
			if (currentCommand is object)
			{
				await _auditService.Write();
				await currentCommand.Undo();
			}
		}
	}
}
