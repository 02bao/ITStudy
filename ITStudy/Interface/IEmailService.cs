namespace ITStudy.Interface
{
    public interface IEmailService
    {
        string Email { get; set; }
        string Name { get; set; }
        int Port { get; set; }
        string SmtpName { get; set; }
        string SmtpPassword { get; set; }
        string SmtpService { get; set; }

        bool SendEmail(string ReceiveEmail, string ReceiveName, string Subjects, string Body);
        bool SendRegisterEmail(string ReceiveEmails, string ReceiveName, string Tokens);
    }
}