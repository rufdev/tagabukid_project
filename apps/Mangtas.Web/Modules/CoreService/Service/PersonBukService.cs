using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreService.Domain;
using Repository.Pattern.Repositories;
using Service.Pattern;

namespace CoreService.Service
{
    public interface IPersonBukService : IService<Person>
    {
    }

    public class PersonBukService : Service<Person>, IPersonBukService
    {
        public PersonBukService(IRepositoryAsync<Person> repository)
            : base(repository)
        {
        }
    }
}
