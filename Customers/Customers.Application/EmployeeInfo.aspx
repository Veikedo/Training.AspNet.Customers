<%@ Page Title="Информация о сотруднике" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeInfo.aspx.cs" Inherits="Customers.Application.EmployeeInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
  <div>
    <div style="float: left; width: 50%;" >
      <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="EmployeeDataSource" Height="50px" Width="125px">
        <Fields>
          <asp:BoundField DataField="Name" HeaderText="<%$ Resources:GlobalRes, Name %>" SortExpression="Name" />
          <asp:BoundField DataField="Id" ReadOnly="True" ShowHeader="False">
            <HeaderStyle CssClass="Hidden" />
            <ControlStyle CssClass="Hidden" />
            <ItemStyle CssClass="Hidden" />
          </asp:BoundField>
          <asp:BoundField DataField="Version" ReadOnly="True" ShowHeader="False">
            <HeaderStyle CssClass="Hidden" />
            <ControlStyle CssClass="Hidden" />
            <ItemStyle CssClass="Hidden" />
          </asp:BoundField>
          <asp:CommandField ShowEditButton="True" EditText="<% $Resources:GlobalRes,Edit %>" 
                            UpdateText="<% $Resources:GlobalRes,Update %>"  CancelText="<% $Resources:GlobalRes,Cancel %>" />
        </Fields>
      </asp:DetailsView>
    </div> 
    <div style="float: right; width: 50%;">
      
      <asp:ObjectDataSource ID="SlavesDataSource" runat="server" SelectMethod="GetSlaves" TypeName="Customers.Application.DataSources.ManagerSlavesDataSource">
        <SelectParameters>
          <asp:QueryStringParameter DefaultValue="0" Name="managerId" QueryStringField="id" Type="Int32" />
        </SelectParameters>
      </asp:ObjectDataSource>
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SlavesDataSource">
        <Columns>
          <asp:BoundField DataField="Name" HeaderText="<% $Resources:GlobalRes, Name %>" SortExpression="Name" />
        </Columns>
      </asp:GridView>
      
    </div>
  </div>
  <asp:ObjectDataSource ID="EmployeeDataSource" runat="server" SelectMethod="GetEmployee" UpdateMethod="UpdateEmployee"
                        TypeName="Customers.Application.DataSources.EmployeeDataSource" 
                        DataObjectTypeName="Customers.Db.Models.Employee" >
    <SelectParameters>
      <asp:QueryStringParameter DefaultValue="0" Name="id" QueryStringField="id" Type="Int32" />
    </SelectParameters>
  </asp:ObjectDataSource>
</asp:Content>