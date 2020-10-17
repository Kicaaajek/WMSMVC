using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WMSMVC.Application.Mapping;
using WMSMVC.Domain.Model;

namespace WMSMVC.Application.ViewModels.Worker
{
    public class WorkerAdressDetailVM : IMapFrom<WorkersAdress>
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int NumberOfHome { get; set; }
        public int? NumberOfFlat { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public int WorkerId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<WorkersAdress, WorkerAdressDetailVM>().ReverseMap();
        }
    }
}
