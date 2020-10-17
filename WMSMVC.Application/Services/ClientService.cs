using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMSMVC.Application.Intefaces;
using WMSMVC.Application.ViewModels.Client;
using WMSMVC.Domain.Intefaces;
using WMSMVC.Domain.Model;
using WMSMVC.Web.Models;

namespace WMSMVC.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public int AddClient(ClientVM newClient)
        {
            var client = _mapper.Map<Client>(newClient);
            var id = _clientRepository.AddNew(client);
            return id;
        }
        public int AddClientAddress(ClientAddresDetailVm clientAddress)
        {
            var address = _mapper.Map<ClientAdress>(clientAddress);
            var id = _clientRepository.AddNewAdress(address);
            return id;
        }
        public int AddClientContact(ClientContactDetailVM clientContact)
        {
            var contact = _mapper.Map<ClientData>(clientContact);
            var id = _clientRepository.AddNewContactDetail(contact);
            return id;
        }
        public void UpdateClient(ClientVM newClient)
        {
            var client = _mapper.Map<Client>(newClient);
            _clientRepository.Update(client);
        }

        public void DeleteClient(int id)
        {
            _clientRepository.Remove(id);
        }

        public ListClientForListVM GetAllActiveClientsForList(int pageSize, int? pageNumber, string searchString)
        {
            var clients = _clientRepository.GetAllActiveClients().Where(c=>c.Name.StartsWith(searchString))
                .ProjectTo<ClientVM>(_mapper.ConfigurationProvider).ToList();
            var pageNo = pageNumber ?? 1;
            var clientsToShow = clients.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var clientList = new ListClientForListVM()
            {
                PageSize = pageSize,
                CurrentPage=pageNo,
                SearchString=searchString,
                Clients = clientsToShow,
                Count = clients.Count
            };
            return clientList; ;
        }

        public ListClientForListVM GetAllClientsForList()
        {
            var clients = _clientRepository.GetAllClients()
                .ProjectTo<ClientVM>(_mapper.ConfigurationProvider).ToList();
            var clientList = new ListClientForListVM()
            {
                Clients = clients,
                Count = clients.Count
            };
            return clientList;
        }

        public ClientVM GetClient(int Id)
        {
            var client = _clientRepository.GetClient(Id);
            var clientVM = _mapper.Map<ClientVM>(client);
            return clientVM;
        }

        public ListClientAddressVM GetClientAddres(int id)
        {
            var adress = _clientRepository.GetClientAdress(id).ProjectTo<ClientAddresDetailVm>(_mapper.ConfigurationProvider).ToList();
            var list = new ListClientAddressVM()
            {
                ClientAddres = adress,
                Count = adress.Count,
                ClientId = id
            };
            return list;
        }

        public ListClientContactVM GetClientContactDetail(int id)
        {
            var contact = _clientRepository.GetClientContacts(id).ProjectTo<ClientContactDetailVM>(_mapper.ConfigurationProvider).ToList();
            var list = new ListClientContactVM()
            {
                ClientContacts = contact,
                Count=contact.Count,
                ClientId=id
            };
            return list;
        }

        public ClientDetailVM GetClientDetails(int clientId)
        {
            var client = _clientRepository.GetClient(clientId);
            //var clientVM = _mapper.Map<ClientDetailVM>(client);
            ClientDetailVM clientVM;
            if (client == null)
            {
                clientVM = new ClientDetailVM();
            }
            else
            {
                clientVM = _mapper.Map<ClientDetailVM>(client);
                var adress = client.ClientAdresses;
                var contact = client.ClientDatas;
                clientVM.Addreses = adress.AsQueryable().ProjectTo<ClientAddresDetailVm>(_mapper.ConfigurationProvider).ToList();
                clientVM.ContactDetails = contact.AsQueryable().ProjectTo<ClientContactDetailVM>(_mapper.ConfigurationProvider).ToList();
            }
            return clientVM;
        }

        public void UpdateContact(ClientContactDetailVM clientModel)
        {
            var client = _mapper.Map<ClientData>(clientModel);
            _clientRepository.UpdateContact(client);
        }

        public void UpdateAddress(ClientAddresDetailVm clientModel)
        {
            var client = _mapper.Map<ClientAdress>(clientModel);
            _clientRepository.UpdateAddress(client);
        }

        public void DeleteClientAddress(int id)
        {
            _clientRepository.RemoveAddress(id);
        }

        public void DeleteClientContact(int id)
        {
            _clientRepository.RemoveContact(id);
        }
    }
}
