using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApiPerson.Data;
using WebApiPerson.Models;

namespace WebApiPerson.Features.Person
{
    public class GetPersons
    {
        public class Query : IRequest<IEnumerable<Persons>> { }

        public class QueryHandler : IRequestHandler<Query, IEnumerable<Persons>>
        {
            private readonly PersonsContext _db;

            public QueryHandler(PersonsContext db) => _db = db;

            public async Task<IEnumerable<Persons>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _db.Persons.ToListAsync(cancellationToken);
            }
        }
    }
}