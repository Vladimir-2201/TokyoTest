using Microsoft.EntityFrameworkCore;

namespace TokyoTestServer.Data
{
    public class TokyoTestServerContext : DbContext
    {
        public TokyoTestServerContext (DbContextOptions<TokyoTestServerContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<TokyoTestServer.Order> Order { get; set; } = default!;
    }
}
