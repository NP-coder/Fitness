using BL.Model;
using System.Data.Entity;

namespace BL.Control
{
    class FitnessContext : DbContext
    {
        public FitnessContext() : base("DBConnection") { }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
