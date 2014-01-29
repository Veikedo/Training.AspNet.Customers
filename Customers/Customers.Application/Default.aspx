<%@ Page Title="Заказы" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Customers.Application.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
  <asp:ObjectDataSource ID="CustomersDataSource" runat="server" SelectMethod="GetCustomers" TypeName="Customers.Application.DataSources.CustomersDataSource" />
  <div>
    <div style="float: left; width: 50%;" >
      <asp:GridView ID="CustomersGridView" runat="server" AutoGenerateColumns="False" DataSourceID="CustomersDataSource" DataKeyNames="Id" >
        <Columns>
          <asp:CommandField ShowSelectButton="True" />
          <asp:BoundField DataField="CompanyName" HeaderText="<% $Resources:GlobalRes, Company %>" SortExpression="CompanyName" ItemStyle-Width="40%" />
          <asp:TemplateField HeaderText="<% $Resources:GlobalRes, Address %>">
            <ItemTemplate>
              <%# Eval("Address.Street") %>, <%# Eval("Address.House") %>
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
      </asp:GridView>
    </div> 
    <div style="float: right; width: 50%;" >
      <asp:ObjectDataSource ID="OrdersDataSource" runat="server" SelectMethod="GetCustomerOrders" TypeName="Customers.Application.DataSources.OrdersDataSource">
        <SelectParameters>
          <asp:ControlParameter ControlID="CustomersGridView" DefaultValue="1" Name="customerId" PropertyName="SelectedDataKey.Values[&quot;Id&quot;]" Type="Int32" />
        </SelectParameters>
      </asp:ObjectDataSource>
      <asp:GridView ID="OrdersGridView" runat="server" AutoGenerateColumns="False" DataSourceID="OrdersDataSource" DataKeyNames="ManagerId" OnRowCommand="OrdersGridView_OnRowCommand" >
        <Columns>
          <asp:BoundField DataField="Description" HeaderText="<% $Resources:GlobalRes, OrderDescriprtion %>">
            <ItemStyle Width="40%" />
          </asp:BoundField>
          <asp:TemplateField HeaderText="<% $Resources:GlobalRes, Manager %>">
            <ItemTemplate>
              <%# Eval("Manager.Name") %>
            </ItemTemplate>
            <ItemStyle Width="30%" />
          </asp:TemplateField>
          <asp:ButtonField HeaderText="<% $Resources:GlobalRes, ManagerInfo %>" 
                           CommandName="GetManagerInfoCommand" ButtonType="Button" Text="<% $Resources:GlobalRes, ManagerInfoButton %>" 
            />
        </Columns>
      </asp:GridView>
    </div> 
  </div>
</asp:Content>