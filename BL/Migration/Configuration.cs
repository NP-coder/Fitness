using System.Data.Entity.Migrations;

namespace BL.Migration
{
    internal sealed class Configuration : DbMigrationsConfiguration<Control.FitnessContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "BL.Control.FitnessContext";
        }

        protected override void Seed(BL.Control.FitnessContext context)
        {

        }
    }
}
