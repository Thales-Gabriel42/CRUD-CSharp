using System;
using Microsoft.Data.SqlClient;
using CRUD.Models;

namespace CRUD.DAL
{
    public static class ClientsDAL
    {
        private static SqlConnection conn = new SqlConnection(Data.ConnectionString);

        public static void Insert(ClientInformation client)
        {
            string query = "INSERT INTO clients (id, name, phone, email, address, birth_date, register_date)"
                        +   "VALUES (" + client.Id + ", '" + client.Name + "', '" + client.Phone + "', '" + client.Email + "', '" + client.Address + "', '" + client.BirthDate.ToString("yyyy-MM-dd") + "', '" + client.RegisterDate.ToString("yyyy-MM-dd HH:mm:ss") + "');";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {              
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }

        }

        public static void Update(ClientInformation client)
        {
            string query = "UPDATE clients SET name = '" + client.Name + "', phone = '" + client.Phone + "', email = '" + client.Email + "', address = '" + client.Address + "', birth_date = '" + client.BirthDate.ToString("yyyy-MM-dd") + "' WHERE id = " + client.Id + ";";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public static void Delete(ClientInformation client)
        {
            string query = "DELETE FROM clients WHERE id = " + client.Id + ";";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public static int RegisterCount()
        {
            string query = "SELECT COUNT(*) FROM clients;";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                cmd.Connection.Open();
                return (Int32)cmd.ExecuteScalar();
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public static ClientInformation Search(int id)
        {
            string query = "SELECT * FROM clients WHERE id = " + id + ";";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                ClientInformation client = new ClientInformation();
                if (reader.Read())
                {
                    client.Id = int.Parse(reader[0].ToString());
                    client.Name = reader[1].ToString();
                    client.Phone = reader[2].ToString();
                    client.Email = reader[3].ToString();
                    client.Address = reader[4].ToString();
                    client.BirthDate = DateTime.Parse(reader[5].ToString());
                    client.RegisterDate = DateTime.Parse(reader[6].ToString());
                    return client;
                }
                else
                {
                    throw new Exception("Client not found!");
                }
                
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
    }
}
