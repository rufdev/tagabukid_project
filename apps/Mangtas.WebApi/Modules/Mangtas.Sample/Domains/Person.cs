using System;
using Repository.Pattern.Ef6;

namespace Mangtas.Sample.Domains
{
    public class Person : Entity
    {
        public Person()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        //public DateTime Birthdate { get; set; }
    }
}
