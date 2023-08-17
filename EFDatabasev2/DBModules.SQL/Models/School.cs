using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Models
{

    public class School
    {
        [Key]
        public Guid SchoolId { get; set; } = Guid.NewGuid();

        [MaxLength(60), Required]
        public string Name { get; set; }

        public DateTime? CreatedAt { get; internal set; } = DateTime.UtcNow;

        [MaxLength(100), Required]
        public string Address { get; set; }  //Non-nullable string that can hold up to 100 characters

        [Range(1, 12)]
        public int Grade { get; set; } //An integer that must be between 1 and 12.

        public bool IsPublic { get; set; } //A boolean property indicating whether the school is public or not

        public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

        public virtual ICollection<Student> Students { get; set; } = new List<Student>();

        public virtual ICollection<Stream> Streams { get; set; } = new List<Stream>();

        public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();


    }
}
