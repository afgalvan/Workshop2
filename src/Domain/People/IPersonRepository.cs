using Domain.Shared;

namespace Domain.People
{
    public interface IPersonRepository : IRepository<string, Person>
    {
    }
}
