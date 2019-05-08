using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
//Require data attributes
namespace OneStop.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Company Website")]
        public string CompanyWebsite { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Display(Name = "City, State")]
        public string CityState { get; set; }

        public virtual ICollection<JobTicket> JobTicketList { get; set; }
    }
}
