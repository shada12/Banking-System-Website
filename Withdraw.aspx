<%@ Page Title="" Language="C#" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" CodeFile="Withdraw.aspx.cs" Inherits="Withdraw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h1>Withdraw Fund</h1>
        <br />
        <asp:Label ID="LabelCustomerName" runat="server" Text="Customer Name:"></asp:Label>
        <asp:DropDownList ID="DropDownListCustomerName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListCustomerName_SelectedIndexChanged">
            <asp:ListItem>Select Customer</asp:ListItem>
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
    
    
    
    
        <asp:Label ID="LabelSavingAccountBalance" runat="server" Text="Saving Account Balance:"></asp:Label>
        <asp:Label ID="LabelSavingBalance" runat="server"></asp:Label>
    
    
        <br />
    <br />
    
    
        <asp:RadioButtonList ID="RadioButtonListAccountType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonListAccountType_SelectedIndexChanged">
            <asp:ListItem Value="fromCheckingAccount">From Checking Account</asp:ListItem>
            <asp:ListItem Value="fromSavingAccount">From Saving Account</asp:ListItem>
        </asp:RadioButtonList>
    
   
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorAccountType" runat="server" ControlToValidate="RadioButtonListAccountType" Display="Dynamic" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
    
   
        <br />
    <br />
    <br />
    
   
        <asp:Label ID="Label6WithdrawAmount" runat="server" Text="Withdraw Amount: "></asp:Label>
        <asp:TextBox ID="TextBoxWithdrawAmount" runat="server" OnTextChanged="TextBoxWithdrawAmount_TextChanged"></asp:TextBox>
   
    
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorWithdrawAmount" runat="server" ControlToValidate="TextBoxWithdrawAmount" Display="Dynamic" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
    
    
    <asp:CompareValidator ID="CompareValidatorWithdrawAmount" runat="server" ControlToValidate="TextBoxWithdrawAmount" Display="Dynamic" ErrorMessage="At least 1 dollar and no more than the account balance!" ForeColor="Red" Operator="GreaterThan" Type="Double" ValueToCompare="0" Visible="False"></asp:CompareValidator>
    
    
        <asp:Label ID="LabelResultMessage" runat="server" ForeColor="Red"></asp:Label>
    
    
        <asp:Label ID="LabelMessage" runat="server" ForeColor="Red"></asp:Label>
    
    
    <br />
   
    
    <br />
    <br />
   
    
        <asp:Button class="btn btn-primary" ID="ButtonWithdraw" runat="server" Text="Withdraw" OnClick="ButtonWithdraw_Click" />
        </asp:Content>

