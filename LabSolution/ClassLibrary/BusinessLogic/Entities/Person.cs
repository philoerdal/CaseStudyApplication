using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.Entities
{
    public partial class Person
    {
        public Person()
        {
            CoAuthoredPapers = new List<Paper>();
        }
        public Person(string Id, string Name, string Surname):this()
        {
                this.Name = Name;
                this.Surname = Surname;
                this.Id = Id;
        }

        public void AddCoAuthoredPaper(Paper p)
        {
            CoAuthoredPapers.Add(p);
        }
    }
}
