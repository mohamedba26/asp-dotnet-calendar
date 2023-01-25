global using Microsoft.EntityFrameworkCore;
using calendar.Models;

namespace calendar.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=calendardb;Trusted_Connection=true;TrustServerCertificate=true;");
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<ClientMission> ClientMissions { get; set; }
        public DbSet<Travail> Travails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientMission>()
                .HasKey(e => new { e.clientID, e.MissionID });
        }
    }
}
