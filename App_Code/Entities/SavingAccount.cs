using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SavingAccount
/// </summary>
public class SavingAccount : Account
{

    public static double PrimierAmount = 2000.0;
    public static double WithdrawPenaltyAmount = 10.0;


    public SavingAccount(Customer owner)
           : base(owner)
    {
    }



    public override void deposit(Transaction transaction)
    {

        base.deposit(transaction);

        if (Balance < PrimierAmount)
        {
            Owner.Status = CustomerStatus.REGULAR;

        }
        else
        {

            Owner.Status = CustomerStatus.PREMIER;
        }
    }

    public override TransactionResult withdraw(Transaction transaction)
    {

        TransactionResult result = base.withdraw(transaction);

        if (result != TransactionResult.SUCCESS)
        {
            return result;
        }


        if (Balance < PrimierAmount)
        {
            Owner.Status = CustomerStatus.REGULAR;

        }
        else
        {

            Owner.Status = CustomerStatus.PREMIER;
        }

        if (Owner.Status == CustomerStatus.REGULAR)
        {
            Transaction penaltyTransaction = new Transaction(WithdrawPenaltyAmount, TransactionType.PENALTY);
            base.withdraw(penaltyTransaction);
        }

        return result;

    }




}