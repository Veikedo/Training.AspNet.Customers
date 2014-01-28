<%@ Page Title="<%$Resources:GlobalRes, Register%>" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Customers.Application.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
  <hgroup class="title">
    <h1><%: Title %>.</h1>
  </hgroup>

  <asp:CreateUserWizard runat="server" ID="RegisterUser" ViewStateMode="Disabled" OnCreatedUser="RegisterUser_CreatedUser">
    <LayoutTemplate>
      <asp:PlaceHolder runat="server" ID="wizardStepPlaceholder" />
      <asp:PlaceHolder runat="server" ID="navigationPlaceholder" />
    </LayoutTemplate>
    <WizardSteps>
      <asp:CreateUserWizardStep runat="server" ID="RegisterUserWizardStep">
        <ContentTemplate>
          <p class="message-info">
            <asp:Literal runat="server" Text="<%$Resources:GlobalRes, PasswordLengthWarning%>" />
            <%: Membership.MinRequiredPasswordLength %> 
            <asp:Literal runat="server" Text="<%$Resources:GlobalRes, CharactersLengh%>" />
          </p>

          <p class="validation-summary-errors">
            <asp:Literal runat="server" ID="ErrorMessage" />
          </p>

          <fieldset>
            <legend>Registration Form</legend>
            <ol>
              <li>
                <asp:Label runat="server" AssociatedControlID="UserName">
                      <asp:Literal runat="server" Text="<%$Resources:GlobalRes, UserName%>" />
                </asp:Label>
                <asp:TextBox runat="server" ID="UserName" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                            CssClass="field-validation-error" ErrorMessage="<% $Resources:GlobalRes, UserNameRequired %>" />
              </li>
              <li>
                <asp:Label runat="server" AssociatedControlID="Email">Email</asp:Label>
                <asp:TextBox runat="server" ID="Email" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                            CssClass="field-validation-error" ErrorMessage="<% $Resources:GlobalRes, EmailNameRequired %>" />
              </li>
              <li>
                <asp:Label runat="server" AssociatedControlID="Password">
                              <asp:Literal runat="server" Text="<%$Resources:GlobalRes, Password%>" />
                </asp:Label>
                <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                                            CssClass="field-validation-error" ErrorMessage="<% $Resources:GlobalRes, PasswordRequired %>" />
              </li>
              <li>
                <asp:Label runat="server" AssociatedControlID="ConfirmPassword">
                              <asp:Literal runat="server" Text="<%$Resources:GlobalRes, ConfirmPassword%>" />
                </asp:Label>
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                                            CssClass="field-validation-error" Display="Dynamic" ErrorMessage="<% $Resources:GlobalRes, ConfirmPasswordRequired %>" />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                      CssClass="field-validation-error" Display="Dynamic" ErrorMessage="<% $Resources:GlobalRes, ConfirmPasswordNotMatch %>" />
              </li>
            </ol>
            <asp:Button runat="server" CommandName="MoveNext" Text="<% $Resources:GlobalRes, Register %>" />
          </fieldset>
        </ContentTemplate>
        <CustomNavigationTemplate />
      </asp:CreateUserWizardStep>
    </WizardSteps>
  </asp:CreateUserWizard>
</asp:Content>