using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public interface ICommandHandler<TE> where TE:ICommand
    {
        public Task Execute(TE command);

        public Task Undo();
    }
}
