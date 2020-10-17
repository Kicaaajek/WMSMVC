using System;
using System.Collections.Generic;
using System.Text;

namespace WMSMVC.Application.ViewModels.Client
{
    public class ListClientAddressVM
    {
        public List<ClientAddresDetailVm> ClientAddres { get; set; }
        public int Count { get; set; }
        public int ClientId { get; set; }
    }
}
