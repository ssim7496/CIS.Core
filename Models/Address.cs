using System;
using System.Collections.Generic;
using System.Text;

namespace CIS.Core.Models
{
    public class Address
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public string AddressType { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
