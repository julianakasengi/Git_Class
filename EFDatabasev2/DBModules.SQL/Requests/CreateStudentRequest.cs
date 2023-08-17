using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Requests
{
    public class CreateStudentRequest
    {
        public string? Name { get; set; }
        public DateTime Dob { get; set; }
        public string Address { get; set; }

        public Guid SchoolId { get; set; }
        public Guid StudentId { get; set; }
        public int Age { get; set; }
    }
}
