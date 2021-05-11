using CIS.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CIS.Core.Services
{
    public class ReportService : IReportService
    {
        public ReportService(string conn)
        {
            DBHelper.SetConnectionString(conn);
        }
        public IEnumerable<RepClientInformation> GetClientInformation()
        {
            List<RepClientInformation> clients = null;

            using (DataTable dt = DBHelper.ExecuteSelectCommand("getClientInformation", CommandType.StoredProcedure))
            {
                if (dt.Rows.Count > 0)
                {
                    clients = new List<RepClientInformation>();

                    foreach (DataRow dr in dt.Rows)
                    {
                        RepClientInformation clientInfo = new RepClientInformation();
                        clientInfo.ID = int.Parse(dr["ID"].ToString());
                        clientInfo.FirstName = dr["FirstName"].ToString();
                        clientInfo.LastName = dr["LastName"].ToString();
                        clientInfo.Gender = dr["Gender"].ToString();
                        clientInfo.PrimaryEmail = dr["PrimaryEmail"].ToString();
                        clientInfo.AddressType = dr["AddressType"].ToString();
                        clientInfo.AddressLine1 = dr["AddressLine1"].ToString();
                        clientInfo.AddressLine2 = dr["AddressLine2"].ToString();
                        clientInfo.Suburb = dr["Suburb"].ToString();
                        clientInfo.City = dr["City"].ToString();
                        clientInfo.PostalCode = dr["PostalCode"].ToString();
                        clientInfo.ContactDescription = dr["ContactDescription"].ToString();
                        clientInfo.ContactInfo = dr["ContactInfo"].ToString();
                        clients.Add(clientInfo);
                    }
                }
            }

            return clients;
        }
    }
}
