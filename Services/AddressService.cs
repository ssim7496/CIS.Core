using CIS.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CIS.Core.Services
{
    public class AddressService : IAddressService
    {
        public AddressService(string conn)
        {
            DBHelper.SetConnectionString(conn);
        }

        public int AddAddress(Address address)
        {
            SqlParameter[] param = new SqlParameter[]
          {
                new SqlParameter("@ClientID", address.ClientID),
                new SqlParameter("@AddressType", address.AddressType),
                new SqlParameter("@AddressLine1", address.AddressLine1),
                new SqlParameter("@AddressLine2", address.AddressLine2),
                new SqlParameter("@Suburb", address.Suburb),
                new SqlParameter("@City", address.City),
                new SqlParameter("@PostalCode", address.PostalCode)
          };

            return DBHelper.ExecuteScalar("addAddress", CommandType.StoredProcedure, param);
        }
    }
}
