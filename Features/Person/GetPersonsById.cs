using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApiPerson.Data;
using WebApiPerson.Models;

namespace WebApiPerson.Features.Person
{
    public class GetPersonsById
    {
        public class Query : IRequest<Persons>
        {
            public int Id { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Persons>
        {
            private readonly PersonsContext _db;

            public QueryHandler(PersonsContext db) => _db = db;

            public async Task<Persons> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _db.Persons.FindAsync(request.Id);
            }
        }
    }
}
