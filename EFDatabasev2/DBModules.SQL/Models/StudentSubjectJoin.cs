using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Models
{
    [PrimaryKey(nameof(SubjectId),nameof(StudentID))]
    public class StudentSubjectJoin
    {
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public Guid StudentID { get; set; }
        public virtual Student Student { get; set; }

        

    }
}
