using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.Ef6;

namespace CoreService.Domain
{
    public class Person : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
