namespace SpaceProgram.IO;

using System.Net;
using System.Net.Mail;

using Interfaces;
using GCommon.Exceptions;

using static GCommon.Constants.ApplicationConstants;
using static GCommon.Constants.Messages;

public class EmailSender : IEmailSender
{
    public async Task<bool> SendGmailAsync(string[] from, string to, string subject, string body)
    {
        using SmtpClient gmailClient = new SmtpClient();
        
        gmailClient.Host = GmailSmtpHost;
        gmailClient.Port = GmailSmtpPort;
        gmailClient.EnableSsl = GmailEnableSsl;
        gmailClient.UseDefaultCredentials = GmailUseDefaultCredentials;
        gmailClient.Credentials = new NetworkCredential(userName: from[0], password: from[1]);

        using MailMessage message = new MailMessage(from[0], to, subject, body);
        
        try
        {
            await gmailClient.SendMailAsync(message);
            return true;
        }
        catch (SmtpException se)
        {
            throw new EmailSendingException(EmailSendingFailedMessage, se);
        }
        catch (InvalidOperationException ioe)
        {
            throw new EmailSendingException(EmailSendingFailedMessage, ioe);
        }
    }
}