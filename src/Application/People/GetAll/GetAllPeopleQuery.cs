using System.Collections.Generic;
using Domain.People;
using Shared.Domain.Bus.Query;

namespace Application.People.GetAll
{
    public class GetAllPeopleQuery : IQuery<IEnumerable<Person>>
    {
    }
}
