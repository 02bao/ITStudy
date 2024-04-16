using MailKit.Net.Smtp;
using MimeKit;

namespace ITStudy.Repository
{
    public class EmailService
    {
        public string Email { get; set; } = "thaibaoluong02@gmail.com";
        public string Name { get; set; } = "Thai Bao";
        public string SmtpService { get; set; } = "smtp.gmail.com";
        public int Port { get; set; } = 587;
        public string SmtpName { get; set; } = "thaibaoluong02@gmail.com";
        public string SmtpPassword { get; set; } = "uypq kjwj nqxi dpzq";

        public bool SendEmail(string ReceiveEmail, string ReceiveName, string Subjects, string Body)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(Name, Email));
                message.To.Add(new MailboxAddress( ReceiveName, ReceiveEmail));
                message.Subject = Subjects;
                var builder = new BodyBuilder();
                builder.TextBody = Body;
                message.Body = builder.ToMessageBody();
                using (var client = new SmtpClient())
                {
                    client.Connect(SmtpService, Port, false);
                    client.Authenticate(SmtpName, SmtpPassword);
                    client.Send(message);
                    client.Disconnect(true);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
    
}
