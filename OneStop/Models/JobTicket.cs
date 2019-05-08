using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneStop.Models
{
    public class JobTicket  
    {
        public int JobTicketId { get; set; }
        public string UserId { get; set; }

        [Display(Name = "Select A Company")]
        public int CompanyId { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        [Display(Name = "Todays Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime DateCreated { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }
        public Company Company { get; set; }
        public ApplicationUser User { get; set; }
    }
}
