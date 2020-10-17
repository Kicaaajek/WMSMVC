using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMSMVC.Application.Intefaces;
using WMSMVC.Application.ViewModels.Client;

namespace WMSMVC.Web.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _clientService.GetAllActiveClientsForList(5,1,"");
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo,string searchString)
        {
            if(!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if(searchString is null)
            {
                searchString = String.Empty;
            }
            var model = _clientService.GetAllActiveClientsForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int clientId)
        {
            var model = _clientService.GetClientDetails(clientId);
           
            return View(model);
        }

        [HttpGet]
        public IActionResult AddressDetails(int id)
        {
            var model = _clientService.GetClientAddres(id);
            if (model == null)
            {
                return RedirectToAction("AddAddress");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult ContactsDetails(int id)
        {
            var model = _clientService.GetClientContactDetail(id);
            if (model == null)
            {
                return RedirectToAction("AddContact");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new ClientVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ClientVM clientModel)
        {
            _clientService.AddClient(clientModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddAddress()
        {
            return View(new ClientAddresDetailVm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAddress(ClientAddresDetailVm clientModel)
        {
            _clientService.AddClientAddress(clientModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddContact()
        {
            return View(new ClientContactDetailVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddContact(ClientContactDetailVM clientModel)
        {
            _clientService.AddClientContact(clientModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var client = _clientService.GetClient(id);
            
                return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClientVM clientModel)
        {
            if(ModelState.IsValid)
            {
                _clientService.UpdateClient(clientModel);
                return RedirectToAction("Index");
            }
            return View(clientModel);
        }

        [HttpGet]
        public IActionResult EditContact(int id)
        {
            var client = _clientService.GetClientContactDetail(id);
            if (client == null)
            {
                return View(client);
            }
            else
            {
                return View(new ClientContactDetailVM());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditContact(ClientContactDetailVM clientModel)
        {
            if (ModelState.IsValid)
            {
                _clientService.UpdateContact(clientModel);
                return RedirectToAction("Index");
            }
            return View(clientModel);
        }

        [HttpGet]
        public IActionResult EditAddress(int id)
        {
            var client = _clientService.GetClientAddres(id);
            if (client == null)
            {
                return View(client);
            }
            else
            {
                return View(new ClientAddresDetailVm());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAddress(ClientAddresDetailVm clientModel)
        {
            if (ModelState.IsValid)
            {
                _clientService.UpdateAddress(clientModel);
                return RedirectToAction("Index");
            }
            return View(clientModel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _clientService.DeleteClient(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteAddress(int id)
        {
            _clientService.DeleteClientAddress(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteContact(int id)
        {
            _clientService.DeleteClientContact(id);
            return RedirectToAction("Index");
        }
    }
}
