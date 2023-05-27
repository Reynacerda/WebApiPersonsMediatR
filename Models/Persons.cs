using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPerson.Models
{
    public class Persons
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string Address { get; set; }

        public string Email { get; set; }

        public int CreatedBy { get; set; }

        [Required]
        public int Status { get; set; }
    }
}
