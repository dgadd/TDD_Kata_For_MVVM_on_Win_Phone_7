using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerApp.Support.Repository;
using CustomerApp.Support.Domain;
using System.ComponentModel;
using CustomerApp.Support.Tests.Unit;

namespace CustomerApp.Support.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        private ICustomerRepository _customerRepository;
        private Customer _customer;
        private CustomerSaveCommand _saveCommand;

        public CustomerViewModel(ICustomerRepository customerRepository, Customer customer)
        {
            _customerRepository = customerRepository;
            _customer = customer;
        }

        public string FirstName
        {
            get
            {
                return _customer.FirstName;
            }
            set
            {
                if(_customer.FirstName != null
                    && _customer.FirstName.Equals(value))
                    return;
                _customer.FirstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get
            {
                return _customer.LastName;
            }
            set
            {
                if (_customer.LastName != null
                    && _customer.LastName.Equals(value))
                    return;
                _customer.LastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public CustomerSaveCommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new CustomerSaveCommand(_customerRepository, _customer);
                }
                return _saveCommand;
            }
        }
    }
}
