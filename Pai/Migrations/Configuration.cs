namespace Pai.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Pai.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<Pai.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Pai.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            Project project = new Project
                {
                    ProjectName = "Dream bicycle",
                    ProjectOwner = "Michael Lu",
                    ProjectStatus = "Pending",
                    CreatedOn = DateTime.Now.AddDays(-32),
                    Metrics =
                    new List<ProjectMetrics>
                    {
                        new ProjectMetrics{Description="Reliability"},
                        new ProjectMetrics{Description="Aesthetics"},
                        new ProjectMetrics{Description="Usability"},
                        new ProjectMetrics{Description="Price"}
                    }
                };
            context.Project.AddOrUpdate(p => p.ProjectName, project);
            context.SaveChanges();
            ProjectRating rating = new ProjectRating 
            { Value = 7.2, 
                Creator="Steven Lamb",
                Project=project,
                Metrics=context.Metrics.SingleOrDefault(m=>m.Description=="Reliability")
            };
            context.Rating.AddOrUpdate(r => r.Id, rating);
            context.SaveChanges();

        }

        private void AddOrUpdateRating (ApplicationDbContext context, string metrics, string projectName)
        {
            var project = context.Project.SingleOrDefault(p => p.ProjectName == projectName);
            var aspect = context.Metrics.SingleOrDefault(m => m.Description == metrics);
        }
    }
}
