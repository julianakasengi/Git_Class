using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModules.SQL.Models
{
    public class Stream
    {
        [Key]
        public Guid StreamID { get; set; } = Guid.NewGuid();

        [Required]
        public string StreamName { get; set; }

        public virtual Guid SchoolId { get; set; }

        public virtual School School { get; set; }

    }
}
