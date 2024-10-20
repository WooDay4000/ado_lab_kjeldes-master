using System;

namespace MMABooksBusinessClasses
{
    public class Customer
    {
        // there are several warnings in this file related to nullable properties and return values.
        // you can ignore them
        public Customer() { }

        public Customer(int customerID, string name, string address, string city, string state, string zipCode)
        {
            CustomerID = customerID;
            Name = name;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        // instance variables, always camelCase
        private int customerID;
        private string name;
        private string address;
        private string city;
        private string state;
        private string zipCode;

        // Getter and setter field of the CustomerID field for Customer object
        public int CustomerID
        {
            get
            {
                return customerID;
            }

            set
            {
                if (value > 0)
                {
                    customerID = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Customer ID must be a positive integer.");
                }
            }
        }

        // Getter and setter field of the Name field for Customer object
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (value.Trim().Length > 0 && value.Trim().Length <= 100)
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Name must be at least 1 character and no more than 100 characters.");
                }
            }
        }

        // Getter and setter field of the Address field for Customer object
        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                if (value.Trim().Length > 0 && value.Trim().Length <= 50)
                {
                    address = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Address must be at least 1 character and no more then 50 characters.");
                }
            }
        }

        // Getter and setter field of the City field for Customer object
        public string City
        {
            get
            {
                return city;
            }

            set
            {
                if (value.Trim().Length > 0 && value.Trim().Length <= 20)
                {
                    city = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("City must be at least 1 character and no more then 20 characters.");
                }
            }
        }

        // Getter and setter field of the State field for Customer object
        public string State
        {
            get
            {
                return state;
            }

            set
            {
                if (value.Trim().Length == 2)
                {
                    state = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("State must be exactly 2 characters.");
                }
            }
        }

        // Getter and setter field of the ZipCode field for Customer object
        public string ZipCode
        {
            get
            {
                return zipCode;
            }

            set
            {
                if (value.Trim().Length >= 5 && value.Trim().Length <= 15)
                {
                    zipCode = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("ZipCode must be at least 5 characters and no more then 15 characters.");
                }
            }
        }

        // A ToString override that allows for the object no matter the datatype to be outputted as a string
        // for testing and to be displayed.
        public override string ToString() => CustomerID + ", " + Name + ", " + Address + ", " + City + ", " + State + ", " + ZipCode;
    }
}