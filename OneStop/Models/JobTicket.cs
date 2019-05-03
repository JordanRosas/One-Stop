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
        public int CompanyId { get; set; }
        public string Position { get; set; }
        [Display(Name = "Date Created")]
        public string DateCreated { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public Company Company { get; set; }
        public ApplicationUser User { get; set; }
    }
}
