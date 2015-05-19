using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pai.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectStatus { get; set; }
        public string ProjectOwner { get; set; }
        public DateTime CreatedOn { get; set; }
        public ICollection<ProjectMetrics> Metrics { get; set; }
        public ICollection<ProjectRating> Ratings { get; set; }
    }
}