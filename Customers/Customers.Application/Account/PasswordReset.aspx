<%@ Page Title="Восстановление доступа" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PasswordReset.aspx.cs" Inherits="Customers.Application.Account.PasswordReset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
  <div runat="server" ID="EmailPromptDiv" >
    <asp:Literal runat="server" Text="<% $Resources:GlobalRes, PasswordRecoveryInfo %>" />
    <br />
    <br />
    <asp:Label runat="server" AssociatedControlID="EmailTextBox">
      <asp:Literal runat="server" Text="Email" />
    </asp:Label><asp:TextBox runat="server" ID="EmailTextBox" />
    <asp:RegularExpressionValidator runat="server" ControlToValidate="EmailTextBox" ValidationExpression=".+@.+\..+"
                                    CssClass="field-validation-error" Display="Dynamic" ErrorMessage="<% $Resources:GlobalRes, EmailRequired %>" />
    <br />
    <asp:Button ID="Button1" runat="server" Text="<% $Resources:GlobalRes, Ready %>" OnClick="SendButton_Click" />
  </div>
  <div runat="server" ID="ChangePasswordDiv">
    <asp:Label runat="server" AssociatedControlID="PasswordTextBox">
      <asp:Literal runat="server" Text="<% $Resources:GlobalRes, Password %>" />
    </asp:Label><asp:TextBox runat="server" ID="PasswordTextBox" TextMode="Password" />
    <asp:RequiredFieldValidator runat="server" ControlToValidate="PasswordTextBox"
                                CssClass="field-validation-error" ErrorMessage="<% $Resources:GlobalRes, PasswordRequired %>" />

    <asp:Label runat="server" AssociatedControlID="ConfirmPasswordTextBox">
      <asp:Literal runat="server" Text="<%$Resources:GlobalRes, ConfirmPassword%>" />
    </asp:Label><asp:TextBox runat="server" ID="ConfirmPasswordTextBox" TextMode="Password" />
    <br />
    <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPasswordTextBox"
                                CssClass="field-validation-error" Display="Dynamic" ErrorMessage="<% $Resources:GlobalRes, ConfirmPasswordRequired %>" />
    <asp:CompareValidator runat="server" ControlToCompare="PasswordTextBox" ControlToValidate="ConfirmPasswordTextBox"
                          CssClass="field-validation-error" Display="Dynamic" ErrorMessage="<% $Resources:GlobalRes, ConfirmPasswordNotMatch %>" />
    <br />
    <asp:Button ID="Button2" runat="server" Text="<% $Resources:GlobalRes, Ready %>" OnClick="ChangeEmailButton_Click" /></div>
</asp:Content>