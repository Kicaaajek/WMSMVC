using System;
using System.Collections.Generic;
using System.Text;
using WMSMVC.Web.Models;

namespace WMSMVC.Domain.Model
{
    public class ClientData
    {
        public int Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
