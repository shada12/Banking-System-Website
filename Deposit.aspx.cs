using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Deposit : System.Web.UI.Page
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

    protected void DropDownListCustomerName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<Customer> customers = Session["customers"] as List<Customer>;

            TextBoxDepositAmount.Text = "";
            LabelCheckingBalance.Text = "";
            LabelSavingBalance.Text = "";
            LabelConfirmation.Text = "";
            LabelIndexError.Text = "";


            int selectedCustomerIndex = DropDownListCustomerName.SelectedIndex - 1;

            LabelCheckingBalance.Text = customers[selectedCustomerIndex].Checking.Balance.ToString("C2");
            LabelSavingBalance.Text = customers[selectedCustomerIndex].Saving.Balance.ToString("C2");

        }
        catch (Exception ex)
        {

            LabelIndexError.Text = ex.Message;

        }
    }

    protected void ButtonDeposit_Click(object sender, EventArgs e)
    {
        try
        {

            List<Customer> customers = Session["customers"] as List<Customer>;


            int selectedCustomerIndex = DropDownListCustomerName.SelectedIndex - 1;

            if (RadioButtonListAccountType.SelectedIndex > -1)
            {
                if (double.Parse(TextBoxDepositAmount.Text) > 0)
                {
                    Transaction transaction = new Transaction(double.Parse(TextBoxDepositAmount.Text), TransactionType.DEPOSIT);

                    switch (RadioButtonListAccountType.SelectedItem.Value)
                    {
                        case "toCheckingAccount":

                            customers[selectedCustomerIndex].Checking.deposit(transaction);

                            break;

                        case "toSavingAccount":

                            customers[selectedCustomerIndex].Saving.deposit(transaction);


                            break;
                    }
                    LabelConfirmation.Text = "The transaction completed and the account balance has been updated";
                    LabelConfirmation.ForeColor = System.Drawing.Color.Red;


                }
                else
                {

                    LabelConfirmation.Text = "Must be greater than 0!";


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

    protected void TextBoxDepositAmount_TextChanged(object sender, EventArgs e)
    {
        LabelConfirmation.Text = " ";
        LabelIndexError.Text = " ";
    }

    protected void RadioButtonListAccountType_SelectedIndexChanged(object sender, EventArgs e)
    {
        LabelConfirmation.Text = " ";
        LabelIndexError.Text = " ";
    }
}