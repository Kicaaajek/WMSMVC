using System;
using System.Collections.Generic;
using System.Text;
using WMSMVC.Application.ViewModels.Client;
using WMSMVC.Application.ViewModels.Worker;

namespace WMSMVC.Application.Intefaces
{
    public interface IWorkerService
    {
        int AddWorker(NewWorkerVM worker);
        int AddAddress(WorkerAdressDetailVM addressVM);
        int AddContact(WorkerContactDetailVM contact);
        void RemoveWorker(int id);
        void RemoveAddress(int id);
        void RemoveContact(int id);
        void UpdateAddress(WorkerAdressDetailVM address);
        void UpdateContact(WorkerContactDetailVM contact);
        NewWorkerVM GetWorkerDetail(int id);
        ListNewWorkerVM GetWorkers();
        WorkerAdressDetailVM GetWorkerAdressDetail(int id);
        WorkerContactDetailVM GetWorkerContactDetail(int id);
        List<WorkerStandardVM> GetWorkerWithoutStandard(DateTime data);
        List<WorkerStandardVM> GetWorkerStandard(int id);
        void UpdateWorker(NewWorkerVM worker);
    }
}
