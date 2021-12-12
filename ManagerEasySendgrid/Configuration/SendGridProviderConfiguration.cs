using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEasySendgrid.Configuration
{
    public class SendGridProviderConfiguration
    {
        /// <summary>
        /// Api key de sendgrid
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Email desde el cual se envian 
        /// </summary>
        public string SourceEmail { get; set; }

        /// <summary>
        /// nombre del Email desde el cual se envian
        /// </summary>
        public string SourceName { get; set; }
    }
}
