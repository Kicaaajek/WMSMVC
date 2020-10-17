using System;
using System.Collections.Generic;
using System.Text;

namespace WMSMVC.Domain.Model
{
    public class WorkersAdress
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int NumberOfHome { get; set; }
        public int? NumberOfFlat { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public int WorkerId { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
