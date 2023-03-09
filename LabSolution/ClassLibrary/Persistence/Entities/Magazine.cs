using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;

namespace Magazine.Entities
{
    public partial class Magazine
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Area> Areas { get; set; }
        
        public virtual ICollection<Issue> Issues { get; set; }

        [Required]
        public virtual User ChiefEditor{get;set;}
    }
}
