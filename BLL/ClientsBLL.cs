using System;
using CRUD.DAL;
using CRUD.Models;

namespace CRUD.BLL
{
    public static class ClientsBLL
    {
        public static void Insert(ClientInformation client)
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
            ClientsDAL.Insert(client);
        }

        public static void Update(ClientInformation client)
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
            ClientsDAL.Update(client);
        }

        public static void Delete(ClientInformation client)
        {
            ClientsDAL.Delete(client);
        }

        public static ClientInformation Search(int id)
        {
            if(id > 0)
            {
                return ClientsDAL.Search(id);
            }
            else
            {
                throw new Exception("The Id must be valid");
            }
        }

        public static int RegisterCount()
        {
            return ClientsDAL.RegisterCount();
        }
    }
}
