using System;
using System.Collections.Generic;
using System.Text;

namespace CIS.Core.Models
{
    public class RepClientInformation
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        public string PrimaryEmail { get; set; }
        public string AddressType { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Suburb { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string ContactDescription { get; set; }

        public string ContactInfo { get; set; }

    }
}
