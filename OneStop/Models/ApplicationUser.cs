using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneStop.Models
{
    public class ApplicationUser: IdentityUser
    {
        public ApplicationUser()
        {

        }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Name")]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public string  Email { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Company> Companies { get; set; }

        public virtual ICollection<JobTicket> Tickets { get; set; }

        public virtual ICollection<Status> Statuses { get; set; }
    }
}
