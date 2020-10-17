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
        public string Company { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string NIP { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<ClientAdress> ClientAdresses { get; set; }
        public virtual ICollection<ClientData> ClientDatas { get; set; }
        public virtual ICollection<Basket> Baskets { get; set; }
    }
}
