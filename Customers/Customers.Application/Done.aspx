<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Done.aspx.cs" Inherits="Customers.Application.Done" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
  <h1>
    <asp:Literal runat="server" Text="<% $Resources:GlobalRes, Done %>"></asp:Literal>
  </h1>
  <p>
    <asp:Literal runat="server" ID="MessageLiteral" ></asp:Literal>
  </p>
</asp:Content>