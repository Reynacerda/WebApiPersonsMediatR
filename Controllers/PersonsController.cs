using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPerson.Features.Person;
using WebApiPerson.Models;

namespace WebApiPerson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public PersonsController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IEnumerable<Persons>> GetPersons() => await _mediator.Send(new GetPersons.Query());

        [HttpGet("{id}")]
        public async Task<Persons> GetPersons(int id) => await _mediator.Send(new GetPersonsById.Query { Id = id });

        [HttpPost]
        public async Task<ActionResult> CreatePersons([FromBody] AddNewPersons.Command command)
        {
            var createdPersonsId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetPersons), new { id = createdPersonsId }, null);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePerson(int id)
        {
            await _mediator.Send(new DeletePersons.Command { Id = id });
            return NoContent();
        }

       
    }
}

