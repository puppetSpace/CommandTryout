using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
	public class AuditService : IAuditService
	{
		public Task Write()
		{
			Console.WriteLine($"User {Environment.UserName} performed an action");
			return Task.CompletedTask;
		}
	}
}
