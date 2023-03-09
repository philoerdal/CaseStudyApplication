using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.Entities
{
    public partial class Issue
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime? PublicationDate { get; set; }

        public virtual ICollection<Paper> PublishedPapers { get; set; }
        
        [Required]
        public virtual Magazine Magazine { get; set; }
        

    }
}
