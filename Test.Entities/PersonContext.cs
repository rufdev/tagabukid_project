using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.Ef6;
using System.Data.Entity;

namespace Test.Entities
{
    public partial class PersonContext : DataContext
    {
        static PersonContext()
        {
            Database.SetInitializer<PersonContext>(null);
        }

        public PersonContext()
            : base("Name=PersonContext")
        {
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PersonConfiguration());
        }
    }
}
