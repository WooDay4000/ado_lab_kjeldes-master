using System;
using System.Collections.Generic;
using System.Text;

namespace MMABooksBusinessClasses
{
    public class Product
    {
        // Unloaded Constructor 
        public Product() { }

        // Loaded Constructor
        public Product(string productCode, string description, decimal unitPrice, int onHandQuantity)
        {
            ProductCode = productCode;
            Description = description;
            UnitPrice = unitPrice;
            OnHandQuantity = onHandQuantity;
        }

        // instance variables
        private string productCode;
        private string description;
        private decimal unitPrice;
        private int onHandQuantity;


        // Getter and setter field of the ProductCode field for Product object
        public string ProductCode
        {
            get
            {
                return productCode;
            }

            set
            {
                if (value.Trim().Length > 0 && value.Trim().Length <= 10)
                {
                    productCode = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Product code must be at least 1 character and no more then 10 characters.");
                }
            }
        }

        // Getter and setter field of the Description field for Product object
        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                if (value.Trim().Length > 0 && value.Trim().Length <= 50)
                {
                    description = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Must be at least 1 character and no more then 50 characters.");
                }
            }
        }

        // Getter and setter field of the UnitPrice field for Product object
        public decimal UnitPrice
        {
            get
            {
                return unitPrice;
            }

            set
            {
                if (value > 0 && value <= 99999999.9999m)
                {
                    unitPrice = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Unit price must be greater than 0.0000 and no more then 99999999.9999.");
                }
            }
        }

        // Getter and setter field of the OnHandQuantity field for Product object
        public int OnHandQuantity
        {
            get
            {
                return onHandQuantity;
            }

            set
            {
                if (value > 0)
                {
                    onHandQuantity = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("OnHandQuantity must be a positive integer.");
                }

            }
        }

        // A ToString override that allows for the object no matter the datatype to be outputted as a string
        // for testing and to be displayed.
        public override string ToString() => ProductCode + ", " + Description + ", " + UnitPrice + ", " + OnHandQuantity;
    }
}