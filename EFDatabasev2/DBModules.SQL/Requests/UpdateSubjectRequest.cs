using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Requests
{
    public class UpdateSubjectRequest
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public Guid TeacherId { get; set; }
    }
}
