using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customer
/// </summary>
public class Customer
{
  

        private string name;
        private CustomerStatus status;
        public CheckingAccount Checking { get; set; }
        public SavingAccount Saving { get; set; }


        public Customer(string name)
        {
            Name = name;

        }




        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public CustomerStatus Status
        {
            get { return status; }
            set { status = value; }
        }


    }
