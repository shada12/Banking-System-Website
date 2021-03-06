using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Account
/// </summary>
public class Account
{
   


        private Customer owner;
        private double balance;
        private List<Transaction> transactionHistory;

        public Account()
        {

        }
        public Account(Customer owner)
        {
            Owner = owner;

            transactionHistory = new List<Transaction>();
        }


        public Customer Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public double Balance
        {
            get { return balance; }

        }


        public List<Transaction> TransactionHistory
        {
            get { return transactionHistory; }
            set { transactionHistory = value; }
        }



        public virtual void deposit(Transaction transaction)
        {

            if (transaction.Amount > 0)
            {
                balance += transaction.Amount;

                transactionHistory.Add(transaction);

            }
        }

        public virtual TransactionResult withdraw(Transaction transaction)
        {

            if (transaction.Amount <= balance)
            {
                balance -= transaction.Amount;

                transactionHistory.Add(transaction);

                return TransactionResult.SUCCESS;

            }
            else
            {
                Console.WriteLine("Withdraw cancelled: INSUFFICIENT_FUND");
                return TransactionResult.INSUFFICIENT_FUND;
            }
        }

    }
