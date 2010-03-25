using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Silverlight.Testing.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerApp.Support.Repository;
using CustomerApp.Support.Domain;
using CustomerApp.Support.ViewModel;

namespace CustomerApp.Support.Tests.Unit
{
    [TestClass]
    public class CustomerSaveCommandTests
    {
        private ICustomerRepository _customerRepository;

        [TestInitialize]
        public void SetUp()
        {
            _customerRepository = new FakeCustomerRepository();
        }

        [TestMethod]
        public void Constructor_CustomerRepositoryInput_ImplementsICommand()
        {
            var customer = new Customer() { FirstName = "June", LastName = "Smith" };
            var sut = new CustomerSaveCommand(_customerRepository, customer);
            Assert.IsInstanceOfType(sut, typeof(ICommand));
        }

    }
}
