using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.People;
using Shared.Domain.Bus.Query;

namespace Application.People.GetAll
{
    public class
        GetAllPeopleQueryHandler : IQueryHandler<GetAllPeopleQuery, IEnumerable<Person>>
    {
        public Task<IEnumerable<Person>> Handle(GetAllPeopleQuery request,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
