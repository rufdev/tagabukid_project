using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreService.Domain;
using Repository.Pattern.Ef6;
using System.Data.Entity;

namespace CoreService
{
    public partial class PersonBukContext : DataContext
    {
        public string connection = System.Configuration.ConfigurationManager.ConnectionStrings["PersonContext"].ConnectionString;
        static PersonBukContext()
        {
            Database.SetInitializer<PersonBukContext>(null);
        }

        public PersonBukContext()
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
