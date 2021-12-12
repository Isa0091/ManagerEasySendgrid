using ManagerEasySendgrid.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEasySendgrid.Abstract
{
    /// <summary>
    /// Maneja los metodos a implementar del envio por sendgrid
    /// </summary>
    public interface IManagerEasySendgridProvider
    {
        /// <summary>
        /// Envia un email por sendgrid con un objeto y un template Id de sendgrid a un listado de emails enviados
        /// </summary>
        /// <param name="sendEmailsDataDto"></param>
        /// <returns></returns>
        Task SendEmails(SendEmailsDataDto sendEmailsDataDto);

        /// <summary>
        /// Envia un email por sendgrid con un objeto y un template Id de sendgrid a un email
        /// </summary>
        /// <param name="sendEmailDataDto"></param>
        /// <returns></returns>
        Task SendEmail(SendEmailDataDto sendEmailDataDto);
    }
}
