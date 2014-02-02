<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Customers.Application.ErrorPages.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <style type="text/css">
    .auto-style1 {
      width: 251px;
      height: 357px;
    }
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
  <h2>
    <asp:Literal runat="server" Text="<% $Resources:GlobalRes,WeGoingToMakeItGood %>"></asp:Literal>
  </h2>
  
  <img alt="Wet pussy" class="auto-style1" src="~/Images/cat.jpg" runat="server" />
</asp:Content>
