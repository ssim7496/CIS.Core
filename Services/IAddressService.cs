using CIS.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIS.Core.Services
{
    public interface IAddressService
    {
        int AddAddress(Address address);
    }
}
