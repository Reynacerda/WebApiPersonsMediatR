
using Microsoft.EntityFrameworkCore;
using WebApiPerson.Models;

namespace WebApiPerson.Data
{
    public class PersonsContext : DbContext
    {
        public PersonsContext(DbContextOptions<PersonsContext> options): base(options)
        {
        }

        public DbSet<Persons> Persons { get; set; }
    }
}
