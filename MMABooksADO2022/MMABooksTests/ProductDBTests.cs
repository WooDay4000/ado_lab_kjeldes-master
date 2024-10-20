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
        [Test]
        // The method that is used to test the GetProduct
        // method in ProductDB if it's able to get a
        // product record from the sql server
        public void TestGetProduct()
        {
            Product c = ProductDB.GetProduct("ADC4");
            Assert.AreEqual("ADC4", c.ProductCode);
        }

        [Test]
        // The method that is used to test the GetList
        // method in ProductDB to see if it's able to get
        // a list of all the possible product records.
        public void TestGetList()
        {
            // The list where all the products will be saved
            // when there grabbed from the Products table
            // in the database.
            List<Product> products = ProductDB.GetList();
            // Checks to see if it was able to grab more then
            // one product from the Products table
            // in the database
            Assert.IsTrue(products.Count > 1);
            // Checks to see if the information was successfully
            // gotten from the Products table in the database,
            // by checking with the second products description.
            Assert.AreEqual("Murach's ASP.NET 4 Web Programming with VB 2010", products[1].Description);
            // Then checks to see if all the fields in each of the product
            // objects are filled with information gotten form each record
            // from the Products table in the database.
            for (int i = 0; i < products.Count; i++)
            {
                Assert.AreNotEqual(null, products[i].ProductCode);
                Assert.AreNotEqual(null, products[i].Description);
                Assert.AreNotEqual(null, products[i].UnitPrice);
                Assert.AreNotEqual(null, products[i].OnHandQuantity);
            }
        }

        [Test]
        // The method that is used to test the AddProduct
        // method in CustomerDB is able create a
        // new customer record in the sql server.
        public void TestAddProduct()
        {
            Product p = new Product();
            p.ProductCode = "QWER";
            p.Description = "Description Something Witty";
            p.UnitPrice = 10.25m;
            p.OnHandQuantity = 1000;

            // Added this because it would produce a error after
            // a second test because the product record was already created,
            // so to fix these we will get the potentially already
            // created product, and if it was already created and has
            // information in it, it will be deleted.
            Product recentlyMade = ProductDB.GetProduct("QWER");
            if (recentlyMade != null)
            {
                ProductDB.DeleteProduct(recentlyMade);
            }
            // Then we add the product to the database, with it returning
            // a 1 if it was able to be added, and -1 if it wasn't able to
            // to be added.
            bool result = ProductDB.AddProduct(p);
            Assert.IsTrue(result);
        }

        [Test]
        // The method that is used to test the DeleteProduct
        // method in ProductDB is able to delete a
        // product record in the sql server.
        public void TestDeleteProduct()
        {
            Product p2 = new Product();
            p2.ProductCode = "BKJY";
            p2.Description = "When Coding A Toaster Isn't Enough!";
            p2.UnitPrice = 59.99m;
            p2.OnHandQuantity = 1250;

            // Add the created product to the database
            ProductDB.AddProduct(p2);
            // Then we remove the product from the database, with it returning
            // a 1 if it was able to be deleted, and -1 if it wasn't able to
            // to be delated.
            bool result = ProductDB.DeleteProduct(p2);
            Assert.IsTrue(result);
        }

        [Test]
        // The method that is used to test the DeleteProduct
        // method in ProductDB is able to update a
        // customer record in the sql server.
        public void TestUpdateProduct()
        {
            Product newProduct = new Product();
            newProduct.ProductCode = "JSP2";
            newProduct.Description = "Murach's JAVA Servlets & JSP 2nd Ed. (OUTDATED)";
            newProduct.UnitPrice = 35.00m;
            newProduct.OnHandQuantity = 4500;

            Product oldProduct = ProductDB.GetProduct("JSP2");
            // With the oldProduct we will use the UpdateProduct method
            // with the newProduct to have the entry in database updated
            // to have the new information. Return 1 for success, and -1 for failure.
            bool result = ProductDB.UpdateProduct(oldProduct, newProduct);
            Assert.IsTrue(result);
        }
    }
}