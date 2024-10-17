using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;
using MMABooksDBClasses;

namespace MMABooksTests
{
    public class CustomerDBTests
    {

        [Test]
        public void TestGetCustomer()
        {
            Customer c = CustomerDB.GetCustomer(1);
            Assert.AreEqual(1, c.CustomerID);
        }

        [Test]
        public void TestCreateCustomer()
        {
            Customer c = new Customer();
            c.Name = "Mickey Mouse";
            c.Address = "101 Main Street";
            c.City = "Orlando";
            c.State = "FL";
            c.ZipCode = "10101";

            int customerID = CustomerDB.AddCustomer(c);
            c = CustomerDB.GetCustomer(customerID);
            Assert.AreEqual("Mickey Mouse", c.Name);
        }

        [Test]
        // The method that will be used to test the DeleteCustomer method in
        // CustomerDB
        public void TestDeleteCustomer()
        {
            //object with "Arcane, Ryan", "101 Main Street", "Orlando", "FL", "71234"
            Customer customer = new Customer();
            customer.Name = "Arcane, Ryan";
            customer.Address = "101 Main Street";
            customer.City = "Orlando";
            customer.State = "FL";
            customer.ZipCode = "71234";

            // Add the created customer to the database 
            // and gets it automatically created id to customerID.
            int customerID = CustomerDB.AddCustomer(customer);
            // Using the customerID, we will update the customer object
            // to have the information from the database including the customer ID
            customer = CustomerDB.GetCustomer(customerID);
            // Then will be run though the DeleteCustomer to delete the customer
            // from the database. Return 1 for success, and -1 for failure.
            bool result = CustomerDB.DeleteCustomer(customer);
            // Then using the result will show in the test if this successful or not.
            Assert.IsTrue(result);
        }

        [Test]
        // The method that will be used to test the UpdateCustomer method in
        // CustomerDB
        public void TestUpdateCustomer()
        {
            //object with "Arcane, Ryan", "101 Main Street", "Orlando", "FL", "71234"
            Customer newCustomer = new Customer();
            newCustomer.Name = "Arcane, Ryan";
            newCustomer.Address = "101 Main Street";
            newCustomer.City = "Orlando";
            newCustomer.State = "FL";
            newCustomer.ZipCode = "71234";

            // Using an id, we will make a the oldCustomer object
            // to have the information that will be updated.
            Customer oldCustomer = CustomerDB.GetCustomer(100);
            // With the oldCustomer will use the UpdateCustomer method
            // with the newCustomer to have the entry in database updated
            // to have the new information. Return 1 for success, and -1 for failure.
            bool result = CustomerDB.UpdateCustomer(oldCustomer, newCustomer);
            // Then using the result will show in the test if this successful or not.
            Assert.IsTrue(result);
            // Lines 85 though 91, is to check that the entry in the database was
            // updated, by checking if each field of the object are not the same.
            // Where if its equals then it will fail, if not then success.
            Customer testCustomer= CustomerDB.GetCustomer(100);
            Assert.AreNotEqual(oldCustomer.Name, testCustomer.Name);
            Assert.AreNotEqual(oldCustomer.Address, testCustomer.Address);
            Assert.AreNotEqual(oldCustomer.City, testCustomer.City);
            Assert.AreNotEqual(oldCustomer.State, testCustomer.State);
            Assert.AreNotEqual(oldCustomer.State, testCustomer.State);
            Assert.AreNotEqual(oldCustomer.ZipCode, testCustomer.ZipCode);
        }
    }
}
