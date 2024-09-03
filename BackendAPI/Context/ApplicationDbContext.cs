using BackendAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<StorageLocation> StorageLocations { get; set; }
        public DbSet<Bpkb> Bpkbs { get; set; }


    }
}
