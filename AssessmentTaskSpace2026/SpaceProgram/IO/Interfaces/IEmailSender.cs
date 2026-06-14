namespace SpaceProgram.IO.Interfaces;

public interface IEmailSender
{
    Task<bool> SendGmailAsync(string[] from, string to, string subject, string body);
}