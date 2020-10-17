using System;
using System.Collections.Generic;
using System.Text;

namespace WMSMVC.Application.ViewModels.Client
{
    public class ListClientForListVM
    {
        public List<ClientVM> Clients { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
    }
}
