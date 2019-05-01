using System;
using System.Collections.Generic;
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
        public string DateCreated { get; set; }
        public int StatusId { get; set; }

    }
}
