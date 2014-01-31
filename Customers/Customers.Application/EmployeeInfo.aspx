<%@ Page Title="Информация о сотруднике" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeInfo.aspx.cs" Inherits="Customers.Application.EmployeeInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
  <div>
    <div style="float: left; width: 50%;" >
      <asp:DetailsView HeaderText="<% $Resources:GlobalRes, Manager %>" ID="UserView" 
                       HeaderStyle-Font-Bold="True" HeaderStyle-Font-Size="1.2em" OnItemUpdated="UserView_OnItemUpdated"
                       runat="server" AutoGenerateRows="False" DataSourceID="ManangerDataSource" Height="50px" Width="125px" Visible="<%# IsOwner %>">
        <Fields>
          <asp:BoundField DataField="Name" ShowHeader="False" HeaderText="<%$ Resources:GlobalRes, Name %>" SortExpression="Name" />
          <asp:BoundField DataField="Id" ReadOnly="True" ShowHeader="False">
            <HeaderStyle CssClass="Hidden" />
            <ControlStyle CssClass="Hidden" />
            <ItemStyle CssClass="Hidden" />
          </asp:BoundField>
          <asp:CommandField ShowEditButton="True" EditText="<% $Resources:GlobalRes,Edit %>"
                            UpdateText="<% $Resources:GlobalRes,Update %>"  CancelText="<% $Resources:GlobalRes,Cancel %>" />
        </Fields>
      </asp:DetailsView>
      <asp:DetailsView HeaderText="<% $Resources:GlobalRes, Manager %>" DataSourceID="ManangerDataSource"
                       HeaderStyle-Font-Bold="True" HeaderStyle-Font-Size="1.2em"
                       ID="UserView1" runat="server" AutoGenerateRows="False"  Height="50px" Width="125px" Visible="<%# !IsOwner %>">
        <Fields>
          <asp:BoundField DataField="Name" ShowHeader="False" HeaderText="<%$ Resources:GlobalRes, Name %>" SortExpression="Name" />
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
        </Fields>
      </asp:DetailsView>
    </div> 
    <div style="float: right; width: 50%;">
      
      <asp:ObjectDataSource ID="SlavesDataSource" runat="server" SelectMethod="GetSlaves" TypeName="Customers.Application.DataSources.ManagerSlavesDataSource">
        <SelectParameters>
          <asp:QueryStringParameter DefaultValue="0" Name="managerId" QueryStringField="id" Type="Int32" />
        </SelectParameters>
      </asp:ObjectDataSource>
      <asp:GridView ID="Slaves" runat="server" AutoGenerateColumns="False" DataSourceID="SlavesDataSource">
        <Columns>
          <asp:TemplateField HeaderText="<% $Resources:GlobalRes, Slaves %>">
            <ItemTemplate>
              <%# Eval("User.Name") %>
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
      </asp:GridView>
      
    </div>
  </div>
  <asp:ObjectDataSource ID="ManangerDataSource" runat="server" SelectMethod="GetEmployee" UpdateMethod="UpdateEmployee"
                        TypeName="Customers.Application.DataSources.EmployeeDataSource" 
                        DataObjectTypeName="Customers.Db.Models.User" >
    <SelectParameters>
      <asp:QueryStringParameter DefaultValue="0" Name="id" QueryStringField="id" Type="Int32" />
    </SelectParameters>
  </asp:ObjectDataSource>
</asp:Content>