using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEasySendgrid.Dto
{
    public class SendEmailsDataDto
    {
        /// <summary>
        /// 
        /// </summary>
        public SendEmailsDataDto()
        {
            EmailsToSend = new List<string>();
        }
        /// <summary>
        /// Requerido: Listado de emails 
        /// </summary>
        public List<string> EmailsToSend { get; set; }
        /// <summary>
        /// Requerido: Identificador del template de sendgrid
        /// </summary>
        public string TemplateId { get; set; }
        /// <summary>
        /// Opcional: Objeto configurado para la template
        /// </summary>
        public object Data { get; set; }
    }
}
