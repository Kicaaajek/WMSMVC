using System;
using System.Collections.Generic;
using System.Text;
using WMSMVC.Application.ViewModels.Client;
using WMSMVC.Web.Models;

namespace WMSMVC.Application.Intefaces
{
    public interface IClientService
    {
        ListClientForListVM GetAllClientsForList();
        ListClientForListVM GetAllActiveClientsForList(int pageSize, int? pageNo, string searchString);
        int AddClient(ClientVM client);
        int AddClientAddress(ClientAddresDetailVm clientAddress);
        int AddClientContact(ClientContactDetailVM clientContact);
        void UpdateClient(ClientVM newClient);
        void DeleteClient(int id);
        ClientVM GetClient(int Id);
        ListClientContactVM GetClientContactDetail(int id);
        ListClientAddressVM GetClientAddres(int id);
        ClientDetailVM GetClientDetails(int clientId);
        void UpdateContact(ClientContactDetailVM clientModel);
        void UpdateAddress(ClientAddresDetailVm clientModel);
        void DeleteClientAddress(int id);
        void DeleteClientContact(int id);
    }
}
