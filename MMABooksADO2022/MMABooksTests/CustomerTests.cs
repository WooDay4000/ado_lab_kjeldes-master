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

        public void TestConstructor()
        {
            Assert.IsNotNull(def);
            Assert.AreEqual(null, def.Name);
            Assert.AreEqual(null, def.Address);
            Assert.AreEqual(null, def.City);
            Assert.AreEqual(null, def.State);
            Assert.AreEqual(null, def.ZipCode);

            Assert.IsNotNull(c);
            Assert.AreNotEqual(null, c.Name);
            Assert.AreNotEqual(null, c.Address);
            Assert.AreNotEqual(null, c.City);
            Assert.AreNotEqual(null, c.State);
            Assert.AreNotEqual(null, c.ZipCode);
        }

        [Test]

        public void TestNameSetter()
        {
            c.Name = "Remorse, Harold";
            Assert.AreNotEqual("Arcane, Ryan", c.Name);
            Assert.AreEqual("Remorse, Harold", c.Name);
        }

        [Test]
        public void TestSettersNameTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Name = "12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901");
        }

        [Test]

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