namespace Portfolio.Common.Abstractions
{
    public interface IMailProvider
    {
        Task Send(string toEmail, string subject, string body);
    }
}