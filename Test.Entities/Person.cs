using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.Ef6;

namespace Test.Entities
{
    public partial class Person : Entity
    {
        public Person()
        {
            this.Id = new Guid();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }    
    }
}
