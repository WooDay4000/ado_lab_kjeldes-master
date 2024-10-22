using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data.MySqlClient;
using System.Data;
using MMABooksBusinessClasses;
using Org.BouncyCastle.Tls;

namespace MMABooksDBClasses
{
    public static class CustomerDB
    {
        // A method that retrieves a specific customer record
        // from the Customers database table using
        // the CustomerID field. Returns a Customer object if found,
        // otherwise returns null.
        public static Customer GetCustomer(int customerID)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement
                = "SELECT CustomerID, Name, Address, City, State, ZipCode "
                + "FROM Customers "
                + "WHERE CustomerID = @CustomerID";
            MySqlCommand selectCommand =
                new MySqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@CustomerID", customerID);

            try
            {
                connection.Open();
                MySqlDataReader custReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (custReader.Read())
                {
                    Customer customer = new Customer();
                    customer.CustomerID = (int)custReader["CustomerID"];
                    customer.Name = custReader["Name"].ToString();
                    customer.Address = custReader["Address"].ToString();
                    customer.City = custReader["City"].ToString();
                    customer.State = custReader["State"].ToString();
                    customer.ZipCode = custReader["ZipCode"].ToString();
                    return customer;
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

        // A method that used to add a new customer record to the Customers
        // database table using a Customer object.
        // Returns the generated CustomerID of the new customer.
        public static int AddCustomer(Customer customer)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string insertStatement =
                "INSERT Customers " +
                "(Name, Address, City, State, ZipCode) " +
                "VALUES (@Name, @Address, @City, @State, @ZipCode)";
            MySqlCommand insertCommand =
                new MySqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue(
                "@Name", customer.Name);
            insertCommand.Parameters.AddWithValue(
                "@Address", customer.Address);
            insertCommand.Parameters.AddWithValue(
                "@City", customer.City);
            insertCommand.Parameters.AddWithValue(
                "@State", customer.State);
            insertCommand.Parameters.AddWithValue(
                "@ZipCode", customer.ZipCode);
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                // MySQL specific code for getting last pk value
                string selectStatement =
                    "SELECT LAST_INSERT_ID()";
                MySqlCommand selectCommand =
                    new MySqlCommand(selectStatement, connection);
                int customerID = Convert.ToInt32(selectCommand.ExecuteScalar());
                return customerID;
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

        // A method that is used to delete a specific customer record in the
        // Customers database table using a Customer object. Where all fields
        // must match the customer data for the record to be deleted,
        // where then it returns true if a record was deleted, otherwise false.
        public static bool DeleteCustomer(Customer customer)
        {
            // get a connection to the database
            MySqlConnection connection = MMABooksDB.GetConnection();
            // The MySql statement that the server will use to perform
            // a specified command. Which for this is to delete
            // a customer record.
            string deleteStatement =
                "DELETE FROM Customers " +
                "WHERE CustomerID = @CustomerID " +
                "AND Name = @Name " +
                "AND Address = @Address " +
                "AND City = @City " +
                "AND State = @State " +
                "AND ZipCode = @ZipCode";
            // Set up the command object
            // With this taking the statement we created and
            // the connection we established with the MySql server.
            MySqlCommand deleteCommand = new MySqlCommand(deleteStatement, connection);
            // With the following code after this, it uses the Customer object
            // fields to replace the specified (@)Parameters in the deleteStatement.
            deleteCommand.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
            deleteCommand.Parameters.AddWithValue("@Name", customer.Name);
            deleteCommand.Parameters.AddWithValue("@Address", customer.Address);
            deleteCommand.Parameters.AddWithValue("@City", customer.City);
            deleteCommand.Parameters.AddWithValue("@State", customer.State);
            deleteCommand.Parameters.AddWithValue("@ZipCode", customer.ZipCode);

            try
            {
                // Opens the connection
                connection.Open();
                // Executes the command
                // Which with the deleteStatement that has the right parameters and
                // the connection to the MySgl server it should be able to delete the
                // specified customer.
                int count = deleteCommand.ExecuteNonQuery();
                // If the count is set to 1 it's successful, otherwise return false
                // which means it was unsuccessful .
                return count == 1;
            }
            // Catches any MySQL-specific errors during database operations.
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

        // A method that updates a customer record in the Customers database table
        // using the current customer record values in the oldCustomer object to
        // specify which record is being updated and a newCustomer object with
        // the data that we want to update too.
        // Returns true if the record was updated, otherwise false.
        public static bool UpdateCustomer(Customer oldCustomer,
            Customer newCustomer)
        {
            // create a connection
            MySqlConnection connection = MMABooksDB.GetConnection();

            string updateStatement =
                "UPDATE Customers SET " +
                "Name = @NewName, " +
                "Address = @NewAddress, " +
                "City = @NewCity, " +
                "State = @NewState, " +
                "ZipCode = @NewZipCode " +
                "WHERE CustomerID = @OldCustomerID " +
                "AND Name = @OldName " +
                "AND Address = @OldAddress " +
                "AND City = @OldCity " +
                "AND State = @OldState " +
                "AND ZipCode = @OldZipCode";
            // setup the command object
            MySqlCommand updateCommand = new MySqlCommand(updateStatement, connection);
            // The new customer values for the update.
            updateCommand.Parameters.AddWithValue("@NewName", newCustomer.Name);
            updateCommand.Parameters.AddWithValue("@NewAddress", newCustomer.Address);
            updateCommand.Parameters.AddWithValue("@NewCity", newCustomer.City);
            updateCommand.Parameters.AddWithValue("@NewState", newCustomer.State);
            updateCommand.Parameters.AddWithValue("@NewZipCode", newCustomer.ZipCode);

            // The old customer values that will be replaced in this update.
            updateCommand.Parameters.AddWithValue("@OldCustomerID", oldCustomer.CustomerID);
            updateCommand.Parameters.AddWithValue("@OldName", oldCustomer.Name);
            updateCommand.Parameters.AddWithValue("@OldAddress", oldCustomer.Address);
            updateCommand.Parameters.AddWithValue("@OldCity", oldCustomer.City);
            updateCommand.Parameters.AddWithValue("@OldState", oldCustomer.State);
            updateCommand.Parameters.AddWithValue("@OldZipCode", oldCustomer.ZipCode);

            try
            {
                // open the connection
                connection.Open();
                // execute the command
                int count = updateCommand.ExecuteNonQuery();
                // if the number of records returned = 1, return true otherwise return false
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
    }
}