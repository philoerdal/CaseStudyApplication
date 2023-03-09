using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.Entities
{
    public partial class Paper
    {
        public Paper() {
            CoAuthors = new List<Person>();
        }

        public Paper(string Title, DateTime UploadTime, Area BelongingArea, User Responsible) :this() 
        {
            this.BelongingArea = BelongingArea;
            this.Responsible = Responsible;
            this.Title = Title;
            this.UploadDate = UploadTime;
            CoAuthors.Add(Responsible);
        }
    }
}
