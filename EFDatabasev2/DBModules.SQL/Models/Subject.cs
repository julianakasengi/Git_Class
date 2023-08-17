using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Models
{
    public class Subject
    {
        [Key]
        public Guid SubjectId { get; set; } 

        [Required]
        public string Name { get; set; }

        [Required]
        public int Score { get; set; }

        public virtual ICollection <StudentSubjectJoin>? Students { get; set; }=new List <StudentSubjectJoin>();
        public virtual Student Student { get; set; }

        [ForeignKey ("TeacherId")]
        public Guid TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public virtual School School { get; set; }
    }
    //EF is used to map poco objectes on db.
    //2 ways to define relationships:
    //1. attributes
    //2. Fluent UI
}
