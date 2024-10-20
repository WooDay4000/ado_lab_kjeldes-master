using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;
using NUnit.Framework.Internal.Execution;

namespace MMABooksTests
{
    [TestFixture]
    public class CustomerTests
    {
        private Customer def;
        private Customer c;

        [SetUp]

        public void SetUp()
        {
            def = new Customer();
            c = new Customer(8, "Arcane, Ryan", "101 Main Street", "Orlando", "FL", "71234");
        }

        [Test]
        // Tests the constructors for the creation of the object and if the
        // fields or the object are set properly.
        public void TestConstructor()
        {
            // These lines are used to check if a unloaded constructor
            // empty.
            Assert.IsNotNull(def);
            Assert.AreEqual(null, def.Name);
            Assert.AreEqual(null, def.Address);
            Assert.AreEqual(null, def.City);
            Assert.AreEqual(null, def.State);
            Assert.AreEqual(null, def.ZipCode);

            // These are used to check if the loaded constructor wes able
            // to fill out the product object.
            Assert.IsNotNull(c);
            Assert.AreEqual("Arcane, Ryan", c.Name);
            Assert.AreEqual("101 Main Street", c.Address);
            Assert.AreEqual("Orlando", c.City);
            Assert.AreEqual("FL", c.State);
            Assert.AreEqual("71234", c.ZipCode);
        }

        [Test]
        // Tests for the setters, including validation for too long and short
        // of the Customer object
        public void TestNameSetter()
        {
            c.Name = "Remorse, Harold";
            Assert.AreNotEqual("Arcane, Ryan", c.Name);
            Assert.AreEqual("Remorse, Harold", c.Name);
        }

        [Test]

        public void TestAddressSetter()
        {
            c.Address = "123 Side Street";
            Assert.AreNotEqual("101 Main Street", c.Address);
            Assert.AreEqual("123 Side Street", c.Address);
        }

        [Test]

        public void TestCitySetter()
        {
            c.City = "Creswell";
            Assert.AreNotEqual("Orlando", c.City);
            Assert.AreEqual("Creswell", c.City);
        }

        [Test]

        public void TestStateSetter()
        {
            c.State = "OR";
            Assert.AreNotEqual("FL", c.State);
            Assert.AreEqual("OR", c.State);
        }

        [Test]

        public void TestZipCodeSetter()
        {
            c.ZipCode = "56789";
            Assert.AreNotEqual("71234", c.ZipCode);
            Assert.AreEqual("56789", c.ZipCode);
        }

        [Test]
        public void TestSettersNameTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Name = "12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901");
        }

        [Test]

        public void TestSettersNameTooShort()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Name = "");
        }

        [Test]
        public void TestSettersAddressTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Address = "123456789012345678901234567890123456789012345678901");
        }

        [Test]

        public void TestSettersAddressTooShort()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Address = "");
        }

        [Test]
        public void TestSettersCityTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.City = "123456789012345678901");
        }

        [Test]

        public void TestSettersCityTooShort()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.City = "");
        }

        [Test]
        public void TestSettersStateTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.State = "123");
        }

        [Test]

        public void TestSettersStateTooShort()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.State = "");
        }

        [Test]
        public void TestSettersZipCodeTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.ZipCode = "1234567890123451");
        }

        [Test]

        public void TestSettersZipCodeTooShort()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.ZipCode = "1234");
        }
        // ----------------------------------------------------------------------

        [Test]
        // Tests to see if the ToString overload method works with the Customer object.
        public void TestCustomerToString()
        {
            c = new Customer(8, "Arcane, Ryan", "101 Main Street", "Orlando", "FL", "71234");

            Assert.IsTrue(c.ToString().Contains("8"));
            Assert.IsTrue(c.ToString().Contains("Arcane, Ryan"));
            Assert.IsTrue(c.ToString().Contains("101 Main Street"));
            Assert.IsTrue(c.ToString().Contains("Orlando"));
            Assert.IsTrue(c.ToString().Contains("FL"));
            Assert.IsTrue(c.ToString().Contains("71234"));
        }
    }
}