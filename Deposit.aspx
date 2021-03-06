<%@ Page Title="" Language="C#" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" CodeFile="Deposit.aspx.cs" Inherits="Deposit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



    
    <h1>  Deposit Fund</h1>
        <br />

        <asp:Label ID="LabelCustomerName" runat="server" Text="Customer Name:"></asp:Label>
   





    <asp:DropDownList ID="DropDownListCustomerName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListCustomerName_SelectedIndexChanged">
        <asp:ListItem Value="0">Select Customer</asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCustomerName" runat="server" ControlToValidate="DropDownListCustomerName" Display="Dynamic" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
    <asp:Label ID="LabelIndexError" runat="server" ForeColor="Red"></asp:Label>
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:Label ID="LabelCheckingAccountBalance" runat="server" Text="Checking Account Balance:"></asp:Label>
    <asp:Label ID="LabelCheckingBalance" runat="server"></asp:Label>
    <br />
    <asp:Label ID="Label3SavingAccountBalance" runat="server" Text="Saving Account Balance:"></asp:Label>
    <asp:Label ID="LabelSavingBalance" runat="server"></asp:Label>
    <br />
    <br />
    <asp:RadioButtonList ID="RadioButtonListAccountType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonListAccountType_SelectedIndexChanged">
        <asp:ListItem Value="toCheckingAccount">To Checking Account</asp:ListItem>
        <asp:ListItem Value="toSavingAccount">To Saving Account</asp:ListItem>
    </asp:RadioButtonList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorAccountType" runat="server" ControlToValidate="RadioButtonListAccountType" Display="Dynamic" ErrorMessage="Required1" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <br />
    <br />
    <br />
    <asp:Label ID="LabelDepositAmount" runat="server" Text="Deposit Amount: "></asp:Label>
    <asp:TextBox ID="TextBoxDepositAmount" runat="server" OnTextChanged="TextBoxDepositAmount_TextChanged"></asp:TextBox>
    <asp:CompareValidator ID="CompareValidatorDepositAmount" runat="server" ControlToValidate="TextBoxDepositAmount" Display="Dynamic" ErrorMessage="Must be greater then 0!" ForeColor="#CC0000" Operator="GreaterThan" Type="Double" ValueToCompare="0" Visible="False"></asp:CompareValidator>
    <asp:Label ID="LabelConfirmation" runat="server" ForeColor="Red"></asp:Label>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDepositAmount" runat="server" ControlToValidate="TextBoxDepositAmount" Display="Dynamic" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Button class="btn btn-primary" ID="ButtonDeposit" runat="server"  Text="Deposit" Width="80px" OnClick="ButtonDeposit_Click" />
   





</asp:Content>

