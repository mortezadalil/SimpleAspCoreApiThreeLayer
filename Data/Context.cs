using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class Context : DbContext
    {
        public static string connectionString = "server=DESKTOP-1111111\\SQLEXPRESS;" +
            "Database=PostDb;" +
            "Trusted_Connection=True;" +
            "MultipleActiveResultSets=true";

        public Context(DbContextOptions<Context> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostMap());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Post> Posts { get; set; }
    }
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<Context>();
            builder.UseSqlServer(Context.connectionString);
            return new Context(builder.Options);
        }
    }

}
