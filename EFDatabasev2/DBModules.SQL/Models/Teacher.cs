using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Models
{
    //public enum GradeLevel
    //{
    //    Junior,
    //    Intermediate,
    //    Senior
    //}

    public class Teacher
    {


        [Key]
        public Guid TeacherId { get; set; } = Guid.NewGuid();

        [Required]
        public string Title { get; set; }

        [MaxLength(100), Required]
        public string FullName { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();

        [Required]
        public int TscNumber { get; set; }

        [Required]
        public GradeLevel Level { get; set; }

        [ForeignKey("SchoolId")]
        public virtual Guid SchoolId { get; set; }

        public virtual School School { get; set; }
    }
}
