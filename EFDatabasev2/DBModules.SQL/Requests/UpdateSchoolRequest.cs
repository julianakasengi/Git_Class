using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Requests
{
    public class UpdateSchoolRequest
    {
        public Guid SchoolID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsPublic { get; set; }
        public int Grade { get; set; }
    }
}
