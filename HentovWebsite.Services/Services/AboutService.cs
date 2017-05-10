using System;
using System.Net.Mail;
using HentovWebsite.Models.Binding.About;
using HentovWebsite.Services.Services.Contracts;
using HentovWebsite.Utility;

namespace HentovWebsite.Services.Services
{
    public class AboutService : IAboutService
    {
        public bool SendMail(SendMailBindingModel model, string host, int port, string mailCredential, string passCredential, string recepient)
        {
            try
            {
                if (host == null || mailCredential == null || passCredential == null ||
                    recepient == null)
                {
                    return false;
                }
                SmtpClient smtpClient = new SmtpClient(host, port);

                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(mailCredential, passCredential);
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;

                MailMessage theMessage = new MailMessage();

                theMessage.From = new MailAddress(model.Email);
                theMessage.To.Add(recepient);
                theMessage.Subject = model.Subject;
                theMessage.Body = model.Message;
                smtpClient.Send(theMessage);

                return true;
            }
            catch (SystemException)
            {
                return false;
            }
        }
    }
}
