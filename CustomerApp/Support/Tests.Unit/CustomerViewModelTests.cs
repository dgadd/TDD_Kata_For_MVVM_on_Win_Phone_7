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
//using Rhino.Mocks;
using CustomerApp.Support.Repository;
using CustomerApp.Support.ViewModel;
using System.Collections.Generic;
using CustomerApp.Support.Domain;
using System.ComponentModel;

namespace CustomerApp.Support.Tests.Unit
{
    [TestClass]
    public class CustomerViewModelTests
    {
        private ICustomerRepository _customerRepository;

        [TestInitialize]
        public void SetUp()
        {
            _customerRepository = new FakeCustomerRepository();
        }

        [TestMethod]
        public void Constructor_CustomerAndRepositoryInput_InstantiatesSuccessfully()
        {
            var customer = new Customer { FirstName = "June", LastName = "Wong" };
            var sut = new CustomerViewModel(_customerRepository, customer);
            Assert.IsNotNull(sut);
        }

        [TestMethod]
        public void Constructor_CustomerAndRepositoryInput_CustomerPropertiesEqualViewModelProperties()
        {
            var customer = new Customer { FirstName = "June", LastName = "Wong" };
            var sut = new CustomerViewModel(_customerRepository, customer);

            Assert.AreEqual(customer.FirstName, sut.FirstName);
            Assert.AreEqual(customer.LastName, sut.LastName);
        }

        [TestMethod]
        [ExpectedException(typeof(VerifyPropertyNameException))]
        public void VerifyPropertyNameMethod_NonExistentPropertyString_ThrowsException()
        {
            var customer = new Customer() { FirstName = "June", LastName = "Smith" };
            var sut = new CustomerViewModel(_customerRepository, customer);
            sut.VerifyPropertyName("NonExistentPropertyName");
        }

        [TestMethod]
        public void Constructor_CustomerInput_ImplementsINotifyPropertyChanged()
        {
            var customer = new Customer() { FirstName = "June", LastName = "Smith" };
            var sut = new CustomerViewModel(_customerRepository, customer);
            Assert.IsInstanceOfType(sut, typeof(INotifyPropertyChanged));
        }

        [TestMethod]
        public void ClassProperties_WhenSet_PropertyChangedEventFires()
        {
            var customer = new Customer();
            var sut = new CustomerViewModel(_customerRepository, customer);
            var receivedEvents = new List<string>();
            sut.PropertyChanged += ((sender, e) => receivedEvents.Add(e.PropertyName));

            sut.FirstName = "Sabrina";
            Assert.AreEqual(1, receivedEvents.Count);
            Assert.AreEqual("FirstName", receivedEvents[0]);
            sut.LastName = "Moore";
            Assert.AreEqual(2, receivedEvents.Count);
            Assert.AreEqual("LastName", receivedEvents[1]);
        }

        [TestMethod]
        public void DomainProperties_ReassignedValues_ViewModelPropertiesTrackChanges()
        {
            var customer = new Customer() { FirstName = "June", LastName = "Smith" };
            var sut = new CustomerViewModel(_customerRepository, customer);

            Assert.AreEqual(customer.FirstName, sut.FirstName);
            Assert.AreEqual(customer.LastName, sut.LastName);

            customer.FirstName = "New First Name";
            customer.LastName = "New Last Name";

            Assert.AreEqual(customer.FirstName, sut.FirstName);
            Assert.AreEqual(customer.LastName, sut.LastName);
        }

        [TestMethod]
        public void CustomerSaveCommandPropertyCanExecute_ValidCustomer_ReturnsTrue()
        {
            var customer = new Customer() { FirstName = "June", LastName = "Smith" };
            var sut = new CustomerViewModel(_customerRepository, customer);

            Assert.IsTrue(sut.CustomerSaveCommand.CanExecute(null));
        }

        [TestMethod]
        public void CustomerSaveCommandPropertyCanExecute_InvalidCustomer_ReturnsTrue()
        {
            var customer = new Customer() { FirstName = "", LastName = "" };
            var sut = new CustomerViewModel(_customerRepository, customer);

            Assert.IsFalse(sut.CustomerSaveCommand.CanExecute(null));
        }

        [TestMethod]
        public void CustomerSaveCommandPropertyExecute_ValidCustomer_RepositoryValidatesCallOccured()
        {
            var customer = new Customer() { FirstName = "June", LastName = "Smith" };
            var sut = new CustomerViewModel(_customerRepository, customer);

            sut.CustomerSaveCommand.Execute(null);
            Assert.IsTrue(_customerRepository.SaveCommandCalled);
        }

    }
}
