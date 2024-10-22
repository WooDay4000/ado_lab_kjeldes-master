using MMABooksBusinessClasses;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MMABooksDBClasses
{
    public static class ProductDB
    {
        // A method that retrieves a specific product record
        // from the Products database table using
        // the ProductCode field. Returns a Product object if found,
        // otherwise returns null.
        public static Product GetProduct(string productCode)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement
                = "SELECT ProductCode, Description, UnitPrice, OnHandQuantity "
                + "FROM Products "
                + "WHERE ProductCode = @ProductCode";
            MySqlCommand selectCommand = new MySqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProductCode", productCode);

            try
            {
                connection.Open();
                MySqlDataReader reader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    Product product = new Product();
                    product.ProductCode = reader["ProductCode"].ToString();
                    product.Description = reader["Description"].ToString();
                    product.UnitPrice = (decimal)reader["UnitPrice"];
                    product.OnHandQuantity = (int)reader["OnHandQuantity"];
                    return product;
                }
                else
                {
                    return null;
                }
            }
            // Catches any MySQL-specific errors during database operations.
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        // A method that will be used to make a Product object list of all
        // the current products stored in the Products database table.
        // Returns a lists of all the current product records
        // stored in the MySql server database.
        public static List<Product> GetList()
        {
            List<Product> products = new List<Product>();
            MySqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement
                = "SELECT ProductCode, Description, UnitPrice, OnHandQuantity "
                + "FROM Products ";
            MySqlCommand selectCommand = new MySqlCommand(selectStatement, connection);

            try
            {
                connection.Open();
                MySqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    Product p = new Product();
                    p.ProductCode = reader["ProductCode"].ToString();
                    p.Description = reader["Description"].ToString();
                    p.UnitPrice = (decimal)reader["UnitPrice"];
                    p.OnHandQuantity = (int)reader["OnHandQuantity"];
                    products.Add(p);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return products;
        }

        // A method that used to add a new product record to the Products
        // database table using a Product object.
        // Returns true if the record was added successfully, false if unsuccessful.
        public static bool AddProduct(Product product)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string insertStatement =
                "INSERT Products " +
                "(ProductCode, Description, UnitPrice, OnHandQuantity) " +
                "VALUES (@ProductCode, @Description, @UnitPrice, @OnHandQuantity)";
            MySqlCommand insertCommand =
                new MySqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@ProductCode", product.ProductCode);
            insertCommand.Parameters.AddWithValue("@Description", product.Description);
            insertCommand.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
            insertCommand.Parameters.AddWithValue("@OnHandQuantity", product.OnHandQuantity);

            try
            {
                connection.Open();
                int count = insertCommand.ExecuteNonQuery();

                return count == 1;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        // A method that is used to delete a specific product record in the
        // Products database table using a Product object. Where all fields
        // must match the product data for the record to be deleted,
        // where then it returns true if a record was deleted, otherwise false.
        public static bool DeleteProduct(Product product)
        {
            // get a connection to the database
            MySqlConnection connection = MMABooksDB.GetConnection();

            string deleteStatement =
                "DELETE FROM Products " +
                "WHERE ProductCode = @ProductCode " +
                "AND Description = @Description " +
                "AND UnitPrice = @UnitPrice " +
                "AND OnHandQuantity = @OnHandQuantity";
            // set up the command object
            MySqlCommand deleteCommand = new MySqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue("@ProductCode", product.ProductCode);
            deleteCommand.Parameters.AddWithValue("@Description", product.Description);
            deleteCommand.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
            deleteCommand.Parameters.AddWithValue("@OnHandQuantity", product.OnHandQuantity);

            try
            {
                // open the connection
                connection.Open();
                // execute the command
                int count = deleteCommand.ExecuteNonQuery();
                // if the number of records returned = 1, return true otherwise return false
                return count == 1;
            }
            catch (MySqlException ex)
            {
                // throw the exception
                throw ex;
            }
            finally
            {
                // close the connection
                connection.Close();
            }
        }

        // A method that updates a product record in the Products database table
        // using the current product record values in the oldProduct object to
        // specify which record is being updated and a newProduct object with
        // the data that we want to update too.
        // Returns true if the record was updated, otherwise false.
        public static bool UpdateProduct(Product oldProduct,
            Product newProduct)
        {
            // create a connection
            MySqlConnection connection = MMABooksDB.GetConnection();

            string updateStatement =
                "UPDATE Products SET " +
                "Description = @NewDescription, " +
                "UnitPrice = @NewUnitPrice, " +
                "OnHandQuantity = @NewOnHandQuantity " +
                "WHERE ProductCode = @OldProductCode " +
                "AND Description = @OldDescription " +
                "AND UnitPrice = @OldUnitPrice " +
                "AND OnHandQuantity = @OldOnHandQuantity";
            // setup the command object
            MySqlCommand updateCommand = new MySqlCommand(updateStatement, connection);
            // The new product values for the update.
            updateCommand.Parameters.AddWithValue("@NewDescription", newProduct.Description);
            updateCommand.Parameters.AddWithValue("@NewUnitPrice", newProduct.UnitPrice);
            updateCommand.Parameters.AddWithValue("@NewOnHandQuantity", newProduct.OnHandQuantity);

            // The old product values that will be replaced in this update.
            updateCommand.Parameters.AddWithValue("@OldProductCode", oldProduct.ProductCode);
            updateCommand.Parameters.AddWithValue("@OldDescription", oldProduct.Description);
            updateCommand.Parameters.AddWithValue("@OldUnitPrice", oldProduct.UnitPrice);
            updateCommand.Parameters.AddWithValue("@OldOnHandQuantity", oldProduct.OnHandQuantity);

            try
            {
                // open the connection
                connection.Open();
                // execute the command
                int count = updateCommand.ExecuteNonQuery();
                // if the number of records returned = 1, return true otherwise return false
                return count == 1;
            }
            // What is this about and is this what is needed?
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}