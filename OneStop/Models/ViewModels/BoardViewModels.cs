using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneStop.Models.ViewModels
{
    public class BoardViewModels
    {
        public Company Company { get; set; }
        public JobTicket Tickets { get; set; }
        public Status Statuses { get; set; }
    }
}
