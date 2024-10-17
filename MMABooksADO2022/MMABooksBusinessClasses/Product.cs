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
        public Product(string productcode, string description, double unitprice, int onhandquantity)
        {
            ProductCode = productcode;
            Description = description;
            UnitPrice = unitprice;
            OnHandQuantity = onhandquantity;
        }

        // instance variables
        private string productcode;
        private string description;
        private double unitprice;
        private int onhandquantity;

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

        public double UnitPrice
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

        public override string ToString() => ProductCode + ", " + Description + ", " + UnitPrice + ", " + OnHandQuantity;
    }
}
