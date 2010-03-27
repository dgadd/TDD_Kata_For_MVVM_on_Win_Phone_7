using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Silverlight.Testing;
using CustomerApp.Support.Domain;
using CustomerApp.Support.ViewModel;
using CustomerApp.Support.Repository;

namespace CustomerApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            SupportedOrientations = SupportedPageOrientation.Portrait | SupportedPageOrientation.Landscape;

            const bool runUnitTests = false;

            if (runUnitTests)
            {
                Content = UnitTestSystem.CreateTestPage();
                IMobileTestPage imtp = Content as IMobileTestPage;

                if (imtp != null)
                {
                    BackKeyPress += (x, xe) => xe.Cancel = imtp.NavigateBack();
                }
            }


            this.DataContext = this.CustomerViewModel;
        }


        private CustomerViewModel CustomerViewModel
        {
            get
            {
                ICustomerRepository customerRepository = new FakeCustomerRepository();
                var customer = new Customer();
                return new CustomerViewModel(customerRepository, customer);
            }
        }
    }
}