using metrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace metrack.Domain.Context
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<Issue> Issues { get; set; }
    }
}
