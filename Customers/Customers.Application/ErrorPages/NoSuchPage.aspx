<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NoSuchPage.aspx.cs" Inherits="Customers.Application.ErrorPages.NoSuchPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
  <h1>
    <asp:Literal runat="server" Text="<%$Resources:GlobalRes, NoSuchPage %>"></asp:Literal>
  </h1>
</asp:Content>
