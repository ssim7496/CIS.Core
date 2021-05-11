using CIS.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CIS.Core.Services
{
    public class ClientService : IClientService
    {
        public ClientService(string conn)
        {
            DBHelper.SetConnectionString(conn);
        }

        public int AddClient(Client client)
        {
            SqlParameter[] param = new SqlParameter[]
          {
                new SqlParameter("@FirstName", client.FirstName),
                new SqlParameter("@LastName", client.LastName),
                new SqlParameter("@Gender", client.Gender),
                new SqlParameter("@PrimaryCell", client.PrimaryCell),
                new SqlParameter("@PrimaryEmail", client.PrimaryEmail)
          };

            return DBHelper.ExecuteScalar("addClient", CommandType.StoredProcedure, param);
        }

        public int DeleteClient(int ID)
        {
            SqlParameter[] param = new SqlParameter[]
           {
                new SqlParameter("@ID", ID)
           };
            return DBHelper.ExecuteNonQuery("deleteClient", CommandType.StoredProcedure, param);
        }

        public Client GetClient(int ID)
        {
            Client client = null;

            SqlParameter[] param = new SqlParameter[]
           {
                new SqlParameter("@ID", ID)
           };

            using (DataTable dt = DBHelper.ExecuteParamerizedSelectCommand("getClient", CommandType.StoredProcedure, param))
            {
                if (dt.Rows.Count > 0)
                {
                    client = new Client();
                    client.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                    client.FirstName = dt.Rows[0]["FirstName"].ToString();
                    client.LastName = dt.Rows[0]["LastName"].ToString();
                    client.Gender = string.IsNullOrEmpty(dt.Rows[0]["Gender"].ToString()) ? -1 : int.Parse(dt.Rows[0]["Gender"].ToString());
                    client.PrimaryCell = dt.Rows[0]["PrimaryCell"].ToString();
                    client.PrimaryEmail = dt.Rows[0]["PrimaryEmail"].ToString();
                }
            }

            return client;
        }

        public IEnumerable<Client> GetClients()
        {
            List<Client> clients = null;

            using (DataTable dt = DBHelper.ExecuteSelectCommand("getClients", CommandType.StoredProcedure))
            {
                if (dt.Rows.Count > 0)
                {
                    clients = new List<Client>();

                    foreach (DataRow dr in dt.Rows)
                    {
                        Client client = new Client();
                        client.ID = int.Parse(dr["ID"].ToString());
                        client.FirstName = dr["FirstName"].ToString();
                        client.LastName = dr["LastName"].ToString();
                        client.Gender = string.IsNullOrEmpty(dr["Gender"].ToString()) ? -1 : int.Parse(dr["Gender"].ToString());
                        client.PrimaryCell = dr["PrimaryCell"].ToString();
                        client.PrimaryEmail = dr["PrimaryEmail"].ToString();
                        clients.Add(client);
                    }
                }
            }

            return clients;
        }

        public int UpdateClient(Client client)
        {
            SqlParameter[] param = new SqlParameter[]
           {
                new SqlParameter("@ID", client.ID),
                new SqlParameter("@FirstName", client.FirstName),
                new SqlParameter("@LastName", client.LastName),
                new SqlParameter("@Gender", client.Gender),
                new SqlParameter("@PrimaryCell", client.PrimaryCell),
                new SqlParameter("@PrimaryEmail", client.PrimaryEmail)
           };
            return DBHelper.ExecuteNonQuery("updateClient", CommandType.StoredProcedure, param);

        }
    }
}
