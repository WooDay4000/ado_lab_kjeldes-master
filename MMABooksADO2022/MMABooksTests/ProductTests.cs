using MMABooksBusinessClasses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMABooksTests
{
    [TestFixture]
    public class ProductTests
    {
        private Product def;
        private Product p;

        [SetUp]
        
        public void SetUp()
        {
            def = new Product();
            p = new Product("RTYU", "Roland's Guide To Coding Or Whatever", 84.75m, 5000);
        }

        [Test]
        // Testing the unloaded and loaded constructor for product
        public void TestConstructor()
        {
            // These lines are used to check if a unloaded constructor
            // empty.
            Assert.IsNotNull(def);
            Assert.AreEqual(null, def.ProductCode);
            Assert.AreEqual(null, def.Description);
            Assert.AreEqual(0.0, def.UnitPrice);
            Assert.AreEqual(0, def.OnHandQuantity);

            // These are used to check if the loaded constructor wes able
            // to fill out the 
            Assert.IsNotNull(p);
            Assert.AreNotEqual(null, p.ProductCode);
            Assert.AreNotEqual(null, p.Description);
            Assert.AreNotEqual(null, p.UnitPrice);
            Assert.AreNotEqual(null, p.OnHandQuantity);
        }

        [Test]

        public void TestProductCodeSetter()
        {
            p.ProductCode = "FGHJ";
            Assert.AreNotEqual("RTYU", p.ProductCode);
            Assert.AreEqual("FGHJ", p.ProductCode);
        }

        [Test]

        public void TestSettersNameTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.ProductCode = "WERTY");
        }

        [Test]

        public void TestProductToString()
        {
            p = new Product("ASDF", "Something Something Coding", 25.25m, 200);

            Assert.IsTrue(p.ToString().Contains("ASDF"));
            Assert.IsTrue(p.ToString().Contains("Something Something Coding"));
            Assert.IsTrue(p.ToString().Contains("25.25"));
            Assert.IsTrue(p.ToString().Contains("200"));
        }
    }
}
