using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pai.Models
{
    public class ProjectModel
    {
        public string Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectStatus { get; set; }
        public string ProjectOwner { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}