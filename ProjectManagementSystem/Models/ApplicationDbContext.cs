using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace ProjectManagementSystem.Models
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext() : base("DefaultConnection"){}

        public DbSet<ProjectModel> ProjectDb { get; set; } = default;
    }

}