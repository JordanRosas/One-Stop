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


        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }


        [Display(Name = "Company Website")]
        public string CompanyWebsite { get; set; }


        public string Address { get; set; }


        [Display(Name = "City, State")]
        public string CityState { get; set; }

        public virtual ICollection<JobTicket> JobTicketList { get; set; }
    }
}
