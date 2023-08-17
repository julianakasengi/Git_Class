using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Results
{
    public class SubjectCreatedResults
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public Guid TeacherId { get; set; }

    }
}
