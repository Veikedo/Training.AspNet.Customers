﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Customers.Application.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
  <asp:ObjectDataSource ID="CustomersDataSource" runat="server" SelectMethod="GetCustomers" TypeName="Customers.Application.DataSources.CustomersDataSource" />
  <div>
    <div style="float: left; width: 50%;">
      <asp:GridView ID="CustomersGridView" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="#E5E5E5" OnRowDataBound="CustomersGridView_OnRowDataBound"
                    DataSourceID="CustomersDataSource" DataKeyNames="UserId">
        <Columns>
          <asp:CommandField ShowSelectButton="True" SelectText="<% $Resources:GlobalRes, Select %>" />     
          <asp:BoundField DataField="CompanyName" HeaderText="<% $Resources:GlobalRes, Company %>" SortExpression="CompanyName" ItemStyle-Width="40%" />
          <asp:BoundField DataField="UserId" ReadOnly="True" ShowHeader="False">
            <HeaderStyle CssClass="Hidden" />
            <ControlStyle CssClass="Hidden" />
            <ItemStyle CssClass="Hidden" />
          </asp:BoundField>

          <asp:TemplateField HeaderText="<% $Resources:GlobalRes, Address %>">
            <ItemTemplate>
              <%# Eval("Address.Street") %>, <%# Eval("Address.House") %>
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
      </asp:GridView>
    </div>
    <div style="float: right; width: 50%;">
      <asp:ObjectDataSource ID="OrdersDataSource" runat="server" SelectMethod="GetCustomerOrders"
                            TypeName="Customers.Application.DataSources.OrdersDataSource" 
                            DataObjectTypeName="Customers.Db.Models.Order">
        <SelectParameters>
          <asp:ControlParameter ControlID="CustomersGridView" DefaultValue="0" Name="customerId" PropertyName="SelectedDataKey.Values[&quot;UserId&quot;]" Type="Int32" />
        </SelectParameters>
      </asp:ObjectDataSource>
      <asp:GridView ID="OrdersGridView" runat="server" AutoGenerateColumns="False" DataSourceID="OrdersDataSource"
                    OnRowCommand="OrdersGridView_OnRowCommand" DataKeyNames="ManagerId">
        <Columns>
          <asp:BoundField DataField="Description" HeaderText="<% $Resources:GlobalRes, OrderDescriprtion %>">
            <ItemStyle Width="40%" />
          </asp:BoundField>
          <asp:TemplateField HeaderText="<% $Resources:GlobalRes, Manager %>">
            <ItemTemplate>
              <%# Eval("Manager.User.Name") %>
            </ItemTemplate>
            <ItemStyle Width="30%" />
          </asp:TemplateField>
          <asp:ButtonField CommandName="GetManagerInfoCommand" ButtonType="Link" Text="<% $Resources:GlobalRes, Info %>"/>
        </Columns>
      </asp:GridView>
    </div>
  </div>
</asp:Content>