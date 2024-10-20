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
        // Tests the constructors for the creation of the object and if the
        // fields or the object are set properly.
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
            // to fill out the product object.
            Assert.IsNotNull(p);
            Assert.AreEqual("RTYU", p.ProductCode);
            Assert.AreEqual("Roland's Guide To Coding Or Whatever", p.Description);
            Assert.AreEqual(84.75m, p.UnitPrice);
            Assert.AreEqual(5000, p.OnHandQuantity);
        }

        [Test]
        // Tests for the setters, including validation for too long and short
        // of the Product object
        public void TestProductCodeSetter()
        {
            p.ProductCode = "FGHJ";
            Assert.AreNotEqual("RTYU", p.ProductCode);
            Assert.AreEqual("FGHJ", p.ProductCode);
        }

        [Test]

        public void TestDescriptionSetter()
        {
            p.Description = "Where There Is Code There Is A Way!";
            Assert.AreNotEqual("Roland's Guide To Coding Or Whatever", p.Description);
            Assert.AreEqual("Where There Is Code There Is A Way!", p.Description);
        }

        [Test]

        public void TestUnitPriceSetter()
        {
            p.UnitPrice = 12.45m;
            Assert.AreNotEqual(84.75m, p.UnitPrice);
            Assert.AreEqual(12.45m, p.UnitPrice);
        }

        [Test]

        public void TestOnHandQuantitySetter()
        {
            p.OnHandQuantity = 4500;
            Assert.AreNotEqual(5000, p.OnHandQuantity);
            Assert.AreEqual(4500, p.OnHandQuantity);
        }

        [Test]

        public void TestSettersProductCodeTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.ProductCode = "QWERTYUIOPD");
        }

        [Test]

        public void TestSettersProductCodeTooShort()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.ProductCode = "");
        }

        [Test]

        public void TestSettersDescriptionTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.Description = "123456789012345678901234567890123456789012345678901");
        }

        [Test]

        public void TestSettersDescriptionTooShort()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.Description = "");
        }

        [Test]

        public void TestSettersUnitPriceTooBig()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.UnitPrice = 199999999.9999m);
        }

        [Test]

        public void TestSettersUnitPriceTooSmall()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.UnitPrice = -1.00m);
        }

        [Test]

        public void TestSettersOnHandQuantityTooSmall()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.OnHandQuantity = -1);
        }
        // ------------------------------------------------------------------

        [Test]
        // Tests to see if the ToString overload method works with the Product object.
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