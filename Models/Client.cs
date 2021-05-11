using System;
using System.Collections.Generic;
using System.Text;

namespace CIS.Core.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public string PrimaryCell { get; set; }

        public string PrimaryEmail { get; set; }

    }
}
