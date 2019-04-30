using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Require data attributes
namespace OneStop.Models
{
    public class Company
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyWebsite { get; set; }
        public string Address { get; set; }
        public string CityState { get; set; }
    }
}
