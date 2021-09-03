using MimeKit;
using MimeKit.Text;
using System.Net.Mail;
using MailKit.Net.Smtp;

using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;

namespace dadachMovie.Helpers
{
    public class MailService
    {
        public void SendMail(string subject, string reciverMail, string body)
        {
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse("from_address@example.com"));
            message.To.Add(MailboxAddress.Parse(reciverMail));

            message.Subject = subject;
            message.Body = new TextPart(TextFormat.Html)
            {
                Text =
            $" <div dir='rtl'> <h5>{subject}</h5> <br/>  <p>{body}</p> </div>"
            };


            using var smtp = new MailKit.Net.Smtp.SmtpClient();

            smtp.Connect("smtp.gmail.com", 587, false);
            smtp.Authenticate("[USERNAME]", "[PASSWORD]");
            smtp.Send(message);
            smtp.Disconnect(true);
        }



    }
}

