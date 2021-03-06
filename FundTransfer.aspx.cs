using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FundTransfer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        List<Customer> customers = Session["customers"] as List<Customer>;

        if (customers == null)
        {
            customers = new List<Customer>();
            Session["customers"] = customers;

        }

        if (!IsPostBack)
        {

            foreach (Customer customer in customers)
            {

                ListItem item = new ListItem(customer.Name);
                DropDownListCustomerName.Items.Add(item);

            }
        }

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        LabelMessage.Text = "";
        LabelIndexErrorMessage.Text = "";

        try
        {

            List<Customer> customers = Session["customers"] as List<Customer>;

            TextBoxTransferAmount.Text = "";
            LabelCheckingBalance.Text = "";
            LabelSavingBalance.Text = "";
            LabelMessage.Text = "";
            CompareValidatorTransferAmount.Text = " ";


            int selectedCustomerIndex = DropDownListCustomerName.SelectedIndex - 1;


            LabelCheckingBalance.Text = customers[selectedCustomerIndex].Checking.Balance.ToString("C2");
            LabelSavingBalance.Text = customers[selectedCustomerIndex].Saving.Balance.ToString("C2");
        }
        catch (Exception ex)
        {

            LabelIndexErrorMessage.Text = ex.Message;
        }

    }

    protected void ButtonTransfer_Click(object sender, EventArgs e)
    {
        try
        {

            List<Customer> customers = Session["customers"] as List<Customer>;

            int selectedCustomerIndex = DropDownListCustomerName.SelectedIndex - 1;

            if (RadioButtonListAccountType.SelectedIndex > -1)
            {

                if (double.Parse(TextBoxTransferAmount.Text) > 0)
                {

                    double amount = double.Parse(TextBoxTransferAmount.Text);


                    switch (RadioButtonListAccountType.SelectedItem.Value)
                    {
                        case "fromCheckingToSaving":


                            Transaction transferOut = new Transaction(amount, TransactionType.TRANSFER_OUT);
                            Transaction transferIn = new Transaction(amount, TransactionType.TRANSFER_IN);

                            TransactionResult transferOutresult = customers[selectedCustomerIndex].Checking.withdraw(transferOut);


                            LabelMessage.Text = transferOutresult.ToString();

                            if (transferOutresult == TransactionResult.SUCCESS)
                            {
                                customers[selectedCustomerIndex].Saving.deposit(transferIn);

                                LabelMessage.Text = "The Transaction completed and the account balance has been updated";
                            }

                            else if (transferOutresult == TransactionResult.INSUFFICIENT_FUND)
                            {

                                LabelMessage.Text = "The Transaction failed, INSUFFICIENT_FUND";

                            }
                            else if (transferOutresult == TransactionResult.EXCEED_MAX_WITHDRAW_AMOUNT)
                            {

                                LabelMessage.Text = "The Transaction failed, EXCEED_MAX_WITHDRAW_AMOUNT";
                            }
                            break;

                        case "fromSavingToChecking":

                            Transaction transferout = new Transaction(double.Parse(TextBoxTransferAmount.Text), TransactionType.TRANSFER_OUT);
                            Transaction transferin = new Transaction(double.Parse(TextBoxTransferAmount.Text), TransactionType.TRANSFER_IN);

                            TransactionResult transferOutResult = customers[selectedCustomerIndex].Saving.withdraw(transferout);


                            LabelMessage.Text = transferOutResult.ToString();

                            if (transferOutResult == TransactionResult.SUCCESS)
                            {
                                customers[selectedCustomerIndex].Checking.deposit(transferin);
                                LabelMessage.Text = "The Transaction completed and the account balance has been updated";

                            }

                            else if (transferOutResult == TransactionResult.INSUFFICIENT_FUND)
                            {

                                LabelMessage.Text = "The Transaction failed, INSUFFICIENT_FUND";

                            }
                            else if (transferOutResult == TransactionResult.EXCEED_MAX_WITHDRAW_AMOUNT)
                            {

                                LabelMessage.Text = "The Transaction failed, EXCEED_MAX_WITHDRAW_AMOUNT";
                            }

                            break;
                    }
                }
                else
                {

                    LabelMessage.Text = "At least 1 dollar and no more than the account balance!";

                }
            }

            LabelCheckingBalance.Text = customers[selectedCustomerIndex].Checking.Balance.ToString("C2");
            LabelSavingBalance.Text = customers[selectedCustomerIndex].Saving.Balance.ToString("C2");


        }
        catch (Exception ex)
        {
            LabelIndexErrorMessage.Text = ex.Message;
        }
    }

    protected void RadioButtonListAccountType_SelectedIndexChanged(object sender, EventArgs e)
    {
        LabelIndexErrorMessage.Text = "";
        LabelMessage.Text = "";
    }
}