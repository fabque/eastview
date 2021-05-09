using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EastviewRestAPI.Models
{
    public class CitizenTask : IEntity
    {
        public int Id { get; set; }

        [Required]
        public DayOfWeek Day { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Description { get; set; }

        [Required]
        public int CitizenId { get; set; }

        public Citizen Citizen { get; set; }
    }
}
