using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pai.Models
{
    public class ProjectRating
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int MetricsId { get; set; }
        public string Creator { get; set; }
        public double Value { get; set; }

        public ProjectMetrics Metrics { get; set; }
        public Project Project { get; set; }

    }
}