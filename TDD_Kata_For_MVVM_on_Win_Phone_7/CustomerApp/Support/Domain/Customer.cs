using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerApp.Support.Domain
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Customer()
        {
            this.FirstName = null;
            this.LastName = null;
        }
    }
}
