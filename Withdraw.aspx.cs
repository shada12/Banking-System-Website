using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Withdraw : System.Web.UI.Page
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
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownListCustomerName_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            List<Customer> customers = Session["customers"] as List<Customer>;
            LabelIndexError.Text = "";
            LabelMessage.Text = "";
            TextBoxWithdrawAmount.Text = "";
            LabelCheckingBalance.Text = "";
            LabelSavingBalance.Text = "";
            LabelResultMessage.Text = "";
            CompareValidatorWithdrawAmount.Text = "";

            int selectedCustomerIndex = DropDownListCustomerName.SelectedIndex - 1;

            LabelCheckingBalance.Text = customers[selectedCustomerIndex].Checking.Balance.ToString("C2");
            LabelSavingBalance.Text = customers[selectedCustomerIndex].Saving.Balance.ToString("C2");

        }
        catch (Exception ex)
        {

            LabelIndexError.Text = ex.Message;
        }
    }

    protected void ButtonWithdraw_Click(object sender, EventArgs e)
    {

        List<Customer> customers = Session["customers"] as List<Customer>;
        try
        {

            int selectedCustomerIndex = DropDownListCustomerName.SelectedIndex - 1;

            if (RadioButtonListAccountType.SelectedIndex > -1)
            {

                if (double.Parse(TextBoxWithdrawAmount.Text) > 0)
                {

                    switch (RadioButtonListAccountType.SelectedItem.Value)
                    {
                        case "fromCheckingAccount":


                            Transaction transaction1 = new Transaction(double.Parse(TextBoxWithdrawAmount.Text), TransactionType.WITHDRAW);

                            TransactionResult result1 = customers[selectedCustomerIndex].Checking.withdraw(transaction1);


                            if (result1.ToString() == "SUCCESS")
                            {
                                // LabelMessage.Text = result1.ToString();
                                LabelResultMessage.Text = "The Transaction completed and the account balance has been updated";

                            }
                            else if (result1.ToString() == "INSUFFICIENT_FUND")
                            {

                                LabelMessage.Text = result1.ToString();
                                LabelResultMessage.Text = "The Transaction failed";
                            }
                            else if (result1.ToString() == "EXCEED_MAX_WITHDRAW_AMOUNT")
                            {

                                LabelMessage.Text = result1.ToString();
                                LabelResultMessage.Text = "The Transaction failed";
                            }

                            break;

                        case "fromSavingAccount":

                            Transaction transaction2 = new Transaction(double.Parse(TextBoxWithdrawAmount.Text), TransactionType.WITHDRAW);

                            TransactionResult result2 = customers[selectedCustomerIndex].Saving.withdraw(transaction2);

                            if (result2.ToString() == "SUCCESS")
                            {
                                LabelMessage.Text = "";
                                LabelResultMessage.Text = "The Transaction completed and the account balance has been updated";
                                CompareValidatorWithdrawAmount.Text = "";

                            }
                            else if (result2.ToString() == "INSUFFICIENT_FUND")
                            {

                                LabelMessage.Text = result2.ToString();
                                LabelResultMessage.Text = "The Transaction failed";
                                CompareValidatorWithdrawAmount.Text = "";
                            }
                            else if (result2.ToString() == "EXCEED_MAX_WITHDRAW_AMOUNT")
                            {

                                LabelMessage.Text = result2.ToString();
                                LabelResultMessage.Text = "The Transaction failed";
                                CompareValidatorWithdrawAmount.Text = "";
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

            LabelIndexError.Text = ex.Message;
        }
    }

    protected void RadioButtonListAccountType_SelectedIndexChanged(object sender, EventArgs e)
    {
        LabelIndexError.Text = "";
        LabelMessage.Text = "";
        TextBoxWithdrawAmount.Text = "";
        LabelResultMessage.Text = "";
    }

    protected void TextBoxWithdrawAmount_TextChanged(object sender, EventArgs e)
    {
        CompareValidatorWithdrawAmount.Text = " ";
        LabelMessage.Text = " ";
        LabelResultMessage.Text = " ";
    }
}