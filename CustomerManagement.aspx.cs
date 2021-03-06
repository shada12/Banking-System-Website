using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerManagement : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        List<Customer> customers = Session["customers"] as List<Customer>;


        if (customers == null)
        {
            customers = new List<Customer>();
            Session["customers"] = customers;

        }

        TableRow firstRow = new TableRow();
        TableCell firstRowCell = new TableCell();

        firstRowCell.Text = "Name";
        firstRowCell.BackColor = System.Drawing.Color.SkyBlue;
        firstRow.Cells.Add(firstRowCell);

        firstRowCell = new TableCell();
        firstRowCell.Text = "Checking Acount Balance";
        firstRowCell.BackColor = System.Drawing.Color.SkyBlue;
        firstRow.Cells.Add(firstRowCell);

        firstRowCell = new TableCell();
        firstRowCell.Text = "Saving Account Balance";
        firstRowCell.BackColor = System.Drawing.Color.SkyBlue;
        firstRow.Cells.Add(firstRowCell);

        firstRowCell = new TableCell();
        firstRowCell.Text = "Status";
        firstRowCell.BackColor = System.Drawing.Color.SkyBlue;
        firstRow.Cells.Add(firstRowCell);
        TableResult.Rows.Add(firstRow);

        showCustomersInformation(customers);


    }

    protected void ButtonAddCustomer_Click(object sender, EventArgs e)
    {

        List<Customer> customers = Session["customers"] as List<Customer>;

        if (customers == null)
        {
            customers = new List<Customer>();
            Session["customers"] = customers;

        }


        String customerName = TextBoxCustomerName.Text;
        double initialDeposit = double.Parse(TextBoxInitialDeposit.Text);


        Customer customer = new Customer(customerName);
        CheckingAccount checkingAccount = new CheckingAccount(customer);
        SavingAccount savingAccount = new SavingAccount(customer);

        Transaction checkingTransaction = new Transaction(0, TransactionType.DEPOSIT);
        Transaction savingTransaction = new Transaction(initialDeposit, TransactionType.DEPOSIT);

        checkingAccount.deposit(checkingTransaction);
        savingAccount.deposit(savingTransaction);


        customer.Checking = checkingAccount;
        customer.Saving = savingAccount;


        customers.Add(customer);

        showCustomersInformation(customers);


    }

    private void showCustomersInformation(List<Customer> customers)
    {
        for (int i = TableResult.Rows.Count - 1; i > 0; i--)
        {

            TableResult.Rows.RemoveAt(i);
        }


        if (customers.Count == 0 || customers == null)
        {
            TableRow lastRow = new TableRow();
            TableCell lastRowCell = new TableCell();
            lastRowCell.Text = "No customer in the system yet";
            lastRowCell.ColumnSpan = 4;
            lastRowCell.HorizontalAlign = HorizontalAlign.Center;
            lastRow.Cells.Add(lastRowCell);
            //
            TableResult.Rows.Add(lastRow);
        }
        else
        {

            foreach (Customer custmer in customers)
            {


                TableRow row = new TableRow();
                TableCell cell = new TableCell();

                cell.Text = custmer.Name;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = custmer.Checking.Balance.ToString("C2");
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = custmer.Saving.Balance.ToString("C2");
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = custmer.Status.ToString();
                row.Cells.Add(cell);
                TableResult.Rows.Add(row);
            }
        }
    }

    protected void TextBoxCustomerName_TextChanged(object sender, EventArgs e)
    {

    }
}