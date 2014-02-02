<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateOrder.aspx.cs" Inherits="Customers.Application.Customer.CreateOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
  <asp:ObjectDataSource ID="EmployeesDataSource" runat="server" SelectMethod="GetEmployeeCards" TypeName="Customers.Application.DataSources.EmployeeCardsDataSource"></asp:ObjectDataSource>
  <div style="float: left; width: 50%;">
    <asp:GridView ID="ManagersGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="UserId"
                  SelectedRowStyle-BackColor="#E5E5E5" DataSourceID="EmployeesDataSource" 
                  OnSelectedIndexChanged="Managers_SelectedIndexChanged">
      <Columns>
        <asp:CommandField ShowSelectButton="True" SelectText="<% $Resources:GlobalRes, Select %>" />
        <asp:TemplateField HeaderText="<% $Resources:GlobalRes, Employees %>">
          <ItemTemplate>
            <%# Eval("User.Name") %>
          </ItemTemplate>
        </asp:TemplateField>
      </Columns>
    </asp:GridView>
  </div>
  <div runat="server" style="float: right; width: 50%;" id="OrderDescriptionDiv" Visible="False">
    <asp:Label runat="server" AssociatedControlID="DescriptionTextBox">
      <asp:Literal runat="server" Text="<%$Resources:GlobalRes, Description%>" />
    </asp:Label><asp:TextBox runat="server" ID="DescriptionTextBox" />
    <asp:RequiredFieldValidator runat="server" ControlToValidate="DescriptionTextBox"
                                CssClass="field-validation-error"
                                ErrorMessage="<% $Resources:GlobalRes, OrderDescriptionRequired %>" />

    <asp:Button ID="CreateOrderButton" runat="server" Text="<% $Resources:GlobalRes, CreateOrder %>" OnClick="CreateOrderButton_Click" /></div>
</asp:Content>