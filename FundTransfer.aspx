<%@ Page Title="" Language="C#" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" CodeFile="FundTransfer.aspx.cs" Inherits="FundTransfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p></p>
    <h1> Transfer Fund</h1>
        <br />
        <asp:Label ID="LabelCustomerName" runat="server" Text="Customer Name:"></asp:Label>
        <asp:DropDownList ID="DropDownListCustomerName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem>Select Customer</asp:ListItem>
        </asp:DropDownList>
    
    
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCustomerName" runat="server" ControlToValidate="DropDownListCustomerName" Display="Dynamic" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
    <asp:Label ID="LabelIndexErrorMessage" runat="server" ForeColor="Red"></asp:Label>
    
    
        <br />
    <br />
    <br />
    
    
        <asp:Label ID="LabelCheckingAccountBalance" runat="server" Text="Checking Account Balance:"></asp:Label>
        <asp:Label ID="LabelCheckingBalance" runat="server"></asp:Label>
    
    
        <br />
    <br />
    
    
        <asp:Label ID="LabelSavingAccountBalance" runat="server" Text="Saving Account Balance"></asp:Label>
        <asp:Label ID="LabelSavingBalance" runat="server"></asp:Label>
    
    
        
    <br />
    <br />
    
    
        
    <asp:RadioButtonList ID="RadioButtonListAccountType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonListAccountType_SelectedIndexChanged">
        <asp:ListItem Value="fromCheckingToSaving">From Checking to Saving</asp:ListItem>
        <asp:ListItem Value="fromSavingToChecking">From Saving to  Checking</asp:ListItem>
    </asp:RadioButtonList>
    
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorAccountType" runat="server" ControlToValidate="RadioButtonListAccountType" Display="Dynamic" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
    
        <br />
    <br />
    <br />
    
        <asp:Label ID="LabelTransferAmount" runat="server" Text="Transfer Amount:"></asp:Label>
        <asp:TextBox ID="TextBoxTransferAmount" runat="server"></asp:TextBox>
    
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTransferAmount" runat="server" ControlToValidate="TextBoxTransferAmount" Display="Dynamic" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
    
    <asp:CompareValidator ID="CompareValidatorTransferAmount" runat="server" ControlToValidate="TextBoxTransferAmount" Display="Dynamic" ErrorMessage="At least 1 dollar and no more than the account balance!" ForeColor="Red" Operator="GreaterThan" Type="Double" ValueToCompare="0" Visible="False"></asp:CompareValidator>
   
        <asp:Label ID="LabelMessage" runat="server" ForeColor="Red"></asp:Label>
   
    <br />
    <br />
    <br />
    <br />
    
        <asp:Button class="btn btn-primary" ID="ButtonTransfer" runat="server" OnClick="ButtonTransfer_Click" Text="Transfer" />
        <br />
    <br />
   
</asp:Content>

