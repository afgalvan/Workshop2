using System.Collections.Generic;
using Shared.Domain.Bus.Query;

namespace Application.People.GetAll
{
    public class GetAllPeopleQuery : IQuery<IEnumerable<PersonResponse>>
    {
    }
}
