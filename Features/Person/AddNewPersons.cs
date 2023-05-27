using FluentValidation;
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
    public class AddNewPersons
    {
        public class Command : IRequest<int>
        {
            public string LastName { get; set; }
          
            public string FirstName { get; set; }
            public string Address { get; set; }

            public string Email { get; set; }

            public int CreatedBy { get; set; }

           
            public int Status { get; set; }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.LastName).NotEmpty().MaximumLength(150);
                RuleFor(c => c.FirstName).NotEmpty().MaximumLength(100);
            }
        }

        public class CommandHandler : IRequestHandler<Command, int>
        {
            private readonly PersonsContext _db;

            public CommandHandler(PersonsContext db) => _db = db;

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = new Persons
                {
                    LastName = request.LastName,
                    FirstName = request.FirstName,
                    Email = request.Email,
                    Address = request.Address,
                    CreatedBy= Convert.ToInt32(request.CreatedBy),
                    Status=request.Status
                };

                await _db.Persons.AddAsync(entity, cancellationToken);
                await _db.SaveChangesAsync(cancellationToken);

                return entity.PersonId;
            }
        }
    }
}
