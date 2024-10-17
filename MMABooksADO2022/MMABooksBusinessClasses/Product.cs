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
        public Product(string productcode, string description, decimal unitprice, int onhandquantity)
        {
            ProductCode = productcode;
            Description = description;
            UnitPrice = unitprice;
            OnHandQuantity = onhandquantity;
        }

        // instance variables
        private string productcode;
        private string description;
        private decimal unitprice;
        private int onhandquantity;


        // Getter and setter field of the ProductCode field for Product object
        public string ProductCode
        {
            get
            {
                return productcode;
            }

            set
            {
                if (value.Trim().Length == 4)
                {
                    productcode = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Product code must be 4 characters of length");
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
                if (value.Trim().Length > 0 && value.Trim().Length <= 100)
                {
                    description = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Must be at least 1 character and no more then 100 characters");
                }
            }
        }

        // Getter and setter field of the UnitPrice field for Product object
        public decimal UnitPrice
        {
            get
            {
                return unitprice;
            }

            set
            {
                if (value > 0 && value <= 500)
                {
                    unitprice = Math.Round(value, 2);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Unit price must be greater then 0.00 and less then 500.00");
                }
            }
        }

        // Getter and setter field of the OnHandQuantity field for Product object
        public int OnHandQuantity
        {
            get
            {
                return onhandquantity;
            }

            set
            {
                if (value > 0)
                {
                    onhandquantity = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("On hand quantity amount must greater then 0");
                }
                
            }
        }

        // A ToString override that allows for the object no matter the datatype to be outputted as a string
        // for testing and to be displayed.
        public override string ToString() => ProductCode + ", " + Description + ", " + UnitPrice + ", " + OnHandQuantity;
    }
}
