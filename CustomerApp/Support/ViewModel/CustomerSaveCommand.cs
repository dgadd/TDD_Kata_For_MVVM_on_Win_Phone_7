using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using CustomerApp.Support.Repository;
using CustomerApp.Support.Domain;

namespace CustomerApp.Support.ViewModel
{
    public class CustomerSaveCommand : ICommand
    {
        private ICustomerRepository _customerRepository;
        private Customer _customer;

        public CustomerSaveCommand(ICustomerRepository customerRepository, Customer customer)
        {
            _customerRepository = customerRepository;
            _customer = customer;
        }

        public bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_customer.FirstName)
                && !string.IsNullOrEmpty(_customer.LastName);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (this.CanExecute(null))
            {
                _customerRepository.SaveCustomer(_customer);
            }
        }
    }
}