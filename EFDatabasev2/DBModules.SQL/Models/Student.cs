using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Models
{
    public class Student
    {
        [Key]
        public Guid StudentID { get; set; } = Guid.NewGuid();

        [Required]
        public string? Name { get; set; }
        [Required]
        public int Age { get; set; }

        [Required]
        public DateTime Dob { get; set; }

        [Required]
        public string Address { get; set; }

        //[ForeignKey("SchoolId")]
        public  Guid SchoolId { get; set; }

        public virtual School School { get; set; }
        public virtual ICollection<StudentSubjectJoin> Subjects { get; set; } = new List<StudentSubjectJoin>();

    }
}
