using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Activity : System.Web.UI.Page
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
        LabelErrorMessage.Text = "";

        try
        {
            List<Customer> customers = Session["customers"] as List<Customer>;



            int selectedCustomerIndex = DropDownListCustomerName.SelectedIndex - 1;



            TableRow firstRow = new TableRow();
            TableCell firstRowCell = new TableCell();

            firstRowCell.Text = "Date";
            firstRowCell.BackColor = System.Drawing.Color.SkyBlue;
            firstRow.Cells.Add(firstRowCell);

            firstRowCell = new TableCell();
            firstRowCell.Text = "Amount";
            firstRowCell.BackColor = System.Drawing.Color.SkyBlue;
            firstRow.Cells.Add(firstRowCell);

            firstRowCell = new TableCell();
            firstRowCell.Text = "Transaction Type";
            firstRowCell.BackColor = System.Drawing.Color.SkyBlue;
            firstRow.Cells.Add(firstRowCell);

            TableCheckingAccount.Rows.Add(firstRow);

            TableRow firstrow = new TableRow();
            TableCell firstrowCell = new TableCell();

            firstrowCell.Text = "Date";
            firstrowCell.BackColor = System.Drawing.Color.SkyBlue;
            firstrow.Cells.Add(firstrowCell);

            firstrowCell = new TableCell();
            firstrowCell.Text = "Amount";
            firstrowCell.BackColor = System.Drawing.Color.SkyBlue;
            firstrow.Cells.Add(firstrowCell);

            firstrowCell = new TableCell();
            firstrowCell.Text = "Transaction Type";
            firstrowCell.BackColor = System.Drawing.Color.SkyBlue;
            firstrow.Cells.Add(firstrowCell);

            TableSavingAccount.Rows.Add(firstrow);



            List<Transaction> checkingTransactions = customers[selectedCustomerIndex].Checking.TransactionHistory;
            List<Transaction> savingTransactions = customers[selectedCustomerIndex].Saving.TransactionHistory;



            for (int i = 0; i < checkingTransactions.Count(); i++)
            {

                TableRow row = new TableRow();
                TableCell cell = new TableCell();

                cell.Text = checkingTransactions[i].TransactionDate.ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = checkingTransactions[i].Amount.ToString("C2");
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = checkingTransactions[i].type.ToString();
                row.Cells.Add(cell);


                TableCheckingAccount.Rows.Add(row);
            }


            for (int i = 0; i < savingTransactions.Count(); i++)
            {

                TableRow row = new TableRow();
                TableCell cell = new TableCell();

                cell.Text = savingTransactions[i].TransactionDate.ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = savingTransactions[i].Amount.ToString("C2");
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = savingTransactions[i].type.ToString();
                row.Cells.Add(cell);


                TableSavingAccount.Rows.Add(row);
            }

        }
        catch (Exception ex)
        {

            LabelErrorMessage.Text = ex.Message;
        }

    }
}