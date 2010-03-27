using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerApp.Support.Domain;

namespace CustomerApp.Support.Repository
{
    public interface ICustomerRepository
    {
        bool SaveCommandCalled { get; }

        void SaveCustomer(Customer customer);
    }
}
