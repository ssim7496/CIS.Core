using System;
using System.Collections.Generic;
using System.Text;

namespace CIS.Core.Models
{
    public class ContactInformation
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public int ContactType { get; set; }
        public string ContactDescription { get; set; }
        public string ContactInfo { get; set; }
    }
}
