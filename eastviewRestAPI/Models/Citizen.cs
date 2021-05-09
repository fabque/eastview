using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EastviewRestAPI.Models
{
    public class Citizen : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Job { get; set; }
    }
}
