﻿using System;

namespace MMABooksBusinessClasses
{
    public class Customer
    {
        // there are several warnings in this file related to nullable properties and return values.
        // you can ignore them
        public Customer() { }

        public Customer(int id, string name, string address, string city, string state, string zipcode)
        {
            CustomerID = id;
            Name = name;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipcode;
        }

        // instance variables
        private int customerID;
        private string name;
        private string address;
        private string city;
        private string state;
        private string zipcode;

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
                    throw new ArgumentOutOfRangeException("Customer must be a positive integer");
                }
            }
        }

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
                    throw new ArgumentOutOfRangeException("Must be at least 1 character and no more then 100 characters");
                }
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                if (value.Trim().Length > 0 && value.Trim().Length <= 100)
                {
                    address = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Must be at least 1 character and no more then 100 characters");
                }
            }
        }

        public string City
        {
            get
            {
                return city;
            }

            set
            {
                if (value.Trim().Length > 0 && value.Trim().Length <= 100)
                {
                    city = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Must be at least 1 character and no more then 100 characters");
                }
            }
        }

        public string State
        {
            get
            { 
                return state;
            }

            set
            {
                if (value.Trim().Length > 0 && value.Trim().Length <= 100)
                {
                    state = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Must be at least 1 character and no more then 100 characters");
                }
            }
        }

        public string ZipCode
        {
            get
            {
                return zipcode;
            }

            set
            {
                if (value.Trim().Length >= 5 && value.Trim().Length <= 10)
                {
                    zipcode = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Must be at least 5 characters and no more then 10 characters");
                }
            }
        }

        public override string ToString() => CustomerID + ", " + Name + ", " + Address + ", " + City + ", " + State + ", " + ZipCode;
    }
}
