using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.Repositories;
using Service.Pattern;
using Test.Entities;

namespace Test.Service
{
    public interface IPersonService : IService<Person>
    {
        
    }

    public class PersonService : Service<Person>, IPersonService
    {
        public PersonService(IRepositoryAsync<Person> repository)
            : base(repository)
        {
            
        }
    }
}
