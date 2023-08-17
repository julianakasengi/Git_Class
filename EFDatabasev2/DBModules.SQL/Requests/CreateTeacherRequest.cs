using DBModules.SQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Requests
{
    public class CreateTeacherRequest
    {
        public string Title { get; set; }
        public string FullName { get; set; }
        public int TscNumber { get; set; }
        public Guid SchoolId { get; set; }
        public GradeLevel Level { get;  set; }
        public Guid TeacherId { get; set; }
    }
}
