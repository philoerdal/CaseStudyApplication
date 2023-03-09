using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.Entities
{
    public partial class Magazine
    {
        public Magazine()
        {
            Areas = new List<Area>();
            Issues = new List<Issue>();
        }

        public Magazine(string name, User chiefEditor):this()
        {
            this.Name = name;

            ChiefEditor = chiefEditor;
        }

        public void AddArea(Area area)
        {
            Areas.Add(area);
        }

        public void AddIssue(Issue issue)
        {
            Issues.Add(issue);
        }

        public Area GetAreaByName(string Area)
        {
            List<Area> areaList = Areas.ToList();
            for (int i = 0; i < areaList.Count; i++)
            {
                Area area = areaList[i];
                if (area.Name == Area) { return area; }
            }
            return null;
        }

        public Area GetAreaById(int areaId)
        {
            List<Area> areaList = Areas.ToList();
            for (int i = 0; i < areaList.Count; i++)
            {
                Area area = areaList[i];
                if (area.Id == areaId) { return area; }
            }
            return null;
        }

        public Issue GetIssueByNumber(int number)
        {
            List<Issue> issueList = Issues.ToList();
            for (int i = 0; i < issueList.Count; i++)
            {
                Issue issue = issueList[i];
                if (issue.Number == number) { return issue; }
            }
            return null;
        }

        public Area GetAreaByPaperId(int paperId) 
        {
            List<Area> areaList = Areas.ToList();
            for (int i = 0; i < areaList.Count; i++)
            {
                Area area = areaList[i];
                List<Paper> papers = area.Papers.ToList();
                for (int p = 0; p < papers.Count; p++)
                {
                    if(papers[p].Id == paperId) { return area; }
                }
            }
            return null;
        }

        public Issue GetIssueByPaperId(int paperId) 
        {
            List<Issue> issueList = Issues.ToList();
            for (int i = 0; i < issueList.Count; i++)
            {
                Issue issue = issueList[i];
                List<Paper> papers = issue.PublishedPapers.ToList();
                for (int p = 0; p < papers.Count; p++)
                {
                    if(papers[p].Id == paperId) { return issue; }
                }
            }
            return null;
        }

        public bool CheckChiefEditor(User loggedUser) 
        {
            if (loggedUser.Id == ChiefEditor.Id) 
            {
                return true;
            }
            return false;
        }
    }
}
