using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Login.Models
{
    public class AppSetingsDBContext : DbContext
    {
        public AppSetingsDBContext(DbContextOptions<AppSetingsDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
