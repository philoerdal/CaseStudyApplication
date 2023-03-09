using Magazine.Entities;
using Magazine.Entities;
using Magazine.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Magazine.Services
{
    public class MagazineISWService : IMagazineISWService
    {
        // Dal persistence service
        private readonly IDAL dal;

        // Resources Manager for error messaging
        private ResourceManager resourceManager;

        // logged in User for verification purposes such as (not complete list):
        // - operations restricted to area editors
        // - operations restricted to chief editor
        // - submitted paper responsible author is logged in user
        private User loggedUser;
        private Entities.Magazine magazine;
        public MagazineISWService(IDAL dal)
        {
            this.dal = dal;

            // Resource manager for internationalization of error messages is created
            resourceManager = Magazine.Resources.ExceptionMessages.ResourceManager;
            // Only one magazine object exists in our system
            magazine = dal.GetAll<Entities.Magazine>().FirstOrDefault();
            if (magazine == null)
            {
                DBInitialization();
            }
        }

        private void ValidateLoggedUser(bool validateLogged)
        {
            if (validateLogged)
            {
                // if user is not logged in and it should be logged in then generate exception
                if (loggedUser == null) throw new ServiceException(resourceManager.GetString("LoggedOutUser"));
            }
            else // if user is logged in and it should not be logged in then generate exception 
                if (loggedUser != null) throw new ServiceException(resourceManager.GetString("LoggedUser"));

        }

        public void RestartDB()
        {
            magazine = null;
            dal.RemoveAllData();
            Commit();
            DBInitialization();
        }

        public void DBInitialization()
        {
            // Chief editor registered
            RegisterUser("66666666A", "Javier", "Jaen", false, "HCI; Software Engineering", "fjaen@upv.es", "fjaen", "1234");

            // Area editors registered
            RegisterUser("77777777B", "Jorge", "Montaner", false, "Software Engineering", "jormonm5@upv.es", "jmontaner", "1234");
            RegisterUser("88888888C", "Fernando", "Alonso", false, "HCI", "falonso@upv.es", "falonso", "1234");

            // Author registered
            RegisterUser("99999999D", "Carlos", "Sainz", false, "HCI", "csainz@upv.es", "csainz", "1234");

            // Magazine created and stored in "magazine" reference
            int magazineId = AddMagazine("University Magazine", "66666666A");
            magazine = dal.GetById<Entities.Magazine>(magazineId);

            // Two Areas added, Login required because only chief editor is allowed to do this 
            Login("fjaen", "1234");
            AddArea("HCI", "77777777B");
            AddArea("Software Engineering", "88888888C");
            Logout();
        }

        public int GetMagazineNumber()
        {
            if (magazine == null) throw new ServiceException(resourceManager.GetString("MagazineNotExists"));
            CheckChiefEditor();
            return magazine.Id;
        }

        #region User

        public void AddPerson(string Id, string Name, string Surname)
        {
            if (Id == null) throw new ServiceException(resourceManager.GetString("NullUserId"));
            if (Id == "") throw new ServiceException(resourceManager.GetString("NullUserId"));
            if (Name == null) throw new ServiceException(resourceManager.GetString("NullUser"));
            if (Name == "") throw new ServiceException(resourceManager.GetString("NullUser"));
            if (Surname == null) throw new ServiceException(resourceManager.GetString("NullSurname"));
            if (Surname == "") throw new ServiceException(resourceManager.GetString("NullSurname"));
            Person person = new Person(Id, Name, Surname);
            dal.Insert<Person>(person);
            Commit();
        }

        public string Login(string login, string password)
        {
            if (login == null) throw new ServiceException(resourceManager.GetString("NullLogin"));
            if (login == "") throw new ServiceException(resourceManager.GetString("NullLogin"));
            if (password == null) throw new ServiceException(resourceManager.GetString("NullPassword"));
            if (password == "") throw new ServiceException(resourceManager.GetString("NullPassword"));
            List<User> userList = dal.GetWhere<Entities.User>(user => user.Login == login).ToList();
            if (userList.Count == 0) throw new ServiceException(resourceManager.GetString("UserNotExists"));
            if (userList[0].Password != password) throw new ServiceException(resourceManager.GetString("PasswordMismatch"));
            loggedUser = userList[0];
            return userList[0].Id;
        }

        public void Logout()
        {
            loggedUser = null;
        }

        public void RegisterUser(string id, string name, string surname, bool alerted, string areasOfInterest, string email, string login, string password)
        {
            //NO COMPROBAMOS TODOS LOS DATOS PARA FACILITAR EL TESTEO
               //CHECKEAR EMAIL VALIDO (@ y .)
            if (id == null) throw new ServiceException(resourceManager.GetString("NullUserId"));
            if (id == "") throw new ServiceException(resourceManager.GetString("NullUserId"));
            if (name == null) throw new ServiceException(resourceManager.GetString("NullUser"));
            if (name == "") throw new ServiceException(resourceManager.GetString("NullUser"));
            if (surname == null) throw new ServiceException(resourceManager.GetString("NullSurname"));
            if (surname == "") throw new ServiceException(resourceManager.GetString("NullSurname"));
            if (areasOfInterest == null) throw new ServiceException(resourceManager.GetString("NullAOI"));
            if (areasOfInterest == "") throw new ServiceException(resourceManager.GetString("NullAOI"));
            if (email == null) throw new ServiceException(resourceManager.GetString("NullEmail"));
            if (email == "") throw new ServiceException(resourceManager.GetString("NullEmail"));
            if(!email.Contains("@") || !email.Contains(".")) throw new ServiceException(resourceManager.GetString("InvalidEmail"));
            if (login == null) throw new ServiceException(resourceManager.GetString("NullLogin"));
            if (login == "") throw new ServiceException(resourceManager.GetString("NullLogin"));
            if (password == null) throw new ServiceException(resourceManager.GetString("NullPassword"));
            if (password == "") throw new ServiceException(resourceManager.GetString("NullPassword"));
            List<string> userIDs = dal.GetAll<User>().Select(u => u.Id).ToList();
            if (userIDs.Contains(id)) throw new ServiceException(resourceManager.GetString("UserIdAlreadyExists"));
            if (dal.GetById<Person>(id) != null)
            {
                Person person = dal.GetById<Person>(id);
                dal.Delete<Person>(person);
                Commit();
            }
            List<string> userLogins = dal.GetAll<User>().Select(u => u.Login).ToList();
            if (userLogins.Contains(login)) throw new ServiceException(resourceManager.GetString("LoginAlreadyExists"));
            User newUser = new User(id, name, surname, alerted, areasOfInterest, email, login, password);
            dal.Insert<User>(newUser);
            Commit();
        }

        public string GetUserLogin()
        {
            return loggedUser.Login;
        }

        public List<Person> GetPeople() 
        {
            List<Person> selfList = new List<Person>();
            selfList.Add(loggedUser);
            return dal.GetAll<Person>().Except(selfList).ToList();
        }

        public bool CheckChiefEditor() 
        {
            if (!magazine.CheckChiefEditor(loggedUser)) throw new ServiceException(resourceManager.GetString("NonChiefEditor"));
            return true;
        }
        #endregion

        #region Paper
        public int SubmitPaper(int areaId, string title, DateTime uploadDate)
        {
            ValidateLoggedUser(true);
            if (areaId < 0) throw new ServiceException(resourceManager.GetString("AreaIdNotExists"));
            if (title == null) throw new ServiceException(resourceManager.GetString("NullTitle"));
            if (title == "") throw new ServiceException(resourceManager.GetString("NullTitle"));
            if (uploadDate == null) throw new ServiceException(resourceManager.GetString("NulluploadDate"));
            Area gottenArea = magazine.GetAreaById(areaId);
            if (gottenArea == null) throw new ServiceException(resourceManager.GetString("AreaIdNotExists"));
            if (uploadDate != DateTime.Today) throw new ServiceException(resourceManager.GetString("NotValidDate"));
            Paper newPaper = new Paper(title, uploadDate, gottenArea, loggedUser);
            loggedUser.AddAuthoredPaper(newPaper);
            gottenArea.SubmitPaper(newPaper);
            Commit();
            return newPaper.Id;
        }

        public void SubmitPaperWithCoAuthors(int areaId, string title, DateTime uploadDate, List<Person> coAuthors)
        {
            coAuthors.Add(loggedUser);
            if (coAuthors.Count > 4) throw new ServiceException(resourceManager.GetString("CoAuthorNumExceeded"));
            int paperId = SubmitPaper(areaId, title, uploadDate);
            Paper gottenPaper = magazine.Areas.SingleOrDefault(a => a.Id == areaId).Papers.SingleOrDefault(p => p.Id == paperId);
            gottenPaper.CoAuthors = coAuthors;

            loggedUser.AddCoAuthoredPaper(gottenPaper);
            foreach (Person person in coAuthors)
            {
                person.AddCoAuthoredPaper(gottenPaper);
            }
            Commit();
        }

        public void EvaluatePaper(bool accepted, string comments, DateTime date, int paperId)
        {
            if (comments == null) throw new ServiceException(resourceManager.GetString("NullComments"));
            if (comments == "") throw new ServiceException(resourceManager.GetString("NullComments"));
            if (date == null) throw new ServiceException(resourceManager.GetString("NullDate"));
            if (paperId < 0) throw new ServiceException(resourceManager.GetString("PaperIdNotExists"));
            ValidateLoggedUser(true);
            Area areaOfPaper = magazine.GetAreaByPaperId(paperId);
            if (loggedUser != areaOfPaper.Editor) throw new ServiceException(resourceManager.GetString("InvalidEvaluateEditor"));

            if(!isEvaluationPending(paperId)) throw new ServiceException(resourceManager.GetString("PaperAlreadyEvaluated"));
            Evaluation evaluation = new Evaluation(accepted, comments, date);
            Paper paperToEvaluate = areaOfPaper.GetPaperById(paperId);
            paperToEvaluate.Evaluation = evaluation;
            if (accepted)
            {
                areaOfPaper.RemoveEvaluationPending(paperToEvaluate);
                areaOfPaper.AddPublicationPending(paperToEvaluate);
            }
            else 
            {
                areaOfPaper.RemoveEvaluationPending(paperToEvaluate);
            }
            Commit();
        }

        public void PublishPaper(int paperId)
        {
            ValidateLoggedUser(true);
            CheckChiefEditor();
            Issue issue = magazine.Issues.SingleOrDefault(i => i.PublicationDate == null);
            if (issue == null) throw new ServiceException(resourceManager.GetString("IssueNotExists"));
            if (issue.checkPublication(paperId)) throw new ServiceException(resourceManager.GetString("PaperAlreadyPublished"));

            if (!isPublicationPending(paperId)) throw new ServiceException(resourceManager.GetString("PaperNotInPublicationPending"));
            if (paperId < 0) throw new ServiceException(resourceManager.GetString("PaperIdNotExists"));
            Area area = magazine.GetAreaByPaperId(paperId);
            Paper paper = area.GetPaperById(paperId);
            if (area == null) throw new ServiceException(resourceManager.GetString("PaperIdNotExists"));
            issue.AddPublishedPaper(paper);
            area.RemovePublicationPending(paper);
            Commit();
        }


        public void UnPublishPaper(int paperId)
        {
            ValidateLoggedUser(true);
            CheckChiefEditor();
            Issue issue = magazine.GetIssueByPaperId(paperId);
            if (paperId < 0) throw new ServiceException(resourceManager.GetString("PaperIdNotExists"));
            if (issue == null) throw new ServiceException(resourceManager.GetString("PaperIdNotExists"));
            Paper paper = issue.GetPaperById(paperId);
            bool alreadyExist = issue.PublishedPapers.Contains(paper);
            if (paper == null) throw new ServiceException(resourceManager.GetString("PaperNotExists"));
            if (!alreadyExist) throw new ServiceException(resourceManager.GetString("PaperNotExists"));

            issue.RemovePublishedPaper(paper);
            paper.BelongingArea.AddPublicationPending(paper);
            Commit();
        }


        public bool isEvaluationPending(int paperId) //Check if paper is evaluated
        {
            ValidateLoggedUser(true);
            if (paperId < 0) throw new ServiceException(resourceManager.GetString("PaperIdNotExists"));
            if (magazine == null) throw new ServiceException(resourceManager.GetString("MagazineNotExists"));

            List<Area> areas = GetAreas();
            Paper paper = null;
            foreach (var area in areas)
                if (area.isInEvaluationPending(paperId))
                {
                    paper = area.GetPaperById(paperId);
                    return true;
                }
            if (paper == null) throw new ServiceException(resourceManager.GetString("PaperNotExists"));

            return false;
        }

        public bool isPublicationPending(int paperId) //Check if paper is published
        {
            ValidateLoggedUser(true);
            if (paperId < 0) throw new ServiceException(resourceManager.GetString("PaperIdNotExists"));
            if (magazine == null) throw new ServiceException(resourceManager.GetString("MagazineNotExists"));
            List<Area> areas = GetAreas();
            Paper paper = null;
            foreach (var area in areas)
                if (area.isInPublicationPending(paperId))
                {
                    paper = area.GetPaperById(paperId);
                    return true;
                }
            if (paper == null) throw new ServiceException(resourceManager.GetString("PaperNotExists"));

            return false;

        }
        public bool isAccepted(int paperId)
        {
            ValidateLoggedUser(true);
            if (paperId < 0) throw new ServiceException(resourceManager.GetString("PaperIdNotExists"));
            if (magazine == null) throw new ServiceException(resourceManager.GetString("MagazineNotExists"));

            List<Area> areas = GetAreas();
            Paper paper = null;
            foreach (var area in areas)
                if(area.GetPaperById(paperId) != null)
                    paper = area.GetPaperById(paperId);
            if (paper == null) throw new ServiceException(resourceManager.GetString("PaperNotExists"));

            Evaluation result = paper.Evaluation;
            return result.Accepted;
        }

        public List<Paper> GetPapers(int areaId)
        {
            Area area = magazine.Areas.SingleOrDefault(a => a.Id == areaId);
            if (area == null) return null;
            return area.Papers.ToList();
        }

        public List<Paper> GetPapersPendingEvaluation(int areaId)
        {
            List<Paper> papers = new List<Paper>();
            Area area = magazine.Areas.SingleOrDefault(a => a.Id == areaId);
            if (area == null) return null;
            papers = area.EvaluationPending.ToList();
            return papers;
        }

        public List<Paper> GetPapersPendingPublication(int areaId)
        {
            List<Paper> papers = new List<Paper>();
            Area area = magazine.Areas.SingleOrDefault(a => a.Id == areaId);
            if (area == null) return null;
            papers = area.PublicationPending.ToList();
            return papers;
        }

        public List<Paper> GetPapersRejected(int areaId)
        {
            List<Paper> papers = new List<Paper>();
            papers = magazine.Areas.SingleOrDefault(a => a.Id == areaId).Papers.Where(p => p.Evaluation != null && p.Evaluation.Accepted == false).ToList();
            return papers;
        }

        public List<Paper> GetPapersPublished(int areaId)
        {
            List<Paper> papers = new List<Paper>();
            List<Issue> issues = magazine.Issues.Where(i => i.PublicationDate.HasValue && i.PublicationDate.GetValueOrDefault() <= DateTime.Today).ToList();
            if (issues.Count == 0) return null;
            foreach (var issue in issues)
                foreach (var paper in issue.PublishedPapers)
                    if (paper.BelongingArea.Id == areaId)
                        papers.Add(paper);
            return papers;
        }

        public List<Paper> GetPapersPublishedInIssue(int issueId)
        {
            List<Paper> papers = new List<Paper>();
            Issue issue = magazine.Issues.SingleOrDefault(i => i.Id == issueId && i.PublicationDate.HasValue && i.PublicationDate.GetValueOrDefault() <= DateTime.Today);
            if (issue != null)
                papers = issue.PublishedPapers.ToList();
            return papers;
        }

        public List<Paper> GetPapersNotYetPublished(int areaId)
        {
            List<Paper> papers = new List<Paper>();
            List<Issue> issues = magazine.Issues.Where(i => !i.PublicationDate.HasValue).ToList();
            if (issues.Count == 0) return null;
            foreach (var issue in issues)
                foreach (var paper in issue.PublishedPapers)
                    if (paper.BelongingArea.Id == areaId)
                        papers.Add(paper);
            return papers;
        }

        public List<Paper> GetPapersNotYetPublishedInIssue(int issueId)
        {
            List<Paper> papers = new List<Paper>();
            Issue issue = magazine.Issues.SingleOrDefault(i => i.Id == issueId && !i.PublicationDate.HasValue);
            if (issue != null)
                papers = issue.PublishedPapers.ToList();
            return papers;
        }

        public List<Paper> GetPapersToBePublished(int areaId)
        {
            List<Paper> papers = new List<Paper>();
            List<Issue> exceptions = magazine.Issues.Where(i => i.PublicationDate.GetValueOrDefault() <= DateTime.Today).ToList();
            List<Issue> issues = magazine.Issues.Except(exceptions).ToList();
            if (issues.Count == 0) return null;
            foreach (var issue in issues)
                foreach (var paper in issue.PublishedPapers)
                    if (paper.BelongingArea.Id == areaId)
                        papers.Add(paper);
            return papers;
        }

        public List<Paper> GetPapersToBePublishedInIssue(int issueId)
        {
            List<Paper> papers = new List<Paper>();
            Issue issue = magazine.Issues.SingleOrDefault(i => i.Id == issueId && i.PublicationDate.GetValueOrDefault() > DateTime.Today);
            if(issue != null)
                papers = issue.PublishedPapers.ToList();
            return papers;
        }
        #endregion


        #region Issue

        public List<Issue> GetIssues()
        {
            List<Issue> list = magazine.Issues.ToList();
            if (list.Count == 0) throw new ServiceException(resourceManager.GetString("NullIssues"));
            return list;
        }

        public Issue GetPaperIssue(Paper paper)
        {
            return magazine.Issues.SingleOrDefault(i => i.GetPaperById(paper.Id) != null);
        }

        public int GetLastIssueId()
        {
            if (magazine.Issues.Count == 0) return AddIssue(0);
            Issue last = magazine.Issues.OrderBy(i => i.Number).LastOrDefault();
            Issue nonPublished = magazine.Issues.SingleOrDefault(i => i.PublicationDate == null);
            if (nonPublished == null) return AddIssue(last.Number + 1);
            return nonPublished.Id;
        }

        public Issue GetIssueById(int issueId)
        {
            return magazine.Issues.SingleOrDefault(i => i.Id == issueId);
        }

        public int AddIssue(int number)
        {
            if (number < 0) throw new ServiceException(resourceManager.GetString("IssueNumberInvalid"));
            if (magazine == null) throw new ServiceException(resourceManager.GetString("MagazineNotExists"));
            CheckChiefEditor();
            if (magazine.Issues.Where(i => i.Number == number).ToList().Count != 0) throw new ServiceException(resourceManager.GetString("IssueIdExists"));
            Issue issue = new Issue(number, magazine);
            magazine.AddIssue(issue);
            Commit();
            return issue.Id;
        }

        public void BuildIssue(int issueId, DateTime? date)
        {
            ValidateLoggedUser(true);
            CheckChiefEditor();
            if(issueId < 0) throw new ServiceException(resourceManager.GetString("IssueNumberInvalid"));
            Issue issue = magazine.Issues.SingleOrDefault(i => i.Id == issueId);
            if (issue == null) throw new ServiceException(resourceManager.GetString("IssueNotExists"));
            if(issue.PublishedPapers.Count == 0) throw new ServiceException(resourceManager.GetString("IssueEmpty"));
            if(!date.HasValue) throw new ServiceException(resourceManager.GetString("NullDate"));
            issue.PublicationDate = date;
            Commit();
        }


        #endregion

        #region Area


        /// <summary>   Validate area and if correct, add a new area.</summary>
        /// <param>     <c>areaName</c> is the area name. 
        /// </param>     
        /// <param>     <c>editorId</c> is the Id of the area editor. 
        /// </param>
        /// <returns> 
        ///             Area id
        ///             Any required ServiceExceptions
        /// </returns>
        public int AddArea(string areaName, string editorId)
        {
            // validate logged user
            ValidateLoggedUser(true);

            // validate user is chief editor
            if (loggedUser.Magazine == null) throw new ServiceException(resourceManager.GetString("InvalidAddAreaUser"));

            // validate magazine exists
            if (magazine == null) throw new ServiceException(resourceManager.GetString("MagazineNotExists"));

            // validate area name not empty
            if ((areaName == null) || (areaName.Length == 0)) throw new ServiceException(resourceManager.GetString("InvalidAreaName"));

            // validate not another area with same name
            if (magazine.GetAreaByName(areaName) != null) throw new ServiceException(resourceManager.GetString("InvalidAreaName"));

            // validate editor id not empty
            if ((editorId == null) || (editorId.Length == 0)) throw new ServiceException(resourceManager.GetString("NullUserId"));

            //validate editor exists
            var editor = dal.GetById<User>(editorId);
            if (editor == null) throw new ServiceException(resourceManager.GetString("UserNotExists"));

            // inserts area
            Area area = new Area(areaName, editor, magazine);
            magazine.AddArea(area);
            Commit();
            return area.Id;
        }

        public List<Area> GetAreas()
        {
            List<Area> list = magazine.Areas.ToList();
            if (list.Count == 0) throw new ServiceException(resourceManager.GetString("NullAreas"));
            return list;
        }

        public List<Area> GetAreasWhereEditor()
        {
            List<Area> list = magazine.Areas.Where(a => a.Editor == loggedUser).ToList();
            if (list.Count == 0) throw new ServiceException(resourceManager.GetString("UserNotEditor"));
            return list;
        }
        #endregion

        #region Magazine

        /// <summary>   Validate data and if correct, add a new magazine with its chief editor.</summary>
        /// <param>     <c>name</c> is the name of the magazine 
        /// </param>
        /// <param>     <c>chiefEditorId</c> is the is the user Id of that becomes chief Editor 
        /// </param>
        /// <returns>   
        ///             Magazine Id
        ///             Any required Service Exceptions 
        /// </returns>
        public int AddMagazine(string name, string chiefEditorId)
        {
            // validate magazine name not empty
            if ((name == null) || (name.Equals(""))) throw new ServiceException(resourceManager.GetString("InvalidMagazineName"));

            // validate chief editor id not empty
            if ((chiefEditorId == null) || (chiefEditorId.Length == 0)) throw new ServiceException(resourceManager.GetString("NullUserId"));

            // validate chief editor exists
            var chief = dal.GetById<User>(chiefEditorId);
            if (chief == null) throw new ServiceException(resourceManager.GetString("UserNotExists"));

            // insert magazine
            Entities.Magazine m = new Entities.Magazine(name, chief);
            dal.Insert(m);
            Commit();
            return m.Id;
        }

        #endregion
        
        public void Commit() 
        {
            dal.Commit();
        }
    }
}