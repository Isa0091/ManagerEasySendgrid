using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEasySendgrid.Dto
{
    public class SendEmailDataDto
    {
        /// <summary>
        /// Email al que se enviara 
        /// </summary>
        public string EmailToSend { get; set; }
        /// <summary>
        /// Identificador del template de sendgrid
        /// </summary>
        public string TemplateId { get; set; }
        /// <summary>
        /// Objeto configurado para la template
        /// </summary>
        public object Data { get; set; }
    }
}
