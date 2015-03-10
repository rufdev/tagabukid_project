using System.Data.Entity.ModelConfiguration;

namespace Mangtas.Sample.Domains
{
    public class PersonConfiguration : EntityTypeConfiguration<Person>
    {

        public PersonConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Table Mapping
            this.ToTable("test.tblPerson");
        }
    }
}
