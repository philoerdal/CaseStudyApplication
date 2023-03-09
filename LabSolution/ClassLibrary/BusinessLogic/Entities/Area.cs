using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.Entities
{
    public partial class Area
    {
        public Area()
        {
            Papers = new List<Paper>();
            EvaluationPending = new List<Paper>();
            PublicationPending = new List<Paper>();
        }

        public Area(string Name, User editor, Magazine mag):this() {
            Editor = editor;
            Magazine = mag;
            this.Name = Name;
        }

        public Paper GetPaperByTitle(string Paper)
        {
            List<Paper> paperList = Papers.ToList();
            for (int i = 0; i < paperList.Count; i++)
            {
                Paper paper = paperList[i];
                if (paper.Title == Paper) { return paper; }
            }
            return null;
        }

        public void SubmitPaper(Paper paper)
        {
            Papers.Add(paper);
            AddEvaluationPending(paper);
        }
        public Paper GetPaperById(int paperId)
        {
            List<Paper> paperList = Papers.ToList();
            for (int i = 0; i < paperList.Count; i++)
            {
                Paper paper = paperList[i];
                if (paper.Id == paperId) { return paper; }
            }
            return null;
        }
        
        public bool isInEvaluationPending(int id)
        {
            List<Paper> pendingPaperList = EvaluationPending.ToList();
            List<Paper> paperList = Papers.ToList();
            for (int i = 0; i < paperList.Count; i++)
            {
                if (paperList[i].Id == id && pendingPaperList.Contains(paperList[i])) 
                {
                    return true;
                }
            }
            return false;
        }

        public bool isInPublicationPending(int id)
        {
            List<Paper> pendingPaperList = PublicationPending.ToList();
            List<Paper> paperList = Papers.ToList();
            for (int i = 0; i < paperList.Count; i++)
            {
                if (paperList[i].Id == id && pendingPaperList.Contains(paperList[i])) 
                {
                    return true;
                }
            }
            return false;
        }

        public void AddPublicationPending(Paper paper) 
        {
            PublicationPending.Add(paper);
        }

        public void RemovePublicationPending(Paper paper) 
        {
            PublicationPending.Remove(paper);
        }
        
        public void AddEvaluationPending(Paper paper) 
        {
            EvaluationPending.Add(paper);
        }

        public void RemoveEvaluationPending(Paper paper) 
        {
            EvaluationPending.Remove(paper);
        }
    }
}
