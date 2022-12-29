using HandPass.Core.CoreEntities;
using HandPass.Entities.Entitiy;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HandPass.DataAccess
{
    public class HandPassContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-G0T65PBM;Initial Catalog=HandPass;User ID=sa;Password=123321;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<UserPassword> UserPasswords { get; set; }

    }
}
