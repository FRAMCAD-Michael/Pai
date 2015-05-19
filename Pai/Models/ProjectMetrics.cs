using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pai.Models
{
    public class ProjectMetrics
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Project> Project { get; set; }
        public ICollection<ProjectRating> Ratings { get; set; }

    }
}