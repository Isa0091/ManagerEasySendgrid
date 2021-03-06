using ManagerEasySendgrid.Abstract;
using ManagerEasySendgrid.Configuration;
using ManagerEasySendgrid.Dto;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEasySendgrid
{
    public class ManagerEasySendgridProvider : IManagerEasySendgridProvider
    {
        private SendGridClient _sendGridClient;
        private readonly SendGridProviderConfiguration _sendGridProviderConfiguration;

        /// <summary>
        /// 
        /// </summary>
        public ManagerEasySendgridProvider(
           SendGridProviderConfiguration sendGridProviderConfiguration)
        {
            _sendGridProviderConfiguration = sendGridProviderConfiguration;
            _sendGridClient = new SendGridClient(_sendGridProviderConfiguration.ApiKey);
        }

        public async Task SendEmails(SendEmailsDataDto sendEmailsDataDto)
        {
            if (sendEmailsDataDto.EmailsToSend == null || sendEmailsDataDto.EmailsToSend.Any() == false)
                throw new ArgumentException("Debe enviar los emails");

            if (string.IsNullOrEmpty(sendEmailsDataDto.TemplateId))
                throw new ArgumentException("Debe enviar un templateId");

            List<Personalization> listPersonalization = new List<Personalization>();
            SendGridClient sendGridClient = new SendGridClient(_sendGridProviderConfiguration.ApiKey);

            foreach (string email in sendEmailsDataDto.EmailsToSend)
            {
                EmailAddress to = new EmailAddress(email);
                Personalization personalization =
                    new Personalization()
                    {
                        Tos = new List<EmailAddress> { to },
                        TemplateData = sendEmailsDataDto.Data
                    };

                if (sendEmailsDataDto.Data != null)
                    personalization.TemplateData = sendEmailsDataDto.Data;

                listPersonalization.Add(personalization);
            }

            EmailAddress from = new EmailAddress(_sendGridProviderConfiguration.SourceEmail, _sendGridProviderConfiguration.SourceName);

            SendGridMessage message = new SendGridMessage
            {
                From = from,
                TemplateId = sendEmailsDataDto.TemplateId,
                Personalizations = listPersonalization
            };

            Response response = await sendGridClient.SendEmailAsync(message);

            if (response.StatusCode != System.Net.HttpStatusCode.Accepted && response.StatusCode != System.Net.HttpStatusCode.OK &&
                response.StatusCode != System.Net.HttpStatusCode.Created)
            {
                string errorMessage = await response.Body.ReadAsStringAsync();
                throw new ArgumentException("Error al enviar emails con sendgrid, " + errorMessage);
            }
        }

        public async Task SendEmail(SendEmailDataDto sendEmailDataDto)
        {
            if (string.IsNullOrEmpty(sendEmailDataDto.EmailToSend))
                throw new ArgumentException("Debe enviar un email a enviar");

            await SendEmails(new SendEmailsDataDto()
            {
                TemplateId = sendEmailDataDto.TemplateId,
                Data = sendEmailDataDto.Data,
                EmailsToSend = new List<string> { sendEmailDataDto.EmailToSend }
            });
        }
    }
}
