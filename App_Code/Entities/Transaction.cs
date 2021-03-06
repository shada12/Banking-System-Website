using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Transaction
/// </summary>
public class Transaction
{
     private double amount;
        public TransactionType type { get; set; }
        private DateTime transactionDate;

        public Transaction()
        {

        }
        public Transaction(double amount, TransactionType type)
        {
            Amount = amount;
            this.type = type;
            TransactionDate = DateTime.Now;

        }


        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }



        public DateTime TransactionDate
        {
            get { return transactionDate; }
            set { transactionDate = value; }
        }

    }
