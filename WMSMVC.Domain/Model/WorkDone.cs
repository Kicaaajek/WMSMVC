using System;
using System.Collections.Generic;
using System.Text;

namespace WMSMVC.Domain.Model
{
    public class WorkDone
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int QuantityOfWork { get; set; }
        public bool Standard { get; set; }
        public int WorkerId { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
