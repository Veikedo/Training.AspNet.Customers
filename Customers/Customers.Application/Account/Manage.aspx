﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Customers.Application.Account.Manage" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
  <hgroup class="title">
    <h1><%: Title %></h1>
  </hgroup>

  <div style="float: left; width: 50%;">
    <section id="passwordForm">
      <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
        <p class="message-success"><%: SuccessMessage %></p>
      </asp:PlaceHolder>
      <asp:PlaceHolder runat="server" ID="changePassword" Visible="false">
        <h3>
          <asp:Localize Text="<%$ Resources: GlobalRes, ChangePwd %>" runat="server" /></h3>
        <asp:ChangePassword runat="server" CancelDestinationPageUrl="~/" ViewStateMode="Disabled" RenderOuterTable="false" SuccessPageUrl="Manage?m=ChangePwdSuccess">
          <ChangePasswordTemplate>
            <p class="validation-summary-errors">
              <asp:Literal runat="server" ID="FailureText" />
            </p>
            <fieldset class="changePassword">
              <legend>Change password details</legend>
              <ol>
                <li>
                  <asp:Label runat="server" ID="CurrentPasswordLabel" AssociatedControlID="CurrentPassword" Text="<%$Resources:GlobalRes,CurrentPassword %>"></asp:Label>
                  <asp:TextBox runat="server" ID="CurrentPassword" CssClass="passwordEntry" TextMode="Password" />
                  <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword"
                                              CssClass="field-validation-error" ErrorMessage="<%$Resources:GlobalRes,ConfirmPasswordRequired %>"
                                              ValidationGroup="ChangePassword" />
                </li>
                <li>
                  <asp:Label runat="server" ID="NewPasswordLabel" AssociatedControlID="NewPassword" Text="<%$Resources:GlobalRes,NewPassword %>"></asp:Label>
                  <asp:TextBox runat="server" ID="NewPassword" CssClass="passwordEntry" TextMode="Password" />
                  <asp:RequiredFieldValidator runat="server" ControlToValidate="NewPassword"
                                              CssClass="field-validation-error" ErrorMessage="<%$Resources:GlobalRes, NewPasswordRequired %>"
                                              ValidationGroup="ChangePassword" />
                </li>
                <li>
                  <asp:Label runat="server" ID="ConfirmNewPasswordLabel" AssociatedControlID="ConfirmNewPassword" Text="<%$Resources:GlobalRes,ConfirmNewPwd %>"></asp:Label>
                  <asp:TextBox runat="server" ID="ConfirmNewPassword" CssClass="passwordEntry" TextMode="Password" />
                  <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmNewPassword"
                                              CssClass="field-validation-error" Display="Dynamic" ErrorMessage="<%$Resources:GlobalRes,ConfirmNewPwdRequired %>"
                                              ValidationGroup="ChangePassword" />
                  <asp:CompareValidator runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                                        CssClass="field-validation-error" Display="Dynamic" ErrorMessage="<%$Resources:GlobalRes,ConfirmPasswordNotMatch %>"
                                        ValidationGroup="ChangePassword" />
                </li>
              </ol>
              <asp:Button runat="server" CommandName="ChangePassword" Text="<%$Resources:GlobalRes, ChangePwd %>" ValidationGroup="ChangePassword" />
            </fieldset>
          </ChangePasswordTemplate>
        </asp:ChangePassword>
      </asp:PlaceHolder>
    </section>
  </div>
  <div style="float: right; width: 50%;" runat="server" id="SelectManagerDiv" Visible="False">

    <asp:ObjectDataSource ID="ManagersDataSoure" runat="server" SelectMethod="GetEmployeeCards" 
                          TypeName="Customers.Application.DataSources.EmployeeCardsDataSource"></asp:ObjectDataSource>
    <asp:GridView ID="ManagersGridView" runat="server" DataSourceID="ManagersDataSoure" 
                  AutoGenerateColumns="False" SelectedRowStyle-BackColor="#E5E5E5" OnRowDataBound="ManagersGridView_OnRowDataBound"
                  DataKeyNames="UserId" OnSelectedIndexChanged="EmployeesGridView_SelectedIndexChanged">
      <Columns>
        <asp:CommandField ShowSelectButton="True" SelectText="<% $Resources:GlobalRes, Select %>" />
        <asp:BoundField  DataField="UserId" Visible="False" ReadOnly="True" ShowHeader="False"/>
        <asp:TemplateField HeaderText="<% $Resources:GlobalRes, SelectManager %>">
          <ItemTemplate>
            <%# Eval("User.Name") %>
          </ItemTemplate>
        </asp:TemplateField>
      </Columns>

    </asp:GridView>
  </div>
</asp:Content>