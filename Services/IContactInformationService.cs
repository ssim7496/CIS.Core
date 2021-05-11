using CIS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIS.Core.Services
{
    public interface IContactInformationService
    {
        int AddContactInformation(ContactInformation contactInfo);
    }
}
