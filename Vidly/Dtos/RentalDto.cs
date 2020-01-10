using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }

        [Required]
        public CustomerDto Customer { get; set; }

        [Required]
        public MovieDto Movie { get; set; }

        public DateTime RentalDate { get; set; }

        public DateTime? ReturningDate { get; set; }
    }
}