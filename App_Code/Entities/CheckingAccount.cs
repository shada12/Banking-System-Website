using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CheckingAccount
/// </summary>
public class CheckingAccount : Account
{
    public static double MaxWithdrawAmount = 300.0;
    public CheckingAccount(Customer owner)
           : base(owner)
    {
    }




    public override void deposit(Transaction transaction)
    {

        base.deposit(transaction);
    }



    public override TransactionResult withdraw(Transaction transaction)
    {

        if (Owner.Status == CustomerStatus.REGULAR && transaction.Amount > MaxWithdrawAmount && transaction.type != TransactionType.TRANSFER_OUT)
        {

            Console.WriteLine("\n" + "Withdraw cancelled: EXCEED_MAX_WITHDRAW_AMOUNT");
            return TransactionResult.EXCEED_MAX_WITHDRAW_AMOUNT;

        }
        return base.withdraw(transaction);
    }


}