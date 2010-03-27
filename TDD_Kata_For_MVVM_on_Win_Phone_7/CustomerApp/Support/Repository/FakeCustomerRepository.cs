using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerApp.Support.Repository;
using CustomerApp.Support.Domain;

namespace CustomerApp.Support.Repository
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        private bool _saveCommandCalled;

        public FakeCustomerRepository()
        {
            _saveCommandCalled = false;
        }


        public bool SaveCommandCalled
        {
            get
            {
                return _saveCommandCalled;
            }
        }


        public void SaveCustomer(Customer customer)
        {
            // call to not-yet-created ORM implementation to save Customer to data store / WCF
            _saveCommandCalled = true;
        }
    }
}
