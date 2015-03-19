using System.Data.Entity;
using Repository.Pattern.Ef6;

namespace Mangtas.Sample.Domains
{
    public partial class SampleBukContext : DataContext
    {
        static SampleBukContext()
        {
            Database.SetInitializer<SampleBukContext>(null);
        }

        public SampleBukContext()
            : base("SQLExpressContext")
        {
            
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PersonConfiguration());
        }
    }
}
