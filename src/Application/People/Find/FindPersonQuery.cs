using Domain.People;
using Shared.Domain.Bus.Query;

namespace Application.People.Find
{
    public class FindPersonQuery : IQuery<Person>
    {
        public FindPersonQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
