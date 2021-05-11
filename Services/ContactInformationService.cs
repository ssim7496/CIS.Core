using CIS.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CIS.Core.Services
{
    public class ContactInformationService : IContactInformationService
    {
        public ContactInformationService(string conn)
        {
            DBHelper.SetConnectionString(conn);
        }

        public int AddContactInformation(ContactInformation contactInfo)
        {
            SqlParameter[] param = new SqlParameter[]
          {
                new SqlParameter("@ClientID", contactInfo.ClientID),
                new SqlParameter("@ContactType", contactInfo.ContactType),
                new SqlParameter("@ContactDescription", contactInfo.ContactDescription),
                new SqlParameter("@ContactInfo", contactInfo.ContactInfo)
          };

            return DBHelper.ExecuteScalar("addContactInformation", CommandType.StoredProcedure, param);
        }
    }
}
