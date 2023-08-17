using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Requests
{
    public class UpdateTeacherRequest
    {
        public string Title { get; set; }
        public string FullName { get; set; }
        public int TscNumber { get; set; }
        public Guid SchoolId { get; set; }
        public Guid TeacherId { get; internal set; }
    }
}
