using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyTweets.Controllers
{
    public class ProjectWithFrontEndBackEnd
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectFile { get; set; }
        public string FrontEndName { get; set; }
        public string BackEndName { get; set; }
    }
}