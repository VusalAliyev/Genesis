using System.Net;
using System.Net.Mail;

namespace Genesis.Infrastructure.Services;

public static class EmailService
{
    public static void SendEmail(string toWho, string content)
    {
        string from = "aliev.hsyn@gmail.com";
        string to = toWho;
        string subject = "Confirm you email";
        string body = content;

        MailMessage mailMessage = new(
            from,
            to,
            subject,
            body
        );
        mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
        mailMessage.IsBodyHtml = true;

        SmtpClient client = new("smtp.gmail.com", 587);
        client.EnableSsl = true;
        client.UseDefaultCredentials = false;
        client.Credentials = new NetworkCredential(from, "vktvykutjpgmwvyz");
        try
        {
            client.Send(mailMessage);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
