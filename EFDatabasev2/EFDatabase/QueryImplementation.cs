using DBModules.SQL.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDatabase
{
    public class QueryImplementation
    {
        private readonly IStudentCommands _studentCommands;

        public QueryImplementation(IStudentCommands studentCommands)
        {
            _studentCommands = studentCommands;
        }
        public async Task UserInteractions()
        {

        }
    }
}
