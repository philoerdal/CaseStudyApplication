using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.Entities
{
    public partial class User : Person
    {
        public User() : base() {
            MainAuthoredPapers = new List<Paper>();
        }
        public User(string Id, string Name, string Surname, bool Alerted, string AreasOfInterest, string Email, string Login, string Password) : base(Id, Name, Surname)
        {
            this.Alerted = Alerted;
            this.AreasOfInterest = AreasOfInterest;
            this.Email = Email;
            this.Login = Login;
            this.Password = Password;

            MainAuthoredPapers = new List<Paper>();
        }

        public User(Person person, bool Alerted, string AreasOfInterest, string Email, string Login, string Password) : base(person.Id, person.Name, person.Surname)
        {
            this.Alerted = Alerted;
            this.AreasOfInterest = AreasOfInterest;
            this.Email = Email;
            this.Login = Login;
            this.Password = Password;

            MainAuthoredPapers = new List<Paper>();
        }

        public void AddAuthoredPaper(Paper p) 
        {
            MainAuthoredPapers.Add(p);
        }
    }
}
