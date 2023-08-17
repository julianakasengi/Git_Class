using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Results
{
    public class SchoolCreatedResults
    {
        public Guid SchoolID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsPublic { get; set; }
        public int Grade { get; set; }

    }
}
