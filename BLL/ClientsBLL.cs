using System;
using CRUD.DAL;
using CRUD.Models;

namespace CRUD.BLL
{
    public class ClientsBLL
    {
        public void Insert(ClientInformation client)
        {
            if (client.Name.Trim().Length == 0)
            {
                throw new Exception("The client name can't be null!");
            }
            if((DateTime.Today.Year - client.BirthDate.Year) < 16)
            {
                throw new Exception("The client must be 16 or older!");
            }
            client.Email = client.Email.ToLower();
            ClientsDAL cd = new ClientsDAL();
            cd.Insert(client);
        }

        public void Update(ClientInformation client)
        {
            if (client.Name.Trim().Length == 0)
            {
                throw new Exception("The client name can't be null!");
            }
            if ((DateTime.Today.Year - client.BirthDate.Year) < 16)
            {
                throw new Exception("The client must be 16 or older!");
            }
            client.Email = client.Email.ToLower();
            ClientsDAL cd = new ClientsDAL();
            cd.Update(client);
        }

        public void Delete(int id)
        {
            ClientsDAL cd = new ClientsDAL();
            cd.Delete(id);
        }

        public ClientInformation Search(int id)
        {
            ClientsDAL cd = new ClientsDAL();
            return cd.Search(id);
        }
    }
}
