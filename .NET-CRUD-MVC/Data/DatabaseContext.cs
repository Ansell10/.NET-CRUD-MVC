using System;
using ASPNET_CRUD_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


namespace ASPNET_CRUD_MVC.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<ContactModel> Contact { get; set; }
        public DbSet<UserModel> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // Enable retry on failure
            optionsBuilder.UseSqlServer(
                optionsBuilder.Options.FindExtension<SqlServerOptionsExtension>().ConnectionString,
                options => options.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null)
            );
        }
    }
}
