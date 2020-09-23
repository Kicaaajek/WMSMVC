using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WMSMVC.Domain.Model;

namespace WMSMVC.Web.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<Adress> Adresses { get; set; }
        public virtual ClientData ClientData { get; set; }
        public Client(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}
