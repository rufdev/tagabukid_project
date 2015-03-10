using Mangtas.Sample.Domains;
using Repository.Pattern.Repositories;
using Service.Pattern;

namespace Mangtas.Sample.Services
{
    public interface IPersonBukService : IService<Person>
    {
    }

    public class PersonBukService : Service<Person>, IPersonBukService
    {
        private readonly IRepositoryAsync<Person> _repository;

        public PersonBukService(IRepositoryAsync<Person> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
