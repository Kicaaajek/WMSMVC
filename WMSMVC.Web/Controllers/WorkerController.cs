using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Host;
using WMSMVC.Application.Intefaces;
using WMSMVC.Application.ViewModels.Worker;

namespace WMSMVC.Web.Controllers
{
    public class WorkerController : Controller
    {
        private readonly IWorkerService _workerService;
        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            var model = _workerService.GetWorkers();
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _workerService.GetWorkerDetail(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddressDetails(int id)
        {
            var model = _workerService.GetWorkerAdressDetail(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult ContactDetails(int id)
        {
            var model = _workerService.GetWorkerContactDetail(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new NewWorkerVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NewWorkerVM newWorker)
        {
            _workerService.AddWorker(newWorker);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateAddress()
        {
            return View(new WorkerAdressDetailVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAddress(WorkerAdressDetailVM address)
        {
            _workerService.AddAddress(address);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            return View(new WorkerContactDetailVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateContact(WorkerContactDetailVM workerContact)
        {
            _workerService.AddContact(workerContact);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditWorker(int id)
        {
            var model = _workerService.GetWorkerDetail(id);
            if (model == null)
            {
                return View(model);
            }
            else
            {
                return View(new NewWorkerVM());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditWorker(NewWorkerVM worker)
        {
            if (ModelState.IsValid)
            {
                _workerService.UpdateWorker(worker);
                return RedirectToAction("Index");
            }
            return View(worker);
        }

        [HttpGet]
        public IActionResult EditAddress(int id)
        {
            var model = _workerService.GetWorkerAdressDetail(id);
            if (model == null)
            {
                return View(model);
            }
            else
            {
                return View(new WorkerAdressDetailVM());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAddress(WorkerAdressDetailVM address)
        {
            if (ModelState.IsValid)
            {
                _workerService.UpdateAddress(address);
                return RedirectToAction("Index");
            }
            return View(address);
        }

        [HttpGet]
        public IActionResult EditContact(int id)
        {
            var model = _workerService.GetWorkerContactDetail(id);
            if (model == null)
            {
                return View(model);
            }
            else
            {
                return View(new WorkerContactDetailVM());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditContact(WorkerContactDetailVM contact)
        {
            if (ModelState.IsValid)
            {
                _workerService.UpdateContact(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        [HttpGet]
        public IActionResult DeleteWorker(int id)
        {
            _workerService.RemoveWorker(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteAddress(int id)
        {
            _workerService.RemoveAddress(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteContact(int id)
        {
            _workerService.RemoveContact(id);
            return RedirectToAction("Index");
        }
    }
}
