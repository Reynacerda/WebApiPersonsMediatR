using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApiPerson.Data;

namespace WebApiPerson.Features.Person
{
    public class DeletePersons
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.Id).GreaterThan(0);
            }
        }

        public class CommandHandler : IRequestHandler<Command, Unit>
        {
            private readonly PersonsContext _db;

            public CommandHandler(PersonsContext db) => _db = db;

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var Persons = await _db.Persons.FindAsync(request.Id);
                if (Persons == null) return Unit.Value;

                _db.Persons.Remove(Persons);
                await _db.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
