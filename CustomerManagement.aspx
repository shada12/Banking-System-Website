<%@ Page Title="" Language="C#" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" CodeFile="CustomerManagement.aspx.cs" Inherits="CustomerManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
    </p>
   <h1> Customer Managemet</h1><br />
    <br />
     
    <div  >
    <asp:Label ID="LabelCustomerName" class="form-label" runat="server" Text="Customr Name:"></asp:Label>
    <asp:TextBox ID="TextBoxCustomerName" class="form-control" runat="server" OnTextChanged="TextBoxCustomerName_TextChanged"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxCustomerName" Display="Dynamic" ForeColor="Red">Required!</asp:RequiredFieldValidator>
     </div>
        <br />
    <br />
     <div><asp:Label ID="LabelInitialDeposit" class="form-label" runat="server" Text="Initial Deposit  :            "></asp:Label>
    <asp:TextBox ID="TextBoxInitialDeposit" class="form-control" runat="server"></asp:TextBox>
    <asp:CompareValidator ID="CompareValidatorInitialAmount" runat="server" ControlToValidate="TextBoxInitialDeposit" Display="Dynamic" ErrorMessage="Must be greater than 0!" ForeColor="Red" Operator="GreaterThan" Type="Double" ValueToCompare="0"></asp:CompareValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorInitialDeposit" runat="server" ControlToValidate="TextBoxInitialDeposit" Display="Dynamic" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
         
         <br />
    <br />
    <br />
    <asp:Button class="btn btn-primary" ID="ButtonAddCustomer" runat="server" Text="Add Customer " OnClick="ButtonAddCustomer_Click"/>
    <br />
    <br />
    <br />
    <p>The following Customers are currently in the system</p>
    <asp:Table ID="TableResult" runat="server" CssClass="table">
    </asp:Table>
    <br />
</asp:Content>

