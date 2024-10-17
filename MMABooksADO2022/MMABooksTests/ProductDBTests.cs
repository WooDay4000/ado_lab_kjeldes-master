using MMABooksBusinessClasses;
using MMABooksDBClasses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMABooksTests
{
    [TestFixture]
    public class ProductDBTests
    {
        private Product p;

        [SetUp]

        public void SetUp()
        {
            // This was a work around i devised because unlike customer id,
            // you can't just use plus 1 it. So during the set it checks to see
            // if the added product is still in the database, where if yes then
            // it deletes it from the database and remakes it as a object, where
            // if no then it just makes the object.
            p = ProductDB.GetProduct("GBHY");

            // This was added because it woundn't update a already updated record,
            // so it checks to see if it's updated by comparing its Description
            // to what it was supposed to update it to, so if its the same then
            // with the if statement it will restart the record being updated
            // back to what it originally was.
            Product p2 = ProductDB.GetProduct("DB1R");

            if (p != null)
            {
                ProductDB.DeleteProduct(p);
            }
            if (p2.Description == "Give A load of This Code!")
            {
                Product p3 = new Product("DB1R", "DB2 for the COBOL Programmer, Part 1 (2nd Edition)", 42.0000m, 4825);
                ProductDB.UpdateProduct(p2, p3);
            }
            p = new Product("GBHY", "Give A load of This Code!", 50.25m, 1000);
        }


        [Test]

        public void TestGetProduct()
        {
            Product c = ProductDB.GetProduct("ADC4");
            Assert.AreEqual("ADC4", c.ProductCode);
        }

        [Test]
        public void TestCreateProduct()
        {
            bool result = ProductDB.AddProduct(p);
            Assert.IsTrue(result);
        }

        [Test]
        public void TestDeleteProduct()
        {
            ProductDB.AddProduct(p);
            bool result = ProductDB.DeleteProduct(p);
            // Then using the result will show in the test if this successful or not.
            Assert.IsTrue(result);
        }

        [Test]
        public void TestUpdateProduct()
        {
            Product oldProduct = new Product("DB1R", "DB2 for the COBOL Programmer, Part 1 (2nd Edition)", 42.0000m, 4825);
            bool result = ProductDB.UpdateProduct(oldProduct, p);
            Assert.IsTrue(result);
        }
    }
}