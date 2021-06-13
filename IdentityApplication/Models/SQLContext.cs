using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityApplication.Models
{
    public class SQLContext : IdentityDbContext<User>
    {
        public SQLContext(DbContextOptions<SQLContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
