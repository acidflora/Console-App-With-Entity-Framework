using Microsoft.EntityFrameworkCore;

namespace ConsoleAppWithEFCore
{
    class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ConsoleAppWithEF;Trusted_Connection=True;Encrypt=False;");
        }
    }
}
