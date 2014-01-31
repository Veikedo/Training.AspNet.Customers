using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using Customers.Application.App_GlobalResources;
using Customers.Application.Helpers;
using Customers.Db.Models;

namespace Customers.Application.Account
{
  public partial class PasswordReset : BasePage
  {
    private string ResetLinkGuid
    {
      get { return Request.QueryString["guid"]; }
    }

    private bool ResetLinkCorrected
    {
      get
      {
        return !string.IsNullOrEmpty(ResetLinkGuid) &&
               Repository.PasswordResetLinks.Any(x => x.Guid == ResetLinkGuid);
      }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      if (User.Identity.IsAuthenticated)
      {
        Response.Redirect("~/");
      }

      if (ResetLinkCorrected)
      {
        EmailPromptDiv.Visible = false;
      }
      else
      {
        ChangePasswordDiv.Visible = false;
      }
    }

    protected void SendButton_Click(object sender, EventArgs e)
    {
      SendResetLink(EmailTextBox.Text);
    }

    private void SendResetLink(string email)
    {
      User user = Repository.Users
                            .FirstOrDefault(x => String.Compare(x.Email, email, StringComparison.OrdinalIgnoreCase) == 0);

      if (user != null)
      {
        string guid = Guid.NewGuid().ToString("N");
        var resetLink = new PasswordResetLink {Guid = guid, User = user};

        Repository.CreatePasswordResetLink(resetLink);

        var smtpClient = new SmtpClient
        {
          Host = "smtp.gmail.com",
          Port = 587,
          UseDefaultCredentials = false,
          Credentials = new NetworkCredential("veikedo", "tpYZ2osAO"),
          EnableSsl = true,
        };

        Uri url = HttpContext.Current.Request.Url;
        string endpoint = string.Format("http://{0}{1}/{2}", url.Host, url.IsDefaultPort ? string.Empty : ":" + url.Port,
                                        "Account/PasswordReset.aspx");

        var mes = new MailMessage("admin@mustard.com", email, "Сброс пароля на Mustard PROJECTS",
                                  string.Format("Чтобы сбросить пароль, пройдите по ссылке {0}?guid={1}", endpoint, guid));
        smtpClient.Send(mes);
      }

      Response.Redirect("~/Done.aspx?mes=" + GlobalRes.ResetLinkSent, true);
    }

    protected void ChangeEmailButton_Click(object sender, EventArgs e)
    {
      PasswordResetLink resetLink = Repository.PasswordResetLinks.First(x => x.Guid == ResetLinkGuid);

      User user = resetLink.User;
      user.Password = CryptoHelper.GetPasswordHash(PasswordTextBox.Text);

      Repository.UpdateUser(user);
      Repository.RemovePasswordResetLink(resetLink.UserId);

      Response.Redirect("~/Done.aspx?mes=" + GlobalRes.PasswordChanged);
    }
  }
}