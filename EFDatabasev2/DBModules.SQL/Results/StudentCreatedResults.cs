using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Results
{
    public class StudentCreatedResults
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Guid StudentID { get; set; }

        //USING CODE FIRST, HOW DO YOU DEFINE PRIMARY KEYS OF TYPE INT, LONG AND DOUBLE WHERE THE KEYS AUTOINCREMENT
    }
}
