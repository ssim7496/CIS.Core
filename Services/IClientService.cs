using CIS.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CIS.Core.Services
{
    public interface IClientService
    {
        IEnumerable<Client> GetClients();
        Client GetClient(int ID);
        int AddClient(Client client);
        int UpdateClient(Client client);
        int DeleteClient(int ID);
    }
}
