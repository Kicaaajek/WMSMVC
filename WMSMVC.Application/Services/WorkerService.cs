using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMSMVC.Application.Intefaces;
using WMSMVC.Application.ViewModels.Client;
using WMSMVC.Application.ViewModels.Worker;
using WMSMVC.Domain.Intefaces;
using WMSMVC.Domain.Model;

namespace WMSMVC.Application.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _workerRepository;
        private readonly IMapper _mapper;
        public WorkerService(IWorkerRepository workerRepository, IMapper mapper)
        {
            _workerRepository = workerRepository;
            _mapper = mapper;
        }
        public int AddAddress(WorkerAdressDetailVM addressVM)
        {
            var address = _mapper.Map<WorkersAdress>(addressVM);
            var id=_workerRepository.AddAddress(address);
            return id;
        }

        public int AddContact(WorkerContactDetailVM contact)
        {
            var cont = _mapper.Map<WorkersData>(contact);
            var id= _workerRepository.AddContact(cont);
            return id;
        }

        public int AddWorker(NewWorkerVM worker)
        {
            var w = _mapper.Map<Worker>(worker);
            var id = _workerRepository.AddNew(w);
            return id;
        }

        public WorkerAdressDetailVM GetWorkerAdressDetail(int id)
        {
            var address = _workerRepository.GetWorkersAdresses(id);
            var addressVM=_mapper.Map<WorkerAdressDetailVM>(address);
            return addressVM;
        }

        public WorkerContactDetailVM GetWorkerContactDetail(int id)
        {
            var contact = _workerRepository.GetWorkersData(id);
            var contactVM = _mapper.Map<WorkerContactDetailVM>(contact);
            return contactVM;
        }

        public NewWorkerVM GetWorkerDetail(int id)
        {
            var worker = _workerRepository.GetWorker(id);
            var workerVM = _mapper.Map<NewWorkerVM>(worker);
            return workerVM;
        }

        public ListNewWorkerVM GetWorkers()
        {
           var workers= _workerRepository.GetWorkers().ProjectTo<NewWorkerVM>(_mapper.ConfigurationProvider).ToList();
            var workersVM = new ListNewWorkerVM()
            {
                Workers = workers,
                Count = workers.Count
            };
            return workersVM;
        }

        public List<WorkerStandardVM> GetWorkerStandard(int id)
        {
            var standards = _workerRepository.GetWorkDones(id).ProjectTo<WorkerStandardVM>(_mapper.ConfigurationProvider).ToList();
            return standards;
        }

        public List<WorkerStandardVM> GetWorkerWithoutStandard(DateTime data)
        {
            var standards = _workerRepository.GetWorkerWithoutStandard(data).ProjectTo<WorkerStandardVM>(_mapper.ConfigurationProvider).ToList();
            return standards;
        }

        public void RemoveAddress(int id)
        {
            _workerRepository.RemoveAddress(id);
        }

        public void RemoveContact(int id)
        {
            _workerRepository.RemoveContact(id);
        }

        public void RemoveWorker(int id)
        {
            _workerRepository.Remove(id);
        }

        public void UpdateAddress(WorkerAdressDetailVM address)
        {
            var a=_mapper.Map<WorkersAdress>(address);
            _workerRepository.UpdateAddress(a);
        }

        public void UpdateWorker(NewWorkerVM worker)
        {
            var w = _mapper.Map<Worker>(worker);
            _workerRepository.Update(w);
        }

        public void UpdateContact(WorkerContactDetailVM contact)
        {
            var c = _mapper.Map<WorkersData>(contact);
            _workerRepository.UpdateContact(c);
        }
    }
}
