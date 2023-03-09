using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.Entities
{
    public partial class Issue
    {
        public Issue()
        {
            PublishedPapers = new List<Paper>();
        }

        public Issue(int number, Magazine mag) :this()
        {
            Number = number;
            Magazine = mag;
        }
        
        public Paper GetPaperById(int paperId)
        {
            List<Paper> paperList = PublishedPapers.ToList();
            for (int i = 0; i < paperList.Count; i++)
            {
                Paper paper = paperList[i];
                if (paper.Id == paperId) { return paper; }
            }
            return null;
        }

        /*public Magazine GetMagazineById(int magazineId)
        {
            List<Magazine> m = Entities.Magazine
        }*/

        public void AddPublishedPaper(Paper paper) 
        {
            PublishedPapers.Add(paper);
        }

        public void RemovePublishedPaper(Paper paper) 
        {
            PublishedPapers.Remove(paper);
        }
        public bool checkPublication(int id)
        {
            List<Paper> paperList = PublishedPapers.ToList();
            for (int i = 0; i < paperList.Count; i++)
            {
                Paper paper = paperList[i];
                if (paper.Id == id) { return true; }
            }
            return false;
        }
    }
}
