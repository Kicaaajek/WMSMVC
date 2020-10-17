using System;
using System.Collections.Generic;
using System.Text;

namespace WMSMVC.Domain.Model
{
    public class WorkersData
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int WorkerId { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
