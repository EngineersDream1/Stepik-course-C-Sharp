using Application.Data.DataBaseContext;
using Domain.Models;
using Domain.Security;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data.DataBaseContext
{
    public class ApplicationDbContext : IdentityDbContext<CustomIdentityUser>, IApplicationDbContext
    {
        public DbSet<Topic> Topics => Set<Topic>();

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly()
            );      
        }
    }
}
