using Microsoft.EntityFrameworkCore;

namespace FashionChess.Models
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
