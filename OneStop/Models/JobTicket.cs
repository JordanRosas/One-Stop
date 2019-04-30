using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneStop.Models
{
    public class JobTicket
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public int CompanyId { get; set; }
        public string Position { get; set; }
        public DateTime DateCreated { get; set; }
        public int StatusId { get; set; }
    }
}
