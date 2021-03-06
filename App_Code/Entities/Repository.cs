using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Repository
/// </summary>
public class Repository
{

    public static List<Customer> customers = new List<Customer>();


    //public Repository()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}


    public static List<Customer> Customers
    {
        get { return customers; }
    }


    public void addCustomer(Customer customer)
    {
        customers.Add(customer);

    }

}