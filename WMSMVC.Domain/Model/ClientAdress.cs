using System;
using System.Collections.Generic;
using System.Text;
using WMSMVC.Web.Models;

namespace WMSMVC.Domain.Model
{
    public class ClientAdress
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int NumberOfHome { get; set; }
        public int? NumberOfFlat { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
