<%@ Page Title="" Language="C#" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" CodeFile="Activity.aspx.cs" Inherits="Activity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
       </p>
    <h1>
        Acount Activities
    </h1>
        <br />
        <asp:Label ID="LabelCustomerName" runat="server" Text="Customer Name"></asp:Label>
        <asp:DropDownList ID="DropDownListCustomerName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem>Select Customer</asp:ListItem>
        </asp:DropDownList>
    
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCustomerName" runat="server" ControlToValidate="DropDownListCustomerName" Display="Dynamic" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
    <asp:Label ID="LabelErrorMessage" runat="server" ForeColor="Red"></asp:Label>
    
    <p>
        &nbsp;</p>
    <p>
        Checking Account Activities:</p>
    
        <asp:Table ID="TableCheckingAccount" runat="server" CssClass="table">
        </asp:Table>
    
    <p>
        &nbsp;</p>
    <p>
        Saving Account Activities:</p>
    <asp:Table ID="TableSavingAccount" runat="server" CssClass="table">
    </asp:Table>
   
    
    <br />
    <br />
    <br />
    <br />
   
    
</asp:Content>

