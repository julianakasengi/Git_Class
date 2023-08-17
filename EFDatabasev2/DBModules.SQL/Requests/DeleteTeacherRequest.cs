using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Requests
{
    public class DeleteTeacherRequest
    {
        public Guid TeacherId { get; internal set; }
    }
}
