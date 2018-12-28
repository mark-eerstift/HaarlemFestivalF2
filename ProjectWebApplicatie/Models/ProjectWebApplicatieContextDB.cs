using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectWebApplicatie.Models
{
    public class ProjectWebApplicatieContextDB : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ProjectWebApplicatieContextDB() : base("name=ProjectWebApplicatieContextDB")
        {
        }

        public DbSet<ProjectWebApplicatie.Models.Evenement> Evenements { get; set; }

        public DbSet<ProjectWebApplicatie.Models.Food> Foods { get; set; }

        public DbSet<ProjectWebApplicatie.Models.History> Historys { get; set; }

        public DbSet<ProjectWebApplicatie.Models.Jazz> Jazzs { get; set; }

        public DbSet<ProjectWebApplicatie.Models.Dance> Dances { get; set; }

        public System.Data.Entity.DbSet<ProjectWebApplicatie.Models.Event> Events { get; set; }

        public System.Data.Entity.DbSet<ProjectWebApplicatie.Models.Ticket> Tickets { get; set; }

        public System.Data.Entity.DbSet<ProjectWebApplicatie.Models.Vrijwilliger> Vrijwilligers { get; set; }

        public System.Data.Entity.DbSet<ProjectWebApplicatie.Models.EventPage> EventPages { get; set; }
    }
}
